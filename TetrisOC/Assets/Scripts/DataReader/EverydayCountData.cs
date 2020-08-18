using System;
using System.Collections.Generic;
using UnityEngine;
[Serializable]
public class EverydayCountData{
/// <summary>
/// 序号
/// </summary>
public int index;
/// <summary>
/// 满次数
/// </summary>
public int MaxCount;
public EverydayCountData(int index, int MaxCount){
this.index = index;
this.MaxCount = MaxCount;
}
class EverydayCountDataReader{
static EverydayCountDataReader instance;
static object syncRoot = new object();
public static EverydayCountDataReader Instance{get{if (instance == null){lock (syncRoot){if (instance == null){instance = new EverydayCountDataReader();instance.Load();}}}return instance;}}
Dictionary<int, EverydayCountData> root = new Dictionary<int, EverydayCountData>();
void Load(){
root.Add(1, new EverydayCountData(1, 3));
}
public EverydayCountData GetReadData(int ID){
if (root.ContainsKey(ID))
return root[ID];
else{
object obj = MMFramework.ModifyExcelModule.Instance.GetModifyedData(ID);
if (obj != null)return obj as EverydayCountData;
Debug.LogError("在表格 EverydayCountData中没有找到ID" + ID);
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
EverydayCountData data = GetReadData(key);
Type type = data.GetType();
System.Reflection.FieldInfo[] filedinfos = type.GetFields();
for (int i = 0; i < filedinfos.Length; i++)
{System.Reflection.FieldInfo field = filedinfos[i];
pairs.Add(field.Name, field.GetValue(data).ToString());}
return pairs;}
}
public static EverydayCountData GetData(int ID){
return EverydayCountDataReader.Instance.GetReadData(ID);
}
public static Dictionary<string, string> GetDictionary(int key)
{ return EverydayCountDataReader.Instance.GetReadDictionary(key);}
public static int GetNum(){
return EverydayCountDataReader.Instance.GetCount();
}
public static List<int> GetKeys(){
return EverydayCountDataReader.Instance.GetDataKeys();
}
public static void SaveToFile(string path){
EverydayCountDataReader.Instance.WriteToFile(path);
}

}