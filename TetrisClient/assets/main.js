// Learn cc.Class:
//  - https://docs.cocos.com/creator/manual/en/scripting/class.html
// Learn Attribute:
//  - https://docs.cocos.com/creator/manual/en/scripting/reference/attributes.html
// Learn life-cycle callbacks:
//  - https://docs.cocos.com/creator/manual/en/scripting/life-cycle-callbacks.html
var blocks = [
    /*长条:横/竖*/
    [[[0, 0], [1, 0], [2, 0], [3, 0]], [[0, 0], [0, 1], [0, 2], [0, 3]]],
    /*三角:尖上/左/下/右*/
    [[[0, 0], [1, 0], [2, 0], [1, 1]], [[1, 0], [0, 1], [1, 1], [1, 2]], [[1, 0], [0, 1], [1, 1], [2, 1]], [[0, 0], [0, 1], [1, 1], [0, 2]]],
    /*方块*/
    [[[0, 0], [0, 1], [1, 0], [1, 1]]],
    /*正闪电 高/躺*/
    [[[1, 0], [0, 1], [1, 1], [0, 2]], [[0, 0], [1, 0], [1, 1], [2, 1]]],
    /*反闪电 高/躺*/
    [[[0, 0], [0, 1], [1, 1], [1, 2]], [[1, 0], [2, 0], [0, 1], [1, 1]]],
    /*7拐 */
    [[[1, 0], [1, 1], [0, 2], [1, 2]], [[0, 0], [0, 1], [1, 1], [2, 1]], [[0, 0], [1, 0], [0, 1], [0, 2]], [[0, 0], [1, 0], [2, 0], [2, 1]]],
    /*反7*/
    [[[0, 0], [0, 1], [0, 2], [1, 2]], [[0, 0], [1, 0], [2, 0], [0, 1]], [[0, 0], [1, 0], [1, 1], [1, 2]], [[2, 0], [0, 1], [1, 1], [2, 1]]],
]
cc.Class({
    extends: cc.Component,

    properties: {
        btn_askmoney1: {
            default: null,
            type: cc.Button,
        },
        btn_askmoney2: {
            default: null,
            type: cc.Button,
        },
        btn_askmoney3: {
            default: null,
            type: cc.Button,
        },
        btn_init: {
            default: null,
            type: cc.Button,
        },
        btn_left: {
            default: null,
            type: cc.Button,
        },
        btn_right: {
            default: null,
            type: cc.Button,
        },
        btn_turn: {
            default: null,
            type: cc.Button,
        },
        btn_summit: {
            default: null,
            type: cc.Button,
        },

        text_cmd: {
            default: null,
            type: cc.Label,
        },

        input: {
            default: null,
            type: cc.EditBox,
        },
        sendbtn: {
            default: null,
            type: cc.Button,
        },
        boardbg: {
            default: null,
            type: cc.Node,
        },
        preshow: {
            default: [],
            type: [cc.Node],
        },
        blockprefab: cc.Prefab,

        board: null,

        money: 0,

        index: 0,
        next: -1,
        pos: 4,
        dir: 0,
        askmoney: 0.1,

        blocksp: [],
        // blocksps: [[], [], [], [], [], [], [], [], [], []],
    },

    // LIFE-CYCLE CALLBACKS:

    callback: function (event, customEventData) {
        // 这里 event 是一个 Event 对象，你可以通过 event.target 取到事件的发送节点
        // var node = event.target;
        // var button = node.getComponent(cc.Button);
        // 这里的 customEventData 参数就等于你之前设置的 "foobar"
        // this.ww.send("{\"op\": \"subscribe\", \"args\": [\"spot/ticker:BTC-USDT\"]}");

    },

    onButtonAskmoney1: function () {
        console.log("onButtonAskmoney1");
        this.askmoney = 0.05;
        this.updateCmd();
    },

    onButtonAskmoney2: function () {
        console.log("onButtonAskmoney2");
        this.askmoney = 0.1;
        this.updateCmd();
    },

    onButtonAskmoney3: function () {
        console.log("onButtonAskmoney3");
        this.askmoney = 0.2;
        this.updateCmd();
    },

    onButtonInit: function () {
        console.log("onButtonInit");
        this.ReceiveInit(
            [
                [true, true],
                [true],
                [],
                [true, true],
                [true, true],
                [true],
                [true, true, true, true],
                [true, true, true, true],
                [true, true],
                [true, true]
            ],
            10.0,
            1,
            1
        );
        this.updateCmd();
    },

    onButtonLeft: function () {
        console.log("onButtonLeft");
        if (this.pos > 0)
            this.pos = this.pos - 1;
        this.updateMove();
        this.updateCmd();
    },

    onButtonRight: function () {
        console.log("onButtonRight");
        let blockwidth = this.getwidth(this.next, this.dir);
        if (this.pos < this.board.length - blockwidth)
            this.pos = this.pos + 1;
        this.updateMove();
        this.updateCmd();
    },

    onButtonDir: function () {
        console.log("onButtonDir");
        this.dir = (this.dir + 1) % blocks[this.next].length;

        let blockwidth = this.getwidth(this.next, this.dir);
        if (this.pos > this.board.length - blockwidth)
            this.pos = this.board.length - blockwidth;

        this.updateMove();
        this.updateCmd();
    },

    onButtonSubmit: function () {
        console.log("onButtonSubmit");
        let iindex = this.index + 1;
        let act = [{ address: "address1", block: this.next, pos: this.pos, dir: this.dir, money: this.askmoney }];
        let money = 0.2;
        let nextindex = getRndInteger(0, blocks.length - 1);
        this.ReceiveStep(iindex, act, money, nextindex);
        this.updateCmd();
    },

    onLoad: function () {
        console.log("zzz");

        source.addEventListener("open", function(event) {
          // handle open event
        }, false);

        this.board = [[], [], [], [], [], [], [], [], [], []];

        this.sendbtn.node.on('click', this.callback, this);

        this.btn_askmoney1.node.on('click', this.onButtonAskmoney1, this);
        this.btn_askmoney2.node.on('click', this.onButtonAskmoney2, this);
        this.btn_askmoney3.node.on('click', this.onButtonAskmoney3, this);

        this.btn_init.node.on('click', this.onButtonInit, this);
        this.btn_left.node.on('click', this.onButtonLeft, this);
        this.btn_right.node.on('click', this.onButtonRight, this);
        this.btn_turn.node.on('click', this.onButtonDir, this);
        this.btn_summit.node.on('click', this.onButtonSubmit, this);

        let ws = new WebSocket("ws://echo.websocket.org");
        // let ws = new WebSocket("wss://real.okex.com:8443/ws/v3");
        ws.onopen = function (event) {
            console.log("Send Text WS was opened.");
            ws.send("Hello WebSocket, I'm a text message.");
        };
        ws.onmessage = function (event) {
            // console.log("response text msg: " + event.data);
            console.log(event.data);
        };
        ws.onerror = function (event) {
            console.log("Send Text fired an error");
        };
        ws.onclose = function (event) {
            console.log("WebSocket instance closed.");
        };

        setTimeout(function () {
            if (ws.readyState === WebSocket.OPEN) {
                ws.send("Hello WebSocket, I'm a text message.");
            }
            else {
                console.log(ws.readyState);
                console.log(WebSocket.OPEN);
                console.log(WebSocket.CLOSED);
                console.log(WebSocket.CONNECTING);
                console.log(WebSocket.CLOSING);
                console.log("WebSocket instance wasn't ready...");
            }
        }, 10);
        this.ww = ws;

        this.blockPool = new cc.NodePool();
        let initCount = 5;
        for (let i = 0; i < initCount; ++i) {
            let enemy = cc.instantiate(this.blockprefab); // 创建节点
            this.blockPool.put(enemy); // 通过 put 接口放入对象池
        }

        this.onButtonInit();
    },

    createBlock: function (parentNode) {
        let block = null;
        if (this.blockPool.size() > 0) { // 通过 size 接口判断对象池中是否有空闲的对象
            block = this.blockPool.get();
        } else { // 如果没有空闲对象，也就是对象池中备用对象不够时，我们就用 cc.instantiate 重新创建
            block = cc.instantiate(this.blockprefab);
        }
        block.parent = parentNode; // 将生成的敌人加入节点树
        let blockwidth = this.boardbg.width / this.board.length;
        let blockheight = blockwidth;
        block.width = blockwidth * 0.98;
        block.height = blockheight * 0.98;
        return block;
        // enemy.getComponent('Enemy').ReceiveInit(); //接下来就可以调用 enemy 身上的脚本进行初始化
    },

    onBlockKilled: function (block) {
        // block 应该是一个 cc.Node
        this.blockPool.put(block); // 和初始化时的方法一样，将节点放进对象池，这个方法会同时调用节点的 removeFromParent
    },

    // onButtonStep: function () {
    //     console.log("onButtonStep");
    //     this.ReceiveStep(1, [
    //         { address: "address1", block: 1, pos: 1, dir: 1, money: 1.0 },
    //         { address: "address2", block: 1, pos: 1, dir: 2, money: 0.9 },
    //         { address: "address3", block: 1, pos: 2, dir: 3, money: 0.8 },
    //     ], 1, 1);
    // },

    /* 初始化 */
    ReceiveInit: function (blocks, money, index, next) {
        console.log("ReceiveInit " + index + " next:" + next);
        this.handle_init(blocks, money, index, next);
    },

    /* 标记、接收角色、动作、出价、下个方块 */
    ReceiveStep: function (index, stepdata, money, next) {
        console.log("ReceiveStep " + index + " next:" + next);
        this.pos = 4;
        this.dir = 0;
        this.handle_step(index, stepdata, money, next);
    },

    handle_init: function (blocks, money, index, next) {
        this.index = index;
        this.board = blocks;
        this.money = money;
        this.next = next;
        this.updateUI();
    },

    handle_step: function (index, stepdata, money, next) {
        this.index = index;
        this.next = next;
        this.handle_oneblock(stepdata[0]);
        // this.handle_oneblock(stepdata[1]);
        // this.handle_oneblock(stepdata[2]);
        this.updateUI();
    },

    handle_oneblock: function (onestep) {
        var high = 0;
        //计算掉落高度
        for (let i = 0; i < blocks[onestep.block][onestep.dir].length; i++) {
            var oneblock_deltapos = blocks[onestep.block][onestep.dir][i];
            let oneblock_index = oneblock_deltapos[0] + onestep.pos;
            let oneblock_high = this.board[oneblock_index].length - oneblock_deltapos[1];
            if (oneblock_high > high)
                high = oneblock_high;
        }
        //填进去
        //改变的行
        let ylist = [];
        for (let i = 0; i < blocks[onestep.block][onestep.dir].length; i++) {
            var oneblock_deltapos = blocks[onestep.block][onestep.dir][i];

            let x = oneblock_deltapos[0] + onestep.pos;
            let y = oneblock_deltapos[1] + high;
            ylist.push(y);
            let oldhighest = this.board[x].length - 1;
            this.board[x][y] = true;
            let newhighest = this.board[x].length - 1;
            for (let iy = (oldhighest + 1); iy < newhighest; iy++) {
                if (!this.board[x][iy]) {
                    this.board[x][iy] = false;
                }
            }
        }
        function unique(arr) {
            return Array.from(new Set(arr))
        }

        ylist = unique(ylist);//改变的行 去重

        let fulllist = [];
        for (let iy = 0; iy < ylist.length; iy++) {
            let y = ylist[iy];
            let breakflag = false;
            let full = true;
            for (let i = 0; i < this.board.length; i++) {
                if (this.board[i].length < y) { full = false; break; }
                full = full && this.board[i][y];
            }
            if (full)
                fulllist.push(y);
        }
        fulllist.sort();
        for (let i = fulllist.length - 1; i >= 0; i--) {

            let y = fulllist[i];
            for (let x = 0; x < this.board.length; x++) {
                console.log(x + "," + y);
                this.board[x].splice(y, 1);
            }
        }
    },

    getwidth: function (blockindex, dir) {
        let max_x = 0;
        let block = blocks[blockindex][dir];
        for (let i = 0; i < block.length; i++) {
            let x = block[i][0];
            if (x > max_x)
                max_x = x;
        }
        return max_x + 1;
    },

    updateUI: function () {
        for (let i = 0; i < this.blocksp.length; i++) {
            let bsp = this.blocksp[i];
            this.onBlockKilled(bsp);
        }
        this.blocksp = [];
        for (let x = 0; x < this.board.length; x++) {
            let blockx = this.board[x];
            for (let y = 0; y < blockx.length; y++) {
                const bone = blockx[y];
                if (bone) {
                    var block = this.createBlock(this.boardbg);
                    this.blocksp.push(block);
                    let p = this.GetPos(x, y);
                    block.x = p.x;
                    block.y = p.y;
                }
            }
        }
        this.updateMove();
    },

    updateMove: function () {
        for (let i = 0; i < blocks[this.next][this.dir].length; i++) {
            let oneblock = blocks[this.next][this.dir][i];
            let bx = oneblock[0];
            let by = oneblock[1];
            let p = this.GetPos(bx + this.pos, by + 12);
            this.preshow[i].x = p.x;
            this.preshow[i].y = p.y;
        }
    },

    GetPos: function (ix, iy) {
        let blockwidth = this.boardbg.width / this.board.length;
        let blockheight = blockwidth;
        let x = ix * blockwidth - this.boardbg.width / 2 + blockwidth / 2;
        let y = iy * blockheight - this.boardbg.height / 2 + blockheight / 2;
        return { x, y };
    },

    updateCmd: function () {
        this.text_cmd.string = "Index:" + this.index
            + " 方块" + this.next
            + " 位置" + this.pos
            + " 方向" + this.dir
            + " 出价" + this.askmoney;
    },

    // start() {},

    // update (dt) {},

}
);

function getRndInteger(min, max) {
    return Math.floor(Math.random() * (max - min + 1)) + min;
}
