using System;
using System.Collections.Generic;
using UnityEngine;
[Serializable]
public class SingleConditionData{
/// <summary>
/// 序号
/// </summary>
public int ID;
/// <summary>
/// 条件类型 1血量最低 2距离(不需要填条件值/权重） 3特定Buff（直接填buffID) 4敌方目标 5友方目标 6只有自己 7不含自己 8随机
/// </summary>
public int ConditionType;
/// <summary>
/// 条件值
/// </summary>
public float ConditionValue;
/// <summary>
/// 权重
/// </summary>
public float Priority;
public SingleConditionData(int ID, int ConditionType, float ConditionValue, float Priority){
this.ID = ID;
this.ConditionType = ConditionType;
this.ConditionValue = ConditionValue;
this.Priority = Priority;
}
class SingleConditionDataReader{
static SingleConditionDataReader instance;
static object syncRoot = new object();
public static SingleConditionDataReader Instance{get{if (instance == null){lock (syncRoot){if (instance == null){instance = new SingleConditionDataReader();instance.Load();}}}return instance;}}
Dictionary<int, SingleConditionData> root = new Dictionary<int, SingleConditionData>();
void Load(){
root.Add(1, new SingleConditionData(1, 4, 0f, 0f));
root.Add(2, new SingleConditionData(2, 5, 0f, 0f));
root.Add(3, new SingleConditionData(3, 6, 0f, 0f));
root.Add(4, new SingleConditionData(4, 2, 0f, 0f));
root.Add(5, new SingleConditionData(5, 1, 0f, 0f));
root.Add(6, new SingleConditionData(6, 7, 0f, 0f));
root.Add(7, new SingleConditionData(7, 8, 0f, 0f));
}
public SingleConditionData GetReadData(int ID){
if (root.ContainsKey(ID))
return root[ID];
else{
object obj = MMFramework.ModifyExcelModule.Instance.GetModifyedData(ID);
if (obj != null)return obj as SingleConditionData;
Debug.LogError("在表格 SingleConditionData中没有找到ID" + ID);
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
SingleConditionData data = GetReadData(key);
Type type = data.GetType();
System.Reflection.FieldInfo[] filedinfos = type.GetFields();
for (int i = 0; i < filedinfos.Length; i++)
{System.Reflection.FieldInfo field = filedinfos[i];
pairs.Add(field.Name, field.GetValue(data).ToString());}
return pairs;}
}
public static SingleConditionData GetData(int ID){
return SingleConditionDataReader.Instance.GetReadData(ID);
}
public static Dictionary<string, string> GetDictionary(int key)
{ return SingleConditionDataReader.Instance.GetReadDictionary(key);}
public static int GetNum(){
return SingleConditionDataReader.Instance.GetCount();
}
public static List<int> GetKeys(){
return SingleConditionDataReader.Instance.GetDataKeys();
}
public static void SaveToFile(string path){
SingleConditionDataReader.Instance.WriteToFile(path);
}

}