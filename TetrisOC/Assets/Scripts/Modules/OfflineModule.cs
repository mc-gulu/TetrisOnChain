using System.Collections.Generic;
using MMFramework;
using UnityEngine;
using LitJson;
using UnityEngine.UI;
namespace MMGame
{
    public class OfflineModule : MonoBehaviour, BaseModule
    {
        public static OfflineModule Instance
        {
            get
            {
                return RootModule.Instance.GetModule<OfflineModule>();
            }
        }

        public void Init()
        {

        }

        public bool HaveOffline
        {
            get
            {
                List<ItemObj> list = DataModule.Instance.OfflineItems;
                return list.Count > 0;
            }
        }

        public List<ItemObj> OfflineItems()
        {
            return DataModule.Instance.OfflineItems;
        }

        public string OfflineTime()
        {
            long time_milli_second = DataModule.Instance.Get<long>(DataModule.Key_OfflineTime, 0L);
            return TimeTools.ShortTime(time_milli_second, false);
        }

        public void AddOfflineItems(List<ItemObj> items)
        {
            List<ItemObj> itemlist = new List<ItemObj>(items);
            itemlist.AddRange(DataModule.Instance.OfflineItems);
            ItemTools.CombineDuplicate(ref itemlist);
            DataModule.Instance.OfflineItems = itemlist;
        }

        public List<ItemObj> Harvest()
        {
            //离线加到存储
            ItemModule.Instance.GetDrop(DataModule.Instance.OfflineItems);
            List<ItemObj> list = DataModule.Instance.OfflineItems;
            //删除离线
            DataModule.Instance.OfflineItems = new List<ItemObj>();

            DataModule.Instance.Set<long>(DataModule.Key_OfflineTime, 0L);
            return list;
        }
    }
}