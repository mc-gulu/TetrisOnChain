using System;
using System.Collections.Generic;
using UnityEngine;
[Serializable]
public class ColorData{
/// <summary>
/// 序号
/// </summary>
public int colorID;
/// <summary>
/// 颜色用途
/// </summary>
public string Name;
/// <summary>
/// #色号
/// </summary>
public string ColorSerialNumber;
/// <summary>
/// Text标签
/// </summary>
public string ColorTextCode;
public ColorData(int colorID, string Name, string ColorSerialNumber, string ColorTextCode){
this.colorID = colorID;
this.Name = Name;
this.ColorSerialNumber = ColorSerialNumber;
this.ColorTextCode = ColorTextCode;
}
class ColorDataReader{
static ColorDataReader instance;
static object syncRoot = new object();
public static ColorDataReader Instance{get{if (instance == null){lock (syncRoot){if (instance == null){instance = new ColorDataReader();instance.Load();}}}return instance;}}
Dictionary<int, ColorData> root = new Dictionary<int, ColorData>();
void Load(){
root.Add(6, new ColorData(6, "文字红", "ffff0000", "<color=#ff0000>{0}</color>"));
}
public ColorData GetReadData(int ID){
if (root.ContainsKey(ID))
return root[ID];
else{
object obj = MMFramework.ModifyExcelModule.Instance.GetModifyedData(ID);
if (obj != null)return obj as ColorData;
Debug.LogError("在表格 ColorData中没有找到ID" + ID);
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
ColorData data = GetReadData(key);
Type type = data.GetType();
System.Reflection.FieldInfo[] filedinfos = type.GetFields();
for (int i = 0; i < filedinfos.Length; i++)
{System.Reflection.FieldInfo field = filedinfos[i];
pairs.Add(field.Name, field.GetValue(data).ToString());}
return pairs;}
}
public static ColorData GetData(int ID){
return ColorDataReader.Instance.GetReadData(ID);
}
public static Dictionary<string, string> GetDictionary(int key)
{ return ColorDataReader.Instance.GetReadDictionary(key);}
public static int GetNum(){
return ColorDataReader.Instance.GetCount();
}
public static List<int> GetKeys(){
return ColorDataReader.Instance.GetDataKeys();
}
public static void SaveToFile(string path){
ColorDataReader.Instance.WriteToFile(path);
}

}