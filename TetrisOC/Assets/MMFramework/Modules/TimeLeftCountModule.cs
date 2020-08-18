using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MMFramework;
namespace MMGame
{
    public class TimeLeftCountModule : MonoBehaviour, BaseModule
    {
        public enum IndexType
        {
            LotteryAd = 1,
        }

        /*
            记录两个变量
            1、上次记录是否是今天
            2、上次日期所剩次数 
        */

        public static TimeLeftCountModule Instance
        {
            get
            {
                return RootModule.Instance.GetModule<TimeLeftCountModule>();
            }
        }

        public void Init()
        {

        }

        public int GetCount(int key)
        {
            int ret;
            string lasttick_key = DataModule.CombineKey(DataModule.Key_EverydayLastTickN, key);
            string leftcount_key = DataModule.CombineKey(DataModule.Key_EverydayLeftN, key);
            int maxcount = EverydayCountData.GetData(key).MaxCount;
            if (DataModule.Instance.Have(lasttick_key))//有记录上次使用时间
            {
                long stored_timetick = DataModule.Instance.Get<long>(lasttick_key, TimeModule.Instance.NowTick);
                DateTime stored_time = new DateTime(stored_timetick);
                DateTime now_time = new DateTime(TimeModule.Instance.NowTick);
                if (stored_time.Date.Equals(now_time.Date)) //如果今天用过，读取时间
                {
                    ret = DataModule.Instance.Get<int>(leftcount_key, maxcount);
                }
                else //今天未用，按最大值算
                {
                    ret = maxcount;
                }
            }
            else
            {
                ret = maxcount;
            }

            return ret;
        }
        public int UsedCount(int key)
        {
            return EverydayCountData.GetData(key).MaxCount - GetCount(key);
        }

        public void Reset(int key)
        {
            int maxcount = EverydayCountData.GetData(key).MaxCount;
            string leftcount_key = DataModule.CombineKey(DataModule.Key_EverydayLeftN, key);
            DataModule.Instance.Set(leftcount_key, maxcount);
        }

        public void Eat(int key)
        {
            string lasttick_key = DataModule.CombineKey(DataModule.Key_EverydayLastTickN, key);
            string leftcount_key = DataModule.CombineKey(DataModule.Key_EverydayLeftN, key);

            int count = GetCount(key);
            count = count - 1;

            DataModule.Instance.Set(lasttick_key, TimeModule.Instance.NowTick);
            DataModule.Instance.Set(leftcount_key, count);
            NoticeTool.Broadcast(NoticeEnum.TimeLeftCountEat);
        }
    }
}