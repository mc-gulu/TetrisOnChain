using System;
using System.Collections.Generic;
using UnityEngine;
[Serializable]
public class CElementRestrain{
/// <summary>
/// 序号
/// </summary>
public int ID;
/// <summary>
/// 空
/// </summary>
public float[] Arr;
public CElementRestrain(int ID, float[] Arr){
this.ID = ID;
this.Arr = Arr;
}
class CElementRestrainReader{
static CElementRestrainReader instance;
static object syncRoot = new object();
public static CElementRestrainReader Instance{get{if (instance == null){lock (syncRoot){if (instance == null){instance = new CElementRestrainReader();instance.Load();}}}return instance;}}
Dictionary<int, CElementRestrain> root = new Dictionary<int, CElementRestrain>();
void Load(){
root.Add(1, new CElementRestrain(1, new float[] {0f, 1f, 0.8f, 1.2f, 1f, 1f, 1f}));
root.Add(2, new CElementRestrain(2, new float[] {0f, 1.2f, 1f, 0.8f, 1f, 1f, 1f}));
root.Add(3, new CElementRestrain(3, new float[] {0f, 0.8f, 1.2f, 1f, 1f, 1f, 1f}));
root.Add(4, new CElementRestrain(4, new float[] {0f, 1f, 1f, 1f, 1f, 0.8f, 1f}));
root.Add(5, new CElementRestrain(5, new float[] {0f, 1f, 1f, 1f, 0.8f, 1f, 1f}));
root.Add(6, new CElementRestrain(6, new float[] {0f, 1f, 1f, 1f, 1f, 1f, 1f}));
}
public CElementRestrain GetReadData(int ID){
if (root.ContainsKey(ID))
return root[ID];
else{
object obj = MMFramework.ModifyExcelModule.Instance.GetModifyedData(ID);
if (obj != null)return obj as CElementRestrain;
Debug.LogError("在表格 CElementRestrain中没有找到ID" + ID);
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
CElementRestrain data = GetReadData(key);
Type type = data.GetType();
System.Reflection.FieldInfo[] filedinfos = type.GetFields();
for (int i = 0; i < filedinfos.Length; i++)
{System.Reflection.FieldInfo field = filedinfos[i];
pairs.Add(field.Name, field.GetValue(data).ToString());}
return pairs;}
}
public static CElementRestrain GetData(int ID){
return CElementRestrainReader.Instance.GetReadData(ID);
}
public static Dictionary<string, string> GetDictionary(int key)
{ return CElementRestrainReader.Instance.GetReadDictionary(key);}
public static int GetNum(){
return CElementRestrainReader.Instance.GetCount();
}
public static List<int> GetKeys(){
return CElementRestrainReader.Instance.GetDataKeys();
}
public static void SaveToFile(string path){
CElementRestrainReader.Instance.WriteToFile(path);
}

}