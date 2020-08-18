using System;
using System.Collections.Generic;
using UnityEngine;
[Serializable]
public class AttributeData{
/// <summary>
/// 属性条ID
/// </summary>
public int AttributeID;
/// <summary>
/// 同类标记
/// </summary>
public int Score;
/// <summary>
/// 品质（字的颜色）
/// </summary>
public int Quality;
/// <summary>
/// 对应的FType
/// </summary>
public int FTypeNum;
/// <summary>
/// 值
/// </summary>
public float Value;
/// <summary>
/// 附带描述
/// </summary>
public string Desc;
/// <summary>
/// 是否显示
/// </summary>
public bool IsShow;
/// <summary>
/// 随机属性描述(随机属性条洗练商人显示）
/// </summary>
public string RandAttrDesc;
public AttributeData(int AttributeID, int Score, int Quality, int FTypeNum, float Value, string Desc, bool IsShow, string RandAttrDesc){
this.AttributeID = AttributeID;
this.Score = Score;
this.Quality = Quality;
this.FTypeNum = FTypeNum;
this.Value = Value;
this.Desc = Desc;
this.IsShow = IsShow;
this.RandAttrDesc = RandAttrDesc;
}
class AttributeDataReader{
static AttributeDataReader instance;
static object syncRoot = new object();
public static AttributeDataReader Instance{get{if (instance == null){lock (syncRoot){if (instance == null){instance = new AttributeDataReader();instance.Load();}}}return instance;}}
Dictionary<int, AttributeData> root = new Dictionary<int, AttributeData>();
void Load(){
root.Add(1, new AttributeData(1, 0, 0, 4, 0.2f, "", false, ""));
root.Add(2, new AttributeData(2, 0, 0, 4, 0.9f, "", false, ""));
root.Add(3, new AttributeData(3, 0, 0, 22, 0.8f, "", false, ""));
root.Add(4, new AttributeData(4, 0, 0, 2, 0.1f, "", false, ""));
root.Add(5, new AttributeData(5, 0, 0, 22, 0.1f, "", false, ""));
root.Add(6, new AttributeData(6, 0, 0, 22, 0.1f, "", false, ""));
root.Add(7, new AttributeData(7, 0, 0, 22, 0.2f, "", false, ""));
root.Add(8, new AttributeData(8, 0, 0, 0, 0f, "", false, ""));
root.Add(9, new AttributeData(9, 0, 0, 0, 0f, "", false, ""));
root.Add(10, new AttributeData(10, 0, 0, 0, 0f, "", false, ""));
root.Add(11, new AttributeData(11, 0, 0, 0, 0f, "", false, ""));
root.Add(12, new AttributeData(12, 0, 0, 0, 0f, "", false, ""));
root.Add(13, new AttributeData(13, 0, 0, 0, 0f, "", false, ""));
root.Add(14, new AttributeData(14, 0, 0, 0, 0f, "", false, ""));
root.Add(15, new AttributeData(15, 0, 0, 0, 0f, "", false, ""));
root.Add(16, new AttributeData(16, 0, 0, 0, 0f, "", false, ""));
root.Add(17, new AttributeData(17, 0, 0, 0, 0f, "", false, ""));
root.Add(18, new AttributeData(18, 0, 0, 0, 0f, "", false, ""));
root.Add(19, new AttributeData(19, 0, 0, 0, 0f, "", false, ""));
root.Add(20, new AttributeData(20, 0, 0, 2, 0.1f, "", false, ""));
root.Add(21, new AttributeData(21, 0, 0, 0, 0f, "", false, ""));
root.Add(22, new AttributeData(22, 0, 0, 0, 0f, "", false, ""));
root.Add(23, new AttributeData(23, 0, 0, 0, 0f, "", false, ""));
root.Add(24, new AttributeData(24, 0, 0, 22, 0.1f, "", false, ""));
root.Add(25, new AttributeData(25, 0, 0, 0, 0f, "", false, ""));
root.Add(26, new AttributeData(26, 0, 0, 0, 0f, "", false, ""));
root.Add(27, new AttributeData(27, 0, 0, 0, 0f, "", false, ""));
root.Add(28, new AttributeData(28, 0, 0, 0, 0f, "", false, ""));
root.Add(29, new AttributeData(29, 0, 0, 2, 0.1f, "", false, ""));
root.Add(30, new AttributeData(30, 0, 0, 22, 0.1f, "", false, ""));
root.Add(31, new AttributeData(31, 0, 0, 0, 0f, "", false, ""));
root.Add(32, new AttributeData(32, 0, 0, 0, 0f, "", false, ""));
root.Add(33, new AttributeData(33, 0, 0, 0, 0f, "", false, ""));
root.Add(34, new AttributeData(34, 0, 0, 0, 0f, "", false, ""));
root.Add(35, new AttributeData(35, 0, 0, 0, 0f, "", false, ""));
root.Add(36, new AttributeData(36, 0, 0, 0, 0f, "", false, ""));
root.Add(37, new AttributeData(37, 0, 0, 0, 0f, "", false, ""));
root.Add(38, new AttributeData(38, 0, 0, 0, 0f, "", false, ""));
root.Add(39, new AttributeData(39, 0, 0, 0, 0f, "", false, ""));
root.Add(40, new AttributeData(40, 0, 0, 0, 0f, "", false, ""));
root.Add(41, new AttributeData(41, 0, 0, 0, 0f, "", false, ""));
root.Add(42, new AttributeData(42, 0, 0, 0, 0f, "", false, ""));
root.Add(43, new AttributeData(43, 0, 0, 0, 0f, "", false, ""));
root.Add(44, new AttributeData(44, 0, 0, 0, 0f, "", false, ""));
root.Add(45, new AttributeData(45, 0, 0, 0, 0f, "", false, ""));
root.Add(46, new AttributeData(46, 0, 0, 0, 0f, "", false, ""));
root.Add(47, new AttributeData(47, 0, 0, 0, 0f, "", false, ""));
root.Add(48, new AttributeData(48, 0, 0, 37, 0.3f, "", false, ""));
root.Add(49, new AttributeData(49, 0, 0, 4, 0.3f, "", false, ""));
root.Add(50, new AttributeData(50, 0, 0, 2, 0.1f, "", false, ""));
root.Add(51, new AttributeData(51, 0, 0, 37, 0.35f, "", false, ""));
root.Add(52, new AttributeData(52, 0, 0, 4, 0.35f, "", false, ""));
root.Add(53, new AttributeData(53, 0, 0, 2, 0.13f, "", false, ""));
root.Add(54, new AttributeData(54, 0, 0, 2, 0.13f, "", false, ""));
root.Add(55, new AttributeData(55, 0, 0, 4, 1f, "", false, ""));
root.Add(56, new AttributeData(56, 0, 0, 0, 0f, "", false, ""));
root.Add(57, new AttributeData(57, 0, 0, 2, 0.1f, "", false, ""));
root.Add(58, new AttributeData(58, 0, 0, 22, 0.05f, "", false, ""));
root.Add(59, new AttributeData(59, 0, 0, 4, 1f, "", false, ""));
root.Add(60, new AttributeData(60, 0, 0, 8, 0.2f, "", false, ""));
root.Add(61, new AttributeData(61, 0, 0, 12, 0.2f, "", false, ""));
root.Add(62, new AttributeData(62, 0, 0, 37, 0.1f, "", false, ""));
root.Add(63, new AttributeData(63, 0, 0, 4, 0.2f, "", false, ""));
}
public AttributeData GetReadData(int ID){
if (root.ContainsKey(ID))
return root[ID];
else{
object obj = MMFramework.ModifyExcelModule.Instance.GetModifyedData(ID);
if (obj != null)return obj as AttributeData;
Debug.LogError("在表格 AttributeData中没有找到ID" + ID);
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
AttributeData data = GetReadData(key);
Type type = data.GetType();
System.Reflection.FieldInfo[] filedinfos = type.GetFields();
for (int i = 0; i < filedinfos.Length; i++)
{System.Reflection.FieldInfo field = filedinfos[i];
pairs.Add(field.Name, field.GetValue(data).ToString());}
return pairs;}
}
public static AttributeData GetData(int ID){
return AttributeDataReader.Instance.GetReadData(ID);
}
public static Dictionary<string, string> GetDictionary(int key)
{ return AttributeDataReader.Instance.GetReadDictionary(key);}
public static int GetNum(){
return AttributeDataReader.Instance.GetCount();
}
public static List<int> GetKeys(){
return AttributeDataReader.Instance.GetDataKeys();
}
public static void SaveToFile(string path){
AttributeDataReader.Instance.WriteToFile(path);
}

}