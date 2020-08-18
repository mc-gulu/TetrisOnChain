using System;
using System.Collections.Generic;
using UnityEngine;
[Serializable]
public class FireData{
/// <summary>
/// 序号
/// </summary>
public int ID;
/// <summary>
/// 名字
/// </summary>
public string Name;
/// <summary>
/// 图标
/// </summary>
public string Icon;
/// <summary>
/// 信息
/// </summary>
public string Info;
/// <summary>
/// 子弹ID
/// </summary>
public int BulletID;
/// <summary>
/// 是否暴击
/// </summary>
public bool CanBigAtk;
/// <summary>
/// 跟踪范围
/// </summary>
public int FollowRange;
/// <summary>
/// 跟踪转角
/// </summary>
public float FollowAngle;
/// <summary>
/// 击退种类(0不击退，1直接击退，2圆周击退）
/// </summary>
public int AtkBackType;
/// <summary>
/// 击退
/// </summary>
public float AtkBack;
/// <summary>
/// 子弹持续时间
/// </summary>
public float BulletLastTime;
/// <summary>
/// 伤害系数
/// </summary>
public float Atkr;
/// <summary>
/// 暴击伤害系数
/// </summary>
public float BigAtkr;
/// <summary>
/// 是否跟人一起走
/// </summary>
public bool WithBody;
/// <summary>
/// 动作到子弹延迟
/// </summary>
public float FireDelay;
/// <summary>
/// 发射方式
/// </summary>
public int StrategyType;
/// <summary>
/// 参数0
/// </summary>
public float[] StrategyArray;
/// <summary>
/// 是否吸血
/// </summary>
public bool IsSuckBlood;
/// <summary>
/// 直击目标
/// </summary>
public bool TargetOnly;
/// <summary>
/// 攻击者显示ID
/// </summary>
public int FireDisplayID;
/// <summary>
/// 被打者显示ID1
/// </summary>
public int[] ColliderDisplayIDArray;
public FireData(int ID, string Name, string Icon, string Info, int BulletID, bool CanBigAtk, int FollowRange, float FollowAngle, int AtkBackType, float AtkBack, float BulletLastTime, float Atkr, float BigAtkr, bool WithBody, float FireDelay, int StrategyType, float[] StrategyArray, bool IsSuckBlood, bool TargetOnly, int FireDisplayID, int[] ColliderDisplayIDArray){
this.ID = ID;
this.Name = Name;
this.Icon = Icon;
this.Info = Info;
this.BulletID = BulletID;
this.CanBigAtk = CanBigAtk;
this.FollowRange = FollowRange;
this.FollowAngle = FollowAngle;
this.AtkBackType = AtkBackType;
this.AtkBack = AtkBack;
this.BulletLastTime = BulletLastTime;
this.Atkr = Atkr;
this.BigAtkr = BigAtkr;
this.WithBody = WithBody;
this.FireDelay = FireDelay;
this.StrategyType = StrategyType;
this.StrategyArray = StrategyArray;
this.IsSuckBlood = IsSuckBlood;
this.TargetOnly = TargetOnly;
this.FireDisplayID = FireDisplayID;
this.ColliderDisplayIDArray = ColliderDisplayIDArray;
}
class FireDataReader{
static FireDataReader instance;
static object syncRoot = new object();
public static FireDataReader Instance{get{if (instance == null){lock (syncRoot){if (instance == null){instance = new FireDataReader();instance.Load();}}}return instance;}}
Dictionary<int, FireData> root = new Dictionary<int, FireData>();
void Load(){
root.Add(1, new FireData(1, "f1", "", "", 1, false, 2000, 100f, 0, 0f, 10f, 0f, 0f, false, 0f, 1, new float[] {1f, 10f, 0f, 0f, 0f, 0f}, false, true, 0, new int[] {0, 0, 0}));
root.Add(2, new FireData(2, "f2", "", "", 2, false, 2000, 100f, 0, 0f, 3f, 0f, 0f, false, 0f, 4, new float[] {0f, 1f, 0f, 0f, 0f, 0f}, false, false, 0, new int[] {0, 0, 0}));
root.Add(3, new FireData(3, "f3", "", "", 3, false, 2000, 100f, 0, 0f, 3f, 0f, 0f, false, 0f, 1, new float[] {1f, 10f, 0f, 0f, 0f, 0f}, false, true, 0, new int[] {0, 0, 0}));
root.Add(4, new FireData(4, "f4", "", "", 4, false, 2000, 100f, 0, 0f, -1f, 0f, 0f, false, 0f, 4, new float[] {0f, 0f, 0f, 0f, 0f, 0f}, false, true, 3, new int[] {0, 0, 0}));
root.Add(3001, new FireData(3001, "f3001", "", "", 4001, true, 0, 0f, 2, 0f, -1f, 1f, 1.7f, false, 0f, 4, new float[] {0f, 0f, 0f, 0f, 0f, 0f}, false, true, 1, new int[] {0, 12, 101}));
root.Add(3002, new FireData(3002, "f3002", "", "", 4501, true, 0, 0f, 2, 0f, -1f, 0f, 0f, true, 0f, 4, new float[] {0f, 0f, 0f, 0f, 0f, 0f}, false, false, 1, new int[] {2, 0, 0}));
root.Add(3003, new FireData(3003, "f3003", "", "", 4005, true, 2000, 100f, 2, 0f, 10f, 1f, 1.7f, false, 0.1f, 1, new float[] {1f, 10f, 0.3f, 0f, 0f, 0f}, false, true, 1, new int[] {2, 12, 101}));
root.Add(3004, new FireData(3004, "f3004", "", "", 4002, true, 0, 0f, 2, 0f, -1f, 1f, 1.7f, true, 0f, 4, new float[] {0f, 0f, 0f, 0f, 0f, 0f}, false, false, 1, new int[] {2, 12, 101}));
root.Add(3005, new FireData(3005, "f3005", "", "", 4003, true, 0, 0f, 2, 0f, -1f, 1f, 1.7f, true, 0f, 4, new float[] {0f, 0f, 0f, 0f, 0f, 0f}, false, false, 1, new int[] {2, 12, 101}));
root.Add(3006, new FireData(3006, "f3006", "", "", 3, true, 0, 0f, 0, 0f, 0f, 0f, 0f, false, 0f, 0, new float[] {0f, 0f, 0f, 0f, 0f, 0f}, false, false, 0, new int[] {0, 0, 0}));
root.Add(3007, new FireData(3007, "f3007", "", "", 3, true, 0, 0f, 0, 0f, 0f, 0f, 0f, false, 0f, 0, new float[] {0f, 0f, 0f, 0f, 0f, 0f}, false, false, 0, new int[] {0, 0, 0}));
root.Add(3008, new FireData(3008, "f3008", "", "", 3, true, 0, 0f, 0, 0f, 0f, 0f, 0f, false, 0f, 0, new float[] {0f, 0f, 0f, 0f, 0f, 0f}, false, false, 0, new int[] {0, 0, 0}));
root.Add(3009, new FireData(3009, "f3009", "", "", 3, true, 0, 0f, 0, 0f, 0f, 0f, 0f, false, 0f, 0, new float[] {0f, 0f, 0f, 0f, 0f, 0f}, false, false, 0, new int[] {0, 0, 0}));
root.Add(3010, new FireData(3010, "f3010", "", "", 3, true, 0, 0f, 0, 0f, 0f, 0f, 0f, false, 0f, 0, new float[] {0f, 0f, 0f, 0f, 0f, 0f}, false, false, 0, new int[] {0, 0, 0}));
root.Add(3011, new FireData(3011, "f3011", "", "", 3, true, 0, 0f, 0, 0f, 0f, 0f, 0f, false, 0f, 0, new float[] {0f, 0f, 0f, 0f, 0f, 0f}, false, false, 0, new int[] {0, 0, 0}));
root.Add(3012, new FireData(3012, "f3012", "", "", 3, true, 0, 0f, 0, 0f, 0f, 0f, 0f, false, 0f, 0, new float[] {0f, 0f, 0f, 0f, 0f, 0f}, false, false, 0, new int[] {0, 0, 0}));
root.Add(3013, new FireData(3013, "f3013", "", "", 2, false, 0, 0f, 0, 0f, 1f, 0f, 0f, true, 0f, 4, new float[] {0f, 1f, 0f, 0f, 0f, 0f}, false, false, 0, new int[] {5, 0, 0}));
root.Add(3014, new FireData(3014, "f3014", "", "", 3, false, 2000, 100f, 0, 0f, 3f, 0f, 0f, false, 0f, 1, new float[] {1f, 30f, 0f, 0f, 0f, 0f}, false, true, 1, new int[] {0, 0, 0}));
root.Add(3100, new FireData(3100, "f3100", "", "", 5, true, 0, 0f, 2, 30f, 0.3f, 1f, 1.7f, false, 0.41f, 4, new float[] {0f, 0f, 0f, 0f, 0f, 0f}, false, false, 1, new int[] {2, 12, 101}));
root.Add(3101, new FireData(3101, "f3101", "", "", 5, true, 0, 0f, 2, 30f, 0.3f, 1f, 1.7f, false, 0.41f, 4, new float[] {0f, 0f, 0f, 0f, 0f, 0f}, false, false, 1, new int[] {2, 12, 101}));
root.Add(3102, new FireData(3102, "f3102", "", "", 5, true, 0, 0f, 2, 30f, 0.3f, 1f, 1.7f, false, 0.41f, 4, new float[] {0f, 0f, 0f, 0f, 0f, 0f}, false, false, 1, new int[] {2, 12, 101}));
root.Add(3103, new FireData(3103, "f3103", "", "", 5, true, 0, 0f, 2, 30f, 0.3f, 1f, 1.7f, false, 0.41f, 4, new float[] {0f, 0f, 0f, 0f, 0f, 0f}, false, false, 1, new int[] {2, 12, 101}));
root.Add(3104, new FireData(3104, "f3104", "", "", 5, true, 0, 0f, 2, 30f, 0.3f, 1f, 1.7f, false, 0.41f, 4, new float[] {0f, 0f, 0f, 0f, 0f, 0f}, false, false, 1, new int[] {2, 12, 101}));
root.Add(3105, new FireData(3105, "f3105", "", "", 6, true, 0, 0f, 2, 30f, 0.3f, 1f, 1.7f, false, 0.41f, 4, new float[] {0f, 1f, 0f, 0f, 0f, 0f}, false, false, 1, new int[] {2, 12, 101}));
root.Add(3106, new FireData(3106, "f3106", "", "", 6, true, 0, 0f, 2, 30f, 0.3f, 1f, 1.7f, false, 0.41f, 4, new float[] {0f, 1f, 0f, 0f, 0f, 0f}, false, false, 1, new int[] {2, 12, 101}));
root.Add(3107, new FireData(3107, "f3107", "", "", 6, true, 0, 0f, 2, 30f, 0.3f, 1f, 1.7f, false, 0.41f, 4, new float[] {0f, 1f, 0f, 0f, 0f, 0f}, false, false, 1, new int[] {2, 12, 101}));
root.Add(3108, new FireData(3108, "f3108", "", "", 6, true, 0, 0f, 2, 30f, 0.3f, 1f, 1.7f, false, 0.41f, 4, new float[] {0f, 1f, 0f, 0f, 0f, 0f}, false, false, 1, new int[] {2, 12, 101}));
root.Add(3109, new FireData(3109, "f3109", "", "", 6, true, 0, 0f, 2, 30f, 0.3f, 1f, 1.7f, false, 0.41f, 4, new float[] {0f, 1f, 0f, 0f, 0f, 0f}, false, false, 1, new int[] {2, 12, 101}));
root.Add(3110, new FireData(3110, "f3110", "", "", 4110, true, 2000, 100f, 2, 30f, 10f, 1f, 1.7f, false, 0.4f, 1, new float[] {1f, 5f, 0.3f, 0f, 0f, 0f}, false, true, 1, new int[] {2, 26, 101}));
root.Add(3111, new FireData(3111, "f3111", "", "", 4111, true, 2000, 100f, 2, 30f, 10f, 1f, 1.7f, false, 0.4f, 1, new float[] {1f, 5f, 0.3f, 0f, 0f, 0f}, false, true, 1, new int[] {2, 27, 101}));
root.Add(3112, new FireData(3112, "f3112", "", "", 4112, true, 2000, 100f, 2, 30f, 10f, 1f, 1.7f, false, 0.4f, 1, new float[] {1f, 5f, 0.3f, 0f, 0f, 0f}, false, true, 1, new int[] {2, 28, 101}));
root.Add(3113, new FireData(3113, "f3113", "", "", 4113, true, 2000, 100f, 2, 30f, 10f, 1f, 1.7f, false, 0.4f, 1, new float[] {1f, 5f, 0.3f, 0f, 0f, 0f}, false, true, 1, new int[] {2, 29, 101}));
root.Add(3114, new FireData(3114, "f3114", "", "", 4114, true, 2000, 100f, 2, 30f, 10f, 1f, 1.7f, false, 0.4f, 1, new float[] {1f, 5f, 0.3f, 0f, 0f, 0f}, false, true, 1, new int[] {2, 30, 101}));
root.Add(3115, new FireData(3115, "f3115", "", "", 4115, true, 2000, 100f, 2, 30f, 10f, 1f, 1.7f, false, 0.27f, 1, new float[] {1f, 3f, 0.3f, 0f, 0f, 0f}, false, true, 1, new int[] {2, 13, 101}));
root.Add(3116, new FireData(3116, "f3116", "", "", 4116, true, 2000, 100f, 2, 30f, 10f, 1f, 1.7f, false, 0.27f, 1, new float[] {1f, 3f, 0.3f, 0f, 0f, 0f}, false, true, 1, new int[] {2, 14, 101}));
root.Add(3117, new FireData(3117, "f3117", "", "", 4117, true, 2000, 100f, 2, 30f, 10f, 1f, 1.7f, false, 0.27f, 1, new float[] {1f, 3f, 0.3f, 0f, 0f, 0f}, false, true, 1, new int[] {2, 15, 101}));
root.Add(3118, new FireData(3118, "f3118", "", "", 4118, true, 2000, 100f, 2, 30f, 10f, 1f, 1.7f, false, 0.27f, 1, new float[] {1f, 3f, 0.3f, 0f, 0f, 0f}, false, true, 1, new int[] {2, 16, 101}));
root.Add(3119, new FireData(3119, "f3119", "", "", 4119, true, 2000, 100f, 2, 30f, 10f, 1f, 1.7f, false, 0.27f, 1, new float[] {1f, 3f, 0.3f, 0f, 0f, 0f}, false, true, 1, new int[] {2, 17, 101}));
root.Add(3120, new FireData(3120, "f3120", "", "", 4120, true, 2000, 100f, 2, 30f, 10f, 0f, 0f, false, 0.16f, 1, new float[] {1f, 4f, 0.3f, 0f, 0f, 0f}, false, true, 1, new int[] {0, 0, 0}));
root.Add(3121, new FireData(3121, "f3121", "", "", 4121, true, 2000, 100f, 2, 30f, 10f, 1f, 1.7f, false, 0.16f, 1, new float[] {1f, 4f, 0.3f, 0f, 0f, 0f}, false, true, 1, new int[] {0, 0, 0}));
root.Add(3122, new FireData(3122, "f3122", "", "", 4122, true, 2000, 100f, 2, 30f, 10f, 1f, 1.7f, false, 0.16f, 1, new float[] {1f, 4f, 0.3f, 0f, 0f, 0f}, false, true, 1, new int[] {0, 0, 0}));
root.Add(3123, new FireData(3123, "f3123", "", "", 4123, true, 2000, 100f, 2, 30f, 10f, 1f, 1.7f, false, 0.16f, 1, new float[] {1f, 4f, 0.3f, 0f, 0f, 0f}, false, true, 1, new int[] {0, 0, 0}));
root.Add(3124, new FireData(3124, "f3124", "", "", 4124, true, 2000, 100f, 2, 30f, 10f, 1f, 1.7f, false, 0.16f, 1, new float[] {1f, 4f, 0.3f, 0f, 0f, 0f}, false, true, 1, new int[] {0, 0, 0}));
root.Add(3125, new FireData(3125, "f3125", "", "", 4125, true, 2000, 100f, 2, 30f, 10f, 1f, 1.7f, false, 0.16f, 1, new float[] {1f, 3f, 0.3f, 0f, 0f, 0f}, false, true, 1, new int[] {2, 13, 101}));
root.Add(3126, new FireData(3126, "f3126", "", "", 4126, true, 2000, 100f, 2, 30f, 10f, 1f, 1.7f, false, 0.16f, 1, new float[] {1f, 3f, 0.3f, 0f, 0f, 0f}, false, true, 1, new int[] {2, 14, 101}));
root.Add(3127, new FireData(3127, "f3127", "", "", 4127, true, 2000, 100f, 2, 30f, 10f, 1f, 1.7f, false, 0.16f, 1, new float[] {1f, 3f, 0.3f, 0f, 0f, 0f}, false, true, 1, new int[] {2, 15, 101}));
root.Add(3128, new FireData(3128, "f3128", "", "", 4128, true, 2000, 100f, 2, 30f, 10f, 1f, 1.7f, false, 0.16f, 1, new float[] {1f, 3f, 0.3f, 0f, 0f, 0f}, false, true, 1, new int[] {2, 16, 101}));
root.Add(3129, new FireData(3129, "f3129", "", "", 4129, true, 2000, 100f, 2, 30f, 10f, 1f, 1.7f, false, 0.16f, 1, new float[] {1f, 3f, 0.3f, 0f, 0f, 0f}, false, true, 1, new int[] {2, 17, 101}));
root.Add(3130, new FireData(3130, "f3130", "", "", 4130, true, 2000, 100f, 2, 30f, 10f, 1f, 1.7f, false, 0.08f, 1, new float[] {1f, 10f, 0.3f, 0f, 0f, 0f}, false, true, 1, new int[] {2, 31, 101}));
root.Add(3131, new FireData(3131, "f3131", "", "", 4131, true, 2000, 100f, 2, 30f, 10f, 1f, 1.7f, false, 0.08f, 1, new float[] {1f, 10f, 0.3f, 0f, 0f, 0f}, false, true, 1, new int[] {2, 32, 101}));
root.Add(3132, new FireData(3132, "f3132", "", "", 4132, true, 2000, 100f, 2, 30f, 10f, 1f, 1.7f, false, 0.08f, 1, new float[] {1f, 10f, 0.3f, 0f, 0f, 0f}, false, true, 1, new int[] {2, 33, 101}));
root.Add(3133, new FireData(3133, "f3133", "", "", 4133, true, 2000, 100f, 2, 30f, 10f, 1f, 1.7f, false, 0.08f, 1, new float[] {1f, 10f, 0.3f, 0f, 0f, 0f}, false, true, 1, new int[] {2, 34, 101}));
root.Add(3134, new FireData(3134, "f3134", "", "", 4134, true, 2000, 100f, 2, 30f, 10f, 1f, 1.7f, false, 0.08f, 1, new float[] {1f, 10f, 0.3f, 0f, 0f, 0f}, false, true, 1, new int[] {2, 35, 101}));
root.Add(3135, new FireData(3135, "f3135", "", "", 5, true, 0, 0f, 2, 30f, 0.2f, 1f, 1.7f, false, 0.25f, 4, new float[] {0f, 1f, 0f, 0f, 0f, 0f}, false, false, 1, new int[] {2, 0, 0}));
root.Add(3136, new FireData(3136, "f3136", "", "", 6, true, 0, 0f, 2, 30f, 0.2f, 1f, 1.7f, false, 0.25f, 4, new float[] {0f, 1f, 0f, 0f, 0f, 0f}, false, false, 1, new int[] {2, 0, 0}));
root.Add(3137, new FireData(3137, "f3137", "", "", 4135, true, 0, 0f, 2, 30f, 1f, 1f, 1.7f, false, 0f, 4, new float[] {0f, 1f, 0f, 0f, 0f, 0f}, false, false, 0, new int[] {2, 0, 101}));
root.Add(3138, new FireData(3138, "f3138", "", "", 4136, true, 0, 0f, 2, 30f, 1f, 1f, 1.7f, false, 0f, 4, new float[] {0f, 1f, 0f, 0f, 0f, 0f}, false, false, 0, new int[] {2, 0, 101}));
root.Add(3139, new FireData(3139, "f3139", "", "", 4137, true, 0, 0f, 2, 30f, 1f, 1f, 1.7f, false, 0f, 4, new float[] {0f, 1f, 0f, 0f, 0f, 0f}, false, false, 0, new int[] {2, 0, 101}));
root.Add(3140, new FireData(3140, "f3140", "", "", 4138, true, 0, 0f, 2, 30f, 1f, 1f, 1.7f, false, 0f, 4, new float[] {0f, 1f, 0f, 0f, 0f, 0f}, false, false, 0, new int[] {2, 0, 101}));
root.Add(3141, new FireData(3141, "f3141", "", "", 4139, true, 0, 0f, 2, 30f, 1f, 1f, 1.7f, false, 0f, 4, new float[] {0f, 1f, 0f, 0f, 0f, 0f}, false, false, 0, new int[] {2, 0, 101}));
root.Add(3142, new FireData(3142, "f3142", "", "", 0, false, 0, 0f, 0, 0f, 0f, 0f, 0f, false, 0f, 0, new float[] {0f, 0f, 0f, 0f, 0f, 0f}, false, false, 0, new int[] {0, 0, 0}));
root.Add(3143, new FireData(3143, "f3143", "", "", 0, false, 0, 0f, 0, 0f, 0f, 0f, 0f, false, 0f, 0, new float[] {0f, 0f, 0f, 0f, 0f, 0f}, false, false, 0, new int[] {0, 0, 0}));
root.Add(3144, new FireData(3144, "f3144", "", "", 0, false, 0, 0f, 0, 0f, 0f, 0f, 0f, false, 0f, 0, new float[] {0f, 0f, 0f, 0f, 0f, 0f}, false, false, 0, new int[] {0, 0, 0}));
root.Add(3145, new FireData(3145, "f3145", "", "", 0, false, 0, 0f, 0, 0f, 0f, 0f, 0f, false, 0f, 0, new float[] {0f, 0f, 0f, 0f, 0f, 0f}, false, false, 0, new int[] {0, 0, 0}));
root.Add(3146, new FireData(3146, "f3146", "", "", 0, false, 0, 0f, 0, 0f, 0f, 0f, 0f, false, 0f, 0, new float[] {0f, 0f, 0f, 0f, 0f, 0f}, false, false, 0, new int[] {0, 0, 0}));
root.Add(3147, new FireData(3147, "f3147", "", "", 0, false, 0, 0f, 0, 0f, 0f, 0f, 0f, false, 0f, 0, new float[] {0f, 0f, 0f, 0f, 0f, 0f}, false, false, 0, new int[] {0, 0, 0}));
root.Add(3148, new FireData(3148, "f3148", "", "", 0, false, 0, 0f, 0, 0f, 0f, 0f, 0f, false, 0f, 0, new float[] {0f, 0f, 0f, 0f, 0f, 0f}, false, false, 0, new int[] {0, 0, 0}));
root.Add(3149, new FireData(3149, "f3149", "", "", 0, false, 0, 0f, 0, 0f, 0f, 0f, 0f, false, 0f, 0, new float[] {0f, 0f, 0f, 0f, 0f, 0f}, false, false, 0, new int[] {0, 0, 0}));
root.Add(3150, new FireData(3150, "f3150", "", "", 4200, true, 0, 0f, 2, 30f, -1f, 0.8f, 1.36f, false, 0.3f, 4, new float[] {0f, 0f, 0f, 0f, 0f, 0f}, false, false, 11, new int[] {2, 12, 101}));
root.Add(3151, new FireData(3151, "f3151", "", "", 4201, true, 0, 0f, 2, 30f, 3f, 1.6f, 2.72f, false, 0.3f, 1, new float[] {1f, 3f, 0.3f, 0f, 0f, 0f}, false, false, 11, new int[] {2, 12, 101}));
root.Add(3152, new FireData(3152, "f3152", "", "", 3, true, 0, 0f, 2, 30f, -1f, -0.5f, -0.5f, false, 0.3f, 4, new float[] {0f, 0f, 0f, 0f, 0f, 0f}, false, true, 11, new int[] {2, 12, 101}));
root.Add(3153, new FireData(3153, "f3153", "", "", 3, true, 0, 0f, 2, 30f, -1f, 2f, 3.4f, false, 0.3f, 4, new float[] {0f, 0f, 0f, 0f, 0f, 0f}, false, false, 11, new int[] {2, 12, 101}));
root.Add(3154, new FireData(3154, "f3154", "", "", 3, true, 0, 0f, 2, 30f, -1f, 2f, 3.4f, false, 0.3f, 4, new float[] {0f, 0f, 0f, 0f, 0f, 0f}, false, false, 11, new int[] {2, 12, 101}));
root.Add(3155, new FireData(3155, "f3155", "", "", 3, true, 0, 0f, 2, 30f, -1f, -0.5f, -0.5f, false, 0.3f, 4, new float[] {0f, 0f, 0f, 0f, 0f, 0f}, false, true, 11, new int[] {2, 12, 101}));
root.Add(3156, new FireData(3156, "f3156", "", "", 4206, true, 0, 0f, 2, 30f, 2f, 1.6f, 2.72f, false, 0.3f, 1, new float[] {1f, 3f, 0.3f, 0f, 0f, 0f}, false, false, 11, new int[] {2, 12, 101}));
root.Add(3157, new FireData(3157, "f3157", "", "", 3, true, 0, 0f, 2, 30f, -1f, 0f, 0f, false, 0.3f, 4, new float[] {0f, 0f, 0f, 0f, 0f, 0f}, false, false, 11, new int[] {0, 0, 0}));
root.Add(3158, new FireData(3158, "f3158", "", "", 3, true, 0, 0f, 2, 30f, -1f, 2f, 3.4f, false, 0.3f, 4, new float[] {0f, 0f, 0f, 0f, 0f, 0f}, false, false, 11, new int[] {2, 12, 101}));
root.Add(3159, new FireData(3159, "f3159", "", "", 4209, true, 0, 0f, 2, 30f, 0.4f, 1.6f, 2.72f, false, 2f, 4, new float[] {0f, 0f, 0f, 0f, 0f, 0f}, false, false, 11, new int[] {2, 12, 101}));
root.Add(3160, new FireData(3160, "f3160", "", "", 3, true, 0, 0f, 2, 30f, -1f, 1.6f, 2.72f, false, 0.3f, 4, new float[] {0f, 0f, 0f, 0f, 0f, 0f}, false, false, 11, new int[] {2, 12, 101}));
root.Add(3161, new FireData(3161, "f3161", "", "", 4211, true, 0, 0f, 2, 30f, 0.4f, 1.6f, 2.72f, false, 0.3f, 4, new float[] {0f, 0f, 0f, 0f, 0f, 0f}, false, false, 11, new int[] {2, 12, 101}));
root.Add(3162, new FireData(3162, "f3162", "", "", 6, true, 0, 0f, 2, 30f, -1f, 1.6f, 2.72f, false, 0.3f, 4, new float[] {0f, 0f, 0f, 0f, 0f, 0f}, false, false, 11, new int[] {2, 12, 101}));
root.Add(3163, new FireData(3163, "f3163", "", "", 3, true, 0, 0f, 2, 30f, -1f, 1.6f, 2.72f, false, 0.3f, 4, new float[] {0f, 0f, 0f, 0f, 0f, 0f}, false, false, 11, new int[] {2, 12, 101}));
root.Add(3164, new FireData(3164, "f3164", "", "", 3, true, 0, 0f, 2, 30f, -1f, -1f, -1f, false, 0.3f, 1, new float[] {1f, 10f, 0.3f, 0f, 0f, 0f}, false, true, 11, new int[] {4, 0, 0}));
root.Add(3165, new FireData(3165, "f3165", "", "", 3, true, 0, 0f, 2, 30f, 1f, 0f, 0f, false, 0.3f, 1, new float[] {1f, 10f, 0.3f, 0f, 0f, 0f}, false, true, 11, new int[] {0, 0, 0}));
root.Add(3166, new FireData(3166, "f3166", "", "", 3, true, 0, 0f, 2, 30f, 1f, 0f, 0f, false, 0.3f, 1, new float[] {1f, 10f, 0.3f, 0f, 0f, 0f}, false, true, 11, new int[] {0, 0, 0}));
root.Add(3167, new FireData(3167, "f3167", "", "", 3, true, 0, 0f, 2, 30f, 1f, 0f, 0f, false, 0.3f, 1, new float[] {1f, 10f, 0.3f, 0f, 0f, 0f}, false, true, 11, new int[] {0, 0, 0}));
root.Add(3168, new FireData(3168, "f3168", "", "", 3, true, 0, 0f, 2, 30f, 1f, 0f, 0f, false, 0.3f, 1, new float[] {1f, 10f, 0.3f, 0f, 0f, 0f}, false, true, 11, new int[] {0, 0, 0}));
root.Add(3169, new FireData(3169, "f3169", "", "", 4219, true, 0, 0f, 2, 30f, -1f, 0.4f, 0.68f, false, 0.3f, 4, new float[] {0f, 1f, 0f, 0f, 0f, 0f}, false, false, 11, new int[] {2, 0, 0}));
root.Add(3170, new FireData(3170, "f3170", "", "", 4220, true, 0, 0f, 2, 30f, -1f, 1.6f, 2.72f, false, 0.3f, 4, new float[] {0f, 1f, 0f, 0f, 0f, 0f}, false, false, 11, new int[] {2, 0, 0}));
root.Add(3171, new FireData(3171, "f3171", "", "", 4221, true, 0, 0f, 2, 30f, 5f, 1.6f, 2.72f, false, 0.3f, 18, new float[] {1f, 0f, 0f, 0f, 0f, 0f}, false, false, 11, new int[] {2, 0, 0}));
root.Add(3172, new FireData(3172, "f3172", "", "", 3, true, 0, 0f, 2, 30f, -1f, 1.6f, 2.72f, false, 0.3f, 0, new float[] {0f, 0f, 0f, 0f, 0f, 0f}, false, false, 11, new int[] {2, 0, 0}));
root.Add(3173, new FireData(3173, "f3173", "", "", 3, true, 0, 0f, 2, 30f, -1f, 1.6f, 2.72f, false, 0.3f, 0, new float[] {0f, 0f, 0f, 0f, 0f, 0f}, false, false, 11, new int[] {2, 0, 0}));
root.Add(3174, new FireData(3174, "f3174", "", "", 3, true, 0, 0f, 2, 30f, -1f, 1.6f, 2.72f, false, 0.3f, 0, new float[] {0f, 0f, 0f, 0f, 0f, 0f}, false, true, 11, new int[] {2, 0, 0}));
root.Add(3175, new FireData(3175, "f3175", "", "", 3, true, 0, 0f, 2, 30f, -1f, 1.6f, 2.72f, false, 0.3f, 0, new float[] {0f, 0f, 0f, 0f, 0f, 0f}, false, true, 11, new int[] {2, 0, 0}));
root.Add(3176, new FireData(3176, "f3176", "", "", 3, true, 0, 0f, 2, 30f, -1f, 1.6f, 2.72f, false, 0.3f, 0, new float[] {0f, 0f, 0f, 0f, 0f, 0f}, false, true, 11, new int[] {2, 0, 0}));
root.Add(3177, new FireData(3177, "f3177", "", "", 4227, true, 0, 0f, 2, 30f, -1f, 0.8f, 1.36f, false, 0.3f, 1, new float[] {2f, 3f, 0.3f, 0.3f, 0f, 0f}, false, false, 11, new int[] {2, 0, 0}));
root.Add(3178, new FireData(3178, "f3178", "", "", 4228, true, 0, 0f, 2, 30f, -1f, 0.8f, 1.36f, false, 0.3f, 1, new float[] {1f, 3f, 0.3f, 0f, 0f, 0f}, false, false, 11, new int[] {2, 0, 0}));
root.Add(3179, new FireData(3179, "f3179", "", "", 3, true, 0, 0f, 2, 30f, -1f, 0.8f, 1.36f, false, 0.3f, 0, new float[] {0f, 0f, 0f, 0f, 0f, 0f}, false, false, 11, new int[] {2, 0, 0}));
root.Add(3180, new FireData(3180, "f3180", "", "", 4230, true, 0, 0f, 2, 30f, -1f, 0.55f, 0.935f, false, 0.3f, 1, new float[] {3f, 3f, 0.3f, 0.3f, 0f, 0f}, false, false, 11, new int[] {2, 0, 0}));
root.Add(3181, new FireData(3181, "f3181", "", "", 3, true, 0, 0f, 2, 30f, -1f, 0.8f, 1.36f, false, 0.3f, 0, new float[] {0f, 0f, 0f, 0f, 0f, 0f}, false, false, 11, new int[] {2, 0, 0}));
root.Add(3182, new FireData(3182, "f3182", "", "", 3, true, 0, 0f, 2, 30f, -1f, 0.8f, 1.36f, false, 0.3f, 0, new float[] {0f, 0f, 0f, 0f, 0f, 0f}, false, false, 11, new int[] {2, 0, 0}));
root.Add(3183, new FireData(3183, "f3183", "", "", 3, true, 0, 0f, 2, 30f, -1f, 1f, 1.7f, false, 0.3f, 0, new float[] {0f, 0f, 0f, 0f, 0f, 0f}, false, false, 11, new int[] {2, 0, 0}));
root.Add(3184, new FireData(3184, "f3184", "", "", 4234, true, 0, 0f, 2, 30f, -1f, 2f, 3.4f, false, 0.3f, 1, new float[] {1f, 8f, 0.3f, 0f, 0f, 0f}, false, false, 11, new int[] {2, 0, 0}));
root.Add(3185, new FireData(3185, "f3185", "", "", 4235, true, 0, 0f, 2, 30f, -1f, 0.8f, 1.36f, false, 0.3f, 18, new float[] {1f, 0f, 0f, 0f, 0f, 0f}, false, false, 11, new int[] {2, 0, 0}));
root.Add(3186, new FireData(3186, "f3186", "", "", 3, true, 0, 0f, 2, 30f, -1f, 0.8f, 1.36f, false, 0.3f, 0, new float[] {0f, 0f, 0f, 0f, 0f, 0f}, false, false, 11, new int[] {2, 0, 0}));
root.Add(3187, new FireData(3187, "f3187", "", "", 4237, true, 0, 0f, 2, 30f, -1f, 2f, 3.4f, false, 0.3f, 1, new float[] {1f, 8f, 0.3f, 0f, 0f, 0f}, false, true, 11, new int[] {2, 0, 0}));
root.Add(3188, new FireData(3188, "f3188", "", "", 3, true, 0, 0f, 2, 30f, -1f, 0.4f, 0.68f, false, 0.3f, 0, new float[] {0f, 0f, 0f, 0f, 0f, 0f}, false, true, 11, new int[] {2, 0, 0}));
root.Add(3189, new FireData(3189, "f3189", "", "", 3, true, 0, 0f, 2, 30f, -1f, 0f, 0f, false, 0.3f, 0, new float[] {0f, 0f, 0f, 0f, 0f, 0f}, false, true, 11, new int[] {2, 0, 0}));
root.Add(3190, new FireData(3190, "f3190", "", "", 3, true, 0, 0f, 2, 30f, -1f, 0f, 0f, false, 0.3f, 0, new float[] {0f, 0f, 0f, 0f, 0f, 0f}, false, true, 11, new int[] {2, 0, 0}));
root.Add(3191, new FireData(3191, "f3191", "", "", 3, true, 0, 0f, 2, 0f, -1f, 0f, 0f, true, 0.3f, 4, new float[] {0f, 1f, 0f, 0f, 0f, 0f}, false, true, 3, new int[] {0, 0, 0}));
root.Add(3192, new FireData(3192, "f3192", "荆棘护甲ILv.2", "荆棘护甲ILv.3", 4242, true, 0, 0f, 2, 30f, 5f, 0.3f, 0.51f, true, 0.3f, 4, new float[] {0f, 1f, 0f, 0f, 0f, 0f}, false, false, 3, new int[] {0, 0, 0}));
root.Add(3193, new FireData(3193, "f3193", "", "", 3, true, 0, 0f, 2, 30f, -1f, 0f, 0f, true, 0.3f, 4, new float[] {0f, 1f, 0f, 0f, 0f, 0f}, false, true, 3, new int[] {0, 0, 0}));
root.Add(3194, new FireData(3194, "f3194", "", "", 1, true, 0, 0f, 2, 30f, -1f, 0.1f, 0.17f, true, 0.3f, 4, new float[] {0f, 1f, 0f, 0f, 0f, 0f}, false, false, 3, new int[] {0, 0, 0}));
root.Add(3195, new FireData(3195, "f3195", "", "", 1, true, 0, 0f, 2, 30f, -1f, 0f, 0f, true, 0.3f, 4, new float[] {0f, 1f, 0f, 0f, 0f, 0f}, false, false, 3, new int[] {0, 0, 0}));
root.Add(3196, new FireData(3196, "f3196", "", "", 3, true, 0, 0f, 2, 30f, -1f, 3f, 5.1f, true, 0.3f, 4, new float[] {0f, 1f, 0f, 0f, 0f, 0f}, false, false, 3, new int[] {2, 0, 0}));
root.Add(3197, new FireData(3197, "f3197", "", "", 4247, true, 0, 0f, 2, -30f, -1f, 3f, 5.1f, false, 0.3f, 4, new float[] {0f, 1f, 0f, 0f, 0f, 0f}, false, false, 3, new int[] {2, 0, 0}));
root.Add(3198, new FireData(3198, "f3198", "", "", 4300, true, 0, 0f, 2, 30f, 0.5f, 3f, 5.1f, true, 0.3f, 4, new float[] {0f, 1f, 0f, 0f, 0f, 0f}, false, false, 3, new int[] {2, 0, 0}));
root.Add(3199, new FireData(3199, "f3199", "", "", 4301, true, 0, 0f, 2, 30f, 0.5f, 3f, 5.1f, true, 0.3f, 4, new float[] {0f, 1f, 0f, 0f, 0f, 0f}, false, false, 3, new int[] {2, 0, 0}));
root.Add(3200, new FireData(3200, "f3200", "", "", 4302, true, 0, 0f, 2, 30f, 0.5f, 3f, 5.1f, true, 0.3f, 4, new float[] {0f, 1f, 0f, 0f, 0f, 0f}, false, false, 3, new int[] {2, 0, 0}));
root.Add(3201, new FireData(3201, "f3201", "", "", 3, true, 0, 0f, 2, 30f, 0.5f, 3f, 5.1f, true, 0.3f, 4, new float[] {0f, 0f, 0f, 0f, 0f, 0f}, false, false, 3, new int[] {2, 0, 0}));
root.Add(3202, new FireData(3202, "f3202", "", "", 4304, true, 0, 0f, 2, 30f, 3f, 0.2f, 0.34f, true, 0.3f, 4, new float[] {0f, 1f, 0f, 0f, 0f, 0f}, false, false, 3, new int[] {2, 0, 0}));
root.Add(3203, new FireData(3203, "f3203", "", "", 4305, true, 0, 0f, 2, 30f, 0.5f, 2f, 3.4f, true, 0.3f, 4, new float[] {0f, 0f, 0f, 0f, 0f, 0f}, false, false, 3, new int[] {2, 0, 0}));
root.Add(3204, new FireData(3204, "f3204", "", "", 3, true, 0, 0f, 2, 30f, 0.5f, 2f, 3.4f, true, 0.3f, 4, new float[] {0f, 0f, 0f, 0f, 0f, 0f}, false, false, 3, new int[] {2, 0, 0}));
root.Add(3205, new FireData(3205, "f3205", "", "", 3, true, 0, 0f, 2, 30f, 1f, -1f, 0f, false, 0.3f, 1, new float[] {1f, 10f, 0.3f, 0f, 0f, 0f}, false, true, 3, new int[] {4, 0, 0}));
root.Add(3206, new FireData(3206, "f3206", "", "", 4308, true, 0, 0f, 2, 30f, -1f, 0f, 0f, false, 0.3f, 4, new float[] {0f, 1f, 0f, 0f, 0f, 0f}, false, true, 3, new int[] {0, 0, 0}));
root.Add(3207, new FireData(3207, "f3207", "", "", 2, true, 0, 0f, 2, 30f, 1f, 0f, 0f, false, 0.3f, 4, new float[] {0f, 0f, 0f, 0f, 0f, 0f}, false, true, 3, new int[] {0, 0, 0}));
root.Add(3208, new FireData(3208, "f3208", "", "", 4310, true, 0, 0f, 2, 30f, 4f, 0f, 0f, false, 0.3f, 4, new float[] {0f, 1f, 0f, 0f, 0f, 0f}, false, true, 3, new int[] {4, 0, 0}));
root.Add(3209, new FireData(3209, "f3209", "", "", 4311, true, 0, 0f, 2, 30f, 4f, -0.1f, 0f, false, 0.3f, 4, new float[] {0f, 1f, 0f, 0f, 0f, 0f}, false, true, 3, new int[] {4, 0, 0}));
root.Add(3210, new FireData(3210, "f3210", "", "", 3, true, 0, 0f, 2, 30f, 1f, 0f, 0f, false, 0.3f, 4, new float[] {0f, 1f, 0f, 0f, 0f, 0f}, false, true, 3, new int[] {0, 0, 0}));
root.Add(3211, new FireData(3211, "f3211", "", "", 3, true, 0, 0f, 2, 30f, 1f, 0f, 0f, false, 0.3f, 4, new float[] {0f, 1f, 0f, 0f, 0f, 0f}, false, true, 3, new int[] {4, 0, 0}));
root.Add(3212, new FireData(3212, "f3212", "", "", 3, true, 0, 0f, 2, 30f, 1f, 0f, 0f, false, 0.3f, 1, new float[] {1f, 10f, 0.3f, 0f, 0f, 0f}, false, true, 3, new int[] {0, 0, 0}));
root.Add(3213, new FireData(3213, "f3213", "", "", 4315, true, 0, 0f, 2, 30f, 5f, 0.35f, 0.595f, false, 0.3f, 4, new float[] {0f, 1f, 0f, 0f, 0f, 0f}, false, true, 3, new int[] {2, 0, 0}));
root.Add(3214, new FireData(3214, "f3214", "", "", 3, true, 0, 0f, 2, 30f, 1f, 0f, 0f, false, 0.3f, 1, new float[] {1f, 10f, 0.3f, 0f, 0f, 0f}, false, true, 3, new int[] {4, 0, 0}));
root.Add(3215, new FireData(3215, "f3215", "", "", 3, true, 0, 0f, 2, 30f, 1f, 0f, 0f, false, 0.3f, 1, new float[] {1f, 10f, 0.3f, 0f, 0f, 0f}, false, true, 3, new int[] {0, 0, 0}));
root.Add(3216, new FireData(3216, "f3216", "", "", 3, true, 0, 0f, 2, 30f, 1f, 0f, 0f, false, 0.3f, 1, new float[] {1f, 10f, 0.3f, 0f, 0f, 0f}, false, true, 3, new int[] {0, 0, 0}));
root.Add(3217, new FireData(3217, "f3217", "", "", 2, true, 0, 0f, 2, 30f, 1f, 0f, 0f, false, 0.3f, 4, new float[] {0f, 1f, 0f, 0f, 0f, 0f}, false, true, 3, new int[] {0, 0, 0}));
root.Add(3218, new FireData(3218, "f3218", "", "", 4320, true, 0, 0f, 2, 30f, 1f, 0f, 0f, false, 0.3f, 1, new float[] {1f, 10f, 0.3f, 0f, 0f, 0f}, false, true, 3, new int[] {2, 0, 0}));
root.Add(3219, new FireData(3219, "f3219", "", "", 4321, true, 0, 0f, 2, 30f, 5f, 3f, 5.1f, false, 0.3f, 18, new float[] {2f, 0f, 0f, 0f, 0f, 0f}, false, false, 3, new int[] {2, 0, 0}));
root.Add(3220, new FireData(3220, "f3220", "", "", 4322, true, 0, 0f, 2, 30f, 1f, 3f, 5.1f, false, 0.3f, 8, new float[] {10f, 1f, 0.3f, 0f, 0f, 0f}, false, false, 3, new int[] {2, 0, 0}));
root.Add(3221, new FireData(3221, "f3221", "", "", 4323, true, 0, 0f, 2, 30f, 5f, 3f, 5.1f, false, 0.3f, 18, new float[] {2f, 0f, 0f, 0f, 0f, 0f}, false, false, 3, new int[] {2, 0, 0}));
root.Add(3222, new FireData(3222, "f3222", "", "", 3, true, 0, 0f, 2, 30f, 1f, 3f, 5.1f, false, 0.3f, 4, new float[] {0f, 1f, 0f, 0f, 0f, 0f}, false, false, 3, new int[] {2, 0, 0}));
root.Add(3223, new FireData(3223, "f3223", "", "", 3, true, 0, 0f, 2, 30f, 1f, 3f, 5.1f, false, 0.3f, 4, new float[] {0f, 1f, 0f, 0f, 0f, 0f}, false, false, 3, new int[] {2, 0, 0}));
root.Add(3224, new FireData(3224, "f3224", "", "", 3, true, 0, 0f, 2, 30f, 1f, 3f, 5.1f, false, 0.3f, 4, new float[] {0f, 1f, 0f, 0f, 0f, 0f}, false, false, 3, new int[] {2, 0, 0}));
root.Add(3225, new FireData(3225, "f3225", "", "", 3, true, 0, 0f, 2, 30f, 1f, 3f, 5.1f, false, 0.3f, 4, new float[] {0f, 1f, 0f, 0f, 0f, 0f}, false, false, 3, new int[] {2, 0, 0}));
root.Add(3226, new FireData(3226, "f3226", "", "", 3, true, 0, 0f, 2, 30f, 1f, 3f, 5.1f, false, 0.3f, 4, new float[] {0f, 1f, 0f, 0f, 0f, 0f}, false, false, 3, new int[] {2, 17, 0}));
root.Add(3227, new FireData(3227, "f3227", "", "", 4329, true, 0, 0f, 2, 30f, 10f, 3f, 5.1f, false, 0.2f, 1, new float[] {1f, 6f, 0.1f, 0f, 0f, 0f}, false, false, 3, new int[] {2, 18, 0}));
root.Add(3228, new FireData(3228, "f3228", "", "", 4330, true, 0, 0f, 2, 30f, 1f, 0.6f, 1.02f, false, 0.3f, 1, new float[] {5f, 6f, 0.3f, 0.2f, 0f, 0f}, false, false, 3, new int[] {2, 19, 0}));
root.Add(3229, new FireData(3229, "f3229", "", "", 3, true, 0, 0f, 2, 30f, 1f, 3f, 5.1f, false, 0.3f, 4, new float[] {0f, 1f, 0f, 0f, 0f, 0f}, false, false, 3, new int[] {2, 18, 0}));
root.Add(3230, new FireData(3230, "f3230", "", "", 4332, true, 0, 0f, 2, 30f, 1f, 0.1f, 0.17f, false, 0.3f, 1, new float[] {1f, 10f, 0.3f, 0f, 0f, 0f}, false, false, 3, new int[] {2, 20, 0}));
root.Add(3231, new FireData(3231, "f3231", "", "", 4333, true, 0, 0f, 2, 0f, 1f, 3f, 5.1f, false, 0.3f, 1, new float[] {1f, 10f, 0.3f, 0f, 0f, 0f}, false, false, 3, new int[] {2, 22, 0}));
root.Add(3232, new FireData(3232, "f3232", "", "", 3, true, 0, 0f, 2, 30f, 1f, 3f, 5.1f, false, 0.3f, 1, new float[] {1f, 10f, 0.3f, 0f, 0f, 0f}, false, false, 3, new int[] {2, 19, 0}));
root.Add(3233, new FireData(3233, "f3233", "", "", 3, true, 0, 0f, 2, 30f, 1f, 3f, 5.1f, false, 0.3f, 1, new float[] {1f, 10f, 0.3f, 0f, 0f, 0f}, false, false, 3, new int[] {2, 21, 0}));
root.Add(3234, new FireData(3234, "f3234", "", "", 3, true, 0, 0f, 2, 0f, 1f, 0f, 0f, false, 0.3f, 4, new float[] {0f, 1f, 0f, 0f, 0f, 0f}, false, false, 3, new int[] {2, 0, 0}));
root.Add(3235, new FireData(3235, "f3235", "", "", 3, true, 0, 0f, 2, 0f, 1f, 0f, 0f, false, 0.3f, 4, new float[] {0f, 1f, 0f, 0f, 0f, 0f}, false, false, 3, new int[] {2, 0, 0}));
root.Add(3236, new FireData(3236, "f3236", "", "", 3, true, 0, 0f, 2, 0f, 1f, 0f, 0f, false, 0.3f, 4, new float[] {0f, 1f, 0f, 0f, 0f, 0f}, false, true, 3, new int[] {2, 0, 0}));
root.Add(3237, new FireData(3237, "f3237", "", "", 3, true, 0, 0f, 2, 0f, 1f, 0f, 0f, false, 0.3f, 4, new float[] {0f, 1f, 0f, 0f, 0f, 0f}, false, true, 3, new int[] {2, 0, 0}));
root.Add(3238, new FireData(3238, "f3238", "", "", 3, true, 0, 0f, 2, 0f, 1f, 0f, 0f, false, 0.3f, 4, new float[] {0f, 1f, 0f, 0f, 0f, 0f}, false, true, 3, new int[] {2, 0, 0}));
root.Add(3239, new FireData(3239, "f3239", "", "", 3, true, 0, 0f, 2, 0f, 1f, 0f, 0f, false, 0.3f, 4, new float[] {0f, 1f, 0f, 0f, 0f, 0f}, false, true, 3, new int[] {2, 0, 0}));
root.Add(3240, new FireData(3240, "f3240", "", "", 3, true, 0, 0f, 2, 0f, 1f, 0f, 0f, false, 0.3f, 4, new float[] {0f, 1f, 0f, 0f, 0f, 0f}, false, true, 3, new int[] {2, 0, 0}));
root.Add(3241, new FireData(3241, "f3241", "", "", 4343, true, 0, 0f, 2, 50f, 1f, 3f, 5.1f, false, 0f, 4, new float[] {0f, 1f, 0f, 0f, 0f, 0f}, false, false, 0, new int[] {2, 0, 0}));
root.Add(3242, new FireData(3242, "f3242", "", "", 4501, true, 0, 0f, 2, 0f, 1f, 0f, 0f, true, 0f, 4, new float[] {0f, 0f, 0f, 0f, 0f, 0f}, false, false, 1, new int[] {0, 2, 101}));
root.Add(3243, new FireData(3243, "f3243", "", "", 3, true, 0, 0f, 2, 0f, 1f, 0f, 0f, true, 0f, 4, new float[] {0f, 1f, 0f, 0f, 0f, 0f}, false, false, 3, new int[] {0, 0, 0}));
root.Add(3244, new FireData(3244, "f3244", "", "", 4345, true, 0, 0f, 2, 0f, -1f, 3f, 5.1f, false, 0f, 4, new float[] {0f, 1f, 0f, 0f, 0f, 0f}, false, false, 0, new int[] {2, 15, 101}));
root.Add(3245, new FireData(3245, "f3245", "", "", 4344, true, 0, 0f, 2, 0f, 1f, 0f, 0f, false, 0f, 4, new float[] {0f, 1f, 0f, 0f, 0f, 0f}, false, false, 0, new int[] {2, 0, 0}));
root.Add(3246, new FireData(3246, "f3246", "", "", 0, false, 0, 0f, 0, 0f, 0f, 0f, 0f, false, 0f, 0, new float[] {0f, 0f, 0f, 0f, 0f, 0f}, false, false, 0, new int[] {0, 0, 0}));
root.Add(3247, new FireData(3247, "f3247", "", "", 0, false, 0, 0f, 0, 0f, 0f, 0f, 0f, false, 0f, 0, new float[] {0f, 0f, 0f, 0f, 0f, 0f}, false, false, 0, new int[] {0, 0, 0}));
root.Add(3248, new FireData(3248, "f3248", "", "", 0, false, 0, 0f, 0, 0f, 0f, 0f, 0f, false, 0f, 0, new float[] {0f, 0f, 0f, 0f, 0f, 0f}, false, false, 0, new int[] {0, 0, 0}));
root.Add(3249, new FireData(3249, "f3249", "", "", 0, false, 0, 0f, 0, 0f, 0f, 0f, 0f, false, 0f, 0, new float[] {0f, 0f, 0f, 0f, 0f, 0f}, false, false, 0, new int[] {0, 0, 0}));
root.Add(3250, new FireData(3250, "f3250", "", "", 0, false, 0, 0f, 0, 0f, 0f, 0f, 0f, false, 0f, 0, new float[] {0f, 0f, 0f, 0f, 0f, 0f}, false, false, 0, new int[] {0, 0, 0}));
root.Add(3251, new FireData(3251, "f3251", "", "", 0, false, 0, 0f, 0, 0f, 0f, 0f, 0f, false, 0f, 0, new float[] {0f, 0f, 0f, 0f, 0f, 0f}, false, false, 0, new int[] {0, 0, 0}));
root.Add(3252, new FireData(3252, "f3252", "", "", 0, false, 0, 0f, 0, 0f, 0f, 0f, 0f, false, 0f, 0, new float[] {0f, 0f, 0f, 0f, 0f, 0f}, false, false, 0, new int[] {0, 0, 0}));
root.Add(3253, new FireData(3253, "f3253", "", "", 0, false, 0, 0f, 0, 0f, 0f, 0f, 0f, false, 0f, 0, new float[] {0f, 0f, 0f, 0f, 0f, 0f}, false, false, 0, new int[] {0, 0, 0}));
root.Add(3254, new FireData(3254, "f3254", "", "", 0, false, 0, 0f, 0, 0f, 0f, 0f, 0f, false, 0f, 0, new float[] {0f, 0f, 0f, 0f, 0f, 0f}, false, false, 0, new int[] {0, 0, 0}));
root.Add(3255, new FireData(3255, "f3255", "", "", 0, false, 0, 0f, 0, 0f, 0f, 0f, 0f, false, 0f, 0, new float[] {0f, 0f, 0f, 0f, 0f, 0f}, false, false, 0, new int[] {0, 0, 0}));
root.Add(3256, new FireData(3256, "f3256", "", "", 0, false, 0, 0f, 0, 0f, 0f, 0f, 0f, false, 0f, 0, new float[] {0f, 0f, 0f, 0f, 0f, 0f}, false, false, 0, new int[] {0, 0, 0}));
root.Add(3257, new FireData(3257, "f3257", "", "", 0, false, 0, 0f, 0, 0f, 0f, 0f, 0f, false, 0f, 0, new float[] {0f, 0f, 0f, 0f, 0f, 0f}, false, false, 0, new int[] {0, 0, 0}));
root.Add(3258, new FireData(3258, "f3258", "", "", 0, false, 0, 0f, 0, 0f, 0f, 0f, 0f, false, 0f, 0, new float[] {0f, 0f, 0f, 0f, 0f, 0f}, false, false, 0, new int[] {0, 0, 0}));
root.Add(3259, new FireData(3259, "f3259", "", "", 0, false, 0, 0f, 0, 0f, 0f, 0f, 0f, false, 0f, 0, new float[] {0f, 0f, 0f, 0f, 0f, 0f}, false, false, 0, new int[] {0, 0, 0}));
root.Add(3260, new FireData(3260, "f3260", "", "", 0, false, 0, 0f, 0, 0f, 0f, 0f, 0f, false, 0f, 0, new float[] {0f, 0f, 0f, 0f, 0f, 0f}, false, false, 0, new int[] {0, 0, 0}));
root.Add(3261, new FireData(3261, "f3261", "", "", 0, false, 0, 0f, 0, 0f, 0f, 0f, 0f, false, 0f, 0, new float[] {0f, 0f, 0f, 0f, 0f, 0f}, false, false, 0, new int[] {0, 0, 0}));
root.Add(3262, new FireData(3262, "f3262", "", "", 0, false, 0, 0f, 0, 0f, 0f, 0f, 0f, false, 0f, 0, new float[] {0f, 0f, 0f, 0f, 0f, 0f}, false, false, 0, new int[] {0, 0, 0}));
root.Add(3263, new FireData(3263, "f3263", "", "", 0, false, 0, 0f, 0, 0f, 0f, 0f, 0f, false, 0f, 0, new float[] {0f, 0f, 0f, 0f, 0f, 0f}, false, false, 0, new int[] {0, 0, 0}));
root.Add(3264, new FireData(3264, "f3264", "", "", 0, false, 0, 0f, 0, 0f, 0f, 0f, 0f, false, 0f, 0, new float[] {0f, 0f, 0f, 0f, 0f, 0f}, false, false, 0, new int[] {0, 0, 0}));
root.Add(3265, new FireData(3265, "f3265", "", "", 0, false, 0, 0f, 0, 0f, 0f, 0f, 0f, false, 0f, 0, new float[] {0f, 0f, 0f, 0f, 0f, 0f}, false, false, 0, new int[] {0, 0, 0}));
root.Add(3266, new FireData(3266, "f3266", "", "", 0, false, 0, 0f, 0, 0f, 0f, 0f, 0f, false, 0f, 0, new float[] {0f, 0f, 0f, 0f, 0f, 0f}, false, false, 0, new int[] {0, 0, 0}));
root.Add(3267, new FireData(3267, "f3267", "", "", 0, false, 0, 0f, 0, 0f, 0f, 0f, 0f, false, 0f, 0, new float[] {0f, 0f, 0f, 0f, 0f, 0f}, false, false, 0, new int[] {0, 0, 0}));
root.Add(3268, new FireData(3268, "f3268", "", "", 0, false, 0, 0f, 0, 0f, 0f, 0f, 0f, false, 0f, 0, new float[] {0f, 0f, 0f, 0f, 0f, 0f}, false, false, 0, new int[] {0, 0, 0}));
root.Add(3269, new FireData(3269, "f3269", "", "", 0, false, 0, 0f, 0, 0f, 0f, 0f, 0f, false, 0f, 0, new float[] {0f, 0f, 0f, 0f, 0f, 0f}, false, false, 0, new int[] {0, 0, 0}));
root.Add(3270, new FireData(3270, "f3270", "", "", 0, false, 0, 0f, 0, 0f, 0f, 0f, 0f, false, 0f, 0, new float[] {0f, 0f, 0f, 0f, 0f, 0f}, false, false, 0, new int[] {0, 0, 0}));
root.Add(3271, new FireData(3271, "f3271", "", "", 0, false, 0, 0f, 0, 0f, 0f, 0f, 0f, false, 0f, 0, new float[] {0f, 0f, 0f, 0f, 0f, 0f}, false, false, 0, new int[] {0, 0, 0}));
root.Add(3272, new FireData(3272, "f3272", "", "", 0, false, 0, 0f, 0, 0f, 0f, 0f, 0f, false, 0f, 0, new float[] {0f, 0f, 0f, 0f, 0f, 0f}, false, false, 0, new int[] {0, 0, 0}));
root.Add(3273, new FireData(3273, "f3273", "", "", 0, false, 0, 0f, 0, 0f, 0f, 0f, 0f, false, 0f, 0, new float[] {0f, 0f, 0f, 0f, 0f, 0f}, false, false, 0, new int[] {0, 0, 0}));
root.Add(3274, new FireData(3274, "f3274", "", "", 0, false, 0, 0f, 0, 0f, 0f, 0f, 0f, false, 0f, 0, new float[] {0f, 0f, 0f, 0f, 0f, 0f}, false, false, 0, new int[] {0, 0, 0}));
root.Add(3275, new FireData(3275, "f3275", "", "", 0, false, 0, 0f, 0, 0f, 0f, 0f, 0f, false, 0f, 0, new float[] {0f, 0f, 0f, 0f, 0f, 0f}, false, false, 0, new int[] {0, 0, 0}));
root.Add(3276, new FireData(3276, "f3276", "", "", 0, false, 0, 0f, 0, 0f, 0f, 0f, 0f, false, 0f, 0, new float[] {0f, 0f, 0f, 0f, 0f, 0f}, false, false, 0, new int[] {0, 0, 0}));
root.Add(3277, new FireData(3277, "f3277", "", "", 0, false, 0, 0f, 0, 0f, 0f, 0f, 0f, false, 0f, 0, new float[] {0f, 0f, 0f, 0f, 0f, 0f}, false, false, 0, new int[] {0, 0, 0}));
root.Add(3278, new FireData(3278, "f3278", "", "", 0, false, 0, 0f, 0, 0f, 0f, 0f, 0f, false, 0f, 0, new float[] {0f, 0f, 0f, 0f, 0f, 0f}, false, false, 0, new int[] {0, 0, 0}));
root.Add(3279, new FireData(3279, "f3279", "", "", 0, false, 0, 0f, 0, 0f, 0f, 0f, 0f, false, 0f, 0, new float[] {0f, 0f, 0f, 0f, 0f, 0f}, false, false, 0, new int[] {0, 0, 0}));
root.Add(3280, new FireData(3280, "f3280", "", "", 0, false, 0, 0f, 0, 0f, 0f, 0f, 0f, false, 0f, 0, new float[] {0f, 0f, 0f, 0f, 0f, 0f}, false, false, 0, new int[] {0, 0, 0}));
root.Add(3281, new FireData(3281, "f3281", "", "", 0, false, 0, 0f, 0, 0f, 0f, 0f, 0f, false, 0f, 0, new float[] {0f, 0f, 0f, 0f, 0f, 0f}, false, false, 0, new int[] {0, 0, 0}));
root.Add(3282, new FireData(3282, "f3282", "", "", 0, false, 0, 0f, 0, 0f, 0f, 0f, 0f, false, 0f, 0, new float[] {0f, 0f, 0f, 0f, 0f, 0f}, false, false, 0, new int[] {0, 0, 0}));
root.Add(3283, new FireData(3283, "f3283", "", "", 0, false, 0, 0f, 0, 0f, 0f, 0f, 0f, false, 0f, 0, new float[] {0f, 0f, 0f, 0f, 0f, 0f}, false, false, 0, new int[] {0, 0, 0}));
root.Add(3284, new FireData(3284, "f3284", "", "", 0, false, 0, 0f, 0, 0f, 0f, 0f, 0f, false, 0f, 0, new float[] {0f, 0f, 0f, 0f, 0f, 0f}, false, false, 0, new int[] {0, 0, 0}));
root.Add(3285, new FireData(3285, "f3285", "", "", 0, false, 0, 0f, 0, 0f, 0f, 0f, 0f, false, 0f, 0, new float[] {0f, 0f, 0f, 0f, 0f, 0f}, false, false, 0, new int[] {0, 0, 0}));
root.Add(3286, new FireData(3286, "f3286", "", "", 0, false, 0, 0f, 0, 0f, 0f, 0f, 0f, false, 0f, 0, new float[] {0f, 0f, 0f, 0f, 0f, 0f}, false, false, 0, new int[] {0, 0, 0}));
root.Add(3287, new FireData(3287, "f3287", "", "", 0, false, 0, 0f, 0, 0f, 0f, 0f, 0f, false, 0f, 0, new float[] {0f, 0f, 0f, 0f, 0f, 0f}, false, false, 0, new int[] {0, 0, 0}));
root.Add(3288, new FireData(3288, "f3288", "", "", 0, false, 0, 0f, 0, 0f, 0f, 0f, 0f, false, 0f, 0, new float[] {0f, 0f, 0f, 0f, 0f, 0f}, false, false, 0, new int[] {0, 0, 0}));
root.Add(3289, new FireData(3289, "f3289", "", "", 0, false, 0, 0f, 0, 0f, 0f, 0f, 0f, false, 0f, 0, new float[] {0f, 0f, 0f, 0f, 0f, 0f}, false, false, 0, new int[] {0, 0, 0}));
root.Add(3290, new FireData(3290, "f3290", "", "", 0, false, 0, 0f, 0, 0f, 0f, 0f, 0f, false, 0f, 0, new float[] {0f, 0f, 0f, 0f, 0f, 0f}, false, false, 0, new int[] {0, 0, 0}));
root.Add(3291, new FireData(3291, "f3291", "", "", 0, false, 0, 0f, 0, 0f, 0f, 0f, 0f, false, 0f, 0, new float[] {0f, 0f, 0f, 0f, 0f, 0f}, false, false, 0, new int[] {0, 0, 0}));
root.Add(3292, new FireData(3292, "f3292", "", "", 0, false, 0, 0f, 0, 0f, 0f, 0f, 0f, false, 0f, 0, new float[] {0f, 0f, 0f, 0f, 0f, 0f}, false, false, 0, new int[] {0, 0, 0}));
root.Add(3293, new FireData(3293, "f3293", "", "", 0, false, 0, 0f, 0, 0f, 0f, 0f, 0f, false, 0f, 0, new float[] {0f, 0f, 0f, 0f, 0f, 0f}, false, false, 0, new int[] {0, 0, 0}));
root.Add(3294, new FireData(3294, "f3294", "", "", 0, false, 0, 0f, 0, 0f, 0f, 0f, 0f, false, 0f, 0, new float[] {0f, 0f, 0f, 0f, 0f, 0f}, false, false, 0, new int[] {0, 0, 0}));
root.Add(3295, new FireData(3295, "f3295", "", "", 0, false, 0, 0f, 0, 0f, 0f, 0f, 0f, false, 0f, 0, new float[] {0f, 0f, 0f, 0f, 0f, 0f}, false, false, 0, new int[] {0, 0, 0}));
root.Add(3296, new FireData(3296, "f3296", "", "", 0, false, 0, 0f, 0, 0f, 0f, 0f, 0f, false, 0f, 0, new float[] {0f, 0f, 0f, 0f, 0f, 0f}, false, false, 0, new int[] {0, 0, 0}));
root.Add(3297, new FireData(3297, "f3297", "", "", 0, false, 0, 0f, 0, 0f, 0f, 0f, 0f, false, 0f, 0, new float[] {0f, 0f, 0f, 0f, 0f, 0f}, false, false, 0, new int[] {0, 0, 0}));
root.Add(3298, new FireData(3298, "f3298", "", "", 0, false, 0, 0f, 0, 0f, 0f, 0f, 0f, false, 0f, 0, new float[] {0f, 0f, 0f, 0f, 0f, 0f}, false, false, 0, new int[] {0, 0, 0}));
root.Add(3299, new FireData(3299, "f3299", "", "", 0, false, 0, 0f, 0, 0f, 0f, 0f, 0f, false, 0f, 0, new float[] {0f, 0f, 0f, 0f, 0f, 0f}, false, false, 0, new int[] {0, 0, 0}));
root.Add(3300, new FireData(3300, "f3300", "", "", 0, false, 0, 0f, 0, 0f, 0f, 0f, 0f, false, 0f, 0, new float[] {0f, 0f, 0f, 0f, 0f, 0f}, false, false, 0, new int[] {0, 0, 0}));
root.Add(3301, new FireData(3301, "f3301", "", "", 0, false, 0, 0f, 0, 0f, 0f, 0f, 0f, false, 0f, 0, new float[] {0f, 0f, 0f, 0f, 0f, 0f}, false, false, 0, new int[] {0, 0, 0}));
root.Add(3302, new FireData(3302, "f3302", "", "", 0, false, 0, 0f, 0, 0f, 0f, 0f, 0f, false, 0f, 0, new float[] {0f, 0f, 0f, 0f, 0f, 0f}, false, false, 0, new int[] {0, 0, 0}));
root.Add(3500, new FireData(3500, "f3500", "", "", 7, true, 0, 0f, 0, 0f, 0.3f, 1f, 1.7f, false, 0f, 4, new float[] {0f, 0f, 0f, 0f, 0f, 0f}, false, false, 1, new int[] {103, 25, 102}));
root.Add(3501, new FireData(3501, "f3501", "", "", 7, true, 0, 0f, 0, 0f, 0.3f, 0.1f, 0.17f, false, 0f, 4, new float[] {0f, 0f, 0f, 0f, 0f, 0f}, false, true, 1, new int[] {103, 25, 102}));
root.Add(3502, new FireData(3502, "f3502", "", "", 7, true, 0, 0f, 0, 0f, 0.3f, 0.1f, 0.17f, false, 0f, 4, new float[] {0f, 0f, 0f, 0f, 0f, 0f}, false, true, 1, new int[] {103, 25, 102}));
root.Add(3503, new FireData(3503, "f3503", "", "", 7, true, 0, 0f, 0, 0f, 0.3f, 1f, 1.7f, false, 0f, 4, new float[] {0f, 1f, 0f, 0f, 0f, 0f}, false, false, 1, new int[] {103, 25, 102}));
root.Add(3504, new FireData(3504, "f3504", "", "", 7, true, 0, 0f, 0, 0f, 0.3f, 1f, 1.7f, false, 0f, 4, new float[] {0f, 1f, 0f, 0f, 0f, 0f}, false, false, 1, new int[] {103, 25, 102}));
root.Add(3505, new FireData(3505, "f3505", "", "", 7, true, 0, 0f, 0, 0f, 0.3f, 1f, 1.7f, false, 0f, 4, new float[] {0f, 0f, 0f, 0f, 0f, 0f}, false, true, 1, new int[] {103, 25, 102}));
root.Add(3506, new FireData(3506, "f3506", "", "", 7, true, 0, 0f, 0, 0f, 0.3f, 1f, 1.7f, false, 0.3f, 4, new float[] {0f, 0f, 0f, 0f, 0f, 0f}, false, true, 1, new int[] {103, 25, 102}));
root.Add(3507, new FireData(3507, "f3507", "", "", 8, true, 0, 0f, 0, 0f, 0.3f, 1f, 1.7f, false, 0.3f, 4, new float[] {0f, 0f, 0f, 0f, 0f, 0f}, false, true, 1, new int[] {103, 25, 102}));
root.Add(3508, new FireData(3508, "f3508", "", "", 7, true, 0, 0f, 0, 0f, 0.3f, 1f, 1.7f, false, 0.3f, 4, new float[] {0f, 0f, 0f, 0f, 0f, 0f}, false, true, 1, new int[] {103, 25, 102}));
root.Add(3509, new FireData(3509, "f3509", "", "", 8, true, 0, 0f, 0, 0f, 0.3f, 1f, 1.7f, false, 0.3f, 4, new float[] {0f, 0f, 0f, 0f, 0f, 0f}, false, true, 1, new int[] {103, 25, 102}));
root.Add(3510, new FireData(3510, "f3510", "", "", 4906, true, 20, 1f, 2, 5f, 10f, 2f, 3.4f, false, 0.4f, 1, new float[] {1f, 5f, 0.1f, 0f, 0f, 0f}, false, false, 1, new int[] {103, 25, 102}));
root.Add(3511, new FireData(3511, "f3511", "", "", 4907, true, 20, 1f, 2, 5f, 10f, 2f, 3.4f, false, 0.4f, 1, new float[] {1f, 5f, 0.1f, 0f, 0f, 0f}, false, false, 1, new int[] {103, 25, 102}));
root.Add(3512, new FireData(3512, "f3512", "", "", 4908, true, 20, 1f, 2, 5f, 10f, 2f, 3.4f, false, 0.4f, 1, new float[] {1f, 5f, 0.1f, 0f, 0f, 0f}, false, false, 1, new int[] {103, 25, 102}));
root.Add(3513, new FireData(3513, "f3513", "", "", 4909, true, 20, 1f, 2, 5f, 10f, 2f, 3.4f, false, 0.4f, 1, new float[] {1f, 5f, 0.1f, 0f, 0f, 0f}, false, false, 1, new int[] {103, 25, 102}));
root.Add(3514, new FireData(3514, "f3514", "", "", 4910, true, 20, 1f, 2, 5f, 10f, 2f, 3.4f, false, 0.4f, 1, new float[] {1f, 5f, 0.1f, 0f, 0f, 0f}, false, false, 1, new int[] {103, 25, 102}));
root.Add(3515, new FireData(3515, "f3515", "", "", 7, true, 0, 0f, 0, 0f, 0.3f, 2f, 3.4f, false, 0.3f, 4, new float[] {0f, 0f, 0f, 0f, 0f, 0f}, false, true, 1, new int[] {103, 25, 102}));
root.Add(3516, new FireData(3516, "f3516", "", "", 7, true, 0, 0f, 0, 0f, 0.3f, 0.9f, 1.7f, false, 0.3f, 4, new float[] {0f, 0f, 0f, 0f, 0f, 0f}, false, true, 1, new int[] {103, 25, 102}));
root.Add(3517, new FireData(3517, "f3517", "", "", 7, true, 0, 0f, 0, 0f, 0.3f, 0.8f, 1.36f, false, 0.3f, 4, new float[] {0f, 0f, 0f, 0f, 0f, 0f}, false, true, 1, new int[] {103, 25, 102}));
root.Add(3518, new FireData(3518, "f3518", "", "", 7, true, 0, 0f, 0, 0f, 0.3f, 0.7f, 1.7f, false, 0.3f, 4, new float[] {0f, 0f, 0f, 0f, 0f, 0f}, false, true, 1, new int[] {103, 25, 102}));
root.Add(3519, new FireData(3519, "f3519", "", "", 7, true, 0, 0f, 0, 0f, 0.3f, 0.6f, 1.02f, false, 0.3f, 4, new float[] {0f, 0f, 0f, 0f, 0f, 0f}, false, true, 1, new int[] {103, 25, 102}));
root.Add(3520, new FireData(3520, "f3520", "", "", 7, true, 0, 0f, 0, 0f, 0.3f, 0.5f, 1.7f, false, 0.3f, 4, new float[] {0f, 0f, 0f, 0f, 0f, 0f}, false, true, 1, new int[] {103, 25, 102}));
root.Add(3521, new FireData(3521, "f3521", "", "", 7, true, 0, 0f, 0, 0f, 0.3f, 0.4f, 0.68f, false, 0.3f, 4, new float[] {0f, 0f, 0f, 0f, 0f, 0f}, false, true, 1, new int[] {103, 25, 102}));
root.Add(3522, new FireData(3522, "f3522", "", "", 7, true, 0, 0f, 0, 0f, 0.3f, 0.3f, 1.7f, false, 0.3f, 4, new float[] {0f, 0f, 0f, 0f, 0f, 0f}, false, true, 1, new int[] {103, 25, 102}));
root.Add(3523, new FireData(3523, "f3523", "", "", 7, true, 0, 0f, 0, 0f, 0.3f, 0.2f, 0.34f, false, 0.3f, 4, new float[] {0f, 0f, 0f, 0f, 0f, 0f}, false, true, 1, new int[] {103, 25, 102}));
root.Add(3524, new FireData(3524, "f3524", "", "", 7, true, 0, 0f, 0, 0f, 0.3f, 0.1f, 1.7f, false, 0.3f, 4, new float[] {0f, 0f, 0f, 0f, 0f, 0f}, false, true, 1, new int[] {103, 25, 102}));
root.Add(3525, new FireData(3525, "f3525", "", "", 0, false, 0, 0f, 0, 0f, 0f, 0f, 0f, false, 0f, 0, new float[] {0f, 0f, 0f, 0f, 0f, 0f}, false, false, 0, new int[] {0, 0, 0}));
}
public FireData GetReadData(int ID){
if (root.ContainsKey(ID))
return root[ID];
else{
object obj = MMFramework.ModifyExcelModule.Instance.GetModifyedData(ID);
if (obj != null)return obj as FireData;
Debug.LogError("在表格 FireData中没有找到ID" + ID);
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
FireData data = GetReadData(key);
Type type = data.GetType();
System.Reflection.FieldInfo[] filedinfos = type.GetFields();
for (int i = 0; i < filedinfos.Length; i++)
{System.Reflection.FieldInfo field = filedinfos[i];
pairs.Add(field.Name, field.GetValue(data).ToString());}
return pairs;}
}
public static FireData GetData(int ID){
return FireDataReader.Instance.GetReadData(ID);
}
public static Dictionary<string, string> GetDictionary(int key)
{ return FireDataReader.Instance.GetReadDictionary(key);}
public static int GetNum(){
return FireDataReader.Instance.GetCount();
}
public static List<int> GetKeys(){
return FireDataReader.Instance.GetDataKeys();
}
public static void SaveToFile(string path){
FireDataReader.Instance.WriteToFile(path);
}

}