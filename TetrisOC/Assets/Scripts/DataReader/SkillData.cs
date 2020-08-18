using System;
using System.Collections.Generic;
using UnityEngine;
[Serializable]
public class SkillData{
/// <summary>
/// 序号
/// </summary>
public int ID;
/// <summary>
/// 名字
/// </summary>
public string Name;
/// <summary>
/// 攻击范围
/// </summary>
public float Range;
/// <summary>
/// 判断条件
/// </summary>
public int SkillConditionID;
/// <summary>
/// 优先级
/// </summary>
public int Priority;
/// <summary>
/// 所需能量
/// </summary>
public float NeedEnergy;
/// <summary>
/// 使用后获取能量
/// </summary>
public int GetEnergy;
/// <summary>
/// 继承角色元素
/// </summary>
public bool InheritCreatureElement;
/// <summary>
/// 描述
/// </summary>
public string Description;
/// <summary>
/// 是否检查共享间隔
/// </summary>
public bool CheckBusy;
/// <summary>
/// 共享间隔
/// </summary>
public float Busy;
/// <summary>
/// 是否检查CD
/// </summary>
public bool CheckCD;
/// <summary>
/// 独立冷却
/// </summary>
public float CD;
/// <summary>
/// （对自己）被动Buff
/// </summary>
public int BuffIDLong;
/// <summary>
/// 发射数组1
/// </summary>
public int[] FireArray;
/// <summary>
/// 位置数组1
/// </summary>
public int[] PosArray;
/// <summary>
/// 攻击时给自己带Buff
/// </summary>
public int AttachSelf;
/// <summary>
/// 攻击给别人带Buff
/// </summary>
public int AttachEnimy;
/// <summary>
/// 是不是普通攻击（用于攻速加减）
/// </summary>
public bool NormalAtk;
public SkillData(int ID, string Name, float Range, int SkillConditionID, int Priority, float NeedEnergy, int GetEnergy, bool InheritCreatureElement, string Description, bool CheckBusy, float Busy, bool CheckCD, float CD, int BuffIDLong, int[] FireArray, int[] PosArray, int AttachSelf, int AttachEnimy, bool NormalAtk){
this.ID = ID;
this.Name = Name;
this.Range = Range;
this.SkillConditionID = SkillConditionID;
this.Priority = Priority;
this.NeedEnergy = NeedEnergy;
this.GetEnergy = GetEnergy;
this.InheritCreatureElement = InheritCreatureElement;
this.Description = Description;
this.CheckBusy = CheckBusy;
this.Busy = Busy;
this.CheckCD = CheckCD;
this.CD = CD;
this.BuffIDLong = BuffIDLong;
this.FireArray = FireArray;
this.PosArray = PosArray;
this.AttachSelf = AttachSelf;
this.AttachEnimy = AttachEnimy;
this.NormalAtk = NormalAtk;
}
class SkillDataReader{
static SkillDataReader instance;
static object syncRoot = new object();
public static SkillDataReader Instance{get{if (instance == null){lock (syncRoot){if (instance == null){instance = new SkillDataReader();instance.Load();}}}return instance;}}
Dictionary<int, SkillData> root = new Dictionary<int, SkillData>();
void Load(){
root.Add(800101, new SkillData(800101, "s800101", 0.5f, 1, 1, 0f, 10, true, "s800101des", true, 1.1f, true, 2f, 0, new int[] {3100, 0, 0}, new int[] {0, 0, 0}, 0, 0, true));
root.Add(800201, new SkillData(800201, "s800201", 0.5f, 1, 1, 0f, 10, true, "s800201des", true, 1.1f, true, 2f, 0, new int[] {3101, 0, 0}, new int[] {0, 0, 0}, 0, 0, true));
root.Add(800301, new SkillData(800301, "s800301", 0.5f, 1, 1, 0f, 10, true, "s800301des", true, 1.1f, true, 2f, 0, new int[] {3102, 0, 0}, new int[] {0, 0, 0}, 0, 0, true));
root.Add(800401, new SkillData(800401, "s800401", 0.5f, 1, 1, 0f, 10, true, "s800401des", true, 1.1f, true, 2f, 0, new int[] {3103, 0, 0}, new int[] {0, 0, 0}, 0, 0, true));
root.Add(800501, new SkillData(800501, "s800501", 0.5f, 1, 1, 0f, 10, true, "s800501des", true, 1.1f, true, 2f, 0, new int[] {3104, 0, 0}, new int[] {0, 0, 0}, 0, 0, true));
root.Add(800601, new SkillData(800601, "s800601", 0.5f, 1, 1, 0f, 10, true, "s800601des", true, 1f, true, 1f, 0, new int[] {3105, 0, 0}, new int[] {0, 0, 0}, 0, 0, true));
root.Add(800701, new SkillData(800701, "s800701", 0.5f, 1, 1, 0f, 10, true, "s800701des", true, 1f, true, 1f, 0, new int[] {3106, 0, 0}, new int[] {0, 0, 0}, 0, 0, true));
root.Add(800801, new SkillData(800801, "s800801", 0.5f, 1, 1, 0f, 10, true, "s800801des", true, 1f, true, 1f, 0, new int[] {3107, 0, 0}, new int[] {0, 0, 0}, 0, 0, true));
root.Add(800901, new SkillData(800901, "s800901", 0.5f, 1, 1, 0f, 10, true, "s800901des", true, 1f, true, 1f, 0, new int[] {3108, 0, 0}, new int[] {0, 0, 0}, 0, 0, true));
root.Add(801001, new SkillData(801001, "s801001", 0.5f, 1, 1, 0f, 10, true, "s801001des", true, 1f, true, 1f, 0, new int[] {3109, 0, 0}, new int[] {0, 0, 0}, 0, 0, true));
root.Add(801101, new SkillData(801101, "s801101", 2f, 1, 1, 0f, 10, true, "s801101des", true, 1.3f, true, 1f, 0, new int[] {3110, 0, 0}, new int[] {0, 0, 0}, 0, 0, true));
root.Add(801201, new SkillData(801201, "s801201", 2f, 1, 1, 0f, 10, true, "s801201des", true, 1.3f, true, 1f, 0, new int[] {3111, 0, 0}, new int[] {0, 0, 0}, 0, 0, true));
root.Add(801301, new SkillData(801301, "s801301", 2f, 1, 1, 0f, 10, true, "s801301des", true, 1.3f, true, 1f, 0, new int[] {3112, 0, 0}, new int[] {0, 0, 0}, 0, 0, true));
root.Add(801401, new SkillData(801401, "s801401", 2f, 1, 1, 0f, 10, true, "s801401des", true, 1.3f, true, 1f, 0, new int[] {3113, 0, 0}, new int[] {0, 0, 0}, 0, 0, true));
root.Add(801501, new SkillData(801501, "s801501", 2f, 1, 1, 0f, 10, true, "s801501des", true, 1.3f, true, 1f, 0, new int[] {3114, 0, 0}, new int[] {0, 0, 0}, 0, 0, true));
root.Add(801601, new SkillData(801601, "s801601", 1.5f, 1, 1, 0f, 10, true, "s801601des", true, 1f, true, 1f, 0, new int[] {3115, 0, 0}, new int[] {0, 0, 0}, 0, 0, true));
root.Add(801701, new SkillData(801701, "s801701", 1.5f, 1, 1, 0f, 10, true, "s801701des", true, 1f, true, 1f, 0, new int[] {3116, 0, 0}, new int[] {0, 0, 0}, 0, 0, true));
root.Add(801801, new SkillData(801801, "s801801", 1.5f, 1, 1, 0f, 10, true, "s801801des", true, 1f, true, 1f, 0, new int[] {3117, 0, 0}, new int[] {0, 0, 0}, 0, 0, true));
root.Add(801901, new SkillData(801901, "s801901", 1.5f, 1, 1, 0f, 10, true, "s801901des", true, 1f, true, 1f, 0, new int[] {3118, 0, 0}, new int[] {0, 0, 0}, 0, 0, true));
root.Add(802001, new SkillData(802001, "s802001", 1.5f, 1, 1, 0f, 10, true, "s802001des", true, 1f, true, 1f, 0, new int[] {3119, 0, 0}, new int[] {0, 0, 0}, 0, 0, true));
root.Add(802101, new SkillData(802101, "s802101", 1.8f, 1, 1, 0f, 10, true, "s802101des", true, 1f, true, 1f, 0, new int[] {3120, 3137, 0}, new int[] {0, 1, 0}, 0, 0, true));
root.Add(802201, new SkillData(802201, "s802201", 1.8f, 1, 1, 0f, 10, true, "s802201des", true, 1f, true, 1f, 0, new int[] {3121, 3138, 0}, new int[] {0, 1, 0}, 0, 0, true));
root.Add(802301, new SkillData(802301, "s802301", 1.8f, 1, 1, 0f, 10, true, "s802301des", true, 1f, true, 1f, 0, new int[] {3122, 3139, 0}, new int[] {0, 1, 0}, 0, 0, true));
root.Add(802401, new SkillData(802401, "s802401", 1.8f, 1, 1, 0f, 10, true, "s802401des", true, 1f, true, 1f, 0, new int[] {3123, 3140, 0}, new int[] {0, 1, 0}, 0, 0, true));
root.Add(802501, new SkillData(802501, "s802501", 1.8f, 1, 1, 0f, 10, true, "s802501des", true, 1f, true, 1f, 0, new int[] {3124, 3141, 0}, new int[] {0, 1, 0}, 0, 0, true));
root.Add(802601, new SkillData(802601, "s802601", 1.5f, 1, 1, 0f, 10, true, "s802601des", true, 1.3f, true, 1f, 0, new int[] {3125, 0, 0}, new int[] {0, 0, 0}, 0, 0, true));
root.Add(802701, new SkillData(802701, "s802701", 1.5f, 1, 1, 0f, 10, true, "s802701des", true, 1.3f, true, 1f, 0, new int[] {3126, 0, 0}, new int[] {0, 0, 0}, 0, 0, true));
root.Add(802801, new SkillData(802801, "s802801", 1.5f, 1, 1, 0f, 10, true, "s802801des", true, 1.3f, true, 1f, 0, new int[] {3127, 0, 0}, new int[] {0, 0, 0}, 0, 0, true));
root.Add(802901, new SkillData(802901, "s802901", 1.5f, 1, 1, 0f, 10, true, "s802901des", true, 1.3f, true, 1f, 0, new int[] {3128, 0, 0}, new int[] {0, 0, 0}, 0, 0, true));
root.Add(803001, new SkillData(803001, "s803001", 1.5f, 1, 1, 0f, 10, true, "s803001des", true, 1.3f, true, 1f, 0, new int[] {3129, 0, 0}, new int[] {0, 0, 0}, 0, 0, true));
root.Add(803101, new SkillData(803101, "s803101", 2f, 1, 1, 0f, 10, true, "s803101des", true, 0.7f, true, 0.8f, 0, new int[] {3130, 0, 0}, new int[] {0, 0, 0}, 0, 0, true));
root.Add(803201, new SkillData(803201, "s803201", 2f, 1, 1, 0f, 10, true, "s803201des", true, 0.7f, true, 0.8f, 0, new int[] {3131, 0, 0}, new int[] {0, 0, 0}, 0, 0, true));
root.Add(803301, new SkillData(803301, "s803301", 2f, 1, 1, 0f, 10, true, "s803301des", true, 0.7f, true, 0.8f, 0, new int[] {3132, 0, 0}, new int[] {0, 0, 0}, 0, 0, true));
root.Add(803401, new SkillData(803401, "s803401", 2f, 1, 1, 0f, 10, true, "s803401des", true, 0.7f, true, 0.8f, 0, new int[] {3133, 0, 0}, new int[] {0, 0, 0}, 0, 0, true));
root.Add(803501, new SkillData(803501, "s803501", 2f, 1, 1, 0f, 10, true, "s803501des", true, 0.7f, true, 0.8f, 0, new int[] {3134, 0, 0}, new int[] {0, 0, 0}, 0, 0, true));
root.Add(810101, new SkillData(810101, "s810101", 0.7f, 1, 2, 50f, 0, true, "s810101des", true, 0.5f, true, 0.8f, 0, new int[] {3150, 0, 0}, new int[] {0, 0, 0}, 0, 0, false));
root.Add(810201, new SkillData(810201, "s810201", 0.7f, 1, 2, 60f, 0, true, "s810201des", true, 0.5f, true, 0.8f, 0, new int[] {3151, 0, 0}, new int[] {0, 0, 0}, 0, 0, false));
root.Add(810301, new SkillData(810301, "s810301", 3.2f, 1, 2, 50f, 0, true, "s810301des", true, 0.5f, true, 0.8f, 0, new int[] {3152, 0, 0}, new int[] {0, 0, 0}, 0, 0, false));
root.Add(810401, new SkillData(810401, "s810401", 3.2f, 1, 2, 50f, 0, true, "s810401des", true, 0.5f, true, 0.8f, 0, new int[] {3153, 0, 0}, new int[] {0, 0, 0}, 57, 0, false));
root.Add(810501, new SkillData(810501, "s810501", 0.7f, 1, 2, 50f, 0, true, "s810501des", true, 0.5f, true, 0.8f, 0, new int[] {3154, 0, 0}, new int[] {0, 0, 0}, 0, 0, false));
root.Add(810601, new SkillData(810601, "s810601", 3.2f, 1, 2, 50f, 0, true, "s810601des", true, 0.5f, true, 0.8f, 0, new int[] {3155, 0, 0}, new int[] {0, 0, 0}, 0, 0, false));
root.Add(810701, new SkillData(810701, "s810701", 3f, 1, 2, 60f, 0, true, "s810701des", true, 0.5f, true, 0.8f, 0, new int[] {3156, 0, 0}, new int[] {0, 0, 0}, 0, 0, false));
root.Add(810801, new SkillData(810801, "s810801", 3.2f, 6, 2, 46f, 0, true, "s810801des", true, 0.5f, true, 0.8f, 0, new int[] {0, 0, 0}, new int[] {0, 0, 0}, 61, 0, false));
root.Add(810901, new SkillData(810901, "s810901", 0.7f, 1, 2, 50f, 0, true, "s810901des", true, 0.5f, true, 0.8f, 0, new int[] {3158, 0, 0}, new int[] {0, 0, 0}, 0, 0, false));
root.Add(811001, new SkillData(811001, "s811001", 0.7f, 1, 2, 50f, 0, true, "s811001des", true, 0.5f, true, 0.8f, 0, new int[] {3159, 0, 0}, new int[] {0, 0, 0}, 0, 0, false));
root.Add(811101, new SkillData(811101, "s811101", 0.7f, 1, 2, 50f, 0, true, "s811101des", true, 0.5f, true, 0.8f, 0, new int[] {3160, 0, 0}, new int[] {0, 0, 0}, 0, 0, false));
root.Add(811201, new SkillData(811201, "s811201", 0.7f, 1, 2, 50f, 0, true, "s811201des", true, 0.5f, true, 0.8f, 0, new int[] {3161, 0, 0}, new int[] {0, 0, 0}, 0, 0, false));
root.Add(811301, new SkillData(811301, "s811301", 0.7f, 1, 2, 48f, 0, true, "s811301des", true, 0.5f, true, 0.8f, 0, new int[] {3162, 0, 0}, new int[] {0, 0, 0}, 0, 0, false));
root.Add(811401, new SkillData(811401, "s811401", 0.7f, 1, 2, 55f, 0, true, "s811401des", true, 0.5f, true, 0.8f, 0, new int[] {3163, 0, 0}, new int[] {0, 0, 0}, 0, 0, false));
root.Add(811501, new SkillData(811501, "s811501", 2f, 5, 2, 50f, 0, true, "s811501des", true, 0.5f, true, 0.8f, 0, new int[] {3164, 0, 0}, new int[] {0, 0, 0}, 0, 0, false));
root.Add(811601, new SkillData(811601, "s811601", 2f, 5, 2, 50f, 0, true, "s811601des", true, 0.5f, true, 0.8f, 0, new int[] {3165, 0, 0}, new int[] {0, 0, 0}, 0, 59, false));
root.Add(811701, new SkillData(811701, "s811701", 2f, 5, 2, 50f, 0, true, "s811701des", true, 0.5f, true, 0.8f, 0, new int[] {3166, 0, 0}, new int[] {0, 0, 0}, 0, 60, false));
root.Add(811801, new SkillData(811801, "s811801", 2f, 5, 2, 50f, 0, true, "s811801des", true, 0.5f, true, 0.8f, 0, new int[] {3167, 0, 0}, new int[] {0, 0, 0}, 0, 62, false));
root.Add(811901, new SkillData(811901, "s811901", 2f, 5, 2, 50f, 0, true, "s811901des", true, 0.5f, true, 0.8f, 0, new int[] {3168, 0, 0}, new int[] {0, 0, 0}, 0, 63, false));
root.Add(812001, new SkillData(812001, "s812001", 2f, 1, 2, 50f, 0, true, "s812001des", true, 0.5f, true, 0.8f, 0, new int[] {3, 3169, 0}, new int[] {0, 1, 2}, 0, 0, false));
root.Add(812101, new SkillData(812101, "s812101", 2f, 1, 2, 50f, 0, true, "s812101des", true, 0.5f, true, 0.8f, 0, new int[] {3, 3170, 0}, new int[] {0, 1, 2}, 0, 0, false));
root.Add(812201, new SkillData(812201, "s812201", 2f, 1, 2, 50f, 0, true, "s812201des", true, 0.5f, true, 0.8f, 0, new int[] {3171, 0, 0}, new int[] {0, 0, 0}, 0, 0, false));
root.Add(812301, new SkillData(812301, "s812301", 2f, 1, 2, 50f, 0, true, "s812301des", true, 0.5f, true, 0.8f, 0, new int[] {3, 3172, 0}, new int[] {0, 1, 2}, 0, 0, false));
root.Add(812401, new SkillData(812401, "s812401", 2f, 1, 2, 50f, 0, true, "s812401des", true, 0.5f, true, 0.8f, 0, new int[] {3, 3173, 0}, new int[] {0, 1, 2}, 0, 0, false));
root.Add(812501, new SkillData(812501, "s812501", 2f, 1, 2, 50f, 0, true, "s812501des", true, 0.5f, true, 0.8f, 0, new int[] {3174, 0, 0}, new int[] {0, 0, 0}, 0, 0, false));
root.Add(812601, new SkillData(812601, "s812601", 2f, 1, 2, 50f, 0, true, "s812601des", true, 0.5f, true, 0.8f, 0, new int[] {3175, 0, 0}, new int[] {0, 0, 0}, 0, 0, false));
root.Add(812701, new SkillData(812701, "s812701", 2f, 1, 2, 50f, 0, true, "s812701des", true, 0.5f, true, 0.8f, 0, new int[] {3176, 0, 0}, new int[] {0, 0, 0}, 0, 0, false));
root.Add(812801, new SkillData(812801, "s812801", 2f, 1, 2, 50f, 0, true, "s812801des", true, 0.5f, true, 0.8f, 0, new int[] {3177, 0, 0}, new int[] {0, 0, 0}, 0, 0, false));
root.Add(812901, new SkillData(812901, "s812901", 2f, 1, 2, 50f, 0, true, "s812901des", true, 0.5f, true, 0.8f, 0, new int[] {3178, 0, 0}, new int[] {0, 0, 0}, 0, 0, false));
root.Add(813001, new SkillData(813001, "s813001", 2f, 1, 2, 50f, 0, true, "s813001des", true, 0.5f, true, 0.8f, 0, new int[] {3179, 0, 0}, new int[] {0, 0, 0}, 0, 0, false));
root.Add(813101, new SkillData(813101, "s813101", 2f, 1, 2, 50f, 0, true, "s813101des", true, 0.5f, true, 0.8f, 0, new int[] {3180, 0, 0}, new int[] {0, 0, 0}, 0, 0, false));
root.Add(813201, new SkillData(813201, "s813201", 2f, 1, 2, 50f, 0, true, "s813201des", true, 0.5f, true, 0.8f, 0, new int[] {3181, 0, 0}, new int[] {0, 0, 0}, 0, 0, false));
root.Add(813301, new SkillData(813301, "s813301", 2f, 1, 2, 50f, 0, true, "s813301des", true, 0.5f, true, 0.8f, 0, new int[] {3182, 0, 0}, new int[] {0, 0, 0}, 0, 0, false));
root.Add(813401, new SkillData(813401, "s813401", 2f, 1, 2, 50f, 0, true, "s813401des", true, 0.5f, true, 0.8f, 0, new int[] {3183, 0, 0}, new int[] {0, 0, 0}, 0, 0, false));
root.Add(813501, new SkillData(813501, "s813501", 2f, 1, 2, 50f, 0, true, "s813501des", true, 0.5f, true, 0.8f, 0, new int[] {3184, 3245, 0}, new int[] {0, 1, 0}, 0, 0, false));
root.Add(813601, new SkillData(813601, "s813601", 1f, 1, 2, 50f, 0, true, "s813601des", true, 0.5f, true, 0.8f, 0, new int[] {3185, 3244, 0}, new int[] {0, 1, 0}, 0, 0, false));
root.Add(813701, new SkillData(813701, "s813701", 1f, 1, 2, 50f, 0, true, "s813701des", true, 0.5f, true, 0.8f, 0, new int[] {3186, 0, 0}, new int[] {0, 0, 0}, 0, 0, false));
root.Add(813801, new SkillData(813801, "s813801", 2f, 1, 2, 50f, 0, true, "s813801des", true, 0.5f, true, 0.8f, 0, new int[] {3187, 3245, 0}, new int[] {0, 1, 0}, 0, 0, false));
root.Add(813901, new SkillData(813901, "s813901", 2f, 1, 2, 50f, 0, true, "s813901des", true, 0.5f, true, 0.8f, 0, new int[] {3188, 0, 0}, new int[] {0, 0, 0}, 0, 0, false));
root.Add(814001, new SkillData(814001, "s814001", 2f, 1, 2, 50f, 0, true, "s814001des", true, 0.5f, true, 0.8f, 0, new int[] {3189, 0, 0}, new int[] {0, 0, 0}, 0, 0, false));
root.Add(814101, new SkillData(814101, "s814101", 2f, 1, 2, 50f, 0, true, "s814101des", true, 0.5f, true, 0.8f, 0, new int[] {3190, 0, 0}, new int[] {0, 0, 0}, 0, 0, false));
root.Add(815101, new SkillData(815101, "s815101", 0.7f, 6, 3, 100f, 0, false, "s815101des", true, 1f, true, 0f, 0, new int[] {3191, 0, 0}, new int[] {0, 0, 0}, 1, 0, false));
root.Add(815201, new SkillData(815201, "s815201", 0.7f, 1, 3, 100f, 0, true, "s815201des", false, 0.5f, false, 0f, 0, new int[] {3192, 0, 0}, new int[] {0, 0, 0}, 8, 0, false));
root.Add(815301, new SkillData(815301, "s815301", 0.7f, 7, 3, 100f, 0, true, "s815301des", false, 0.5f, false, 0f, 0, new int[] {3193, 0, 0}, new int[] {0, 0, 0}, 0, 0, false));
root.Add(815401, new SkillData(815401, "s815401", 0.7f, 1, 3, 100f, 0, true, "s815401des", false, 0.5f, false, 0f, 0, new int[] {3194, 0, 0}, new int[] {0, 0, 0}, 10, 0, false));
root.Add(815501, new SkillData(815501, "s815501", 1.44f, 5, 3, 100f, 0, true, "s815501des", false, 0.5f, false, 0f, 0, new int[] {3195, 0, 0}, new int[] {0, 0, 0}, 0, 0, false));
root.Add(815601, new SkillData(815601, "s815601", 0.7f, 1, 3, 100f, 0, true, "s815601des", false, 0.5f, false, 0f, 0, new int[] {3196, 0, 0}, new int[] {0, 0, 0}, 0, 0, false));
root.Add(815701, new SkillData(815701, "s815701", 0.7f, 1, 3, 100f, 0, true, "s815701des", false, 0.5f, false, 0f, 0, new int[] {3197, 0, 0}, new int[] {0, 0, 0}, 0, 0, false));
root.Add(815801, new SkillData(815801, "s815801", 0.7f, 1, 3, 100f, 0, true, "s815801des", false, 0.5f, false, 0f, 0, new int[] {3198, 0, 0}, new int[] {0, 0, 0}, 0, 0, false));
root.Add(815901, new SkillData(815901, "s815901", 0.7f, 1, 3, 100f, 0, true, "s815901des", false, 0.5f, false, 0f, 0, new int[] {0, 0, 0}, new int[] {0, 0, 0}, 0, 0, false));
root.Add(816001, new SkillData(816001, "s816001", 0.7f, 1, 3, 100f, 0, true, "s816001des", false, 0.5f, false, 0f, 0, new int[] {3200, 0, 0}, new int[] {0, 0, 0}, 0, 0, false));
root.Add(816101, new SkillData(816101, "s816101", 0.7f, 1, 3, 100f, 0, true, "s816101des", false, 0.5f, false, 0f, 0, new int[] {0, 0, 0}, new int[] {0, 0, 0}, 0, 0, false));
root.Add(816201, new SkillData(816201, "s816201", 0.7f, 1, 3, 100f, 0, true, "s816201des", false, 3f, false, 0f, 0, new int[] {3202, 0, 0}, new int[] {0, 0, 0}, 0, 0, false));
root.Add(816301, new SkillData(816301, "s816301", 0.7f, 1, 3, 100f, 0, true, "s816301des", false, 0.5f, false, 0f, 0, new int[] {3203, 0, 0}, new int[] {0, 0, 0}, 0, 0, false));
root.Add(816401, new SkillData(816401, "s816401", 0.7f, 1, 3, 100f, 0, true, "s816401des", false, 0.5f, false, 0f, 0, new int[] {0, 0, 0}, new int[] {0, 0, 0}, 0, 0, false));
root.Add(816501, new SkillData(816501, "s816501", 2f, 5, 3, 100f, 0, true, "s816501des", false, 0.5f, false, 0f, 0, new int[] {3205, 0, 0}, new int[] {0, 0, 0}, 0, 21, false));
root.Add(816601, new SkillData(816601, "s816601", 2f, 5, 3, 100f, 0, true, "s816601des", false, 0.5f, false, 0f, 0, new int[] {3206, 0, 0}, new int[] {0, 0, 0}, 0, 22, false));
root.Add(816701, new SkillData(816701, "s816701", 2f, 5, 3, 100f, 0, true, "s816701des", false, 0.5f, false, 0f, 0, new int[] {3207, 0, 0}, new int[] {0, 0, 0}, 0, 23, false));
root.Add(816801, new SkillData(816801, "s816801", 2f, 5, 3, 100f, 0, true, "s816801des", false, 0.5f, false, 0f, 0, new int[] {3208, 0, 0}, new int[] {0, 0, 0}, 0, 24, false));
root.Add(816901, new SkillData(816901, "s816901", 2f, 5, 3, 100f, 0, true, "s816901des", false, 0.5f, false, 0f, 0, new int[] {3, 3209, 0}, new int[] {0, 1, 0}, 0, 25, false));
root.Add(817001, new SkillData(817001, "s817001", 2f, 5, 3, 100f, 0, true, "s817001des", false, 0.5f, false, 0f, 0, new int[] {0, 0, 0}, new int[] {0, 0, 0}, 0, 26, false));
root.Add(817101, new SkillData(817101, "s817101", 2f, 5, 3, 100f, 0, true, "s817101des", false, 0.5f, false, 0f, 0, new int[] {0, 0, 0}, new int[] {0, 0, 0}, 0, 27, false));
root.Add(817201, new SkillData(817201, "s817201", 2f, 5, 3, 100f, 0, true, "s817201des", false, 0.5f, false, 0f, 0, new int[] {3, 0, 0}, new int[] {0, 0, 0}, 0, 28, false));
root.Add(817301, new SkillData(817301, "s817301", 2f, 1, 3, 100f, 0, true, "s817301des", false, 0.5f, false, 0f, 0, new int[] {3129, 3213, 0}, new int[] {0, 1, 0}, 0, 29, false));
root.Add(817401, new SkillData(817401, "s817401", 2f, 5, 3, 100f, 0, true, "s817401des", false, 0.5f, false, 0f, 0, new int[] {0, 0, 0}, new int[] {0, 0, 0}, 0, 30, false));
root.Add(817501, new SkillData(817501, "s817501", 2f, 8, 3, 100f, 0, true, "s817501des", false, 0.5f, false, 0f, 0, new int[] {3, 0, 0}, new int[] {0, 0, 0}, 0, 31, false));
root.Add(817601, new SkillData(817601, "s817601", 2f, 8, 3, 100f, 0, true, "s817601des", false, 0.5f, false, 0f, 0, new int[] {3216, 0, 0}, new int[] {0, 0, 0}, 0, 32, false));
root.Add(817701, new SkillData(817701, "s817701", 2f, 8, 3, 100f, 0, true, "s817701des", false, 0.5f, false, 0f, 0, new int[] {0, 0, 0}, new int[] {0, 0, 0}, 0, 0, false));
root.Add(817801, new SkillData(817801, "s817801", 2f, 8, 3, 100f, 0, true, "s817801des", false, 0.5f, false, 0f, 0, new int[] {0, 0, 0}, new int[] {0, 0, 0}, 0, 0, false));
root.Add(817901, new SkillData(817901, "s817901", 2f, 1, 3, 100f, 0, true, "s817901des", false, 0.5f, false, 0f, 0, new int[] {3219, 0, 0}, new int[] {0, 0, 0}, 0, 0, false));
root.Add(818001, new SkillData(818001, "s818001", 2f, 1, 3, 100f, 0, true, "s818001des", false, 0.5f, false, 0f, 0, new int[] {3, 3220, 0}, new int[] {0, 1, 0}, 0, 0, false));
root.Add(818101, new SkillData(818101, "s818101", 2f, 1, 3, 100f, 0, true, "s818101des", false, 0.5f, false, 0f, 0, new int[] {3221, 0, 0}, new int[] {0, 0, 0}, 0, 0, false));
root.Add(818201, new SkillData(818201, "s818201", 2f, 1, 3, 100f, 0, true, "s818201des", false, 0.5f, false, 0f, 0, new int[] {3222, 0, 0}, new int[] {0, 0, 0}, 0, 0, false));
root.Add(818301, new SkillData(818301, "s818301", 2f, 1, 3, 100f, 0, true, "s818301des", false, 0.5f, false, 0f, 0, new int[] {3223, 0, 0}, new int[] {0, 0, 0}, 0, 0, false));
root.Add(818401, new SkillData(818401, "s818401", 2f, 1, 3, 100f, 0, true, "s818401des", false, 0.5f, false, 0f, 0, new int[] {3224, 0, 0}, new int[] {0, 0, 0}, 0, 0, false));
root.Add(818501, new SkillData(818501, "s818501", 2f, 1, 3, 100f, 0, true, "s818501des", false, 0.5f, false, 0f, 0, new int[] {3225, 0, 0}, new int[] {0, 0, 0}, 0, 0, false));
root.Add(818601, new SkillData(818601, "s818601", 2f, 1, 3, 100f, 0, true, "s818601des", false, 0.5f, false, 0f, 0, new int[] {3226, 0, 0}, new int[] {0, 0, 0}, 0, 0, false));
root.Add(818701, new SkillData(818701, "s818701", 2f, 1, 3, 100f, 0, true, "s818701des", false, 0.5f, false, 0f, 0, new int[] {3227, 0, 0}, new int[] {0, 0, 0}, 0, 0, false));
root.Add(818801, new SkillData(818801, "s818801", 2f, 1, 3, 100f, 0, true, "s818801des", false, 0.5f, false, 0f, 0, new int[] {3228, 3002, 0}, new int[] {0, 0, 0}, 0, 0, false));
root.Add(818901, new SkillData(818901, "s818901", 2f, 1, 3, 100f, 0, true, "s818901des", false, 0.5f, false, 0f, 0, new int[] {0, 0, 0}, new int[] {0, 0, 0}, 0, 0, false));
root.Add(819001, new SkillData(819001, "s819001", 2f, 1, 3, 100f, 0, true, "s819001des", false, 0.5f, false, 0f, 0, new int[] {3230, 3241, 0}, new int[] {0, 1, 0}, 0, 0, false));
root.Add(819101, new SkillData(819101, "s819101", 2f, 1, 3, 100f, 0, true, "s819101des", false, 0.5f, false, 0f, 0, new int[] {3, 3154, 0}, new int[] {0, 1, 0}, 6, 0, false));
root.Add(819201, new SkillData(819201, "s819201", 2f, 1, 3, 100f, 0, true, "s819201des", false, 0.5f, false, 0f, 0, new int[] {0, 0, 0}, new int[] {0, 0, 0}, 0, 0, false));
root.Add(819301, new SkillData(819301, "s819301", 2f, 1, 3, 100f, 0, true, "s819301des", false, 0.5f, false, 0f, 0, new int[] {0, 0, 0}, new int[] {0, 0, 0}, 0, 0, false));
root.Add(819401, new SkillData(819401, "s819401", 2f, 6, 3, 100f, 0, true, "s819401des", false, 0.5f, false, 0f, 0, new int[] {3, 0, 0}, new int[] {0, 0, 0}, 50, 0, false));
root.Add(819501, new SkillData(819501, "s819501", 2f, 7, 3, 100f, 0, true, "s819501des", false, 0.5f, false, 0f, 0, new int[] {3, 0, 0}, new int[] {0, 0, 0}, 51, 0, false));
root.Add(819601, new SkillData(819601, "s819601", 2f, 7, 3, 100f, 0, true, "s819601des", false, 0.5f, false, 0f, 0, new int[] {3237, 0, 0}, new int[] {0, 0, 0}, 52, 0, false));
root.Add(819701, new SkillData(819701, "s819701", 2f, 7, 3, 100f, 0, true, "s819701des", false, 0.5f, false, 0f, 0, new int[] {3, 0, 0}, new int[] {0, 0, 0}, 53, 0, false));
root.Add(819801, new SkillData(819801, "s819801", 2f, 7, 3, 100f, 0, true, "s819801des", false, 0.5f, false, 0f, 0, new int[] {0, 0, 0}, new int[] {0, 0, 0}, 54, 0, false));
root.Add(819901, new SkillData(819901, "s819901", 2f, 7, 3, 100f, 0, true, "s819901des", false, 0.5f, false, 0f, 0, new int[] {0, 0, 0}, new int[] {0, 0, 0}, 55, 0, false));
root.Add(820001, new SkillData(820001, "s820001", 2f, 7, 3, 100f, 0, true, "s820001des", false, 0.5f, false, 0f, 0, new int[] {0, 0, 0}, new int[] {0, 0, 0}, 56, 0, false));
root.Add(900101, new SkillData(900101, "s900101", 0.5f, 1, 1, 0f, 0, true, "s900101des", true, 1f, true, 4f, 0, new int[] {3509, 0, 0}, new int[] {0, 0, 0}, 0, 0, true));
root.Add(900201, new SkillData(900201, "s900201", 0.5f, 1, 1, 0f, 0, true, "s900201des", true, 1f, true, 2f, 0, new int[] {3509, 0, 0}, new int[] {0, 0, 0}, 0, 0, true));
root.Add(900301, new SkillData(900301, "s900301", 0.5f, 1, 1, 0f, 0, true, "s900301des", true, 2f, true, 2f, 0, new int[] {3520, 0, 0}, new int[] {0, 0, 0}, 0, 0, true));
root.Add(900401, new SkillData(900401, "s900401", 3.2f, 1, 1, 0f, 0, true, "s900401des", true, 1f, true, 4f, 0, new int[] {3, 3503, 3504}, new int[] {0, 1, 2}, 0, 0, true));
root.Add(900501, new SkillData(900501, "s900501", 0.7f, 1, 1, 0f, 0, true, "s900501des", true, 1f, true, 4f, 0, new int[] {3508, 0, 0}, new int[] {0, 0, 0}, 0, 0, true));
root.Add(900601, new SkillData(900601, "s900601", 0.7f, 1, 1, 0f, 0, true, "s900601des", true, 1f, true, 2f, 0, new int[] {3508, 0, 0}, new int[] {0, 0, 0}, 0, 0, true));
root.Add(900701, new SkillData(900701, "s900701", 0.5f, 1, 1, 0f, 0, true, "s900701des", true, 1f, true, 4f, 0, new int[] {3, 3504, 0}, new int[] {0, 1, 0}, 0, 0, true));
root.Add(900801, new SkillData(900801, "s900801", 0.5f, 1, 1, 0f, 0, true, "s900801des", true, 1f, true, 2f, 0, new int[] {3508, 0, 0}, new int[] {0, 0, 0}, 0, 0, true));
root.Add(900901, new SkillData(900901, "s900901", 0.5f, 1, 1, 0f, 0, true, "s900901des", true, 1f, true, 2f, 0, new int[] {3508, 0, 0}, new int[] {0, 0, 0}, 0, 0, true));
root.Add(901001, new SkillData(901001, "s901001", 0.5f, 1, 1, 0f, 0, true, "s901001des", true, 1f, true, 2f, 0, new int[] {3509, 0, 0}, new int[] {0, 0, 0}, 0, 0, true));
root.Add(901101, new SkillData(901101, "s901101", 0.5f, 1, 1, 0f, 0, true, "s901101des", true, 1f, true, 1f, 0, new int[] {3508, 0, 0}, new int[] {0, 0, 0}, 0, 0, true));
root.Add(901201, new SkillData(901201, "s901201", 0.5f, 1, 1, 0f, 0, true, "s901201des", true, 1f, true, 1f, 0, new int[] {3509, 0, 0}, new int[] {0, 0, 0}, 0, 0, true));
root.Add(901301, new SkillData(901301, "s901301", 2f, 1, 1, 0f, 10, true, "s901301des", true, 1.3f, true, 0.8f, 0, new int[] {3510, 0, 0}, new int[] {0, 0, 0}, 0, 0, true));
root.Add(901401, new SkillData(901401, "s901401", 2f, 1, 1, 0f, 10, true, "s901401des", true, 1.3f, true, 0.8f, 0, new int[] {3511, 0, 0}, new int[] {0, 0, 0}, 0, 0, true));
root.Add(901501, new SkillData(901501, "s901501", 2f, 1, 1, 0f, 10, true, "s901501des", true, 1.3f, true, 0.8f, 0, new int[] {3512, 0, 0}, new int[] {0, 0, 0}, 0, 0, true));
root.Add(901601, new SkillData(901601, "s901601", 2f, 1, 1, 0f, 10, true, "s901601des", true, 1.3f, true, 0.8f, 0, new int[] {3513, 0, 0}, new int[] {0, 0, 0}, 0, 0, true));
root.Add(901701, new SkillData(901701, "s901701", 2f, 1, 1, 0f, 10, true, "s901701des", true, 1.3f, true, 0.8f, 0, new int[] {3514, 0, 0}, new int[] {0, 0, 0}, 0, 0, true));
root.Add(901801, new SkillData(901801, "s901801", 0.5f, 1, 1, 0f, 0, true, "s901801des", true, 1f, true, 3f, 0, new int[] {3515, 0, 0}, new int[] {0, 0, 0}, 0, 0, true));
root.Add(901901, new SkillData(901901, "s901901", 0.5f, 1, 1, 0f, 0, true, "s901901des", true, 1f, true, 3f, 0, new int[] {3516, 0, 0}, new int[] {0, 0, 0}, 0, 0, true));
root.Add(902001, new SkillData(902001, "s902001", 0.5f, 1, 1, 0f, 0, true, "s902001des", true, 1f, true, 3f, 0, new int[] {3517, 0, 0}, new int[] {0, 0, 0}, 0, 0, true));
root.Add(902101, new SkillData(902101, "s902101", 0.5f, 1, 1, 0f, 0, true, "s902101des", true, 1f, true, 3f, 0, new int[] {3518, 0, 0}, new int[] {0, 0, 0}, 0, 0, true));
root.Add(902201, new SkillData(902201, "s902201", 0.5f, 1, 1, 0f, 0, true, "s902201des", true, 1f, true, 3f, 0, new int[] {3519, 0, 0}, new int[] {0, 0, 0}, 0, 0, true));
root.Add(902301, new SkillData(902301, "s902301", 0.5f, 1, 1, 0f, 0, true, "s902301des", true, 1f, true, 3f, 0, new int[] {3520, 0, 0}, new int[] {0, 0, 0}, 0, 0, true));
root.Add(902401, new SkillData(902401, "s902401", 0.5f, 1, 1, 0f, 0, true, "s902401des", true, 1f, true, 3f, 0, new int[] {3521, 0, 0}, new int[] {0, 0, 0}, 0, 0, true));
root.Add(902501, new SkillData(902501, "s902501", 0.5f, 1, 1, 0f, 0, true, "s902501des", true, 1f, true, 3f, 0, new int[] {3522, 0, 0}, new int[] {0, 0, 0}, 0, 0, true));
root.Add(902601, new SkillData(902601, "s902601", 0.5f, 1, 1, 0f, 0, true, "s902601des", true, 1f, true, 3f, 0, new int[] {3523, 0, 0}, new int[] {0, 0, 0}, 0, 0, true));
root.Add(902701, new SkillData(902701, "s902701", 0.5f, 1, 1, 0f, 0, true, "s902701des", true, 1f, true, 3f, 0, new int[] {3524, 0, 0}, new int[] {0, 0, 0}, 0, 0, true));
}
public SkillData GetReadData(int ID){
if (root.ContainsKey(ID))
return root[ID];
else{
object obj = MMFramework.ModifyExcelModule.Instance.GetModifyedData(ID);
if (obj != null)return obj as SkillData;
Debug.LogError("在表格 SkillData中没有找到ID" + ID);
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
SkillData data = GetReadData(key);
Type type = data.GetType();
System.Reflection.FieldInfo[] filedinfos = type.GetFields();
for (int i = 0; i < filedinfos.Length; i++)
{System.Reflection.FieldInfo field = filedinfos[i];
pairs.Add(field.Name, field.GetValue(data).ToString());}
return pairs;}
}
public static SkillData GetData(int ID){
return SkillDataReader.Instance.GetReadData(ID);
}
public static Dictionary<string, string> GetDictionary(int key)
{ return SkillDataReader.Instance.GetReadDictionary(key);}
public static int GetNum(){
return SkillDataReader.Instance.GetCount();
}
public static List<int> GetKeys(){
return SkillDataReader.Instance.GetDataKeys();
}
public static void SaveToFile(string path){
SkillDataReader.Instance.WriteToFile(path);
}

}