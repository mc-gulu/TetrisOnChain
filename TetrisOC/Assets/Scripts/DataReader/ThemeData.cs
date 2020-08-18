using System;
using System.Collections.Generic;
using UnityEngine;
[Serializable]
public class ThemeData{
/// <summary>
/// 主题ID
/// </summary>
public int ThemeID;
/// <summary>
/// 主题名字
/// </summary>
public string ThemeName;
public ThemeData(int ThemeID, string ThemeName){
this.ThemeID = ThemeID;
this.ThemeName = ThemeName;
}
class ThemeDataReader{
static ThemeDataReader instance;
static object syncRoot = new object();
public static ThemeDataReader Instance{get{if (instance == null){lock (syncRoot){if (instance == null){instance = new ThemeDataReader();instance.Load();}}}return instance;}}
Dictionary<int, ThemeData> root = new Dictionary<int, ThemeData>();
void Load(){
root.Add(33001, new ThemeData(33001, "平原"));
root.Add(33002, new ThemeData(33002, "雪山"));
root.Add(33003, new ThemeData(33003, "地狱"));
}
public ThemeData GetReadData(int ID){
if (root.ContainsKey(ID))
return root[ID];
else{
object obj = MMFramework.ModifyExcelModule.Instance.GetModifyedData(ID);
if (obj != null)return obj as ThemeData;
Debug.LogError("在表格 ThemeData中没有找到ID" + ID);
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
ThemeData data = GetReadData(key);
Type type = data.GetType();
System.Reflection.FieldInfo[] filedinfos = type.GetFields();
for (int i = 0; i < filedinfos.Length; i++)
{System.Reflection.FieldInfo field = filedinfos[i];
pairs.Add(field.Name, field.GetValue(data).ToString());}
return pairs;}
}
public static ThemeData GetData(int ID){
return ThemeDataReader.Instance.GetReadData(ID);
}
public static Dictionary<string, string> GetDictionary(int key)
{ return ThemeDataReader.Instance.GetReadDictionary(key);}
public static int GetNum(){
return ThemeDataReader.Instance.GetCount();
}
public static List<int> GetKeys(){
return ThemeDataReader.Instance.GetDataKeys();
}
public static void SaveToFile(string path){
ThemeDataReader.Instance.WriteToFile(path);
}

}