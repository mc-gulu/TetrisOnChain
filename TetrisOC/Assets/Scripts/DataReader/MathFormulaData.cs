using System;
using System.Collections.Generic;
using UnityEngine;
[Serializable]
public class MathFormulaData{
/// <summary>
/// 公式ID
/// </summary>
public int ID;
/// <summary>
/// 公式
/// </summary>
public string Formula;
public MathFormulaData(int ID, string Formula){
this.ID = ID;
this.Formula = Formula;
}
class MathFormulaDataReader{
static MathFormulaDataReader instance;
static object syncRoot = new object();
public static MathFormulaDataReader Instance{get{if (instance == null){lock (syncRoot){if (instance == null){instance = new MathFormulaDataReader();instance.Load();}}}return instance;}}
Dictionary<int, MathFormulaData> root = new Dictionary<int, MathFormulaData>();
void Load(){
root.Add(1, new MathFormulaData(1, "POW(a,FLOOR(x/d)*d)*b*LN(a)*(x+1/LN(a)-FLOOR(x/d)*d)+c"));
root.Add(2, new MathFormulaData(2, "b*POW(a,x)+c"));
root.Add(3, new MathFormulaData(3, "1*a+2*b+3*c"));
}
public MathFormulaData GetReadData(int ID){
if (root.ContainsKey(ID))
return root[ID];
else{
object obj = MMFramework.ModifyExcelModule.Instance.GetModifyedData(ID);
if (obj != null)return obj as MathFormulaData;
Debug.LogError("在表格 MathFormulaData中没有找到ID" + ID);
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
MathFormulaData data = GetReadData(key);
Type type = data.GetType();
System.Reflection.FieldInfo[] filedinfos = type.GetFields();
for (int i = 0; i < filedinfos.Length; i++)
{System.Reflection.FieldInfo field = filedinfos[i];
pairs.Add(field.Name, field.GetValue(data).ToString());}
return pairs;}
}
public static MathFormulaData GetData(int ID){
return MathFormulaDataReader.Instance.GetReadData(ID);
}
public static Dictionary<string, string> GetDictionary(int key)
{ return MathFormulaDataReader.Instance.GetReadDictionary(key);}
public static int GetNum(){
return MathFormulaDataReader.Instance.GetCount();
}
public static List<int> GetKeys(){
return MathFormulaDataReader.Instance.GetDataKeys();
}
public static void SaveToFile(string path){
MathFormulaDataReader.Instance.WriteToFile(path);
}

}