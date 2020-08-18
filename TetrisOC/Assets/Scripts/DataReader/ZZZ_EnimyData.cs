using System;
using System.Collections.Generic;
using UnityEngine;
[Serializable]
public class ZZZ_EnimyData{
/// <summary>
/// 怪组ID
/// </summary>
public string enimyID;
/// <summary>
/// 怪组ID
/// </summary>
public int roomTag;
/// <summary>
/// 波数
/// </summary>
public int indexTag;
/// <summary>
/// IndexID外观
/// </summary>
public int CreatureID;
/// <summary>
/// 个数
/// </summary>
public int Num;
/// <summary>
/// 出生点
/// </summary>
public int birthIndex;
/// <summary>
/// 增加等级
/// </summary>
public int AddLv;
/// <summary>
/// 增加星级
/// </summary>
public int AddStar;
public ZZZ_EnimyData(string enimyID, int roomTag, int indexTag, int CreatureID, int Num, int birthIndex, int AddLv, int AddStar){
this.enimyID = enimyID;
this.roomTag = roomTag;
this.indexTag = indexTag;
this.CreatureID = CreatureID;
this.Num = Num;
this.birthIndex = birthIndex;
this.AddLv = AddLv;
this.AddStar = AddStar;
}
class ZZZ_EnimyDataReader{
static ZZZ_EnimyDataReader instance;
static object syncRoot = new object();
public static ZZZ_EnimyDataReader Instance{get{if (instance == null){lock (syncRoot){if (instance == null){instance = new ZZZ_EnimyDataReader();instance.Load();}}}return instance;}}
Dictionary<string, ZZZ_EnimyData> root = new Dictionary<string, ZZZ_EnimyData>();
void Load(){
root.Add("370011440010", new ZZZ_EnimyData("370011440010", 37001, 1, 44001, 1, 0, 0, 0));
root.Add("370021440010", new ZZZ_EnimyData("370021440010", 37002, 1, 44001, 3, 0, 0, 0));
root.Add("370022440020", new ZZZ_EnimyData("370022440020", 37002, 2, 44002, 1, 0, 0, 0));
root.Add("370031440010", new ZZZ_EnimyData("370031440010", 37003, 1, 44001, 3, 0, 0, 0));
root.Add("370032440030", new ZZZ_EnimyData("370032440030", 37003, 2, 44003, 1, 0, 0, 0));
root.Add("370041440010", new ZZZ_EnimyData("370041440010", 37004, 1, 44001, 4, 0, 0, 0));
root.Add("370042440020", new ZZZ_EnimyData("370042440020", 37004, 2, 44002, 2, 0, 0, 0));
root.Add("370051440020", new ZZZ_EnimyData("370051440020", 37005, 1, 44002, 3, 0, 0, 0));
root.Add("370052440030", new ZZZ_EnimyData("370052440030", 37005, 2, 44003, 2, 0, 0, 0));
root.Add("370061440010", new ZZZ_EnimyData("370061440010", 37006, 1, 44001, 6, 0, 0, 0));
root.Add("370062440020", new ZZZ_EnimyData("370062440020", 37006, 2, 44002, 3, 0, 0, 0));
root.Add("370071440030", new ZZZ_EnimyData("370071440030", 37007, 1, 44003, 2, 0, 0, 0));
root.Add("370072440030", new ZZZ_EnimyData("370072440030", 37007, 2, 44003, 4, 0, 0, 0));
root.Add("370081440010", new ZZZ_EnimyData("370081440010", 37008, 1, 44001, 2, 0, 0, 0));
root.Add("370081440020", new ZZZ_EnimyData("370081440020", 37008, 1, 44002, 3, 0, 0, 0));
root.Add("370082440020", new ZZZ_EnimyData("370082440020", 37008, 2, 44002, 2, 0, 0, 0));
root.Add("370082440030", new ZZZ_EnimyData("370082440030", 37008, 2, 44003, 2, 0, 0, 0));
root.Add("370083440010", new ZZZ_EnimyData("370083440010", 37008, 3, 44001, 3, 0, 0, 0));
root.Add("370083440030", new ZZZ_EnimyData("370083440030", 37008, 3, 44003, 2, 0, 0, 0));
root.Add("370091440010", new ZZZ_EnimyData("370091440010", 37009, 1, 44001, 6, 0, 0, 0));
root.Add("370091440020", new ZZZ_EnimyData("370091440020", 37009, 1, 44002, 3, 0, 0, 0));
root.Add("370092440020", new ZZZ_EnimyData("370092440020", 37009, 2, 44002, 4, 0, 0, 0));
root.Add("370092440030", new ZZZ_EnimyData("370092440030", 37009, 2, 44003, 3, 0, 0, 0));
root.Add("370093440010", new ZZZ_EnimyData("370093440010", 37009, 3, 44001, 20, 0, 0, 0));
root.Add("370101440010", new ZZZ_EnimyData("370101440010", 37010, 1, 44001, 40, 0, 0, 0));
root.Add("370101440030", new ZZZ_EnimyData("370101440030", 37010, 1, 44003, 3, 0, 0, 0));
root.Add("370102440010", new ZZZ_EnimyData("370102440010", 37010, 2, 44001, 40, 0, 0, 0));
root.Add("370102440020", new ZZZ_EnimyData("370102440020", 37010, 2, 44002, 2, 0, 0, 0));
root.Add("370102440030", new ZZZ_EnimyData("370102440030", 37010, 2, 44003, 2, 0, 0, 0));
root.Add("370103440050", new ZZZ_EnimyData("370103440050", 37010, 3, 44005, 1, 0, 0, 0));
root.Add("370111440010", new ZZZ_EnimyData("370111440010", 37011, 1, 44001, 20, 0, 0, 0));
root.Add("370112440020", new ZZZ_EnimyData("370112440020", 37011, 2, 44002, 10, 0, 0, 0));
root.Add("370112440030", new ZZZ_EnimyData("370112440030", 37011, 2, 44003, 10, 0, 0, 0));
root.Add("370113440010", new ZZZ_EnimyData("370113440010", 37011, 3, 44001, 10, 0, 0, 0));
root.Add("370113440020", new ZZZ_EnimyData("370113440020", 37011, 3, 44002, 5, 0, 0, 0));
root.Add("370114440050", new ZZZ_EnimyData("370114440050", 37011, 4, 44005, 1, 0, 0, 0));
root.Add("370121440020", new ZZZ_EnimyData("370121440020", 37012, 1, 44002, 4, 0, 0, 0));
root.Add("370121440030", new ZZZ_EnimyData("370121440030", 37012, 1, 44003, 4, 0, 0, 0));
root.Add("370122440020", new ZZZ_EnimyData("370122440020", 37012, 2, 44002, 6, 0, 0, 0));
root.Add("370122440030", new ZZZ_EnimyData("370122440030", 37012, 2, 44003, 2, 0, 0, 0));
root.Add("370123440010", new ZZZ_EnimyData("370123440010", 37012, 3, 44001, 8, 0, 0, 0));
root.Add("370123440030", new ZZZ_EnimyData("370123440030", 37012, 3, 44003, 4, 0, 0, 0));
root.Add("370124440050", new ZZZ_EnimyData("370124440050", 37012, 4, 44005, 1, 0, 0, 0));
}
public ZZZ_EnimyData GetReadData(string ID){
if (root.ContainsKey(ID))
return root[ID];
else{
object obj = MMFramework.ModifyExcelModule.Instance.GetModifyedData(ID);
if (obj != null)return obj as ZZZ_EnimyData;
Debug.LogError("在表格 ZZZ_EnimyData中没有找到ID" + ID);
return null;}
}
public void WriteToFile(string path){}
public int GetCount(){
return root.Count;
}
public List<string> GetDataKeys(){
return new List<string>(root.Keys);
}
public Dictionary<string, string> GetReadDictionary(string key)
{Dictionary<string, string> pairs = new Dictionary<string, string>();
ZZZ_EnimyData data = GetReadData(key);
Type type = data.GetType();
System.Reflection.FieldInfo[] filedinfos = type.GetFields();
for (int i = 0; i < filedinfos.Length; i++)
{System.Reflection.FieldInfo field = filedinfos[i];
pairs.Add(field.Name, field.GetValue(data).ToString());}
return pairs;}
}
public static ZZZ_EnimyData GetData(string ID){
return ZZZ_EnimyDataReader.Instance.GetReadData(ID);
}
public static Dictionary<string, string> GetDictionary(string key)
{ return ZZZ_EnimyDataReader.Instance.GetReadDictionary(key);}
public static int GetNum(){
return ZZZ_EnimyDataReader.Instance.GetCount();
}
public static List<string> GetKeys(){
return ZZZ_EnimyDataReader.Instance.GetDataKeys();
}
public static void SaveToFile(string path){
ZZZ_EnimyDataReader.Instance.WriteToFile(path);
}

}