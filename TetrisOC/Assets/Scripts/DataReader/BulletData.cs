using System;
using System.Collections.Generic;
using UnityEngine;
[Serializable]
public class BulletData{
/// <summary>
/// 子弹序号
/// </summary>
public int bulletID;
/// <summary>
/// prefab子弹
/// </summary>
public string Prefab;
/// <summary>
/// 动画器
/// </summary>
public string AnimControllerPath;
/// <summary>
/// 飞行动画
/// </summary>
public string FlyAction;
/// <summary>
/// 碰撞动画
/// </summary>
public string HitAction;
/// <summary>
/// 最大碰人次数
/// </summary>
public int OnlyCollisionOnetime;
/// <summary>
/// 是否贴地
/// </summary>
public bool Ground;
/// <summary>
/// 碰墙是否消失
/// </summary>
public bool WallCollision;
public BulletData(int bulletID, string Prefab, string AnimControllerPath, string FlyAction, string HitAction, int OnlyCollisionOnetime, bool Ground, bool WallCollision){
this.bulletID = bulletID;
this.Prefab = Prefab;
this.AnimControllerPath = AnimControllerPath;
this.FlyAction = FlyAction;
this.HitAction = HitAction;
this.OnlyCollisionOnetime = OnlyCollisionOnetime;
this.Ground = Ground;
this.WallCollision = WallCollision;
}
class BulletDataReader{
static BulletDataReader instance;
static object syncRoot = new object();
public static BulletDataReader Instance{get{if (instance == null){lock (syncRoot){if (instance == null){instance = new BulletDataReader();instance.Load();}}}return instance;}}
Dictionary<int, BulletData> root = new Dictionary<int, BulletData>();
void Load(){
root.Add(1, new BulletData(1, "Prefabs/bullet", "Ase/bullet/bullet_empty30", "bullet_empty30_fly", "", 1, true, true));
root.Add(2, new BulletData(2, "Prefabs/bullet", "Ase/bullet/bullet_empty100", "bullet_empty100_fly", "", 4, true, true));
root.Add(3, new BulletData(3, "Prefabs/bullet", "Ase/bullet/bullet_empty3", "bullet_empty3_fly", "", 1, true, true));
root.Add(4, new BulletData(4, "Animation/ani_prefabs/bullet/bullet_xuli", "", "xuli", "", 1, false, false));
root.Add(5, new BulletData(5, "Prefabs/bullet", "Ase/bullet/bullet_empty_knight", "bullet_empty_knight", "", 1, true, false));
root.Add(6, new BulletData(6, "Prefabs/bullet", "Ase/bullet/bullet_empty_berserker", "bullet_empty_berserker", "", 1, true, false));
root.Add(7, new BulletData(7, "Animation/ani_prefabs/bullet/bullet_empty_monster", "", "", "", 1, true, false));
root.Add(8, new BulletData(8, "Animation/ani_prefabs/bullet/bullet_empty_monster_big", "", "", "", 99, true, false));
root.Add(4001, new BulletData(4001, "Prefabs/bullet", "Ase/bullet/sword_hit", "sword_hit_hit01", "", 999, false, false));
root.Add(4002, new BulletData(4002, "Prefabs/bullet", "Ase/bullet/sword_hit", "sword_hit_hit02", "", 999, false, false));
root.Add(4003, new BulletData(4003, "Prefabs/bullet", "Ase/bullet/sword_hit", "sword_hit_hit03", "", 999, false, false));
root.Add(4004, new BulletData(4004, "Prefabs/bullet", "Ase/bullet/sword_hit", "sword_hit_hit04", "", 999, false, false));
root.Add(4005, new BulletData(4005, "Prefabs/bullet", "Ase/bullet/arrow", "arrow_fly", "arrow_hit", 1, false, true));
root.Add(4100, new BulletData(4100, "Animation/ani_prefabs/bullet/juese_swordhit01_fire", "", "", "", 999, false, false));
root.Add(4101, new BulletData(4101, "Animation/ani_prefabs/bullet/juese_swordhit01_wind", "", "", "", 999, false, false));
root.Add(4102, new BulletData(4102, "Animation/ani_prefabs/bullet/juese_swordhit01_water", "", "", "", 999, false, false));
root.Add(4103, new BulletData(4103, "Animation/ani_prefabs/bullet/juese_swordhit01_light", "", "", "", 999, false, false));
root.Add(4104, new BulletData(4104, "Animation/ani_prefabs/bullet/juese_swordhit01_dark", "", "", "", 999, false, false));
root.Add(4105, new BulletData(4105, "Animation/ani_prefabs/bullet/axe_hit_fire", "", "", "", 999, false, false));
root.Add(4106, new BulletData(4106, "Animation/ani_prefabs/bullet/axe_hit_wind", "", "", "", 999, false, false));
root.Add(4107, new BulletData(4107, "Animation/ani_prefabs/bullet/axe_hit_water", "", "", "", 999, false, false));
root.Add(4108, new BulletData(4108, "Animation/ani_prefabs/bullet/axe_hit_light", "", "", "", 999, false, false));
root.Add(4109, new BulletData(4109, "Animation/ani_prefabs/bullet/axe_hit_dark", "", "", "", 999, false, false));
root.Add(4110, new BulletData(4110, "Animation/ani_prefabs/bullet/bullet_arrow_fire", "", "", "", 1, false, true));
root.Add(4111, new BulletData(4111, "Animation/ani_prefabs/bullet/bullet_arrow_wind", "", "", "", 1, false, true));
root.Add(4112, new BulletData(4112, "Animation/ani_prefabs/bullet/bullet_arrow_water", "", "", "", 1, false, true));
root.Add(4113, new BulletData(4113, "Animation/ani_prefabs/bullet/bullet_arrow_light", "", "", "", 1, false, true));
root.Add(4114, new BulletData(4114, "Animation/ani_prefabs/bullet/bullet_arrow_dark", "", "", "", 1, false, true));
root.Add(4115, new BulletData(4115, "Animation/ani_prefabs/bullet/bullet_hit_fire", "", "", "", 1, false, true));
root.Add(4116, new BulletData(4116, "Animation/ani_prefabs/bullet/bullet_hit_wind", "", "", "", 1, false, true));
root.Add(4117, new BulletData(4117, "Animation/ani_prefabs/bullet/bullet_hit_water", "", "", "", 1, false, true));
root.Add(4118, new BulletData(4118, "Animation/ani_prefabs/bullet/bullet_hit_light", "", "", "", 1, false, true));
root.Add(4119, new BulletData(4119, "Animation/ani_prefabs/bullet/bullet_hit_dark", "", "", "", 1, false, true));
root.Add(4120, new BulletData(4120, "Animation/ani_prefabs/bullet/bullet_ball_fire", "", "", "", 1, false, true));
root.Add(4121, new BulletData(4121, "Animation/ani_prefabs/bullet/bullet_ball_wind", "", "", "", 1, false, true));
root.Add(4122, new BulletData(4122, "Animation/ani_prefabs/bullet/bullet_ball_water", "", "", "", 1, false, true));
root.Add(4123, new BulletData(4123, "Animation/ani_prefabs/bullet/bullet_ball_light", "", "", "", 1, false, true));
root.Add(4124, new BulletData(4124, "Animation/ani_prefabs/bullet/bullet_ball_dark", "", "", "", 1, false, true));
root.Add(4125, new BulletData(4125, "Animation/ani_prefabs/bullet/bullet_bottle_fire", "", "", "", 1, false, true));
root.Add(4126, new BulletData(4126, "Animation/ani_prefabs/bullet/bullet_bottle_wind", "", "", "", 1, false, true));
root.Add(4127, new BulletData(4127, "Animation/ani_prefabs/bullet/bullet_bottle_water", "", "", "", 1, false, true));
root.Add(4128, new BulletData(4128, "Animation/ani_prefabs/bullet/bullet_bottle_light", "", "", "", 1, false, true));
root.Add(4129, new BulletData(4129, "Animation/ani_prefabs/bullet/bullet_bottle_dark", "", "", "", 1, false, true));
root.Add(4130, new BulletData(4130, "Animation/ani_prefabs/bullet/bullet_bullet_fire", "", "", "", 1, false, true));
root.Add(4131, new BulletData(4131, "Animation/ani_prefabs/bullet/bullet_bullet_wind", "", "", "", 1, false, true));
root.Add(4132, new BulletData(4132, "Animation/ani_prefabs/bullet/bullet_bullet_water", "", "", "", 1, false, true));
root.Add(4133, new BulletData(4133, "Animation/ani_prefabs/bullet/bullet_bullet_light", "", "", "", 1, false, true));
root.Add(4134, new BulletData(4134, "Animation/ani_prefabs/bullet/bullet_bullet_dark", "", "", "", 1, false, true));
root.Add(4135, new BulletData(4135, "Animation/ani_prefabs/bullet/bullet_ball_fire_explosion", "", "", "", 999, false, false));
root.Add(4136, new BulletData(4136, "Animation/ani_prefabs/bullet/bullet_ball_wind_explosion", "", "", "", 999, false, false));
root.Add(4137, new BulletData(4137, "Animation/ani_prefabs/bullet/bullet_ball_water_explosion", "", "", "", 999, false, false));
root.Add(4138, new BulletData(4138, "Animation/ani_prefabs/bullet/bullet_ball_light_explosion", "", "", "", 999, false, false));
root.Add(4139, new BulletData(4139, "Animation/ani_prefabs/bullet/bullet_ball_dark_explosion", "", "", "", 999, false, false));
root.Add(4140, new BulletData(4140, "", "", "", "", 0, false, false));
root.Add(4200, new BulletData(4200, "Animation/ani_prefabs/bullet/double_strike", "", "double_strike", "", 999, false, false));
root.Add(4201, new BulletData(4201, "Animation/ani_prefabs/bullet/wind_sword", "", "wind_sword", "", 999, false, false));
root.Add(4202, new BulletData(4202, "", "", "", "", 999, false, false));
root.Add(4203, new BulletData(4203, "", "", "", "", 999, false, false));
root.Add(4204, new BulletData(4204, "", "", "", "", 999, false, false));
root.Add(4205, new BulletData(4205, "", "", "", "", 999, false, false));
root.Add(4206, new BulletData(4206, "Animation/ani_prefabs/bullet/bullet_skill_light_sword", "", "bullet_skill_light_sword", "", 999, false, false));
root.Add(4207, new BulletData(4207, "", "", "", "", 999, false, false));
root.Add(4208, new BulletData(4208, "", "", "", "", 999, false, false));
root.Add(4209, new BulletData(4209, "Animation/ani_prefabs/bullet/big_axe_hit_wind", "", "big_axe_hit_wind", "", 999, false, false));
root.Add(4210, new BulletData(4210, "", "", "", "", 999, true, false));
root.Add(4211, new BulletData(4211, "Animation/ani_prefabs/bullet/big_axe_hit_water", "", "big_axe_hit_water", "", 999, false, false));
root.Add(4212, new BulletData(4212, "", "", "", "", 999, false, false));
root.Add(4213, new BulletData(4213, "", "", "", "", 999, false, false));
root.Add(4214, new BulletData(4214, "", "", "", "", 999, false, false));
root.Add(4215, new BulletData(4215, "", "", "", "", 999, false, false));
root.Add(4216, new BulletData(4216, "", "", "", "", 999, false, false));
root.Add(4217, new BulletData(4217, "", "", "", "", 999, false, false));
root.Add(4218, new BulletData(4218, "", "", "", "", 999, false, false));
root.Add(4219, new BulletData(4219, "Animation/ani_prefabs/bullet/bullet_fire_zhu", "", "bullet_fire_zhu", "", 999, true, false));
root.Add(4220, new BulletData(4220, "Animation/ani_prefabs/bullet/bullet_ice_zhu", "", "bullet_ice_zhu", "", 999, true, false));
root.Add(4221, new BulletData(4221, "Animation/ani_prefabs/bullet/bullet_light_ball", "", "bullet_light_ball", "", 999, false, false));
root.Add(4222, new BulletData(4222, "", "", "", "", 999, true, false));
root.Add(4223, new BulletData(4223, "", "", "", "", 999, false, false));
root.Add(4224, new BulletData(4224, "", "", "", "", 999, false, false));
root.Add(4225, new BulletData(4225, "", "", "", "", 999, false, false));
root.Add(4226, new BulletData(4226, "", "", "", "", 999, false, false));
root.Add(4227, new BulletData(4227, "Animation/ani_prefabs/bullet/arrow_red", "", "arrow_red", "", 999, false, false));
root.Add(4228, new BulletData(4228, "Animation/ani_prefabs/bullet/arrow_green", "", "arrow_green", "", 999, false, false));
root.Add(4229, new BulletData(4229, "", "", "", "", 999, false, false));
root.Add(4230, new BulletData(4230, "Animation/ani_prefabs/bullet/arrow_blue", "", "arrow_blue", "", 999, false, false));
root.Add(4231, new BulletData(4231, "", "", "", "", 999, false, false));
root.Add(4232, new BulletData(4232, "", "", "", "", 999, false, false));
root.Add(4233, new BulletData(4233, "", "", "", "", 999, false, false));
root.Add(4234, new BulletData(4234, "Animation/ani_prefabs/bullet/gun_hit_bullet", "", "gun_hit_bullet_fly", "", 1, false, true));
root.Add(4235, new BulletData(4235, "Animation/ani_prefabs/bullet/ice_grenade", "", "ice_grenade", "", 1, false, false));
root.Add(4236, new BulletData(4236, "", "", "", "", 999, false, false));
root.Add(4237, new BulletData(4237, "Animation/ani_prefabs/bullet/gun_hit_bullet", "", "gun_hit_bullet_fly", "", 1, false, true));
root.Add(4238, new BulletData(4238, "", "", "", "", 999, false, false));
root.Add(4239, new BulletData(4239, "", "", "", "", 999, false, false));
root.Add(4240, new BulletData(4240, "", "", "", "", 999, false, false));
root.Add(4241, new BulletData(4241, "", "", "", "", 999, false, false));
root.Add(4242, new BulletData(4242, "Animation/ani_prefabs/bullet/skill_bobo", "", "skill_bobo", "", 999, false, false));
root.Add(4243, new BulletData(4243, "", "", "", "", 999, false, false));
root.Add(4244, new BulletData(4244, "", "", "", "", 999, false, false));
root.Add(4245, new BulletData(4245, "", "", "", "", 999, false, false));
root.Add(4246, new BulletData(4246, "", "", "", "", 999, false, false));
root.Add(4247, new BulletData(4247, "Animation/ani_prefabs/bullet/skill_hermes", "", "skill_hermes", "", 999, false, false));
root.Add(4300, new BulletData(4300, "Animation/ani_prefabs/bullet/skill_erwin_empty", "", "skill_erwin_empty", "", 999, false, false));
root.Add(4301, new BulletData(4301, "Animation/ani_prefabs/bullet/bullet_push_back", "", "bullet_push_back", "", 999, false, false));
root.Add(4302, new BulletData(4302, "Animation/ani_prefabs/bullet/skill_fabio", "", "skill_fabio", "", 999, false, false));
root.Add(4303, new BulletData(4303, "", "", "", "", 999, false, false));
root.Add(4304, new BulletData(4304, "Animation/ani_prefabs/bullet/skill_nova", "", "skill_nova", "", 999, false, false));
root.Add(4305, new BulletData(4305, "Animation/ani_prefabs/bullet/skill_renato", "", "skill_renato", "", 999, false, false));
root.Add(4306, new BulletData(4306, "", "", "", "", 999, false, false));
root.Add(4307, new BulletData(4307, "", "", "", "", 999, false, false));
root.Add(4308, new BulletData(4308, "Animation/ani_prefabs/bullet/skill_guloo", "", "skill_guloo", "", 999, false, false));
root.Add(4309, new BulletData(4309, "", "", "", "", 999, false, false));
root.Add(4310, new BulletData(4310, "Animation/ani_prefabs/bullet/bullet_skill_fanny", "", "bullet_skill_fanny", "", 999, false, false));
root.Add(4311, new BulletData(4311, "Animation/ani_prefabs/bullet/bullet_skill_fanny", "", "bullet_skill_fanny", "", 999, false, false));
root.Add(4312, new BulletData(4312, "", "", "", "", 999, false, false));
root.Add(4313, new BulletData(4313, "", "", "", "", 999, false, false));
root.Add(4314, new BulletData(4314, "", "", "", "", 2, false, false));
root.Add(4315, new BulletData(4315, "Animation/ani_prefabs/bullet/bullet_skill_poison", "", "bullet_skill_poison", "", 999, false, false));
root.Add(4316, new BulletData(4316, "", "", "", "", 999, false, false));
root.Add(4317, new BulletData(4317, "", "", "", "", 999, false, false));
root.Add(4318, new BulletData(4318, "", "", "", "", 999, false, false));
root.Add(4319, new BulletData(4319, "", "", "", "", 999, false, false));
root.Add(4320, new BulletData(4320, "Animation/ani_prefabs/bullet/bullet_skill_curse_bomb", "", "bullet_skill_curse_bomb", "", 999, false, false));
root.Add(4321, new BulletData(4321, "Animation/ani_prefabs/bullet/skill_gabriel", "", "skill_gabriel", "", 999, true, false));
root.Add(4322, new BulletData(4322, "Animation/ani_prefabs/bullet/skill_mulu", "", "skill_mulu", "", 999, true, false));
root.Add(4323, new BulletData(4323, "Animation/ani_prefabs/bullet/skill_dominic", "", "skill_dominic", "", 999, true, false));
root.Add(4324, new BulletData(4324, "", "", "", "", 999, true, false));
root.Add(4325, new BulletData(4325, "", "", "", "", 999, true, false));
root.Add(4326, new BulletData(4326, "", "", "", "", 999, true, false));
root.Add(4327, new BulletData(4327, "", "", "", "", 999, false, false));
root.Add(4328, new BulletData(4328, "", "", "", "", 999, false, false));
root.Add(4329, new BulletData(4329, "Animation/ani_prefabs/bullet/bullet_xuli_arrow", "", "bullet_xuli_arrow", "", 999, false, false));
root.Add(4330, new BulletData(4330, "Animation/ani_prefabs/bullet/bullet_lianshe_arrow", "", "bullet_lianshe_arrow", "", 1, false, true));
root.Add(4331, new BulletData(4331, "", "", "", "", 999, false, false));
root.Add(4332, new BulletData(4332, "Animation/ani_prefabs/bullet/bullet_bomb_arrow", "", "bullet_bomb_arrow", "", 1, false, true));
root.Add(4333, new BulletData(4333, "Animation/ani_prefabs/bullet/rainshot", "", "rain_shot_ani", "", 999, false, false));
root.Add(4334, new BulletData(4334, "", "", "", "", 999, false, false));
root.Add(4335, new BulletData(4335, "", "", "", "", 999, false, false));
root.Add(4336, new BulletData(4336, "", "", "", "", 999, false, false));
root.Add(4337, new BulletData(4337, "", "", "", "", 999, false, false));
root.Add(4338, new BulletData(4338, "", "", "", "", 999, false, false));
root.Add(4339, new BulletData(4339, "", "", "", "", 999, false, false));
root.Add(4340, new BulletData(4340, "", "", "", "", 999, false, false));
root.Add(4341, new BulletData(4341, "", "", "", "", 999, false, false));
root.Add(4342, new BulletData(4342, "", "", "", "", 999, false, false));
root.Add(4343, new BulletData(4343, "Animation/ani_prefabs/bullet/bullet_explosion", "", "bullet_explosion", "", 999, false, false));
root.Add(4344, new BulletData(4344, "Animation/ani_prefabs/bullet/gun_hit_smoke", "", "gun_hit_smoke", "", 999, false, false));
root.Add(4345, new BulletData(4345, "Animation/ani_prefabs/bullet/ice_grenade_explosion", "", "ice_grenade_explosion", "", 999, false, false));
root.Add(4346, new BulletData(4346, "", "", "", "", 0, false, false));
root.Add(4347, new BulletData(4347, "", "", "", "", 0, false, false));
root.Add(4348, new BulletData(4348, "", "", "", "", 0, false, false));
root.Add(4349, new BulletData(4349, "", "", "", "", 0, false, false));
root.Add(4350, new BulletData(4350, "", "", "", "", 0, false, false));
root.Add(4351, new BulletData(4351, "", "", "", "", 0, false, false));
root.Add(4352, new BulletData(4352, "", "", "", "", 0, false, false));
root.Add(4353, new BulletData(4353, "", "", "", "", 0, false, false));
root.Add(4354, new BulletData(4354, "", "", "", "", 0, false, false));
root.Add(4355, new BulletData(4355, "", "", "", "", 0, false, false));
root.Add(4356, new BulletData(4356, "", "", "", "", 0, false, false));
root.Add(4357, new BulletData(4357, "", "", "", "", 0, false, false));
root.Add(4358, new BulletData(4358, "", "", "", "", 0, false, false));
root.Add(4359, new BulletData(4359, "", "", "", "", 0, false, false));
root.Add(4360, new BulletData(4360, "", "", "", "", 0, false, false));
root.Add(4361, new BulletData(4361, "", "", "", "", 0, false, false));
root.Add(4501, new BulletData(4501, "Prefabs/bullet", "Ase/bullet/shot_common", "shot_common", "", 1, false, false));
root.Add(4502, new BulletData(4502, "Ase/effect/skill_backhaus_holdshot", "", "skill_backhaus_holdshot", "", 20, false, false));
root.Add(4503, new BulletData(4503, "Animation/ani_prefabs/bullet/skill_backhaus_rainshot", "", "", "", 1, false, false));
root.Add(4504, new BulletData(4504, "Animation/ani_prefabs/bullet/rainshot", "", "rain_shot_ani", "", 999, false, false));
root.Add(4505, new BulletData(4505, "", "", "", "", 1, false, false));
root.Add(4506, new BulletData(4506, "", "", "", "", 999, true, false));
root.Add(4507, new BulletData(4507, "", "", "", "", 0, false, false));
root.Add(4508, new BulletData(4508, "", "", "", "", 0, false, false));
root.Add(4900, new BulletData(4900, "Prefabs/bullet_enemyboss_laser", "", "bullet_enemyboss_laser_fly", "bullet_enemyboss_laser_hit", 999, false, false));
root.Add(4901, new BulletData(4901, "Animation/ani_prefabs/bullet/monster_bark", "", "monster_bark", "", 2, false, false));
root.Add(4902, new BulletData(4902, "Animation/ani_prefabs/bullet/monster_bite", "", "monster_bite", "", 2, false, false));
root.Add(4903, new BulletData(4903, "Animation/ani_prefabs/bullet/monster_bombhit_bullet", "", "monster_bombhit_bullet", "", 100, false, false));
root.Add(4904, new BulletData(4904, "Animation/ani_prefabs/bullet/monster_bombhit", "", "monster_bombhit", "", 100, true, false));
root.Add(4905, new BulletData(4905, "Animation/ani_prefabs/bullet/monster_throughhit", "", "monster_throughhit", "", 2, false, false));
root.Add(4906, new BulletData(4906, "Animation/ani_prefabs/bullet/arrow_red", "", "", "", 1, false, true));
root.Add(4907, new BulletData(4907, "Animation/ani_prefabs/bullet/arrow_green", "", "", "", 1, false, true));
root.Add(4908, new BulletData(4908, "Animation/ani_prefabs/bullet/arrow_blue", "", "", "", 1, false, true));
root.Add(4909, new BulletData(4909, "Animation/ani_prefabs/bullet/bullet_arrow_light", "", "", "", 1, false, true));
root.Add(4910, new BulletData(4910, "Animation/ani_prefabs/bullet/bullet_arrow_dark", "", "", "", 1, false, true));
root.Add(4911, new BulletData(4911, "", "", "", "", 0, false, false));
root.Add(4912, new BulletData(4912, "", "", "", "", 0, false, false));
root.Add(4913, new BulletData(4913, "", "", "", "", 0, false, false));
root.Add(4914, new BulletData(4914, "", "", "", "", 0, false, false));
root.Add(4915, new BulletData(4915, "", "", "", "", 0, false, false));
}
public BulletData GetReadData(int ID){
if (root.ContainsKey(ID))
return root[ID];
else{
object obj = MMFramework.ModifyExcelModule.Instance.GetModifyedData(ID);
if (obj != null)return obj as BulletData;
Debug.LogError("在表格 BulletData中没有找到ID" + ID);
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
BulletData data = GetReadData(key);
Type type = data.GetType();
System.Reflection.FieldInfo[] filedinfos = type.GetFields();
for (int i = 0; i < filedinfos.Length; i++)
{System.Reflection.FieldInfo field = filedinfos[i];
pairs.Add(field.Name, field.GetValue(data).ToString());}
return pairs;}
}
public static BulletData GetData(int ID){
return BulletDataReader.Instance.GetReadData(ID);
}
public static Dictionary<string, string> GetDictionary(int key)
{ return BulletDataReader.Instance.GetReadDictionary(key);}
public static int GetNum(){
return BulletDataReader.Instance.GetCount();
}
public static List<int> GetKeys(){
return BulletDataReader.Instance.GetDataKeys();
}
public static void SaveToFile(string path){
BulletDataReader.Instance.WriteToFile(path);
}

}