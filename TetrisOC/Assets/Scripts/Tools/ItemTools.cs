using System.Collections;
using System.Collections.Generic;
using MMFramework;
using UnityEngine;
using System;
namespace MMGame
{
    [Serializable]
    public class ItemObj
    {
        public int ID;
        public int _value;//可以叠加的物品代表数量;卡牌代表星级
        public int Value
        {
            get
            {
                return Convert.ToInt32(_value.ToString());
            }
        }
        public ItemObj()//Json需要默认构造函数
        {

        }
        public ItemObj(int ID, int Value = 0)
        {
            if (!ItemTools.IsFinalID(ID))
            {
                Debug.LogError("创建物品不是最终ID" + ID);
                return;
            }

            if (ItemTools.IsHeroStarID(ID))
            {
                this.ID = ID / 100;
                this._value = ID % 100;
            }
            else
            {
                this.ID = ID;
                this._value = Value;
            }
        }

        public ItemData.ItemEnum ItemType
        {
            get
            {
                return MMGame.ItemTools.GetIDEnum(ID);
            }
        }
    }
    public static class ItemTools
    {
        public const int Item_ItemIndex = 1000;
        public const int Diamond_ItemIndex = 1001;
        public const int Gold_ItemIndex = 1002;
        public const int Exp_ItemIndex = 1003;
        public const int Random_ItemIndex = 1125;
        public const int Index_ItemIndex = 1126;
        public const int Drop_ItemIndex = 1119;
        public const int CreatureStar_ItemIndex = 1101;
        public const int Theme_ItemIndex = 1120;

