import os
import docopt
import logging

from fernet_cipher import FernetCipher

import bitsv
from bitsv.utils import hex_to_bytes
from bitsv.network.meta import Unspent

# from dot_mapi import dotm_tx

import svlet.net

def _get_unspents_from_metasv(addr):
    metasv_utxo_set = svlet.net.UTXO_query_utxo_set(addr)

    highest = 0
    for utxo in metasv_utxo_set:
        if utxo['height'] > highest:
            highest = utxo['height']

    utxos = []
    for utxo in metasv_utxo_set:
        u = Unspent(amount=utxo['value'],
                    confirmations=0 if utxo['height'] in [0, -1] else highest-utxo['height']+1, # !!! 注意：这里的确认数不准确，因为没有使用最新的区块高度，所以确认数的绝对值不准确，但相对值是准确的
                    txid=utxo['txid'],
                    txindex=utxo['outputIndex'])
        utxos.append(u)
    return sorted(utxos, key=lambda utxo: (-utxo.confirmations, utxo.amount))


WALLET_DEFAULT_NETWORK = "main" # main/test/stn

def get_filename(name):
    return os.path.join("data", name + ".wa") 
def get_addr_filename(name):
    return os.path.join("data", name + "_addr.txt") 

def get_txlen(tx_hex):
    return len(hex_to_bytes(tx_hex))

def get_fees_relay(tx_hex):                     # 0.25 sat/b.
    return 250 * get_txlen(tx_hex) // 1000

def get_fees_normal(tx_hex):                    # 0.5 sat/b.
    return 500 * get_txlen(tx_hex) // 1000

def get_fees_sufficient(tx_hex):                # 2.0 sat/b.
    return 2000 * get_txlen(tx_hex) // 1000
    
FeeModeLut = {
    "relay" : get_fees_relay,
    "normal" : get_fees_normal,
    "sufficient" : get_fees_sufficient,
}

def pick_suitable_unspents(unspents, oldestIfPossible=True, leastAmount=500):
    sum = 0
    for i, utxo in enumerate(unspents): 
        sum += utxo.amount
        if utxo.amount >= leastAmount:
            return [utxo]   # 有单条 utxo 满足余额的需求的话，优先返回单条的
        if sum >= leastAmount:
            return unspents[:i+1]  # 如果此前相加之和满足的话，返回合并的
        # 只有上两条都不满足的情况下才考虑更新的 utxo

def get_balance_with_utxos(unspents):
    if not unspents:
        return 0
    
    return sum(unspent.amount for unspent in unspents)

