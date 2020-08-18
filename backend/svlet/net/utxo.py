import logging
import json
import requests

from requests_toolbelt.utils import dump

from bitsv.network.meta import Unspent

DebugResponse = False

def _error(msg, url, resp):
    msg = ("[APIError] <{}> {} \n".format("MetaSV", msg))
    msg = ("- url: {}\n".format(url))
    msg += "- resp (full detail): \n{}\n".format(json.dumps(resp, indent=4, sort_keys=True))
    raise ValueError(msg)


"""
source: https://metasv.com/#utxo-2

{
    "code": 200,
    "data": [
        {
            "id": 4701050,
            "address": "12higDjoCCNXSA95xZMWUdPvXNmkAduhWv",
            "txid": "3541514998f58a38443878d0904033f519cb26820e9d88ccb5b22a90c3f34d1b",
            "outputIndex": 0,
            "value": 500000,
            "height": 576239,
            "ancestors": 0,
            "descendents": 0
        },
        {
            "id": 5376917,
            "address": "12higDjoCCNXSA95xZMWUdPvXNmkAduhWv",
            "txid": "e798e31cecf8a73ecf66402e702d28a91f99be46c09bee73a2e04a2068f2451f",
            "outputIndex": 0,
            "value": 9990,
            "height": 576240,
            "ancestors": 0,
            "descendents": 0
        }
    ],
    "message": null,
    "success": true
}
"""

class UTXO_MetaSV():
    def __init__(self, addr):
        self._addr = addr
        self._endpoint_url = "https://api.metasv.com/v1/address/{}/utxo".format(self._addr)
    
    def error(self, msg):
        _error(msg, self._endpoint_url, self._resp)

    def query_latest(self):
        """ 查询给定地址的 utxo 集 """
        self._resp = requests.get(self._endpoint_url)

        try:
            self._resp = self._resp.json()
        except Exception as e:
            self.error("parsing json 'resp' failed: " + str(e)) 

        logging.info("<UTXO_MetaSV> code={}".format(self._resp['code']))

        if 'success' not in self._resp or self._resp['code'] != 200:
            self.error("bad_query ({}):{}".format(self._resp['code'], self._resp['message']))

        if 'data' not in self._resp:
            self.error("field not found: resp['data']")

        # 返回的数组内每一项的结构，见文件顶部的返回值注释
        return self._resp['data']

    def endpoint_url(self):
        return self._endpoint_url


def UTXO_query_utxo_set(addr):
    q = UTXO_MetaSV(addr)
    utxos = q.query_latest()

    # 按区块顺序从小到大排列，但如果有 utxo 尚未进入区块 ('height': -1)，则排在末尾，也就是整体上是按照时间顺序
    utxos = sorted(utxos, key=lambda u: u['height'] > 0 and u['height'] or 9999999999 )  
    return utxos


def UTXO_query_utxo_as_addr_unspent(addr, txid):
    """ 通过 txid 查询到一个属于某个地址的 Unspent 对象的完整信息 """

    url = "https://api.metasv.com/v1/tx/{}".format(txid)
    resp = requests.get(url)

    try:
        resp = resp.json()
    except Exception as e:
        _error("parsing json 'resp' failed: " + str(e), url, resp) 

    logging.info("<UTXO_query_utxo_as_unspent> code={}".format(resp['code']))

    if 'success' not in resp or not resp['success'] or resp['code'] != 200:
        _error("bad_query ({}):{}".format(resp['code'], resp['message']), url, resp)

    if 'data' not in resp or 'voutList' not in resp['data'] or not resp['data']['voutList']:
        _error("resp['data']['voutList'] not found or is empty", url, resp)

    for vout in resp['data']['voutList']:
        if vout['address'] == addr and 'spent' not in vout: # 这是一笔属于该地址的 utxo
            return Unspent(amount=vout['value'],
                    confirmations=0 if vout['height'] in [0, -1] else 10000000-vout['height']+1, # !!! 注意：这里的确认数不准确，因为没有使用最新的区块高度，所以确认数的绝对值不准确，但相对值是准确的
                    txid=txid,
                    txindex=vout['index'])

    # 该地址没有此 utxo
    return None
