using System;
using System.Collections.Generic;
using UnityEngine;
[Serializable]
public class PhysiqueStarData{
/// <summary>
/// 属性ID
/// </summary>
public int PhysiqueID;
/// <summary>
/// 攻击力公式
/// </summary>
public string AtkFormula;
/// <summary>
/// 防御值公式
/// </summary>
public string DefFormula;
/// <summary>
/// 生命值公式
/// </summary>
public string HpFormula;
/// <summary>
/// 升级上限
/// </summary>
public int LevelUpMax;
public PhysiqueStarData(int PhysiqueID, string AtkFormula, string DefFormula, string HpFormula, int LevelUpMax){
this.PhysiqueID = PhysiqueID;
this.AtkFormula = AtkFormula;
this.DefFormula = DefFormula;
this.HpFormula = HpFormula;
this.LevelUpMax = LevelUpMax;
}
class PhysiqueStarDataReader{
static PhysiqueStarDataReader instance;
static object syncRoot = new object();
public static PhysiqueStarDataReader Instance{get{if (instance == null){lock (syncRoot){if (instance == null){instance = new PhysiqueStarDataReader();instance.Load();}}}return instance;}}
Dictionary<int, PhysiqueStarData> root = new Dictionary<int, PhysiqueStarData>();
void Load(){
root.Add(700101, new PhysiqueStarData(700101, "5.33333333333333*POW(1.04,x)", "2*POW(1.04,x)", "135*POW(1.04,x)", 40));
root.Add(700102, new PhysiqueStarData(700102, "5.33333333333333*POW(1.04,x)", "2*POW(1.04,x)", "135*POW(1.04,x)", 80));
root.Add(700103, new PhysiqueStarData(700103, "5.33333333333333*POW(1.04,x)", "2*POW(1.04,x)", "135*POW(1.04,x)", 120));
root.Add(700104, new PhysiqueStarData(700104, "5.33333333333333*POW(1.04,x)", "2*POW(1.04,x)", "135*POW(1.04,x)", 160));
root.Add(700105, new PhysiqueStarData(700105, "5.33333333333333*POW(1.04,x)", "2*POW(1.04,x)", "135*POW(1.04,x)", 200));
root.Add(700106, new PhysiqueStarData(700106, "5.33333333333333*POW(1.04,x)", "2*POW(1.04,x)", "135*POW(1.04,x)", 250));
root.Add(700107, new PhysiqueStarData(700107, "5.33333333333333*POW(1.04,x)", "2*POW(1.04,x)", "135*POW(1.04,x)", 300));
root.Add(700108, new PhysiqueStarData(700108, "5.33333333333333*POW(1.04,x)", "2*POW(1.04,x)", "135*POW(1.04,x)", 300));
root.Add(700109, new PhysiqueStarData(700109, "5.33333333333333*POW(1.04,x)", "2*POW(1.04,x)", "135*POW(1.04,x)", 300));
root.Add(700110, new PhysiqueStarData(700110, "8.75*POW(1.04,x)", "2*POW(1.04,x)", "105*POW(1.04,x)", 300));
root.Add(700201, new PhysiqueStarData(700201, "8.75*POW(1.04,x)", "2*POW(1.04,x)", "105*POW(1.04,x)", 40));
root.Add(700202, new PhysiqueStarData(700202, "8.75*POW(1.04,x)", "2*POW(1.04,x)", "105*POW(1.04,x)", 80));
root.Add(700203, new PhysiqueStarData(700203, "8.75*POW(1.04,x)", "2*POW(1.04,x)", "105*POW(1.04,x)", 120));
root.Add(700204, new PhysiqueStarData(700204, "8.75*POW(1.04,x)", "2*POW(1.04,x)", "105*POW(1.04,x)", 160));
root.Add(700205, new PhysiqueStarData(700205, "8.75*POW(1.04,x)", "2*POW(1.04,x)", "105*POW(1.04,x)", 200));
root.Add(700206, new PhysiqueStarData(700206, "8.75*POW(1.04,x)", "2*POW(1.04,x)", "105*POW(1.04,x)", 250));
root.Add(700207, new PhysiqueStarData(700207, "8.75*POW(1.04,x)", "2*POW(1.04,x)", "105*POW(1.04,x)", 300));
root.Add(700208, new PhysiqueStarData(700208, "8.75*POW(1.04,x)", "2*POW(1.04,x)", "105*POW(1.04,x)", 300));
root.Add(700209, new PhysiqueStarData(700209, "8.75*POW(1.04,x)", "2*POW(1.04,x)", "105*POW(1.04,x)", 300));
root.Add(700210, new PhysiqueStarData(700210, "8.75*POW(1.04,x)", "2*POW(1.04,x)", "105*POW(1.04,x)", 300));
root.Add(700301, new PhysiqueStarData(700301, "8.75*POW(1.04,x)", "2*POW(1.04,x)", "75*POW(1.04,x)", 40));
root.Add(700302, new PhysiqueStarData(700302, "8.75*POW(1.04,x)", "2*POW(1.04,x)", "75*POW(1.04,x)", 80));
root.Add(700303, new PhysiqueStarData(700303, "8.75*POW(1.04,x)", "2*POW(1.04,x)", "75*POW(1.04,x)", 120));
root.Add(700304, new PhysiqueStarData(700304, "8.75*POW(1.04,x)", "2*POW(1.04,x)", "75*POW(1.04,x)", 160));
root.Add(700305, new PhysiqueStarData(700305, "8.75*POW(1.04,x)", "2*POW(1.04,x)", "75*POW(1.04,x)", 200));
root.Add(700306, new PhysiqueStarData(700306, "8.75*POW(1.04,x)", "2*POW(1.04,x)", "75*POW(1.04,x)", 250));
root.Add(700307, new PhysiqueStarData(700307, "8.75*POW(1.04,x)", "2*POW(1.04,x)", "75*POW(1.04,x)", 300));
root.Add(700308, new PhysiqueStarData(700308, "8.75*POW(1.04,x)", "2*POW(1.04,x)", "75*POW(1.04,x)", 300));
root.Add(700309, new PhysiqueStarData(700309, "8.75*POW(1.04,x)", "2*POW(1.04,x)", "75*POW(1.04,x)", 300));
root.Add(700310, new PhysiqueStarData(700310, "8.75*POW(1.04,x)", "2*POW(1.04,x)", "75*POW(1.04,x)", 300));
root.Add(700401, new PhysiqueStarData(700401, "9.5*POW(1.04,x)", "2*POW(1.04,x)", "66*POW(1.04,x)", 40));
root.Add(700402, new PhysiqueStarData(700402, "9.5*POW(1.04,x)", "2*POW(1.04,x)", "66*POW(1.04,x)", 80));
root.Add(700403, new PhysiqueStarData(700403, "9.5*POW(1.04,x)", "2*POW(1.04,x)", "66*POW(1.04,x)", 120));
root.Add(700404, new PhysiqueStarData(700404, "9.5*POW(1.04,x)", "2*POW(1.04,x)", "66*POW(1.04,x)", 160));
root.Add(700405, new PhysiqueStarData(700405, "9.5*POW(1.04,x)", "2*POW(1.04,x)", "66*POW(1.04,x)", 200));
root.Add(700406, new PhysiqueStarData(700406, "9.5*POW(1.04,x)", "2*POW(1.04,x)", "66*POW(1.04,x)", 250));
root.Add(700407, new PhysiqueStarData(700407, "9.5*POW(1.04,x)", "2*POW(1.04,x)", "66*POW(1.04,x)", 300));
root.Add(700408, new PhysiqueStarData(700408, "9.5*POW(1.04,x)", "2*POW(1.04,x)", "66*POW(1.04,x)", 300));
root.Add(700409, new PhysiqueStarData(700409, "9.5*POW(1.04,x)", "2*POW(1.04,x)", "66*POW(1.04,x)", 300));
root.Add(700410, new PhysiqueStarData(700410, "9.5*POW(1.04,x)", "2*POW(1.04,x)", "66*POW(1.04,x)", 300));
root.Add(700501, new PhysiqueStarData(700501, "10.7096774193548*POW(1.04,x)", "2*POW(1.04,x)", "63*POW(1.04,x)", 40));
root.Add(700502, new PhysiqueStarData(700502, "10.7096774193548*POW(1.04,x)", "2*POW(1.04,x)", "63*POW(1.04,x)", 80));
root.Add(700503, new PhysiqueStarData(700503, "10.7096774193548*POW(1.04,x)", "2*POW(1.04,x)", "63*POW(1.04,x)", 120));
root.Add(700504, new PhysiqueStarData(700504, "10.7096774193548*POW(1.04,x)", "2*POW(1.04,x)", "63*POW(1.04,x)", 160));
root.Add(700505, new PhysiqueStarData(700505, "10.7096774193548*POW(1.04,x)", "2*POW(1.04,x)", "63*POW(1.04,x)", 200));
root.Add(700506, new PhysiqueStarData(700506, "10.7096774193548*POW(1.04,x)", "2*POW(1.04,x)", "63*POW(1.04,x)", 250));
root.Add(700507, new PhysiqueStarData(700507, "10.7096774193548*POW(1.04,x)", "2*POW(1.04,x)", "63*POW(1.04,x)", 300));
root.Add(700508, new PhysiqueStarData(700508, "10.7096774193548*POW(1.04,x)", "2*POW(1.04,x)", "63*POW(1.04,x)", 300));
root.Add(700509, new PhysiqueStarData(700509, "10.7096774193548*POW(1.04,x)", "2*POW(1.04,x)", "63*POW(1.04,x)", 300));
root.Add(700510, new PhysiqueStarData(700510, "10.7096774193548*POW(1.04,x)", "2*POW(1.04,x)", "63*POW(1.04,x)", 300));
root.Add(700601, new PhysiqueStarData(700601, "32*POW(1.04,x)", "2*POW(1.04,x)", "75*POW(1.04,x)", 40));
root.Add(700602, new PhysiqueStarData(700602, "32*POW(1.04,x)", "2*POW(1.04,x)", "75*POW(1.04,x)", 80));
root.Add(700603, new PhysiqueStarData(700603, "32*POW(1.04,x)", "2*POW(1.04,x)", "75*POW(1.04,x)", 120));
root.Add(700604, new PhysiqueStarData(700604, "32*POW(1.04,x)", "2*POW(1.04,x)", "75*POW(1.04,x)", 160));
root.Add(700605, new PhysiqueStarData(700605, "32*POW(1.04,x)", "2*POW(1.04,x)", "75*POW(1.04,x)", 200));
root.Add(700606, new PhysiqueStarData(700606, "32*POW(1.04,x)", "2*POW(1.04,x)", "75*POW(1.04,x)", 250));
root.Add(700607, new PhysiqueStarData(700607, "32*POW(1.04,x)", "2*POW(1.04,x)", "75*POW(1.04,x)", 300));
root.Add(700608, new PhysiqueStarData(700608, "32*POW(1.04,x)", "2*POW(1.04,x)", "75*POW(1.04,x)", 300));
root.Add(700609, new PhysiqueStarData(700609, "32*POW(1.04,x)", "2*POW(1.04,x)", "75*POW(1.04,x)", 300));
root.Add(700610, new PhysiqueStarData(700610, "32*POW(1.04,x)", "2*POW(1.04,x)", "75*POW(1.04,x)", 300));
root.Add(700701, new PhysiqueStarData(700701, "18.875*POW(1.04,x)", "2*POW(1.04,x)", "81*POW(1.04,x)", 40));
root.Add(700702, new PhysiqueStarData(700702, "18.875*POW(1.04,x)", "2*POW(1.04,x)", "81*POW(1.04,x)", 80));
root.Add(700703, new PhysiqueStarData(700703, "18.875*POW(1.04,x)", "2*POW(1.04,x)", "81*POW(1.04,x)", 120));
root.Add(700704, new PhysiqueStarData(700704, "18.875*POW(1.04,x)", "2*POW(1.04,x)", "81*POW(1.04,x)", 160));
root.Add(700705, new PhysiqueStarData(700705, "18.875*POW(1.04,x)", "2*POW(1.04,x)", "81*POW(1.04,x)", 200));
root.Add(700706, new PhysiqueStarData(700706, "18.875*POW(1.04,x)", "2*POW(1.04,x)", "81*POW(1.04,x)", 250));
root.Add(700707, new PhysiqueStarData(700707, "18.875*POW(1.04,x)", "2*POW(1.04,x)", "81*POW(1.04,x)", 300));
root.Add(700708, new PhysiqueStarData(700708, "18.875*POW(1.04,x)", "2*POW(1.04,x)", "81*POW(1.04,x)", 300));
root.Add(700709, new PhysiqueStarData(700709, "18.875*POW(1.04,x)", "2*POW(1.04,x)", "81*POW(1.04,x)", 300));
root.Add(700710, new PhysiqueStarData(700710, "18.875*POW(1.04,x)", "2*POW(1.04,x)", "81*POW(1.04,x)", 300));
root.Add(700801, new PhysiqueStarData(700801, "5*POW(1.04,x)", "2*POW(1.04,x)", "20*POW(1.04,x)", 300));
root.Add(700802, new PhysiqueStarData(700802, "5*POW(1.04,x)", "2*POW(1.04,x)", "20*POW(1.04,x)", 300));
root.Add(700803, new PhysiqueStarData(700803, "5*POW(1.04,x)", "2*POW(1.04,x)", "20*POW(1.04,x)", 300));
root.Add(700804, new PhysiqueStarData(700804, "5*POW(1.04,x)", "2*POW(1.04,x)", "20*POW(1.04,x)", 300));
root.Add(700805, new PhysiqueStarData(700805, "5*POW(1.04,x)", "2*POW(1.04,x)", "20*POW(1.04,x)", 300));
root.Add(700806, new PhysiqueStarData(700806, "5*POW(1.04,x)", "2*POW(1.04,x)", "20*POW(1.04,x)", 300));
root.Add(700807, new PhysiqueStarData(700807, "5*POW(1.04,x)", "2*POW(1.04,x)", "20*POW(1.04,x)", 300));
root.Add(700808, new PhysiqueStarData(700808, "5*POW(1.04,x)", "2*POW(1.04,x)", "20*POW(1.04,x)", 300));
root.Add(700809, new PhysiqueStarData(700809, "5*POW(1.04,x)", "2*POW(1.04,x)", "20*POW(1.04,x)", 300));
root.Add(700810, new PhysiqueStarData(700810, "5*POW(1.04,x)", "2*POW(1.04,x)", "20*POW(1.04,x)", 300));
root.Add(700901, new PhysiqueStarData(700901, "5*POW(1.04,x)", "2*POW(1.04,x)", "20*POW(1.04,x)/1.6", 300));
root.Add(700902, new PhysiqueStarData(700902, "5*POW(1.04,x)", "2*POW(1.04,x)", "20*POW(1.04,x)/1.6", 300));
root.Add(700903, new PhysiqueStarData(700903, "5*POW(1.04,x)", "2*POW(1.04,x)", "20*POW(1.04,x)/1.6", 300));
root.Add(700904, new PhysiqueStarData(700904, "5*POW(1.04,x)", "2*POW(1.04,x)", "20*POW(1.04,x)/1.6", 300));
root.Add(700905, new PhysiqueStarData(700905, "5*POW(1.04,x)", "2*POW(1.04,x)", "20*POW(1.04,x)/1.6", 300));
root.Add(700906, new PhysiqueStarData(700906, "5*POW(1.04,x)", "2*POW(1.04,x)", "20*POW(1.04,x)/1.6", 300));
root.Add(700907, new PhysiqueStarData(700907, "5*POW(1.04,x)", "2*POW(1.04,x)", "20*POW(1.04,x)/1.6", 300));
root.Add(700908, new PhysiqueStarData(700908, "5*POW(1.04,x)", "2*POW(1.04,x)", "20*POW(1.04,x)/1.6", 300));
root.Add(700909, new PhysiqueStarData(700909, "5*POW(1.04,x)", "2*POW(1.04,x)", "20*POW(1.04,x)/1.6", 300));
root.Add(700910, new PhysiqueStarData(700910, "5*POW(1.04,x)", "2*POW(1.04,x)", "20*POW(1.04,x)/1.6", 300));
root.Add(701001, new PhysiqueStarData(701001, "5*POW(1.04,x)", "2*POW(1.04,x)", "20*POW(1.04,x)/10", 300));
root.Add(701002, new PhysiqueStarData(701002, "5*POW(1.04,x)", "2*POW(1.04,x)", "20*POW(1.04,x)/10", 300));
root.Add(701003, new PhysiqueStarData(701003, "5*POW(1.04,x)", "2*POW(1.04,x)", "20*POW(1.04,x)/10", 300));
root.Add(701004, new PhysiqueStarData(701004, "5*POW(1.04,x)", "2*POW(1.04,x)", "20*POW(1.04,x)/10", 300));
root.Add(701005, new PhysiqueStarData(701005, "5*POW(1.04,x)", "2*POW(1.04,x)", "20*POW(1.04,x)/10", 300));
root.Add(701006, new PhysiqueStarData(701006, "5*POW(1.04,x)", "2*POW(1.04,x)", "20*POW(1.04,x)/10", 300));
root.Add(701007, new PhysiqueStarData(701007, "5*POW(1.04,x)", "2*POW(1.04,x)", "20*POW(1.04,x)/10", 300));
root.Add(701008, new PhysiqueStarData(701008, "5*POW(1.04,x)", "2*POW(1.04,x)", "20*POW(1.04,x)/10", 300));
root.Add(701009, new PhysiqueStarData(701009, "5*POW(1.04,x)", "2*POW(1.04,x)", "20*POW(1.04,x)/10", 300));
root.Add(701010, new PhysiqueStarData(701010, "5*POW(1.04,x)", "2*POW(1.04,x)", "20*POW(1.04,x)/10", 300));
root.Add(701101, new PhysiqueStarData(701101, "5*POW(1.04,x)", "2*POW(1.04,x)", "20*POW(1.04,x)", 300));
root.Add(701102, new PhysiqueStarData(701102, "5*POW(1.04,x)", "2*POW(1.04,x)", "20*POW(1.04,x)", 300));
root.Add(701103, new PhysiqueStarData(701103, "5*POW(1.04,x)", "2*POW(1.04,x)", "20*POW(1.04,x)", 300));
root.Add(701104, new PhysiqueStarData(701104, "5*POW(1.04,x)", "2*POW(1.04,x)", "20*POW(1.04,x)", 300));
root.Add(701105, new PhysiqueStarData(701105, "5*POW(1.04,x)", "2*POW(1.04,x)", "20*POW(1.04,x)", 300));
root.Add(701106, new PhysiqueStarData(701106, "5*POW(1.04,x)", "2*POW(1.04,x)", "20*POW(1.04,x)", 300));
root.Add(701107, new PhysiqueStarData(701107, "5*POW(1.04,x)", "2*POW(1.04,x)", "20*POW(1.04,x)", 300));
root.Add(701108, new PhysiqueStarData(701108, "5*POW(1.04,x)", "2*POW(1.04,x)", "20*POW(1.04,x)", 300));
root.Add(701109, new PhysiqueStarData(701109, "5*POW(1.04,x)", "2*POW(1.04,x)", "20*POW(1.04,x)", 300));
root.Add(701110, new PhysiqueStarData(701110, "5*POW(1.04,x)", "2*POW(1.04,x)", "20*POW(1.04,x)", 300));
root.Add(701201, new PhysiqueStarData(701201, "5*POW(1.04,x)", "2*POW(1.04,x)", "20*POW(1.04,x)*15", 300));
root.Add(701202, new PhysiqueStarData(701202, "5*POW(1.04,x)", "2*POW(1.04,x)", "20*POW(1.04,x)*15", 300));
root.Add(701203, new PhysiqueStarData(701203, "5*POW(1.04,x)", "2*POW(1.04,x)", "20*POW(1.04,x)*15", 300));
root.Add(701204, new PhysiqueStarData(701204, "5*POW(1.04,x)", "2*POW(1.04,x)", "20*POW(1.04,x)*15", 300));
root.Add(701205, new PhysiqueStarData(701205, "5*POW(1.04,x)", "2*POW(1.04,x)", "20*POW(1.04,x)*15", 300));
root.Add(701206, new PhysiqueStarData(701206, "5*POW(1.04,x)", "2*POW(1.04,x)", "20*POW(1.04,x)*15", 300));
root.Add(701207, new PhysiqueStarData(701207, "5*POW(1.04,x)", "2*POW(1.04,x)", "20*POW(1.04,x)*15", 300));
root.Add(701208, new PhysiqueStarData(701208, "5*POW(1.04,x)", "2*POW(1.04,x)", "20*POW(1.04,x)*15", 300));
root.Add(701209, new PhysiqueStarData(701209, "5*POW(1.04,x)", "2*POW(1.04,x)", "20*POW(1.04,x)*15", 300));
root.Add(701210, new PhysiqueStarData(701210, "5*POW(1.04,x)", "2*POW(1.04,x)", "20*POW(1.04,x)*15", 300));
}
public PhysiqueStarData GetReadData(int ID){
if (root.ContainsKey(ID))
return root[ID];
else{
object obj = MMFramework.ModifyExcelModule.Instance.GetModifyedData(ID);
if (obj != null)return obj as PhysiqueStarData;
Debug.LogError("在表格 PhysiqueStarData中没有找到ID" + ID);
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
PhysiqueStarData data = GetReadData(key);
Type type = data.GetType();
System.Reflection.FieldInfo[] filedinfos = type.GetFields();
for (int i = 0; i < filedinfos.Length; i++)
{System.Reflection.FieldInfo field = filedinfos[i];
pairs.Add(field.Name, field.GetValue(data).ToString());}
return pairs;}
}
public static PhysiqueStarData GetData(int ID){
return PhysiqueStarDataReader.Instance.GetReadData(ID);
}
public static Dictionary<string, string> GetDictionary(int key)
{ return PhysiqueStarDataReader.Instance.GetReadDictionary(key);}
public static int GetNum(){
return PhysiqueStarDataReader.Instance.GetCount();
}
public static List<int> GetKeys(){
return PhysiqueStarDataReader.Instance.GetDataKeys();
}
public static void SaveToFile(string path){
PhysiqueStarDataReader.Instance.WriteToFile(path);
}

}