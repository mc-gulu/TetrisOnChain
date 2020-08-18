using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace MMGame
{
    public struct Vec2Int
    {
        public int x;
        public int y;
        Vec2Int(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
    }
    public static class ConfigInGame
    {
        static List<List<int[,]>> blocks = null;
        public static List<List<int[,]>> Blocks
        {
            get
            {
                if (blocks == null)
                {
                    blocks = new List<List<int[,]>>();
                    {
                        /* 横 竖*/
                        List<int[,]> blocksuitlist = new List<int[,]>();
                        blocksuitlist.Add(new int[,] { { 0, 0 }, { 1, 0 }, { 2, 0 }, { 3, 0 } });
                        blocksuitlist.Add(new int[,] { { 0, 0 }, { 0, 1 }, { 0, 2 }, { 0, 3 } });
                        blocks.Add(blocksuitlist);
                    }
                    {
                        /*三角:尖上/左/下/右*/
                        List<int[,]> blocksuitlist = new List<int[,]>();
                        blocksuitlist.Add(new int[,] { { 0, 0 }, { 1, 0 }, { 2, 0 }, { 1, 1 } });
                        blocksuitlist.Add(new int[,] { { 1, 0 }, { 0, 1 }, { 1, 1 }, { 1, 2 } });
                        blocksuitlist.Add(new int[,] { { 1, 0 }, { 0, 1 }, { 1, 1 }, { 2, 1 } });
                        blocksuitlist.Add(new int[,] { { 0, 0 }, { 0, 1 }, { 1, 1 }, { 0, 2 } });
                        blocks.Add(blocksuitlist);
                    }
                    {
                        /*方块*/
                        List<int[,]> blocksuitlist = new List<int[,]>();
                        blocksuitlist.Add(new int[,] { { 0, 0 }, { 0, 1 }, { 1, 0 }, { 1, 1 } });
                        blocks.Add(blocksuitlist);
                    }
                    {
                        /*正闪电 高/躺*/
                        List<int[,]> blocksuitlist = new List<int[,]>();
                        blocksuitlist.Add(new int[,] { { 1, 0 }, { 0, 1 }, { 1, 1 }, { 0, 2 } });
                        blocksuitlist.Add(new int[,] { { 0, 0 }, { 1, 0 }, { 1, 1 }, { 2, 1 } });
                        blocks.Add(blocksuitlist);
                    }
                    {
                        /*反闪电 高/躺*/
                        List<int[,]> blocksuitlist = new List<int[,]>();
                        blocksuitlist.Add(new int[,] { { 0, 0 }, { 0, 1 }, { 1, 1 }, { 1, 2 } });
                        blocksuitlist.Add(new int[,] { { 1, 0 }, { 2, 0 }, { 0, 1 }, { 1, 1 } });
                        blocks.Add(blocksuitlist);
                    }
                    {
                        /*7拐 */
                        List<int[,]> blocksuitlist = new List<int[,]>();
                        blocksuitlist.Add(new int[,] { { 1, 0 }, { 1, 1 }, { 0, 2 }, { 1, 2 } });
                        blocksuitlist.Add(new int[,] { { 0, 0 }, { 0, 1 }, { 1, 1 }, { 2, 1 } });
                        blocksuitlist.Add(new int[,] { { 0, 0 }, { 1, 0 }, { 0, 1 }, { 0, 2 } });
                        blocksuitlist.Add(new int[,] { { 0, 0 }, { 1, 0 }, { 2, 0 }, { 2, 1 } });
                        blocks.Add(blocksuitlist);
                    }
                    {
                        /*反7*/
                        List<int[,]> blocksuitlist = new List<int[,]>();
                        blocksuitlist.Add(new int[,] { { 0, 0 }, { 0, 1 }, { 0, 2 }, { 1, 2 } });
                        blocksuitlist.Add(new int[,] { { 0, 0 }, { 1, 0 }, { 2, 0 }, { 0, 1 } });
                        blocksuitlist.Add(new int[,] { { 0, 0 }, { 1, 0 }, { 1, 1 }, { 1, 2 } });
                        blocksuitlist.Add(new int[,] { { 2, 0 }, { 0, 1 }, { 1, 1 }, { 2, 1 } });
                        blocks.Add(blocksuitlist);
                    }
                }
                return blocks;
            }
        }

        public static bool AutoSpSkill
        {
            get { return PlayerPrefs.GetInt("AutoSpSkill", 0) == 1; }
            set { PlayerPrefs.SetInt("AutoSpSkill", value ? 1 : 0); }
        }
        public static bool DoubleSpeed
        {
            get { return PlayerPrefs.GetInt("DoubleSpeed", 0) == 1; }
            set { PlayerPrefs.SetInt("DoubleSpeed", value ? 1 : 0); }
        }

        /// <summary>
        /// 受击100%血量时获取的能量
        /// </summary>
        public static float HitEnergy = 80;

        public const string BulletPrefabPathName = "Prefabs/bullet";

        public const string IconHeroPath = "Prefabs/ui/icon/hero_icon";
        public const string IconItemPath = "Prefabs/ui/icon/item_icon";

        public const int selfid = 6007;
        public const int selflv = 1;
        public const int selfst = 1;
        //½ÇÉ«id
        public static int[] partnersids = new int[] { };
        //½ÇÉ«µÈ¼¶
        public static int[] partnerslvs = new int[] { 1, 1, 1 };
        //½ÇÉ«ÐÇ¼¶
        public static int[] partnerssts = new int[] { 1, 1, 1 };

        //ÉËº¦¹«Ê½³£ÊýA
        public static float fightnumA = 1;

        //Áì¶ÓÊÓ¾õ·¶Î§
        public static float viewDistance = 100f;
        //µÐÈËÊÓ¾õ·¶Î§
        public static float enemyViewDistance = 100f;
        //´«ËÍ¾àÀë
        public static float transportDistance = 10f;
        //¸úËæ¾àÀë
        public static float followDistance = 0.1f;
        public static int moveSpeed = 400;
        public static float playerMoveSpeed = 0.08f;
        //重置英雄等级花费（全等级相同）
        public static int ResetHeroCostID = 27003;

        public const int MaxCreatureNumber = 1000;

        //电池持续时间
        public const long BatterySecond = 5 * SmallTickPerSecond;
        //无电池增加资源时间
        public const long DrillingTick = 1000 * 10000;//0.5秒
                                                      //有电池增加资源时间
        public const long DrillingTick_Battery = 100 * 10000;//0.05秒
                                                             //多少个资源时间开始算作离线收益
        public const long MinOfflineCount = 120 * 60 * 6;//120 = 120 * DrillingTick = 1分钟
                                                         //离线收益最高多长时间
        public const long MaxOfflineTick = SmallTickPerSecond * 60 * 60 * 12;//12小时

        //十连抽抽卡LotteryID
        public const int Ten_LotteryID = 48001;

        public const int One_PayLotteryID = 48002;

        public const int One_AdLotteryID = 48002;

        //单抽价格
        public const int OnePayCostID = 27005;
        //十连抽价格
        public const int TenPayCostID = 27004;

        public const int SyncSecond = 15;

        //电池礼包时间
        public const long BatteryGiftCount = 1 * 60 * 1000 * 10000L;//120 = 120 * DrillingTick = 1分钟
                                                                    //电池礼包掉落
        public const int BatteryGiftDropID = 30200;

        //血条显示时间
        public const float HpShowTime = 0.8f;

        public const int AudioChannel = 0;
        public const int MusicChannel = 1;

        //等级伤害减成
        public const float LvR = 0.05f;

        //初始掉落角色
        public const int FirstDropID = 30027;

        public const long SmallTickPerMilleSecond = 10000;
        public const long SmallTickPerSecond = 10000000;

        public const float ClickBtnBusyTime = 0.1f;
        public const int UnlockBusytimeCount = 5;

        //新手引导掉落
        public const int TutorialDrop = 31000;

        //背景音乐
        public const string Key_MUSIC_Tutorial = "bgm_home";
        public const string Key_MUSIC_GoDown = "bgm_go_down";
        public const string Key_MUSIC_HOME = "bgm_home";
        public const string Key_MUSIC_FIGHT = "bgm_fight_{0}";

        //星级对应颜色
        public static string[] StarBGPath =
        {
            "Images/UI_cut_520/bg_UI_cut_520_61",
            "Images/UI_cut_520/bg_UI_cut_520_61",
            "Images/UI_cut_520/bg_UI_cut_520_193",
            "Images/UI_cut_520/bg_UI_cut_520_34",
            "Images/UI_cut_520/bg_UI_cut_520_169",
            "Images/UI_cut_520/bg_UI_cut_520_170",
        };

        //战斗力公式id
        public const int FormulaID_CE = 3;
    }
}