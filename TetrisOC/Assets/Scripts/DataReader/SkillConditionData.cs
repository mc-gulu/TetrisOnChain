using System;
using System.Collections.Generic;
using UnityEngine;
[Serializable]
public class SkillConditionData{
/// <summary>
/// 序号
/// </summary>
public int ID;
/// <summary>
/// 阈值
/// </summary>
public int Threshold;
/// <summary>
/// 条件1id
/// </summary>
public int[] ConditionArray;
public SkillConditionData(int ID, int Threshold, int[] ConditionArray){
this.ID = ID;
this.Threshold = Threshold;
this.ConditionArray = ConditionArray;
}
class SkillConditionDataReader{
static SkillConditionDataReader instance;
static object syncRoot = new object();
public static SkillConditionDataReader Instance{get{if (instance == null){lock (syncRoot){if (instance == null){instance = new SkillConditionDataReader();instance.Load();}}}return instance;}}
Dictionary<int, SkillConditionData> root = new Dictionary<int, SkillConditionData>();
void Load(){
root.Add(1, new SkillConditionData(1, 20, new int[] {1, 0, 0, 0}));
root.Add(2, new SkillConditionData(2, 20, new int[] {1, 0, 0, 0}));
root.Add(3, new SkillConditionData(3, 20, new int[] {1, 0, 0, 0}));
root.Add(4, new SkillConditionData(4, 20, new int[] {1, 0, 0, 0}));
root.Add(5, new SkillConditionData(5, 20, new int[] {2, 5, 0, 0}));
root.Add(6, new SkillConditionData(6, 20, new int[] {3, 0, 0, 0}));
root.Add(7, new SkillConditionData(7, 20, new int[] {2, 6, 5, 0}));
root.Add(8, new SkillConditionData(8, 20, new int[] {2, 7, 0, 0}));
}
public SkillConditionData GetReadData(int ID){
if (root.ContainsKey(ID))
return root[ID];
else{
object obj = MMFramework.ModifyExcelModule.Instance.GetModifyedData(ID);
if (obj != null)return obj as SkillConditionData;
Debug.LogError("在表格 SkillConditionData中没有找到ID" + ID);
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
SkillConditionData data = GetReadData(key);
Type type = data.GetType();
System.Reflection.FieldInfo[] filedinfos = type.GetFields();
for (int i = 0; i < filedinfos.Length; i++)
{System.Reflection.FieldInfo field = filedinfos[i];
pairs.Add(field.Name, field.GetValue(data).ToString());}
return pairs;}
}
public static SkillConditionData GetData(int ID){
return SkillConditionDataReader.Instance.GetReadData(ID);
}
public static Dictionary<string, string> GetDictionary(int key)
{ return SkillConditionDataReader.Instance.GetReadDictionary(key);}
public static int GetNum(){
return SkillConditionDataReader.Instance.GetCount();
}
public static List<int> GetKeys(){
return SkillConditionDataReader.Instance.GetDataKeys();
}
public static void SaveToFile(string path){
SkillConditionDataReader.Instance.WriteToFile(path);
}

}