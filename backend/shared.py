#----- wallet importing begin -----
import os
import sys
from pathlib import Path
root_path = Path(os.path.abspath(__file__)).parent
sys.path.insert(0, str(root_path))      # add parent folder ('root') to 'sys.path'
# print(sys.path)
sys.path.insert(0, os.path.join(root_path, 'bitsv'))
sys.path.insert(0, os.path.join(root_path, 'src'))
from svwallet import SVWallet
#----- wallet importing end -----

import logging
from datetime import datetime

import svlet.net

ROUND_TIME = 10     # 10 秒一回合

TX_Next = "tx_next"
TX_Bet = "tx_bet"
TX_Exec = "tx_exec" # 执行本回合操作

# 选择恰当的费率发送交易
#   'relay' means 0.25 sat/b
#   'normal' means 0.5 sat/b
#   'sufficient' means 2.0 sat/b
FEE_Default = "normal"   

# 选择恰当的发送方 ['mempool', 'metasv']
TARGET_Default = "metasv"   

def broadcast_datatx(wallet, txType, content, _print):
    try:
        _print("sending {} : {}".format(txType, content)) 
        tx_hex = wallet.create_opreturn_tx_with_content(['satoplay.com', 'satetris', txType, content], FEE_Default)
        if not tx_hex:
            raise Exception("create_opreturn_tx_with_content() failed. (see above for details)")

        txid = svlet.net.mapi_sendtx(tx_hex, TARGET_Default)
        _print("tx sent: " + txid)
    except Exception as e:
        _print("sending tx failed: " + str(e))
                

class TxEvent():
    def __init__(self, evt):
        if 'data' not in evt:
            raise ValueError("'data' field missing") 
        if 'parts' not in evt['data']:
            raise ValueError("'data.parts' field missing") 
        if len(evt['data']['parts']) < 6:
            raise ValueError("<bad_evt>: 'data.parts' too few parts (<6)") 

        self._evtType = evt['data']['parts'][4]
        self._evtContent = evt['data']['parts'][5]

    def getEventType(self):
        return self._evtType

    def getEventContent(self):
        return self._evtContent


def setup_logs(log_name):
    start_time = datetime.now()
    dateStr = start_time.strftime("%Y-%m-%d")
    Path("logs/{}".format(dateStr)).mkdir(parents=True, exist_ok=True)
    timeStr = start_time.strftime("%Y-%m-%d %H-%M-%S")
    logFilePath = os.path.join("logs", "{}/{} {}.log".format(dateStr, timeStr, log_name ))
    logging.basicConfig(filename=logFilePath, filemode='a', format='%(asctime)s (%(levelname)s) %(message)s', level=logging.INFO)
    logging.info('--- new session ---')

