using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using MMFramework;
namespace MMGame
{
    public class TimeModule : MonoBehaviour, BaseModule//查次数
    {
        public static TimeModule Instance
        {
            get
            {
                return RootModule.Instance.GetModule<TimeModule>();
            }
        }

        public void Init()
        {
            SyncTime();
        }

        long sc_tick_delta = 0;
        long timezone_tick_offset = 0;

        public void SyncTime()
        {
            // Debug.LogError("TimeModule SyncTime");
            //时区
            int timezoneoffset = ConfigModule.Instance.TimeZoneOffset;
            TimeSpan timeSpan = new TimeSpan(timezoneoffset);
            timezone_tick_offset = ToUnixTicks(timeSpan);
            //时间
            long client_tick1 = ToUnixTicks(DateTime.UtcNow);
            ServerModule.Instance.GetServerTime(delegate (bool successtime, LitJson.JsonData jsontime)
            {
                if (successtime)
                {
                    long client_tick2 = ToUnixTicks(DateTime.UtcNow);
                    long client_tick = (client_tick1 + client_tick2) / 2;
                    long server_tick = (long)jsontime["time"];
                    sc_tick_delta = server_tick - client_tick;

                    if (LoginProcessModule.Instance.State.process.Equals(LoginProcess.TimeDate)
                        && LoginProcessModule.Instance.State.state.Equals(ProcessState.Doing))
                    {
                        LoginProcessModule.Instance.StateDone();
                    }

                    // NoticeUI.Broadcast(NoticeID.SERVER_TIME_UPDATE);
                }
            });
        }

        public long NowTick
        {
            get
            {
                return NowTickUtc + timezone_tick_offset;
            }
        }

        public long NowTickUtc
        {
            get
            {
                return ToUnixTicks(DateTime.UtcNow) + sc_tick_delta;
            }
        }

        public long NowTickUtcMilliSecond
        {
            get
            {
                return DateTime.UtcNow.Ticks + sc_tick_delta * TimeSpan.TicksPerSecond;
            }
        }

        public static DateTime ToUnityDateTime(long timestamp)
        {
            DateTime date = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc).AddSeconds(timestamp);
            return date;
        }
        public static TimeSpan ToUnityTimeSpan(long timestamp)
        {
            TimeSpan time = new TimeSpan(timestamp * TimeSpan.TicksPerSecond);
            return time;
        }

        public static long ToUnixTicks(DateTime dateTime)
        {
            DateTime dt1970 = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            return (dateTime.Ticks - dt1970.Ticks) / TimeSpan.TicksPerSecond;
        }

        public static long ToUnixTicks(TimeSpan timeSpan)
        {
            return Convert.ToInt64(timeSpan.TotalSeconds);
        }

        public int Days
        {
            get
            {
                int timezoneoffset = ConfigModule.Instance.TimeZoneOffset;

                DateTime start = new DateTime(2014, 10, 25, 0, 0, 0, DateTimeKind.Utc);
                start = start.AddHours(Convert.ToDouble(timezoneoffset));

                DateTime today = ToUnityDateTime(TimeModule.Instance.NowTickUtc);
                today = today.AddHours(Convert.ToDouble(timezoneoffset));

                TimeSpan fromstartdays = today.Date - start.Date;
                return Convert.ToInt32(fromstartdays.TotalDays);
            }
        }

        public void UpdateDays()
        {
            int lastday = DataModule.Instance.Get<int>(DataModule.Key_LastDay, 0);
            int logindays = DataModule.Instance.Get<int>(DataModule.Key_LoginDays, 1);
            int continuelogindays = DataModule.Instance.Get<int>(DataModule.Key_ContinueLoginDays, 1);
            if (lastday == 0)
            {
                //DataModule.Instance.LastDay = today;
            }
            else if ((Days - lastday) == 1)
            {
                DataModule.Instance.Set<int>(DataModule.Key_LoginDays, logindays + 1);
                DataModule.Instance.Set<int>(DataModule.Key_ContinueLoginDays, continuelogindays + 1);
            }
            else if ((Days - lastday) > 1)
            {
                DataModule.Instance.Set<int>(DataModule.Key_LoginDays, logindays + 1);
                DataModule.Instance.Set<int>(DataModule.Key_ContinueLoginDays, 1);
            }
            else
            {
                //nothing
            }

            DataModule.Instance.Set<int>(DataModule.Key_LastDay, Days);
        }
    }
}