        public const int ID_Diamond = 2000;
        public const int ID_Gold = 3000;
        // public const int 
        //DropID解析成List<ItemObj>
        public static string IconStr(int itemID)
        {
            return ItemData.GetData(itemID).TextIcon;
        }
        public static List<ItemObj> GetDrops(int dropID, int index = 0)
        {
            DropData dropData = DropData.GetData(dropID);

            List<ItemObj> drops = new List<ItemObj>();
            Queue<KeyValuePair<int, int>> temp = new Queue<KeyValuePair<int, int>>();
            temp.Enqueue(new KeyValuePair<int, int>(dropID, 1));
            while (temp.Count > 0)
            {
                KeyValuePair<int, int> kv = temp.Dequeue();
                int ID = kv.Key;
                int num = kv.Value;
                if (ItemTools.IsRandomID(ID))
                {
                    for (int i = 0; i < num; i++)
                    {
                        RandomData random = RandomData.GetData(ID);
                        int rindex = IDTools.RandPick(random.PArray);
                        int newID = random.IDArray[rindex];
                        temp.Enqueue(new KeyValuePair<int, int>(newID, 1));
                    }
                }
                else if (ItemTools.IsIndexID(ID))
                {
                    for (int i = 0; i < num; i++)
                    {
                        IndexData random = IndexData.GetData(ID);
                        int newID = random.IDArray[index];
                        temp.Enqueue(new KeyValuePair<int, int>(newID, 1));
                    }
                }
                else if (ItemTools.IsDropID(ID))
                {
                    DropData drop = DropData.GetData(ID);
                    for (int i = 0; i < drop.IDArray.Length; i++)
                    {
                        int subID = drop.IDArray[i];
                        int subNum = drop.NumArray[i] * num;
                        if (subID > 0 && subNum > 0)
                            temp.Enqueue(new KeyValuePair<int, int>(subID, subNum));
                    }
                }
                else
                {
                    int typeindex = ItemTools.GetIDType(ID);
                    ItemData item = ItemData.GetData(typeindex);
                    if (item.CanCombine)
                    {
                        drops.Add(new ItemObj(ID, num));
                    }
                    else
                    {
                        for (int i = 0; i < num; i++)
                        {
                            drops.Add(new ItemObj(ID, 1));
                        }
                    }
                }
            }
            return drops;
        }
        public static int GetIDType(int ID)
        {
            List<int> keys = ItemData.GetKeys();
            for (int i = 0; i < keys.Count; i++)
            {
                int key = keys[i];
                ItemData item = ItemData.GetData(key);
                if (!(ID < item.MinID || ID > item.MaxID))
                    return key;
            }
            Debug.LogError("错误物品类型 ID:" + ID);
            return 0;
        }
        public static ItemData.ItemEnum GetIDEnum(int ID)
        {
            List<int> keys = ItemData.GetKeys();
            for (int i = 0; i < keys.Count; i++)
            {
                int key = keys[i];
                ItemData item = ItemData.GetData(key);
                if (!(ID < item.MinID || ID > item.MaxID))
                    return item.ItemType;
            }
            Debug.LogError("错误物品类型 ID:" + ID);
            return ItemData.ItemEnum.None;
        }
        public static string GetItemKeyPath(int itype)
        {
            return ItemData.GetData(itype).KeyPath;
        }
        public static bool IsFinalID(int ID)
        {
            return !(IsRandomID(ID) || IsDropID(ID));
        }
        public static bool IsRandomID(int ID)//是否是 需要随机处理的ID
        {
            ItemData randomitem = ItemData.GetData(Random_ItemIndex);
            return !(ID < randomitem.MinID || ID > randomitem.MaxID);
        }
        public static bool IsIndexID(int ID)//是否是 需要Index处理的ID
        {
            ItemData indexitem = ItemData.GetData(Index_ItemIndex);
            return !(ID < indexitem.MinID || ID > indexitem.MaxID);
        }
        public static bool IsDropID(int ID)//是否是 需要随机处理的ID
        {
            ItemData randomitem = ItemData.GetData(Drop_ItemIndex);
            return !(ID < randomitem.MinID || ID > randomitem.MaxID);
        }
        public static bool IsHeroStarID(int ID)//是否是 卡牌与星级的合成ID
        {
            ItemData randomitem = ItemData.GetData(CreatureStar_ItemIndex);
            return !(ID < randomitem.MinID || ID > randomitem.MaxID);
        }
        public static bool CanCombine(int ID)
        {
            int itemtype = GetIDType(ID);
            return ItemData.GetData(itemtype).CanCombine;
        }
        //去重
        public static void CombineDuplicate(ref List<ItemObj> objs)
        {
            Dictionary<int, int> dict = new Dictionary<int, int>();
            for (int i = objs.Count - 1; i >= 0; i--)
            {
                ItemObj item = objs[i];
                if (CanCombine(item.ID))
                {
                    if (!dict.ContainsKey(item.ID))
                        dict[item.ID] = 0;
                    dict[item.ID] += item.Value;
                    objs.RemoveAt(i);
                }
            }

            foreach (var it in dict)
            {
                ItemObj item = new ItemObj(it.Key, it.Value);
                objs.Add(item);
            }
        }
        public static string ItemTypeToStr(int itemtype)
        {
            return ItemData.GetData(itemtype).TextIcon;
        }
        //List<ItemObj>发放物品
        /*
        public void GetDropItems(List<ItemObj> DropList, CostTool.Reason reason)
        {
            if (DropList != null)
            {
                for (int i = 0; i < DropList.Count; i++)
                {
                    ItemObj item = DropList[i];
                    if (item.itemType.Equals(Item.Diamond))
                    {
                        DataModule.Instance.ChangeDiamond(item.itemValue, reason);
                    }
                    else if (item.itemType.Equals(Item.Gold))
                    {
                        DataModule.Instance.ChangeGold(item.itemValue, reason);
                    }
                    else if (item.itemType.Equals(Item.Exp))
                    {
                        HerosModule hm = RootModule.Instance.GetModule<HerosModule>();
                        int current_heroID = hm.GetCurrentHero();
                        hm.GainExp(current_heroID, item.itemValue);
                    }
                    else if (item.itemType.Equals(Item.WeaponExp))
                    {
                        PlayerModule.Instance.AddPractice(item.itemValue);
                    }
                    else if (item.itemType.Equals(Item.AD))
                    {
                        DataModule.Instance.AdNumber += item.itemValue;
                    }
                    else if (item.itemType >= Item.Crystal0 && item.itemType <= Item.CrystalMax)
                    {
                        int index = item.itemType - Item.Crystal0;
                        int val = DataModule.Instance.GetCrystal(index);
                        DataModule.Instance.SetCrystal(index, val + item.itemValue);
                    }
                    else if (item.itemType.Equals(Item.Red))
                    {
                        DataModule.Instance.Red += item.itemValue;
                    }
                    else if (item.itemType.Equals(Item.PP))
                    {
                        PPModule.Instance.AddOnePP(item.itemValue, true);
                    }
                    else if (item.itemType.Equals(Item.Dice))
                    {
                        DataModule.Instance.Dice += item.itemValue;
                    }
                    else if (item.itemType.Equals(Item.Stone))
                    {
                        DataModule.Instance.Stone += item.itemValue;
                    }
                    else if (item.itemType.Equals(Item.Noad))
                    {
                        DataModule.Instance.Noad += item.itemValue;
                    }
                    else if (item.itemType.Equals(Item.Monthly))
                    {
                        string key = DataModule.DataKey.vipexpire.ToString();
                        ServerModule.Instance.GetValue(key, delegate (bool success, LitJson.JsonData result)
                        {
                            if (!success)
                                return;
                            string valuestr = result["value"].ToString();
                            DataModule.Instance.SetData(key, valuestr);

                            if (DataModule.Instance.VipExpire < (DayModule.Instance.Days - 1))
                            {
                                DataModule.Instance.VipExpire = DayModule.Instance.Days - 1;
                                DataModule.Instance.VipPick = DayModule.Instance.Days - 1;
                            }

                            DataModule.Instance.VipExpire += item.itemValue;

                            NoticeUI.Broadcast(NoticeID.MONTHLY_UPDATE);
                        });
                    }
                    else if (item.itemType.Equals(Item.Weekly))
                    {
                        string key = DataModule.DataKey.weeklyvipexpire.ToString();
                        ServerModule.Instance.GetValue(key, delegate (bool success, LitJson.JsonData result)
                        {
                            if (!success)
                                return;
                            string valuestr = result["value"].ToString();
                            DataModule.Instance.SetData(key, valuestr);

                            if (DataModule.Instance.WeeklyVipExpire < (DayModule.Instance.Days - 1))
                            {
                                DataModule.Instance.WeeklyVipExpire = DayModule.Instance.Days - 1;
                                DataModule.Instance.WeeklyVipPick = DayModule.Instance.Days - 1;
                            }

                            DataModule.Instance.WeeklyVipExpire += item.itemValue;

                            NoticeUI.Broadcast(NoticeID.WEEKLY_UPDATE);
                        });
                    }
                    else if (item.itemType >= Item.Hero0 && item.itemType <= Item.HeroMax)
                    {
                        int index = item.itemType - Item.Hero0;
                        int creatureID = HeroIndexCreatureID.GetData(index).CreatureID;
                        HerosModule.Instance.buy_hero(creatureID);
                    }
                    else if (item.itemType.Equals(Item.Weapon))
                    {
                        int weaponID = item.itemID;
                        RootModule.Instance.GetModule<BagModule>().AddWeaponToBag(weaponID);
                    }
                    else if (item.itemType.Equals(Item.Equip))
                    {
                        int equipID = item.itemID;
                        EquipModule.Instance.Light(equipID);
                    }
                    else if (item.itemType.Equals(Item.Material))
                    {
                        int materialID = item.itemID;
                        RootModule.Instance.GetModule<BagModule>().AddMaterialToBag(materialID, item.itemValue);

                        //记录充能
                        ScrollModule.Instance.ToEnergy(materialID, item.itemValue);
                    }
                    else if (item.itemType.Equals(Item.Scroll))
                    {
                        int scrollID = item.itemID;
                        ScrollModule.Instance.GetScrollPushed(scrollID);
                    }
                    else if (item.itemType.Equals(Item.TalentExp))
                    {
                        int currentheroID = HerosModule.Instance.GetCurrentHero();
                        int oldexp = DataModule.Instance.GetPlayerTalentExp(currentheroID);
                        int newexp = oldexp + item.itemValue;
                        DataModule.Instance.SetPlayerTalentExp(currentheroID, newexp);
                    }
                }
            }
        }
        

        public static void Sort(ref List<ItemObj> objs, bool bigfront = false)
        {
            int k = bigfront ? -1 : 1;
            objs.Sort(delegate (ItemObj obj1, ItemObj obj2)
            {
                int typed = obj1.itemType - obj2.itemType;
                if (typed != 0)
                    return typed * k;
                else
                {
                    if (obj1.itemType == Item.Weapon)
                    {
                        WeaponStruct item1 = RootModule.Instance.GetModule<WeaponModule>().GetWeapon(obj1.itemID);
                        WeaponStruct item2 = RootModule.Instance.GetModule<WeaponModule>().GetWeapon(obj2.itemID);
                        return (item1.quality - item2.quality) * k;
                    }
                    else if (obj1.itemType == Item.Material)
                    {
                        MaterialData md1 = MaterialData.GetData(obj1.itemID);
                        MaterialData md2 = MaterialData.GetData(obj2.itemID);
                        if (md1.Quality - md2.Quality != 0)
                            return (md1.Quality - md2.Quality) * k;
                        else
                            return (md1.MaterialID - md2.MaterialID) * k;
                    }
                    else if (obj1.itemType == Item.Scroll)
                    {
                        Roguelike_ScrollData sd1 = Roguelike_ScrollData.GetData(obj1.itemID);
                        Roguelike_ScrollData sd2 = Roguelike_ScrollData.GetData(obj2.itemID);
                        if (sd1.Quality - sd2.Quality != 0)
                            return (sd1.Quality - sd2.Quality) * k;
                        else
                            return (sd1.ScrollID - sd2.ScrollID) * k;
                    }
                    else
                    { //装备不排序
                        return 0;
                    }
                }
            });
        }

        //拆分成若干份额
        public static Dictionary<int, List<ItemObj>> Part(List<ItemObj> objs, int num)
        {
            Dictionary<int, List<ItemObj>> ret = new Dictionary<int, List<ItemObj>>();
            for (int i = 0; i < objs.Count; i++)
            {
                ItemObj item = objs[i];
                if (Item.NormalType(item.itemType))
                {
                    int val = item.itemValue;
                    int average = val / num;
                    int left = val % num;
                    for (int j = 0; j < num; j++)
                    {
                        int finalval = average;
                        if (j < left)
                            finalval += 1;
                        if (finalval > 0)
                        {
                            if (!ret.ContainsKey(j))
                                ret[j] = new List<ItemObj>();
                            ret[j].Add(new ItemObj(item.itemType, item.itemID, finalval));
                        }
                    }
                }
                else
                {
                    int pos = FrameTools.GetRandomInt(0, num);
                    if (!ret.ContainsKey(pos))
                        ret[pos] = new List<ItemObj>();
                    ret[pos].Add(item);
                }
            }

            return ret;
        }
        //放大
        public static void ScaleGoldDiamondTalentExpDrops(List<ItemObj> drops, float scale)
        {
            for (int i = 0; i < drops.Count; i++)
            {
                ItemObj itemobj = drops[i];
                if (itemobj.itemType.Equals(Item.Diamond) ||
                    itemobj.itemType.Equals(Item.Gold) ||
                    itemobj.itemType.Equals(Item.TalentExp))
                {
                    itemobj.itemValue = Mathf.CeilToInt(itemobj.itemValue * scale);
                }
            }
        }

        //分离
        public static List<ItemObj> SplitItems(List<ItemObj> items, params int[] itemtype)
        {
            List<ItemObj> ret = new List<ItemObj>();
            if (items != null)
                for (int i = 0; i < items.Count; i++)
                {
                    for (int j = 0; j < itemtype.Length; j++)
                    {
                        if (items[i].itemType.Equals(itemtype[j]))
                        {
                            ret.Add(items[i]);
                            break;
                        }
                    }
                }
            return ret;
        }

        //挑出
        public static ItemObj PopType(ref List<ItemObj> list, int itemtype)
        {
            ItemObj item = null;

            for (int i = (list.Count - 1); i >= 0; i--)
            {
                if (list[i].itemType.Equals(itemtype))
                {
                    if (item == null)
                        item = list[i];
                    else
                        item.itemValue += list[i].itemValue;
                    list.RemoveAt(i);
                }
            }
            if (item == null)
                item = new ItemObj(itemtype, 0, 0);
            return item;
        }*/
    }
}