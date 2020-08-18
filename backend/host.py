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

import time
import random
import datetime
import json
import pprint
import threading
import queue

import PySimpleGUI as sg

import shared
import shared_sse

g_logLines = ""
g_logLenWritten = 0

blocks = [
    #/*长条:横/竖*/
    [[[0, 0], [1, 0], [2, 0], [3, 0]], [[0, 0], [0, 1], [0, 2], [0, 3]]],
    #/*三角:尖上/左/下/右*/
    [[[0, 0], [1, 0], [2, 0], [1, 1]], [[1, 0], [0, 1], [1, 1], [1, 2]], [[1, 0], [0, 1], [1, 1], [2, 1]], [[0, 0], [0, 1], [1, 1], [0, 2]]],
    #/*方块*/
    [[[0, 0], [0, 1], [1, 0], [1, 1]]],
    #/*正闪电 高/躺*/
    [[[1, 0], [0, 1], [1, 1], [0, 2]], [[0, 0], [1, 0], [1, 1], [2, 1]]],
    #/*反闪电 高/躺*/
    [[[0, 0], [0, 1], [1, 1], [1, 2]], [[1, 0], [2, 0], [0, 1], [1, 1]]],
    #/*7拐 */
    [[[1, 0], [1, 1], [0, 2], [1, 2]], [[0, 0], [0, 1], [1, 1], [2, 1]], [[0, 0], [1, 0], [0, 1], [0, 2]], [[0, 0], [1, 0], [2, 0], [2, 1]]],
    #/*反7*/
    [[[0, 0], [0, 1], [0, 2], [1, 2]], [[0, 0], [1, 0], [2, 0], [0, 1]], [[0, 0], [1, 0], [1, 1], [1, 2]], [[2, 0], [0, 1], [1, 1], [2, 1]]],
]

#act = {index,addr,posx,dir,money}
def g_log(s):
    print(s)
    global g_logLines
    g_logLines += "{} {}\n".format(datetime.datetime.now().strftime("%H:%M:%S"), s)

class CountdownTimer():
    def __init__(self):
        self._evtQueue = queue.Queue(32)
        self._timer = threading.Timer(shared.ROUND_TIME, self.over)
        self._timer.start()
        self._timerStartTime = time.time()

    def over(self):
        g_log("本轮倒计时结束!")
        self._evtQueue.put_nowait("time_over")

    def isOver(self):
        g_log("距离结束还有: {:.3f}s".format(self._timerStartTime + shared.ROUND_TIME - time.time()))

        if self._evtQueue.empty():
            return False

        self._evtQueue.get_nowait() 
        return True

