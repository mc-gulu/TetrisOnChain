using System;
using System.Collections.Generic;
using UnityEngine;
[Serializable]
public class CreatureData{
/// <summary>
/// 序号
/// </summary>
public int ID;
/// <summary>
/// 名字
/// </summary>
public string Name;
/// <summary>
/// 图标路径
/// </summary>
public string IconPath;
/// <summary>
/// 大图标路径
/// </summary>
public string BigIconPath;
/// <summary>
/// 剑盾/狂战/祭司/药剂/法师/弓箭/火枪=1234567
/// </summary>
public int Career;
/// <summary>
/// 火风水光暗物=123456
/// </summary>
public int Element;
/// <summary>
/// 
/// </summary>
public string PrefabPath;
/// <summary>
/// 出生效果
/// </summary>
public int BornDisplayID;
/// <summary>
/// 死亡效果
/// </summary>
public int DieDisplayID;
/// <summary>
/// 最大星级
/// </summary>
public int MaxStar;
/// <summary>
/// 体质组
/// </summary>
public int PhysicsGroupID;
/// <summary>
/// 技能组1主动技
/// </summary>
public int[] SkillGroupArray;
/// <summary>
/// 描述
/// </summary>
public string Desc;
/// <summary>
/// 羁绊列表id
/// </summary>
public int[] BondageArray;
public CreatureData(int ID, string Name, string IconPath, string BigIconPath, int Career, int Element, string PrefabPath, int BornDisplayID, int DieDisplayID, int MaxStar, int PhysicsGroupID, int[] SkillGroupArray, string Desc, int[] BondageArray){
this.ID = ID;
this.Name = Name;
this.IconPath = IconPath;
this.BigIconPath = BigIconPath;
this.Career = Career;
this.Element = Element;
this.PrefabPath = PrefabPath;
this.BornDisplayID = BornDisplayID;
this.DieDisplayID = DieDisplayID;
this.MaxStar = MaxStar;
this.PhysicsGroupID = PhysicsGroupID;
this.SkillGroupArray = SkillGroupArray;
this.Desc = Desc;
this.BondageArray = BondageArray;
}
class CreatureDataReader{
static CreatureDataReader instance;
static object syncRoot = new object();
public static CreatureDataReader Instance{get{if (instance == null){lock (syncRoot){if (instance == null){instance = new CreatureDataReader();instance.Load();}}}return instance;}}
Dictionary<int, CreatureData> root = new Dictionary<int, CreatureData>();
void Load(){
root.Add(6001, new CreatureData(6001, "6001艾萨克 Essac", "Images/UI_icon_610/UI_icon_610_4", "Ase/role/Essac/Essac_0", 1, 3, "Animation/ani_prefabs/role/Essac", 0, 50, 10, 7001, new int[] {8151, 8101, 8003}, "艾萨克 Essac（男）的描述", new int[] {1003, 1006, 3001, 0}));
root.Add(6002, new CreatureData(6002, "6002波波 Bobo", "Images/UI_icon_610/UI_icon_610_4", "Ase/role/Bobo/Bobo_0", 1, 2, "Animation/ani_prefabs/role/Bobo", 0, 50, 10, 7001, new int[] {8152, 8102, 8002}, "波波 Bobo（男）的描述", new int[] {1002, 1006, 3001, 0}));
root.Add(6003, new CreatureData(6003, "6003鲁巴 Nooba", "Images/UI_icon_610/UI_icon_610_4", "Ase/role/Nooba/Nooba_0", 1, 3, "Animation/ani_prefabs/role/Nooba", 0, 50, 10, 7001, new int[] {8153, 8103, 8003}, "鲁巴 Nooba（男）的描述", new int[] {1003, 1006, 3001, 0}));
root.Add(6004, new CreatureData(6004, "6004安迪 Andy", "Images/UI_icon_610/UI_icon_610_4", "Ase/role/Essac/Essac_11", 1, 1, "Animation/ani_prefabs/role/Andy", 0, 50, 10, 7001, new int[] {8154, 8104, 8001}, "安迪 Andy（男）的描述", new int[] {1001, 1006, 3001, 0}));
root.Add(6005, new CreatureData(6005, "6005乌乌WooWoo", "Images/UI_icon_610/UI_icon_610_4", "Ase/role/WooWoo/WooWoo_0", 1, 2, "Animation/ani_prefabs/role/WooWoo", 0, 50, 10, 7001, new int[] {8155, 8105, 8002}, "乌乌WooWoo（男）的描述", new int[] {1002, 0, 3001, 0}));
root.Add(6006, new CreatureData(6006, "6006杜登Duden", "Images/UI_icon_610/UI_icon_610_4", "Ase/role/Essac/Essac_14", 1, 5, "Animation/ani_prefabs/role/Essac", 0, 50, 10, 7001, new int[] {8156, 8106, 8005}, "杜登Duden（男）的描述", new int[] {1005, 0, 3001, 0}));
root.Add(6007, new CreatureData(6007, "6007赫尔墨斯Hermes ", "Images/UI_icon_610/UI_icon_610_4", "Ase/role/Essac/Essac_16", 1, 4, "Animation/ani_prefabs/role/Essac", 0, 50, 10, 7001, new int[] {8157, 8107, 8004}, "赫尔墨斯Hermes （男）的描述", new int[] {1004, 0, 3001, 0}));
root.Add(6008, new CreatureData(6008, "6008埃尔温Erwin", "Images/UI_icon_610/UI_icon_610_6", "Ase/role/Erwin/Erwin_0", 2, 1, "Animation/ani_prefabs/role/Erwin", 0, 50, 10, 7002, new int[] {8158, 8108, 8006}, "埃尔温Erwin（男）的描述", new int[] {1001, 0, 3001, 0}));
root.Add(6009, new CreatureData(6009, "6009多纳特罗Donatello", "Images/UI_icon_610/UI_icon_610_6", "Ase/role/Erwin/Erwin_9", 2, 2, "Animation/ani_prefabs/role/Donatello", 0, 50, 10, 7002, new int[] {8159, 8109, 8007}, "多纳特罗Donatello（男）的描述", new int[] {1002, 0, 3001, 0}));
root.Add(6010, new CreatureData(6010, "6010法比奥Fabio", "Images/UI_icon_610/UI_icon_610_6", "Ase/role/Erwin/Fabio_0", 2, 2, "Animation/ani_prefabs/role/Fabio", 0, 50, 10, 7002, new int[] {8160, 8110, 8007}, "法比奥Fabio（男）的描述", new int[] {1002, 0, 3001, 0}));
root.Add(6011, new CreatureData(6011, "6011尼诺 Nnino", "Images/UI_icon_610/UI_icon_610_6", "Ase/role/Erwin/Erwin_11", 2, 1, "Animation/ani_prefabs/role/Erwin", 0, 50, 10, 7002, new int[] {8161, 8111, 8006}, "尼诺 Nnino（男）的描述", new int[] {1001, 0, 3001, 0}));
root.Add(6012, new CreatureData(6012, "6012诺娃 Nova", "Images/UI_icon_610/UI_icon_610_6", "Ase/role/Nova/Nova_0", 2, 3, "Animation/ani_prefabs/role/Nova", 0, 50, 10, 7002, new int[] {8162, 8112, 8008}, "诺娃 Nova（女）的描述", new int[] {1003, 0, 3001, 0}));
root.Add(6013, new CreatureData(6013, "6013雷纳托Renato", "Images/UI_icon_610/UI_icon_610_6", "Ase/role/Renato/Renato_0", 2, 5, "Animation/ani_prefabs/role/Renato", 0, 50, 10, 7002, new int[] {8163, 8113, 8010}, "雷纳托Renato（男）的描述", new int[] {1005, 0, 3001, 0}));
root.Add(6014, new CreatureData(6014, "6014阿瑞斯Ares", "Images/UI_icon_610/UI_icon_610_6", "Ase/role/Erwin/Erwin_16", 2, 4, "Animation/ani_prefabs/role/Erwin", 0, 50, 10, 7002, new int[] {8164, 8114, 8009}, "阿瑞斯Ares（男）的描述", new int[] {1004, 0, 3001, 0}));
root.Add(6015, new CreatureData(6015, "6015亚历克斯Alex", "Images/UI_icon_610/UI_icon_610_6", "Ase/role/Alex/Alex_0", 3, 4, "Animation/ani_prefabs/role/Alex", 0, 50, 10, 7003, new int[] {8165, 8115, 8019}, "亚历克斯Alex（男）的描述", new int[] {1004, 0, 3001, 0}));
root.Add(6016, new CreatureData(6016, "6016咕噜GuLoo ", "Images/UI_icon_610/UI_icon_610_7", "Ase/role/GuLoo/GuLoo_0", 3, 1, "Animation/ani_prefabs/role/GuLoo", 0, 50, 10, 7003, new int[] {8166, 8115, 8016}, "咕噜GuLoo 男的描述", new int[] {1001, 0, 3001, 0}));
root.Add(6017, new CreatureData(6017, "6017帕克Paco ", "Images/UI_icon_610/UI_icon_610_7", "Ase/role/Paco/Paco_0", 3, 3, "Animation/ani_prefabs/role/Paco", 0, 50, 10, 7003, new int[] {8167, 8115, 8018}, "帕克Paco 男的描述", new int[] {1003, 0, 3001, 0}));
root.Add(6018, new CreatureData(6018, "6018佐伊Zoé ", "Images/UI_icon_610/UI_icon_610_7", "Ase/role/Alex/Alex_11", 3, 3, "Animation/ani_prefabs/role/Alex", 0, 50, 10, 7003, new int[] {8168, 8115, 8018}, "佐伊Zoé （女）的描述", new int[] {1003, 0, 3001, 0}));
root.Add(6019, new CreatureData(6019, "6019法妮Fanny ", "Images/UI_icon_610/UI_icon_610_7", "Ase/role/Fanny/Fanny_0", 3, 5, "Animation/ani_prefabs/role/Fanny", 0, 50, 10, 7003, new int[] {8169, 8115, 8020}, "法妮Fanny （女）的描述", new int[] {1005, 0, 3001, 0}));
root.Add(6020, new CreatureData(6020, "6020米娅 Mia ", "Images/UI_icon_610/UI_icon_610_7", "Ase/role/Alex/Alex_14", 3, 2, "Animation/ani_prefabs/role/Alex", 0, 50, 10, 7003, new int[] {8170, 8115, 8017}, "米娅 Mia （女）的描述", new int[] {1002, 0, 3001, 0}));
root.Add(6021, new CreatureData(6021, "6021赫玛墨涅Heimarmene", "Images/UI_icon_610/UI_icon_610_7", "Ase/role/Alex/Alex_16", 3, 4, "Animation/ani_prefabs/role/Alex", 0, 50, 10, 7003, new int[] {8171, 8115, 8019}, "赫玛墨涅Heimarmene（女）的描述", new int[] {1004, 0, 3001, 0}));
root.Add(6022, new CreatureData(6022, "6022波顿 Burton", "Images/UI_icon_610/UI_icon_610_5", "Ase/role/Burton/Burton_0", 4, 3, "Animation/ani_prefabs/role/Burton", 0, 50, 10, 7004, new int[] {8172, 8117, 8028}, "波顿 Burton（男）的描述", new int[] {1003, 0, 3001, 0}));
root.Add(6023, new CreatureData(6023, "6023翁贝托 Umberto", "Images/UI_icon_610/UI_icon_610_5", "Ase/role/Burton/Burton_9", 4, 5, "Animation/ani_prefabs/role/Burton", 0, 50, 10, 7004, new int[] {8173, 8116, 8030}, "翁贝托 Umberto（男）的描述", new int[] {1005, 0, 3001, 0}));
root.Add(6024, new CreatureData(6024, "6024埃德曼Erdmann", "Images/UI_icon_610/UI_icon_610_5", "Ase/role/Burton/Burton_26", 4, 5, "Animation/ani_prefabs/role/Burton", 0, 50, 10, 7004, new int[] {8174, 8119, 8030}, "埃德曼Erdmann（男）的描述", new int[] {1005, 0, 3001, 0}));
root.Add(6025, new CreatureData(6025, "6025茉茉MoMo ", "Images/UI_icon_610/UI_icon_610_5", "Ase/role/Burton/Burton_11", 4, 3, "Animation/ani_prefabs/role/Burton", 0, 50, 10, 7004, new int[] {8175, 8115, 8028}, "茉茉MoMo （女）的描述", new int[] {1003, 0, 3001, 0}));
root.Add(6026, new CreatureData(6026, "6026银银GinGine ", "Images/UI_icon_610/UI_icon_610_5", "Ase/role/Burton/Burton_13", 4, 1, "Animation/ani_prefabs/role/Burton", 0, 50, 10, 7004, new int[] {8176, 8116, 8026}, "银银GinGine （男）的描述", new int[] {1001, 0, 3001, 0}));
root.Add(6027, new CreatureData(6027, "6027费格森·安森特 Ferguson Ancient", "Images/UI_icon_610/UI_icon_610_5", "Ase/role/Burton/Burton_14", 4, 2, "Animation/ani_prefabs/role/Burton", 0, 50, 10, 7004, new int[] {8177, 8117, 8027}, "费格森·安森特 Ferguson Ancient（男）的描述", new int[] {1002, 0, 3001, 0}));
root.Add(6028, new CreatureData(6028, "6028克里斯汀娜 Christina", "Images/UI_icon_610/UI_icon_610_5", "Ase/role/Burton/Burton_16", 4, 4, "Animation/ani_prefabs/role/Burton", 0, 50, 10, 7004, new int[] {8178, 8118, 8029}, "克里斯汀娜 Christina（女）的描述", new int[] {1004, 0, 3001, 0}));
root.Add(6029, new CreatureData(6029, "6029加布里埃尔 Gabriel", "Images/UI_icon_610/UI_icon_610_7", "Ase/role/Gabriel/Gabriel_0", 5, 1, "Animation/ani_prefabs/role/Gabriel", 0, 50, 10, 7005, new int[] {8179, 8120, 8021}, "加布里埃尔 Gabriel（男）的描述", new int[] {1001, 0, 3001, 0}));
root.Add(6030, new CreatureData(6030, "6030姆噜 Mulu", "Images/UI_icon_610/UI_icon_610_7", "Ase/role/Mulu/Mulu_0", 5, 3, "Animation/ani_prefabs/role/Mulu", 0, 50, 10, 7005, new int[] {8180, 8121, 8023}, "姆噜 Mulu（男）的描述", new int[] {1003, 0, 3001, 0}));
root.Add(6031, new CreatureData(6031, "6031多米尼克Dominic", "Images/UI_icon_610/UI_icon_610_7", "Ase/role/Gabriel/Dominic_0", 5, 4, "Animation/ani_prefabs/role/Dominic", 0, 50, 10, 7005, new int[] {8181, 8122, 8024}, "多米尼克Dominic（男）的描述", new int[] {1004, 0, 3001, 0}));
root.Add(6032, new CreatureData(6032, "6032卡卡Kaka", "Images/UI_icon_610/UI_icon_610_7", "Ase/role/Gabriel/Gabriel_11", 5, 1, "Animation/ani_prefabs/role/Gabriel", 0, 50, 10, 7005, new int[] {8182, 8123, 8021}, "卡卡Kaka（男）的描述", new int[] {1001, 0, 3001, 0}));
root.Add(6033, new CreatureData(6033, "6033碧姬 芭铎 Brigitte Bardot", "Images/UI_icon_610/UI_icon_610_7", "Ase/role/Gabriel/Gabriel_13", 5, 3, "Animation/ani_prefabs/role/Gabriel", 0, 50, 10, 7005, new int[] {8183, 8124, 8023}, "碧姬 芭铎 Brigitte Bardot的描述", new int[] {1003, 0, 3001, 0}));
root.Add(6034, new CreatureData(6034, "6034安东尼Antoine", "Images/UI_icon_610/UI_icon_610_7", "Ase/role/Gabriel/Gabriel_14", 5, 2, "Animation/ani_prefabs/role/Gabriel", 0, 50, 10, 7005, new int[] {8184, 8125, 8022}, "安东尼Antoine（男）的描述", new int[] {1002, 0, 3001, 0}));
root.Add(6035, new CreatureData(6035, "6035阿德拉斯忒亚Adrasteia", "Images/UI_icon_610/UI_icon_610_7", "Ase/role/Gabriel/Gabriel_16", 5, 4, "Animation/ani_prefabs/role/Gabriel", 0, 50, 10, 7005, new int[] {8185, 8126, 8024}, "阿德拉斯忒亚Adrasteia（女）的描述", new int[] {1004, 0, 3001, 0}));
root.Add(6036, new CreatureData(6036, "6036克洛伊Chloé", "Images/UI_icon_610/UI_icon_610_7", "Ase/role/Gabriel/Gabriel_17", 5, 5, "Animation/ani_prefabs/role/Gabriel", 0, 50, 10, 7005, new int[] {8186, 8127, 8025}, "克洛伊Chloé（女）的描述", new int[] {1005, 0, 3001, 0}));
root.Add(6037, new CreatureData(6037, "6037巴克豪斯Backhaus", "Images/UI_icon_610/UI_icon_610_7", "Ase/role/Backhaus/Backhaus_0", 6, 1, "Animation/ani_prefabs/role/Backhaus", 0, 50, 10, 7006, new int[] {8187, 8128, 8011}, "巴克豪斯Backhaus（男）的描述", new int[] {1001, 0, 3001, 0}));
root.Add(6038, new CreatureData(6038, "6038罗宾 Robin", "Images/UI_icon_610/UI_icon_610_7", "Ase/role/Robin/Robin_0", 6, 2, "Animation/ani_prefabs/role/Robin", 0, 50, 10, 7006, new int[] {8188, 8129, 8012}, "罗宾 Robin（男）的描述", new int[] {1002, 0, 3001, 0}));
root.Add(6039, new CreatureData(6039, "6039卡尔 Carl", "Images/UI_icon_610/UI_icon_610_7", "Ase/role/Backhaus/Backhaus_28", 6, 1, "Animation/ani_prefabs/role/Backhaus", 0, 50, 10, 7006, new int[] {8189, 8130, 8011}, "卡尔 Carl（男）的描述", new int[] {1001, 0, 3001, 0}));
root.Add(6040, new CreatureData(6040, "6040巴泽尔 Barzel", "Images/UI_icon_610/UI_icon_610_7", "Ase/role/Barzel/Barzel_0", 6, 3, "Animation/ani_prefabs/role/Barzel", 0, 50, 10, 7006, new int[] {8190, 8131, 8013}, "巴泽尔 Barzel（男）的描述", new int[] {1003, 0, 3001, 0}));
root.Add(6041, new CreatureData(6041, "6041奥兰多 Orlando", "Images/UI_icon_610/UI_icon_610_7", "Ase/role/Backhaus/Backhaus_13", 6, 5, "Animation/ani_prefabs/role/Backhaus", 0, 50, 10, 7006, new int[] {8191, 8132, 8015}, "奥兰多 Orlando（男）的描述", new int[] {1005, 0, 3001, 0}));
root.Add(6042, new CreatureData(6042, "6042娅米露 Amiloo", "Images/UI_icon_610/UI_icon_610_7", "Ase/role/Backhaus/Backhaus_14", 6, 2, "Animation/ani_prefabs/role/Backhaus", 0, 50, 10, 7006, new int[] {8192, 8133, 8012}, "娅米露 Amiloo（女）的描述", new int[] {1002, 0, 3001, 0}));
root.Add(6043, new CreatureData(6043, "6043菲希斯Phusis", "Images/UI_icon_610/UI_icon_610_7", "Ase/role/Backhaus/Backhaus_16", 6, 4, "Animation/ani_prefabs/role/Backhaus", 0, 50, 10, 7006, new int[] {8193, 8134, 8014}, "菲希斯Phusis（女）的描述", new int[] {1004, 0, 3001, 0}));
root.Add(6044, new CreatureData(6044, "6044吉斯莫Gizmo", "Images/UI_icon_610/UI_icon_610_7", "Ase/role/Gizmo/Gizmo_0", 7, 5, "Animation/ani_prefabs/role/Gizmo", 0, 50, 10, 7007, new int[] {8194, 8135, 8035}, "吉斯莫Gizmo（男)的描述", new int[] {1005, 0, 3001, 0}));
root.Add(6045, new CreatureData(6045, "6045夏拉Sarah", "Images/UI_icon_610/UI_icon_610_7", "Ase/role/Sarah/Sarah_0", 7, 3, "Animation/ani_prefabs/role/Sarah", 0, 50, 10, 7007, new int[] {8195, 8136, 8033}, "夏莎Sarah（女）的描述", new int[] {1003, 0, 3001, 0}));
root.Add(6046, new CreatureData(6046, "6046鲍尔Bauer", "Images/UI_icon_610/UI_icon_610_7", "Ase/role/Bauer/Bauer_0", 7, 1, "Animation/ani_prefabs/role/Bauer", 0, 50, 10, 7007, new int[] {8196, 8137, 8031}, "鲍尔Bauer（男)的描述", new int[] {1001, 0, 3001, 0}));
root.Add(6047, new CreatureData(6047, "6047甘布GumBoo", "Images/UI_icon_610/UI_icon_610_7", "Ase/role/GumBoo/GumBoo_0", 7, 2, "Animation/ani_prefabs/role/GumBoo", 0, 50, 10, 7007, new int[] {8197, 8138, 8032}, "甘布GumBoo（男)的描述", new int[] {1002, 0, 3001, 0}));
root.Add(6048, new CreatureData(6048, "6048洛雷托Loreto ", "Images/UI_icon_610/UI_icon_610_7", "Ase/role/Loreto/Loreto_0", 7, 1, "Animation/ani_prefabs/role/Loreto", 0, 50, 10, 7007, new int[] {8198, 8139, 8031}, "洛雷托Loreto （男)的描述", new int[] {1001, 0, 3001, 0}));
root.Add(6049, new CreatureData(6049, "6049米罗Milo ", "Images/UI_icon_610/UI_icon_610_7", "Ase/role/Milo/Milo_0", 7, 5, "Animation/ani_prefabs/role/Milo", 0, 50, 10, 7007, new int[] {8199, 8140, 8035}, "米罗Milo （男)的描述", new int[] {1005, 0, 3001, 0}));
root.Add(6050, new CreatureData(6050, "6050忒希斯Thesis", "Images/UI_icon_610/UI_icon_610_7", "Ase/role/Thesis/Thesis_0", 7, 4, "Animation/ani_prefabs/role/Thesis", 0, 50, 10, 7007, new int[] {8200, 8141, 8034}, "忒希斯Thesis（女）的描述", new int[] {1004, 0, 3001, 0}));
root.Add(6300, new CreatureData(6300, "火狗", "Images/UI_icon_610/UI_icon_610_6", "Ase/role/enemy00/enemy00_0", 0, 1, "Animation/ani_prefabs/enemy/enemy00", 0, 50, 10, 7010, new int[] {0, 0, 9023}, "怪物近战0.5", new int[] {0, 0, 0, 0}));
root.Add(6301, new CreatureData(6301, "火近战守卫兵", "Images/UI_icon_610/UI_icon_610_7", "Ase/role/enemy01/enemy01_0", 0, 1, "Animation/ani_prefabs/enemy/enemy01", 0, 50, 10, 7008, new int[] {0, 0, 9018}, "怪物近战1", new int[] {0, 0, 0, 0}));
root.Add(6302, new CreatureData(6302, "火远战守卫兵", "Images/UI_icon_610/UI_icon_610_4", "Ase/role/enemy02/enemy02_0", 0, 1, "Animation/ani_prefabs/enemy/enemy02", 0, 50, 10, 7009, new int[] {0, 0, 9013}, "怪物火箭", new int[] {0, 0, 0, 0}));
root.Add(6303, new CreatureData(6303, "火boss", "Images/UI_icon_610/UI_icon_610_5", "Ase/role/enemy03/enemy03_0", 0, 1, "Animation/ani_prefabs/enemy/enemy03", 0, 50, 10, 7012, new int[] {0, 0, 9012}, "怪物平A一堆1s", new int[] {0, 0, 0, 0}));
root.Add(6304, new CreatureData(6304, "风狗", "Images/UI_icon_610/UI_icon_610_6", "Ase/role/enemy00/enemy00_0", 0, 2, "Animation/ani_prefabs/enemy/enemy00", 0, 50, 10, 7010, new int[] {0, 0, 9023}, "怪物近战0.5", new int[] {0, 0, 0, 0}));
root.Add(6305, new CreatureData(6305, "风近战守卫兵", "Images/UI_icon_610/UI_icon_610_7", "Ase/role/enemy01/enemy01_0", 0, 2, "Animation/ani_prefabs/enemy/enemy01", 0, 50, 10, 7008, new int[] {0, 0, 9018}, "怪物近战1", new int[] {0, 0, 0, 0}));
root.Add(6306, new CreatureData(6306, "风远战守卫兵", "Images/UI_icon_610/UI_icon_610_4", "Ase/role/enemy02/enemy02_0", 0, 2, "Animation/ani_prefabs/enemy/enemy02", 0, 50, 10, 7009, new int[] {0, 0, 9014}, "怪物风箭", new int[] {0, 0, 0, 0}));
root.Add(6307, new CreatureData(6307, "风boss", "Images/UI_icon_610/UI_icon_610_5", "Ase/role/enemy03/enemy03_0", 0, 2, "Animation/ani_prefabs/enemy/enemy03", 0, 50, 10, 7012, new int[] {0, 0, 9012}, "怪物平A一堆1s", new int[] {0, 0, 0, 0}));
root.Add(6308, new CreatureData(6308, "水狗", "Images/UI_icon_610/UI_icon_610_6", "Ase/role/enemy00/enemy00_0", 0, 3, "Animation/ani_prefabs/enemy/enemy00", 0, 50, 10, 7010, new int[] {0, 0, 9023}, "怪物近战0.5", new int[] {0, 0, 0, 0}));
root.Add(6309, new CreatureData(6309, "水近战守卫兵", "Images/UI_icon_610/UI_icon_610_7", "Ase/role/enemy01/enemy01_0", 0, 3, "Animation/ani_prefabs/enemy/enemy01", 0, 50, 10, 7008, new int[] {0, 0, 9018}, "怪物近战1", new int[] {0, 0, 0, 0}));
root.Add(6310, new CreatureData(6310, "水远战守卫兵", "Images/UI_icon_610/UI_icon_610_4", "Ase/role/enemy02/enemy02_0", 0, 3, "Animation/ani_prefabs/enemy/enemy02", 0, 50, 10, 7009, new int[] {0, 0, 9015}, "怪物水箭", new int[] {0, 0, 0, 0}));
root.Add(6311, new CreatureData(6311, "水boss", "Images/UI_icon_610/UI_icon_610_5", "Ase/role/enemy03/enemy03_0", 0, 4, "Animation/ani_prefabs/enemy/enemy03", 0, 50, 10, 7012, new int[] {0, 0, 9012}, "怪物平A一堆1s", new int[] {0, 0, 0, 0}));
root.Add(6312, new CreatureData(6312, "光狗", "Images/UI_icon_610/UI_icon_610_6", "Ase/role/enemy00/enemy00_0", 0, 4, "Animation/ani_prefabs/enemy/enemy00", 0, 50, 10, 7010, new int[] {0, 0, 9023}, "怪物近战0.5", new int[] {0, 0, 0, 0}));
root.Add(6313, new CreatureData(6313, "光近战守卫兵", "Images/UI_icon_610/UI_icon_610_7", "Ase/role/enemy01/enemy01_0", 0, 4, "Animation/ani_prefabs/enemy/enemy01", 0, 50, 10, 7008, new int[] {0, 0, 9018}, "怪物近战1", new int[] {0, 0, 0, 0}));
root.Add(6314, new CreatureData(6314, "光远战守卫兵", "Images/UI_icon_610/UI_icon_610_4", "Ase/role/enemy02/enemy02_0", 0, 5, "Animation/ani_prefabs/enemy/enemy02", 0, 50, 10, 7009, new int[] {0, 0, 9016}, "怪物光箭", new int[] {0, 0, 0, 0}));
root.Add(6315, new CreatureData(6315, "光boss", "Images/UI_icon_610/UI_icon_610_5", "Ase/role/enemy03/enemy03_0", 0, 4, "Animation/ani_prefabs/enemy/enemy03", 0, 50, 10, 7012, new int[] {0, 0, 9012}, "怪物平A一堆1s", new int[] {0, 0, 0, 0}));
root.Add(6316, new CreatureData(6316, "暗狗", "Images/UI_icon_610/UI_icon_610_6", "Ase/role/enemy00/enemy00_0", 0, 5, "Animation/ani_prefabs/enemy/enemy00", 0, 50, 10, 7010, new int[] {0, 0, 9023}, "怪物近战0.5", new int[] {0, 0, 0, 0}));
root.Add(6317, new CreatureData(6317, "暗近战守卫兵", "Images/UI_icon_610/UI_icon_610_7", "Ase/role/enemy01/enemy01_0", 0, 6, "Animation/ani_prefabs/enemy/enemy01", 0, 50, 10, 7008, new int[] {0, 0, 9018}, "怪物近战1", new int[] {0, 0, 0, 0}));
root.Add(6318, new CreatureData(6318, "暗远战守卫兵", "Images/UI_icon_610/UI_icon_610_4", "Ase/role/enemy02/enemy02_0", 0, 5, "Animation/ani_prefabs/enemy/enemy02", 0, 50, 10, 7009, new int[] {0, 0, 9017}, "怪物暗箭", new int[] {0, 0, 0, 0}));
root.Add(6319, new CreatureData(6319, "暗boss", "Images/UI_icon_610/UI_icon_610_5", "Ase/role/enemy03/enemy03_0", 0, 5, "Animation/ani_prefabs/enemy/enemy03", 0, 50, 10, 7012, new int[] {0, 0, 9012}, "怪物平A一堆1s", new int[] {0, 0, 0, 0}));
}
public CreatureData GetReadData(int ID){
if (root.ContainsKey(ID))
return root[ID];
else{
object obj = MMFramework.ModifyExcelModule.Instance.GetModifyedData(ID);
if (obj != null)return obj as CreatureData;
Debug.LogError("在表格 CreatureData中没有找到ID" + ID);
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
CreatureData data = GetReadData(key);
Type type = data.GetType();
System.Reflection.FieldInfo[] filedinfos = type.GetFields();
for (int i = 0; i < filedinfos.Length; i++)
{System.Reflection.FieldInfo field = filedinfos[i];
pairs.Add(field.Name, field.GetValue(data).ToString());}
return pairs;}
}
public static CreatureData GetData(int ID){
return CreatureDataReader.Instance.GetReadData(ID);
}
public static Dictionary<string, string> GetDictionary(int key)
{ return CreatureDataReader.Instance.GetReadDictionary(key);}
public static int GetNum(){
return CreatureDataReader.Instance.GetCount();
}
public static List<int> GetKeys(){
return CreatureDataReader.Instance.GetDataKeys();
}
public static void SaveToFile(string path){
CreatureDataReader.Instance.WriteToFile(path);
}

}