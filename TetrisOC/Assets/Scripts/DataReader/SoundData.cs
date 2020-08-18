using System;
using System.Collections.Generic;
using UnityEngine;
[Serializable]
public class SoundData{
/// <summary>
/// 来源
/// </summary>
public string key;
/// <summary>
/// 延迟
/// </summary>
public float delay;
/// <summary>
/// 声道(1是背景乐，0是音效）
/// </summary>
public int channel;
/// <summary>
/// 声音文件
/// </summary>
public string sound;
/// <summary>
/// 声音大小[0,1]
/// </summary>
public float volume;
/// <summary>
/// 是否循环
/// </summary>
public bool loop;
public SoundData(string key, float delay, int channel, string sound, float volume, bool loop){
this.key = key;
this.delay = delay;
this.channel = channel;
this.sound = sound;
this.volume = volume;
this.loop = loop;
}
class SoundDataReader{
static SoundDataReader instance;
static object syncRoot = new object();
public static SoundDataReader Instance{get{if (instance == null){lock (syncRoot){if (instance == null){instance = new SoundDataReader();instance.Load();}}}return instance;}}
Dictionary<string, SoundData> root = new Dictionary<string, SoundData>();
void Load(){
root.Add("bgm_go_down", new SoundData("bgm_go_down", 0f, 1, "Sounds/01BGM", 1f, true));
root.Add("bgm_home", new SoundData("bgm_home", 0f, 1, "Sounds/home", 1f, true));
root.Add("bgm_fight_1", new SoundData("bgm_fight_1", 0f, 1, "Sounds/01BGM", 1f, true));
root.Add("bgm_fight_2", new SoundData("bgm_fight_2", 0f, 1, "Sounds/02BGM", 1f, true));
root.Add("bgm_fight_3", new SoundData("bgm_fight_3", 0f, 1, "Sounds/03BGM", 1f, true));
root.Add("bgm_fight_4", new SoundData("bgm_fight_4", 0f, 1, "Sounds/04BGM", 1f, true));
root.Add("HeroStarUpUI/in", new SoundData("HeroStarUpUI/in", 0f, 0, "Sounds/black_hole_long", 1f, false));
root.Add("btn1", new SoundData("btn1", 0f, 0, "Sounds/btn1", 1f, false));
root.Add("btn2", new SoundData("btn2", 0f, 0, "Sounds/btn2", 1f, false));
root.Add("btn3", new SoundData("btn3", 0f, 0, "Sounds/btn3", 1f, false));
root.Add("btn4", new SoundData("btn4", 0f, 0, "Sounds/btn4", 1f, false));
root.Add("btn5", new SoundData("btn5", 0f, 0, "Sounds/btn5", 1f, false));
root.Add("btn6", new SoundData("btn6", 0f, 0, "Sounds/btn6", 1f, false));
root.Add("btn7", new SoundData("btn7", 0f, 0, "Sounds/btn7", 1f, false));
root.Add("btn8", new SoundData("btn8", 0f, 0, "Sounds/btn8", 1f, false));
root.Add("btn_good", new SoundData("btn_good", 0f, 0, "Sounds/good_feedback", 1f, false));
root.Add("skill_btn", new SoundData("skill_btn", 0f, 0, "Sounds/buff_all", 1f, false));
root.Add("fly_coin", new SoundData("fly_coin", 0f, 0, "Sounds/gold_fly", 1f, false));
root.Add("1", new SoundData("1", 0f, 0, "Sounds/none", 1f, false));
root.Add("2", new SoundData("2", 0f, 0, "Sounds/none", 1f, false));
root.Add("3", new SoundData("3", 0f, 0, "Sounds/none", 1f, false));
root.Add("4", new SoundData("4", 0f, 0, "Sounds/32buff1", 1f, false));
root.Add("5", new SoundData("5", 0f, 0, "Sounds/buff_all", 1f, false));
root.Add("6", new SoundData("6", 0f, 0, "Sounds/32buff", 1f, false));
root.Add("7", new SoundData("7", 0f, 0, "Sounds/buff_all", 1f, false));
root.Add("8", new SoundData("8", 0f, 0, "Sounds/none", 1f, false));
root.Add("9", new SoundData("9", 0f, 0, "Sounds/none", 1f, false));
root.Add("10", new SoundData("10", 0f, 0, "Sounds/none", 1f, false));
root.Add("11", new SoundData("11", 0f, 0, "Sounds/none", 1f, false));
root.Add("12", new SoundData("12", 0f, 0, "Sounds/36sword_behit", 1f, false));
root.Add("13", new SoundData("13", 0f, 0, "Sounds/s_fire_ball_hit2", 1f, false));
root.Add("14", new SoundData("14", 0f, 0, "Sounds/none", 1f, false));
root.Add("15", new SoundData("15", 0f, 0, "Sounds/none", 1f, false));
root.Add("16", new SoundData("16", 0f, 0, "Sounds/none", 1f, false));
root.Add("17", new SoundData("17", 0f, 0, "Sounds/curse_bomb", 1f, false));
root.Add("18", new SoundData("18", 0f, 0, "Sounds/none", 1f, false));
root.Add("19", new SoundData("19", 0f, 0, "Sounds/none", 1f, false));
root.Add("20", new SoundData("20", 0f, 0, "Sounds/none", 1f, false));
root.Add("21", new SoundData("21", 0f, 0, "Sounds/none", 1f, false));
root.Add("22", new SoundData("22", 0f, 0, "Sounds/none", 1f, false));
root.Add("23", new SoundData("23", 0f, 0, "Sounds/none", 1f, false));
root.Add("24", new SoundData("24", 0f, 0, "Sounds/none", 1f, false));
root.Add("25", new SoundData("25", 0f, 0, "Sounds/none", 1f, false));
root.Add("26", new SoundData("26", 0f, 0, "Sounds/30arrow_hit", 1f, false));
root.Add("27", new SoundData("27", 0f, 0, "Sounds/30arrow_hit", 1f, false));
root.Add("28", new SoundData("28", 0f, 0, "Sounds/30arrow_hit", 1f, false));
root.Add("29", new SoundData("29", 0f, 0, "Sounds/30arrow_hit", 1f, false));
root.Add("30", new SoundData("30", 0f, 0, "Sounds/30arrow_hit", 1f, false));
root.Add("31", new SoundData("31", 0f, 0, "Sounds/normal_hit", 1f, false));
root.Add("32", new SoundData("32", 0f, 0, "Sounds/normal_hit", 1f, false));
root.Add("33", new SoundData("33", 0f, 0, "Sounds/normal_hit", 1f, false));
root.Add("34", new SoundData("34", 0f, 0, "Sounds/normal_hit", 1f, false));
root.Add("35", new SoundData("35", 0f, 0, "Sounds/normal_hit", 1f, false));
root.Add("36", new SoundData("36", 0f, 0, "Sounds/none", 1f, false));
root.Add("37", new SoundData("37", 0f, 0, "Sounds/none", 1f, false));
root.Add("50", new SoundData("50", 0f, 0, "Sounds/none", 1f, false));
root.Add("51", new SoundData("51", 0f, 0, "Sounds/none", 1f, false));
root.Add("52", new SoundData("52", 0f, 0, "Sounds/none", 1f, false));
root.Add("53", new SoundData("53", 0f, 0, "Sounds/none", 1f, false));
root.Add("54", new SoundData("54", 0f, 0, "Sounds/none", 1f, false));
root.Add("55", new SoundData("55", 0f, 0, "Sounds/none", 1f, false));
root.Add("56", new SoundData("56", 0f, 0, "Sounds/none", 1f, false));
root.Add("57", new SoundData("57", 0f, 0, "Sounds/none", 1f, false));
root.Add("58", new SoundData("58", 0f, 0, "Sounds/none", 1f, false));
root.Add("59", new SoundData("59", 0f, 0, "Sounds/none", 1f, false));
root.Add("60", new SoundData("60", 0f, 0, "Sounds/none", 1f, false));
root.Add("61", new SoundData("61", 0f, 0, "Sounds/none", 1f, false));
root.Add("62", new SoundData("62", 0f, 0, "Sounds/none", 1f, false));
root.Add("63", new SoundData("63", 0f, 0, "Sounds/none", 1f, false));
root.Add("64", new SoundData("64", 0f, 0, "Sounds/none", 1f, false));
root.Add("65", new SoundData("65", 0f, 0, "Sounds/none", 1f, false));
root.Add("66", new SoundData("66", 0f, 0, "Sounds/none", 1f, false));
root.Add("67", new SoundData("67", 0f, 0, "Sounds/none", 1f, false));
root.Add("68", new SoundData("68", 0f, 0, "Sounds/none", 1f, false));
root.Add("69", new SoundData("69", 0f, 0, "Sounds/none", 1f, false));
root.Add("70", new SoundData("70", 0f, 0, "Sounds/none", 1f, false));
root.Add("71", new SoundData("71", 0f, 0, "Sounds/none", 1f, false));
root.Add("72", new SoundData("72", 0f, 0, "Sounds/none", 1f, false));
root.Add("73", new SoundData("73", 0f, 0, "Sounds/none", 1f, false));
root.Add("74", new SoundData("74", 0f, 0, "Sounds/none", 1f, false));
root.Add("75", new SoundData("75", 0f, 0, "Sounds/none", 1f, false));
root.Add("76", new SoundData("76", 0f, 0, "Sounds/none", 1f, false));
root.Add("77", new SoundData("77", 0f, 0, "Sounds/none", 1f, false));
root.Add("78", new SoundData("78", 0f, 0, "Sounds/none", 1f, false));
root.Add("79", new SoundData("79", 0f, 0, "Sounds/none", 1f, false));
root.Add("80", new SoundData("80", 0f, 0, "Sounds/none", 1f, false));
root.Add("81", new SoundData("81", 0f, 0, "Sounds/none", 1f, false));
root.Add("82", new SoundData("82", 0f, 0, "Sounds/none", 1f, false));
root.Add("83", new SoundData("83", 0f, 0, "Sounds/none", 1f, false));
root.Add("84", new SoundData("84", 0f, 0, "Sounds/none", 1f, false));
root.Add("85", new SoundData("85", 0f, 0, "Sounds/none", 1f, false));
root.Add("86", new SoundData("86", 0f, 0, "Sounds/none", 1f, false));
root.Add("87", new SoundData("87", 0f, 0, "Sounds/none", 1f, false));
root.Add("88", new SoundData("88", 0f, 0, "Sounds/none", 1f, false));
root.Add("89", new SoundData("89", 0f, 0, "Sounds/none", 1f, false));
root.Add("90", new SoundData("90", 0f, 0, "Sounds/none", 1f, false));
root.Add("91", new SoundData("91", 0f, 0, "Sounds/none", 1f, false));
root.Add("92", new SoundData("92", 0f, 0, "Sounds/none", 1f, false));
root.Add("93", new SoundData("93", 0f, 0, "Sounds/none", 1f, false));
root.Add("94", new SoundData("94", 0f, 0, "Sounds/none", 1f, false));
root.Add("95", new SoundData("95", 0f, 0, "Sounds/none", 1f, false));
root.Add("96", new SoundData("96", 0f, 0, "Sounds/none", 1f, false));
root.Add("97", new SoundData("97", 0f, 0, "Sounds/none", 1f, false));
root.Add("98", new SoundData("98", 0f, 0, "Sounds/none", 1f, false));
root.Add("99", new SoundData("99", 0f, 0, "Sounds/none", 1f, false));
root.Add("100", new SoundData("100", 0f, 0, "Sounds/none", 1f, false));
root.Add("101", new SoundData("101", 0f, 0, "Sounds/none", 1f, false));
root.Add("102", new SoundData("102", 0f, 0, "Sounds/none", 1f, false));
root.Add("103", new SoundData("103", 0f, 0, "Sounds/none", 1f, false));
root.Add("104", new SoundData("104", 0f, 0, "Sounds/none", 1f, false));
root.Add("3500", new SoundData("3500", 0f, 0, "Sounds/17bite", 1f, false));
root.Add("3501", new SoundData("3501", 0f, 0, "Sounds/none", 1f, false));
root.Add("3502", new SoundData("3502", 0f, 0, "Sounds/s_monster_bite", 1f, false));
root.Add("3503", new SoundData("3503", 0f, 0, "Sounds/none", 1f, false));
root.Add("3504", new SoundData("3504", 0f, 0, "Sounds/none", 1f, false));
root.Add("3505", new SoundData("3505", 0f, 0, "Sounds/s_monster_hit", 1f, false));
root.Add("3506", new SoundData("3506", 0f, 0, "Sounds/s_monster_hit", 1f, false));
root.Add("3507", new SoundData("3507", 0f, 0, "Sounds/s_monster_hit", 1f, false));
root.Add("3508", new SoundData("3508", 0f, 0, "Sounds/s_monster_hit", 1f, false));
root.Add("3509", new SoundData("3509", 0f, 0, "Sounds/s_monster_hit", 1f, false));
root.Add("3510", new SoundData("3510", 0f, 0, "Sounds/s_monster_hit", 1f, false));
root.Add("3511", new SoundData("3511", 0f, 0, "Sounds/s_monster_hit", 1f, false));
root.Add("3512", new SoundData("3512", 0f, 0, "Sounds/s_monster_hit", 1f, false));
root.Add("3513", new SoundData("3513", 0f, 0, "Sounds/s_monster_hit", 1f, false));
root.Add("3514", new SoundData("3514", 0f, 0, "Sounds/s_monster_hit", 1f, false));
root.Add("3515", new SoundData("3515", 0f, 0, "Sounds/s_monster_hit", 1f, false));
root.Add("3516", new SoundData("3516", 0f, 0, "Sounds/s_monster_hit", 1f, false));
root.Add("3517", new SoundData("3517", 0f, 0, "Sounds/s_monster_hit", 1f, false));
root.Add("3518", new SoundData("3518", 0f, 0, "Sounds/s_monster_hit", 1f, false));
root.Add("3519", new SoundData("3519", 0f, 0, "Sounds/s_monster_hit", 1f, false));
root.Add("3520", new SoundData("3520", 0f, 0, "Sounds/s_monster_hit", 1f, false));
root.Add("3521", new SoundData("3521", 0f, 0, "Sounds/s_monster_hit", 1f, false));
root.Add("3522", new SoundData("3522", 0f, 0, "Sounds/s_monster_hit", 1f, false));
root.Add("3523", new SoundData("3523", 0f, 0, "Sounds/s_monster_hit", 1f, false));
root.Add("3524", new SoundData("3524", 0f, 0, "Sounds/s_monster_hit", 1f, false));
root.Add("3100", new SoundData("3100", 0f, 0, "Sounds/sword_hit1", 1f, false));
root.Add("3101", new SoundData("3101", 0f, 0, "Sounds/41sword_kan", 1f, false));
root.Add("3102", new SoundData("3102", 0f, 0, "Sounds/sword_hit3", 1f, false));
root.Add("3103", new SoundData("3103", 0f, 0, "Sounds/41sword_kan", 1f, false));
root.Add("3104", new SoundData("3104", 0f, 0, "Sounds/41sword_kan", 1f, false));
root.Add("3105", new SoundData("3105", 0f, 0, "Sounds/42sword_ci", 1f, false));
root.Add("3106", new SoundData("3106", 0f, 0, "Sounds/42sword_ci", 1f, false));
root.Add("3107", new SoundData("3107", 0f, 0, "Sounds/s_water_axe", 1f, false));
root.Add("3108", new SoundData("3108", 0f, 0, "Sounds/42sword_ci", 1f, false));
root.Add("3109", new SoundData("3109", 0f, 0, "Sounds/42sword_ci", 1f, false));
root.Add("3110", new SoundData("3110", 0f, 0, "Sounds/44arrow_fly", 1f, false));
root.Add("3111", new SoundData("3111", 0f, 0, "Sounds/44arrow_fly", 1f, false));
root.Add("3112", new SoundData("3112", 0f, 0, "Sounds/44arrow_fly", 1f, false));
root.Add("3113", new SoundData("3113", 0f, 0, "Sounds/44arrow_fly", 1f, false));
root.Add("3114", new SoundData("3114", 0f, 0, "Sounds/44arrow_fly", 1f, false));
root.Add("3115", new SoundData("3115", 0f, 0, "Sounds/55magic_ball2", 1f, false));
root.Add("3116", new SoundData("3116", 0f, 0, "Sounds/55magic_ball2", 1f, false));
root.Add("3117", new SoundData("3117", 0f, 0, "Sounds/55magic_ball2", 1f, false));
root.Add("3118", new SoundData("3118", 0f, 0, "Sounds/55magic_ball2", 1f, false));
root.Add("3119", new SoundData("3119", 0f, 0, "Sounds/55magic_ball2", 1f, false));
root.Add("3120", new SoundData("3120", 0f, 0, "Sounds/s_fire_ball_fly", 1f, false));
root.Add("3121", new SoundData("3121", 0f, 0, "Sounds/none", 1f, false));
root.Add("3122", new SoundData("3122", 0f, 0, "Sounds/45ice_ball", 1f, false));
root.Add("3123", new SoundData("3123", 0f, 0, "Sounds/none", 1f, false));
root.Add("3124", new SoundData("3124", 0f, 0, "Sounds/46magic_ball", 1f, false));
root.Add("3125", new SoundData("3125", 0f, 0, "Sounds/none", 1f, false));
root.Add("3126", new SoundData("3126", 0f, 0, "Sounds/none", 1f, false));
root.Add("3127", new SoundData("3127", 0f, 0, "Sounds/none", 1f, false));
root.Add("3128", new SoundData("3128", 0f, 0, "Sounds/none", 1f, false));
root.Add("3129", new SoundData("3129", 0f, 0, "Sounds/none", 1f, false));
root.Add("3130", new SoundData("3130", 0f, 0, "Sounds/none", 1f, false));
root.Add("3131", new SoundData("3131", 0f, 0, "Sounds/none", 1f, false));
root.Add("3132", new SoundData("3132", 0f, 0, "Sounds/none", 1f, false));
root.Add("3133", new SoundData("3133", 0f, 0, "Sounds/none", 1f, false));
root.Add("3134", new SoundData("3134", 0f, 0, "Sounds/none", 1f, false));
root.Add("3135", new SoundData("3135", 0f, 0, "Sounds/none", 1f, false));
root.Add("3136", new SoundData("3136", 0f, 0, "Sounds/none", 1f, false));
root.Add("3137", new SoundData("3137", 0f, 0, "Sounds/none", 1f, false));
root.Add("3138", new SoundData("3138", 0f, 0, "Sounds/none", 1f, false));
root.Add("3139", new SoundData("3139", 0f, 0, "Sounds/none", 1f, false));
root.Add("3140", new SoundData("3140", 0f, 0, "Sounds/none", 1f, false));
root.Add("3141", new SoundData("3141", 0f, 0, "Sounds/none", 1f, false));
root.Add("3142", new SoundData("3142", 0f, 0, "Sounds/none", 1f, false));
root.Add("3143", new SoundData("3143", 0f, 0, "Sounds/none", 1f, false));
root.Add("3144", new SoundData("3144", 0f, 0, "Sounds/none", 1f, false));
root.Add("3145", new SoundData("3145", 0f, 0, "Sounds/none", 1f, false));
root.Add("3146", new SoundData("3146", 0f, 0, "Sounds/none", 1f, false));
root.Add("3147", new SoundData("3147", 0f, 0, "Sounds/none", 1f, false));
root.Add("3148", new SoundData("3148", 0f, 0, "Sounds/none", 1f, false));
root.Add("3149", new SoundData("3149", 0f, 0, "Sounds/none", 1f, false));
root.Add("3150", new SoundData("3150", 0f, 0, "Sounds/none", 1f, false));
root.Add("3151", new SoundData("3151", 0f, 0, "Sounds/none", 1f, false));
root.Add("3152", new SoundData("3152", 0f, 0, "Sounds/none", 1f, false));
root.Add("3153", new SoundData("3153", 0f, 0, "Sounds/none", 1f, false));
root.Add("3154", new SoundData("3154", 0f, 0, "Sounds/none", 1f, false));
root.Add("3155", new SoundData("3155", 0f, 0, "Sounds/none", 1f, false));
root.Add("3156", new SoundData("3156", 0f, 0, "Sounds/none", 1f, false));
root.Add("3157", new SoundData("3157", 0f, 0, "Sounds/none", 1f, false));
root.Add("3158", new SoundData("3158", 0f, 0, "Sounds/none", 1f, false));
root.Add("3159", new SoundData("3159", 0f, 0, "Sounds/none", 1f, false));
root.Add("3160", new SoundData("3160", 0f, 0, "Sounds/none", 1f, false));
root.Add("3161", new SoundData("3161", 0f, 0, "Sounds/none", 1f, false));
root.Add("3162", new SoundData("3162", 0f, 0, "Sounds/none", 1f, false));
root.Add("3163", new SoundData("3163", 0f, 0, "Sounds/none", 1f, false));
root.Add("3164", new SoundData("3164", 0f, 0, "Sounds/none", 1f, false));
root.Add("3165", new SoundData("3165", 0f, 0, "Sounds/none", 1f, false));
root.Add("3166", new SoundData("3166", 0f, 0, "Sounds/none", 1f, false));
root.Add("3167", new SoundData("3167", 0f, 0, "Sounds/none", 1f, false));
root.Add("3168", new SoundData("3168", 0f, 0, "Sounds/none", 1f, false));
root.Add("3169", new SoundData("3169", 0f, 0, "Sounds/none", 1f, false));
root.Add("3170", new SoundData("3170", 0f, 0, "Sounds/21ca_ice", 1f, false));
root.Add("3171", new SoundData("3171", 0f, 0, "Sounds/none", 1f, false));
root.Add("3172", new SoundData("3172", 0f, 0, "Sounds/none", 1f, false));
root.Add("3173", new SoundData("3173", 0f, 0, "Sounds/none", 1f, false));
root.Add("3174", new SoundData("3174", 0f, 0, "Sounds/none", 1f, false));
root.Add("3175", new SoundData("3175", 0f, 0, "Sounds/none", 1f, false));
root.Add("3176", new SoundData("3176", 0f, 0, "Sounds/none", 1f, false));
root.Add("3177", new SoundData("3177", 0f, 0, "Sounds/38lianshe", 1f, false));
root.Add("3178", new SoundData("3178", 0f, 0, "Sounds/none", 1f, false));
root.Add("3179", new SoundData("3179", 0f, 0, "Sounds/none", 1f, false));
root.Add("3180", new SoundData("3180", 0f, 0, "Sounds/none", 1f, false));
root.Add("3181", new SoundData("3181", 0f, 0, "Sounds/none", 1f, false));
root.Add("3182", new SoundData("3182", 0f, 0, "Sounds/none", 1f, false));
root.Add("3183", new SoundData("3183", 0f, 0, "Sounds/none", 1f, false));
root.Add("3184", new SoundData("3184", 0f, 0, "Sounds/none", 1f, false));
root.Add("3185", new SoundData("3185", 0f, 0, "Sounds/none", 1f, false));
root.Add("3186", new SoundData("3186", 0f, 0, "Sounds/none", 1f, false));
root.Add("3187", new SoundData("3187", 0f, 0, "Sounds/none", 1f, false));
root.Add("3188", new SoundData("3188", 0f, 0, "Sounds/none", 1f, false));
root.Add("3189", new SoundData("3189", 0f, 0, "Sounds/none", 1f, false));
root.Add("3190", new SoundData("3190", 0f, 0, "Sounds/none", 1f, false));
root.Add("3191", new SoundData("3191", 0f, 0, "Sounds/25magic_shield1", 1f, false));
root.Add("3192", new SoundData("3192", 0f, 0, "Sounds/none", 1f, false));
root.Add("3193", new SoundData("3193", 0f, 0, "Sounds/none", 1f, false));
root.Add("3194", new SoundData("3194", 0f, 0, "Sounds/none", 1f, false));
root.Add("3195", new SoundData("3195", 0f, 0, "Sounds/none", 1f, false));
root.Add("3196", new SoundData("3196", 0f, 0, "Sounds/none", 1f, false));
root.Add("3197", new SoundData("3197", 0f, 0, "Sounds/none", 1f, false));
root.Add("3198", new SoundData("3198", 0f, 0, "Sounds/none", 1f, false));
root.Add("3199", new SoundData("3199", 0f, 0, "Sounds/none", 1f, false));
root.Add("3200", new SoundData("3200", 0f, 0, "Sounds/none", 1f, false));
root.Add("3201", new SoundData("3201", 0f, 0, "Sounds/none", 1f, false));
root.Add("3202", new SoundData("3202", 0f, 0, "Sounds/none", 1f, false));
root.Add("3203", new SoundData("3203", 0f, 0, "Sounds/none", 1f, false));
root.Add("3204", new SoundData("3204", 0f, 0, "Sounds/none", 1f, false));
root.Add("3205", new SoundData("3205", 0f, 0, "Sounds/none", 1f, false));
root.Add("3206", new SoundData("3206", 0f, 0, "Sounds/none", 1f, false));
root.Add("3207", new SoundData("3207", 0f, 0, "Sounds/none", 1f, false));
root.Add("3208", new SoundData("3208", 0f, 0, "Sounds/none", 1f, false));
root.Add("3209", new SoundData("3209", 0f, 0, "Sounds/none", 1f, false));
root.Add("3210", new SoundData("3210", 0f, 0, "Sounds/none", 1f, false));
root.Add("3211", new SoundData("3211", 0f, 0, "Sounds/none", 1f, false));
root.Add("3212", new SoundData("3212", 0f, 0, "Sounds/none", 1f, false));
root.Add("3213", new SoundData("3213", 0f, 0, "Sounds/s_poison_skill", 1f, false));
root.Add("3214", new SoundData("3214", 0f, 0, "Sounds/none", 1f, false));
root.Add("3215", new SoundData("3215", 0f, 0, "Sounds/none", 1f, false));
root.Add("3216", new SoundData("3216", 0f, 0, "Sounds/none", 1f, false));
root.Add("3217", new SoundData("3217", 0f, 0, "Sounds/none", 1f, false));
root.Add("3218", new SoundData("3218", 0f, 0, "Sounds/none", 1f, false));
root.Add("3219", new SoundData("3219", 0f, 0, "Sounds/s_fire_wind", 1f, false));
root.Add("3220", new SoundData("3220", 0f, 0, "Sounds/none", 1f, false));
root.Add("3221", new SoundData("3221", 0f, 0, "Sounds/none", 1f, false));
root.Add("3222", new SoundData("3222", 0f, 0, "Sounds/none", 1f, false));
root.Add("3223", new SoundData("3223", 0f, 0, "Sounds/none", 1f, false));
root.Add("3224", new SoundData("3224", 0f, 0, "Sounds/none", 1f, false));
root.Add("3225", new SoundData("3225", 0f, 0, "Sounds/none", 1f, false));
root.Add("3226", new SoundData("3226", 0f, 0, "Sounds/none", 1f, false));
root.Add("3227", new SoundData("3227", 0f, 0, "Sounds/xulijian", 1f, false));
root.Add("3228", new SoundData("3228", 0f, 0, "Sounds/31jump_shoot", 1f, false));
root.Add("3229", new SoundData("3229", 0f, 0, "Sounds/none", 1f, false));
root.Add("3230", new SoundData("3230", 0f, 0, "Sounds/none", 1f, false));
root.Add("3231", new SoundData("3231", 0f, 0, "Sounds/none", 1f, false));
root.Add("3232", new SoundData("3232", 0f, 0, "Sounds/none", 1f, false));
root.Add("3233", new SoundData("3233", 0f, 0, "Sounds/none", 1f, false));
root.Add("3234", new SoundData("3234", 0f, 0, "Sounds/none", 1f, false));
root.Add("3235", new SoundData("3235", 0f, 0, "Sounds/none", 1f, false));
root.Add("3236", new SoundData("3236", 0f, 0, "Sounds/none", 1f, false));
root.Add("3237", new SoundData("3237", 0f, 0, "Sounds/none", 1f, false));
root.Add("3238", new SoundData("3238", 0f, 0, "Sounds/none", 1f, false));
root.Add("3239", new SoundData("3239", 0f, 0, "Sounds/none", 1f, false));
root.Add("3240", new SoundData("3240", 0f, 0, "Sounds/none", 1f, false));
root.Add("3241", new SoundData("3241", 0f, 0, "Sounds/none", 1f, false));
root.Add("3242", new SoundData("3242", 0f, 0, "Sounds/none", 1f, false));
root.Add("3243", new SoundData("3243", 0f, 0, "Sounds/none", 1f, false));
root.Add("3244", new SoundData("3244", 0f, 0, "Sounds/none", 1f, false));
root.Add("3245", new SoundData("3245", 0f, 0, "Sounds/none", 1f, false));
}
public SoundData GetReadData(string ID){
if (root.ContainsKey(ID))
return root[ID];
else{
object obj = MMFramework.ModifyExcelModule.Instance.GetModifyedData(ID);
if (obj != null)return obj as SoundData;
Debug.LogError("在表格 SoundData中没有找到ID" + ID);
return null;}
}
public void WriteToFile(string path){}
public int GetCount(){
return root.Count;
}
public List<string> GetDataKeys(){
return new List<string>(root.Keys);
}
public Dictionary<string, string> GetReadDictionary(string key)
{Dictionary<string, string> pairs = new Dictionary<string, string>();
SoundData data = GetReadData(key);
Type type = data.GetType();
System.Reflection.FieldInfo[] filedinfos = type.GetFields();
for (int i = 0; i < filedinfos.Length; i++)
{System.Reflection.FieldInfo field = filedinfos[i];
pairs.Add(field.Name, field.GetValue(data).ToString());}
return pairs;}
}
public static SoundData GetData(string ID){
return SoundDataReader.Instance.GetReadData(ID);
}
public static Dictionary<string, string> GetDictionary(string key)
{ return SoundDataReader.Instance.GetReadDictionary(key);}
public static int GetNum(){
return SoundDataReader.Instance.GetCount();
}
public static List<string> GetKeys(){
return SoundDataReader.Instance.GetDataKeys();
}
public static void SaveToFile(string path){
SoundDataReader.Instance.WriteToFile(path);
}

}