class SVWallet:
    def __init__(self, _network):
        self.m_key = bitsv.Key(network=_network or WALLET_DEFAULT_NETWORK)

    def printvalues(self):
        print("priv: ", self.m_key.to_wif())          
        # print("pubkey: ", self.m_key.public_key)    
        print("addr: ", self.m_key.address)


    def save(self, name, password):
        if not password:
            raise Exception("wallet '{}' password is empty.".format(name))
        if os.path.isfile(get_filename(name)):
            raise Exception("wallet '{}' already exists.".format(name))

        wif = self.m_key.to_wif()
        # print("wif: ", wif)
        fc = FernetCipher(password)
        encoded = fc.encode(wif)
        with open(get_filename(name), 'w') as f:
            f.write(encoded) 
        with open(get_addr_filename(name), 'w') as f:
            f.write(self.getaddress()) 
        

    def load(self, name, password):
        try:
            fc = FernetCipher(password)
            with open(get_filename(name), 'r') as f:
                encoded = f.read() 
                wif = fc.decode(encoded)
                # print("decoded wif: ", wif)
                self.m_key = bitsv.wif_to_key(wif, self.m_key.network or WALLET_DEFAULT_NETWORK)
        except Exception as e:
            raise Exception("wallet '{}' loading failed: {}".format(name, e))   # 这里可能产生文件不存在，密码不对，等等异常


    def load_wif(self, wif):
        try:
            self.m_key = bitsv.wif_to_key(wif, self.m_key.network or WALLET_DEFAULT_NETWORK)
        except Exception as e:
            raise Exception("wallet with wif '{}' loading failed: {}".format(wif, e))   # 这里可能产生 wif 格式不正确导致的异常

    def getkey(self):
        return self.m_key
    def getaddress(self):
        return self.m_key.address

    def get_unspents(self):
        # 这里获取 utxo 使用的是 MetaSV 方案 (注意：这个方案目前确认数仅保证相对值准确，绝对值不准确)
        return _get_unspents_from_metasv(self.getaddress())
        # return self.m_key.get_unspents()
    def getbalance(self):
        return sum(unspent.amount for unspent in self.get_unspents())

    def sendtx(self, addr, sat):
        logging.info(("sendtx: {} -> {} ({} sat)").format(self.getaddress(), addr, sat))
        return self.m_key.send([(addr, sat, 'satoshi')])

    def sendtx_for_2(self, addrA, satA, addrB, satB):
        logging.info(("sendtx: \n  {} ({} sat)\n   -> {} ({} sat)\n   -> {} ({} sat)").format(self.getaddress(), self.getbalance(), addrA, satA, addrB, satB))
        return self.m_key.send([(addrA, satA, 'satoshi'), (addrB, satB, 'satoshi')])

    # === Deprecated. should use svlet.net.mapi_sendtx ===
    # def sendtx_opreturn(self, content):
    #     if isinstance(content, str):
    #         return self.m_key.send_op_return([content.encode('utf-8')])
    #     else:
    #         return self.m_key.send_op_return([x.encode('utf-8') for x in content])

    # === Deprecated. should use svlet.net.mapi_sendtx ===
    # def sendtx_opreturn_using_merchant_api(self, content):
    #     tx_hex = self.create_opreturn_tx_with_content(content, "normal")
    #     return dotm_tx(tx_hex)

    def create_opreturn_tx_with_content(self, content, feeMode, from_txid=None):
        if feeMode not in FeeModeLut:
            logging.error(("fee mode error: unknown 'feeMode' feeMode={}").format(feeMode))
            return ""
        
        feeFunc = FeeModeLut[feeMode]

        # 先处理好 push data
        pushdatas = ""
        if isinstance(content, str):
            pushdatas = [content.encode('utf-8')]
        else:
            pushdatas = [x.encode('utf-8') for x in content]

        # 接着查询合适的 utxo
        preferred_utxos = []
        if from_txid:
            unspent = svlet.net.UTXO_query_utxo_as_addr_unspent(self.getaddress(), from_txid)
            if unspent:
                preferred_utxos = [unspent]
        else:
            # 仅向外部 API 查询一次 UTXO 集
            utxo_fullset = self.get_unspents()
            preferred_utxos = pick_suitable_unspents(utxo_fullset)
            logging.info(("utxo_fullset: {}").format(utxo_fullset))

        # 验证 utxo 有效性
        if not preferred_utxos:
            raise Exception("empty address (utxo not found)")
        balance = get_balance_with_utxos(preferred_utxos)
        if balance < 1000:
            raise Exception("balance < 1000. (transfer in some satoshis first)")

        logging.info(("preferred_utxos: {}").format(preferred_utxos))
        logging.info(("balance: {}").format(balance))
        
        # Pass 1 - 创建一个用于估计手续费的 tx_estimate
        tx_hex = self.m_key.create_op_return_tx(pushdatas, outputs=[(self.getaddress(), int(balance) - 500, 'satoshi')], unspents=preferred_utxos)
        tx_fee = feeFunc(tx_hex)
        logging.info(("estimated fee: {} (rate={:.2f} Sat/Byte)").format(tx_fee, tx_fee / get_txlen(tx_hex)))

        # Pass 2 - 用算出的手续费创建真实的 tx_real
        tx_hex = self.m_key.create_op_return_tx(pushdatas, outputs=[(self.getaddress(), int(balance) - tx_fee, 'satoshi')], unspents=preferred_utxos)
        return tx_hex
