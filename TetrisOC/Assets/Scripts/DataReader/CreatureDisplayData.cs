using System;
using System.Collections.Generic;
using UnityEngine;
[Serializable]
public class CreatureDisplayData{
/// <summary>
/// 显示ID
/// </summary>
public int CreatureDisplayID;
/// <summary>
/// 角色动作
/// </summary>
public string CreatureAction;
/// <summary>
/// 动作优先级
/// </summary>
public int ActionPriority;
/// <summary>
/// 上slot的prefab名
/// </summary>
public string TopAdd;
/// <summary>
/// 下slot的prefab名
/// </summary>
public string DownAdd;
/// <summary>
/// 前slot的prefab名
/// </summary>
public string FrontAdd;
/// <summary>
/// 后slot的prefab名
/// </summary>
public string BackAdd;
/// <summary>
/// 持续时间(buff和死亡这列不管用，持续时间根据buff的来，技能填-1读取角色原有动作时间，被打不能填-1）
/// </summary>
public float Time;
/// <summary>
/// 跳字Prefab(用于受击方）
/// </summary>
public string DigitalPrefab;
/// <summary>
/// 子弹从左打来的动画
/// </summary>
public string LeftAnim;
/// <summary>
/// 角色颜色
/// </summary>
public string Color;
/// <summary>
/// 颜色混合程度
/// </summary>
public float ColorScale;
/// <summary>
/// 混合方式（0硬混合，1正片叠底）
/// </summary>
public int ColorType;
/// <summary>
/// 颜色优先级
/// </summary>
public int ColorPriority;
public CreatureDisplayData(int CreatureDisplayID, string CreatureAction, int ActionPriority, string TopAdd, string DownAdd, string FrontAdd, string BackAdd, float Time, string DigitalPrefab, string LeftAnim, string Color, float ColorScale, int ColorType, int ColorPriority){
this.CreatureDisplayID = CreatureDisplayID;
this.CreatureAction = CreatureAction;
this.ActionPriority = ActionPriority;
this.TopAdd = TopAdd;
this.DownAdd = DownAdd;
this.FrontAdd = FrontAdd;
this.BackAdd = BackAdd;
this.Time = Time;
this.DigitalPrefab = DigitalPrefab;
this.LeftAnim = LeftAnim;
this.Color = Color;
this.ColorScale = ColorScale;
this.ColorType = ColorType;
this.ColorPriority = ColorPriority;
}
class CreatureDisplayDataReader{
static CreatureDisplayDataReader instance;
static object syncRoot = new object();
public static CreatureDisplayDataReader Instance{get{if (instance == null){lock (syncRoot){if (instance == null){instance = new CreatureDisplayDataReader();instance.Load();}}}return instance;}}
Dictionary<int, CreatureDisplayData> root = new Dictionary<int, CreatureDisplayData>();
void Load(){
root.Add(1, new CreatureDisplayData(1, "attack", 2, "", "", "", "", -1f, "", "", "", 0f, 0, 0));
root.Add(2, new CreatureDisplayData(2, "behit", 1, "", "", "", "", 0.4f, "prefabs/ui/flytext", "mid_scale", "", 0f, 0, 0));
root.Add(3, new CreatureDisplayData(3, "bigskill", 3, "", "", "", "", -1f, "", "", "", 0f, 0, 0));
root.Add(4, new CreatureDisplayData(4, "", 0, "", "", "Animation/ani_prefabs/effect/addhp", "", 0.4f, "prefabs/ui/flytext", "mid_scale_green", "", 0f, 0, 0));
root.Add(5, new CreatureDisplayData(5, "", 0, "", "", "Animation/ani_prefabs/effect/skill_burton_shell", "", 0.4f, "", "", "", 0f, 0, 0));
root.Add(6, new CreatureDisplayData(6, "", 0, "", "", "Animation/ani_prefabs/effect/skill_gizmo", "", 0.4f, "", "", "", 0f, 0, 0));
root.Add(7, new CreatureDisplayData(7, "", 0, "", "Animation/ani_prefabs/effect/buff_attack_up", "", "", 0.4f, "", "", "", 0f, 0, 0));
root.Add(8, new CreatureDisplayData(8, "", 0, "", "", "", "", 0f, "", "", "", 0f, 0, 0));
root.Add(9, new CreatureDisplayData(9, "behit", 1, "", "", "Animation/ani_prefabs/effect/fx_laser_hit", "", 0.4f, "prefabs/ui/flytext", "mid_scale", "", 0f, 0, 0));
root.Add(10, new CreatureDisplayData(10, "", 0, "", "", "Animation/ani_prefabs/effect/poison", "", 0.4f, "prefabs/ui/flytext", "mid_scale", "ff00C412", 0.5f, 1, 1));
root.Add(11, new CreatureDisplayData(11, "skill", 3, "", "", "", "", -1f, "", "", "", 0f, 0, 0));
root.Add(12, new CreatureDisplayData(12, "", 0, "", "", "Animation/ani_prefabs/effect/sword_behit", "", 0.4f, "prefabs/ui/flytext", "mid_scale", "", 0f, 0, 0));
root.Add(13, new CreatureDisplayData(13, "", 0, "", "", "Animation/ani_prefabs/effect/fireball_behit", "", 0.4f, "prefabs/ui/flytext", "mid_scale", "", 0f, 0, 0));
root.Add(14, new CreatureDisplayData(14, "", 0, "", "", "Animation/ani_prefabs/effect/windball_behit", "", 0.4f, "prefabs/ui/flytext", "mid_scale", "", 0f, 0, 0));
root.Add(15, new CreatureDisplayData(15, "", 0, "", "", "Animation/ani_prefabs/effect/waterball_behit", "", 0.4f, "prefabs/ui/flytext", "mid_scale", "", 0f, 0, 0));
root.Add(16, new CreatureDisplayData(16, "", 0, "", "", "Animation/ani_prefabs/effect/lightball_behit", "", 0.4f, "prefabs/ui/flytext", "mid_scale", "", 0f, 0, 0));
root.Add(17, new CreatureDisplayData(17, "", 0, "", "", "Animation/ani_prefabs/effect/darkball_behit", "", 0.4f, "prefabs/ui/flytext", "mid_scale", "", 0f, 0, 0));
root.Add(18, new CreatureDisplayData(18, "", 0, "", "", "Animation/ani_prefabs/effect/firearrow_behit", "", 0.4f, "prefabs/ui/flytext", "mid_scale", "", 0f, 0, 0));
root.Add(19, new CreatureDisplayData(19, "", 0, "", "", "Animation/ani_prefabs/effect/windarrow_behit", "", 0.4f, "prefabs/ui/flytext", "mid_scale", "", 0f, 0, 0));
root.Add(20, new CreatureDisplayData(20, "", 0, "", "", "Animation/ani_prefabs/effect/waterarrow_behit", "", 0.4f, "prefabs/ui/flytext", "mid_scale", "", 0f, 0, 0));
root.Add(21, new CreatureDisplayData(21, "", 0, "", "", "Animation/ani_prefabs/effect/lightarrow_behit", "", 0.4f, "prefabs/ui/flytext", "mid_scale", "", 0f, 0, 0));
root.Add(22, new CreatureDisplayData(22, "", 0, "", "", "Animation/ani_prefabs/effect/darkarrow_behit", "", 0.4f, "prefabs/ui/flytext", "mid_scale", "", 0f, 0, 0));
root.Add(23, new CreatureDisplayData(23, "", 0, "", "", "Animation/ani_prefabs/effect/be_hit_physic", "", 0.4f, "prefabs/ui/flytext", "mid_scale", "", 0f, 0, 0));
root.Add(24, new CreatureDisplayData(24, "", 0, "", "", "Animation/ani_prefabs/effect/xuli", "", 0.4f, "prefabs/ui/flytext", "mid_scale", "", 0f, 0, 0));
root.Add(25, new CreatureDisplayData(25, "behit", 1, "", "", "", "", 0.2f, "prefabs/ui/flytext", "mid_scale_red", "ffFF2424", 0.5f, 1, 9));
root.Add(26, new CreatureDisplayData(26, "", 0, "", "", "Animation/ani_prefabs/effect/firearrow_behit", "", 0.4f, "prefabs/ui/flytext", "mid_scale", "", 0f, 0, 0));
root.Add(27, new CreatureDisplayData(27, "", 0, "", "", "Animation/ani_prefabs/effect/windarrow_behit", "", 0.4f, "prefabs/ui/flytext", "mid_scale", "", 0f, 0, 0));
root.Add(28, new CreatureDisplayData(28, "", 0, "", "", "Animation/ani_prefabs/effect/waterarrow_behit", "", 0.4f, "prefabs/ui/flytext", "mid_scale", "", 0f, 0, 0));
root.Add(29, new CreatureDisplayData(29, "", 0, "", "", "Animation/ani_prefabs/effect/lightarrow_behit", "", 0.4f, "prefabs/ui/flytext", "mid_scale", "", 0f, 0, 0));
root.Add(30, new CreatureDisplayData(30, "", 0, "", "", "Animation/ani_prefabs/effect/darkarrow_behit", "", 0.4f, "prefabs/ui/flytext", "mid_scale", "", 0f, 0, 0));
root.Add(31, new CreatureDisplayData(31, "", 0, "", "", "Animation/ani_prefabs/effect/firearrow_behit", "", 0.4f, "prefabs/ui/flytext", "mid_scale", "", 0f, 0, 0));
root.Add(32, new CreatureDisplayData(32, "", 0, "", "", "Animation/ani_prefabs/effect/windarrow_behit", "", 0.4f, "prefabs/ui/flytext", "mid_scale", "", 0f, 0, 0));
root.Add(33, new CreatureDisplayData(33, "", 0, "", "", "Animation/ani_prefabs/effect/waterarrow_behit", "", 0.4f, "prefabs/ui/flytext", "mid_scale", "", 0f, 0, 0));
root.Add(34, new CreatureDisplayData(34, "", 0, "", "", "Animation/ani_prefabs/effect/lightarrow_behit", "", 0.4f, "prefabs/ui/flytext", "mid_scale", "", 0f, 0, 0));
root.Add(35, new CreatureDisplayData(35, "", 0, "", "", "Animation/ani_prefabs/effect/darkarrow_behit", "", 0.4f, "prefabs/ui/flytext", "mid_scale", "", 0f, 0, 0));
root.Add(36, new CreatureDisplayData(36, "", 0, "", "", "", "", 0f, "", "", "", 0f, 0, 0));
root.Add(50, new CreatureDisplayData(50, "die", 9, "", "", "", "", 9999f, "", "", "ff000000", 0.5f, 1, 9));
root.Add(51, new CreatureDisplayData(51, "", 0, "", "", "Animation/ani_prefabs/effect/skill_essac01", "", 5f, "prefabs/ui/flytext", "mid_scale", "", 0f, 0, 0));
root.Add(52, new CreatureDisplayData(52, "bigskill", 3, "", "", "", "", -1f, "prefabs/ui/flytext", "mid_scale", "", 0f, 0, 0));
root.Add(53, new CreatureDisplayData(53, "bigskill", 3, "", "", "", "", -1f, "prefabs/ui/flytext", "mid_scale", "", 0f, 0, 0));
root.Add(54, new CreatureDisplayData(54, "bigskill", 3, "", "", "Animation/ani_prefabs/effect/Skill_Andy", "", -1f, "prefabs/ui/flytext", "mid_scale", "", 0f, 0, 0));
root.Add(55, new CreatureDisplayData(55, "bigskill", 3, "", "", "", "", -1f, "prefabs/ui/flytext", "mid_scale", "", 0f, 0, 0));
root.Add(56, new CreatureDisplayData(56, "bigskill", 3, "", "", "", "", -1f, "prefabs/ui/flytext", "mid_scale", "", 0f, 0, 0));
root.Add(57, new CreatureDisplayData(57, "bigskill", 3, "", "", "", "", -1f, "prefabs/ui/flytext", "mid_scale", "", 0f, 0, 0));
root.Add(58, new CreatureDisplayData(58, "bigskill", 3, "", "", "", "", -1f, "prefabs/ui/flytext", "mid_scale", "", 0f, 0, 0));
root.Add(59, new CreatureDisplayData(59, "bigskill", 3, "", "", "", "", -1f, "prefabs/ui/flytext", "mid_scale", "", 0f, 0, 0));
root.Add(60, new CreatureDisplayData(60, "bigskill", 3, "", "", "", "", -1f, "prefabs/ui/flytext", "mid_scale", "", 0f, 0, 0));
root.Add(61, new CreatureDisplayData(61, "bigskill", 3, "", "", "", "", -1f, "prefabs/ui/flytext", "mid_scale", "", 0f, 0, 0));
root.Add(62, new CreatureDisplayData(62, "bigskill", 3, "", "", "", "", -1f, "prefabs/ui/flytext", "mid_scale", "", 0f, 0, 0));
root.Add(63, new CreatureDisplayData(63, "bigskill", 3, "", "", "", "", -1f, "prefabs/ui/flytext", "mid_scale", "", 0f, 0, 0));
root.Add(64, new CreatureDisplayData(64, "bigskill", 3, "", "", "", "", -1f, "prefabs/ui/flytext", "mid_scale", "", 0f, 0, 0));
root.Add(65, new CreatureDisplayData(65, "bigskill", 3, "", "", "", "", -1f, "prefabs/ui/flytext", "mid_scale_green", "", 0f, 0, 0));
root.Add(66, new CreatureDisplayData(66, "", 3, "", "", "Animation/ani_prefabs/effect/buff_attack_up", "", -1f, "prefabs/ui/flytext", "mid_scale", "", 0f, 0, 0));
root.Add(67, new CreatureDisplayData(67, "", 3, "", "", "Animation/ani_prefabs/effect/skill_paco", "", -1f, "prefabs/ui/flytext", "mid_scale_green", "", 0f, 0, 0));
root.Add(68, new CreatureDisplayData(68, "bigskill", 3, "", "", "", "", -1f, "prefabs/ui/flytext", "mid_scale_green", "", 0f, 0, 0));
root.Add(69, new CreatureDisplayData(69, "bigskill", 3, "", "", "", "", -1f, "prefabs/ui/flytext", "mid_scale_green", "", 0f, 0, 0));
root.Add(70, new CreatureDisplayData(70, "bigskill", 3, "", "", "", "", -1f, "prefabs/ui/flytext", "mid_scale", "", 0f, 0, 0));
root.Add(71, new CreatureDisplayData(71, "bigskill", 3, "", "", "", "", -1f, "prefabs/ui/flytext", "mid_scale", "", 0f, 0, 0));
root.Add(72, new CreatureDisplayData(72, "bigskill", 3, "", "", "", "", -1f, "prefabs/ui/flytext", "mid_scale_green", "", 0f, 0, 0));
root.Add(73, new CreatureDisplayData(73, "bigskill", 3, "", "", "", "", -1f, "prefabs/ui/flytext", "mid_scale", "", 0f, 0, 0));
root.Add(74, new CreatureDisplayData(74, "bigskill", 3, "", "", "", "", -1f, "prefabs/ui/flytext", "mid_scale_green", "", 0f, 0, 0));
root.Add(75, new CreatureDisplayData(75, "bigskill", 3, "", "", "", "", -1f, "prefabs/ui/flytext", "mid_scale", "", 0f, 0, 0));
root.Add(76, new CreatureDisplayData(76, "bigskill", 3, "", "", "", "", -1f, "prefabs/ui/flytext", "mid_scale", "", 0f, 0, 0));
root.Add(77, new CreatureDisplayData(77, "bigskill", 3, "", "", "", "", -1f, "prefabs/ui/flytext", "mid_scale", "", 0f, 0, 0));
root.Add(78, new CreatureDisplayData(78, "bigskill", 3, "", "", "", "", -1f, "prefabs/ui/flytext", "mid_scale", "", 0f, 0, 0));
root.Add(79, new CreatureDisplayData(79, "bigskill", 3, "", "", "", "", -1f, "prefabs/ui/flytext", "mid_scale", "", 0f, 0, 0));
root.Add(80, new CreatureDisplayData(80, "bigskill", 3, "", "", "", "", -1f, "prefabs/ui/flytext", "mid_scale", "", 0f, 0, 0));
root.Add(81, new CreatureDisplayData(81, "bigskill", 3, "", "", "", "", -1f, "prefabs/ui/flytext", "mid_scale", "", 0f, 0, 0));
root.Add(82, new CreatureDisplayData(82, "bigskill", 3, "", "", "", "", -1f, "prefabs/ui/flytext", "mid_scale", "", 0f, 0, 0));
root.Add(83, new CreatureDisplayData(83, "bigskill", 3, "", "", "", "", -1f, "prefabs/ui/flytext", "mid_scale", "", 0f, 0, 0));
root.Add(84, new CreatureDisplayData(84, "bigskill", 3, "", "", "", "", -1f, "prefabs/ui/flytext", "mid_scale", "", 0f, 0, 0));
root.Add(85, new CreatureDisplayData(85, "bigskill", 3, "", "", "", "", -1f, "prefabs/ui/flytext", "mid_scale", "", 0f, 0, 0));
root.Add(86, new CreatureDisplayData(86, "bigskill", 3, "", "", "", "", -1f, "prefabs/ui/flytext", "mid_scale", "", 0f, 0, 0));
root.Add(87, new CreatureDisplayData(87, "bigskill", 3, "", "", "Animation/ani_prefabs/bullet/bullet_xuli", "", -1f, "prefabs/ui/flytext", "mid_scale", "", 0f, 0, 0));
root.Add(88, new CreatureDisplayData(88, "bigskill", 3, "", "", "", "", -1f, "prefabs/ui/flytext", "mid_scale", "", 0f, 0, 0));
root.Add(89, new CreatureDisplayData(89, "bigskill", 3, "", "", "", "", -1f, "prefabs/ui/flytext", "mid_scale", "", 0f, 0, 0));
root.Add(90, new CreatureDisplayData(90, "bigskill", 3, "", "", "", "", -1f, "prefabs/ui/flytext", "mid_scale", "", 0f, 0, 0));
root.Add(91, new CreatureDisplayData(91, "bigskill", 3, "", "", "", "", -1f, "prefabs/ui/flytext", "mid_scale", "", 0f, 0, 0));
root.Add(92, new CreatureDisplayData(92, "bigskill", 3, "", "", "", "", -1f, "prefabs/ui/flytext", "mid_scale", "", 0f, 0, 0));
root.Add(93, new CreatureDisplayData(93, "bigskill", 3, "", "", "", "", -1f, "prefabs/ui/flytext", "mid_scale", "", 0f, 0, 0));
root.Add(94, new CreatureDisplayData(94, "bigskill", 3, "", "", "Animation/ani_prefabs/effect/skill_gizmo", "", -1f, "prefabs/ui/flytext", "mid_scale", "", 0f, 0, 0));
root.Add(95, new CreatureDisplayData(95, "bigskill", 3, "Animation/ani_prefabs/effect/skill_sarah", "", "", "", -1f, "prefabs/ui/flytext", "mid_scale", "", 0f, 0, 0));
root.Add(96, new CreatureDisplayData(96, "bigskill", 3, "", "", "", "", -1f, "prefabs/ui/flytext", "mid_scale", "", 0f, 0, 0));
root.Add(97, new CreatureDisplayData(97, "bigskill", 3, "", "", "Animation/ani_prefabs/effect/skill_gizmo", "", -1f, "prefabs/ui/flytext", "mid_scale", "", 0f, 0, 0));
root.Add(98, new CreatureDisplayData(98, "bigskill", 3, "Animation/ani_prefabs/effect/skill_sarah", "", "", "", -1f, "prefabs/ui/flytext", "mid_scale", "", 0f, 0, 0));
root.Add(99, new CreatureDisplayData(99, "bigskill", 3, "", "", "", "", -1f, "prefabs/ui/flytext", "mid_scale", "", 0f, 0, 0));
root.Add(100, new CreatureDisplayData(100, "bigskill", 3, "", "", "", "", -1f, "prefabs/ui/flytext", "mid_scale", "", 0f, 0, 0));
root.Add(101, new CreatureDisplayData(101, "", 0, "", "", "", "", 0.15f, "", "", "ffffffff", 1f, 0, 9));
root.Add(102, new CreatureDisplayData(102, "", 0, "", "", "", "", 0.15f, "", "", "ffff0000", 0.8f, 1, 9));
root.Add(103, new CreatureDisplayData(103, "behit", 1, "", "", "", "", 0.4f, "prefabs/ui/flytext", "mid_scale_red", "", 0f, 0, 0));
root.Add(104, new CreatureDisplayData(104, "", 1, "", "", "Animation/ani_prefabs/effect/buff_attack_up", "", 10f, "", "", "", 0f, 0, 0));
}
public CreatureDisplayData GetReadData(int ID){
if (root.ContainsKey(ID))
return root[ID];
else{
object obj = MMFramework.ModifyExcelModule.Instance.GetModifyedData(ID);
if (obj != null)return obj as CreatureDisplayData;
Debug.LogError("在表格 CreatureDisplayData中没有找到ID" + ID);
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
CreatureDisplayData data = GetReadData(key);
Type type = data.GetType();
System.Reflection.FieldInfo[] filedinfos = type.GetFields();
for (int i = 0; i < filedinfos.Length; i++)
{System.Reflection.FieldInfo field = filedinfos[i];
pairs.Add(field.Name, field.GetValue(data).ToString());}
return pairs;}
}
public static CreatureDisplayData GetData(int ID){
return CreatureDisplayDataReader.Instance.GetReadData(ID);
}
public static Dictionary<string, string> GetDictionary(int key)
{ return CreatureDisplayDataReader.Instance.GetReadDictionary(key);}
public static int GetNum(){
return CreatureDisplayDataReader.Instance.GetCount();
}
public static List<int> GetKeys(){
return CreatureDisplayDataReader.Instance.GetDataKeys();
}
public static void SaveToFile(string path){
CreatureDisplayDataReader.Instance.WriteToFile(path);
}

}