import requests
import time
import random
import logging

from requests_toolbelt.utils import dump

from bitsv import op_return

OP_0 = b'\x00'
OP_RETURN = b'\x6a'

#-----------------------------------------
# 打点的小额支付接口，目前已经不再被用于数据上链
#-----------------------------------------

# 这里我们手动拼一下
def dot_opreturn_build_hex_str(content):
    bytes_list = []
    if isinstance(content, str):
        bytes_list = [content.encode('utf-8')]
    else:
        bytes_list = [x.encode('utf-8') for x in content]

    prefix = OP_0 + OP_RETURN
    pushdata = b''
    for data in bytes_list:
        pushdata += op_return.get_op_pushdata_code(data) + data
    return (prefix + pushdata).hex()


DebugResponse = False

# 打点“小额支付”接口
def dot_pay_small_money(opreturn_content):
    timestamp = int(time.time()) * 10000 + random.randint(0, 999)

    hexstr = dot_opreturn_build_hex_str(opreturn_content)

    url = 'https://www.ddpurse.com/openapi/pay_small_money'
    params = {
        'app_id': '1c305f3a358735d34ae4b22d547c3b26',
        'secret': 'bc149284965c4907c51d894ec816a95a',
        'merchant_order_sn': str(timestamp),
        'pre_amount': 700,      # 要支付的最小金额
        'user_open_id': '422b7312366f18d68bc45c6d2f2de09d',
        'item_name': 'bsv_engrave',
        'opreturn': hexstr,
        'receive_address': '[]',    # gulu 2020-03-12 
                                    # 这里如果显式地指明 []，打点会认为这是数据上链，
                                    # 不再产生 700 sat. 到商户地址的输出，改为自己发送给自己
                                    # 而且仅消耗一半的手续费 0.5 sat/byte
        }

    resp = requests.post(url, data = params)

    if DebugResponse:
        data = dump.dump_all(resp)
        print(data.decode('utf-8'))

    resp = resp.json()
    if resp['code'] != 0:
        logging.error("'dot_engrave' failed: <bad_txid:{}>".format(resp['msg']))
        return "<bad_txid:{}>".format(resp['msg'])

    logging.info("'dot_engrave' done: order_sn={}, pay_txid={}".format(resp['data']['order_sn'], resp['data']['pay_txid']))
    return resp['data']['pay_txid']

# txid = dot_engrave('test')
# print(txid)

