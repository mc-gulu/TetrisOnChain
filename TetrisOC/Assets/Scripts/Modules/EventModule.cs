using System.Collections.Generic;
using MMFramework;
using UnityEngine;
using LitJson;
using System;
using System.Linq;

namespace MMGame
{
    public enum EventEnum
    {
        LOAD_ALL_DATA,
        FILL_DATA,
        LOAD_MAIL,
        HERO_LEVELUP,

        SYNC_CACHE,
        HERO_STARUP,

        GM,
        HERO_RESET,
        BATTERY_USE,
        LOTTERY,
        MAIL_READ,
        MAIL_DELETEALL,
        MAIL_GETALL,
        OFFLINE_GET,
        TEAM_CHANGED,
        TASK_FINISH,
        TASK_DOUBLE,
        CHECKIN,
        UPDATE_DAYS,
        BATTERY_GIFT,
        TUTORIAL_DROP,

        HARVEST_GROUNDGOLD,//自动或者手动收取地上的金币
    }

    public class EventModule : MonoBehaviour, BaseModule
    {
        public static EventModule Instance
        {
            get
            {
                return RootModule.Instance.GetModule<EventModule>();
            }
        }

        public void Init()
        {

        }

        bool busy = false;

        public int HandleEvent(EventEnum eventenum, params object[] objs)
        {
            if (EventBusy())
            {
                return -2;
            }
            else if (!eventenum.Equals(EventEnum.LOAD_ALL_DATA) && !DataModule.Instance.Verify() && !DataModule.Instance.Verify(false))
            {
                Debug.LogError("校验失败 重新拉取数据");
                GameAccountModule.Instance.LoadAllValues();
                return -1;
            }
            else
            {
                int ret = 0;
                if (eventenum.Equals(EventEnum.LOAD_ALL_DATA))
                {
                    ret = LOAD_ALL_DATA(objs);
                }
                else if (eventenum.Equals(EventEnum.HERO_LEVELUP))
                {
                    ret = HERO_LEVELUP(objs);
                }
                else if (eventenum.Equals(EventEnum.SYNC_CACHE))
                {
                    ret = SYNC_CACHE(objs);
                }
                else if (eventenum.Equals(EventEnum.HERO_STARUP))
                {
                    ret = HERO_STARUP(objs);
                }
                else if (eventenum.Equals(EventEnum.HERO_RESET))
                {
                    ret = HERO_RESET(objs);
                }
                else if (eventenum.Equals(EventEnum.GM))
                {
                    ret = GM(objs);
                }
                else if (eventenum.Equals(EventEnum.BATTERY_USE))
                {
                    ret = BATTERY_USE(objs);
                }
                else if (eventenum.Equals(EventEnum.LOTTERY))
                {
                    ret = LOTTERY(objs);
                }
                else if (eventenum.Equals(EventEnum.LOAD_MAIL))
                {
                    ret = LOAD_MAIL(objs);
                }
                else if (eventenum.Equals(EventEnum.MAIL_READ))
                {
                    ret = MAIL_READ(objs);
                }
                else if (eventenum.Equals(EventEnum.MAIL_GETALL))
                {
                    ret = MAIL_GETALL(objs);
                }
                else if (eventenum.Equals(EventEnum.MAIL_DELETEALL))
                {
                    ret = MAIL_DELETEALL(objs);
                }
                else if (eventenum.Equals(EventEnum.FILL_DATA))
                {
                    ret = FILL_DATA(objs);
                }
                else if (eventenum.Equals(EventEnum.OFFLINE_GET))
                {
                    ret = OFFLINE_GET(objs);
                }
                else if (eventenum.Equals(EventEnum.TEAM_CHANGED))
                {
                    ret = TEAM_CHANGED(objs);
                }
                else if (eventenum.Equals(EventEnum.TASK_FINISH))
                {
                    ret = TASK_FINISH(objs);
                }
                else if (eventenum.Equals(EventEnum.TASK_DOUBLE))
                {
                    ret = TASK_DOUBLE(objs);
                }
                else if (eventenum.Equals(EventEnum.CHECKIN))
                {
                    ret = CHECKIN(objs);
                }
                else if (eventenum.Equals(EventEnum.UPDATE_DAYS))
                {
                    ret = UPDATE_DAYS(objs);
                }
                else if (eventenum.Equals(EventEnum.BATTERY_GIFT))
                {
                    ret = BATTERY_GIFT(objs);
                }
                else if (eventenum.Equals(EventEnum.TUTORIAL_DROP))
                {
                    ret = TUTORIAL_DROP(objs);
                }
                else if (eventenum.Equals(EventEnum.HARVEST_GROUNDGOLD))
                {
                    ret = HARVEST_GROUNDGOLD(objs);
                }

                if (ret < 0)
                    if (StringConfig.ErrorDict.ContainsKey(ret))
                        Debug.LogError(StringConfig.ErrorDict[ret]);
                    else
                        Debug.LogError("未定义错误 " + ret);

                return ret;
            }
        }
        int TASK_FINISH(object[] objs)
        {
            bool success = (bool)objs[0];

            var curLv = DataModule.Instance.MainLv;
            List<ItemObj> drops = null;
            if (success)
            {
                DataModule.Instance.MainLv = curLv + 1;
                FloorFightData ffd = FloorFightData.GetData(DataModule.Instance.MainLv);
                drops = ItemTools.GetDrops(ffd.BreakDropID);
                ItemModule.Instance.GetDrop(drops);
            }
            SyncData(() =>
            {
                RootModule.Instance.ScaleGame(1);
                //NoticeTool.Broadcast(NoticeEnum.CLEAR_ROOM);
                BattlefieldModule.Instance.BattleState = BattleState.normal;
                MMFrame.HideFrame(FrameData.FrameEnum.BattleBottomFrame);
                MMFrame.ShowFrame(FrameData.FrameEnum.BattleResultFrame, new object[] { success, curLv, drops });
            });
            return 0;
        }

