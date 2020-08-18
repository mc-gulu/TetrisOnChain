using System;
using System.Collections.Generic;
using UnityEngine;
[Serializable]
public class LogicData{
/// <summary>
/// 逻辑ID
/// </summary>
public int LogicID;
/// <summary>
/// 前置条件0
/// </summary>
public string[] ConditionNameArray;
/// <summary>
/// 条件值0
/// </summary>
public int[] ConditionValueArray;
/// <summary>
/// 改变Key0
/// </summary>
public string[] ActiveNameArray;
/// <summary>
/// 改变值0
/// </summary>
public int[] ActiceValueArray;
/// <summary>
/// 展示Prefab
/// </summary>
public string Prefab;
public LogicData(int LogicID, string[] ConditionNameArray, int[] ConditionValueArray, string[] ActiveNameArray, int[] ActiceValueArray, string Prefab){
this.LogicID = LogicID;
this.ConditionNameArray = ConditionNameArray;
this.ConditionValueArray = ConditionValueArray;
this.ActiveNameArray = ActiveNameArray;
this.ActiceValueArray = ActiceValueArray;
this.Prefab = Prefab;
}
class LogicDataReader{
static LogicDataReader instance;
static object syncRoot = new object();
public static LogicDataReader Instance{get{if (instance == null){lock (syncRoot){if (instance == null){instance = new LogicDataReader();instance.Load();}}}return instance;}}
Dictionary<int, LogicData> root = new Dictionary<int, LogicData>();
void Load(){
root.Add(1, new LogicData(1, new string[] {"tutorial", "", ""}, new int[] {0, 0, 0}, new string[] {"tutorial", "", ""}, new int[] {1, 0, 0}, "Animation/ani_prefabs/fingerui_pick"));
root.Add(2, new LogicData(2, new string[] {"tutorial", "", ""}, new int[] {1, 0, 0}, new string[] {"tutorial", "", ""}, new int[] {2, 0, 0}, "Animation/ani_prefabs/fingerui_pick2"));
root.Add(3, new LogicData(3, new string[] {"tutorial", "", ""}, new int[] {2, 0, 0}, new string[] {"tutorial", "", ""}, new int[] {3, 0, 0}, "Animation/ani_prefabs/fingerui_pick3"));
root.Add(4, new LogicData(4, new string[] {"tutorial", "", ""}, new int[] {3, 0, 0}, new string[] {"tutorial", "", ""}, new int[] {4, 0, 0}, "Animation/ani_prefabs/fingerui"));
root.Add(5, new LogicData(5, new string[] {"tutorial", "", ""}, new int[] {4, 0, 0}, new string[] {"tutorial", "", ""}, new int[] {5, 0, 0}, "Animation/ani_prefabs/fingerui"));
root.Add(6, new LogicData(6, new string[] {"tutorial", "", ""}, new int[] {5, 0, 0}, new string[] {"tutorial", "charged", ""}, new int[] {6, 1, 0}, "Animation/ani_prefabs/fingerui"));
root.Add(7, new LogicData(7, new string[] {"tutorial", "charged", ""}, new int[] {6, 1, 0}, new string[] {"tutorial", "", ""}, new int[] {7, 0, 0}, "Animation/ani_prefabs/fingerui"));
root.Add(99, new LogicData(99, new string[] {"tutorial", "", ""}, new int[] {7, 0, 0}, new string[] {"mainui", "", ""}, new int[] {1, 0, 0}, ""));
root.Add(8, new LogicData(8, new string[] {"tutorial", "mainui", ""}, new int[] {7, 1, 0}, new string[] {"tutorial", "", ""}, new int[] {8, 0, 0}, "Animation/ani_prefabs/fingerui"));
root.Add(9, new LogicData(9, new string[] {"tutorial", "", ""}, new int[] {8, 0, 0}, new string[] {"", "", ""}, new int[] {0, 0, 0}, "Animation/ani_prefabs/fingerui"));
root.Add(10, new LogicData(10, new string[] {"tutorial", "", ""}, new int[] {8, 0, 0}, new string[] {"tutorial", "level5", ""}, new int[] {9, 1, 0}, ""));
root.Add(11, new LogicData(11, new string[] {"tutorial", "level5", ""}, new int[] {9, 1, 0}, new string[] {"tutorial", "", ""}, new int[] {10, 0, 0}, "Animation/ani_prefabs/fingerui"));
root.Add(12, new LogicData(12, new string[] {"tutorial", "", ""}, new int[] {10, 0, 0}, new string[] {"tutorial", "", ""}, new int[] {11, 0, 0}, "Animation/ani_prefabs/fingerui"));
root.Add(13, new LogicData(13, new string[] {"tutorial", "", ""}, new int[] {11, 0, 0}, new string[] {"tutorial", "", ""}, new int[] {13, 0, 0}, "Animation/ani_prefabs/fingerui"));
root.Add(15, new LogicData(15, new string[] {"tutorial", "", ""}, new int[] {13, 0, 0}, new string[] {"tutorial", "", ""}, new int[] {14, 0, 0}, "Animation/ani_prefabs/fingerui"));
root.Add(16, new LogicData(16, new string[] {"tutorial", "", ""}, new int[] {14, 0, 0}, new string[] {"tutorial", "", ""}, new int[] {15, 0, 0}, "Animation/ani_prefabs/fingerui"));
root.Add(17, new LogicData(17, new string[] {"tutorial", "", ""}, new int[] {15, 0, 0}, new string[] {"tutorial", "", ""}, new int[] {16, 0, 0}, "Animation/ani_prefabs/fingerui"));
}
public LogicData GetReadData(int ID){
if (root.ContainsKey(ID))
return root[ID];
else{
object obj = MMFramework.ModifyExcelModule.Instance.GetModifyedData(ID);
if (obj != null)return obj as LogicData;
Debug.LogError("在表格 LogicData中没有找到ID" + ID);
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
LogicData data = GetReadData(key);
Type type = data.GetType();
System.Reflection.FieldInfo[] filedinfos = type.GetFields();
for (int i = 0; i < filedinfos.Length; i++)
{System.Reflection.FieldInfo field = filedinfos[i];
pairs.Add(field.Name, field.GetValue(data).ToString());}
return pairs;}
}
public static LogicData GetData(int ID){
return LogicDataReader.Instance.GetReadData(ID);
}
public static Dictionary<string, string> GetDictionary(int key)
{ return LogicDataReader.Instance.GetReadDictionary(key);}
public static int GetNum(){
return LogicDataReader.Instance.GetCount();
}
public static List<int> GetKeys(){
return LogicDataReader.Instance.GetDataKeys();
}
public static void SaveToFile(string path){
LogicDataReader.Instance.WriteToFile(path);
}

}