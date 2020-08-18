using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MMFramework;
using System;
namespace MMGame
{
    public class DrillingModule : MonoBehaviour, BaseModule
    {
        public static DrillingModule Instance
        {
            get
            {
                return RootModule.Instance.GetModule<DrillingModule>();
            }
        }

        public void Init()
        {
            // Debug.LogError("TickPerMillisecond" + TimeSpan.TicksPerMillisecond);
        }

        public System.Numerics.BigInteger CalculateGroundGold()
        {
            //普通矿机部分
            long lastgettime = DataModule.Instance.Get<long>(DataModule.Key_GetGoldTime, TimeModule.Instance.NowTickUtcMilliSecond);
            long nowtime = TimeModule.Instance.NowTickUtcMilliSecond;
            int floorfightID = DataModule.Instance.MainLv;
            FloorFightData ffd = FloorFightData.GetData(floorfightID);
            System.Numerics.BigInteger drillinggold = CalculateTool.Calculate2BigInt(floorfightID, ffd.GoldSecond) * (nowtime - lastgettime) / ConfigInGame.DrillingTick;

            //电池矿机部分
            long batterystarttime = DataModule.Instance.Get<long>(DataModule.Key_BatteryStartTime, 0);
            long batteryendtime = batterystarttime + ConfigInGame.BatterySecond;

            long starttime = Math.Max(lastgettime, batterystarttime);
            long endtime = Math.Min(nowtime, batteryendtime);
            long btime = Math.Max((endtime - starttime), 0);
            System.Numerics.BigInteger batterygold = CalculateTool.Calculate2BigInt(floorfightID, ffd.GoldSecond) * 9 * btime / ConfigInGame.DrillingTick;
            System.Numerics.BigInteger total = drillinggold + batterygold;
            // Debug.LogError(total.ToString());
            return total;
        }

        public void HarvestGroundGold()
        {
            NoticeTool.Broadcast(NoticeEnum.HARVESTGROUND_UI);

            System.Numerics.BigInteger gold = CalculateGroundGold();
            DataModule.Instance.Set(DataModule.Key_Gold, (DataModule.Instance.Gold + gold).ToString());
            DataModule.Instance.Set<long>(DataModule.Key_GetGoldTime, TimeModule.Instance.NowTickUtcMilliSecond);
        }

        public void Sync()
        {
            // System.Numerics.BigInteger gold = DataModule.Instance.Gold;
            // DataModule.Instance.Gold = gold;

            // int exp = DataModule.Instance.Exp;
            // DataModule.Instance.Exp = exp;

            // long nowstamp = TimeModule.Instance.NowTickUtcMilliSecond;
            //DataModule.Instance.Get(DataModule.Key_Timestamp, nowstamp, false);
            // long laststemp = CountdownModule.Instance.GetCountdownTime(CountdownModule.Drilling, false);
            // DataModule.Instance.Set(DataModule.Key_Timestamp, laststemp);

            // DrillingModule.Instance.HarvestGroundGold();
        }

        public int UseBattery()
        {
            if (IsEnergy())
                return -1001;

            //装电池之前先收取已有的
            NoticeTool.Broadcast(NoticeEnum.AUTO_HARVESTGROUND);

            //装电池
            DataModule.Instance.Battery--;
            //设置电池开始时间
            long timenow = TimeModule.Instance.NowTickUtcMilliSecond;
            DataModule.Instance.Set<long>(DataModule.Key_BatteryStartTime, timenow);

            DataModule.Instance.GenerateMd5(true);
            return 0;
        }

        long BatteryLeftTime()
        {
            long timenow = TimeModule.Instance.NowTickUtcMilliSecond;
            long batterystarttime = DataModule.Instance.Get<long>(DataModule.Key_BatteryStartTime, 0);
            long timespansmalltick = batterystarttime + ConfigInGame.BatterySecond - timenow;
            return timespansmalltick;
        }

        public string GetBatteryLefttime()
        {
            long timespansmalltick = BatteryLeftTime();
            if (timespansmalltick > 0)
            {
                return TimeTools.ShortTime(timespansmalltick);
            }
            else
                return string.Empty;
        }

        public bool IsEnergy()
        {
            long timespansmalltick = BatteryLeftTime();
            bool energy = timespansmalltick > 0;
            return energy;
        }

        void Handler(System.Enum noticeEnum, object[] objects)
        {
            EventModule.Instance.HandleEvent(EventEnum.HARVEST_GROUNDGOLD);
        }

        void OnEnable()
        {
            NoticeTool.RegisterNotice(NoticeEnum.AUTO_HARVESTGROUND, Handler);
        }

        void OnDisable()
        {
            NoticeTool.UnRegisterNotice(NoticeEnum.AUTO_HARVESTGROUND, Handler);
        }

        public System.Numerics.BigInteger OneTickGet()
        {
            int floorfightID = DataModule.Instance.MainLv;
            FloorFightData ffd = FloorFightData.GetData(floorfightID);
            return CalculateTool.Calculate2BigInt(floorfightID, ffd.GoldSecond);
        }

