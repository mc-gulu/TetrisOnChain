using System;
using System.Collections.Generic;
using UnityEngine;
[Serializable]
public class FrameData{
public enum FrameEnum{
None,
TestFrame,
BattleBottomFrame,
EmergencyNoticeFrame,
HomeFrame,
BattleResultFrame,
HomeUI,
HeroListUI,
HeroDetailFrame,
PreBattleFrame,
GMFrame,
GetItemsFrame,
ItemDetailFrame,
HeroStarUpUI,
BattleOptionUI,
MailListFrame,
MailDetailFrame,
OfflineHarvestFrame,
TipsFrame,
LotteryFrame,
CheckinFrame,
WarningFrame,
HeroBuffFrame,
MainTopBar,
MainBottom,
FlyResourcesFrame,
NextFloorFrame,
HeroNewShowFrame,
HeroStarUpShowFrame,
SetFrame,
}
/// <summary>
/// 界面枚举
/// </summary>
public FrameEnum FrameType;
/// <summary>
/// prefab名
/// </summary>
public string PrefabPathFile;
/// <summary>
/// 放在哪个层级
/// </summary>
public int LayerIndex;
/// <summary>
/// 进入场景动作
/// </summary>
public string StartAnim;
/// <summary>
/// 离开场景动作
/// </summary>
public string EndAnim;
public FrameData(FrameEnum FrameType, string PrefabPathFile, int LayerIndex, string StartAnim, string EndAnim){
this.FrameType = FrameType;
this.PrefabPathFile = PrefabPathFile;
this.LayerIndex = LayerIndex;
this.StartAnim = StartAnim;
this.EndAnim = EndAnim;
}
class FrameDataReader{
static FrameDataReader instance;
static object syncRoot = new object();
public static FrameDataReader Instance{get{if (instance == null){lock (syncRoot){if (instance == null){instance = new FrameDataReader();instance.Load();}}}return instance;}}
Dictionary<FrameEnum, FrameData> root = new Dictionary<FrameEnum, FrameData>();
void Load(){
root.Add(FrameEnum.TestFrame, new FrameData(FrameEnum.TestFrame, "Prefabs/ui/TestFrame", 4, "Animation/In", "Animation/Out"));
root.Add(FrameEnum.BattleBottomFrame, new FrameData(FrameEnum.BattleBottomFrame, "Prefabs/ui/BattleBottomFrame", 4, "Animation/In", "Animation/Out"));
root.Add(FrameEnum.EmergencyNoticeFrame, new FrameData(FrameEnum.EmergencyNoticeFrame, "Prefabs/ui/EmergencyNoticeFrame", 4, "Animation/In", "Animation/Out"));
root.Add(FrameEnum.HomeFrame, new FrameData(FrameEnum.HomeFrame, "Prefabs/ui/HomeFrame", 4, "Animation/In", "Animation/Out"));
root.Add(FrameEnum.BattleResultFrame, new FrameData(FrameEnum.BattleResultFrame, "Prefabs/ui/BattleResultFrame", 5, "Animation/battle_result_frame", "Animation/Out"));
root.Add(FrameEnum.HomeUI, new FrameData(FrameEnum.HomeUI, "Prefabs/ui/HomeUI", 3, "Animation/HomeUIIn", "Animation/HomeUIOut"));
root.Add(FrameEnum.HeroListUI, new FrameData(FrameEnum.HeroListUI, "Prefabs/ui/HeroListUI", 3, "Animation/HeroListUIIn", "Animation/HeroListUIOut"));
root.Add(FrameEnum.HeroDetailFrame, new FrameData(FrameEnum.HeroDetailFrame, "Prefabs/ui/HeroDetailFrame", 5, "", ""));
root.Add(FrameEnum.PreBattleFrame, new FrameData(FrameEnum.PreBattleFrame, "Prefabs/ui/PreBattleFrame", 4, "Animation/PreBattleIn", "Animation/PreBattleOut"));
root.Add(FrameEnum.GMFrame, new FrameData(FrameEnum.GMFrame, "Prefabs/ui/GMFrame", 7, "", ""));
root.Add(FrameEnum.GetItemsFrame, new FrameData(FrameEnum.GetItemsFrame, "Prefabs/ui/GetItemsFrame", 5, "", ""));
root.Add(FrameEnum.ItemDetailFrame, new FrameData(FrameEnum.ItemDetailFrame, "Prefabs/ui/ItemDetailFrame", 7, "", ""));
root.Add(FrameEnum.HeroStarUpUI, new FrameData(FrameEnum.HeroStarUpUI, "Prefabs/ui/HeroStarUpUI", 3, "", ""));
root.Add(FrameEnum.BattleOptionUI, new FrameData(FrameEnum.BattleOptionUI, "Prefabs/ui/BattleOptionUI", 7, "", ""));
root.Add(FrameEnum.MailListFrame, new FrameData(FrameEnum.MailListFrame, "Prefabs/ui/MailListFrame", 5, "", ""));
root.Add(FrameEnum.MailDetailFrame, new FrameData(FrameEnum.MailDetailFrame, "Prefabs/ui/MailDetailFrame", 7, "", ""));
root.Add(FrameEnum.OfflineHarvestFrame, new FrameData(FrameEnum.OfflineHarvestFrame, "Prefabs/ui/OfflineHarvestFrame", 5, "Animation/In", "Animation/Out"));
root.Add(FrameEnum.TipsFrame, new FrameData(FrameEnum.TipsFrame, "Prefabs/ui/TipsFrame", 5, "Animation/In", "Animation/Out"));
root.Add(FrameEnum.LotteryFrame, new FrameData(FrameEnum.LotteryFrame, "Prefabs/ui/LotteryFrame", 3, "Animation/In", "Animation/Out"));
root.Add(FrameEnum.CheckinFrame, new FrameData(FrameEnum.CheckinFrame, "Prefabs/ui/CheckinFrame", 5, "Animation/In", "Animation/Out"));
root.Add(FrameEnum.WarningFrame, new FrameData(FrameEnum.WarningFrame, "Prefabs/ui/WarningFrame", 5, "", ""));
root.Add(FrameEnum.HeroBuffFrame, new FrameData(FrameEnum.HeroBuffFrame, "Prefabs/ui/HeroBuffFrame", 8, "", ""));
root.Add(FrameEnum.MainTopBar, new FrameData(FrameEnum.MainTopBar, "Prefabs/ui/MainTopBar", 6, "", ""));
root.Add(FrameEnum.MainBottom, new FrameData(FrameEnum.MainBottom, "Prefabs/ui/MainBottom", 4, "", ""));
root.Add(FrameEnum.FlyResourcesFrame, new FrameData(FrameEnum.FlyResourcesFrame, "Prefabs/ui/FlyResourcesFrame", 8, "", ""));
root.Add(FrameEnum.NextFloorFrame, new FrameData(FrameEnum.NextFloorFrame, "Prefabs/ui/NextFloorFrame", 2, "Animation/In", "Animation/Out"));
root.Add(FrameEnum.HeroNewShowFrame, new FrameData(FrameEnum.HeroNewShowFrame, "Prefabs/ui/HeroNewShowFrame", 7, "", ""));
root.Add(FrameEnum.HeroStarUpShowFrame, new FrameData(FrameEnum.HeroStarUpShowFrame, "Prefabs/ui/HeroStarUpShowFrame", 7, "", ""));
root.Add(FrameEnum.SetFrame, new FrameData(FrameEnum.SetFrame, "Prefabs/ui/SetFrame", 7, "Animation/In", "Animation/Out"));
}
public FrameData GetReadData(FrameEnum ID){
if (root.ContainsKey(ID))
return root[ID];
else{
object obj = MMFramework.ModifyExcelModule.Instance.GetModifyedData(ID);
if (obj != null)return obj as FrameData;
Debug.LogError("在表格 FrameData中没有找到ID" + ID);
return null;}
}
public void WriteToFile(string path){}
public int GetCount(){
return root.Count;
}
public List<FrameEnum> GetDataKeys(){
return new List<FrameEnum>(root.Keys);
}
public Dictionary<string, string> GetReadDictionary(FrameEnum key)
{Dictionary<string, string> pairs = new Dictionary<string, string>();
FrameData data = GetReadData(key);
Type type = data.GetType();
System.Reflection.FieldInfo[] filedinfos = type.GetFields();
for (int i = 0; i < filedinfos.Length; i++)
{System.Reflection.FieldInfo field = filedinfos[i];
pairs.Add(field.Name, field.GetValue(data).ToString());}
return pairs;}
}
public static FrameData GetData(FrameEnum ID){
return FrameDataReader.Instance.GetReadData(ID);
}
public static Dictionary<string, string> GetDictionary(FrameEnum key)
{ return FrameDataReader.Instance.GetReadDictionary(key);}
public static int GetNum(){
return FrameDataReader.Instance.GetCount();
}
public static List<FrameEnum> GetKeys(){
return FrameDataReader.Instance.GetDataKeys();
}
public static void SaveToFile(string path){
FrameDataReader.Instance.WriteToFile(path);
}

}