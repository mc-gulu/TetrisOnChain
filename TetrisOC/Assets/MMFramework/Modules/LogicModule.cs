using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MMFramework;
namespace MMFramework
{
    public class LogicModule : MonoBehaviour, BaseModule
    {
        //TalkingData

        public static LogicModule Instance
        { get { return RootModule.Instance.GetModule<LogicModule>(); } }

        Dictionary<string, int> logicdict;

        public void Init()
        {
            logicdict = StorageModule.LoadStructDef(StorageKey.LogicDict, new Dictionary<string, int>());
        }

        public void Active(int logicID)
        {
            NoticeTool.Broadcast(NoticeEnum.MASK_CLEAR);
            LogicData logicdata = LogicData.GetData(logicID);
            for (int i = 0; i < logicdata.ActiveNameArray.Length; i++)
            {
                string aname = logicdata.ActiveNameArray[i];
                int val = logicdata.ActiceValueArray[i];
                if (!string.IsNullOrEmpty(aname))
                {
                    logicdict[aname] = val;
                }
            }
            StorageModule.SaveStruct(StorageKey.LogicDict, logicdict);
            NoticeTool.Broadcast(NoticeEnum.MASK_UPDATE);

            if (logicID.Equals(7))
            {
                RootModule.Instance.PauseAll(false);
            }
        }

        public bool IsPrepared(int logicID)
        {
            if (!SDK_Configs.Tutorial)
                return false;
            LogicData logicdata = LogicData.GetData(logicID);
            for (int i = 0; i < logicdata.ConditionNameArray.Length; i++)
            {
                string cname = logicdata.ConditionNameArray[i];
                int val = logicdata.ConditionValueArray[i];
                if (!string.IsNullOrEmpty(cname))
                {
                    if (logicdict.ContainsKey(cname) && logicdict[cname].Equals(val))
                    {
                        continue;
                    }
                    else if (!logicdict.ContainsKey(cname) && val.Equals(0))
                    {
                        continue;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public string Prefab(int logicID)
        {
            LogicData logicdata = LogicData.GetData(logicID);
            return logicdata.Prefab;
        }

        void Handler(System.Enum noticeID, object[] objects)
        {
            int logicID = (int)objects[0];
            Active(logicID);
        }

        private void OnEnable()
        {
            NoticeTool.RegisterNotice(NoticeEnum.MASK_LOGIC_FINISH, Handler);
        }

        private void OnDisable()
        {
            NoticeTool.UnRegisterNotice(NoticeEnum.MASK_LOGIC_FINISH, Handler);
        }
    }
}