        public int OneDrop()
        {
            int floorfightID = DataModule.Instance.MainLv;
            FloorFightData ffd = FloorFightData.GetData(floorfightID);
            if (IsEnergy())
            {
                return ffd.ShowCharging;
            }
            else
            {
                return ffd.ShowGoldOnetime;
            }
        }

        public int GroundNeedParticles()
        {
            long nowtime = TimeModule.Instance.NowTickUtcMilliSecond;
            int floorfightID = DataModule.Instance.MainLv;
            FloorFightData ffd = FloorFightData.GetData(floorfightID);
            //矿机最大 * 时间百分比
            long lastgettime = DataModule.Instance.Get<long>(DataModule.Key_GetGoldTime, TimeModule.Instance.NowTickUtcMilliSecond);
            float percent = (nowtime - lastgettime) / System.Convert.ToSingle(ConfigInGame.MaxOfflineTick / 10);

            int drilling = System.Convert.ToInt32(ffd.ShowGroundMax * percent);
            drilling = Math.Max(drilling, 10);


            //电池产 * 时间百分比
            long batterystarttime = DataModule.Instance.Get<long>(DataModule.Key_BatteryStartTime, 0);
            long currenttime = nowtime - batterystarttime;
            if (currenttime > ConfigInGame.BatterySecond)
                currenttime = 0;
            float bpercent = currenttime / System.Convert.ToSingle(ConfigInGame.BatterySecond);
            int battery = System.Convert.ToInt32(ffd.ShowCharging * bpercent);

            // Debug.LogError(string.Format("{0}  {1}  {2}  {3}  {4}  {5}", ffd.ShowGroundMax, percent, drilling, ffd.ShowCharging, bpercent, battery));
            return drilling + battery;
        }

        bool last_is_energy = false;//不依赖此变量检测，只用作标记存档使用

        public static bool inited = false;


        void Update()
        {
            if (!inited)
                return;

            bool isenergy = IsEnergy();

            if (last_is_energy && !isenergy)
            {
                NoticeTool.Broadcast(NoticeEnum.BATTERY_OUT);
            }

            last_is_energy = isenergy;

            //事件2 使用电池（与事件1区分，以防止Event内部调Event产生的校验失败
            if (!isenergy && DataModule.Instance.Battery > 0)
                EventModule.Instance.HandleEvent(EventEnum.BATTERY_USE, null);

            /*
                long ticktime = isenergy ? ConfigInGame.DrillingTick_Battery : ConfigInGame.DrillingTick;
                long num = CountdownModule.Instance.CheckCount(ticktime, CountdownModule.Drilling, false);
                long left = CountdownModule.Instance.LeftTime_SmallTick(ticktime, CountdownModule.Drilling, false);

                if (num > 0)
                    if (DataModule.Instance.Verify(false))
                    {
                        CountdownModule.Instance.ApplyCount(num, ticktime, CountdownModule.Drilling, false);
                        DataModule.Instance.GenerateMd5(false);
                    }
                    else
                        Debug.LogError("校验失败 临时数据被篡改");


                if (num > ConfigInGame.MinOfflineCount)
                {
                    //事件1 加金币
                    if (DataModule.Instance.Verify(false))
                    {
                        num = Math.Min(num, ConfigInGame.MaxOfflineCount);
                        //增加离线时长
                        long lastsmalltick = DataModule.Instance.Get<long>(DataModule.Key_OfflineTime, 0L);
                        long smalltick = lastsmalltick + num * ticktime;
                        DataModule.Instance.Set<long>(DataModule.Key_OfflineTime, smalltick);
                        //计算离线收益
                        int floorfightID = DataModule.Instance.MainLv;
                        FloorFightData ffd = FloorFightData.GetData(floorfightID);
                        int goldcache_add = ffd.GoldSecond * Convert.ToInt32(num);

                        ItemObj item = new ItemObj(ItemTools.ID_Gold, goldcache_add);
                        List<ItemObj> list = new List<ItemObj>();
                        list.Add(item);
                        //增加离线收益
                        OfflineModule.Instance.AddOfflineItems(list);

                        DataModule.Instance.GenerateMd5(false);

                    }
                    else
                    {
                        Debug.LogError("校验失败 临时数据被篡改");
                    }
                }
                else if (num > 0)
                {
                    if (DataModule.Instance.Verify(false))
                    {
                        //事件1 加金币
                        int floorfightID = DataModule.Instance.MainLv;
                        FloorFightData ffd = FloorFightData.GetData(floorfightID);
                        int goldcache_add = ffd.GoldSecond * Convert.ToInt32(num);
                        DataModule.Instance.GoldCache += goldcache_add;
                        DataModule.Instance.ExpCache += ffd.ExpSecond * Convert.ToInt32(num);
                        NoticeTool.Broadcast(NoticeEnum.GOLD_CACHE_ADD, new object[] { goldcache_add });

                        DataModule.Instance.GenerateMd5(false);
                    }
                    else
                    {
                        Debug.LogError("校验失败 临时数据被篡改");
                    }


                }*/
        }
    }
}