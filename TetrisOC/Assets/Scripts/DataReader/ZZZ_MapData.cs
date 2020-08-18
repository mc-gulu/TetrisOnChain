using System;
using System.Collections.Generic;
using UnityEngine;
[Serializable]
public class ZZZ_MapData{
/// <summary>
/// 序号
/// </summary>
public int mapID;
/// <summary>
/// 房间模型
/// </summary>
public string Prefab;
public ZZZ_MapData(int mapID, string Prefab){
this.mapID = mapID;
this.Prefab = Prefab;
}
class ZZZ_MapDataReader{
static ZZZ_MapDataReader instance;
static object syncRoot = new object();
public static ZZZ_MapDataReader Instance{get{if (instance == null){lock (syncRoot){if (instance == null){instance = new ZZZ_MapDataReader();instance.Load();}}}return instance;}}
Dictionary<int, ZZZ_MapData> root = new Dictionary<int, ZZZ_MapData>();
void Load(){
root.Add(34001, new ZZZ_MapData(34001, "Prefabs/map/map1-1"));
root.Add(34002, new ZZZ_MapData(34002, "Prefabs/map/map1-2"));
}
public ZZZ_MapData GetReadData(int ID){
if (root.ContainsKey(ID))
return root[ID];
else{
object obj = MMFramework.ModifyExcelModule.Instance.GetModifyedData(ID);
if (obj != null)return obj as ZZZ_MapData;
Debug.LogError("在表格 ZZZ_MapData中没有找到ID" + ID);
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
ZZZ_MapData data = GetReadData(key);
Type type = data.GetType();
System.Reflection.FieldInfo[] filedinfos = type.GetFields();
for (int i = 0; i < filedinfos.Length; i++)
{System.Reflection.FieldInfo field = filedinfos[i];
pairs.Add(field.Name, field.GetValue(data).ToString());}
return pairs;}
}
public static ZZZ_MapData GetData(int ID){
return ZZZ_MapDataReader.Instance.GetReadData(ID);
}
public static Dictionary<string, string> GetDictionary(int key)
{ return ZZZ_MapDataReader.Instance.GetReadDictionary(key);}
public static int GetNum(){
return ZZZ_MapDataReader.Instance.GetCount();
}
public static List<int> GetKeys(){
return ZZZ_MapDataReader.Instance.GetDataKeys();
}
public static void SaveToFile(string path){
ZZZ_MapDataReader.Instance.WriteToFile(path);
}

}