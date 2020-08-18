import requests
import time
import random
import logging
import json

import abc

from requests_toolbelt.utils import dump

DebugResponse = False

# MetaSV 
#   - 0.25sat/byte
#   - 交易体积上限为 15M
#   - 广播接口: /merchants/tx/broadcast
#   - 广播文档: https://metasv.com/#bc60c7b38b
#
#   - 参数传递方式与打点不同： metasv 传 json 

# Fee Specification 手续费的说明及确定性手续费的计算
# https://github.com/bitcoin-sv-specs/brfc-misc/tree/master/feespec


class MAPI(metaclass=abc.ABCMeta):
    def __init__(self):
        pass

    @abc.abstractmethod
    def post_tx(self, hex_tx):
        pass

    @abc.abstractmethod
    def endpoint_url(self):
        pass


class MAPI_MetaSV(MAPI):
    def __init__(self):
        pass
    
    def APIError(self, msg):
        return Exception("<{}> APIError: {}".format(self.__class__.__name__, msg) )

    def post_tx(self, hex_tx):
        resp = requests.post(self.endpoint_url(), json={'rawHex': hex_tx})

        if DebugResponse:
            logging.debug("<metasv> post_tx (full detail)\n{}".format(dump.dump_all(resp).decode('utf-8')))

        try:
            resp = resp.json()
        except Exception as e:
            raise self.APIError("invalid json return value: {}\n (full content attached) \n{}".format(e, json.dumps(resp, indent=4, sort_keys=True))) from e

        if not resp['success'] or resp['code'] != 200:
            raise self.APIError("invoking failed (code={}, msg={})".format(resp['code'], resp['message']))

        if 'error' in resp['data'] and resp['data']['error']:
            err = resp['data']['error']
            raise self.APIError("runtime error (err_code={}, err_msg={})".format(err['code'], err['message']))

        if 'hash' not in resp['data'] or not resp['data']['hash']:
            raise self.APIError("field missing or empty (resp['data']['hash'])")

        logging.info("<metasv> post_tx() done successfully (txid={})".format(resp['data']['hash']))
        return resp['data']['hash']

    def endpoint_url(self):
        return 'https://api.metasv.com/v1/merchants/tx/broadcast'


class MAPI_Mempool(MAPI):
    def __init__(self):
        pass
    
    def post_tx(self, hex_tx):
        headers = {
            'token': '561b756d12572020ea9a104c3441b71790acbbce95a6ddbf7e0630971af9424b',
            }
        data = {
            'rawtx': hex_tx,
            }
        resp = requests.post(self.endpoint_url(), headers=headers, data=data)

        if DebugResponse:
            data = dump.dump_all(resp)
            print(data.decode('utf-8'))

        try:
            resp = resp.json()
            inner = json.loads(resp['payload'])

            if not inner or inner['returnResult'] != "success":
                raise ValueError("<mempool> failed to broadcast")

            return inner['txid'].strip('\"')
        except Exception as e:
            raise ValueError("<mempool> bad_broadcast: \n{}".format(json.dumps(resp, indent=4, sort_keys=True))) from e


    def endpoint_url(self):
        return 'https://www.ddpurse.com/openapi/mapi/tx'



TargetLut = {
    "metasv": MAPI_MetaSV(),
    "mempool": MAPI_Mempool(),
}

def mapi_sendtx(txhex, target):
    if target not in TargetLut:
        raise ValueError("unknown target: " + target)
    
    m = TargetLut[target]
    return m.post_tx(txhex)



if __name__ == "__main__":
    foo = MAPI_MetaSV()
    print(foo.endpoint_url())
