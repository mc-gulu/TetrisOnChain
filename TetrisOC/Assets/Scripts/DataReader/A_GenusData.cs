using System;
using System.Collections.Generic;
using UnityEngine;
[Serializable]
public class A_GenusData{
public enum StyleEnum{
None,
Value,
Scale,
AttachBuff,
ActiveSkill,
}
/// <summary>
/// 属性类型ID
/// </summary>
public int GenusID;
/// <summary>
/// 描述
/// </summary>
public string Desc;
/// <summary>
/// 洗练描述
/// </summary>
public string DescShort;
/// <summary>
/// 形式
/// </summary>
public StyleEnum Style;
public A_GenusData(int GenusID, string Desc, string DescShort, StyleEnum Style){
this.GenusID = GenusID;
this.Desc = Desc;
this.DescShort = DescShort;
this.Style = Style;
}
class A_GenusDataReader{
static A_GenusDataReader instance;
static object syncRoot = new object();
public static A_GenusDataReader Instance{get{if (instance == null){lock (syncRoot){if (instance == null){instance = new A_GenusDataReader();instance.Load();}}}return instance;}}
Dictionary<int, A_GenusData> root = new Dictionary<int, A_GenusData>();
void Load(){
root.Add(1, new A_GenusData(1, "genus_1", "DescShort_1", StyleEnum.Value));
root.Add(2, new A_GenusData(2, "genus_2", "DescShort_2", StyleEnum.Scale));
root.Add(3, new A_GenusData(3, "genus_3", "DescShort_3", StyleEnum.Scale));
root.Add(4, new A_GenusData(4, "genus_4", "DescShort_4", StyleEnum.Scale));
root.Add(5, new A_GenusData(5, "genus_5", "DescShort_5", StyleEnum.Scale));
root.Add(6, new A_GenusData(6, "genus_6", "DescShort_6", StyleEnum.Scale));
root.Add(7, new A_GenusData(7, "genus_7", "DescShort_7", StyleEnum.Scale));
root.Add(8, new A_GenusData(8, "genus_8", "DescShort_8", StyleEnum.Scale));
root.Add(9, new A_GenusData(9, "genus_9", "DescShort_9", StyleEnum.Scale));
root.Add(10, new A_GenusData(10, "genus_10", "DescShort_10", StyleEnum.Scale));
root.Add(11, new A_GenusData(11, "genus_11", "DescShort_11", StyleEnum.Scale));
root.Add(12, new A_GenusData(12, "genus_12", "DescShort_12", StyleEnum.Scale));
root.Add(13, new A_GenusData(13, "genus_13", "DescShort_13", StyleEnum.Scale));
root.Add(14, new A_GenusData(14, "genus_14", "DescShort_14", StyleEnum.Scale));
root.Add(15, new A_GenusData(15, "genus_15", "DescShort_15", StyleEnum.Scale));
root.Add(16, new A_GenusData(16, "genus_16", "DescShort_16", StyleEnum.Scale));
root.Add(17, new A_GenusData(17, "genus_17", "DescShort_17", StyleEnum.Scale));
root.Add(18, new A_GenusData(18, "genus_18", "DescShort_18", StyleEnum.Scale));
root.Add(19, new A_GenusData(19, "genus_19", "DescShort_19", StyleEnum.Scale));
root.Add(20, new A_GenusData(20, "genus_20", "DescShort_20", StyleEnum.Value));
root.Add(21, new A_GenusData(21, "genus_21", "DescShort_21", StyleEnum.Value));
root.Add(22, new A_GenusData(22, "genus_22", "DescShort_22", StyleEnum.Scale));
root.Add(23, new A_GenusData(23, "genus_23", "DescShort_23", StyleEnum.Scale));
root.Add(24, new A_GenusData(24, "genus_24", "DescShort_24", StyleEnum.Scale));
root.Add(25, new A_GenusData(25, "genus_25", "DescShort_25", StyleEnum.Scale));
root.Add(26, new A_GenusData(26, "genus_26", "DescShort_26", StyleEnum.Scale));
root.Add(27, new A_GenusData(27, "genus_27", "DescShort_27", StyleEnum.Scale));
root.Add(28, new A_GenusData(28, "genus_28", "DescShort_28", StyleEnum.Scale));
root.Add(29, new A_GenusData(29, "genus_29", "DescShort_29", StyleEnum.Scale));
root.Add(30, new A_GenusData(30, "genus_30", "DescShort_30", StyleEnum.Scale));
root.Add(31, new A_GenusData(31, "genus_31", "DescShort_31", StyleEnum.Scale));
root.Add(32, new A_GenusData(32, "genus_32", "DescShort_32", StyleEnum.Scale));
root.Add(33, new A_GenusData(33, "genus_33", "DescShort_33", StyleEnum.Scale));
root.Add(34, new A_GenusData(34, "genus_34", "DescShort_34", StyleEnum.Scale));
root.Add(35, new A_GenusData(35, "genus_35", "DescShort_35", StyleEnum.Scale));
root.Add(36, new A_GenusData(36, "genus_36", "DescShort_36", StyleEnum.Scale));
root.Add(37, new A_GenusData(37, "genus_37", "DescShort_37", StyleEnum.Scale));
root.Add(38, new A_GenusData(38, "genus_38", "DescShort_38", StyleEnum.Scale));
root.Add(39, new A_GenusData(39, "genus_39", "DescShort_39", StyleEnum.Value));
root.Add(40, new A_GenusData(40, "genus_40", "DescShort_40", StyleEnum.Scale));
root.Add(41, new A_GenusData(41, "genus_41", "DescShort_41", StyleEnum.AttachBuff));
root.Add(42, new A_GenusData(42, "genus_42", "DescShort_42", StyleEnum.AttachBuff));
root.Add(43, new A_GenusData(43, "genus_43", "DescShort_43", StyleEnum.AttachBuff));
root.Add(44, new A_GenusData(44, "genus_44", "DescShort_44", StyleEnum.AttachBuff));
root.Add(45, new A_GenusData(45, "genus_45", "DescShort_45", StyleEnum.AttachBuff));
root.Add(46, new A_GenusData(46, "genus_46", "DescShort_46", StyleEnum.ActiveSkill));
root.Add(47, new A_GenusData(47, "genus_47", "DescShort_47", StyleEnum.ActiveSkill));
root.Add(48, new A_GenusData(48, "genus_48", "DescShort_48", StyleEnum.ActiveSkill));
root.Add(49, new A_GenusData(49, "genus_49", "DescShort_49", StyleEnum.None));
root.Add(50, new A_GenusData(50, "genus_50", "DescShort_50", StyleEnum.None));
}
public A_GenusData GetReadData(int ID){
if (root.ContainsKey(ID))
return root[ID];
else{
object obj = MMFramework.ModifyExcelModule.Instance.GetModifyedData(ID);
if (obj != null)return obj as A_GenusData;
Debug.LogError("在表格 A_GenusData中没有找到ID" + ID);
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
A_GenusData data = GetReadData(key);
Type type = data.GetType();
System.Reflection.FieldInfo[] filedinfos = type.GetFields();
for (int i = 0; i < filedinfos.Length; i++)
{System.Reflection.FieldInfo field = filedinfos[i];
pairs.Add(field.Name, field.GetValue(data).ToString());}
return pairs;}
}
public static A_GenusData GetData(int ID){
return A_GenusDataReader.Instance.GetReadData(ID);
}
public static Dictionary<string, string> GetDictionary(int key)
{ return A_GenusDataReader.Instance.GetReadDictionary(key);}
public static int GetNum(){
return A_GenusDataReader.Instance.GetCount();
}
public static List<int> GetKeys(){
return A_GenusDataReader.Instance.GetDataKeys();
}
public static void SaveToFile(string path){
A_GenusDataReader.Instance.WriteToFile(path);
}

}