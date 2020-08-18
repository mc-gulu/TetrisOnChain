using System;
using System.Collections.Generic;
using UnityEngine;
[Serializable]
public class RandomData{
/// <summary>
/// 随机ID
/// </summary>
public int RandomID;
/// <summary>
/// ID
/// </summary>
public int[] IDArray;
/// <summary>
/// 概率
/// </summary>
public float[] PArray;
public RandomData(int RandomID, int[] IDArray, float[] PArray){
this.RandomID = RandomID;
this.IDArray = IDArray;
this.PArray = PArray;
}
class RandomDataReader{
static RandomDataReader instance;
static object syncRoot = new object();
public static RandomDataReader Instance{get{if (instance == null){lock (syncRoot){if (instance == null){instance = new RandomDataReader();instance.Load();}}}return instance;}}
Dictionary<int, RandomData> root = new Dictionary<int, RandomData>();
void Load(){
root.Add(41001, new RandomData(41001, new int[] {41002, 41003, 0, 0, 0, 0, 0, 0, 0, 0}, new float[] {0.7f, 0.3f, 0f, 0f, 0f, 0f, 0f, 0f, 0f, 0f}));
root.Add(41002, new RandomData(41002, new int[] {600101, 600202, 600301, 0, 0, 0, 0, 0, 0, 0}, new float[] {1f, 1f, 1f, 0f, 0f, 0f, 0f, 0f, 0f, 0f}));
root.Add(41003, new RandomData(41003, new int[] {601111, 601211, 601311, 0, 0, 0, 0, 0, 0, 0}, new float[] {1f, 1f, 1f, 0f, 0f, 0f, 0f, 0f, 0f, 0f}));
root.Add(41004, new RandomData(41004, new int[] {41012, 41013, 41014, 41015, 0, 0, 0, 0, 0, 0}, new float[] {0.8f, 0.15f, 0f, 0f, 0f, 0f, 0f, 0f, 0f, 0f}));
root.Add(41005, new RandomData(41005, new int[] {41012, 41013, 41014, 41015, 0, 0, 0, 0, 0, 0}, new float[] {0f, 0f, 0.03f, 0.02f, 0f, 0f, 0f, 0f, 0f, 0f}));
root.Add(41012, new RandomData(41012, new int[] {41016, 41017, 41018, 41019, 0, 0, 0, 0, 0, 0}, new float[] {1f, 1f, 1f, 1f, 0f, 0f, 0f, 0f, 0f, 0f}));
root.Add(41013, new RandomData(41013, new int[] {41020, 41021, 41022, 41023, 0, 0, 0, 0, 0, 0}, new float[] {1f, 1f, 1f, 1f, 0f, 0f, 0f, 0f, 0f, 0f}));
root.Add(41014, new RandomData(41014, new int[] {41024, 41025, 41026, 41027, 0, 0, 0, 0, 0, 0}, new float[] {1f, 1f, 1f, 1f, 0f, 0f, 0f, 0f, 0f, 0f}));
root.Add(41015, new RandomData(41015, new int[] {41028, 41029, 41030, 41031, 0, 0, 0, 0, 0, 0}, new float[] {1f, 1f, 1f, 1f, 0f, 0f, 0f, 0f, 0f, 0f}));
root.Add(41016, new RandomData(41016, new int[] {600103, 600203, 600703, 600803, 601003, 601203, 601303, 0, 0, 0}, new float[] {1f, 1f, 1f, 1f, 1f, 1f, 1f, 0f, 0f, 0f}));
root.Add(41017, new RandomData(41017, new int[] {601503, 601603, 601703, 601903, 602203, 602303, 602603, 0, 0, 0}, new float[] {1f, 1f, 1f, 1f, 1f, 1f, 1f, 0f, 0f, 0f}));
root.Add(41018, new RandomData(41018, new int[] {602903, 603003, 603103, 603703, 603803, 604003, 604403, 0, 0, 0}, new float[] {1f, 1f, 1f, 1f, 1f, 1f, 1f, 0f, 0f, 0f}));
root.Add(41019, new RandomData(41019, new int[] {604503, 604703, 0, 0, 0, 0, 0, 0, 0, 0}, new float[] {1f, 1f, 0f, 0f, 0f, 0f, 0f, 0f, 0f, 0f}));
root.Add(41020, new RandomData(41020, new int[] {600104, 600204, 600704, 600804, 601004, 601204, 601304, 0, 0, 0}, new float[] {1f, 1f, 1f, 1f, 1f, 1f, 1f, 0f, 0f, 0f}));
root.Add(41021, new RandomData(41021, new int[] {601504, 601604, 601704, 601904, 602204, 602304, 602604, 0, 0, 0}, new float[] {1f, 1f, 1f, 1f, 1f, 1f, 1f, 0f, 0f, 0f}));
root.Add(41022, new RandomData(41022, new int[] {602904, 603004, 603104, 603704, 603804, 604004, 604404, 0, 0, 0}, new float[] {1f, 1f, 1f, 1f, 1f, 1f, 1f, 0f, 0f, 0f}));
root.Add(41023, new RandomData(41023, new int[] {604504, 604704, 0, 0, 0, 0, 0, 0, 0, 0}, new float[] {1f, 1f, 0f, 0f, 0f, 0f, 0f, 0f, 0f, 0f}));
root.Add(41024, new RandomData(41024, new int[] {600105, 600205, 600705, 600805, 601005, 601205, 601305, 0, 0, 0}, new float[] {1f, 1f, 1f, 1f, 1f, 1f, 1f, 0f, 0f, 0f}));
root.Add(41025, new RandomData(41025, new int[] {601505, 601605, 601705, 601905, 602205, 602305, 602605, 0, 0, 0}, new float[] {1f, 1f, 1f, 1f, 1f, 1f, 1f, 0f, 0f, 0f}));
root.Add(41026, new RandomData(41026, new int[] {602905, 603005, 603105, 603705, 603805, 604005, 604405, 0, 0, 0}, new float[] {1f, 1f, 1f, 1f, 1f, 1f, 1f, 0f, 0f, 0f}));
root.Add(41027, new RandomData(41027, new int[] {604505, 604705, 0, 0, 0, 0, 0, 0, 0, 0}, new float[] {1f, 1f, 0f, 0f, 0f, 0f, 0f, 0f, 0f, 0f}));
root.Add(41028, new RandomData(41028, new int[] {600106, 600206, 600706, 600806, 601006, 601206, 601306, 0, 0, 0}, new float[] {1f, 1f, 1f, 1f, 1f, 1f, 1f, 0f, 0f, 0f}));
root.Add(41029, new RandomData(41029, new int[] {601506, 601606, 601706, 601906, 602206, 602306, 602606, 0, 0, 0}, new float[] {1f, 1f, 1f, 1f, 1f, 1f, 1f, 0f, 0f, 0f}));
root.Add(41030, new RandomData(41030, new int[] {602906, 603006, 603106, 603706, 603806, 604006, 604406, 0, 0, 0}, new float[] {1f, 1f, 1f, 1f, 1f, 1f, 1f, 0f, 0f, 0f}));
root.Add(41031, new RandomData(41031, new int[] {604506, 604706, 0, 0, 0, 0, 0, 0, 0, 0}, new float[] {1f, 1f, 0f, 0f, 0f, 0f, 0f, 0f, 0f, 0f}));
root.Add(41032, new RandomData(41032, new int[] {0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, new float[] {0f, 0f, 0f, 0f, 0f, 0f, 0f, 0f, 0f, 0f}));
root.Add(41033, new RandomData(41033, new int[] {0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, new float[] {0f, 0f, 0f, 0f, 0f, 0f, 0f, 0f, 0f, 0f}));
root.Add(41034, new RandomData(41034, new int[] {0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, new float[] {0f, 0f, 0f, 0f, 0f, 0f, 0f, 0f, 0f, 0f}));
root.Add(41035, new RandomData(41035, new int[] {0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, new float[] {0f, 0f, 0f, 0f, 0f, 0f, 0f, 0f, 0f, 0f}));
root.Add(42001, new RandomData(42001, new int[] {42002, 42003, 0, 0, 0, 0, 0, 0, 0, 0}, new float[] {1f, 1f, 0f, 0f, 0f, 0f, 0f, 0f, 0f, 0f}));
root.Add(42002, new RandomData(42002, new int[] {8001, 8002, 0, 0, 0, 0, 0, 0, 0, 0}, new float[] {1f, 1f, 0f, 0f, 0f, 0f, 0f, 0f, 0f, 0f}));
root.Add(42003, new RandomData(42003, new int[] {8003, 8004, 0, 0, 0, 0, 0, 0, 0, 0}, new float[] {1f, 1f, 0f, 0f, 0f, 0f, 0f, 0f, 0f, 0f}));
}
public RandomData GetReadData(int ID){
if (root.ContainsKey(ID))
return root[ID];
else{
object obj = MMFramework.ModifyExcelModule.Instance.GetModifyedData(ID);
if (obj != null)return obj as RandomData;
Debug.LogError("在表格 RandomData中没有找到ID" + ID);
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
RandomData data = GetReadData(key);
Type type = data.GetType();
System.Reflection.FieldInfo[] filedinfos = type.GetFields();
for (int i = 0; i < filedinfos.Length; i++)
{System.Reflection.FieldInfo field = filedinfos[i];
pairs.Add(field.Name, field.GetValue(data).ToString());}
return pairs;}
}
public static RandomData GetData(int ID){
return RandomDataReader.Instance.GetReadData(ID);
}
public static Dictionary<string, string> GetDictionary(int key)
{ return RandomDataReader.Instance.GetReadDictionary(key);}
public static int GetNum(){
return RandomDataReader.Instance.GetCount();
}
public static List<int> GetKeys(){
return RandomDataReader.Instance.GetDataKeys();
}
public static void SaveToFile(string path){
RandomDataReader.Instance.WriteToFile(path);
}

}