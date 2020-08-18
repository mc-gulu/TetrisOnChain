using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using Umeng;

namespace MMFramework
{
    public class AnalyticsModule : MonoBehaviour, BaseModule
    {
        public const string TopLv = "maxlv"; //玩家最高等级
        public const string NoticeBoard = "noticeboard"; //玩家观看公告板
        public const string Store = "store"; //打开商店页面
        public const string TryBuyHero = "trybuyhero"; //尝试购买英雄
        public const string UMengBoughtHero = "boughthero";
        public const string UMengReliveAD = "relive_ad";
        public const string UMengReliveGold = "relive_gold";
        public const string UMengCombineSuccess = "combinesuccess";
        public const string UMengCombineFail = "combinefail";
        public const string UMengGetPushed = "getpushed";
        //多少次才能通5关第一次
        //查看明日增送的界面
        //查看突破法球的界面(每个人一次)
        //多少人查看过小猫(每个人一次)
        //玩家总共突破成功多少次,失败次数,看广告重铸次数,最大看广告重铸次数
        //死在哪个怪上

        public const string UMengTopStage = "topstage";
        public const string UMengMoneyToday = "moneytoday";
        public const string UMengTowerToday = "towertoday";
        public const string UMengExpToday = "exptoday";
        public const string UMengMaxTower = "maxtower";
        public const string UMengMulti = "multi_";

        //TalkingData
        public const string ProcessOver = "ProcessFinish";
        public const string ProcessOverStart = "start";
        public const string ProcessOverEnd = "end";
        public const string ProcessOverDuring = "during";
        public const string ProcessOverLevel = "level";
        public const string ProcessOverFloor = "floor";
        public const string ProcessOverSuccess = "success";
        public const string ProcessOverRoomtype = "roomtype";
        public const string ProcessOverStarSuccess = "starsuccess";
        public const string ProcessOverAdvnumSuccess = "advnumsuccess";
        public const string ProcessOverFirstDayAdv = "firstdayadv";

        public const string ADStart = "AdStart";
        public const string ADNoad = "AdNoad";
        public const string ADShowSuccess = "AdShowSuccess";

        public const string Event_First_LoginProcess = "FirstLoginProcess";
        public const string Event_LoginProcess = "LoginProcess";

        public static AnalyticsModule Instance
        {
            get
            {
                return RootModule.Instance.GetModule<AnalyticsModule>();
            }
        }
        public void Init()
        {

        }

        public void InitAnalytics(int serverID, string accountID)
        {

            SDKMap.Analytics.InitSDK(ChannelConfigs.ChannelName);
            SDKMap.Analytics.SetAccount(serverID, accountID);
        }

        public void OnChargeRequest(
            string orderID,
            string iAPID,
            float payAmount,
            string payUnit,
            double getAmount,
            string payChannelType)
        {
            SDKMap.Analytics.OnChargeRequest(orderID, iAPID, payAmount, payUnit, getAmount, payChannelType);
        }

        public void OnChargeSuccess(string orderID)
        {
            SDKMap.Analytics.OnChargeSuccess(orderID);
        }

        public void OnReward(int value, string reason) //获得
        {
            SDKMap.Analytics.OnReward(value, reason);
        }

        public void OnPurchase(string reason, int count, int value) //消耗
        {
            SDKMap.Analytics.OnPurchase(reason, count, value);
        }

        public void OnEvent(string key, Dictionary<string, object> dict)
        {
            SDKMap.Analytics.OnEvent(key, dict);
        }

        public void Event(string key)
        {
            OnEvent(key, new Dictionary<string, object>());
        }
        public void Event(string key, int val)
        {
            Dictionary<string, object> dict = new Dictionary<string, object>();
            dict["value"] = val;
            OnEvent(key, dict);
        }

        public void EventWithData(string key, int val, bool version = true, bool practicelv = true, bool maxstar = true, bool heronow = true, bool vip = true, bool week = true)
        {
            Dictionary<string, object> dict = new Dictionary<string, object>();
            dict["value"] = val;
            // if (version)
            //     dict["version"] = Application.version;
            // if (practicelv)
            //     dict["practicelv"] = PlayerModule.Instance.Practice.ToString();
            // if (maxstar)
            //     dict["star"] = DataModule.Instance.LevelStarMax.ToString();
            // if (heronow)
            //     dict["hero"] = DataModule.Instance.CurrentHero.ToString();
            // if (vip)
            //     dict["vip"] = (MonthlyModule.Instance.VipLeft > 0).ToString();
            // if (week)
            //     dict["week"] = (WeeklyModule.Instance.VipLeft > 0).ToString();
            OnEvent(key, dict);
        }

        public void Value(string key, string reason, int delta)
        {
            Dictionary<string, object> dict = new Dictionary<string, object>();
            dict[reason] = delta;
            OnEvent(key, dict);
        }

        public void UserLevel(int level)
        {
            SDKMap.Analytics.UserLevel(level);
        }
        public void StartStage(int stage)
        {
            SDKMap.Analytics.StartStage(stage);
        }
        public void EndStage(bool success)
        {
            SDKMap.Analytics.EndStage(success);
        }

        public void Step(bool onlyfirst, string eventname, string stepname)
        {
            if (onlyfirst)
            {
                string key = "Analytics-" + eventname + "-" + stepname;
                if (PlayerPrefs.HasKey(key) || PlayerPrefs.HasKey("gid"))
                    return;
                else
                    PlayerPrefs.SetInt(key, 0);
            }
            Dictionary<string, object> stepparam = new Dictionary<string, object>();
            stepparam.Add("version", Application.version);

            string finaleventname = eventname + stepname;
            OnEvent(finaleventname, stepparam);
            // Debug.Log(finaleventname);
        }

        Dictionary<string, int> dict = new Dictionary<string, int>();

        //不按stepindex来，不记录
        //首次以外，不记录,删除旧有
        public void Step(bool onlyfirst, string eventname, int stepindex)
        {
            if (onlyfirst && stepindex == 0)
            {
                string key = "Analytics-" + eventname;

                if (PlayerPrefs.HasKey(key) || PlayerPrefs.HasKey("gid"))
                {
                    if (dict.ContainsKey(eventname))
                        dict.Remove(eventname);
                    return;
                }
                else
                {
                    PlayerPrefs.SetInt(key, 0);
                }
            }
            if (stepindex > 0)
            {
                if (!dict.ContainsKey(eventname) || dict[eventname] != stepindex - 1)
                {
                    if (dict.ContainsKey(eventname))
                        dict.Remove(eventname);
                    return;
                }
            }

            dict[eventname] = stepindex;
            Dictionary<string, object> stepparam = new Dictionary<string, object>();
            stepparam.Add("version", Application.version);

            string finaleventname = eventname + stepindex.ToString("D2");
            OnEvent(finaleventname, stepparam);
            // Debug.Log(finaleventname);
        }
    }
}