        int TASK_DOUBLE(object[] objs)
        {
            FloorFightData ffd = FloorFightData.GetData(DataModule.Instance.MainLv);
            List<ItemObj> drops = ItemTools.GetDrops(ffd.BreakDropID);
            ItemModule.Instance.GetDrop(drops);

            SyncData(() =>
            {
                NoticeTool.Broadcast(NoticeEnum.TASK_REWARD_EXTRA, new object[] { drops });
            });
            return 0;
        }

        int BATTERY_USE(object[] objs)
        {
            int ret = DrillingModule.Instance.UseBattery();
            SyncData(delegate
            {
                NoticeTool.Broadcast(NoticeEnum.BATTERY_IN);
            });
            return ret;
        }

        int GM(object[] objs)
        {
            int index = (int)objs[0];
            string val = (string)objs[1];

            GMModule.Instance.ActiveCmd(index, val);

            return 0;
        }
        int HERO_RESET(object[] objs)
        {
            var id = (int)objs[0];
            var backnum = HeroModule.Instance.CanResetHero(id);
            if (backnum != 0)
                return backnum;
            HeroModule.Instance.ResetHero(id);
            SyncData(() =>
            {
                NoticeTool.Broadcast(NoticeEnum.HERO_RESET, new object[] { id });
            });
            return 0;
        }
        int HERO_STARUP(object[] objs)
        {
            var upid = (int)objs[0];
            var remids = (int[])objs[1];
            var list = DataModule.Instance.GetHeroDataDic();
            var backnum = HeroModule.Instance.CanStarUp(upid, remids);
            if (backnum != 0)
                return backnum;
            var allcost = HeroModule.Instance.StarUpAndRemove(upid, remids);
            SyncData(() =>
            {
                NoticeTool.Broadcast(NoticeEnum.HERO_STARUP, new object[] { upid });
                MMFrame.ShowFrame(FrameData.FrameEnum.HeroStarUpShowFrame, new object[] { upid });
            });
            return 0;
        }

        int LOAD_ALL_DATA(params object[] objs)
        {
            string rootjson = (string)objs[0];
            DataModule.Instance.SetRoot(rootjson);
            return 0;
        }
        int HERO_LEVELUP(params object[] objs)
        {
            int id = (int)objs[0];
            int addlv = int.Parse(objs[1].ToString());
            int backNum = HeroModule.Instance.CanLevelUp(id, addlv);
            if (backNum != 0)
                return backNum;
            HeroModule.Instance.LevelUpHero(id, addlv);
            SyncData(() =>
            {
                NoticeTool.Broadcast(NoticeEnum.HEROLV_CHANGED, new object[] { id });
            });
            return 0;
        }

