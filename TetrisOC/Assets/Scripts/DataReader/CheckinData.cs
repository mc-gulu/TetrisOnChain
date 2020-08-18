using System;
using System.Collections.Generic;
using UnityEngine;
[Serializable]
public class CheckinData{
/// <summary>
/// 加强ID
/// </summary>
public int CheckinID;
/// <summary>
/// 文字描述
/// </summary>
public string Desc;
/// <summary>
/// 详细说明
/// </summary>
public string Info;
/// <summary>
/// 掉落ID
/// </summary>
public int DropID;
public CheckinData(int CheckinID, string Desc, string Info, int DropID){
this.CheckinID = CheckinID;
this.Desc = Desc;
this.Info = Info;
this.DropID = DropID;
}
class CheckinDataReader{
static CheckinDataReader instance;
static object syncRoot = new object();
public static CheckinDataReader Instance{get{if (instance == null){lock (syncRoot){if (instance == null){instance = new CheckinDataReader();instance.Load();}}}return instance;}}
Dictionary<int, CheckinData> root = new Dictionary<int, CheckinData>();
void Load(){
root.Add(0, new CheckinData(0, "day1_text", "day1_info", 30205));
root.Add(1, new CheckinData(1, "day2_text", "day2_info", 30206));
root.Add(2, new CheckinData(2, "day3_text", "day3_info", 30207));
root.Add(3, new CheckinData(3, "day4_text", "day4_info", 30208));
root.Add(4, new CheckinData(4, "day5_text", "day5_info", 30209));
root.Add(5, new CheckinData(5, "day6_text", "day6_info", 30210));
root.Add(6, new CheckinData(6, "day7_text", "day7_info", 30211));
}
public CheckinData GetReadData(int ID){
if (root.ContainsKey(ID))
return root[ID];
else{
object obj = MMFramework.ModifyExcelModule.Instance.GetModifyedData(ID);
if (obj != null)return obj as CheckinData;
Debug.LogError("在表格 CheckinData中没有找到ID" + ID);
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
CheckinData data = GetReadData(key);
Type type = data.GetType();
System.Reflection.FieldInfo[] filedinfos = type.GetFields();
for (int i = 0; i < filedinfos.Length; i++)
{System.Reflection.FieldInfo field = filedinfos[i];
pairs.Add(field.Name, field.GetValue(data).ToString());}
return pairs;}
}
public static CheckinData GetData(int ID){
return CheckinDataReader.Instance.GetReadData(ID);
}
public static Dictionary<string, string> GetDictionary(int key)
{ return CheckinDataReader.Instance.GetReadDictionary(key);}
public static int GetNum(){
return CheckinDataReader.Instance.GetCount();
}
public static List<int> GetKeys(){
return CheckinDataReader.Instance.GetDataKeys();
}
public static void SaveToFile(string path){
CheckinDataReader.Instance.WriteToFile(path);
}

}