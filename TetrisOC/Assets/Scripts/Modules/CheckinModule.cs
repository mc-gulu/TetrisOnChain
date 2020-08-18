using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MMFramework;
namespace MMGame
{
    public enum CheckinStateEnum
    {
        Ready,
        NotReady,
        Got,
    }

    public class CheckinModule : MonoBehaviour, BaseModule
    {
        public static CheckinModule Instance
        {
            get
            {
                return RootModule.Instance.GetModule<CheckinModule>();
            }
        }

        public void Init()
        {
            RedModule.Instance.Regist("rightlist.checkin", delegate
            {
                int num = 0;
                List<int> checkinlist = CheckinData.GetKeys();
                for (int i = 0; i < checkinlist.Count; i++)
                {
                    int checkinID = checkinlist[i];
                    CheckinStateEnum state = GetState(checkinID);
                    if (state.Equals(CheckinStateEnum.Ready))
                        num++;
                }

                return num;
            });
        }

        public List<ItemObj> GetReward(int checkinID)
        {
            List<ItemObj> drops = null;
            CheckinStateEnum state = GetState(checkinID);
            if (state.Equals(CheckinStateEnum.Ready))
            {
                CheckinData checkin = CheckinData.GetData(checkinID);
                drops = ItemTools.GetDrops(checkin.DropID);
                ItemModule.Instance.GetDrop(drops);
                string key = DataModule.CombineKey(DataModule.Key_CheckinN, checkinID);
                DataModule.Instance.Set<int>(key, 1);
            }
            return drops;
        }

        public CheckinStateEnum GetState(int checkinID)
        {
            int logindays = DataModule.Instance.Get<int>(DataModule.Key_LoginDays, 1);
            string key = DataModule.CombineKey(DataModule.Key_CheckinN, checkinID);
            int got = DataModule.Instance.Get<int>(key, 0);
            if (logindays > checkinID)
            {
                if (got == 0)
                    return CheckinStateEnum.Ready;
                else
                    return CheckinStateEnum.Got;
            }
            else
                return CheckinStateEnum.NotReady;

        }
    }
}