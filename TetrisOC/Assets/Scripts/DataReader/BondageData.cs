using System;
using System.Collections.Generic;
using UnityEngine;
[Serializable]
public class BondageData{
/// <summary>
/// 套装ID
/// </summary>
public int BondageID;
/// <summary>
/// 套装名
/// </summary>
public string Name;
/// <summary>
/// 图标
/// </summary>
public string Icon;
/// <summary>
/// 2套属性条1
/// </summary>
public int[] E2BuffArray;
/// <summary>
/// 3套属性条1
/// </summary>
public int[] E3BuffArray;
/// <summary>
/// 4套属性条1
/// </summary>
public int[] E4BuffArray;
/// <summary>
/// 是否在角色页面显示
/// </summary>
public bool ShowDesc;
/// <summary>
/// 2套开始点亮描述
/// </summary>
public string[] DescArray;
/// <summary>
/// 详情显示图片路径
/// </summary>
public string[] IconPathArray;
/// <summary>
/// 2个bondage
/// </summary>
public int[] BondageArray;
public BondageData(int BondageID, string Name, string Icon, int[] E2BuffArray, int[] E3BuffArray, int[] E4BuffArray, bool ShowDesc, string[] DescArray, string[] IconPathArray, int[] BondageArray){
this.BondageID = BondageID;
this.Name = Name;
this.Icon = Icon;
this.E2BuffArray = E2BuffArray;
this.E3BuffArray = E3BuffArray;
this.E4BuffArray = E4BuffArray;
this.ShowDesc = ShowDesc;
this.DescArray = DescArray;
this.IconPathArray = IconPathArray;
this.BondageArray = BondageArray;
}
class BondageDataReader{
static BondageDataReader instance;
static object syncRoot = new object();
public static BondageDataReader Instance{get{if (instance == null){lock (syncRoot){if (instance == null){instance = new BondageDataReader();instance.Load();}}}return instance;}}
Dictionary<int, BondageData> root = new Dictionary<int, BondageData>();
void Load(){
root.Add(10011, new BondageData(10011, "烈火白", "", new int[] {1043, 0, 0}, new int[] {0, 0, 0}, new int[] {1042, 0, 0}, false, new string[] {"2火系", "3火系", "4火系", ""}, new string[] {"", "", "", ""}, new int[] {2001, 0, 0}));
root.Add(10012, new BondageData(10012, "烈火绿", "", new int[] {1043, 0, 0}, new int[] {0, 0, 0}, new int[] {1043, 0, 0}, false, new string[] {"2火系", "3火系", "4火系", ""}, new string[] {"", "", "", ""}, new int[] {2001, 0, 0}));
root.Add(10013, new BondageData(10013, "烈火蓝", "", new int[] {1043, 0, 0}, new int[] {0, 0, 0}, new int[] {1044, 0, 0}, false, new string[] {"2火系", "3火系", "4火系", ""}, new string[] {"", "", "", ""}, new int[] {2001, 0, 0}));
root.Add(10014, new BondageData(10014, "烈火紫", "", new int[] {1043, 0, 0}, new int[] {0, 0, 0}, new int[] {1045, 0, 0}, false, new string[] {"2火系", "3火系", "4火系", ""}, new string[] {"", "", "", ""}, new int[] {2001, 0, 0}));
root.Add(10015, new BondageData(10015, "烈火橙", "", new int[] {1043, 0, 0}, new int[] {0, 0, 0}, new int[] {1046, 0, 0}, false, new string[] {"2火系", "3火系", "4火系", ""}, new string[] {"", "", "", ""}, new int[] {2001, 0, 0}));
root.Add(10031, new BondageData(10031, "激水白", "", new int[] {1044, 0, 0}, new int[] {0, 0, 0}, new int[] {0, 0, 0}, false, new string[] {"2水系", "3水系", "4水系", ""}, new string[] {"", "", "", ""}, new int[] {2001, 0, 0}));
root.Add(10032, new BondageData(10032, "激水绿", "", new int[] {1044, 0, 0}, new int[] {0, 0, 0}, new int[] {0, 0, 0}, false, new string[] {"2水系", "3水系", "4水系", ""}, new string[] {"", "", "", ""}, new int[] {2001, 0, 0}));
root.Add(10033, new BondageData(10033, "激水蓝", "", new int[] {1044, 0, 0}, new int[] {0, 0, 0}, new int[] {0, 0, 0}, false, new string[] {"2水系", "3水系", "4水系", ""}, new string[] {"", "", "", ""}, new int[] {2001, 0, 0}));
root.Add(10034, new BondageData(10034, "激水紫", "", new int[] {1044, 0, 0}, new int[] {0, 0, 0}, new int[] {0, 0, 0}, false, new string[] {"2水系", "3水系", "4水系", ""}, new string[] {"", "", "", ""}, new int[] {2001, 0, 0}));
root.Add(10035, new BondageData(10035, "激水橙", "", new int[] {1044, 0, 0}, new int[] {0, 0, 0}, new int[] {0, 0, 0}, false, new string[] {"2水系", "3水系", "4水系", ""}, new string[] {"", "", "", ""}, new int[] {2001, 0, 0}));
root.Add(20011, new BondageData(20011, "能量充盈白", "", new int[] {1045, 0, 0}, new int[] {0, 0, 0}, new int[] {0, 0, 0}, false, new string[] {"2水系2火系", "", "", ""}, new string[] {"", "", "", ""}, new int[] {0, 0, 0}));
root.Add(20012, new BondageData(20012, "能量充盈绿", "", new int[] {1045, 0, 0}, new int[] {0, 0, 0}, new int[] {0, 0, 0}, false, new string[] {"2水系2火系", "", "", ""}, new string[] {"", "", "", ""}, new int[] {0, 0, 0}));
root.Add(20013, new BondageData(20013, "能量充盈蓝", "", new int[] {1045, 0, 0}, new int[] {0, 0, 0}, new int[] {0, 0, 0}, false, new string[] {"2水系2火系", "", "", ""}, new string[] {"", "", "", ""}, new int[] {0, 0, 0}));
root.Add(20014, new BondageData(20014, "能量充盈紫", "", new int[] {1045, 0, 0}, new int[] {0, 0, 0}, new int[] {0, 0, 0}, false, new string[] {"2水系2火系", "", "", ""}, new string[] {"", "", "", ""}, new int[] {0, 0, 0}));
root.Add(20015, new BondageData(20015, "能量充盈橙", "", new int[] {1045, 0, 0}, new int[] {0, 0, 0}, new int[] {0, 0, 0}, false, new string[] {"2水系2火系", "", "", ""}, new string[] {"", "", "", ""}, new int[] {0, 0, 0}));
root.Add(30011, new BondageData(30011, "酒友白", "", new int[] {1046, 0, 0}, new int[] {0, 0, 0}, new int[] {0, 0, 0}, true, new string[] {"", "", "", "所有羁绊角色增加2闪避\n羁绊角色：\n1\n2\n3"}, new string[] {"", "", "", ""}, new int[] {0, 0, 0}));
root.Add(30012, new BondageData(30012, "酒友绿", "", new int[] {1046, 0, 0}, new int[] {0, 0, 0}, new int[] {0, 0, 0}, true, new string[] {"", "", "", "所有羁绊角色增加2闪避\n羁绊角色：\n1\n2\n3"}, new string[] {"", "", "", ""}, new int[] {0, 0, 0}));
root.Add(30013, new BondageData(30013, "酒友蓝", "", new int[] {1046, 0, 0}, new int[] {0, 0, 0}, new int[] {0, 0, 0}, true, new string[] {"", "", "", "所有羁绊角色增加2闪避\n羁绊角色：\n1\n2\n3"}, new string[] {"", "", "", ""}, new int[] {0, 0, 0}));
root.Add(30014, new BondageData(30014, "酒友紫", "", new int[] {1046, 0, 0}, new int[] {0, 0, 0}, new int[] {0, 0, 0}, true, new string[] {"", "", "", "所有羁绊角色增加2闪避\n羁绊角色：\n1\n2\n3"}, new string[] {"", "", "", ""}, new int[] {0, 0, 0}));
root.Add(30015, new BondageData(30015, "酒友橙", "", new int[] {1046, 0, 0}, new int[] {0, 0, 0}, new int[] {0, 0, 0}, false, new string[] {"", "", "", "所有羁绊角色增加2闪避\n羁绊角色：\n1\n2\n3"}, new string[] {"", "", "", ""}, new int[] {0, 0, 0}));
}
public BondageData GetReadData(int ID){
if (root.ContainsKey(ID))
return root[ID];
else{
object obj = MMFramework.ModifyExcelModule.Instance.GetModifyedData(ID);
if (obj != null)return obj as BondageData;
Debug.LogError("在表格 BondageData中没有找到ID" + ID);
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
BondageData data = GetReadData(key);
Type type = data.GetType();
System.Reflection.FieldInfo[] filedinfos = type.GetFields();
for (int i = 0; i < filedinfos.Length; i++)
{System.Reflection.FieldInfo field = filedinfos[i];
pairs.Add(field.Name, field.GetValue(data).ToString());}
return pairs;}
}
public static BondageData GetData(int ID){
return BondageDataReader.Instance.GetReadData(ID);
}
public static Dictionary<string, string> GetDictionary(int key)
{ return BondageDataReader.Instance.GetReadDictionary(key);}
public static int GetNum(){
return BondageDataReader.Instance.GetCount();
}
public static List<int> GetKeys(){
return BondageDataReader.Instance.GetDataKeys();
}
public static void SaveToFile(string path){
BondageDataReader.Instance.WriteToFile(path);
}

}