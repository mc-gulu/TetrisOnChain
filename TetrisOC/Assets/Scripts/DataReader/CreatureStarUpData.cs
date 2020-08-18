using System;
using System.Collections.Generic;
using UnityEngine;
[Serializable]
public class CreatureStarUpData{
/// <summary>
/// 升星ID
/// </summary>
public int StarupID;
/// <summary>
/// 消耗卡牌的星级
/// </summary>
public int CostStar;
/// <summary>
/// 消耗个数
/// </summary>
public int CostNum;
/// <summary>
/// 消耗的卡牌是否需要同一个角色
/// </summary>
public bool IsSameCreature;
/// <summary>
/// 消耗是否需要同元素
/// </summary>
public bool IsSameElement;
public CreatureStarUpData(int StarupID, int CostStar, int CostNum, bool IsSameCreature, bool IsSameElement){
this.StarupID = StarupID;
this.CostStar = CostStar;
this.CostNum = CostNum;
this.IsSameCreature = IsSameCreature;
this.IsSameElement = IsSameElement;
}
class CreatureStarUpDataReader{
static CreatureStarUpDataReader instance;
static object syncRoot = new object();
public static CreatureStarUpDataReader Instance{get{if (instance == null){lock (syncRoot){if (instance == null){instance = new CreatureStarUpDataReader();instance.Load();}}}return instance;}}
Dictionary<int, CreatureStarUpData> root = new Dictionary<int, CreatureStarUpData>();
void Load(){
root.Add(1, new CreatureStarUpData(1, 1, 2, false, true));
root.Add(2, new CreatureStarUpData(2, 2, 2, false, true));
root.Add(3, new CreatureStarUpData(3, 3, 2, false, true));
root.Add(4, new CreatureStarUpData(4, 4, 2, true, true));
root.Add(5, new CreatureStarUpData(5, 5, 2, false, true));
root.Add(6, new CreatureStarUpData(6, 6, 1, true, true));
root.Add(7, new CreatureStarUpData(7, 7, 2, false, true));
root.Add(8, new CreatureStarUpData(8, 7, 1, true, true));
root.Add(9, new CreatureStarUpData(9, 9, 1, false, true));
root.Add(10, new CreatureStarUpData(10, 9, 1, false, true));
root.Add(0, new CreatureStarUpData(0, 0, 0, false, false));
}
public CreatureStarUpData GetReadData(int ID){
if (root.ContainsKey(ID))
return root[ID];
else{
object obj = MMFramework.ModifyExcelModule.Instance.GetModifyedData(ID);
if (obj != null)return obj as CreatureStarUpData;
Debug.LogError("在表格 CreatureStarUpData中没有找到ID" + ID);
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
CreatureStarUpData data = GetReadData(key);
Type type = data.GetType();
System.Reflection.FieldInfo[] filedinfos = type.GetFields();
for (int i = 0; i < filedinfos.Length; i++)
{System.Reflection.FieldInfo field = filedinfos[i];
pairs.Add(field.Name, field.GetValue(data).ToString());}
return pairs;}
}
public static CreatureStarUpData GetData(int ID){
return CreatureStarUpDataReader.Instance.GetReadData(ID);
}
public static Dictionary<string, string> GetDictionary(int key)
{ return CreatureStarUpDataReader.Instance.GetReadDictionary(key);}
public static int GetNum(){
return CreatureStarUpDataReader.Instance.GetCount();
}
public static List<int> GetKeys(){
return CreatureStarUpDataReader.Instance.GetDataKeys();
}
public static void SaveToFile(string path){
CreatureStarUpDataReader.Instance.WriteToFile(path);
}

}