using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using MMFramework;
namespace MMGame
{
    public struct Act
    {
        public string addr;
        public int pos;
        public int dir;
        public float askmoney;
    }
    public class MainFrame : MMFrame
    {
        public Button btnleft, btnright, btnturn, btnsummit;
        public Button[] btnasks;
        public Image previewlight;

        public BlockSuit blockSuit, previewSuit;

        public RectTransform boardtrans;
        public Block askblock;
        public Text info;
        public Text mymoney;

        List<List<float>> board = new List<List<float>>();
        List<List<Block>> blocksp = new List<List<Block>>();

        int index = 0;
        int next;
        int pos = 4;
        int dir;
        float mybsv = 10.0f;
        float askmoney = 0.04f;

        const int BW = 10;
        float[] asktags = { 0.04f, 0.2f, 0.4f, 2f, 4f };

        void Awake()
        {
            Init(null);
        }

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Z))
            {
                askmoney = asktags[0];
                UpdateAsk();
            }
            else if (Input.GetKeyDown(KeyCode.X))
            {
                askmoney = asktags[1];
                UpdateAsk();
            }
            else if (Input.GetKeyDown(KeyCode.C))
            {
                askmoney = asktags[2];
                UpdateAsk();
            }
            else if (Input.GetKeyDown(KeyCode.V))
            {
                askmoney = asktags[3];
                UpdateAsk();
            }
            else if (Input.GetKeyDown(KeyCode.B))
            {
                askmoney = asktags[4];
                UpdateAsk();
            }
            else if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                if (pos > 0)
                    pos--;
                Debug.Log("btnleft" + pos);
                UpdateMove();
            }
            else if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                int blocksuitwidth = BlockSuit.getwidth(next, dir);
                if (pos < board.Count - blocksuitwidth)
                    pos++;
                Debug.Log("btnright" + pos);
                UpdateMove();
            }
            else if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                dir = (dir + 1) % ConfigInGame.Blocks[next].Count;
                int blocksuitwidth = BlockSuit.getwidth(next, dir);
                if (pos > board.Count - blocksuitwidth)
                    pos = board.Count - blocksuitwidth;
                Debug.Log("btnturn" + dir);
                UpdateMove();
            }
            else if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                Act act = new Act();
                act.addr = "zzz";
                act.pos = pos;
                act.dir = dir;
                act.askmoney = askmoney;
                mybsv = mybsv - act.askmoney;
                // int next = (newindex / 3) % 7;
                Step(index + 1, new Act[] { act }, next);
            }
            else if (Input.GetKeyDown(KeyCode.Q))
            {
                next = 0;
                dir = dir % ConfigInGame.Blocks[next].Count;
                UpdatePreview();
                UpdateMove();
            }
            else if (Input.GetKeyDown(KeyCode.W))
            {
                next = 1;
                dir = dir % ConfigInGame.Blocks[next].Count;
                UpdatePreview();
                UpdateMove();
            }
            else if (Input.GetKeyDown(KeyCode.E))
            {
                next = 2;
                dir = dir % ConfigInGame.Blocks[next].Count;
                UpdatePreview();
                UpdateMove();
            }
            else if (Input.GetKeyDown(KeyCode.R))
            {
                next = 3;
                dir = dir % ConfigInGame.Blocks[next].Count;
                UpdatePreview();
                UpdateMove();
            }
            else if (Input.GetKeyDown(KeyCode.T))
            {
                next = 4;
                dir = dir % ConfigInGame.Blocks[next].Count;
                UpdatePreview();
                UpdateMove();
            }
            else if (Input.GetKeyDown(KeyCode.Y))
            {
                next = 5;
                dir = dir % ConfigInGame.Blocks[next].Count;
                UpdatePreview();
                UpdateMove();
            }
            else if (Input.GetKeyDown(KeyCode.U))
            {
                next = 6;
                dir = dir % ConfigInGame.Blocks[next].Count;
                UpdatePreview();
                UpdateMove();
            }
        }

        public override void Init(object[] objects)
        {
            for (int x = 0; x < BW; x++)
            {
                board.Add(new List<float>());
                blocksp.Add(new List<Block>());
            }

            for (int i = 0; i < btnasks.Length; i++)
            {
                int index = i;
                btnasks[i].onClick.AddListener(delegate
                {
                    // Debug.LogError(index + " " + asktags.Length);
                    askmoney = asktags[index];
                    UpdateAsk();
                });
            }

            previewSuit.SetPreview();

            btnleft.onClick.AddListener(delegate
            {
                if (pos > 0)
                    pos--;
                Debug.Log("btnleft" + pos);
                UpdateMove();
            });
            btnright.onClick.AddListener(delegate
            {
                int blocksuitwidth = BlockSuit.getwidth(next, dir);
                if (pos < board.Count - blocksuitwidth)
                    pos++;
                Debug.Log("btnright" + pos);
                UpdateMove();
            });
            btnturn.onClick.AddListener(delegate
            {
                dir = (dir + 1) % ConfigInGame.Blocks[next].Count;
                int blocksuitwidth = BlockSuit.getwidth(next, dir);
                if (pos > board.Count - blocksuitwidth)
                    pos = board.Count - blocksuitwidth;
                Debug.Log("btnturn" + dir);
                UpdateMove();
            });
            btnsummit.onClick.AddListener(delegate
            {
                Act act = new Act();
                act.addr = "zzz";
                act.pos = pos;
                act.dir = dir;
                act.askmoney = askmoney;
                mybsv = mybsv - act.askmoney;
                int newindex = index + 1;
                int next = (newindex / 3) % 7;
                Step(newindex, new Act[] { act }, next);


            });

            UpdateAsk();
            UpdateMove();
            UpdateBoard();
        }

        void InitBoard(List<List<float>> board, int index, int next)
        {
            this.board = board;
            this.index = index;
            UpdateBoard();
            this.next = next;
        }

        void Step(int index, Act[] acts, int pnext)
        {
            StepOne(acts[0], pnext);
            this.index = index;
        }

        void StepOne(Act act, int pnext)
        {
            //计算掉落高度
            int high = 0;
            for (int i = 0; i < ConfigInGame.Blocks[next][act.dir].GetLength(0); i++)
            {
                int[,] blocksuit = ConfigInGame.Blocks[next][act.dir];
                int x = blocksuit[i, 0] + act.pos;
                int y = board[x].Count - blocksuit[i, 1];
                if (y > high)
                    high = y;
            }
            //填进去
            //改变的行
            List<int> ylist = new List<int>();
            for (int i = 0; i < ConfigInGame.Blocks[next][act.dir].GetLength(0); i++)
            {
                int[,] blocksuit = ConfigInGame.Blocks[next][act.dir];
                int x = blocksuit[i, 0] + act.pos;
                int y = blocksuit[i, 1] + high;
                if (!ylist.Contains(y))
                    ylist.Add(y);
                int fromy = board[x].Count;
                while (fromy != y)
                {
                    board[x].Add(-1);
                    fromy++;
                }
                board[x].Add(act.askmoney / 4);
            }

            //检查消除
            List<int> fulllist = new List<int>();
            for (int iy = 0; iy < ylist.Count; iy++)
            {
                int y = ylist[iy];
                bool fullflag = true;
                for (int x = 0; x < board.Count; x++)
                {
                    if ((board[x].Count <= y) || (board[x][y] < 0))
                    {
                        fullflag = false;
                        break;
                    }
                }
                if (fullflag)
                    fulllist.Add(y);
            }
            //删除满行
            fulllist.Sort();
            fulllist.Reverse();
            for (int i = 0; i < fulllist.Count; i++)
            {
                int y = fulllist[i];
                for (int x = 0; x < board.Count; x++)
                {
                    Debug.LogError("del " + x + "," + y);
                    board[x][y] = -100f;
                }
            }
            float delay = 0f;
            if (fulllist.Count > 0)
                delay = 0.5f;

            blockSuit.gameObject.SetActive(false);
            previewlight.gameObject.SetActive(false);
            previewSuit.gameObject.SetActive(false);

            UpdateBoard();
            StartCoroutine(afterstep(delay, pnext));
        }

        IEnumerator afterstep(float dur, int pnext)
        {
            yield return new WaitForSeconds(dur);
            //检查漏删除的
            for (int x = 0; x < board.Count; x++)
            {
                for (int y = board[x].Count - 1; y >= 0; y--)
                {
                    if (board[x][y] < 0)
                    {
                        board[x].RemoveAt(y);
                        Debug.LogError("ded " + x + "," + y);
                    }
                    else
                        break;
                }
            }
            for (int x = 0; x < board.Count; x++)
            {
                for (int y = board[x].Count - 1; y >= 0; y--)
                {
                    if (board[x][y] < -10)
                    {
                        board[x].RemoveAt(y);
                        Debug.LogError("dex " + x + "," + y);
                    }
                }
            }

            UpdateBoard();
            this.next = pnext;
            dir = dir % ConfigInGame.Blocks[next].Count;

            blockSuit.gameObject.SetActive(true);
            previewlight.gameObject.SetActive(true);
            previewSuit.gameObject.SetActive(true);
            UpdateMove();
        }

        void UpdateMove()
        {
            Debug.Log("UpdateMove");
            blockSuit.Change(next, dir);
            blockSuit.transform.DOLocalMoveX(GetPosX(pos), 0.1f);
            UpdatePreview();
        }

        void UpdatePreview()
        {
            //计算掉落高度
            int high = 0;
            for (int i = 0; i < ConfigInGame.Blocks[next][dir].GetLength(0); i++)
            {
                int[,] blocksuit = ConfigInGame.Blocks[next][dir];
                int x = blocksuit[i, 0] + pos;
                int y = board[x].Count - blocksuit[i, 1];
                if (y > high)
                    high = y;
            }

            previewSuit.Change(next, dir);
            previewSuit.transform.DOLocalMove(new Vector3(GetPosX(pos), GetPosY(high)), 0.1f);

            int blocksuitwidth = BlockSuit.getwidth(next, dir);
            float width = blocksuitwidth * Block.W;
            previewlight.rectTransform.sizeDelta = new Vector2(width, previewlight.rectTransform.sizeDelta.y);
            previewlight.transform.DOLocalMoveX(GetPosX(pos) - Block.W / 2 + width / 2, 0.1f);
        }

        float GetPosX(int pos)
        {
            // Debug.Log(string.Format("{0} {1} {2} ", pos, board.Count, Block.W));
            return Block.W * (pos - (board.Count - 1) / 2f);
        }

        float GetPosY(int pos)
        {
            return Block.H * (pos + 0.5f) - boardtrans.sizeDelta.y / 2f;
        }

        void UpdateBoard()
        {
            for (int x = 0; x < blocksp.Count; x++)
            {
                for (int y = 0; y < blocksp[x].Count; y++)
                {
                    DestroyImmediate(blocksp[x][y].gameObject);
                }
                blocksp[x].Clear();
            }

            float total = 0;
            for (int x = 0; x < board.Count; x++)
            {
                for (int y = 0; y < board[x].Count; y++)
                {
                    float block_money = board[x][y];
                    if (block_money > 0)
                    {
                        total += block_money;
                        GameObject go = ObjTools.CreatePrefab(boardtrans, "TetrisPrefabs/Block");
                        Block block = go.GetComponent<Block>();
                        blocksp[x].Add(block);
                        go.transform.localPosition = new Vector3(GetPosX(x), GetPosY(y));
                        block.SetMoney(board[x][y]);
                    }
                }
            }

            info.text = "Round:" + (index / 3) + "  " + total + " BSV";
            mymoney.text = string.Format("{0:N2}", mybsv);
        }

        void UpdateAsk()
        {
            askblock.SetMoney(askmoney / 4f);
            blockSuit.SetPerBlockMoney(askmoney / 4f);
        }
    }
}