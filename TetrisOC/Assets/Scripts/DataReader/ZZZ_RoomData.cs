using System;
using System.Collections.Generic;
using UnityEngine;
[Serializable]
public class ZZZ_RoomData{
/// <summary>
/// 房间ID
/// </summary>
public int RoomID;
/// <summary>
/// 房间名字
/// </summary>
public string RoomName;
/// <summary>
/// 转换ID
/// </summary>
public int TransformID;
/// <summary>
/// 标题ID
/// </summary>
public int TitleID;
/// <summary>
/// 主题
/// </summary>
public int ThemeID;
/// <summary>
/// 地图ID
/// </summary>
public int MapID;
/// <summary>
/// 怪物组房间Tag
/// </summary>
public int EnimyID;
/// <summary>
/// 怪物掉落ID（把掉落分配给每个怪）
/// </summary>
public int DropGroupID;
public ZZZ_RoomData(int RoomID, string RoomName, int TransformID, int TitleID, int ThemeID, int MapID, int EnimyID, int DropGroupID){
this.RoomID = RoomID;
this.RoomName = RoomName;
this.TransformID = TransformID;
this.TitleID = TitleID;
this.ThemeID = ThemeID;
this.MapID = MapID;
this.EnimyID = EnimyID;
this.DropGroupID = DropGroupID;
}
class ZZZ_RoomDataReader{
static ZZZ_RoomDataReader instance;
static object syncRoot = new object();
public static ZZZ_RoomDataReader Instance{get{if (instance == null){lock (syncRoot){if (instance == null){instance = new ZZZ_RoomDataReader();instance.Load();}}}return instance;}}
Dictionary<int, ZZZ_RoomData> root = new Dictionary<int, ZZZ_RoomData>();
void Load(){
root.Add(10011, new ZZZ_RoomData(10011, "主城", 1, 101, 0, 11, 0, 0));
root.Add(10012, new ZZZ_RoomData(10012, "猫抓练功走廊", 0, 102, 0, 12, 0, 0));
root.Add(10013, new ZZZ_RoomData(10013, "冲塔走廊", 0, 103, 0, 13, 0, 0));
root.Add(10014, new ZZZ_RoomData(10014, "沙漠主城", 1, 201, 2, 14, 0, 0));
root.Add(10021, new ZZZ_RoomData(10021, "猫抓板房间I", 51, 104, 1, 20, 821, 0));
root.Add(10022, new ZZZ_RoomData(10022, "猫抓板房间II", 52, 104, 1, 20, 822, 0));
root.Add(10023, new ZZZ_RoomData(10023, "猫抓板房间III", 53, 104, 1, 20, 823, 0));
root.Add(10031, new ZZZ_RoomData(10031, "练功房I", 62, 105, 1, 30, 831, 9931));
root.Add(10032, new ZZZ_RoomData(10032, "练功房II", 62, 106, 2, 31, 832, 9931));
root.Add(10033, new ZZZ_RoomData(10033, "练功房III", 62, 107, 3, 32, 833, 9931));
root.Add(10041, new ZZZ_RoomData(10041, "塔1层1房", 55, 108, 6, 10001, 701, 9504));
root.Add(10042, new ZZZ_RoomData(10042, "塔1层2房", 0, 108, 6, 10002, 702, 9504));
root.Add(10043, new ZZZ_RoomData(10043, "塔1层3房", 0, 108, 1, 8505, 703, 9504));
root.Add(10044, new ZZZ_RoomData(10044, "塔2层1房", 0, 109, 6, 10001, 704, 9506));
root.Add(10045, new ZZZ_RoomData(10045, "塔2层2房", 0, 109, 6, 10002, 705, 9506));
root.Add(10046, new ZZZ_RoomData(10046, "塔2层3房", 0, 109, 1, 8504, 706, 9506));
root.Add(10047, new ZZZ_RoomData(10047, "塔3层1房", 0, 110, 6, 10001, 707, 9508));
root.Add(10048, new ZZZ_RoomData(10048, "塔3层2房", 0, 110, 6, 10002, 708, 9508));
root.Add(10049, new ZZZ_RoomData(10049, "塔3层3房", 0, 110, 2, 8503, 709, 9508));
root.Add(10050, new ZZZ_RoomData(10050, "塔4层1房", 0, 111, 6, 10001, 710, 9510));
root.Add(10051, new ZZZ_RoomData(10051, "塔4层2房", 0, 111, 6, 10002, 711, 9510));
root.Add(10052, new ZZZ_RoomData(10052, "塔4层3房", 0, 111, 2, 8506, 712, 9510));
root.Add(10053, new ZZZ_RoomData(10053, "塔5层房1", 0, 112, 6, 10001, 713, 9512));
root.Add(10054, new ZZZ_RoomData(10054, "塔5层房2", 0, 112, 6, 10002, 714, 9512));
root.Add(10055, new ZZZ_RoomData(10055, "塔5层房3", 0, 112, 3, 8507, 715, 9512));
root.Add(10056, new ZZZ_RoomData(10056, "塔6层房1", 0, 113, 6, 10001, 716, 9514));
root.Add(10057, new ZZZ_RoomData(10057, "塔6层房2", 0, 113, 6, 10002, 717, 9514));
root.Add(10058, new ZZZ_RoomData(10058, "塔6层房3", 0, 113, 4, 8502, 718, 9514));
root.Add(10059, new ZZZ_RoomData(10059, "塔7层房1", 0, 114, 6, 10001, 719, 9516));
root.Add(10060, new ZZZ_RoomData(10060, "塔7层房2", 0, 114, 6, 10002, 720, 9516));
root.Add(10061, new ZZZ_RoomData(10061, "塔7层房3", 0, 114, 5, 8504, 721, 9516));
root.Add(10101, new ZZZ_RoomData(10101, "第1关一房", 54, 1, 1, 8101, 101, 9011));
root.Add(10102, new ZZZ_RoomData(10102, "第1关二房", 0, 1, 1, 8102, 102, 9014));
root.Add(10103, new ZZZ_RoomData(10103, "第1关Boss房", 50, 51, 1, 8103, 103, 0));
root.Add(10104, new ZZZ_RoomData(10104, "第2关一房", 1, 2, 1, 8104, 104, 9021));
root.Add(10105, new ZZZ_RoomData(10105, "第2关二房", 56, 2, 1, 8105, 105, 0));
root.Add(10106, new ZZZ_RoomData(10106, "第2关Boss房", 2, 52, 1, 8106, 106, 0));
root.Add(10107, new ZZZ_RoomData(10107, "第3关一房", 61, 3, 1, 8107, 107, 9031));
root.Add(10108, new ZZZ_RoomData(10108, "第3关二房", 58, 3, 1, 8108, 108, 0));
root.Add(10109, new ZZZ_RoomData(10109, "第3关Boss房", 3, 53, 1, 8109, 109, 0));
root.Add(10110, new ZZZ_RoomData(10110, "第4关一房", 59, 4, 1, 8110, 110, 9041));
root.Add(10111, new ZZZ_RoomData(10111, "第4关二房", 60, 4, 1, 8111, 111, 0));
root.Add(10112, new ZZZ_RoomData(10112, "第4关Boss房", 4, 54, 1, 8112, 112, 0));
root.Add(10113, new ZZZ_RoomData(10113, "第5关一房", 57, 5, 1, 8113, 113, 9051));
root.Add(10114, new ZZZ_RoomData(10114, "第5关二房", 62, 5, 1, 8114, 114, 0));
root.Add(10115, new ZZZ_RoomData(10115, "第5关Boss房", 5, 55, 1, 8115, 115, 0));
root.Add(10116, new ZZZ_RoomData(10116, "第6关一房", 56, 6, 1, 8116, 116, 9061));
root.Add(10117, new ZZZ_RoomData(10117, "第6关二房", 57, 6, 1, 8117, 117, 0));
root.Add(10118, new ZZZ_RoomData(10118, "第6关Boss房", 6, 56, 1, 8118, 118, 0));
root.Add(10119, new ZZZ_RoomData(10119, "第7关一房", 58, 7, 1, 8119, 119, 9071));
root.Add(10120, new ZZZ_RoomData(10120, "第7关二房", 59, 7, 1, 8120, 120, 0));
root.Add(10121, new ZZZ_RoomData(10121, "第7关Boss房", 7, 57, 1, 8121, 121, 0));
root.Add(10122, new ZZZ_RoomData(10122, "第8关一房", 60, 8, 1, 8122, 122, 9081));
root.Add(10123, new ZZZ_RoomData(10123, "第8关二房", 61, 8, 1, 8123, 123, 0));
root.Add(10124, new ZZZ_RoomData(10124, "第8关Boss房", 8, 58, 1, 8124, 124, 0));
root.Add(10125, new ZZZ_RoomData(10125, "第9关一房", 62, 9, 1, 8125, 125, 9091));
root.Add(10126, new ZZZ_RoomData(10126, "第9关二房", 56, 9, 1, 8126, 126, 0));
root.Add(10127, new ZZZ_RoomData(10127, "第9关Boss房", 9, 59, 1, 8127, 127, 0));
root.Add(10128, new ZZZ_RoomData(10128, "第10关一房", 57, 10, 1, 8128, 128, 9101));
root.Add(10129, new ZZZ_RoomData(10129, "第10关二房", 58, 10, 1, 8129, 129, 0));
root.Add(10130, new ZZZ_RoomData(10130, "第10关Boss房", 10, 60, 1, 8130, 130, 0));
root.Add(10131, new ZZZ_RoomData(10131, "第11关一房", 59, 11, 2, 8131, 131, 9111));
root.Add(10132, new ZZZ_RoomData(10132, "第11关二房", 60, 11, 2, 8132, 132, 0));
root.Add(10133, new ZZZ_RoomData(10133, "第11关Boss房", 11, 61, 2, 8133, 133, 0));
root.Add(10134, new ZZZ_RoomData(10134, "第12关一房", 61, 12, 2, 8134, 134, 9121));
root.Add(10135, new ZZZ_RoomData(10135, "第12关二房", 62, 12, 2, 8135, 135, 0));
root.Add(10136, new ZZZ_RoomData(10136, "第12关Boss房", 12, 62, 2, 8136, 136, 0));
root.Add(10137, new ZZZ_RoomData(10137, "第13关一房", 56, 13, 2, 8137, 137, 9131));
root.Add(10138, new ZZZ_RoomData(10138, "第13关二房", 57, 13, 2, 8138, 138, 0));
root.Add(10139, new ZZZ_RoomData(10139, "第13关Boss房", 13, 63, 2, 8139, 139, 0));
root.Add(10140, new ZZZ_RoomData(10140, "第14关一房", 58, 14, 2, 8140, 140, 9141));
root.Add(10141, new ZZZ_RoomData(10141, "第14关二房", 59, 14, 2, 8141, 141, 0));
root.Add(10142, new ZZZ_RoomData(10142, "第14关Boss房", 14, 64, 2, 8142, 142, 0));
root.Add(10143, new ZZZ_RoomData(10143, "第15关一房", 60, 15, 2, 8143, 143, 9151));
root.Add(10144, new ZZZ_RoomData(10144, "第15关二房", 61, 15, 2, 8144, 144, 0));
root.Add(10145, new ZZZ_RoomData(10145, "第15关Boss房", 15, 65, 2, 8145, 145, 0));
root.Add(10146, new ZZZ_RoomData(10146, "第16关一房", 62, 16, 2, 8146, 146, 9161));
root.Add(10147, new ZZZ_RoomData(10147, "第16关二房", 56, 16, 2, 8147, 147, 0));
root.Add(10148, new ZZZ_RoomData(10148, "第16关Boss房", 16, 66, 2, 8148, 148, 0));
root.Add(10149, new ZZZ_RoomData(10149, "第17关一房", 57, 17, 2, 8149, 149, 9171));
root.Add(10150, new ZZZ_RoomData(10150, "第17关二房", 58, 17, 2, 8150, 150, 0));
root.Add(10151, new ZZZ_RoomData(10151, "第17关Boss房", 17, 67, 2, 8151, 151, 0));
root.Add(10152, new ZZZ_RoomData(10152, "第18关一房", 59, 18, 2, 8152, 152, 9181));
root.Add(10153, new ZZZ_RoomData(10153, "第18关二房", 60, 18, 2, 8153, 153, 0));
root.Add(10154, new ZZZ_RoomData(10154, "第18关Boss房", 18, 68, 2, 8154, 154, 0));
root.Add(10155, new ZZZ_RoomData(10155, "第19关一房", 61, 19, 2, 8155, 155, 9191));
root.Add(10156, new ZZZ_RoomData(10156, "第19关二房", 62, 19, 2, 8156, 156, 0));
root.Add(10157, new ZZZ_RoomData(10157, "第19关Boss房", 19, 69, 2, 8157, 157, 0));
root.Add(10158, new ZZZ_RoomData(10158, "第20关一房", 56, 20, 2, 8158, 158, 9201));
root.Add(10159, new ZZZ_RoomData(10159, "第20关二房", 57, 20, 2, 8159, 159, 0));
root.Add(10160, new ZZZ_RoomData(10160, "第20关Boss房", 20, 70, 2, 8160, 160, 0));
root.Add(10161, new ZZZ_RoomData(10161, "第21关一房", 58, 21, 3, 8161, 161, 9211));
root.Add(10162, new ZZZ_RoomData(10162, "第21关二房", 59, 21, 3, 8162, 162, 0));
root.Add(10163, new ZZZ_RoomData(10163, "第21关Boss房", 21, 71, 3, 8163, 163, 0));
root.Add(10164, new ZZZ_RoomData(10164, "第22关一房", 60, 22, 3, 8164, 164, 9221));
root.Add(10165, new ZZZ_RoomData(10165, "第22关二房", 61, 22, 3, 8165, 165, 0));
root.Add(10166, new ZZZ_RoomData(10166, "第22关Boss房", 22, 72, 3, 8166, 166, 0));
root.Add(10167, new ZZZ_RoomData(10167, "第23关一房", 62, 23, 3, 8167, 167, 9231));
root.Add(10168, new ZZZ_RoomData(10168, "第23关二房", 56, 23, 3, 8168, 168, 0));
root.Add(10169, new ZZZ_RoomData(10169, "第23关Boss房", 23, 73, 3, 8169, 169, 0));
root.Add(10170, new ZZZ_RoomData(10170, "第24关一房", 57, 24, 3, 8170, 170, 9241));
root.Add(10171, new ZZZ_RoomData(10171, "第24关二房", 58, 24, 3, 8171, 171, 0));
root.Add(10172, new ZZZ_RoomData(10172, "第24关Boss房", 24, 74, 3, 8172, 172, 0));
root.Add(10173, new ZZZ_RoomData(10173, "第25关一房", 59, 25, 3, 8173, 173, 9251));
root.Add(10174, new ZZZ_RoomData(10174, "第25关二房", 60, 25, 3, 8174, 174, 0));
root.Add(10175, new ZZZ_RoomData(10175, "第25关Boss房", 25, 75, 3, 8175, 175, 0));
root.Add(10176, new ZZZ_RoomData(10176, "第26关一房", 61, 26, 3, 8176, 176, 9261));
root.Add(10177, new ZZZ_RoomData(10177, "第26关二房", 62, 26, 3, 8177, 177, 0));
root.Add(10178, new ZZZ_RoomData(10178, "第26关Boss房", 26, 76, 3, 8178, 178, 0));
root.Add(10179, new ZZZ_RoomData(10179, "第27关一房", 56, 27, 3, 8179, 179, 9271));
root.Add(10180, new ZZZ_RoomData(10180, "第27关二房", 57, 27, 3, 8180, 180, 0));
root.Add(10181, new ZZZ_RoomData(10181, "第27关Boss房", 27, 77, 3, 8181, 181, 0));
root.Add(10182, new ZZZ_RoomData(10182, "第28关一房", 58, 28, 3, 8182, 182, 9281));
root.Add(10183, new ZZZ_RoomData(10183, "第28关二房", 59, 28, 3, 8183, 183, 0));
root.Add(10184, new ZZZ_RoomData(10184, "第28关Boss房", 28, 78, 3, 8184, 184, 0));
root.Add(10185, new ZZZ_RoomData(10185, "第29关一房", 60, 29, 3, 8185, 185, 9291));
root.Add(10186, new ZZZ_RoomData(10186, "第29关二房", 61, 29, 3, 8186, 186, 0));
root.Add(10187, new ZZZ_RoomData(10187, "第29关Boss房", 29, 79, 3, 8187, 187, 0));
root.Add(10188, new ZZZ_RoomData(10188, "第30关一房", 62, 30, 3, 8188, 188, 9301));
root.Add(10189, new ZZZ_RoomData(10189, "第30关二房", 56, 30, 3, 8189, 189, 0));
root.Add(10190, new ZZZ_RoomData(10190, "第30关Boss房", 30, 80, 3, 8190, 190, 0));
root.Add(10191, new ZZZ_RoomData(10191, "第31关一房", 57, 31, 4, 8191, 191, 9311));
root.Add(10192, new ZZZ_RoomData(10192, "第31关二房", 58, 31, 4, 8192, 192, 0));
root.Add(10193, new ZZZ_RoomData(10193, "第31关Boss房", 31, 81, 4, 8193, 193, 0));
root.Add(10194, new ZZZ_RoomData(10194, "第32关一房", 59, 32, 4, 8194, 194, 9321));
root.Add(10195, new ZZZ_RoomData(10195, "第32关二房", 60, 32, 4, 8195, 195, 0));
root.Add(10196, new ZZZ_RoomData(10196, "第32关Boss房", 32, 82, 4, 8196, 196, 0));
root.Add(10197, new ZZZ_RoomData(10197, "第33关一房", 61, 33, 4, 8197, 197, 9331));
root.Add(10198, new ZZZ_RoomData(10198, "第33关二房", 62, 33, 4, 8198, 198, 0));
root.Add(10199, new ZZZ_RoomData(10199, "第33关Boss房", 33, 83, 4, 8199, 199, 0));
root.Add(10200, new ZZZ_RoomData(10200, "第34关一房", 56, 34, 4, 8200, 200, 9341));
root.Add(10201, new ZZZ_RoomData(10201, "第34关二房", 57, 34, 4, 8201, 201, 0));
root.Add(10202, new ZZZ_RoomData(10202, "第34关Boss房", 34, 84, 4, 8202, 202, 0));
root.Add(10203, new ZZZ_RoomData(10203, "第35关一房", 58, 35, 4, 8203, 203, 9351));
root.Add(10204, new ZZZ_RoomData(10204, "第35关二房", 59, 35, 4, 8204, 204, 0));
root.Add(10205, new ZZZ_RoomData(10205, "第35关Boss房", 35, 85, 4, 8205, 205, 0));
root.Add(10206, new ZZZ_RoomData(10206, "第36关一房", 60, 36, 4, 8206, 206, 9361));
root.Add(10207, new ZZZ_RoomData(10207, "第36关二房", 61, 36, 4, 8207, 207, 0));
root.Add(10208, new ZZZ_RoomData(10208, "第36关Boss房", 36, 86, 4, 8208, 208, 0));
root.Add(10209, new ZZZ_RoomData(10209, "第37关一房", 62, 37, 4, 8209, 209, 9371));
root.Add(10210, new ZZZ_RoomData(10210, "第37关二房", 56, 37, 4, 8210, 210, 0));
root.Add(10211, new ZZZ_RoomData(10211, "第37关Boss房", 37, 87, 4, 8211, 211, 0));
root.Add(10212, new ZZZ_RoomData(10212, "第38关一房", 57, 38, 4, 8212, 212, 9381));
root.Add(10213, new ZZZ_RoomData(10213, "第38关二房", 58, 38, 4, 8213, 213, 0));
root.Add(10214, new ZZZ_RoomData(10214, "第38关Boss房", 38, 88, 4, 8214, 214, 0));
root.Add(10215, new ZZZ_RoomData(10215, "第39关一房", 59, 39, 4, 8215, 215, 9391));
root.Add(10216, new ZZZ_RoomData(10216, "第39关二房", 60, 39, 4, 8216, 216, 0));
root.Add(10217, new ZZZ_RoomData(10217, "第39关Boss房", 39, 89, 4, 8217, 217, 0));
root.Add(10218, new ZZZ_RoomData(10218, "第40关一房", 61, 40, 4, 8218, 218, 9401));
root.Add(10219, new ZZZ_RoomData(10219, "第40关二房", 62, 40, 4, 8219, 219, 0));
root.Add(10220, new ZZZ_RoomData(10220, "第40关Boss房", 40, 90, 4, 8220, 220, 0));
root.Add(10221, new ZZZ_RoomData(10221, "第41关一房", 56, 41, 5, 8221, 221, 9411));
root.Add(10222, new ZZZ_RoomData(10222, "第41关二房", 57, 41, 5, 8222, 222, 0));
root.Add(10223, new ZZZ_RoomData(10223, "第41关Boss房", 41, 91, 5, 8223, 223, 0));
root.Add(10224, new ZZZ_RoomData(10224, "第42关一房", 58, 42, 5, 8224, 224, 9421));
root.Add(10225, new ZZZ_RoomData(10225, "第42关二房", 59, 42, 5, 8225, 225, 0));
root.Add(10226, new ZZZ_RoomData(10226, "第42关Boss房", 42, 92, 5, 8226, 226, 0));
root.Add(10227, new ZZZ_RoomData(10227, "第43关一房", 60, 43, 5, 8227, 227, 9431));
root.Add(10228, new ZZZ_RoomData(10228, "第43关二房", 61, 43, 5, 8228, 228, 0));
root.Add(10229, new ZZZ_RoomData(10229, "第43关Boss房", 43, 93, 5, 8229, 229, 0));
root.Add(10230, new ZZZ_RoomData(10230, "第44关一房", 62, 44, 5, 8230, 230, 9441));
root.Add(10231, new ZZZ_RoomData(10231, "第44关二房", 56, 44, 5, 8231, 231, 0));
root.Add(10232, new ZZZ_RoomData(10232, "第44关Boss房", 44, 94, 5, 8232, 232, 0));
root.Add(10233, new ZZZ_RoomData(10233, "第45关一房", 57, 45, 5, 8233, 233, 9451));
root.Add(10234, new ZZZ_RoomData(10234, "第45关二房", 58, 45, 5, 8234, 234, 0));
root.Add(10235, new ZZZ_RoomData(10235, "第45关Boss房", 45, 95, 5, 8235, 235, 0));
root.Add(10236, new ZZZ_RoomData(10236, "第46关一房", 59, 46, 5, 8236, 236, 9461));
root.Add(10237, new ZZZ_RoomData(10237, "第46关二房", 60, 46, 5, 8237, 237, 0));
root.Add(10238, new ZZZ_RoomData(10238, "第46关Boss房", 46, 96, 5, 8238, 238, 0));
root.Add(10239, new ZZZ_RoomData(10239, "第47关一房", 61, 47, 5, 8239, 239, 9471));
root.Add(10240, new ZZZ_RoomData(10240, "第47关二房", 62, 47, 5, 8240, 240, 0));
root.Add(10241, new ZZZ_RoomData(10241, "第47关Boss房", 47, 97, 5, 8241, 241, 0));
root.Add(10242, new ZZZ_RoomData(10242, "第48关一房", 56, 48, 5, 8242, 242, 9481));
root.Add(10243, new ZZZ_RoomData(10243, "第48关二房", 57, 48, 5, 8243, 243, 0));
root.Add(10244, new ZZZ_RoomData(10244, "第48关Boss房", 48, 98, 5, 8244, 244, 0));
root.Add(10245, new ZZZ_RoomData(10245, "第49关一房", 58, 49, 5, 8245, 245, 9491));
root.Add(10246, new ZZZ_RoomData(10246, "第49关二房", 59, 49, 5, 8246, 246, 0));
root.Add(10247, new ZZZ_RoomData(10247, "第49关Boss房", 49, 99, 5, 8247, 247, 0));
root.Add(10248, new ZZZ_RoomData(10248, "第50关一房", 60, 50, 5, 8248, 248, 9501));
root.Add(10249, new ZZZ_RoomData(10249, "第50关二房", 61, 50, 5, 8249, 249, 0));
root.Add(10250, new ZZZ_RoomData(10250, "第50关Boss房", 50, 100, 5, 8250, 250, 0));
root.Add(10888, new ZZZ_RoomData(10888, "测试用房间", 62, 1, 6, 8889, 888, 9011));
root.Add(11000, new ZZZ_RoomData(11000, "冲塔菱形房间", 76, 0, 0, 9501, 0, 0));
root.Add(11001, new ZZZ_RoomData(11001, "冲塔菱形房间", 77, 0, 0, 9502, 0, 0));
root.Add(11002, new ZZZ_RoomData(11002, "冲塔菱形房间", 78, 0, 0, 9503, 0, 0));
root.Add(11003, new ZZZ_RoomData(11003, "冲塔菱形房间", 79, 0, 0, 9504, 0, 0));
root.Add(11004, new ZZZ_RoomData(11004, "冲塔菱形房间", 80, 0, 0, 9505, 0, 0));
root.Add(11005, new ZZZ_RoomData(11005, "冲塔菱形房间", 81, 0, 0, 9506, 0, 0));
}
public ZZZ_RoomData GetReadData(int ID){
if (root.ContainsKey(ID))
return root[ID];
else{
object obj = MMFramework.ModifyExcelModule.Instance.GetModifyedData(ID);
if (obj != null)return obj as ZZZ_RoomData;
Debug.LogError("在表格 ZZZ_RoomData中没有找到ID" + ID);
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
ZZZ_RoomData data = GetReadData(key);
Type type = data.GetType();
System.Reflection.FieldInfo[] filedinfos = type.GetFields();
for (int i = 0; i < filedinfos.Length; i++)
{System.Reflection.FieldInfo field = filedinfos[i];
pairs.Add(field.Name, field.GetValue(data).ToString());}
return pairs;}
}
public static ZZZ_RoomData GetData(int ID){
return ZZZ_RoomDataReader.Instance.GetReadData(ID);
}
public static Dictionary<string, string> GetDictionary(int key)
{ return ZZZ_RoomDataReader.Instance.GetReadDictionary(key);}
public static int GetNum(){
return ZZZ_RoomDataReader.Instance.GetCount();
}
public static List<int> GetKeys(){
return ZZZ_RoomDataReader.Instance.GetDataKeys();
}
public static void SaveToFile(string path){
ZZZ_RoomDataReader.Instance.WriteToFile(path);
}

}