        int SYNC_CACHE(params object[] objs)
        {
            DrillingModule.Instance.Sync();
            SyncData();
            return 0;
        }

        int LOTTERY(params object[] objs)
        {
            int lotteryIndex = (int)objs[0];
            if (objs.Length > 1)
            {
                int costID = (int)objs[1];
                CostTool.PayCost(costID);
            }

            List<ItemObj> drops = LotteryModule.Instance.EventLottery(lotteryIndex);
            SyncData(delegate
            {
                MMFrame.ShowFrame(FrameData.FrameEnum.GetItemsFrame, new object[] { drops });
                NoticeTool.Broadcast(NoticeEnum.UPDATE_LOTTERY);
            });
            return 0;
        }
        int TEAM_CHANGED(params object[] objs)
        {
            List<int> teamlist = objs[0] as List<int>;
            if (teamlist.Count != 4)
                return -801;
            var dic = DataModule.Instance.GetHeroDataDic();
            foreach (var item in teamlist)
            {
                if (!dic.ContainsKey(item.ToString()) && item != 0) return -802;
            }
            for (int i = 0; i < teamlist.Count - 1; i++)
            {
                if (teamlist[i] == 0) continue;
                for (int j = i + 1; j < teamlist.Count; j++)
                {
                    if (teamlist[j] == 0) continue;
                    if (DataModule.Instance.GetHeroData(teamlist[i]).creatureid == DataModule.Instance.GetHeroData(teamlist[j]).creatureid)
                    {
                        return -803;
                    }
                }
            }
            DataModule.Instance.Set(DataModule.Key_Team, teamlist);
            Action callback = objs[1] as Action;
            SyncData(callback);
            return 0;
        }

        int LOAD_MAIL(params object[] objs)
        {
            return 0;
        }

        int BATTERY_GIFT(params object[] objs)
        {
            List<ItemObj> list = ItemTools.GetDrops(ConfigInGame.BatteryGiftDropID);
            ItemModule.Instance.GetDrop(list);
            CountdownModule.Instance.StartCount(CountdownModule.BatteryGift);
            SyncData(delegate
            {
                if (list != null && list.Count > 0)
                    MMFrame.ShowFrame(FrameData.FrameEnum.GetItemsFrame, new object[] { list });
            });

            return 0;
        }

        int TUTORIAL_DROP(object[] objs)
        {
            List<ItemObj> list = ItemTools.GetDrops(ConfigInGame.TutorialDrop);
            ItemModule.Instance.GetDrop(list);
            SyncData();
            return 0;
        }

        int MAIL_READ(params object[] objs)
        {
            int mailID = (int)objs[0];
            List<ItemObj> list = MailModule.Instance.ReadMail(mailID);
            SyncData(delegate
            {
                NoticeTool.Broadcast(NoticeEnum.EMAIL_UPDATE);
                if (list != null && list.Count > 0)
                    MMFrame.ShowFrame(FrameData.FrameEnum.GetItemsFrame, new object[] { list });
            });
            return 0;
        }

        int MAIL_GETALL(params object[] objs)
        {
            List<ItemObj> list = MailModule.Instance.CollectAll();
            SyncData(delegate
            {
                NoticeTool.Broadcast(NoticeEnum.EMAIL_UPDATE);
                if (list != null && list.Count > 0)
                    MMFrame.ShowFrame(FrameData.FrameEnum.GetItemsFrame, new object[] { list });
            });
            return 0;
        }

        int MAIL_DELETEALL(params object[] objs)
        {
            MailModule.Instance.DeleteAllRead();
            SyncData(delegate
            {
                NoticeTool.Broadcast(NoticeEnum.EMAIL_UPDATE);
            });
            return 0;
        }

        int OFFLINE_GET(params object[] objs)
        {
            List<ItemObj> list = OfflineModule.Instance.Harvest();
            DrillingModule.Instance.Sync();
            SyncData(delegate
            {
                if (list != null && list.Count > 0)
                    MMFrame.ShowFrame(FrameData.FrameEnum.GetItemsFrame, new object[] { list });
            });
            return 0;
        }

