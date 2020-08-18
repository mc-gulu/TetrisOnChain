import datetime
import json
import pprint
import requests
import PySimpleGUI as sg

import shared
import shared_sse

g_logLines = ""
g_logLenWritten = 0

def g_log(s):
    print(s)
    global g_logLines
    g_logLines += "{} {}\n".format(datetime.datetime.now().strftime("%H:%M:%S"), s)


class GameClient():
    def __init__(self):
        self._round = -1
        self._numbers = []

    def onHostEvent(self, event):
        try:
            txEvt = shared.TxEvent(event)
            if txEvt.getEventType() == shared.TX_Bet:
                return

            g_log("<host_event>: " + pprint.pformat(event))
            if txEvt.getEventType() == shared.TX_Next:
                contentJson = json.loads(txEvt.getEventContent())
                if 'round' not in contentJson or 'numbers' not in contentJson:
                    raise ValueError("'round' or 'numbers' not found")

                self._round = int(contentJson['round'])
                self._numbers = contentJson['numbers']
                g_log("已获取新一轮的状态信息: round={}, numbers={}".format(self._round, self._numbers))

        except Exception as e:
            g_log("<bad_event> : " + str(e))


    def Bet(self, index):
        if self._round < 0:
            g_log("未获取新一轮的状态信息，请等待信息刷出后重试。")
            return

        resp = requests.post("http://localhost:5000/bet", json={ "round": self._round, "bet_index": index })
        g_log(resp.status_code)
        g_log(resp.text)


if __name__ == "__main__":

    shared.setup_logs("client")

    # 监听线程
    d = shared_sse.SSEThread()
    d.start()

    # 客户端游戏对象
    client = GameClient()

    # 界面布局
    layout = [
        [ sg.Text("闲家状态: "), sg.Text("<status - not refreshed yet>", key="-status-") ],
        [ sg.HSeparator() ],
        [ sg.Button("Bet 0"), sg.Button("Bet 1"), sg.Button("Bet 2")],
        [ sg.HSeparator() ],
        [ sg.Multiline("<logging - not refreshed yet>", key="-logs-", size=(1024, 300), autoscroll=True) ],
    ]
    window = sg.Window("SatoPlay Tetris Client", layout, size=(1024, 768))

    # 事件循环
    while True:
        event, values = window.read(timeout=1000)
        if event == sg.WIN_CLOSED:
            break

        if event == sg.EVENT_TIMEOUT:
            # g_log(datetime.datetime.now().strftime("%H:%M:%S") + " ticked: " + str(values))

            # 有事件，则优先处理事件
            if d.hasEvent():
                evt = d.getEvent()
                client.onHostEvent(evt)

            # 随时刷新状态和日志
            if client._round and client._numbers:
                window["-status-"].update("round: {} numbers: {}".format(client._round, client._numbers))
            if g_logLenWritten != len(g_logLines):
                window["-logs-"].update(g_logLines)
            continue

        if event == "Bet 0":
            client.Bet(0)
        if event == "Bet 1":
            client.Bet(1)
        if event == "Bet 2":
            client.Bet(2)

    window.close()
