using System;
using System.Collections.Generic;
using UnityEngine;
[Serializable]
public class SkillGroupData{
/// <summary>
/// 技能组ID
/// </summary>
public int SkillGroupID;
/// <summary>
/// 图标
/// </summary>
public string Icon;
/// <summary>
/// ID
/// </summary>
public int[] IDArray;
/// <summary>
/// ID
/// </summary>
public int[] LvArray;
public SkillGroupData(int SkillGroupID, string Icon, int[] IDArray, int[] LvArray){
this.SkillGroupID = SkillGroupID;
this.Icon = Icon;
this.IDArray = IDArray;
this.LvArray = LvArray;
}
class SkillGroupDataReader{
static SkillGroupDataReader instance;
static object syncRoot = new object();
public static SkillGroupDataReader Instance{get{if (instance == null){lock (syncRoot){if (instance == null){instance = new SkillGroupDataReader();instance.Load();}}}return instance;}}
Dictionary<int, SkillGroupData> root = new Dictionary<int, SkillGroupData>();
void Load(){
root.Add(8001, new SkillGroupData(8001, "", new int[] {800101, 0, 0, 0, 0}, new int[] {1, 0, 0, 0, 0}));
root.Add(8002, new SkillGroupData(8002, "", new int[] {800201, 0, 0, 0, 0}, new int[] {1, 0, 0, 0, 0}));
root.Add(8003, new SkillGroupData(8003, "", new int[] {800301, 0, 0, 0, 0}, new int[] {1, 0, 0, 0, 0}));
root.Add(8004, new SkillGroupData(8004, "", new int[] {800401, 0, 0, 0, 0}, new int[] {1, 0, 0, 0, 0}));
root.Add(8005, new SkillGroupData(8005, "", new int[] {800501, 0, 0, 0, 0}, new int[] {1, 0, 0, 0, 0}));
root.Add(8006, new SkillGroupData(8006, "", new int[] {800601, 0, 0, 0, 0}, new int[] {1, 0, 0, 0, 0}));
root.Add(8007, new SkillGroupData(8007, "", new int[] {800701, 0, 0, 0, 0}, new int[] {1, 0, 0, 0, 0}));
root.Add(8008, new SkillGroupData(8008, "", new int[] {800801, 0, 0, 0, 0}, new int[] {1, 0, 0, 0, 0}));
root.Add(8009, new SkillGroupData(8009, "", new int[] {800901, 0, 0, 0, 0}, new int[] {1, 0, 0, 0, 0}));
root.Add(8010, new SkillGroupData(8010, "", new int[] {801001, 0, 0, 0, 0}, new int[] {1, 0, 0, 0, 0}));
root.Add(8011, new SkillGroupData(8011, "", new int[] {801101, 0, 0, 0, 0}, new int[] {1, 0, 0, 0, 0}));
root.Add(8012, new SkillGroupData(8012, "", new int[] {801201, 0, 0, 0, 0}, new int[] {1, 0, 0, 0, 0}));
root.Add(8013, new SkillGroupData(8013, "", new int[] {801301, 0, 0, 0, 0}, new int[] {1, 0, 0, 0, 0}));
root.Add(8014, new SkillGroupData(8014, "", new int[] {801401, 0, 0, 0, 0}, new int[] {1, 0, 0, 0, 0}));
root.Add(8015, new SkillGroupData(8015, "", new int[] {801501, 0, 0, 0, 0}, new int[] {1, 0, 0, 0, 0}));
root.Add(8016, new SkillGroupData(8016, "", new int[] {801601, 0, 0, 0, 0}, new int[] {1, 0, 0, 0, 0}));
root.Add(8017, new SkillGroupData(8017, "", new int[] {801701, 0, 0, 0, 0}, new int[] {1, 0, 0, 0, 0}));
root.Add(8018, new SkillGroupData(8018, "", new int[] {801801, 0, 0, 0, 0}, new int[] {1, 0, 0, 0, 0}));
root.Add(8019, new SkillGroupData(8019, "", new int[] {801901, 0, 0, 0, 0}, new int[] {1, 0, 0, 0, 0}));
root.Add(8020, new SkillGroupData(8020, "", new int[] {802001, 0, 0, 0, 0}, new int[] {1, 0, 0, 0, 0}));
root.Add(8021, new SkillGroupData(8021, "", new int[] {802101, 0, 0, 0, 0}, new int[] {1, 0, 0, 0, 0}));
root.Add(8022, new SkillGroupData(8022, "", new int[] {802201, 0, 0, 0, 0}, new int[] {1, 0, 0, 0, 0}));
root.Add(8023, new SkillGroupData(8023, "", new int[] {802301, 0, 0, 0, 0}, new int[] {1, 0, 0, 0, 0}));
root.Add(8024, new SkillGroupData(8024, "", new int[] {802401, 0, 0, 0, 0}, new int[] {1, 0, 0, 0, 0}));
root.Add(8025, new SkillGroupData(8025, "", new int[] {802501, 0, 0, 0, 0}, new int[] {1, 0, 0, 0, 0}));
root.Add(8026, new SkillGroupData(8026, "", new int[] {802601, 0, 0, 0, 0}, new int[] {1, 0, 0, 0, 0}));
root.Add(8027, new SkillGroupData(8027, "", new int[] {802701, 0, 0, 0, 0}, new int[] {1, 0, 0, 0, 0}));
root.Add(8028, new SkillGroupData(8028, "", new int[] {802801, 0, 0, 0, 0}, new int[] {1, 0, 0, 0, 0}));
root.Add(8029, new SkillGroupData(8029, "", new int[] {802901, 0, 0, 0, 0}, new int[] {1, 0, 0, 0, 0}));
root.Add(8030, new SkillGroupData(8030, "", new int[] {803001, 0, 0, 0, 0}, new int[] {1, 0, 0, 0, 0}));
root.Add(8031, new SkillGroupData(8031, "", new int[] {803101, 0, 0, 0, 0}, new int[] {1, 0, 0, 0, 0}));
root.Add(8032, new SkillGroupData(8032, "", new int[] {803201, 0, 0, 0, 0}, new int[] {1, 0, 0, 0, 0}));
root.Add(8033, new SkillGroupData(8033, "", new int[] {803301, 0, 0, 0, 0}, new int[] {1, 0, 0, 0, 0}));
root.Add(8034, new SkillGroupData(8034, "", new int[] {803401, 0, 0, 0, 0}, new int[] {1, 0, 0, 0, 0}));
root.Add(8035, new SkillGroupData(8035, "", new int[] {803501, 0, 0, 0, 0}, new int[] {1, 0, 0, 0, 0}));
root.Add(8101, new SkillGroupData(8101, "", new int[] {810101, 0, 0, 0, 0}, new int[] {1, 0, 0, 0, 0}));
root.Add(8102, new SkillGroupData(8102, "", new int[] {810201, 0, 0, 0, 0}, new int[] {1, 0, 0, 0, 0}));
root.Add(8103, new SkillGroupData(8103, "", new int[] {810301, 0, 0, 0, 0}, new int[] {1, 0, 0, 0, 0}));
root.Add(8104, new SkillGroupData(8104, "", new int[] {810401, 0, 0, 0, 0}, new int[] {1, 0, 0, 0, 0}));
root.Add(8105, new SkillGroupData(8105, "", new int[] {810501, 0, 0, 0, 0}, new int[] {1, 0, 0, 0, 0}));
root.Add(8106, new SkillGroupData(8106, "", new int[] {810601, 0, 0, 0, 0}, new int[] {1, 0, 0, 0, 0}));
root.Add(8107, new SkillGroupData(8107, "", new int[] {810701, 0, 0, 0, 0}, new int[] {1, 0, 0, 0, 0}));
root.Add(8108, new SkillGroupData(8108, "", new int[] {810801, 0, 0, 0, 0}, new int[] {1, 0, 0, 0, 0}));
root.Add(8109, new SkillGroupData(8109, "", new int[] {810901, 0, 0, 0, 0}, new int[] {1, 0, 0, 0, 0}));
root.Add(8110, new SkillGroupData(8110, "", new int[] {811001, 0, 0, 0, 0}, new int[] {1, 0, 0, 0, 0}));
root.Add(8111, new SkillGroupData(8111, "", new int[] {811101, 0, 0, 0, 0}, new int[] {1, 0, 0, 0, 0}));
root.Add(8112, new SkillGroupData(8112, "", new int[] {811201, 0, 0, 0, 0}, new int[] {1, 0, 0, 0, 0}));
root.Add(8113, new SkillGroupData(8113, "", new int[] {811301, 0, 0, 0, 0}, new int[] {1, 0, 0, 0, 0}));
root.Add(8114, new SkillGroupData(8114, "", new int[] {811401, 0, 0, 0, 0}, new int[] {1, 0, 0, 0, 0}));
root.Add(8115, new SkillGroupData(8115, "", new int[] {811501, 0, 0, 0, 0}, new int[] {1, 0, 0, 0, 0}));
root.Add(8116, new SkillGroupData(8116, "", new int[] {811601, 0, 0, 0, 0}, new int[] {1, 0, 0, 0, 0}));
root.Add(8117, new SkillGroupData(8117, "", new int[] {811701, 0, 0, 0, 0}, new int[] {1, 0, 0, 0, 0}));
root.Add(8118, new SkillGroupData(8118, "", new int[] {811801, 0, 0, 0, 0}, new int[] {1, 0, 0, 0, 0}));
root.Add(8119, new SkillGroupData(8119, "", new int[] {811901, 0, 0, 0, 0}, new int[] {1, 0, 0, 0, 0}));
root.Add(8120, new SkillGroupData(8120, "", new int[] {812001, 0, 0, 0, 0}, new int[] {1, 0, 0, 0, 0}));
root.Add(8121, new SkillGroupData(8121, "", new int[] {812101, 0, 0, 0, 0}, new int[] {1, 0, 0, 0, 0}));
root.Add(8122, new SkillGroupData(8122, "", new int[] {812201, 0, 0, 0, 0}, new int[] {1, 0, 0, 0, 0}));
root.Add(8123, new SkillGroupData(8123, "", new int[] {812301, 0, 0, 0, 0}, new int[] {1, 0, 0, 0, 0}));
root.Add(8124, new SkillGroupData(8124, "", new int[] {812401, 0, 0, 0, 0}, new int[] {1, 0, 0, 0, 0}));
root.Add(8125, new SkillGroupData(8125, "", new int[] {812501, 0, 0, 0, 0}, new int[] {1, 0, 0, 0, 0}));
root.Add(8126, new SkillGroupData(8126, "", new int[] {812601, 0, 0, 0, 0}, new int[] {1, 0, 0, 0, 0}));
root.Add(8127, new SkillGroupData(8127, "", new int[] {812701, 0, 0, 0, 0}, new int[] {1, 0, 0, 0, 0}));
root.Add(8128, new SkillGroupData(8128, "", new int[] {812801, 0, 0, 0, 0}, new int[] {1, 0, 0, 0, 0}));
root.Add(8129, new SkillGroupData(8129, "", new int[] {812901, 0, 0, 0, 0}, new int[] {1, 0, 0, 0, 0}));
root.Add(8130, new SkillGroupData(8130, "", new int[] {813001, 0, 0, 0, 0}, new int[] {1, 0, 0, 0, 0}));
root.Add(8131, new SkillGroupData(8131, "", new int[] {813101, 0, 0, 0, 0}, new int[] {1, 0, 0, 0, 0}));
root.Add(8132, new SkillGroupData(8132, "", new int[] {813201, 0, 0, 0, 0}, new int[] {1, 0, 0, 0, 0}));
root.Add(8133, new SkillGroupData(8133, "", new int[] {813301, 0, 0, 0, 0}, new int[] {1, 0, 0, 0, 0}));
root.Add(8134, new SkillGroupData(8134, "", new int[] {813401, 0, 0, 0, 0}, new int[] {1, 0, 0, 0, 0}));
root.Add(8135, new SkillGroupData(8135, "", new int[] {813501, 0, 0, 0, 0}, new int[] {1, 0, 0, 0, 0}));
root.Add(8136, new SkillGroupData(8136, "", new int[] {813601, 0, 0, 0, 0}, new int[] {1, 0, 0, 0, 0}));
root.Add(8137, new SkillGroupData(8137, "", new int[] {813701, 0, 0, 0, 0}, new int[] {1, 0, 0, 0, 0}));
root.Add(8138, new SkillGroupData(8138, "", new int[] {813801, 0, 0, 0, 0}, new int[] {1, 0, 0, 0, 0}));
root.Add(8139, new SkillGroupData(8139, "", new int[] {813901, 0, 0, 0, 0}, new int[] {1, 0, 0, 0, 0}));
root.Add(8140, new SkillGroupData(8140, "", new int[] {814001, 0, 0, 0, 0}, new int[] {1, 0, 0, 0, 0}));
root.Add(8141, new SkillGroupData(8141, "", new int[] {814101, 0, 0, 0, 0}, new int[] {1, 0, 0, 0, 0}));
root.Add(8151, new SkillGroupData(8151, "", new int[] {815101, 815101, 815101, 815101, 815101}, new int[] {1, 3, 5, 9, 20}));
root.Add(8152, new SkillGroupData(8152, "", new int[] {815201, 815201, 815201, 815201, 815201}, new int[] {1, 3, 5, 9, 20}));
root.Add(8153, new SkillGroupData(8153, "", new int[] {815301, 815301, 815301, 815301, 815301}, new int[] {1, 3, 5, 9, 20}));
root.Add(8154, new SkillGroupData(8154, "", new int[] {815401, 815401, 815401, 815401, 815401}, new int[] {1, 3, 5, 9, 20}));
root.Add(8155, new SkillGroupData(8155, "", new int[] {815501, 815501, 815501, 815501, 815501}, new int[] {1, 3, 5, 9, 20}));
root.Add(8156, new SkillGroupData(8156, "", new int[] {815601, 815601, 815601, 815601, 815601}, new int[] {1, 3, 5, 9, 20}));
root.Add(8157, new SkillGroupData(8157, "", new int[] {815701, 815701, 815701, 815701, 815701}, new int[] {1, 3, 5, 9, 20}));
root.Add(8158, new SkillGroupData(8158, "", new int[] {815801, 815801, 815801, 815801, 815801}, new int[] {1, 3, 5, 9, 20}));
root.Add(8159, new SkillGroupData(8159, "", new int[] {815901, 815901, 815901, 815901, 815901}, new int[] {1, 3, 5, 9, 20}));
root.Add(8160, new SkillGroupData(8160, "", new int[] {816001, 816001, 816001, 816001, 816001}, new int[] {1, 3, 5, 9, 20}));
root.Add(8161, new SkillGroupData(8161, "", new int[] {816101, 816101, 816101, 816101, 816101}, new int[] {1, 3, 5, 9, 20}));
root.Add(8162, new SkillGroupData(8162, "", new int[] {816201, 816201, 816201, 816201, 816201}, new int[] {1, 3, 5, 9, 20}));
root.Add(8163, new SkillGroupData(8163, "", new int[] {816301, 816301, 816301, 816301, 816301}, new int[] {1, 3, 5, 9, 20}));
root.Add(8164, new SkillGroupData(8164, "", new int[] {816401, 816401, 816401, 816401, 816401}, new int[] {1, 3, 5, 9, 20}));
root.Add(8165, new SkillGroupData(8165, "", new int[] {816501, 816501, 816501, 816501, 816501}, new int[] {1, 3, 5, 9, 20}));
root.Add(8166, new SkillGroupData(8166, "", new int[] {816601, 816601, 816601, 816601, 816601}, new int[] {1, 3, 5, 9, 20}));
root.Add(8167, new SkillGroupData(8167, "", new int[] {816701, 816701, 816701, 816701, 816701}, new int[] {1, 3, 5, 9, 20}));
root.Add(8168, new SkillGroupData(8168, "", new int[] {816801, 816801, 816801, 816801, 816801}, new int[] {1, 3, 5, 9, 20}));
root.Add(8169, new SkillGroupData(8169, "", new int[] {816901, 816901, 816901, 816901, 816901}, new int[] {1, 3, 5, 9, 20}));
root.Add(8170, new SkillGroupData(8170, "", new int[] {817001, 817001, 817001, 817001, 817001}, new int[] {1, 3, 5, 9, 20}));
root.Add(8171, new SkillGroupData(8171, "", new int[] {817101, 817101, 817101, 817101, 817101}, new int[] {1, 3, 5, 9, 20}));
root.Add(8172, new SkillGroupData(8172, "", new int[] {817201, 817201, 817201, 817201, 817201}, new int[] {1, 3, 5, 9, 20}));
root.Add(8173, new SkillGroupData(8173, "", new int[] {817301, 817301, 817301, 817301, 817301}, new int[] {1, 3, 5, 9, 20}));
root.Add(8174, new SkillGroupData(8174, "", new int[] {817401, 817401, 817401, 817401, 817401}, new int[] {1, 3, 5, 9, 20}));
root.Add(8175, new SkillGroupData(8175, "", new int[] {817501, 817501, 817501, 817501, 817501}, new int[] {1, 3, 5, 9, 20}));
root.Add(8176, new SkillGroupData(8176, "", new int[] {817601, 817601, 817601, 817601, 817601}, new int[] {1, 3, 5, 9, 20}));
root.Add(8177, new SkillGroupData(8177, "", new int[] {817701, 817701, 817701, 817701, 817701}, new int[] {1, 3, 5, 9, 20}));
root.Add(8178, new SkillGroupData(8178, "", new int[] {817801, 817801, 817801, 817801, 817801}, new int[] {1, 3, 5, 9, 20}));
root.Add(8179, new SkillGroupData(8179, "", new int[] {817901, 817901, 817901, 817901, 817901}, new int[] {1, 3, 5, 9, 20}));
root.Add(8180, new SkillGroupData(8180, "", new int[] {818001, 818001, 818001, 818001, 818001}, new int[] {1, 3, 5, 9, 20}));
root.Add(8181, new SkillGroupData(8181, "", new int[] {818101, 818101, 818101, 818101, 818101}, new int[] {1, 3, 5, 9, 20}));
root.Add(8182, new SkillGroupData(8182, "", new int[] {818201, 818201, 818201, 818201, 818201}, new int[] {1, 3, 5, 9, 20}));
root.Add(8183, new SkillGroupData(8183, "", new int[] {818301, 818301, 818301, 818301, 818301}, new int[] {1, 3, 5, 9, 20}));
root.Add(8184, new SkillGroupData(8184, "", new int[] {818401, 818401, 818401, 818401, 818401}, new int[] {1, 3, 5, 9, 20}));
root.Add(8185, new SkillGroupData(8185, "", new int[] {818501, 818501, 818501, 818501, 818501}, new int[] {1, 3, 5, 9, 20}));
root.Add(8186, new SkillGroupData(8186, "", new int[] {818601, 818601, 818601, 818601, 818601}, new int[] {1, 3, 5, 9, 20}));
root.Add(8187, new SkillGroupData(8187, "", new int[] {818701, 818701, 818701, 818701, 818701}, new int[] {1, 3, 5, 9, 20}));
root.Add(8188, new SkillGroupData(8188, "", new int[] {818801, 818801, 818801, 818801, 818801}, new int[] {1, 3, 5, 9, 20}));
root.Add(8189, new SkillGroupData(8189, "", new int[] {818901, 818901, 818901, 818901, 818901}, new int[] {1, 3, 5, 9, 20}));
root.Add(8190, new SkillGroupData(8190, "", new int[] {819001, 819001, 819001, 819001, 819001}, new int[] {1, 3, 5, 9, 20}));
root.Add(8191, new SkillGroupData(8191, "", new int[] {819101, 819101, 819101, 819101, 819101}, new int[] {1, 3, 5, 9, 20}));
root.Add(8192, new SkillGroupData(8192, "", new int[] {819201, 819201, 819201, 819201, 819201}, new int[] {1, 3, 5, 9, 20}));
root.Add(8193, new SkillGroupData(8193, "", new int[] {819301, 819301, 819301, 819301, 819301}, new int[] {1, 3, 5, 9, 20}));
root.Add(8194, new SkillGroupData(8194, "", new int[] {819401, 819401, 819401, 819401, 819401}, new int[] {1, 3, 5, 9, 20}));
root.Add(8195, new SkillGroupData(8195, "", new int[] {819501, 819501, 819501, 819501, 819501}, new int[] {1, 3, 5, 9, 20}));
root.Add(8196, new SkillGroupData(8196, "", new int[] {819601, 819601, 819601, 819601, 819601}, new int[] {1, 3, 5, 9, 20}));
root.Add(8197, new SkillGroupData(8197, "", new int[] {819701, 819701, 819701, 819701, 819701}, new int[] {1, 3, 5, 9, 20}));
root.Add(8198, new SkillGroupData(8198, "", new int[] {819801, 819801, 819801, 819801, 819801}, new int[] {1, 3, 5, 9, 20}));
root.Add(8199, new SkillGroupData(8199, "", new int[] {819901, 819901, 819901, 819901, 819901}, new int[] {1, 3, 5, 9, 20}));
root.Add(8200, new SkillGroupData(8200, "", new int[] {820001, 820001, 820001, 820001, 820001}, new int[] {1, 3, 5, 9, 20}));
root.Add(9001, new SkillGroupData(9001, "", new int[] {900101, 0, 0, 0, 0}, new int[] {1, 0, 0, 0, 0}));
root.Add(9002, new SkillGroupData(9002, "", new int[] {900201, 0, 0, 0, 0}, new int[] {1, 0, 0, 0, 0}));
root.Add(9003, new SkillGroupData(9003, "", new int[] {900301, 0, 0, 0, 0}, new int[] {1, 0, 0, 0, 0}));
root.Add(9004, new SkillGroupData(9004, "", new int[] {900401, 0, 0, 0, 0}, new int[] {1, 0, 0, 0, 0}));
root.Add(9005, new SkillGroupData(9005, "", new int[] {900501, 0, 0, 0, 0}, new int[] {1, 0, 0, 0, 0}));
root.Add(9006, new SkillGroupData(9006, "", new int[] {900601, 0, 0, 0, 0}, new int[] {1, 0, 0, 0, 0}));
root.Add(9007, new SkillGroupData(9007, "", new int[] {900701, 0, 0, 0, 0}, new int[] {1, 0, 0, 0, 0}));
root.Add(9008, new SkillGroupData(9008, "", new int[] {900801, 0, 0, 0, 0}, new int[] {1, 0, 0, 0, 0}));
root.Add(9009, new SkillGroupData(9009, "", new int[] {900901, 0, 0, 0, 0}, new int[] {1, 2, 3, 4, 5}));
root.Add(9010, new SkillGroupData(9010, "", new int[] {901001, 0, 0, 0, 0}, new int[] {1, 2, 3, 4, 5}));
root.Add(9011, new SkillGroupData(9011, "", new int[] {901101, 0, 0, 0, 0}, new int[] {1, 0, 0, 0, 0}));
root.Add(9012, new SkillGroupData(9012, "", new int[] {901201, 0, 0, 0, 0}, new int[] {1, 0, 0, 0, 0}));
root.Add(9013, new SkillGroupData(9013, "", new int[] {901301, 0, 0, 0, 0}, new int[] {1, 0, 0, 0, 0}));
root.Add(9014, new SkillGroupData(9014, "", new int[] {901401, 0, 0, 0, 0}, new int[] {1, 0, 0, 0, 0}));
root.Add(9015, new SkillGroupData(9015, "", new int[] {901501, 0, 0, 0, 0}, new int[] {1, 0, 0, 0, 0}));
root.Add(9016, new SkillGroupData(9016, "", new int[] {901601, 0, 0, 0, 0}, new int[] {1, 0, 0, 0, 0}));
root.Add(9017, new SkillGroupData(9017, "", new int[] {901701, 0, 0, 0, 0}, new int[] {1, 0, 0, 0, 0}));
root.Add(9018, new SkillGroupData(9018, "", new int[] {901801, 0, 0, 0, 0}, new int[] {1, 0, 0, 0, 0}));
root.Add(9019, new SkillGroupData(9019, "", new int[] {901901, 0, 0, 0, 0}, new int[] {1, 0, 0, 0, 0}));
root.Add(9020, new SkillGroupData(9020, "", new int[] {902001, 0, 0, 0, 0}, new int[] {1, 0, 0, 0, 0}));
root.Add(9021, new SkillGroupData(9021, "", new int[] {902101, 0, 0, 0, 0}, new int[] {1, 0, 0, 0, 0}));
root.Add(9022, new SkillGroupData(9022, "", new int[] {902201, 0, 0, 0, 0}, new int[] {1, 0, 0, 0, 0}));
root.Add(9023, new SkillGroupData(9023, "", new int[] {902301, 0, 0, 0, 0}, new int[] {1, 0, 0, 0, 0}));
root.Add(9024, new SkillGroupData(9024, "", new int[] {902401, 0, 0, 0, 0}, new int[] {1, 0, 0, 0, 0}));
root.Add(9025, new SkillGroupData(9025, "", new int[] {902501, 0, 0, 0, 0}, new int[] {1, 0, 0, 0, 0}));
root.Add(9026, new SkillGroupData(9026, "", new int[] {902601, 0, 0, 0, 0}, new int[] {1, 0, 0, 0, 0}));
root.Add(9027, new SkillGroupData(9027, "", new int[] {902701, 0, 0, 0, 0}, new int[] {1, 0, 0, 0, 0}));
}
public SkillGroupData GetReadData(int ID){
if (root.ContainsKey(ID))
return root[ID];
else{
object obj = MMFramework.ModifyExcelModule.Instance.GetModifyedData(ID);
if (obj != null)return obj as SkillGroupData;
Debug.LogError("在表格 SkillGroupData中没有找到ID" + ID);
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
SkillGroupData data = GetReadData(key);
Type type = data.GetType();
System.Reflection.FieldInfo[] filedinfos = type.GetFields();
for (int i = 0; i < filedinfos.Length; i++)
{System.Reflection.FieldInfo field = filedinfos[i];
pairs.Add(field.Name, field.GetValue(data).ToString());}
return pairs;}
}
public static SkillGroupData GetData(int ID){
return SkillGroupDataReader.Instance.GetReadData(ID);
}
public static Dictionary<string, string> GetDictionary(int key)
{ return SkillGroupDataReader.Instance.GetReadDictionary(key);}
public static int GetNum(){
return SkillGroupDataReader.Instance.GetCount();
}
public static List<int> GetKeys(){
return SkillGroupDataReader.Instance.GetDataKeys();
}
public static void SaveToFile(string path){
SkillGroupDataReader.Instance.WriteToFile(path);
}

}