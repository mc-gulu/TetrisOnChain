using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using MMFramework;
namespace MMGame
{
    public static class CostTool
    {
        public const int NOT_ENOUGH_INDEX = 6;
        public static string CostString(int CostID)
        {
            if (CostID <= 0) return string.Empty;
            Dictionary<int, int> costdict = CostConvert(CostID);
            return CostString(costdict);
        }

        public static string CostString(Dictionary<int, int> costdict)
        {
            //显示一行，不够的变红
            StringBuilder builder = new StringBuilder();

            foreach (var item in costdict)
            {
                int ID = item.Key;
                int costvalue = item.Value;
                if (ID > 0 && costvalue > 0)
                {
                    int itemtype = ItemTools.GetIDType(ID);
                    string unit = ItemTools.ItemTypeToStr(itemtype);
                    string keypath = ItemTools.GetItemKeyPath(itemtype);
                    builder.Append(unit);

                    ItemData.ItemEnum itemenum = ItemData.GetData(itemtype).ItemType;
                    if (itemenum.Equals(ItemData.ItemEnum.Gold))
                    {
                        if (costvalue > DataModule.Instance.Gold)
                        {
                            string textcolorcode = ColorData.GetData(NOT_ENOUGH_INDEX).ColorTextCode;
                            builder.AppendFormat(textcolorcode, costvalue);
                        }
                        else
                        {
                            builder.Append(costvalue);
                        }
                    }
                    else if (itemenum.Equals(ItemData.ItemEnum.Exp))
                    {
                        if (costvalue > DataModule.Instance.Exp)
                        {
                            string textcolorcode = ColorData.GetData(NOT_ENOUGH_INDEX).ColorTextCode;
                            builder.AppendFormat(textcolorcode, costvalue);
                        }
                        else
                        {
                            builder.Append(costvalue);
                        }
                    }
                    else if (!string.IsNullOrEmpty(keypath))
                    {
                        if (costvalue > DataModule.Instance.Get(keypath, 0))
                        {
                            string textcolorcode = ColorData.GetData(NOT_ENOUGH_INDEX).ColorTextCode;
                            builder.AppendFormat(textcolorcode, costvalue);
                        }
                        else
                        {
                            builder.Append(costvalue);
                        }
                    }
                    else
                    {
                        Debug.LogError("未定义KeyPath");
                    }
                }
            }
            return builder.ToString();
        }
        public static bool CostCanAfford(int CostID, ref string tips)
        {
            if (CostID <= 0) return false;
            Dictionary<int, int> costdict = CostConvert(CostID);
            return CostCanAfford(costdict, ref tips);
        }

        public static bool CostCanAfford(List<int> CostIDs, ref string tips)
        {
            if (CostIDs.Count == 0)
                return false;
            Dictionary<int, int> costdict = new Dictionary<int, int>();
            for (int i = 0; i < CostIDs.Count; i++)
            {
                Dictionary<int, int> tmpcostdict = CostConvert(CostIDs[i]);
                foreach (var item in tmpcostdict)
                {
                    if (!costdict.ContainsKey(item.Key))
                        costdict.Add(item.Key, item.Value);
                    else
                        costdict[item.Key] += item.Value;
                }
            }
            return CostCanAfford(costdict, ref tips);
        }

        public static bool CostCanAfford(Dictionary<int, int> costdict, ref string tips)
        {
            //检查所有，返回是否
            foreach (var item in costdict)
            {
                int ID = item.Key;
                int costvalue = item.Value;
                if (ID > 0 && costvalue > 0)
                {
                    int itemtype = ItemTools.GetIDType(ID);
                    string keypath = ItemTools.GetItemKeyPath(itemtype);
                    ItemData.ItemEnum itemenum = ItemData.GetData(itemtype).ItemType;
                    if (itemenum.Equals(ItemData.ItemEnum.Gold))
                    {
                        if (costvalue > DataModule.Instance.Gold)
                        {
                            string str1 = LocalModule.Instance.GetValue(StringConfig.Tips_Text_NoResources);
                            string str2 = LocalModule.Instance.GetValue(ItemData.GetData(itemtype).Name);
                            tips = string.Format(str1, str2); return false;
                        }
                    }
                    else if (itemenum.Equals(ItemData.ItemEnum.Exp))
                    {
                        if (costvalue > DataModule.Instance.Exp)
                        {
                            string str1 = LocalModule.Instance.GetValue(StringConfig.Tips_Text_NoResources);
                            string str2 = LocalModule.Instance.GetValue(ItemData.GetData(itemtype).Name);
                            tips = string.Format(str1, str2); return false;
                        }
                    }
                    else if (!string.IsNullOrEmpty(keypath))
                    {
                        if (costvalue > DataModule.Instance.Get(keypath, 0))
                        {
                            string str1 = LocalModule.Instance.GetValue(StringConfig.Tips_Text_NoResources);
                            string str2 = LocalModule.Instance.GetValue(ItemData.GetData(itemtype).Name);
                            tips = string.Format(str1, str2); return false;
                        }
                    }
                }
            }
            tips = string.Empty;
            return true;
        }

        public static void PayCost(int CostID)
        {
            if (CostID <= 0) return;
            Dictionary<int, int> costdict = CostConvert(CostID);
            PayCost(costdict);
        }
        public static void PayCost(Dictionary<int, int> costdict)
        {
            //花掉
            string text = string.Empty;
            if (CostCanAfford(costdict, ref text))
            {
                foreach (var item in costdict)
                {
                    int ID = item.Key;
                    int costvalue = item.Value;
                    if (ID > 0 && costvalue > 0)
                    {
                        ItemData.ItemEnum itemenum = ItemTools.GetIDEnum(ID);
                        if (itemenum.Equals(ItemData.ItemEnum.Gold))
                        {
                            DataModule.Instance.Gold -= costvalue;
                        }
                        else if (itemenum.Equals(ItemData.ItemEnum.Exp))
                        {
                            DataModule.Instance.Exp -= costvalue;
                        }
                        else if (itemenum.Equals(ItemData.ItemEnum.Diamond))
                        {
                            DataModule.Instance.Diamond -= costvalue;
                        }
                        else
                        {
                            int itemtype = ItemTools.GetIDType(ID);
                            string keypath = ItemTools.GetItemKeyPath(itemtype);
                            int value = DataModule.Instance.Get(keypath, 0);
                            value -= costvalue;
                            DataModule.Instance.Set(keypath, value);
                        }
                    }
                }
            }
            else
            {
                Debug.LogError("PayCost支付不起");
            }
        }

        public static Dictionary<int, int> CostConvert(int CostID)
        {
            Dictionary<int, int> costdict = new Dictionary<int, int>();
            CostData costdata = CostData.GetData(CostID);
            for (int i = 0; i < costdata.IDArray.Length; i++)
            {
                int ID = costdata.IDArray[i];
                int num = costdata.NumArray[i];
                if (CostID > 0 && num > 0)
                {
                    if (!costdict.ContainsKey(ID))
                        costdict[ID] = 0;
                    costdict[ID] += num;
                }
            }
            return costdict;
        }
    }
}