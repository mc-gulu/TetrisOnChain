using System;
using System.Collections.Generic;
using UnityEngine;
[Serializable]
public class A_AttachBuffData{
/// <summary>
/// 子弹附加给对象Buff的行为ID
/// </summary>
public int AttachBuffID;
/// <summary>
/// 概率
/// </summary>
public float Percent;
/// <summary>
/// BuffID
/// </summary>
public int BuffID;
public A_AttachBuffData(int AttachBuffID, float Percent, int BuffID){
this.AttachBuffID = AttachBuffID;
this.Percent = Percent;
this.BuffID = BuffID;
}
class A_AttachBuffDataReader{
static A_AttachBuffDataReader instance;
static object syncRoot = new object();
public static A_AttachBuffDataReader Instance{get{if (instance == null){lock (syncRoot){if (instance == null){instance = new A_AttachBuffDataReader();instance.Load();}}}return instance;}}
Dictionary<int, A_AttachBuffData> root = new Dictionary<int, A_AttachBuffData>();
void Load(){
root.Add(1, new A_AttachBuffData(1, 1f, 1001));
root.Add(2, new A_AttachBuffData(2, 1f, 1002));
root.Add(3, new A_AttachBuffData(3, 1f, 1004));
root.Add(4, new A_AttachBuffData(4, 1f, 1010));
root.Add(5, new A_AttachBuffData(5, 1f, 1011));
root.Add(6, new A_AttachBuffData(6, 1f, 1012));
root.Add(7, new A_AttachBuffData(7, 1f, 0));
root.Add(8, new A_AttachBuffData(8, 1f, 1013));
root.Add(9, new A_AttachBuffData(9, 1f, 0));
root.Add(10, new A_AttachBuffData(10, 1f, 0));
root.Add(11, new A_AttachBuffData(11, 1f, 0));
root.Add(12, new A_AttachBuffData(12, 1f, 0));
root.Add(13, new A_AttachBuffData(13, 1f, 0));
root.Add(14, new A_AttachBuffData(14, 1f, 0));
root.Add(15, new A_AttachBuffData(15, 1f, 0));
root.Add(16, new A_AttachBuffData(16, 1f, 0));
root.Add(17, new A_AttachBuffData(17, 1f, 0));
root.Add(18, new A_AttachBuffData(18, 1f, 0));
root.Add(19, new A_AttachBuffData(19, 1f, 0));
root.Add(20, new A_AttachBuffData(20, 1f, 0));
root.Add(21, new A_AttachBuffData(21, 1f, 1017));
root.Add(22, new A_AttachBuffData(22, 1f, 1018));
root.Add(23, new A_AttachBuffData(23, 1f, 1019));
root.Add(24, new A_AttachBuffData(24, 1f, 1020));
root.Add(25, new A_AttachBuffData(25, 1f, 1021));
root.Add(26, new A_AttachBuffData(26, 1f, 1022));
root.Add(27, new A_AttachBuffData(27, 1f, 1023));
root.Add(28, new A_AttachBuffData(28, 1f, 1024));
root.Add(29, new A_AttachBuffData(29, 1f, 1025));
root.Add(30, new A_AttachBuffData(30, 1f, 1026));
root.Add(31, new A_AttachBuffData(31, 1f, 1027));
root.Add(32, new A_AttachBuffData(32, 1f, 1028));
root.Add(33, new A_AttachBuffData(33, 1f, 0));
root.Add(34, new A_AttachBuffData(34, 1f, 0));
root.Add(35, new A_AttachBuffData(35, 1f, 0));
root.Add(36, new A_AttachBuffData(36, 1f, 0));
root.Add(37, new A_AttachBuffData(37, 1f, 0));
root.Add(38, new A_AttachBuffData(38, 1f, 0));
root.Add(39, new A_AttachBuffData(39, 1f, 0));
root.Add(40, new A_AttachBuffData(40, 1f, 0));
root.Add(41, new A_AttachBuffData(41, 1f, 0));
root.Add(42, new A_AttachBuffData(42, 1f, 0));
root.Add(43, new A_AttachBuffData(43, 1f, 0));
root.Add(44, new A_AttachBuffData(44, 1f, 0));
root.Add(45, new A_AttachBuffData(45, 1f, 0));
root.Add(46, new A_AttachBuffData(46, 1f, 0));
root.Add(47, new A_AttachBuffData(47, 1f, 1012));
root.Add(48, new A_AttachBuffData(48, 1f, 0));
root.Add(49, new A_AttachBuffData(49, 1f, 0));
root.Add(50, new A_AttachBuffData(50, 1f, 1031));
root.Add(51, new A_AttachBuffData(51, 1f, 1032));
root.Add(52, new A_AttachBuffData(52, 1f, 1033));
root.Add(53, new A_AttachBuffData(53, 1f, 1034));
root.Add(54, new A_AttachBuffData(54, 1f, 1035));
root.Add(55, new A_AttachBuffData(55, 1f, 1036));
root.Add(56, new A_AttachBuffData(56, 1f, 1037));
root.Add(57, new A_AttachBuffData(57, 1f, 1038));
root.Add(58, new A_AttachBuffData(58, 1f, 1039));
root.Add(59, new A_AttachBuffData(59, 1f, 1040));
root.Add(60, new A_AttachBuffData(60, 1f, 1041));
root.Add(61, new A_AttachBuffData(61, 1f, 1042));
root.Add(62, new A_AttachBuffData(62, 1f, 1046));
root.Add(63, new A_AttachBuffData(63, 1f, 1047));
}
public A_AttachBuffData GetReadData(int ID){
if (root.ContainsKey(ID))
return root[ID];
else{
object obj = MMFramework.ModifyExcelModule.Instance.GetModifyedData(ID);
if (obj != null)return obj as A_AttachBuffData;
Debug.LogError("在表格 A_AttachBuffData中没有找到ID" + ID);
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
A_AttachBuffData data = GetReadData(key);
Type type = data.GetType();
System.Reflection.FieldInfo[] filedinfos = type.GetFields();
for (int i = 0; i < filedinfos.Length; i++)
{System.Reflection.FieldInfo field = filedinfos[i];
pairs.Add(field.Name, field.GetValue(data).ToString());}
return pairs;}
}
public static A_AttachBuffData GetData(int ID){
return A_AttachBuffDataReader.Instance.GetReadData(ID);
}
public static Dictionary<string, string> GetDictionary(int key)
{ return A_AttachBuffDataReader.Instance.GetReadDictionary(key);}
public static int GetNum(){
return A_AttachBuffDataReader.Instance.GetCount();
}
public static List<int> GetKeys(){
return A_AttachBuffDataReader.Instance.GetDataKeys();
}
public static void SaveToFile(string path){
A_AttachBuffDataReader.Instance.WriteToFile(path);
}

}