class TheGame():
    def __init__(self):
        self._curRound = 0
        self._curRoundTimer = None
        self._wallet = SVWallet('main')
        self._wallet.load_wif('L53m4CgBCbAC3byHXEPBEekZAzijFhqwSdNeZN8mXniB15mkBzvT')
        self._numQueue = [] # 数字接龙的队列
        self._numBuf = []   # 当前这一轮的缓冲
        self._blockindex = 0    #当前方块
        self._money = 0.0   #当前积累筹码
        self._board = [[], [], [], [], [], [], [], [], [], []]

    def Next(self):
        randnums = random.sample(range(1, 5), 3)
        self._curRound += 1
        self._curRoundNums = randnums
        self._curRoundTimer = None

        g_log("新的一轮开始: {}".format(self._curRound))

        content = json.dumps({ "round": self._curRound, "numbers": randnums })
        shared.broadcast_datatx(self._wallet, shared.TX_Next, content, g_log)

    def onClientEvent(self, event):
        try:
            txEvt = shared.TxEvent(event)
            if txEvt.getEventType() == shared.TX_Next:
                return

            if txEvt.getEventType() != shared.TX_Bet:
                raise ValueError("not 'tx_bet': " + pprint.pformat(event))

            g_log("<bet>: " + pprint.pformat(event))
            contentJson = json.loads(txEvt.getEventContent())
            if 'round' not in contentJson or 'bet_index' not in contentJson:
                raise ValueError("'round' or 'bet_index' not found")

            clientRound = int(contentJson['round'])
            clientBetIndex = int(contentJson['bet_index'])
            clientBetAddr = contentJson['bet_addr']
            if self._curRound != clientRound:
                raise ValueError("round mismatched: hostRound={} clientRound={}".format(self._curRound, clientRound))

            bet = (clientBetAddr, self._curRoundNums[clientBetIndex])
            self._numBuf.append(bet)
            g_log("客户端 ({}) 参与: ({})".format(bet[0], bet))

            # 只有当任意一个参与者下注，才开始这一回合的倒计时
            if not self._curRoundTimer:
                self._curRoundTimer = CountdownTimer()

        except Exception as e:
            g_log("<bad_event>: " + str(e) + pprint.pformat(event))


    def checkRoundOver(self):
        if not self._curRoundTimer:
            return

        if not self._curRoundTimer.isOver():
            return

        g_log("系统确认倒计时结束，开始跑本轮的游戏逻辑。")

        # 没有操作无法触发 timer 不可能走到这里
        assert len(self._numBuf) > 0

        # 从所有玩家的 bet 中选择一个作为实际操作的指令
        chosen = random.randint(0, len(self._numBuf) - 1)#TODO 按出价概率选择三个
        chosenOp = self._numBuf[chosen]
        self._numBuf = []

        # 执行本回合的操作
        content = json.dumps({ "round": self._curRound, "op": chosenOp })
        shared.broadcast_datatx(self._wallet, shared.TX_Exec, content, g_log)

        # ---- 这里是真实游戏逻辑 ----
        self.performGameLogic(chosenOp)

    def performGameLogic(self, chosens):
        g_log("开始跑游戏逻辑: queue={}, chosen={}".format(self._numQueue, chosen))

        high = 0
        for act in chosens:
            for block in blocks[self._blockindex][act.dir]:
                x = block[0] + act.pos
                y = len(self._board[x]) - block[1]
                if (y > high):
                    high = y
            
            #标记改动了哪几行
            ylist = []
            for block in blocks[self._blockindex][act.dir]:
                x = block[0] + act.pos
                y = block[1] + high
                if y not in ylist:
                    ylist.append(y)

                #在棋盘上填充刚下落的方块
                starty = len(self._board[x])
                while starty != y:
                    self._board[x].append(False)
                    starty = starty + 1
                self._board[x][y].append(True)

            #检查满行
            fulllist = []
            for y in ylist:
                fullflag = True
                for x in range(0,len(self._board)):
                    if(len(self._board[x]) <= y || !self._board[x][y]):
                        fullflag = False
                        break
                if fullflag:
                    fulllist.append(y)

            #满行数(用于发奖励)
            fullnum = len(fulllist)
            #删除满行
            fulllist.sort(reverse=True)
            for y in fulllist:
                for x in range(0,len(self._board)):
                    del self._board[x][y]

        self.Next()

if __name__ == "__main__":

    shared.setup_logs("host")

    # 监听线程
    d = shared_sse.SSEThread()
    d.setTxType(shared.TX_Bet)
    d.start()

    # 游戏主对象
    g = TheGame()

    # 界面布局
    layout = [
        [ sg.Text("庄家状态: "), sg.Text("<status - not refreshed yet>", key="-status-") ],
        [ sg.HSeparator() ],
        [ sg.Button("Next!")],
        [ sg.HSeparator() ],
        [ sg.Multiline("<logging - not refreshed yet>", key="-logs-", size=(1024, 300), autoscroll=True) ],
    ]
    window = sg.Window("SatoPlay Tetris Host", layout, size=(1024, 768))

    # 事件循环
    while True:
        event, values = window.read(timeout=1000)
        if event == sg.WIN_CLOSED:
            break

        # 保证 log 窗口随时刷新
        if g._numQueue:
            window["-status-"].update(','.join(["{}".format(x) for x in g._numQueue]))
        if g_logLenWritten != len(g_logLines):
            window["-logs-"].update(g_logLines)

        if event == sg.EVENT_TIMEOUT:
            # g_log(datetime.datetime.now().strftime("%H:%M:%S") + " ticked: " + str(values))

            if d.hasEvent():
                evt = d.getEvent()
                g.onClientEvent(evt)
            
            # 检查本轮是否结束
            g.checkRoundOver()
            continue

        if event == "Next!":
            g.Next()

    window.close()

