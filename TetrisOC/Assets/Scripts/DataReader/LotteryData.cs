using System;
using System.Collections.Generic;
using UnityEngine;
[Serializable]
public class LotteryData{
/// <summary>
/// 抽奖ID
/// </summary>
public int LotteryID;
/// <summary>
/// 普通掉落
/// </summary>
public int DropNormal;
/// <summary>
/// 高级掉落
/// </summary>
public int DropGood;
/// <summary>
/// 基础高级概率
/// </summary>
public float GoodBasePercent;
/// <summary>
/// 每一次高级增加概率
/// </summary>
public float GoodPerPercent;
/// <summary>
/// 次数Tag
/// </summary>
public string Tag;
public LotteryData(int LotteryID, int DropNormal, int DropGood, float GoodBasePercent, float GoodPerPercent, string Tag){
this.LotteryID = LotteryID;
this.DropNormal = DropNormal;
this.DropGood = DropGood;
this.GoodBasePercent = GoodBasePercent;
this.GoodPerPercent = GoodPerPercent;
this.Tag = Tag;
}
class LotteryDataReader{
static LotteryDataReader instance;
static object syncRoot = new object();
public static LotteryDataReader Instance{get{if (instance == null){lock (syncRoot){if (instance == null){instance = new LotteryDataReader();instance.Load();}}}return instance;}}
Dictionary<int, LotteryData> root = new Dictionary<int, LotteryData>();
void Load(){
root.Add(48001, new LotteryData(48001, 30007, 30008, 0.1f, 0.01f, "IShiLianChou"));
root.Add(48002, new LotteryData(48002, 30009, 30010, 0.1f, 0.01f, "IShiLianChou"));
}
public LotteryData GetReadData(int ID){
if (root.ContainsKey(ID))
return root[ID];
else{
object obj = MMFramework.ModifyExcelModule.Instance.GetModifyedData(ID);
if (obj != null)return obj as LotteryData;
Debug.LogError("在表格 LotteryData中没有找到ID" + ID);
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
LotteryData data = GetReadData(key);
Type type = data.GetType();
System.Reflection.FieldInfo[] filedinfos = type.GetFields();
for (int i = 0; i < filedinfos.Length; i++)
{System.Reflection.FieldInfo field = filedinfos[i];
pairs.Add(field.Name, field.GetValue(data).ToString());}
return pairs;}
}
public static LotteryData GetData(int ID){
return LotteryDataReader.Instance.GetReadData(ID);
}
public static Dictionary<string, string> GetDictionary(int key)
{ return LotteryDataReader.Instance.GetReadDictionary(key);}
public static int GetNum(){
return LotteryDataReader.Instance.GetCount();
}
public static List<int> GetKeys(){
return LotteryDataReader.Instance.GetDataKeys();
}
public static void SaveToFile(string path){
LotteryDataReader.Instance.WriteToFile(path);
}

}