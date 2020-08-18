using System;
using System.Collections.Generic;
using UnityEngine;
[Serializable]
public class BuffData{
/// <summary>
/// 序号
/// </summary>
public int buffID;
/// <summary>
/// 名字（要写进去language）
/// </summary>
public string Name;
/// <summary>
/// 持续特效显示ID
/// </summary>
public int DisplayID;
/// <summary>
/// 触发瞬间特效和飘字
/// </summary>
public int ActiveDisplayID;
/// <summary>
/// 生效次数
/// </summary>
public int ActiveTime;
/// <summary>
/// 生效间隔(秒
/// </summary>
public float ActiveInterval;
/// <summary>
/// 最多叠加次数（只限独立堆叠）
/// </summary>
public int MaxNum;
/// <summary>
/// 是否是永久
/// </summary>
public bool IsForever;
/// <summary>
/// 堆叠方式 0独立单独算时间,1时间重置更新,2次数重置更新
/// </summary>
public int MultiType;
/// <summary>
/// 激发技能
/// </summary>
public int ActiveSkillId;
/// <summary>
/// 安全[激发效果]每次回血+/扣血-
/// </summary>
public float SafeChangeHp;
/// <summary>
/// 不安全[激发效果]每次回血+/扣血-
/// </summary>
public float UnsafeChangeHp;
/// <summary>
/// 激发百分比回血
/// </summary>
public float ChangeHpByMax;
/// <summary>
/// 
/// </summary>
public int[] AttrArray;
/// <summary>
/// 描述
/// </summary>
public string Desc;
/// <summary>
/// icon路径
/// </summary>
public string Icon;
public BuffData(int buffID, string Name, int DisplayID, int ActiveDisplayID, int ActiveTime, float ActiveInterval, int MaxNum, bool IsForever, int MultiType, int ActiveSkillId, float SafeChangeHp, float UnsafeChangeHp, float ChangeHpByMax, int[] AttrArray, string Desc, string Icon){
this.buffID = buffID;
this.Name = Name;
this.DisplayID = DisplayID;
this.ActiveDisplayID = ActiveDisplayID;
this.ActiveTime = ActiveTime;
this.ActiveInterval = ActiveInterval;
this.MaxNum = MaxNum;
this.IsForever = IsForever;
this.MultiType = MultiType;
this.ActiveSkillId = ActiveSkillId;
this.SafeChangeHp = SafeChangeHp;
this.UnsafeChangeHp = UnsafeChangeHp;
this.ChangeHpByMax = ChangeHpByMax;
this.AttrArray = AttrArray;
this.Desc = Desc;
this.Icon = Icon;
}
class BuffDataReader{
static BuffDataReader instance;
static object syncRoot = new object();
public static BuffDataReader Instance{get{if (instance == null){lock (syncRoot){if (instance == null){instance = new BuffDataReader();instance.Load();}}}return instance;}}
Dictionary<int, BuffData> root = new Dictionary<int, BuffData>();
void Load(){
root.Add(1001, new BuffData(1001, "buff1001", 51, 0, 1, 5f, 1, false, 1, 0, 0f, 0f, 0f, new int[] {3, 0, 0, 0, 0, 0, 0}, "", ""));
root.Add(1002, new BuffData(1002, "buff1002", 0, 4, 1, 1f, 4, false, 0, 0, 0f, 0f, 0.1f, new int[] {0, 0, 0, 0, 0, 0, 0}, "", ""));
root.Add(1003, new BuffData(1003, "buff1003", 0, 0, 0, 0f, 0, false, 0, 0, 0f, 0f, 0f, new int[] {0, 0, 0, 0, 0, 0, 0}, "", ""));
root.Add(1004, new BuffData(1004, "buff1004", 0, 0, 10, 1f, 0, false, 1, 0, 0f, 0f, -0.01f, new int[] {0, 0, 0, 0, 0, 0, 0}, "", ""));
root.Add(1005, new BuffData(1005, "buff1005", 0, 0, 0, 0f, 0, false, 0, 0, 0f, 0f, 0f, new int[] {0, 0, 0, 0, 0, 0, 0}, "", ""));
root.Add(1006, new BuffData(1006, "buff1006", 0, 0, 0, 0f, 0, false, 0, 0, 0f, 0f, 0f, new int[] {0, 0, 0, 0, 0, 0, 0}, "", ""));
root.Add(1007, new BuffData(1007, "buff1007", 0, 0, 0, 0f, 0, false, 0, 0, 0f, 0f, 0f, new int[] {0, 0, 0, 0, 0, 0, 0}, "", ""));
root.Add(1008, new BuffData(1008, "buff1008", 0, 0, 0, 0f, 0, false, 0, 0, 0f, 0f, 0f, new int[] {0, 0, 0, 0, 0, 0, 0}, "", ""));
root.Add(1009, new BuffData(1009, "buff1009", 0, 0, 0, 0f, 0, false, 0, 0, 0f, 0f, 0f, new int[] {0, 0, 0, 0, 0, 0, 0}, "", ""));
root.Add(1010, new BuffData(1010, "buff1010", 7, 0, 1, 10f, 0, false, 1, 0, 0f, 0f, 0f, new int[] {4, 0, 0, 0, 0, 0, 0}, "", ""));
root.Add(1011, new BuffData(1011, "buff1011", 5, 0, 1, 10f, 0, false, 1, 0, 0f, 0f, 0f, new int[] {0, 0, 0, 0, 0, 0, 0}, "", ""));
root.Add(1012, new BuffData(1012, "buff1012", 0, 8, 1, 1f, 0, false, 1, 0, 0f, 0f, 0f, new int[] {0, 0, 0, 0, 0, 0, 0}, "", ""));
root.Add(1013, new BuffData(1013, "buff1013", 0, 52, 1, 5f, 0, false, 1, 0, 0f, 0f, 0f, new int[] {6, 0, 0, 0, 0, 0, 0}, "", ""));
root.Add(1014, new BuffData(1014, "buff1014", 5, 0, 0, 0f, 0, false, 1, 0, 0f, 0f, 0f, new int[] {7, 0, 0, 0, 0, 0, 0}, "", ""));
root.Add(1015, new BuffData(1015, "buff1015", 0, 54, 1, 1f, 0, false, 1, 0, 0f, 0f, 0f, new int[] {0, 0, 0, 0, 0, 0, 0}, "", ""));
root.Add(1016, new BuffData(1016, "buff1016", 0, 0, 0, 0f, 0, false, 1, 0, 0f, 0f, 0f, new int[] {0, 0, 0, 0, 0, 0, 0}, "", ""));
root.Add(1017, new BuffData(1017, "buff1017", 0, 4, 1, 1f, 1, false, 1, 0, 0f, 0f, 0.2f, new int[] {0, 0, 0, 0, 0, 0, 0}, "", ""));
root.Add(1018, new BuffData(1018, "buff1018", 66, 0, 1, 10f, 1, false, 1, 0, 0f, 0f, 0f, new int[] {20, 0, 0, 0, 0, 0, 0}, "", ""));
root.Add(1019, new BuffData(1019, "buff1019", 67, 0, 10, 1f, 1, false, 2, 0, 0f, 0f, 0.03f, new int[] {0, 0, 0, 0, 0, 0, 0}, "", ""));
root.Add(1020, new BuffData(1020, "buff1020", 0, 0, 1, 0f, 1, false, 1, 0, 0f, 0f, 0.15f, new int[] {0, 0, 0, 0, 0, 0, 0}, "", ""));
root.Add(1021, new BuffData(1021, "buff1021", 0, 0, 1, 1f, 1, false, 1, 0, 0f, 0f, 0.1f, new int[] {0, 0, 0, 0, 0, 0, 0}, "", ""));
root.Add(1022, new BuffData(1022, "buff1022", 5, 0, 1, 10f, 1, false, 1, 0, 0f, 0f, 0f, new int[] {24, 0, 0, 0, 0, 0, 0}, "", ""));
root.Add(1023, new BuffData(1023, "buff1023", 0, 0, 1, 10f, 1, false, 1, 0, 0f, 0f, 0f, new int[] {0, 0, 0, 0, 0, 0, 0}, "", ""));
root.Add(1024, new BuffData(1024, "buff1024", 0, 4, 1, 1f, 1, false, 1, 0, 0f, 0f, 0.1f, new int[] {0, 0, 0, 0, 0, 0, 0}, "", ""));
root.Add(1025, new BuffData(1025, "buff1025", 10, 0, 3, 1f, 1, false, 1, 0, 0f, 0f, 0f, new int[] {0, 0, 0, 0, 0, 0, 0}, "", ""));
root.Add(1026, new BuffData(1026, "buff1026", 0, 4, 5, 1f, 1, false, 2, 0, 0f, 0f, 0.04f, new int[] {0, 0, 0, 0, 0, 0, 0}, "", ""));
root.Add(1027, new BuffData(1027, "buff1027", 7, 0, 1, 10f, 1, false, 1, 0, 0f, 0f, 0f, new int[] {29, 0, 0, 0, 0, 0, 0}, "", ""));
root.Add(1028, new BuffData(1028, "buff1028", 5, 0, 1, 10f, 1, false, 1, 0, 0f, 0f, 0f, new int[] {30, 0, 0, 0, 0, 0, 0}, "", ""));
root.Add(1029, new BuffData(1029, "buff1029", 0, 0, 1, 1f, 1, false, 1, 0, 0f, 0f, 0f, new int[] {0, 0, 0, 0, 0, 0, 0}, "", ""));
root.Add(1030, new BuffData(1030, "buff1030", 0, 0, 1, 10f, 1, false, 1, 0, 0f, 0f, 0f, new int[] {0, 0, 0, 0, 0, 0, 0}, "", ""));
root.Add(1031, new BuffData(1031, "buff1031", 0, 94, 1, 10f, 1, false, 1, 0, 0f, 0f, 0f, new int[] {48, 0, 0, 0, 0, 0, 0}, "", ""));
root.Add(1032, new BuffData(1032, "buff1032", 0, 95, 1, 10f, 1, false, 1, 0, 0f, 0f, 0f, new int[] {49, 0, 0, 0, 0, 0, 0}, "", ""));
root.Add(1033, new BuffData(1033, "buff1033", 0, 96, 1, 10f, 1, false, 1, 0, 0f, 0f, 0f, new int[] {50, 0, 0, 0, 0, 0, 0}, "", ""));
root.Add(1034, new BuffData(1034, "buff1034", 0, 97, 1, 10f, 1, false, 1, 0, 0f, 0f, 0f, new int[] {51, 0, 0, 0, 0, 0, 0}, "", ""));
root.Add(1035, new BuffData(1035, "buff1035", 0, 98, 1, 10f, 1, false, 1, 0, 0f, 0f, 0f, new int[] {52, 0, 0, 0, 0, 0, 0}, "", ""));
root.Add(1036, new BuffData(1036, "buff1036", 0, 99, 1, 10f, 1, false, 1, 0, 0f, 0f, 0f, new int[] {53, 0, 0, 0, 0, 0, 0}, "", ""));
root.Add(1037, new BuffData(1037, "buff1037", 0, 100, 1, 10f, 1, false, 1, 0, 0f, 0f, 0f, new int[] {54, 0, 0, 0, 0, 0, 0}, "", ""));
root.Add(1038, new BuffData(1038, "buff1038", 0, 0, 1, 10f, 1, false, 1, 0, 0f, 0f, 0f, new int[] {55, 0, 0, 0, 0, 0, 0}, "", ""));
root.Add(1039, new BuffData(1039, "buff1039", 0, 4, 1, 1f, 1, false, 1, 0, 0f, 0f, 0.1f, new int[] {0, 0, 0, 0, 0, 0, 0}, "", ""));
root.Add(1040, new BuffData(1040, "buff1040", 7, 0, 1, 5f, 1, false, 1, 0, 0f, 0f, 0f, new int[] {57, 0, 0, 0, 0, 0, 0}, "", ""));
root.Add(1041, new BuffData(1041, "buff1041", 5, 0, 1, 10f, 1, false, 1, 0, 0f, 0f, 0f, new int[] {58, 0, 0, 0, 0, 0, 0}, "", ""));
root.Add(1042, new BuffData(1042, "buff1042", 104, 0, 1, 10f, 1, false, 1, 0, 0f, 0f, 0f, new int[] {59, 0, 0, 0, 0, 0, 0}, "", ""));
root.Add(1043, new BuffData(1043, "buff1043", 0, 0, 3, 3f, 1, true, 1, 0, 0f, -0.03f, 0f, new int[] {60, 0, 0, 0, 0, 0, 0}, "", ""));
root.Add(1044, new BuffData(1044, "buff1044", 0, 7, 1, 0f, 1, true, 1, 0, 0f, 0f, 0f, new int[] {0, 0, 0, 0, 0, 0, 0}, "", ""));
root.Add(1045, new BuffData(1045, "buff1045", 0, 7, 1, 0f, 1, true, 1, 0, 0f, 0f, 0f, new int[] {0, 0, 0, 0, 0, 0, 0}, "", ""));
root.Add(1046, new BuffData(1046, "buff1046", 0, 0, 1, 10f, 1, false, 1, 0, 0f, 0f, 0f, new int[] {62, 0, 0, 0, 0, 0, 0}, "", ""));
root.Add(1047, new BuffData(1047, "buff1047", 0, 0, 1, 10f, 1, false, 1, 0, 0f, 0f, 0f, new int[] {63, 0, 0, 0, 0, 0, 0}, "", ""));
}
public BuffData GetReadData(int ID){
if (root.ContainsKey(ID))
return root[ID];
else{
object obj = MMFramework.ModifyExcelModule.Instance.GetModifyedData(ID);
if (obj != null)return obj as BuffData;
Debug.LogError("在表格 BuffData中没有找到ID" + ID);
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
BuffData data = GetReadData(key);
Type type = data.GetType();
System.Reflection.FieldInfo[] filedinfos = type.GetFields();
for (int i = 0; i < filedinfos.Length; i++)
{System.Reflection.FieldInfo field = filedinfos[i];
pairs.Add(field.Name, field.GetValue(data).ToString());}
return pairs;}
}
public static BuffData GetData(int ID){
return BuffDataReader.Instance.GetReadData(ID);
}
public static Dictionary<string, string> GetDictionary(int key)
{ return BuffDataReader.Instance.GetReadDictionary(key);}
public static int GetNum(){
return BuffDataReader.Instance.GetCount();
}
public static List<int> GetKeys(){
return BuffDataReader.Instance.GetDataKeys();
}
public static void SaveToFile(string path){
BuffDataReader.Instance.WriteToFile(path);
}

}