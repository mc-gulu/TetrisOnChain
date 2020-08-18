using System;
using System.Collections.Generic;
using UnityEngine;
[Serializable]
public class ItemData{
public enum ItemEnum{
None,
Item,
Diamond,
Gold,
Exp,
Battery,
Creature,
CreatureStar,
PhysicGroup,
PhysicStar,
Physic,
Skill,
Fire,
SkillCondition,
SingleCondition,
AttachBuff,
Buff,
Genus,
Attribute,
Display,
Bullet,
Element,
Levelup,
Starup,
Cost,
Drop,
Theme,
Map,
Floor,
RoomTag,
TextStyle,
Random,
Index,
Color,
Lottery,
}
/// <summary>
/// 物品类型
/// </summary>
public int typeID;
/// <summary>
/// 物品名字
/// </summary>
public string Name;
/// <summary>
/// 枚举名
/// </summary>
public ItemEnum ItemType;
/// <summary>
/// 最小ID
/// </summary>
public int MinID;
/// <summary>
/// 最大ID
/// </summary>
public int MaxID;
/// <summary>
/// 是否可以叠加
/// </summary>
public bool CanCombine;
/// <summary>
/// 物品描述
/// </summary>
public string Info;
/// <summary>
/// 大图
/// </summary>
public string[] IconArray;
/// <summary>
/// 文本形式
/// </summary>
public int TextStyle;
/// <summary>
/// 文字颜色
/// </summary>
public int TextColor;
/// <summary>
/// 文字图标
/// </summary>
public string TextIcon;
/// <summary>
/// 数据位置
/// </summary>
public string KeyPath;
/// <summary>
/// 描述
/// </summary>
public string Desc;
public ItemData(int typeID, string Name, ItemEnum ItemType, int MinID, int MaxID, bool CanCombine, string Info, string[] IconArray, int TextStyle, int TextColor, string TextIcon, string KeyPath, string Desc){
this.typeID = typeID;
this.Name = Name;
this.ItemType = ItemType;
this.MinID = MinID;
this.MaxID = MaxID;
this.CanCombine = CanCombine;
this.Info = Info;
this.IconArray = IconArray;
this.TextStyle = TextStyle;
this.TextColor = TextColor;
this.TextIcon = TextIcon;
this.KeyPath = KeyPath;
this.Desc = Desc;
}
class ItemDataReader{
static ItemDataReader instance;
static object syncRoot = new object();
public static ItemDataReader Instance{get{if (instance == null){lock (syncRoot){if (instance == null){instance = new ItemDataReader();instance.Load();}}}return instance;}}
Dictionary<int, ItemData> root = new Dictionary<int, ItemData>();
void Load(){
root.Add(1000, new ItemData(1000, "物品名字", ItemEnum.Item, 1000, 1999, false, "", new string[] {"", ""}, 0, 0, "", "", ""));
root.Add(1001, new ItemData(1001, "钻石", ItemEnum.Diamond, 2000, 2000, true, "info_diamond", new string[] {"Images/UI_icon_610/UI_icon_610_1", "Images/UI_icon_610/UI_icon_610_1"}, 6, 8, "@", "Idiamond", "充值才能获得"));
root.Add(1002, new ItemData(1002, "金币", ItemEnum.Gold, 3000, 3000, true, "info_gold_coin", new string[] {"Images/UI_icon_610/UI_icon_610_0", "Images/UI_icon_610/UI_icon_610_0"}, 5, 7, "!", "Igold", "挖矿产出"));
root.Add(1003, new ItemData(1003, "经验", ItemEnum.Exp, 4000, 4000, true, "info_exp", new string[] {"Images/UI_icon_610/UI_icon_610_2", "Images/UI_icon_610/UI_icon_610_2"}, 0, 0, "^", "Iexp", "升级需要"));
root.Add(1004, new ItemData(1004, "电池", ItemEnum.Battery, 5000, 5000, true, "", new string[] {"Images/UI_cut_520/UI_cut_520_5", "Images/UI_cut_520/UI_cut_520_5"}, 0, 7, "#", "Ibattery", "一节电池，增加矿机动力"));
root.Add(1005, new ItemData(1005, "角色", ItemEnum.Creature, 6000, 6999, true, "info_battery", new string[] {"", ""}, 0, 0, "", "", ""));
root.Add(1101, new ItemData(1101, "角色带星ID", ItemEnum.CreatureStar, 600000, 699999, false, "", new string[] {"", ""}, 0, 0, "", "", ""));
root.Add(1102, new ItemData(1102, "PhysicsGroup", ItemEnum.PhysicGroup, 7000, 7999, false, "", new string[] {"", ""}, 0, 0, "", "", ""));
root.Add(1103, new ItemData(1103, "Physics", ItemEnum.PhysicStar, 700000, 799999, false, "", new string[] {"", ""}, 0, 0, "", "", ""));
root.Add(1104, new ItemData(1104, "SkillGroup", ItemEnum.Physic, 8000, 8999, false, "", new string[] {"", ""}, 0, 0, "", "", ""));
root.Add(1105, new ItemData(1105, "SkillID", ItemEnum.Skill, 800000, 899999, false, "", new string[] {"", ""}, 0, 0, "", "", ""));
root.Add(1106, new ItemData(1106, "FireID", ItemEnum.Fire, 9000, 9999, false, "", new string[] {"", ""}, 0, 0, "", "", ""));
root.Add(1107, new ItemData(1107, "SkillConditionID", ItemEnum.SkillCondition, 10000, 10999, false, "", new string[] {"", ""}, 0, 0, "", "", ""));
root.Add(1108, new ItemData(1108, "SingleConditionID", ItemEnum.SingleCondition, 11000, 11999, false, "", new string[] {"", ""}, 0, 0, "", "", ""));
root.Add(1109, new ItemData(1109, "AttachBuff", ItemEnum.AttachBuff, 12000, 12999, false, "", new string[] {"", ""}, 0, 0, "", "", ""));
root.Add(1110, new ItemData(1110, "BuffID", ItemEnum.Buff, 13000, 13999, false, "", new string[] {"", ""}, 0, 0, "", "", ""));
root.Add(1111, new ItemData(1111, "GenusID", ItemEnum.Genus, 14000, 14999, false, "", new string[] {"", ""}, 0, 0, "", "", ""));
root.Add(1112, new ItemData(1112, "Attribute", ItemEnum.Attribute, 15000, 19999, false, "", new string[] {"", ""}, 0, 0, "", "", ""));
root.Add(1113, new ItemData(1113, "DisplayID", ItemEnum.Display, 20000, 20999, false, "", new string[] {"", ""}, 0, 0, "", "", ""));
root.Add(1114, new ItemData(1114, "BulletID", ItemEnum.Bullet, 21000, 22999, false, "", new string[] {"", ""}, 0, 0, "", "", ""));
root.Add(1115, new ItemData(1115, "ElementID", ItemEnum.Element, 23000, 23999, false, "", new string[] {"", ""}, 0, 0, "", "", ""));
root.Add(1116, new ItemData(1116, "LevelupCostID", ItemEnum.Levelup, 24000, 24999, false, "", new string[] {"", ""}, 0, 0, "", "", ""));
root.Add(1117, new ItemData(1117, "StarupCost", ItemEnum.Starup, 25000, 26999, false, "", new string[] {"", ""}, 0, 0, "", "", ""));
root.Add(1118, new ItemData(1118, "CostID", ItemEnum.Cost, 27000, 29999, false, "", new string[] {"", ""}, 0, 0, "", "", ""));
root.Add(1119, new ItemData(1119, "掉落ID", ItemEnum.Drop, 30000, 32999, false, "", new string[] {"", ""}, 0, 0, "", "", ""));
root.Add(1120, new ItemData(1120, "ThemeID", ItemEnum.Theme, 33000, 33999, false, "", new string[] {"", ""}, 0, 0, "", "", ""));
root.Add(1121, new ItemData(1121, "mapID", ItemEnum.Map, 34000, 34999, false, "", new string[] {"", ""}, 0, 0, "", "", ""));
root.Add(1122, new ItemData(1122, "FloorFightID", ItemEnum.Floor, 35000, 36999, false, "", new string[] {"", ""}, 0, 0, "", "", ""));
root.Add(1123, new ItemData(1123, "roomTag", ItemEnum.RoomTag, 37000, 39999, false, "", new string[] {"", ""}, 0, 0, "", "", ""));
root.Add(1124, new ItemData(1124, "StyleID", ItemEnum.TextStyle, 40000, 40999, false, "", new string[] {"", ""}, 0, 0, "", "", ""));
root.Add(1125, new ItemData(1125, "随机ID", ItemEnum.Random, 41000, 43999, false, "", new string[] {"", ""}, 0, 0, "", "", ""));
root.Add(1126, new ItemData(1126, "IndexID", ItemEnum.Index, 44000, 46999, false, "", new string[] {"", ""}, 0, 0, "", "", ""));
root.Add(1127, new ItemData(1127, "ColorID", ItemEnum.Color, 47000, 47999, false, "", new string[] {"", ""}, 0, 0, "", "", ""));
root.Add(1128, new ItemData(1128, "LotteryID", ItemEnum.Lottery, 48000, 48999, false, "", new string[] {"", ""}, 0, 0, "", "", ""));
}
public ItemData GetReadData(int ID){
if (root.ContainsKey(ID))
return root[ID];
else{
object obj = MMFramework.ModifyExcelModule.Instance.GetModifyedData(ID);
if (obj != null)return obj as ItemData;
Debug.LogError("在表格 ItemData中没有找到ID" + ID);
return null;}
}
public void WriteToFile(string path){}
public int GetCount(){
return root.Count;
}
public List<int> GetDataKeys(){
return new List<int>(root.Keys);
}
public Dictionary<string, string> GetReadDictionary(int key)
{Dictionary<string, string> pairs = new Dictionary<string, string>();
ItemData data = GetReadData(key);
Type type = data.GetType();
System.Reflection.FieldInfo[] filedinfos = type.GetFields();
for (int i = 0; i < filedinfos.Length; i++)
{System.Reflection.FieldInfo field = filedinfos[i];
pairs.Add(field.Name, field.GetValue(data).ToString());}
return pairs;}
}
public static ItemData GetData(int ID){
return ItemDataReader.Instance.GetReadData(ID);
}
public static Dictionary<string, string> GetDictionary(int key)
{ return ItemDataReader.Instance.GetReadDictionary(key);}
public static int GetNum(){
return ItemDataReader.Instance.GetCount();
}
public static List<int> GetKeys(){
return ItemDataReader.Instance.GetDataKeys();
}
public static void SaveToFile(string path){
ItemDataReader.Instance.WriteToFile(path);
}

}