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

import json
import time
import datetime
import logging
from threading import Timer
import pprint

from flask import Flask
from flask import request
from flask import Response

import shared
import shared_sse

def g_log(s):
    print(s)
    logging.info(s)


# ----------- The Game -----------

class GameProxy():
    def __init__(self):
        self._wallet = SVWallet('main')
        self._wallet.load_wif('KyU4PEVdCdaQYFfpg5vFbg1QZWNKefYbWPngjbUMnTT6uiZLK9mg')
        self._sse = shared_sse.SSEThread()

    def start(self):
        self._sse.start()
        self.tick()

    def tick(self):
        # g_log(datetime.datetime.now().strftime("%H:%M:%S") + " ticked.")

        if self._sse.hasEvent():
            evt = self._sse.getEvent()
            self.onEvent(evt)

        Timer(1, self.tick).start()

    def onEvent(self, event):
        try:
            txEvt = shared.TxEvent(event)
            if txEvt.getEventType() == shared.TX_Bet:
                return

            g_log("<host_event>: " + pprint.pformat(event))

        except Exception as e:
            g_log("<bad_event> : " + str(e))


    def Bet(self, betJson):
        bet = json.loads(betJson)
        bet['bet_addr'] = self._wallet.getaddress()
        content = json.dumps(bet)

        g_log("<bet> sending : " + str(content))
        shared.broadcast_datatx(self._wallet, shared.TX_Bet, content, g_log)

    #收集操作
    #决定操作
    #执行操作,分配筹码
    #发送操作,筹码,下一个块
    
# ----------- Main Entry -----------

shared.setup_logs("proxy")

g_theProxy = GameProxy()
g_theProxy.start()

# ----------- Flask Handlers -----------

app = Flask(__name__)

@app.route("/bet", methods=['POST'])
def bet():
    g_theProxy.Bet(request.data)
    return "bet!"



# foo = json.dumps({"foo":1, "bar":2}) 
# message_to_send =  "data: {}\n\n".format(foo)

# @app.route("/game_status_event")
# def game_status_event():
#     def event_stream():
#         while True:
#             time.sleep(1)
            
#             if message_to_send:
#                 g_log("<game_status_event> sent (pre-yield): " + message_to_send)
#                 yield message_to_send
#                 g_log("<game_status_event> sent (post-yield): " + message_to_send)
    
#     return Response(event_stream(), mimetype="text/event-stream")





