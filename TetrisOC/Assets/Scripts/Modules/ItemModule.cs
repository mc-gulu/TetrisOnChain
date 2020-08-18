using System.Collections.Generic;
using MMFramework;
using UnityEngine;
using LitJson;
using UnityEngine.UI;
namespace MMGame
{
    public class ItemModule : MonoBehaviour, BaseModule
    {
        public static ItemModule Instance
        {
            get
            {
                return RootModule.Instance.GetModule<ItemModule>();
            }
        }

        public void Init()
        {

        }

        public void GetDrop(int dropID, int index = 0)
        {
            List<ItemObj> list = ItemTools.GetDrops(dropID, index);
            GetDrop(list);
        }

        public void GetDrop(Dictionary<int, int> dict)
        {
            List<ItemObj> list = new List<ItemObj>();
            foreach (var item in dict)
            {
                list.Add(new ItemObj(item.Key, item.Value));
            }
            GetDrop(list);
        }

        public void GetDrop(List<ItemObj> list)
        {
            for (int i = 0; i < list.Count; i++)
            {
                ItemObj item = list[i];
                ItemData.ItemEnum itemenum = ItemTools.GetIDEnum(item.ID);
                Debug.Log("获得" + item.ID + ":" + item.Value);
                switch (itemenum)
                {
                    case ItemData.ItemEnum.Gold:
                        {
                            Debug.Log("获得金币");
                            DataModule.Instance.Gold += item.Value;
                            break;
                        }
                    case ItemData.ItemEnum.Exp:
                        {
                            Debug.Log("获得经验");
                            DataModule.Instance.Exp += item.Value;
                            break;
                        }
                    case ItemData.ItemEnum.Diamond:
                        {
                            Debug.Log("获得钻石");
                            DataModule.Instance.Diamond += item.Value;
                            break;
                        }
                    case ItemData.ItemEnum.Battery:
                        {
                            Debug.Log("获得电池");
                            DataModule.Instance.Battery += item.Value;
                            break;
                        }
                    case ItemData.ItemEnum.Creature:
                        {
                            Debug.Log("获得卡牌");
                            int newID = IDTools.GetNewHeroID();
                            RealHeroData rhd = new RealHeroData();
                            rhd.id = newID;
                            rhd.creatureid = item.ID;
                            rhd.star = item.Value;
                            rhd.lv = 1;
                            DataModule.Instance.Set(string.Format("{0}/{1}", DataModule.Key_HeroDic, newID), rhd);
                            HeroModule.Instance.NewHeroCheck(newID);
                            break;
                        }
                    default:
                        {

                            break;
                        }
                }
            }
        }
    }
}