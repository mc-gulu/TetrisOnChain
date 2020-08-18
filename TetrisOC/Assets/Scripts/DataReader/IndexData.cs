using System;
using System.Collections.Generic;
using UnityEngine;
[Serializable]
public class IndexData{
/// <summary>
/// 序列ID
/// </summary>
public int IndexID;
/// <summary>
/// ID平原（themeData）
/// </summary>
public int[] IDArray;
public IndexData(int IndexID, int[] IDArray){
this.IndexID = IndexID;
this.IDArray = IDArray;
}
class IndexDataReader{
static IndexDataReader instance;
static object syncRoot = new object();
public static IndexDataReader Instance{get{if (instance == null){lock (syncRoot){if (instance == null){instance = new IndexDataReader();instance.Load();}}}return instance;}}
Dictionary<int, IndexData> root = new Dictionary<int, IndexData>();
void Load(){
root.Add(44001, new IndexData(44001, new int[] {6300, 6305, 6300}));
root.Add(44002, new IndexData(44002, new int[] {6301, 6306, 6301}));
root.Add(44003, new IndexData(44003, new int[] {6302, 6307, 6302}));
root.Add(44004, new IndexData(44004, new int[] {6303, 6308, 6303}));
root.Add(44005, new IndexData(44005, new int[] {6303, 6304, 6304}));
root.Add(44006, new IndexData(44006, new int[] {0, 0, 0}));
root.Add(44007, new IndexData(44007, new int[] {0, 0, 0}));
root.Add(44008, new IndexData(44008, new int[] {0, 0, 0}));
root.Add(44009, new IndexData(44009, new int[] {0, 0, 0}));
root.Add(44010, new IndexData(44010, new int[] {0, 0, 0}));
root.Add(44011, new IndexData(44011, new int[] {0, 0, 0}));
root.Add(44012, new IndexData(44012, new int[] {0, 0, 0}));
root.Add(45001, new IndexData(45001, new int[] {34001, 34001, 34002}));
root.Add(45002, new IndexData(45002, new int[] {34001, 34001, 34002}));
root.Add(45003, new IndexData(45003, new int[] {34001, 34001, 34002}));
root.Add(45004, new IndexData(45004, new int[] {34001, 34001, 34002}));
root.Add(45005, new IndexData(45005, new int[] {34001, 34001, 34002}));
root.Add(45006, new IndexData(45006, new int[] {34001, 34001, 34002}));
root.Add(45007, new IndexData(45007, new int[] {34001, 34001, 34002}));
root.Add(45008, new IndexData(45008, new int[] {34001, 34001, 34002}));
root.Add(45009, new IndexData(45009, new int[] {34001, 34001, 34002}));
root.Add(45010, new IndexData(45010, new int[] {34001, 34001, 34002}));
root.Add(45011, new IndexData(45011, new int[] {34001, 34001, 34002}));
root.Add(45012, new IndexData(45012, new int[] {34001, 34001, 34002}));
root.Add(45013, new IndexData(45013, new int[] {34001, 34001, 34002}));
root.Add(45014, new IndexData(45014, new int[] {34001, 34001, 34002}));
root.Add(45015, new IndexData(45015, new int[] {34001, 34001, 34002}));
root.Add(45016, new IndexData(45016, new int[] {34001, 34001, 34002}));
root.Add(45017, new IndexData(45017, new int[] {34001, 34001, 34002}));
root.Add(45018, new IndexData(45018, new int[] {34001, 34001, 34002}));
root.Add(45019, new IndexData(45019, new int[] {34001, 34001, 34002}));
root.Add(45020, new IndexData(45020, new int[] {34001, 34001, 34002}));
root.Add(45021, new IndexData(45021, new int[] {34001, 34001, 34002}));
root.Add(45022, new IndexData(45022, new int[] {34001, 34001, 34002}));
root.Add(45023, new IndexData(45023, new int[] {34001, 34001, 34002}));
root.Add(45024, new IndexData(45024, new int[] {34001, 34001, 34002}));
root.Add(45025, new IndexData(45025, new int[] {34001, 34001, 34002}));
root.Add(45026, new IndexData(45026, new int[] {34001, 34001, 34002}));
root.Add(45027, new IndexData(45027, new int[] {34001, 34001, 34002}));
root.Add(45028, new IndexData(45028, new int[] {34001, 34001, 34002}));
root.Add(45029, new IndexData(45029, new int[] {34001, 34001, 34002}));
root.Add(45030, new IndexData(45030, new int[] {34001, 34001, 34002}));
root.Add(45031, new IndexData(45031, new int[] {34001, 34001, 34002}));
root.Add(45032, new IndexData(45032, new int[] {34001, 34001, 34002}));
root.Add(45033, new IndexData(45033, new int[] {34001, 34001, 34002}));
root.Add(45034, new IndexData(45034, new int[] {34001, 34001, 34002}));
root.Add(45035, new IndexData(45035, new int[] {34001, 34001, 34002}));
root.Add(45036, new IndexData(45036, new int[] {34001, 34001, 34002}));
root.Add(45037, new IndexData(45037, new int[] {34001, 34001, 34002}));
root.Add(45038, new IndexData(45038, new int[] {34001, 34001, 34002}));
root.Add(45039, new IndexData(45039, new int[] {34001, 34001, 34002}));
root.Add(45040, new IndexData(45040, new int[] {34001, 34001, 34002}));
root.Add(45041, new IndexData(45041, new int[] {34001, 34001, 34002}));
root.Add(45042, new IndexData(45042, new int[] {34001, 34001, 34002}));
root.Add(45043, new IndexData(45043, new int[] {34001, 34001, 34002}));
root.Add(45044, new IndexData(45044, new int[] {34001, 34001, 34002}));
root.Add(45045, new IndexData(45045, new int[] {34001, 34001, 34002}));
root.Add(45046, new IndexData(45046, new int[] {34001, 34001, 34002}));
root.Add(45047, new IndexData(45047, new int[] {34001, 34001, 34002}));
root.Add(45048, new IndexData(45048, new int[] {34001, 34001, 34002}));
root.Add(45049, new IndexData(45049, new int[] {34001, 34001, 34002}));
root.Add(45050, new IndexData(45050, new int[] {34001, 34001, 34002}));
root.Add(45051, new IndexData(45051, new int[] {34001, 34001, 34002}));
root.Add(45052, new IndexData(45052, new int[] {34001, 34001, 34002}));
root.Add(45053, new IndexData(45053, new int[] {34001, 34001, 34002}));
root.Add(45054, new IndexData(45054, new int[] {34001, 34001, 34002}));
root.Add(45055, new IndexData(45055, new int[] {34001, 34001, 34002}));
root.Add(45056, new IndexData(45056, new int[] {34001, 34001, 34002}));
root.Add(45057, new IndexData(45057, new int[] {34001, 34001, 34002}));
root.Add(45058, new IndexData(45058, new int[] {34001, 34001, 34002}));
root.Add(45059, new IndexData(45059, new int[] {34001, 34001, 34002}));
root.Add(45060, new IndexData(45060, new int[] {34001, 34001, 34002}));
root.Add(45061, new IndexData(45061, new int[] {34001, 34001, 34002}));
root.Add(45062, new IndexData(45062, new int[] {34001, 34001, 34002}));
root.Add(45063, new IndexData(45063, new int[] {34001, 34001, 34002}));
root.Add(45064, new IndexData(45064, new int[] {34001, 34001, 34002}));
root.Add(45065, new IndexData(45065, new int[] {34001, 34001, 34002}));
root.Add(45066, new IndexData(45066, new int[] {34001, 34001, 34002}));
root.Add(45067, new IndexData(45067, new int[] {34001, 34001, 34002}));
root.Add(45068, new IndexData(45068, new int[] {34001, 34001, 34002}));
root.Add(45069, new IndexData(45069, new int[] {34001, 34001, 34002}));
root.Add(45070, new IndexData(45070, new int[] {34001, 34001, 34002}));
root.Add(45071, new IndexData(45071, new int[] {34001, 34001, 34002}));
root.Add(45072, new IndexData(45072, new int[] {34001, 34001, 34002}));
root.Add(45073, new IndexData(45073, new int[] {34001, 34001, 34002}));
root.Add(45074, new IndexData(45074, new int[] {34001, 34001, 34002}));
root.Add(45075, new IndexData(45075, new int[] {34001, 34001, 34002}));
root.Add(45076, new IndexData(45076, new int[] {34001, 34001, 34002}));
root.Add(45077, new IndexData(45077, new int[] {34001, 34001, 34002}));
root.Add(45078, new IndexData(45078, new int[] {34001, 34001, 34002}));
root.Add(45079, new IndexData(45079, new int[] {34001, 34001, 34002}));
root.Add(45080, new IndexData(45080, new int[] {34001, 34001, 34002}));
root.Add(45081, new IndexData(45081, new int[] {34001, 34001, 34002}));
root.Add(45082, new IndexData(45082, new int[] {34001, 34001, 34002}));
root.Add(45083, new IndexData(45083, new int[] {34001, 34001, 34002}));
root.Add(45084, new IndexData(45084, new int[] {34001, 34001, 34002}));
root.Add(45085, new IndexData(45085, new int[] {34001, 34001, 34002}));
root.Add(45086, new IndexData(45086, new int[] {34001, 34001, 34002}));
root.Add(45087, new IndexData(45087, new int[] {34001, 34001, 34002}));
root.Add(45088, new IndexData(45088, new int[] {34001, 34001, 34002}));
root.Add(45089, new IndexData(45089, new int[] {34001, 34001, 34002}));
root.Add(45090, new IndexData(45090, new int[] {34001, 34001, 34002}));
root.Add(45091, new IndexData(45091, new int[] {34001, 34001, 34002}));
root.Add(45092, new IndexData(45092, new int[] {34001, 34001, 34002}));
root.Add(45093, new IndexData(45093, new int[] {34001, 34001, 34002}));
root.Add(45094, new IndexData(45094, new int[] {34001, 34001, 34002}));
root.Add(45095, new IndexData(45095, new int[] {34001, 34001, 34002}));
root.Add(45096, new IndexData(45096, new int[] {34001, 34001, 34002}));
root.Add(45097, new IndexData(45097, new int[] {34001, 34001, 34002}));
root.Add(45098, new IndexData(45098, new int[] {34001, 34001, 34002}));
root.Add(45099, new IndexData(45099, new int[] {34001, 34001, 34002}));
root.Add(45100, new IndexData(45100, new int[] {34001, 34001, 34002}));
root.Add(45101, new IndexData(45101, new int[] {34001, 34001, 34002}));
root.Add(45102, new IndexData(45102, new int[] {34001, 34001, 34002}));
root.Add(45103, new IndexData(45103, new int[] {34001, 34001, 34002}));
root.Add(45104, new IndexData(45104, new int[] {34001, 34001, 34002}));
root.Add(45105, new IndexData(45105, new int[] {34001, 34001, 34002}));
root.Add(45106, new IndexData(45106, new int[] {34001, 34001, 34002}));
root.Add(45107, new IndexData(45107, new int[] {34001, 34001, 34002}));
root.Add(45108, new IndexData(45108, new int[] {34001, 34001, 34002}));
root.Add(45109, new IndexData(45109, new int[] {34001, 34001, 34002}));
root.Add(45110, new IndexData(45110, new int[] {34001, 34001, 34002}));
root.Add(45111, new IndexData(45111, new int[] {34001, 34001, 34002}));
root.Add(45112, new IndexData(45112, new int[] {34001, 34001, 34002}));
root.Add(45113, new IndexData(45113, new int[] {34001, 34001, 34002}));
root.Add(45114, new IndexData(45114, new int[] {34001, 34001, 34002}));
root.Add(45115, new IndexData(45115, new int[] {34001, 34001, 34002}));
root.Add(45116, new IndexData(45116, new int[] {34001, 34001, 34002}));
root.Add(45117, new IndexData(45117, new int[] {34001, 34001, 34002}));
root.Add(45118, new IndexData(45118, new int[] {34001, 34001, 34002}));
root.Add(45119, new IndexData(45119, new int[] {34001, 34001, 34002}));
root.Add(45120, new IndexData(45120, new int[] {34001, 34001, 34002}));
root.Add(45121, new IndexData(45121, new int[] {34001, 34001, 34002}));
root.Add(45122, new IndexData(45122, new int[] {34001, 34001, 34002}));
root.Add(45123, new IndexData(45123, new int[] {34001, 34001, 34002}));
root.Add(45124, new IndexData(45124, new int[] {34001, 34001, 34002}));
root.Add(45125, new IndexData(45125, new int[] {34001, 34001, 34002}));
root.Add(45126, new IndexData(45126, new int[] {34001, 34001, 34002}));
root.Add(45127, new IndexData(45127, new int[] {34001, 34001, 34002}));
root.Add(45128, new IndexData(45128, new int[] {34001, 34001, 34002}));
root.Add(45129, new IndexData(45129, new int[] {34001, 34001, 34002}));
root.Add(45130, new IndexData(45130, new int[] {34001, 34001, 34002}));
root.Add(45131, new IndexData(45131, new int[] {34001, 34001, 34002}));
root.Add(45132, new IndexData(45132, new int[] {34001, 34001, 34002}));
root.Add(45133, new IndexData(45133, new int[] {34001, 34001, 34002}));
root.Add(45134, new IndexData(45134, new int[] {34001, 34001, 34002}));
root.Add(45135, new IndexData(45135, new int[] {34001, 34001, 34002}));
root.Add(45136, new IndexData(45136, new int[] {34001, 34001, 34002}));
root.Add(45137, new IndexData(45137, new int[] {34001, 34001, 34002}));
root.Add(45138, new IndexData(45138, new int[] {34001, 34001, 34002}));
root.Add(45139, new IndexData(45139, new int[] {34001, 34001, 34002}));
root.Add(45140, new IndexData(45140, new int[] {34001, 34001, 34002}));
root.Add(45141, new IndexData(45141, new int[] {34001, 34001, 34002}));
root.Add(45142, new IndexData(45142, new int[] {34001, 34001, 34002}));
root.Add(45143, new IndexData(45143, new int[] {34001, 34001, 34002}));
root.Add(45144, new IndexData(45144, new int[] {34001, 34001, 34002}));
root.Add(45145, new IndexData(45145, new int[] {34001, 34001, 34002}));
root.Add(45146, new IndexData(45146, new int[] {34001, 34001, 34002}));
root.Add(45147, new IndexData(45147, new int[] {34001, 34001, 34002}));
root.Add(45148, new IndexData(45148, new int[] {34001, 34001, 34002}));
root.Add(45149, new IndexData(45149, new int[] {34001, 34001, 34002}));
root.Add(45150, new IndexData(45150, new int[] {34001, 34001, 34002}));
root.Add(45151, new IndexData(45151, new int[] {34001, 34001, 34002}));
root.Add(45152, new IndexData(45152, new int[] {34001, 34001, 34002}));
root.Add(45153, new IndexData(45153, new int[] {34001, 34001, 34002}));
root.Add(45154, new IndexData(45154, new int[] {34001, 34001, 34002}));
root.Add(45155, new IndexData(45155, new int[] {34001, 34001, 34002}));
root.Add(45156, new IndexData(45156, new int[] {34001, 34001, 34002}));
root.Add(45157, new IndexData(45157, new int[] {34001, 34001, 34002}));
root.Add(45158, new IndexData(45158, new int[] {34001, 34001, 34002}));
root.Add(45159, new IndexData(45159, new int[] {34001, 34001, 34002}));
root.Add(45160, new IndexData(45160, new int[] {34001, 34001, 34002}));
root.Add(45161, new IndexData(45161, new int[] {34001, 34001, 34002}));
root.Add(45162, new IndexData(45162, new int[] {34001, 34001, 34002}));
root.Add(45163, new IndexData(45163, new int[] {34001, 34001, 34002}));
root.Add(45164, new IndexData(45164, new int[] {34001, 34001, 34002}));
root.Add(45165, new IndexData(45165, new int[] {34001, 34001, 34002}));
root.Add(45166, new IndexData(45166, new int[] {34001, 34001, 34002}));
root.Add(45167, new IndexData(45167, new int[] {34001, 34001, 34002}));
root.Add(45168, new IndexData(45168, new int[] {34001, 34001, 34002}));
root.Add(45169, new IndexData(45169, new int[] {34001, 34001, 34002}));
root.Add(45170, new IndexData(45170, new int[] {34001, 34001, 34002}));
root.Add(45171, new IndexData(45171, new int[] {34001, 34001, 34002}));
root.Add(45172, new IndexData(45172, new int[] {34001, 34001, 34002}));
root.Add(45173, new IndexData(45173, new int[] {34001, 34001, 34002}));
root.Add(45174, new IndexData(45174, new int[] {34001, 34001, 34002}));
root.Add(45175, new IndexData(45175, new int[] {34001, 34001, 34002}));
root.Add(45176, new IndexData(45176, new int[] {34001, 34001, 34002}));
root.Add(45177, new IndexData(45177, new int[] {34001, 34001, 34002}));
root.Add(45178, new IndexData(45178, new int[] {34001, 34001, 34002}));
root.Add(45179, new IndexData(45179, new int[] {34001, 34001, 34002}));
root.Add(45180, new IndexData(45180, new int[] {34001, 34001, 34002}));
root.Add(45181, new IndexData(45181, new int[] {34001, 34001, 34002}));
root.Add(45182, new IndexData(45182, new int[] {34001, 34001, 34002}));
root.Add(45183, new IndexData(45183, new int[] {34001, 34001, 34002}));
root.Add(45184, new IndexData(45184, new int[] {34001, 34001, 34002}));
root.Add(45185, new IndexData(45185, new int[] {34001, 34001, 34002}));
root.Add(45186, new IndexData(45186, new int[] {34001, 34001, 34002}));
root.Add(45187, new IndexData(45187, new int[] {34001, 34001, 34002}));
root.Add(45188, new IndexData(45188, new int[] {34001, 34001, 34002}));
root.Add(45189, new IndexData(45189, new int[] {34001, 34001, 34002}));
root.Add(45190, new IndexData(45190, new int[] {34001, 34001, 34002}));
root.Add(45191, new IndexData(45191, new int[] {34001, 34001, 34002}));
root.Add(45192, new IndexData(45192, new int[] {34001, 34001, 34002}));
root.Add(45193, new IndexData(45193, new int[] {34001, 34001, 34002}));
root.Add(45194, new IndexData(45194, new int[] {34001, 34001, 34002}));
root.Add(45195, new IndexData(45195, new int[] {34001, 34001, 34002}));
root.Add(45196, new IndexData(45196, new int[] {34001, 34001, 34002}));
root.Add(45197, new IndexData(45197, new int[] {34001, 34001, 34002}));
root.Add(45198, new IndexData(45198, new int[] {34001, 34001, 34002}));
root.Add(45199, new IndexData(45199, new int[] {34001, 34001, 34002}));
root.Add(45200, new IndexData(45200, new int[] {34001, 34001, 34002}));
root.Add(45201, new IndexData(45201, new int[] {34001, 34001, 34002}));
root.Add(45202, new IndexData(45202, new int[] {34001, 34001, 34002}));
root.Add(45203, new IndexData(45203, new int[] {34001, 34001, 34002}));
root.Add(45204, new IndexData(45204, new int[] {34001, 34001, 34002}));
root.Add(45205, new IndexData(45205, new int[] {34001, 34001, 34002}));
root.Add(45206, new IndexData(45206, new int[] {34001, 34001, 34002}));
root.Add(45207, new IndexData(45207, new int[] {34001, 34001, 34002}));
root.Add(45208, new IndexData(45208, new int[] {34001, 34001, 34002}));
root.Add(45209, new IndexData(45209, new int[] {34001, 34001, 34002}));
root.Add(45210, new IndexData(45210, new int[] {34001, 34001, 34002}));
root.Add(45211, new IndexData(45211, new int[] {34001, 34001, 34002}));
root.Add(45212, new IndexData(45212, new int[] {34001, 34001, 34002}));
root.Add(45213, new IndexData(45213, new int[] {34001, 34001, 34002}));
root.Add(45214, new IndexData(45214, new int[] {34001, 34001, 34002}));
root.Add(45215, new IndexData(45215, new int[] {34001, 34001, 34002}));
root.Add(45216, new IndexData(45216, new int[] {34001, 34001, 34002}));
root.Add(45217, new IndexData(45217, new int[] {34001, 34001, 34002}));
root.Add(45218, new IndexData(45218, new int[] {34001, 34001, 34002}));
root.Add(45219, new IndexData(45219, new int[] {34001, 34001, 34002}));
root.Add(45220, new IndexData(45220, new int[] {34001, 34001, 34002}));
root.Add(45221, new IndexData(45221, new int[] {34001, 34001, 34002}));
root.Add(45222, new IndexData(45222, new int[] {34001, 34001, 34002}));
root.Add(45223, new IndexData(45223, new int[] {34001, 34001, 34002}));
root.Add(45224, new IndexData(45224, new int[] {34001, 34001, 34002}));
root.Add(45225, new IndexData(45225, new int[] {34001, 34001, 34002}));
root.Add(45226, new IndexData(45226, new int[] {34001, 34001, 34002}));
root.Add(45227, new IndexData(45227, new int[] {34001, 34001, 34002}));
root.Add(45228, new IndexData(45228, new int[] {34001, 34001, 34002}));
root.Add(45229, new IndexData(45229, new int[] {34001, 34001, 34002}));
root.Add(45230, new IndexData(45230, new int[] {34001, 34001, 34002}));
root.Add(45231, new IndexData(45231, new int[] {34001, 34001, 34002}));
root.Add(45232, new IndexData(45232, new int[] {34001, 34001, 34002}));
root.Add(45233, new IndexData(45233, new int[] {34001, 34001, 34002}));
root.Add(45234, new IndexData(45234, new int[] {34001, 34001, 34002}));
root.Add(45235, new IndexData(45235, new int[] {34001, 34001, 34002}));
root.Add(45236, new IndexData(45236, new int[] {34001, 34001, 34002}));
root.Add(45237, new IndexData(45237, new int[] {34001, 34001, 34002}));
root.Add(45238, new IndexData(45238, new int[] {34001, 34001, 34002}));
root.Add(45239, new IndexData(45239, new int[] {34001, 34001, 34002}));
root.Add(45240, new IndexData(45240, new int[] {34001, 34001, 34002}));
}
public IndexData GetReadData(int ID){
if (root.ContainsKey(ID))
return root[ID];
else{
object obj = MMFramework.ModifyExcelModule.Instance.GetModifyedData(ID);
if (obj != null)return obj as IndexData;
Debug.LogError("在表格 IndexData中没有找到ID" + ID);
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
IndexData data = GetReadData(key);
Type type = data.GetType();
System.Reflection.FieldInfo[] filedinfos = type.GetFields();
for (int i = 0; i < filedinfos.Length; i++)
{System.Reflection.FieldInfo field = filedinfos[i];
pairs.Add(field.Name, field.GetValue(data).ToString());}
return pairs;}
}
public static IndexData GetData(int ID){
return IndexDataReader.Instance.GetReadData(ID);
}
public static Dictionary<string, string> GetDictionary(int key)
{ return IndexDataReader.Instance.GetReadDictionary(key);}
public static int GetNum(){
return IndexDataReader.Instance.GetCount();
}
public static List<int> GetKeys(){
return IndexDataReader.Instance.GetDataKeys();
}
public static void SaveToFile(string path){
IndexDataReader.Instance.WriteToFile(path);
}

}