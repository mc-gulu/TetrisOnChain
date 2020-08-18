using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MMFramework;
namespace MMGame
{
    public class CountdownModule : MonoBehaviour, BaseModule
    {
        public static CountdownModule Instance
        {
            get
            {
                return RootModule.Instance.GetModule<CountdownModule>();
            }
        }

        public void Init()
        {

        }

        public const int Drilling = 1;
        public const int BatteryGift = 2;

        //查看是否有计数
        public long CheckCount(long smalltick, int index, bool server = true)
        {
            string key = DataModule.CombineKey(DataModule.Key_CountdownLastN, index);
            long nowsmalltimestamp = TimeModule.Instance.NowTickUtcMilliSecond;
            long last_smalltick = DataModule.Instance.Get<long>(key, nowsmalltimestamp, server);
            long delta = nowsmalltimestamp - last_smalltick;
            long num = delta / smalltick;
            return num;
        }

        //计数生效，计时更新
        public void ApplyCount(long num, long smalltick, int index, bool server = true)
        {
            string key = DataModule.CombineKey(DataModule.Key_CountdownLastN, index);
            long nowsmalltimestamp = TimeModule.Instance.NowTickUtcMilliSecond;
            long last_smalltick = DataModule.Instance.Get<long>(key, nowsmalltimestamp, server);
            last_smalltick += smalltick * num;
            DataModule.Instance.Set<long>(key, last_smalltick, server);
        }

        //下次计数生效所剩时间
        public long LeftTime_SmallTick(long smalltick, int index, bool server = true)
        {
            string key = DataModule.CombineKey(DataModule.Key_CountdownLastN, index);
            long nowsmalltimestamp = TimeModule.Instance.NowTickUtcMilliSecond;
            long last_smalltick = DataModule.Instance.Get<long>(key, nowsmalltimestamp, server);
            long delta = nowsmalltimestamp - last_smalltick;
            long num = delta / smalltick;
            long lefttime = smalltick * (num + 1) - delta;
            return lefttime;
        }

        //(重新)开始计时
        public void StartCount(int index, bool server = true)
        {
            long nowsmalltimestamp = TimeModule.Instance.NowTickUtcMilliSecond;
            string key = DataModule.CombineKey(DataModule.Key_CountdownLastN, index);
            DataModule.Instance.Set<long>(key, nowsmalltimestamp, server);
        }

        //手动设置时间
        public void SetCountdownTime(long smalltick, int index, bool server = true)
        {
            string key = DataModule.CombineKey(DataModule.Key_CountdownLastN, index);
            DataModule.Instance.Set<long>(key, smalltick, server);
        }

        //获取时间
        public long GetCountdownTime(int index, bool server = true)
        {
            long nowsmalltimestamp = TimeModule.Instance.NowTickUtcMilliSecond;
            string key = DataModule.CombineKey(DataModule.Key_CountdownLastN, index);
            return DataModule.Instance.Get<long>(key, nowsmalltimestamp, server);
        }

        public bool HaveCountdown(int index, bool server = true)
        {
            string key = DataModule.CombineKey(DataModule.Key_CountdownLastN, index);
            return DataModule.Instance.Have(key, server);
        }
    }
}