        int CHECKIN(params object[] objs)
        {
            int checkinID = (int)objs[0];
            List<ItemObj> list = CheckinModule.Instance.GetReward(checkinID);
            SyncData(delegate
            {
                if (list != null && list.Count > 0)
                    MMFrame.ShowFrame(FrameData.FrameEnum.GetItemsFrame, new object[] { list });
                NoticeTool.Broadcast(NoticeEnum.UPDATE_REDPOINT, new object[] { "rightlist.checkin" });
                NoticeTool.Broadcast(NoticeEnum.CHECKIN_UPDATE);
            });
            return 0;
        }

        int UPDATE_DAYS(params object[] objs)
        {
            TimeModule.Instance.UpdateDays();
            SyncData(delegate
            {
                if (LoginProcessModule.Instance.State.process.Equals(LoginProcess.UPDATE_DAYS)
                        && LoginProcessModule.Instance.State.state.Equals(ProcessState.Doing))
                {
                    LoginProcessModule.Instance.StateDone();
                }
                NoticeTool.Broadcast(NoticeEnum.UPDATE_DAYS);
            });
            return 0;
        }

        int HARVEST_GROUNDGOLD(params object[] objs)
        {
            if (DataModule.Instance.Verify())
            {
                DrillingModule.Instance.HarvestGroundGold();
                DataModule.Instance.GenerateMd5(true);
                SyncData();
            }
            else
            {
                Debug.LogError("校验失败 临时数据被篡改");
            }
            return 0;
        }

        int FILL_DATA(params object[] objs)
        {
            if (!DataModule.Instance.Have(DataModule.Key_PrivateMaillist))
            {
                List<Mail> mlist = new List<Mail>();
                DataModule.Instance.Set(DataModule.Key_PrivateMaillist, mlist);
            }

            // if (!DataModule.Instance.Have(DataModule.Key_Timestamp))
            // {
            //     long nowstamp = TimeModule.Instance.NowTickUtcMilliSecond;
            //     DataModule.Instance.Set(DataModule.Key_Timestamp, nowstamp);
            // }

            if (!CountdownModule.Instance.HaveCountdown(CountdownModule.BatteryGift))
            {
                CountdownModule.Instance.StartCount(CountdownModule.BatteryGift);
            }

            if (!DataModule.Instance.Have(DataModule.Key_GetGoldTime))
            {
                DataModule.Instance.Set<long>(DataModule.Key_GetGoldTime, TimeModule.Instance.NowTickUtcMilliSecond);
            }

            //TODO
            Dictionary<string, RealHeroData> herodict = DataModule.Instance.GetHeroDataDic();
            if (herodict.Count == 0)
            {
                ItemModule.Instance.GetDrop(ConfigInGame.FirstDropID);
                List<int> teamlist = new List<int>();
                teamlist.Add(1);
                teamlist.Add(0);
                teamlist.Add(0);
                teamlist.Add(0);
                DataModule.Instance.Set(DataModule.Key_Team, teamlist);
            }

            if (!DataModule.Instance.Have(DataModule.Key_mainlv))
            {
                DataModule.Instance.Set(DataModule.Key_mainlv, 1);
            }




            SyncData(delegate
            {
                // long nowstamp = TimeModule.Instance.NowTickUtcMilliSecond;
                // long lasttimestemp = DataModule.Instance.Get(DataModule.Key_Timestamp, nowstamp);
                // if (DataModule.Instance.Verify(false))
                // {
                //     CountdownModule.Instance.SetCountdownTime(lasttimestemp, CountdownModule.Drilling, false);
                //     DataModule.Instance.GenerateMd5(false);
                // }
                // else
                // {
                //     Debug.LogError("作弊");
                // }

                LoginProcessModule.Instance.StateDone();
            });

            return 0;
        }

        public bool EventBusy()
        {
            return busy;
        }

        public void SyncData(Action successcallback = null)
        {
            busy = true;
            DataModule.Instance.SyncData("reason", delegate (bool success, JsonData jsondata)
            {
                if (success)
                {
                    busy = false;
                    DataModule.Instance.ApplyValueChangedToUI();

                    if (successcallback != null)
                        successcallback();
                }
            });
        }
    }
}