using System;
using System.Collections.Generic;
using UnityEngine;
[Serializable]
public class FloorFightData{
/// <summary>
/// 序号
/// </summary>
public int Index;
/// <summary>
/// 关卡名
/// </summary>
public string StageName;
/// <summary>
/// 地图
/// </summary>
public int MapID;
/// <summary>
/// 怪物
/// </summary>
public int EnimyTag;
/// <summary>
/// 怪物等级
/// </summary>
public int EnimyLevelAdd;
/// <summary>
/// 怪物星级
/// </summary>
public int EnimyStarAdd;
/// <summary>
/// 每秒经验
/// </summary>
public int ExpSecond;
/// <summary>
/// 金币粒子贴图
/// </summary>
public string GoldParticalTexture;
/// <summary>
/// 突破掉落
/// </summary>
public int BreakDropID;
/// <summary>
/// 是否可以看广告双倍
/// </summary>
public bool AdDouble;
/// <summary>
/// 主题
/// </summary>
public int ThemeID;
/// <summary>
/// 【计算】每秒金币
/// </summary>
public string GoldSecond;
/// <summary>
/// 【显示】矿机每次掉金币数量
/// </summary>
public int ShowGoldOnetime;
/// <summary>
/// 【显示】地上金币上限
/// </summary>
public int ShowGroundMax;
/// <summary>
/// 【显示】充电后每次掉金币
/// </summary>
public int ShowCharging;
public FloorFightData(int Index, string StageName, int MapID, int EnimyTag, int EnimyLevelAdd, int EnimyStarAdd, int ExpSecond, string GoldParticalTexture, int BreakDropID, bool AdDouble, int ThemeID, string GoldSecond, int ShowGoldOnetime, int ShowGroundMax, int ShowCharging){
this.Index = Index;
this.StageName = StageName;
this.MapID = MapID;
this.EnimyTag = EnimyTag;
this.EnimyLevelAdd = EnimyLevelAdd;
this.EnimyStarAdd = EnimyStarAdd;
this.ExpSecond = ExpSecond;
this.GoldParticalTexture = GoldParticalTexture;
this.BreakDropID = BreakDropID;
this.AdDouble = AdDouble;
this.ThemeID = ThemeID;
this.GoldSecond = GoldSecond;
this.ShowGoldOnetime = ShowGoldOnetime;
this.ShowGroundMax = ShowGroundMax;
this.ShowCharging = ShowCharging;
}
class FloorFightDataReader{
static FloorFightDataReader instance;
static object syncRoot = new object();
public static FloorFightDataReader Instance{get{if (instance == null){lock (syncRoot){if (instance == null){instance = new FloorFightDataReader();instance.Load();}}}return instance;}}
Dictionary<int, FloorFightData> root = new Dictionary<int, FloorFightData>();
void Load(){
root.Add(1, new FloorFightData(1, "level_1", 45001, 37001, 1, 1, 1, "", 30301, false, 33001, "0", 0, 0, 0));
root.Add(2, new FloorFightData(2, "level_2", 45002, 37002, 2, 1, 1, "", 30302, true, 33001, "3", 1, 1000, 3));
root.Add(3, new FloorFightData(3, "level_3", 45003, 37003, 3, 1, 1, "", 30303, false, 33001, "10", 2, 2000, 6));
root.Add(4, new FloorFightData(4, "level_4", 45004, 37004, 4, 1, 1, "", 30304, true, 33001, "22", 3, 3000, 9));
root.Add(5, new FloorFightData(5, "level_5", 45005, 37005, 5, 1, 1, "", 30305, false, 33001, "43", 4, 4000, 12));
root.Add(6, new FloorFightData(6, "level_6", 45006, 37006, 6, 1, 1, "", 30306, false, 33001, "71", 5, 5000, 15));
root.Add(7, new FloorFightData(7, "level_7", 45007, 37007, 7, 1, 1, "", 30307, false, 33001, "114", 5, 6000, 15));
root.Add(8, new FloorFightData(8, "level_8", 45008, 37008, 8, 1, 1, "", 30308, false, 33001, "158", 5, 7000, 15));
root.Add(9, new FloorFightData(9, "level_9", 45009, 37009, 9, 1, 1, "", 30309, false, 33001, "213", 5, 8000, 15));
root.Add(10, new FloorFightData(10, "level_10", 45010, 37010, 10, 1, 1, "", 30310, false, 33001, "CEIL((19*x+3)+POW(1.5,x))", 6, 9000, 15));
root.Add(11, new FloorFightData(11, "level_11", 45011, 37010, 11, 1, 1, "", 30311, false, 33001, "CEIL((19*x+3)+POW(1.5,x))", 6, 10000, 15));
root.Add(12, new FloorFightData(12, "level_12", 45012, 37010, 12, 1, 1, "", 30312, false, 33001, "CEIL((19*x+3)+POW(1.5,x))", 6, 10000, 15));
root.Add(13, new FloorFightData(13, "level_13", 45013, 37010, 13, 1, 1, "", 30313, false, 33001, "CEIL((19*x+3)+POW(1.5,x))", 6, 10000, 15));
root.Add(14, new FloorFightData(14, "level_14", 45014, 37010, 14, 1, 1, "", 30314, false, 33002, "CEIL((19*x+3)+POW(1.5,x))", 6, 10000, 15));
root.Add(15, new FloorFightData(15, "level_15", 45015, 37010, 15, 1, 1, "", 30315, false, 33002, "CEIL((19*x+3)+POW(1.5,x))", 6, 10000, 15));
root.Add(16, new FloorFightData(16, "level_16", 45016, 37010, 16, 1, 1, "", 30316, false, 33002, "CEIL((19*x+3)+POW(1.5,x))", 6, 10000, 15));
root.Add(17, new FloorFightData(17, "level_17", 45017, 37010, 17, 1, 1, "", 30317, false, 33002, "CEIL((19*x+3)+POW(1.5,x))", 6, 10000, 15));
root.Add(18, new FloorFightData(18, "level_18", 45018, 37010, 18, 1, 1, "", 30318, false, 33002, "CEIL((19*x+3)+POW(1.5,x))", 6, 10000, 15));
root.Add(19, new FloorFightData(19, "level_19", 45019, 37010, 19, 1, 1, "", 30319, false, 33002, "CEIL((19*x+3)+POW(1.5,x))", 6, 10000, 15));
root.Add(20, new FloorFightData(20, "level_20", 45020, 37010, 20, 1, 1, "", 30320, false, 33002, "CEIL((19*x+3)+POW(1.5,x))", 6, 10000, 15));
root.Add(21, new FloorFightData(21, "level_21", 45021, 37010, 21, 1, 1, "", 30321, false, 33002, "CEIL((19*x+3)+POW(1.5,x))", 7, 10000, 15));
root.Add(22, new FloorFightData(22, "level_22", 45022, 37010, 22, 1, 1, "", 30322, false, 33002, "CEIL((19*x+3)+POW(1.5,x))", 7, 10000, 15));
root.Add(23, new FloorFightData(23, "level_23", 45023, 37010, 23, 1, 1, "", 30323, false, 33002, "CEIL((19*x+3)+POW(1.5,x))", 7, 10000, 15));
root.Add(24, new FloorFightData(24, "level_24", 45024, 37010, 24, 1, 1, "", 30324, false, 33002, "CEIL((19*x+3)+POW(1.5,x))", 7, 10000, 15));
root.Add(25, new FloorFightData(25, "level_25", 45025, 37010, 25, 1, 1, "", 30325, false, 33002, "CEIL((19*x+3)+POW(1.5,x))", 7, 10000, 15));
root.Add(26, new FloorFightData(26, "level_26", 45026, 37010, 26, 1, 1, "", 30326, false, 33002, "CEIL((19*x+3)+POW(1.5,x))", 7, 10000, 15));
root.Add(27, new FloorFightData(27, "level_27", 45027, 37010, 27, 1, 1, "", 30327, false, 33002, "CEIL((19*x+3)+POW(1.5,x))", 7, 10000, 15));
root.Add(28, new FloorFightData(28, "level_28", 45028, 37010, 28, 1, 1, "", 30328, false, 33003, "CEIL((19*x+3)+POW(1.5,x))", 7, 10000, 15));
root.Add(29, new FloorFightData(29, "level_29", 45029, 37011, 29, 1, 1, "", 30329, false, 33003, "CEIL((19*x+3)+POW(1.5,x))", 7, 10000, 15));
root.Add(30, new FloorFightData(30, "level_30", 45030, 37011, 30, 1, 1, "", 30330, false, 33003, "CEIL((19*x+3)+POW(1.5,x))", 7, 10000, 15));
root.Add(31, new FloorFightData(31, "level_31", 45031, 37011, 31, 1, 1, "", 30331, false, 33003, "CEIL((19*x+3)+POW(1.5,x))", 8, 10000, 15));
root.Add(32, new FloorFightData(32, "level_32", 45032, 37011, 32, 1, 1, "", 30332, false, 33003, "CEIL((19*x+3)+POW(1.5,x))", 8, 10000, 15));
root.Add(33, new FloorFightData(33, "level_33", 45033, 37011, 33, 1, 1, "", 30333, false, 33003, "CEIL((19*x+3)+POW(1.5,x))", 8, 10000, 15));
root.Add(34, new FloorFightData(34, "level_34", 45034, 37011, 34, 1, 1, "", 30334, false, 33003, "CEIL((19*x+3)+POW(1.5,x))", 8, 10000, 15));
root.Add(35, new FloorFightData(35, "level_35", 45035, 37011, 35, 1, 1, "", 30335, false, 33003, "CEIL((19*x+3)+POW(1.5,x))", 8, 10000, 15));
root.Add(36, new FloorFightData(36, "level_36", 45036, 37011, 36, 1, 1, "", 30336, false, 33003, "CEIL((19*x+3)+POW(1.5,x))", 8, 10000, 15));
root.Add(37, new FloorFightData(37, "level_37", 45037, 37011, 37, 1, 1, "", 30337, false, 33003, "CEIL((19*x+3)+POW(1.5,x))", 8, 10000, 15));
root.Add(38, new FloorFightData(38, "level_38", 45038, 37011, 38, 1, 1, "", 30338, false, 33003, "CEIL((19*x+3)+POW(1.5,x))", 8, 10000, 15));
root.Add(39, new FloorFightData(39, "level_39", 45039, 37011, 39, 1, 1, "", 30339, false, 33003, "CEIL((19*x+3)+POW(1.5,x))", 8, 10000, 15));
root.Add(40, new FloorFightData(40, "level_40", 45040, 37011, 40, 1, 1, "", 30340, false, 33003, "CEIL((19*x+3)+POW(1.5,x))", 8, 10000, 15));
root.Add(41, new FloorFightData(41, "level_41", 45041, 37011, 41, 1, 1, "", 30341, false, 33003, "CEIL((19*x+3)+POW(1.5,x))", 9, 10000, 15));
root.Add(42, new FloorFightData(42, "level_42", 45042, 37011, 42, 1, 1, "", 30342, false, 33003, "CEIL((19*x+3)+POW(1.5,x))", 9, 10000, 15));
root.Add(43, new FloorFightData(43, "level_43", 45043, 37011, 43, 1, 1, "", 30343, false, 33003, "CEIL((19*x+3)+POW(1.5,x))", 9, 10000, 15));
root.Add(44, new FloorFightData(44, "level_44", 45044, 37011, 44, 1, 1, "", 30344, false, 33003, "CEIL((19*x+3)+POW(1.5,x))", 9, 10000, 15));
root.Add(45, new FloorFightData(45, "level_45", 45045, 37011, 45, 1, 1, "", 30345, false, 33004, "CEIL((19*x+3)+POW(1.5,x))", 9, 10000, 15));
root.Add(46, new FloorFightData(46, "level_46", 45046, 37011, 46, 1, 1, "", 30346, false, 33004, "CEIL((19*x+3)+POW(1.5,x))", 9, 10000, 15));
root.Add(47, new FloorFightData(47, "level_47", 45047, 37011, 47, 1, 1, "", 30347, false, 33004, "CEIL((19*x+3)+POW(1.5,x))", 9, 10000, 15));
root.Add(48, new FloorFightData(48, "level_48", 45048, 37011, 48, 1, 1, "", 30348, false, 33004, "CEIL((19*x+3)+POW(1.5,x))", 9, 10000, 15));
root.Add(49, new FloorFightData(49, "level_49", 45049, 37011, 49, 1, 1, "", 30349, false, 33004, "CEIL((19*x+3)+POW(1.5,x))", 9, 10000, 15));
root.Add(50, new FloorFightData(50, "level_50", 45050, 37011, 50, 1, 1, "", 30350, false, 33004, "CEIL((19*x+3)+POW(1.5,x))", 9, 10000, 15));
root.Add(51, new FloorFightData(51, "level_51", 45051, 37011, 51, 1, 1, "", 30351, false, 33004, "CEIL((19*x+3)+POW(1.5,x))", 9, 10000, 15));
root.Add(52, new FloorFightData(52, "level_52", 45052, 37011, 52, 1, 1, "", 30352, false, 33004, "CEIL((19*x+3)+POW(1.5,x))", 9, 10000, 15));
root.Add(53, new FloorFightData(53, "level_53", 45053, 37011, 53, 1, 1, "", 30353, false, 33004, "CEIL((19*x+3)+POW(1.5,x))", 9, 10000, 15));
root.Add(54, new FloorFightData(54, "level_54", 45054, 37011, 54, 1, 1, "", 30354, false, 33004, "CEIL((19*x+3)+POW(1.5,x))", 9, 10000, 15));
root.Add(55, new FloorFightData(55, "level_55", 45055, 37011, 55, 1, 1, "", 30355, false, 33004, "CEIL((19*x+3)+POW(1.5,x))", 9, 10000, 15));
root.Add(56, new FloorFightData(56, "level_56", 45056, 37011, 56, 1, 1, "", 30356, false, 33004, "CEIL((19*x+3)+POW(1.5,x))", 9, 10000, 15));
root.Add(57, new FloorFightData(57, "level_57", 45057, 37011, 57, 1, 1, "", 30357, false, 33004, "CEIL((19*x+3)+POW(1.5,x))", 9, 10000, 15));
root.Add(58, new FloorFightData(58, "level_58", 45058, 37011, 58, 1, 1, "", 30358, false, 33004, "CEIL((19*x+3)+POW(1.5,x))", 9, 10000, 15));
root.Add(59, new FloorFightData(59, "level_59", 45059, 37011, 59, 1, 1, "", 30359, false, 33004, "CEIL((19*x+3)+POW(1.5,x))", 9, 10000, 15));
root.Add(60, new FloorFightData(60, "level_60", 45060, 37011, 60, 1, 1, "", 30360, false, 33004, "CEIL((19*x+3)+POW(1.5,x))", 9, 10000, 15));
root.Add(61, new FloorFightData(61, "level_61", 45061, 37011, 61, 1, 1, "", 30361, false, 33004, "CEIL((19*x+3)+POW(1.5,x))", 9, 10000, 15));
root.Add(62, new FloorFightData(62, "level_62", 45062, 37011, 62, 1, 1, "", 30362, false, 33004, "CEIL((19*x+3)+POW(1.5,x))", 9, 10000, 15));
root.Add(63, new FloorFightData(63, "level_63", 45063, 37011, 63, 1, 1, "", 30363, false, 33004, "CEIL((19*x+3)+POW(1.5,x))", 9, 10000, 15));
root.Add(64, new FloorFightData(64, "level_64", 45064, 37011, 64, 1, 1, "", 30364, false, 33004, "CEIL((19*x+3)+POW(1.5,x))", 9, 10000, 15));
root.Add(65, new FloorFightData(65, "level_65", 45065, 37011, 65, 1, 1, "", 30365, false, 33004, "CEIL((19*x+3)+POW(1.5,x))", 9, 10000, 15));
root.Add(66, new FloorFightData(66, "level_66", 45066, 37011, 66, 1, 1, "", 30366, false, 33004, "CEIL((19*x+3)+POW(1.5,x))", 9, 10000, 15));
root.Add(67, new FloorFightData(67, "level_67", 45067, 37011, 67, 1, 1, "", 30367, false, 33004, "CEIL((19*x+3)+POW(1.5,x))", 9, 10000, 15));
root.Add(68, new FloorFightData(68, "level_68", 45068, 37011, 68, 1, 1, "", 30368, false, 33004, "CEIL((19*x+3)+POW(1.5,x))", 9, 10000, 15));
root.Add(69, new FloorFightData(69, "level_69", 45069, 37011, 69, 1, 1, "", 30369, false, 33004, "CEIL((19*x+3)+POW(1.5,x))", 9, 10000, 15));
root.Add(70, new FloorFightData(70, "level_70", 45070, 37011, 70, 1, 1, "", 30370, false, 33005, "CEIL((19*x+3)+POW(1.5,x))", 9, 10000, 15));
root.Add(71, new FloorFightData(71, "level_71", 45071, 37011, 71, 1, 1, "", 30371, false, 33005, "CEIL((19*x+3)+POW(1.5,x))", 9, 10000, 15));
root.Add(72, new FloorFightData(72, "level_72", 45072, 37011, 72, 1, 1, "", 30372, false, 33005, "CEIL((19*x+3)+POW(1.5,x))", 9, 10000, 15));
root.Add(73, new FloorFightData(73, "level_73", 45073, 37011, 73, 1, 1, "", 30373, false, 33005, "CEIL((19*x+3)+POW(1.5,x))", 9, 10000, 15));
root.Add(74, new FloorFightData(74, "level_74", 45074, 37011, 74, 1, 1, "", 30374, false, 33005, "CEIL((19*x+3)+POW(1.5,x))", 9, 10000, 15));
root.Add(75, new FloorFightData(75, "level_75", 45075, 37011, 75, 1, 1, "", 30375, false, 33005, "CEIL((19*x+3)+POW(1.5,x))", 9, 10000, 15));
root.Add(76, new FloorFightData(76, "level_76", 45076, 37011, 76, 1, 1, "", 30376, false, 33005, "CEIL((19*x+3)+POW(1.5,x))", 9, 10000, 15));
root.Add(77, new FloorFightData(77, "level_77", 45077, 37011, 77, 1, 1, "", 30377, false, 33005, "CEIL((19*x+3)+POW(1.5,x))", 9, 10000, 15));
root.Add(78, new FloorFightData(78, "level_78", 45078, 37011, 78, 1, 1, "", 30378, false, 33005, "CEIL((19*x+3)+POW(1.5,x))", 9, 10000, 15));
root.Add(79, new FloorFightData(79, "level_79", 45079, 37011, 79, 1, 1, "", 30379, false, 33005, "CEIL((19*x+3)+POW(1.5,x))", 9, 10000, 15));
root.Add(80, new FloorFightData(80, "level_80", 45080, 37011, 80, 1, 1, "", 30380, false, 33005, "CEIL((19*x+3)+POW(1.5,x))", 9, 10000, 15));
root.Add(81, new FloorFightData(81, "level_81", 45081, 37011, 81, 1, 1, "", 30381, false, 33005, "CEIL((19*x+3)+POW(1.5,x))", 9, 10000, 15));
root.Add(82, new FloorFightData(82, "level_82", 45082, 37011, 82, 1, 1, "", 30382, false, 33005, "CEIL((19*x+3)+POW(1.5,x))", 9, 10000, 15));
root.Add(83, new FloorFightData(83, "level_83", 45083, 37011, 83, 1, 1, "", 30383, false, 33005, "CEIL((19*x+3)+POW(1.5,x))", 9, 10000, 15));
root.Add(84, new FloorFightData(84, "level_84", 45084, 37011, 84, 1, 1, "", 30384, false, 33005, "CEIL((19*x+3)+POW(1.5,x))", 9, 10000, 15));
root.Add(85, new FloorFightData(85, "level_85", 45085, 37011, 85, 1, 1, "", 30385, false, 33005, "CEIL((19*x+3)+POW(1.5,x))", 9, 10000, 15));
root.Add(86, new FloorFightData(86, "level_86", 45086, 37011, 86, 1, 1, "", 30386, false, 33005, "CEIL((19*x+3)+POW(1.5,x))", 9, 10000, 15));
root.Add(87, new FloorFightData(87, "level_87", 45087, 37011, 87, 1, 1, "", 30387, false, 33005, "CEIL((19*x+3)+POW(1.5,x))", 9, 10000, 15));
root.Add(88, new FloorFightData(88, "level_88", 45088, 37011, 88, 1, 1, "", 30388, false, 33005, "CEIL((19*x+3)+POW(1.5,x))", 9, 10000, 15));
root.Add(89, new FloorFightData(89, "level_89", 45089, 37011, 89, 1, 1, "", 30389, false, 33005, "CEIL((19*x+3)+POW(1.5,x))", 9, 10000, 15));
root.Add(90, new FloorFightData(90, "level_90", 45090, 37011, 90, 1, 1, "", 30390, false, 33005, "CEIL((19*x+3)+POW(1.5,x))", 9, 10000, 15));
root.Add(91, new FloorFightData(91, "level_91", 45091, 37011, 91, 1, 1, "", 30391, false, 33005, "CEIL((19*x+3)+POW(1.5,x))", 9, 10000, 15));
root.Add(92, new FloorFightData(92, "level_92", 45092, 37011, 92, 1, 1, "", 30392, false, 33005, "CEIL((19*x+3)+POW(1.5,x))", 9, 10000, 15));
root.Add(93, new FloorFightData(93, "level_93", 45093, 37011, 93, 1, 1, "", 30393, false, 33005, "CEIL((19*x+3)+POW(1.5,x))", 9, 10000, 15));
root.Add(94, new FloorFightData(94, "level_94", 45094, 37011, 94, 1, 1, "", 30394, false, 33005, "CEIL((19*x+3)+POW(1.5,x))", 9, 10000, 15));
root.Add(95, new FloorFightData(95, "level_95", 45095, 37011, 95, 1, 1, "", 30395, false, 33005, "CEIL((19*x+3)+POW(1.5,x))", 9, 10000, 15));
root.Add(96, new FloorFightData(96, "level_96", 45096, 37011, 96, 1, 1, "", 30396, false, 33005, "CEIL((19*x+3)+POW(1.5,x))", 9, 10000, 15));
root.Add(97, new FloorFightData(97, "level_97", 45097, 37011, 97, 1, 1, "", 30397, false, 33005, "CEIL((19*x+3)+POW(1.5,x))", 9, 10000, 15));
root.Add(98, new FloorFightData(98, "level_98", 45098, 37011, 98, 1, 1, "", 30398, false, 33001, "CEIL((19*x+3)+POW(1.5,x))", 9, 10000, 15));
root.Add(99, new FloorFightData(99, "level_99", 45099, 37011, 99, 1, 1, "", 30399, false, 33001, "CEIL((19*x+3)+POW(1.5,x))", 9, 10000, 15));
root.Add(100, new FloorFightData(100, "level_100", 45100, 37011, 100, 1, 1, "", 30400, false, 33001, "CEIL((19*x+3)+POW(1.5,x))", 9, 10000, 15));
root.Add(101, new FloorFightData(101, "level_101", 45101, 37011, 101, 1, 1, "", 30401, false, 33001, "CEIL((19*x+3)+POW(1.5,x))", 9, 10000, 15));
root.Add(102, new FloorFightData(102, "level_102", 45102, 37011, 102, 1, 1, "", 30402, false, 33001, "CEIL((19*x+3)+POW(1.5,x))", 9, 10000, 15));
root.Add(103, new FloorFightData(103, "level_103", 45103, 37011, 103, 1, 1, "", 30403, false, 33001, "CEIL((19*x+3)+POW(1.5,x))", 9, 10000, 15));
root.Add(104, new FloorFightData(104, "level_104", 45104, 37011, 104, 1, 1, "", 30404, false, 33001, "CEIL((19*x+3)+POW(1.5,x))", 9, 10000, 15));
root.Add(105, new FloorFightData(105, "level_105", 45105, 37011, 105, 1, 1, "", 30405, false, 33001, "CEIL((19*x+3)+POW(1.5,x))", 9, 10000, 15));
root.Add(106, new FloorFightData(106, "level_106", 45106, 37011, 106, 1, 1, "", 30406, false, 33001, "CEIL((19*x+3)+POW(1.5,x))", 9, 10000, 15));
root.Add(107, new FloorFightData(107, "level_107", 45107, 37011, 107, 1, 1, "", 30407, false, 33001, "CEIL((19*x+3)+POW(1.5,x))", 9, 10000, 15));
root.Add(108, new FloorFightData(108, "level_108", 45108, 37011, 108, 1, 1, "", 30408, false, 33001, "CEIL((19*x+3)+POW(1.5,x))", 9, 10000, 15));
root.Add(109, new FloorFightData(109, "level_109", 45109, 37011, 109, 1, 1, "", 30409, false, 33001, "CEIL((19*x+3)+POW(1.5,x))", 9, 10000, 15));
root.Add(110, new FloorFightData(110, "level_110", 45110, 37011, 110, 1, 1, "", 30410, false, 33001, "CEIL((19*x+3)+POW(1.5,x))", 9, 10000, 15));
root.Add(111, new FloorFightData(111, "level_111", 45111, 37011, 111, 1, 1, "", 30411, false, 33001, "CEIL((19*x+3)+POW(1.5,x))", 9, 10000, 15));
root.Add(112, new FloorFightData(112, "level_112", 45112, 37011, 112, 1, 1, "", 30412, false, 33001, "CEIL((19*x+3)+POW(1.5,x))", 9, 10000, 15));
root.Add(113, new FloorFightData(113, "level_113", 45113, 37011, 113, 1, 1, "", 30413, false, 33001, "CEIL((19*x+3)+POW(1.5,x))", 9, 10000, 15));
root.Add(114, new FloorFightData(114, "level_114", 45114, 37011, 114, 1, 1, "", 30414, false, 33001, "CEIL((19*x+3)+POW(1.5,x))", 9, 10000, 15));
root.Add(115, new FloorFightData(115, "level_115", 45115, 37011, 115, 1, 1, "", 30415, false, 33001, "CEIL((19*x+3)+POW(1.5,x))", 9, 10000, 15));
root.Add(116, new FloorFightData(116, "level_116", 45116, 37011, 116, 1, 1, "", 30416, false, 33001, "CEIL((19*x+3)+POW(1.5,x))", 9, 10000, 15));
root.Add(117, new FloorFightData(117, "level_117", 45117, 37011, 117, 1, 1, "", 30417, false, 33001, "CEIL((19*x+3)+POW(1.5,x))", 9, 10000, 15));
root.Add(118, new FloorFightData(118, "level_118", 45118, 37011, 118, 1, 1, "", 30418, false, 33001, "CEIL((19*x+3)+POW(1.5,x))", 9, 10000, 15));
root.Add(119, new FloorFightData(119, "level_119", 45119, 37011, 119, 1, 1, "", 30419, false, 33001, "CEIL((19*x+3)+POW(1.5,x))", 9, 10000, 15));
root.Add(120, new FloorFightData(120, "level_120", 45120, 37011, 120, 1, 1, "", 30420, false, 33001, "CEIL((19*x+3)+POW(1.5,x))", 9, 10000, 15));
root.Add(121, new FloorFightData(121, "level_121", 45121, 37011, 121, 1, 1, "", 30421, false, 33001, "CEIL((19*x+3)+POW(1.5,x))", 9, 10000, 15));
root.Add(122, new FloorFightData(122, "level_122", 45122, 37011, 122, 1, 1, "", 30422, false, 33001, "CEIL((19*x+3)+POW(1.5,x))", 9, 10000, 15));
root.Add(123, new FloorFightData(123, "level_123", 45123, 37011, 123, 1, 1, "", 30423, false, 33001, "CEIL((19*x+3)+POW(1.5,x))", 9, 10000, 15));
root.Add(124, new FloorFightData(124, "level_124", 45124, 37011, 124, 1, 1, "", 30424, false, 33001, "CEIL((19*x+3)+POW(1.5,x))", 9, 10000, 15));
root.Add(125, new FloorFightData(125, "level_125", 45125, 37011, 125, 1, 1, "", 30425, false, 33001, "CEIL((19*x+3)+POW(1.5,x))", 9, 10000, 15));
root.Add(126, new FloorFightData(126, "level_126", 45126, 37011, 126, 1, 1, "", 30426, false, 33001, "CEIL((19*x+3)+POW(1.5,x))", 9, 10000, 15));
root.Add(127, new FloorFightData(127, "level_127", 45127, 37011, 127, 1, 1, "", 30427, false, 33001, "CEIL((19*x+3)+POW(1.5,x))", 9, 10000, 15));
root.Add(128, new FloorFightData(128, "level_128", 45128, 37011, 128, 1, 1, "", 30428, false, 33001, "CEIL((19*x+3)+POW(1.5,x))", 9, 10000, 15));
root.Add(129, new FloorFightData(129, "level_129", 45129, 37011, 129, 1, 1, "", 30429, false, 33001, "CEIL((19*x+3)+POW(1.5,x))", 9, 10000, 15));
root.Add(130, new FloorFightData(130, "level_130", 45130, 37011, 130, 1, 1, "", 30430, false, 33001, "CEIL((19*x+3)+POW(1.5,x))", 9, 10000, 15));
root.Add(131, new FloorFightData(131, "level_131", 45131, 37011, 131, 1, 1, "", 30431, false, 33001, "CEIL((19*x+3)+POW(1.5,x))", 9, 10000, 15));
root.Add(132, new FloorFightData(132, "level_132", 45132, 37011, 132, 1, 1, "", 30432, false, 33001, "CEIL((19*x+3)+POW(1.5,x))", 9, 10000, 15));
root.Add(133, new FloorFightData(133, "level_133", 45133, 37011, 133, 1, 1, "", 30433, false, 33001, "CEIL((19*x+3)+POW(1.5,x))", 9, 10000, 15));
root.Add(134, new FloorFightData(134, "level_134", 45134, 37011, 134, 1, 1, "", 30434, false, 33001, "CEIL((19*x+3)+POW(1.5,x))", 9, 10000, 15));
root.Add(135, new FloorFightData(135, "level_135", 45135, 37011, 135, 1, 1, "", 30435, false, 33001, "CEIL((19*x+3)+POW(1.5,x))", 9, 10000, 15));
root.Add(136, new FloorFightData(136, "level_136", 45136, 37011, 136, 1, 1, "", 30436, false, 33001, "CEIL((19*x+3)+POW(1.5,x))", 9, 10000, 15));
root.Add(137, new FloorFightData(137, "level_137", 45137, 37011, 137, 1, 1, "", 30437, false, 33001, "CEIL((19*x+3)+POW(1.5,x))", 9, 10000, 15));
root.Add(138, new FloorFightData(138, "level_138", 45138, 37011, 138, 1, 1, "", 30438, false, 33001, "CEIL((19*x+3)+POW(1.5,x))", 9, 10000, 15));
root.Add(139, new FloorFightData(139, "level_139", 45139, 37011, 139, 1, 1, "", 30439, false, 33001, "CEIL((19*x+3)+POW(1.5,x))", 9, 10000, 15));
root.Add(140, new FloorFightData(140, "level_140", 45140, 37011, 140, 1, 1, "", 30440, false, 33001, "CEIL((19*x+3)+POW(1.5,x))", 9, 10000, 15));
root.Add(141, new FloorFightData(141, "level_141", 45141, 37011, 141, 1, 1, "", 30441, false, 33001, "CEIL((19*x+3)+POW(1.5,x))", 9, 10000, 15));
root.Add(142, new FloorFightData(142, "level_142", 45142, 37011, 142, 1, 1, "", 30442, false, 33001, "CEIL((19*x+3)+POW(1.5,x))", 9, 10000, 15));
root.Add(143, new FloorFightData(143, "level_143", 45143, 37011, 143, 1, 1, "", 30443, false, 33001, "CEIL((19*x+3)+POW(1.5,x))", 9, 10000, 15));
root.Add(144, new FloorFightData(144, "level_144", 45144, 37011, 144, 1, 1, "", 30444, false, 33001, "CEIL((19*x+3)+POW(1.5,x))", 9, 10000, 15));
root.Add(145, new FloorFightData(145, "level_145", 45145, 37011, 145, 1, 1, "", 30445, false, 33001, "CEIL((19*x+3)+POW(1.5,x))", 9, 10000, 15));
root.Add(146, new FloorFightData(146, "level_146", 45146, 37011, 146, 1, 1, "", 30446, false, 33001, "CEIL((19*x+3)+POW(1.5,x))", 9, 10000, 15));
root.Add(147, new FloorFightData(147, "level_147", 45147, 37011, 147, 1, 1, "", 30447, false, 33001, "CEIL((19*x+3)+POW(1.5,x))", 9, 10000, 15));
root.Add(148, new FloorFightData(148, "level_148", 45148, 37011, 148, 1, 1, "", 30448, false, 33001, "CEIL((19*x+3)+POW(1.5,x))", 9, 10000, 15));
root.Add(149, new FloorFightData(149, "level_149", 45149, 37011, 149, 1, 1, "", 30449, false, 33001, "CEIL((19*x+3)+POW(1.5,x))", 9, 10000, 15));
root.Add(150, new FloorFightData(150, "level_150", 45150, 37011, 150, 1, 1, "", 30450, false, 33001, "CEIL((19*x+3)+POW(1.5,x))", 9, 10000, 15));
root.Add(151, new FloorFightData(151, "level_151", 45151, 37011, 151, 1, 1, "", 30451, false, 33001, "CEIL((19*x+3)+POW(1.5,x))", 9, 10000, 15));
root.Add(152, new FloorFightData(152, "level_152", 45152, 37011, 152, 1, 1, "", 30452, false, 33001, "CEIL((19*x+3)+POW(1.5,x))", 9, 10000, 15));
root.Add(153, new FloorFightData(153, "level_153", 45153, 37011, 153, 1, 1, "", 30453, false, 33001, "CEIL((19*x+3)+POW(1.5,x))", 9, 10000, 15));
root.Add(154, new FloorFightData(154, "level_154", 45154, 37011, 154, 1, 1, "", 30454, false, 33001, "CEIL((19*x+3)+POW(1.5,x))", 9, 10000, 15));
root.Add(155, new FloorFightData(155, "level_155", 45155, 37011, 155, 1, 1, "", 30455, false, 33001, "CEIL((19*x+3)+POW(1.5,x))", 9, 10000, 15));
root.Add(156, new FloorFightData(156, "level_156", 45156, 37011, 156, 1, 1, "", 30456, false, 33001, "CEIL((19*x+3)+POW(1.5,x))", 9, 10000, 15));
root.Add(157, new FloorFightData(157, "level_157", 45157, 37011, 157, 1, 1, "", 30457, false, 33001, "CEIL((19*x+3)+POW(1.5,x))", 9, 10000, 15));
root.Add(158, new FloorFightData(158, "level_158", 45158, 37011, 158, 1, 1, "", 30458, false, 33001, "CEIL((19*x+3)+POW(1.5,x))", 9, 10000, 15));
root.Add(159, new FloorFightData(159, "level_159", 45159, 37011, 159, 1, 1, "", 30459, false, 33001, "CEIL((19*x+3)+POW(1.5,x))", 9, 10000, 15));
root.Add(160, new FloorFightData(160, "level_160", 45160, 37011, 160, 1, 1, "", 30460, false, 33001, "CEIL((19*x+3)+POW(1.5,x))", 9, 10000, 15));
root.Add(161, new FloorFightData(161, "level_161", 45161, 37011, 161, 1, 1, "", 30461, false, 33001, "CEIL((19*x+3)+POW(1.5,x))", 9, 10000, 15));
root.Add(162, new FloorFightData(162, "level_162", 45162, 37011, 162, 1, 1, "", 30462, false, 33001, "CEIL((19*x+3)+POW(1.5,x))", 9, 10000, 15));
root.Add(163, new FloorFightData(163, "level_163", 45163, 37011, 163, 1, 1, "", 30463, false, 33001, "CEIL((19*x+3)+POW(1.5,x))", 9, 10000, 15));
root.Add(164, new FloorFightData(164, "level_164", 45164, 37011, 164, 1, 1, "", 30464, false, 33001, "CEIL((19*x+3)+POW(1.5,x))", 9, 10000, 15));
root.Add(165, new FloorFightData(165, "level_165", 45165, 37011, 165, 1, 1, "", 30465, false, 33001, "CEIL((19*x+3)+POW(1.5,x))", 9, 10000, 15));
root.Add(166, new FloorFightData(166, "level_166", 45166, 37011, 166, 1, 1, "", 30466, false, 33001, "CEIL((19*x+3)+POW(1.5,x))", 9, 10000, 15));
root.Add(167, new FloorFightData(167, "level_167", 45167, 37011, 167, 1, 1, "", 30467, false, 33001, "CEIL((19*x+3)+POW(1.5,x))", 9, 10000, 15));
root.Add(168, new FloorFightData(168, "level_168", 45168, 37011, 168, 1, 1, "", 30468, false, 33001, "CEIL((19*x+3)+POW(1.5,x))", 9, 10000, 15));
root.Add(169, new FloorFightData(169, "level_169", 45169, 37011, 169, 1, 1, "", 30469, false, 33001, "CEIL((19*x+3)+POW(1.5,x))", 9, 10000, 15));
root.Add(170, new FloorFightData(170, "level_170", 45170, 37011, 170, 1, 1, "", 30470, false, 33001, "CEIL((19*x+3)+POW(1.5,x))", 9, 10000, 15));
root.Add(171, new FloorFightData(171, "level_171", 45171, 37011, 171, 1, 1, "", 30471, false, 33001, "CEIL((19*x+3)+POW(1.5,x))", 9, 10000, 15));
root.Add(172, new FloorFightData(172, "level_172", 45172, 37011, 172, 1, 1, "", 30472, false, 33001, "CEIL((19*x+3)+POW(1.5,x))", 9, 10000, 15));
root.Add(173, new FloorFightData(173, "level_173", 45173, 37011, 173, 1, 1, "", 30473, false, 33001, "CEIL((19*x+3)+POW(1.5,x))", 9, 10000, 15));
root.Add(174, new FloorFightData(174, "level_174", 45174, 37011, 174, 1, 1, "", 30474, false, 33001, "CEIL((19*x+3)+POW(1.5,x))", 9, 10000, 15));
root.Add(175, new FloorFightData(175, "level_175", 45175, 37011, 175, 1, 1, "", 30475, false, 33001, "CEIL((19*x+3)+POW(1.5,x))", 9, 10000, 15));
root.Add(176, new FloorFightData(176, "level_176", 45176, 37011, 176, 1, 1, "", 30476, false, 33001, "CEIL((19*x+3)+POW(1.5,x))", 9, 10000, 15));
root.Add(177, new FloorFightData(177, "level_177", 45177, 37011, 177, 1, 1, "", 30477, false, 33001, "CEIL((19*x+3)+POW(1.5,x))", 9, 10000, 15));
root.Add(178, new FloorFightData(178, "level_178", 45178, 37011, 178, 1, 1, "", 30478, false, 33001, "CEIL((19*x+3)+POW(1.5,x))", 9, 10000, 15));
root.Add(179, new FloorFightData(179, "level_179", 45179, 37011, 179, 1, 1, "", 30479, false, 33001, "CEIL((19*x+3)+POW(1.5,x))", 9, 10000, 15));
root.Add(180, new FloorFightData(180, "level_180", 45180, 37011, 180, 1, 1, "", 30480, false, 33001, "CEIL((19*x+3)+POW(1.5,x))", 9, 10000, 15));
root.Add(181, new FloorFightData(181, "level_181", 45181, 37011, 181, 1, 1, "", 30481, false, 33001, "CEIL((19*x+3)+POW(1.5,x))", 9, 10000, 15));
root.Add(182, new FloorFightData(182, "level_182", 45182, 37011, 182, 1, 1, "", 30482, false, 33001, "CEIL((19*x+3)+POW(1.5,x))", 9, 10000, 15));
root.Add(183, new FloorFightData(183, "level_183", 45183, 37001, 183, 1, 1, "", 30483, false, 33001, "CEIL((19*x+3)+POW(1.5,x))", 9, 10000, 15));
root.Add(184, new FloorFightData(184, "level_184", 45184, 37001, 184, 1, 1, "", 30484, false, 33001, "CEIL((19*x+3)+POW(1.5,x))", 9, 10000, 15));
root.Add(185, new FloorFightData(185, "level_185", 45185, 37001, 185, 1, 1, "", 30485, false, 33001, "CEIL((19*x+3)+POW(1.5,x))", 9, 10000, 15));
root.Add(186, new FloorFightData(186, "level_186", 45186, 37001, 186, 1, 1, "", 30486, false, 33001, "CEIL((19*x+3)+POW(1.5,x))", 9, 10000, 15));
root.Add(187, new FloorFightData(187, "level_187", 45187, 37001, 187, 1, 1, "", 30487, false, 33001, "CEIL((19*x+3)+POW(1.5,x))", 9, 10000, 15));
root.Add(188, new FloorFightData(188, "level_188", 45188, 37001, 188, 1, 1, "", 30488, false, 33001, "CEIL((19*x+3)+POW(1.5,x))", 9, 10000, 15));
root.Add(189, new FloorFightData(189, "level_189", 45189, 37001, 189, 1, 1, "", 30489, false, 33001, "CEIL((19*x+3)+POW(1.5,x))", 9, 10000, 15));
root.Add(190, new FloorFightData(190, "level_190", 45190, 37001, 190, 1, 1, "", 30490, false, 33001, "CEIL((19*x+3)+POW(1.5,x))", 9, 10000, 15));
root.Add(191, new FloorFightData(191, "level_191", 45191, 37001, 191, 1, 1, "", 30491, false, 33001, "CEIL((19*x+3)+POW(1.5,x))", 9, 10000, 15));
root.Add(192, new FloorFightData(192, "level_192", 45192, 37001, 192, 1, 1, "", 30492, false, 33001, "CEIL((19*x+3)+POW(1.5,x))", 9, 10000, 15));
root.Add(193, new FloorFightData(193, "level_193", 45193, 37001, 193, 1, 1, "", 30493, false, 33001, "CEIL((19*x+3)+POW(1.5,x))", 9, 10000, 15));
root.Add(194, new FloorFightData(194, "level_194", 45194, 37001, 194, 1, 1, "", 30494, false, 33001, "CEIL((19*x+3)+POW(1.5,x))", 9, 10000, 15));
root.Add(195, new FloorFightData(195, "", 0, 0, 195, 1, 1, "", 30495, false, 33001, "CEIL((19*x+3)+POW(1.5,x))", 9, 10000, 15));
root.Add(196, new FloorFightData(196, "", 0, 0, 196, 1, 1, "", 30496, false, 33001, "CEIL((19*x+3)+POW(1.5,x))", 9, 10000, 15));
root.Add(197, new FloorFightData(197, "", 0, 0, 197, 1, 1, "", 30497, false, 33001, "CEIL((19*x+3)+POW(1.5,x))", 9, 10000, 15));
root.Add(198, new FloorFightData(198, "", 0, 0, 198, 1, 1, "", 30498, false, 33001, "CEIL((19*x+3)+POW(1.5,x))", 9, 10000, 15));
root.Add(199, new FloorFightData(199, "", 0, 0, 199, 1, 1, "", 30499, false, 33001, "CEIL((19*x+3)+POW(1.5,x))", 9, 10000, 15));
root.Add(200, new FloorFightData(200, "", 0, 0, 200, 1, 1, "", 30500, false, 33001, "CEIL((19*x+3)+POW(1.5,x))", 9, 10000, 15));
root.Add(201, new FloorFightData(201, "", 0, 0, 201, 1, 1, "", 30501, false, 33001, "CEIL((19*x+3)+POW(1.5,x))", 9, 10000, 15));
root.Add(202, new FloorFightData(202, "", 0, 0, 202, 1, 1, "", 30502, false, 33001, "CEIL((19*x+3)+POW(1.5,x))", 9, 10000, 15));
root.Add(203, new FloorFightData(203, "", 0, 0, 203, 1, 1, "", 30503, false, 33001, "CEIL((19*x+3)+POW(1.5,x))", 9, 10000, 15));
root.Add(204, new FloorFightData(204, "", 0, 0, 204, 1, 1, "", 30504, false, 33001, "CEIL((19*x+3)+POW(1.5,x))", 9, 10000, 15));
root.Add(205, new FloorFightData(205, "", 0, 0, 205, 1, 1, "", 30505, false, 33001, "CEIL((19*x+3)+POW(1.5,x))", 9, 10000, 15));
root.Add(206, new FloorFightData(206, "", 0, 0, 206, 1, 1, "", 30506, false, 33001, "CEIL((19*x+3)+POW(1.5,x))", 9, 10000, 15));
root.Add(207, new FloorFightData(207, "", 0, 0, 207, 1, 1, "", 30507, false, 33001, "CEIL((19*x+3)+POW(1.5,x))", 9, 10000, 15));
root.Add(208, new FloorFightData(208, "", 0, 0, 208, 1, 1, "", 30508, false, 33001, "CEIL((19*x+3)+POW(1.5,x))", 9, 10000, 15));
root.Add(209, new FloorFightData(209, "", 0, 0, 209, 1, 1, "", 30509, false, 33001, "CEIL((19*x+3)+POW(1.5,x))", 9, 10000, 15));
root.Add(210, new FloorFightData(210, "", 0, 0, 210, 1, 1, "", 30510, false, 33001, "CEIL((19*x+3)+POW(1.5,x))", 9, 10000, 15));
root.Add(211, new FloorFightData(211, "", 0, 0, 211, 1, 1, "", 30511, false, 33001, "CEIL((19*x+3)+POW(1.5,x))", 9, 10000, 15));
root.Add(212, new FloorFightData(212, "", 0, 0, 212, 1, 1, "", 30512, false, 33001, "CEIL((19*x+3)+POW(1.5,x))", 9, 10000, 15));
root.Add(213, new FloorFightData(213, "", 0, 0, 213, 1, 1, "", 30513, false, 33001, "CEIL((19*x+3)+POW(1.5,x))", 9, 10000, 15));
root.Add(214, new FloorFightData(214, "", 0, 0, 214, 1, 1, "", 30514, false, 33001, "CEIL((19*x+3)+POW(1.5,x))", 9, 10000, 15));
root.Add(215, new FloorFightData(215, "", 0, 0, 215, 1, 1, "", 30515, false, 33001, "CEIL((19*x+3)+POW(1.5,x))", 9, 10000, 15));
root.Add(216, new FloorFightData(216, "", 0, 0, 216, 1, 1, "", 30516, false, 33001, "CEIL((19*x+3)+POW(1.5,x))", 9, 10000, 15));
root.Add(217, new FloorFightData(217, "", 0, 0, 217, 1, 1, "", 30517, false, 33001, "CEIL((19*x+3)+POW(1.5,x))", 9, 10000, 15));
root.Add(218, new FloorFightData(218, "", 0, 0, 218, 1, 1, "", 30518, false, 33001, "CEIL((19*x+3)+POW(1.5,x))", 9, 10000, 15));
root.Add(219, new FloorFightData(219, "", 0, 0, 219, 1, 1, "", 30519, false, 33001, "CEIL((19*x+3)+POW(1.5,x))", 9, 10000, 15));
root.Add(220, new FloorFightData(220, "", 0, 0, 220, 1, 1, "", 30520, false, 33001, "CEIL((19*x+3)+POW(1.5,x))", 9, 10000, 15));
root.Add(221, new FloorFightData(221, "", 0, 0, 221, 1, 1, "", 30521, false, 33001, "CEIL((19*x+3)+POW(1.5,x))", 9, 10000, 15));
root.Add(222, new FloorFightData(222, "", 0, 0, 222, 1, 1, "", 30522, false, 33001, "CEIL((19*x+3)+POW(1.5,x))", 9, 10000, 15));
root.Add(223, new FloorFightData(223, "", 0, 0, 223, 1, 1, "", 30523, false, 33001, "CEIL((19*x+3)+POW(1.5,x))", 9, 10000, 15));
root.Add(224, new FloorFightData(224, "", 0, 0, 224, 1, 1, "", 30524, false, 33001, "CEIL((19*x+3)+POW(1.5,x))", 9, 10000, 15));
root.Add(225, new FloorFightData(225, "", 0, 0, 225, 1, 1, "", 30525, false, 33001, "CEIL((19*x+3)+POW(1.5,x))", 9, 10000, 15));
root.Add(226, new FloorFightData(226, "", 0, 0, 226, 1, 1, "", 30526, false, 33001, "CEIL((19*x+3)+POW(1.5,x))", 9, 10000, 15));
root.Add(227, new FloorFightData(227, "", 0, 0, 227, 1, 1, "", 30527, false, 33001, "CEIL((19*x+3)+POW(1.5,x))", 9, 10000, 15));
root.Add(228, new FloorFightData(228, "", 0, 0, 228, 1, 1, "", 30528, false, 33001, "CEIL((19*x+3)+POW(1.5,x))", 9, 10000, 15));
root.Add(229, new FloorFightData(229, "", 0, 0, 229, 1, 1, "", 30529, false, 33001, "CEIL((19*x+3)+POW(1.5,x))", 9, 10000, 15));
root.Add(230, new FloorFightData(230, "", 0, 0, 230, 1, 1, "", 30530, false, 33001, "CEIL((19*x+3)+POW(1.5,x))", 9, 10000, 15));
root.Add(231, new FloorFightData(231, "", 0, 0, 231, 1, 1, "", 30531, false, 33001, "CEIL((19*x+3)+POW(1.5,x))", 9, 10000, 15));
root.Add(232, new FloorFightData(232, "", 0, 0, 232, 1, 1, "", 30532, false, 33001, "CEIL((19*x+3)+POW(1.5,x))", 9, 10000, 15));
root.Add(233, new FloorFightData(233, "", 0, 0, 233, 1, 1, "", 30533, false, 33001, "CEIL((19*x+3)+POW(1.5,x))", 9, 10000, 15));
root.Add(234, new FloorFightData(234, "", 0, 0, 234, 1, 1, "", 30534, false, 33001, "CEIL((19*x+3)+POW(1.5,x))", 9, 10000, 15));
root.Add(235, new FloorFightData(235, "", 0, 0, 235, 1, 1, "", 30535, false, 33001, "CEIL((19*x+3)+POW(1.5,x))", 9, 10000, 15));
root.Add(236, new FloorFightData(236, "", 0, 0, 236, 1, 1, "", 30536, false, 33001, "CEIL((19*x+3)+POW(1.5,x))", 9, 10000, 15));
root.Add(237, new FloorFightData(237, "", 0, 0, 237, 1, 1, "", 30537, false, 33001, "CEIL((19*x+3)+POW(1.5,x))", 9, 10000, 15));
root.Add(238, new FloorFightData(238, "", 0, 0, 238, 1, 1, "", 30538, false, 33001, "CEIL((19*x+3)+POW(1.5,x))", 9, 10000, 15));
root.Add(239, new FloorFightData(239, "", 0, 0, 239, 1, 1, "", 30539, false, 33001, "CEIL((19*x+3)+POW(1.5,x))", 9, 10000, 15));
root.Add(240, new FloorFightData(240, "", 0, 0, 240, 1, 1, "", 30539, false, 33001, "CEIL((19*x+3)+POW(1.5,x))", 9, 10000, 15));
}
public FloorFightData GetReadData(int ID){
if (root.ContainsKey(ID))
return root[ID];
else{
object obj = MMFramework.ModifyExcelModule.Instance.GetModifyedData(ID);
if (obj != null)return obj as FloorFightData;
Debug.LogError("在表格 FloorFightData中没有找到ID" + ID);
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
FloorFightData data = GetReadData(key);
Type type = data.GetType();
System.Reflection.FieldInfo[] filedinfos = type.GetFields();
for (int i = 0; i < filedinfos.Length; i++)
{System.Reflection.FieldInfo field = filedinfos[i];
pairs.Add(field.Name, field.GetValue(data).ToString());}
return pairs;}
}
public static FloorFightData GetData(int ID){
return FloorFightDataReader.Instance.GetReadData(ID);
}
public static Dictionary<string, string> GetDictionary(int key)
{ return FloorFightDataReader.Instance.GetReadDictionary(key);}
public static int GetNum(){
return FloorFightDataReader.Instance.GetCount();
}
public static List<int> GetKeys(){
return FloorFightDataReader.Instance.GetDataKeys();
}
public static void SaveToFile(string path){
FloorFightDataReader.Instance.WriteToFile(path);
}

}