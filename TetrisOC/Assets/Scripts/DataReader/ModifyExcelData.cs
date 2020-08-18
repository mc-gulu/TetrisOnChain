using System;
using System.Collections.Generic;
using UnityEngine;
[Serializable]
public class ModifyExcelData{
/// <summary>
/// 序号
/// </summary>
public int ID;
/// <summary>
/// 表格
/// </summary>
public string Data;
/// <summary>
/// 行
/// </summary>
public int Key;
/// <summary>
/// 变量名
/// </summary>
public string Name0;
/// <summary>
/// 数组第几个
/// </summary>
public int ArrayIndex0;
/// <summary>
/// 值
/// </summary>
public string Value0;
/// <summary>
/// 变量名
/// </summary>
public string Name1;
/// <summary>
/// 数组第几个
/// </summary>
public int ArrayIndex1;
/// <summary>
/// 值
/// </summary>
public string Value1;
/// <summary>
/// 变量名
/// </summary>
public string Name2;
/// <summary>
/// 数组第几个
/// </summary>
public int ArrayIndex2;
/// <summary>
/// 值
/// </summary>
public string Value2;
/// <summary>
/// 变量名
/// </summary>
public string Name3;
/// <summary>
/// 数组第几个
/// </summary>
public int ArrayIndex3;
/// <summary>
/// 值
/// </summary>
public string Value3;
/// <summary>
/// 变量名
/// </summary>
public string Name;
/// <summary>
/// 数组第几个
/// </summary>
public int ArrayIndex;
/// <summary>
/// 值
/// </summary>
public string Value;
public ModifyExcelData(int ID, string Data, int Key, string Name0, int ArrayIndex0, string Value0, string Name1, int ArrayIndex1, string Value1, string Name2, int ArrayIndex2, string Value2, string Name3, int ArrayIndex3, string Value3, string Name, int ArrayIndex, string Value){
this.ID = ID;
this.Data = Data;
this.Key = Key;
this.Name0 = Name0;
this.ArrayIndex0 = ArrayIndex0;
this.Value0 = Value0;
this.Name1 = Name1;
this.ArrayIndex1 = ArrayIndex1;
this.Value1 = Value1;
this.Name2 = Name2;
this.ArrayIndex2 = ArrayIndex2;
this.Value2 = Value2;
this.Name3 = Name3;
this.ArrayIndex3 = ArrayIndex3;
this.Value3 = Value3;
this.Name = Name;
this.ArrayIndex = ArrayIndex;
this.Value = Value;
}
class ModifyExcelDataReader{
static ModifyExcelDataReader instance;
static object syncRoot = new object();
public static ModifyExcelDataReader Instance{get{if (instance == null){lock (syncRoot){if (instance == null){instance = new ModifyExcelDataReader();instance.Load();}}}return instance;}}
Dictionary<int, ModifyExcelData> root = new Dictionary<int, ModifyExcelData>();
void Load(){
root.Add(31001, new ModifyExcelData(31001, "DropData", 31000, "NumArray", 0, "10", "NumArray", 0, "10", "NumArray", 0, "10", "NumArray", 0, "10", "NumArray", 0, "10"));
root.Add(31002, new ModifyExcelData(31002, "DropData", 31001, "NumArray", 0, "100", "NumArray", 0, "100", "NumArray", 0, "100", "NumArray", 0, "100", "NumArray", 0, "100"));
}
public ModifyExcelData GetReadData(int ID){
if (root.ContainsKey(ID))
return root[ID];
else{
object obj = MMFramework.ModifyExcelModule.Instance.GetModifyedData(ID);
if (obj != null)return obj as ModifyExcelData;
Debug.LogError("在表格 ModifyExcelData中没有找到ID" + ID);
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
ModifyExcelData data = GetReadData(key);
Type type = data.GetType();
System.Reflection.FieldInfo[] filedinfos = type.GetFields();
for (int i = 0; i < filedinfos.Length; i++)
{System.Reflection.FieldInfo field = filedinfos[i];
pairs.Add(field.Name, field.GetValue(data).ToString());}
return pairs;}
}
public static ModifyExcelData GetData(int ID){
return ModifyExcelDataReader.Instance.GetReadData(ID);
}
public static Dictionary<string, string> GetDictionary(int key)
{ return ModifyExcelDataReader.Instance.GetReadDictionary(key);}
public static int GetNum(){
return ModifyExcelDataReader.Instance.GetCount();
}
public static List<int> GetKeys(){
return ModifyExcelDataReader.Instance.GetDataKeys();
}
public static void SaveToFile(string path){
ModifyExcelDataReader.Instance.WriteToFile(path);
}

}