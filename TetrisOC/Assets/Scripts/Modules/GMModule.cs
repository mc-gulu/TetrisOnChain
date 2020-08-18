using System.Collections.Generic;
using MMFramework;
using UnityEngine;
using LitJson;
using UnityEngine.UI;
namespace MMGame
{
    public class GMModule : MonoBehaviour, BaseModule
    {
        public static GMModule Instance
        {
            get
            {
                return RootModule.Instance.GetModule<GMModule>();
            }
        }

        public void Init()
        {

        }

        public void ActiveCmd(int index, string val)
        {
            if (index == 0)
            {
                int dropID = int.Parse(val);
                List<ItemObj> list = ItemTools.GetDrops(dropID);
                ItemModule.Instance.GetDrop(list);
                EventModule.Instance.SyncData(delegate
                {
                    MMFrame.ShowFrame(FrameData.FrameEnum.GetItemsFrame, new object[] { list });
                });
            }
            else if (index == 1)
            {
                int dropID = int.Parse(val);
                List<ItemObj> list = ItemTools.GetDrops(dropID);
                ItemModule.Instance.GetDrop(list);
                EventModule.Instance.SyncData(delegate
                {
                    MMFrame.ShowFrame(FrameData.FrameEnum.GetItemsFrame, new object[] { list });
                });
            }
            else if (index == 2)
            {
                DataModule.Instance.Battery += 3;
                EventModule.Instance.SyncData(null);
            }
            else if (index == 3)
            {
                EventModule.Instance.HandleEvent(EventEnum.LOTTERY);
            }
            else if (index == 6)
            {
                int level = int.Parse(val);
                Dictionary<string, RealHeroData> dict = DataModule.Instance.GetHeroDataDic();
                foreach (var item in dict)
                {
                    item.Value.lv = level;
                }
                DataModule.Instance.SetHeroDataDic(dict);
                EventModule.Instance.SyncData(delegate
                {
                    Debug.Log("设置成功" + level);
                });
            }
            else if (index == 7)
            {
                int star = int.Parse(val);
                Dictionary<string, RealHeroData> dict = DataModule.Instance.GetHeroDataDic();
                foreach (var item in dict)
                {
                    item.Value.star = star;
                }
                DataModule.Instance.SetHeroDataDic(dict);
                EventModule.Instance.SyncData(delegate
                {
                    Debug.Log("设置成功" + star);
                });
            }
            else if (index == 8)
            {
                int mainlv = int.Parse(val);
                DataModule.Instance.MainLv = mainlv;
                EventModule.Instance.SyncData(delegate
                {
                    Debug.Log("设置成功" + mainlv);
                });
            }
        }
    }
}