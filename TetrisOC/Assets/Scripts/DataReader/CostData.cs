using System;
using System.Collections.Generic;
using UnityEngine;
[Serializable]
public class CostData{
/// <summary>
/// 花费ID
/// </summary>
public int CostID;
/// <summary>
/// ID
/// </summary>
public int[] IDArray;
/// <summary>
/// 个数
/// </summary>
public int[] NumArray;
public CostData(int CostID, int[] IDArray, int[] NumArray){
this.CostID = CostID;
this.IDArray = IDArray;
this.NumArray = NumArray;
}
class CostDataReader{
static CostDataReader instance;
static object syncRoot = new object();
public static CostDataReader Instance{get{if (instance == null){lock (syncRoot){if (instance == null){instance = new CostDataReader();instance.Load();}}}return instance;}}
Dictionary<int, CostData> root = new Dictionary<int, CostData>();
void Load(){
root.Add(27001, new CostData(27001, new int[] {2000, 3000, 4000}, new int[] {9, 1, 12}));
root.Add(27002, new CostData(27002, new int[] {3000, 0, 0}, new int[] {1, 0, 0}));
root.Add(27003, new CostData(27003, new int[] {2000, 0, 0}, new int[] {1, 0, 0}));
root.Add(27004, new CostData(27004, new int[] {2000, 0, 0}, new int[] {2700, 0, 0}));
root.Add(27005, new CostData(27005, new int[] {2000, 0, 0}, new int[] {300, 0, 0}));
root.Add(27006, new CostData(27006, new int[] {2000, 0, 0}, new int[] {10, 0, 0}));
root.Add(27007, new CostData(27007, new int[] {2000, 0, 0}, new int[] {20, 0, 0}));
root.Add(27008, new CostData(27008, new int[] {2000, 0, 0}, new int[] {30, 0, 0}));
root.Add(27009, new CostData(27009, new int[] {2000, 0, 0}, new int[] {40, 0, 0}));
root.Add(27010, new CostData(27010, new int[] {2000, 0, 0}, new int[] {50, 0, 0}));
root.Add(27011, new CostData(27011, new int[] {2000, 0, 0}, new int[] {60, 0, 0}));
root.Add(27012, new CostData(27012, new int[] {2000, 0, 0}, new int[] {70, 0, 0}));
root.Add(27013, new CostData(27013, new int[] {2000, 0, 0}, new int[] {80, 0, 0}));
root.Add(27014, new CostData(27014, new int[] {2000, 0, 0}, new int[] {90, 0, 0}));
root.Add(27015, new CostData(27015, new int[] {2000, 0, 0}, new int[] {100, 0, 0}));
root.Add(27016, new CostData(27016, new int[] {2000, 0, 0}, new int[] {110, 0, 0}));
root.Add(27017, new CostData(27017, new int[] {2000, 0, 0}, new int[] {120, 0, 0}));
root.Add(27018, new CostData(27018, new int[] {2000, 0, 0}, new int[] {130, 0, 0}));
root.Add(27101, new CostData(27101, new int[] {3000, 0, 0}, new int[] {1, 0, 0}));
root.Add(27102, new CostData(27102, new int[] {3000, 0, 0}, new int[] {20, 0, 0}));
root.Add(27103, new CostData(27103, new int[] {3000, 0, 0}, new int[] {172, 0, 0}));
root.Add(27104, new CostData(27104, new int[] {3000, 0, 0}, new int[] {718, 0, 0}));
root.Add(27105, new CostData(27105, new int[] {3000, 0, 0}, new int[] {2270, 0, 0}));
root.Add(27106, new CostData(27106, new int[] {3000, 0, 0}, new int[] {5520, 0, 0}));
root.Add(27107, new CostData(27107, new int[] {3000, 0, 0}, new int[] {12257, 0, 0}));
root.Add(27108, new CostData(27108, new int[] {3000, 0, 0}, new int[] {22448, 0, 0}));
root.Add(27109, new CostData(27109, new int[] {3000, 0, 0}, new int[] {38646, 0, 0}));
root.Add(27110, new CostData(27110, new int[] {3000, 0, 0}, new int[] {56625, 0, 0}));
root.Add(27111, new CostData(27111, new int[] {3000, 0, 0}, new int[] {81818, 0, 0}));
root.Add(27112, new CostData(27112, new int[] {3000, 0, 0}, new int[] {118523, 0, 0}));
root.Add(27113, new CostData(27113, new int[] {3000, 0, 0}, new int[] {172161, 0, 0}));
root.Add(27114, new CostData(27114, new int[] {3000, 0, 0}, new int[] {252584, 0, 0}));
root.Add(27115, new CostData(27115, new int[] {3000, 0, 0}, new int[] {376358, 0, 0}));
root.Add(27116, new CostData(27116, new int[] {3000, 0, 0}, new int[] {570071, 0, 0}));
root.Add(27117, new CostData(27117, new int[] {3000, 0, 0}, new int[] {877216, 0, 0}));
root.Add(27118, new CostData(27118, new int[] {3000, 0, 0}, new int[] {1370312, 0, 0}));
root.Add(27119, new CostData(27119, new int[] {3000, 0, 0}, new int[] {2165562, 0, 0}));
root.Add(27120, new CostData(27120, new int[] {3000, 0, 0}, new int[] {3452889, 0, 0}));
root.Add(27121, new CostData(27121, new int[] {3000, 0, 0}, new int[] {5541782, 0, 0}));
root.Add(27122, new CostData(27122, new int[] {3000, 0, 0}, new int[] {8345385, 0, 0}));
root.Add(27123, new CostData(27123, new int[] {3000, 0, 0}, new int[] {12875666, 0, 0}));
root.Add(27124, new CostData(27124, new int[] {3000, 0, 0}, new int[] {19921665, 0, 0}));
root.Add(27125, new CostData(27125, new int[] {3000, 0, 0}, new int[] {30875001, 0, 0}));
root.Add(27126, new CostData(27126, new int[] {3000, 0, 0}, new int[] {47890443, 0, 0}));
root.Add(27127, new CostData(27127, new int[] {3000, 0, 0}, new int[] {74301142, 0, 0}));
root.Add(27128, new CostData(27128, new int[] {3000, 0, 0}, new int[] {115258339, 0, 0}));
root.Add(27129, new CostData(27129, new int[] {3000, 0, 0}, new int[] {178716150, 0, 0}));
root.Add(27130, new CostData(27130, new int[] {3000, 0, 0}, new int[] {276946645, 0, 0}));
root.Add(27131, new CostData(27131, new int[] {3000, 0, 0}, new int[] {276946645, 0, 0}));
root.Add(27132, new CostData(27132, new int[] {3000, 0, 0}, new int[] {276946645, 0, 0}));
root.Add(27133, new CostData(27133, new int[] {3000, 0, 0}, new int[] {276946645, 0, 0}));
root.Add(27134, new CostData(27134, new int[] {3000, 0, 0}, new int[] {276946645, 0, 0}));
root.Add(27135, new CostData(27135, new int[] {3000, 0, 0}, new int[] {276946645, 0, 0}));
root.Add(27136, new CostData(27136, new int[] {3000, 0, 0}, new int[] {276946645, 0, 0}));
root.Add(27137, new CostData(27137, new int[] {3000, 0, 0}, new int[] {276946645, 0, 0}));
root.Add(27138, new CostData(27138, new int[] {3000, 0, 0}, new int[] {276946645, 0, 0}));
root.Add(27139, new CostData(27139, new int[] {3000, 0, 0}, new int[] {276946645, 0, 0}));
root.Add(27140, new CostData(27140, new int[] {3000, 0, 0}, new int[] {276946645, 0, 0}));
root.Add(27141, new CostData(27141, new int[] {3000, 0, 0}, new int[] {276946645, 0, 0}));
root.Add(27142, new CostData(27142, new int[] {3000, 0, 0}, new int[] {276946645, 0, 0}));
root.Add(27143, new CostData(27143, new int[] {3000, 0, 0}, new int[] {276946645, 0, 0}));
root.Add(27144, new CostData(27144, new int[] {3000, 0, 0}, new int[] {276946645, 0, 0}));
root.Add(27145, new CostData(27145, new int[] {3000, 0, 0}, new int[] {276946645, 0, 0}));
root.Add(27146, new CostData(27146, new int[] {3000, 0, 0}, new int[] {276946645, 0, 0}));
root.Add(27147, new CostData(27147, new int[] {3000, 0, 0}, new int[] {276946645, 0, 0}));
root.Add(27148, new CostData(27148, new int[] {3000, 0, 0}, new int[] {276946645, 0, 0}));
root.Add(27149, new CostData(27149, new int[] {3000, 0, 0}, new int[] {276946645, 0, 0}));
root.Add(27150, new CostData(27150, new int[] {3000, 0, 0}, new int[] {276946645, 0, 0}));
root.Add(27151, new CostData(27151, new int[] {3000, 0, 0}, new int[] {276946645, 0, 0}));
root.Add(27152, new CostData(27152, new int[] {3000, 0, 0}, new int[] {276946645, 0, 0}));
root.Add(27153, new CostData(27153, new int[] {3000, 0, 0}, new int[] {276946645, 0, 0}));
root.Add(27154, new CostData(27154, new int[] {3000, 0, 0}, new int[] {276946645, 0, 0}));
root.Add(27155, new CostData(27155, new int[] {3000, 0, 0}, new int[] {276946645, 0, 0}));
root.Add(27156, new CostData(27156, new int[] {3000, 0, 0}, new int[] {276946645, 0, 0}));
root.Add(27157, new CostData(27157, new int[] {3000, 0, 0}, new int[] {276946645, 0, 0}));
root.Add(27158, new CostData(27158, new int[] {3000, 0, 0}, new int[] {276946645, 0, 0}));
root.Add(27159, new CostData(27159, new int[] {3000, 0, 0}, new int[] {276946645, 0, 0}));
root.Add(27160, new CostData(27160, new int[] {3000, 0, 0}, new int[] {276946645, 0, 0}));
root.Add(27161, new CostData(27161, new int[] {3000, 0, 0}, new int[] {276946645, 0, 0}));
root.Add(27162, new CostData(27162, new int[] {3000, 0, 0}, new int[] {276946645, 0, 0}));
root.Add(27163, new CostData(27163, new int[] {3000, 0, 0}, new int[] {276946645, 0, 0}));
root.Add(27164, new CostData(27164, new int[] {3000, 0, 0}, new int[] {276946645, 0, 0}));
root.Add(27165, new CostData(27165, new int[] {3000, 0, 0}, new int[] {276946645, 0, 0}));
root.Add(27166, new CostData(27166, new int[] {3000, 0, 0}, new int[] {276946645, 0, 0}));
root.Add(27167, new CostData(27167, new int[] {3000, 0, 0}, new int[] {276946645, 0, 0}));
root.Add(27168, new CostData(27168, new int[] {3000, 0, 0}, new int[] {276946645, 0, 0}));
root.Add(27169, new CostData(27169, new int[] {3000, 0, 0}, new int[] {276946645, 0, 0}));
root.Add(27170, new CostData(27170, new int[] {3000, 0, 0}, new int[] {276946645, 0, 0}));
root.Add(27171, new CostData(27171, new int[] {3000, 0, 0}, new int[] {276946645, 0, 0}));
root.Add(27172, new CostData(27172, new int[] {3000, 0, 0}, new int[] {276946645, 0, 0}));
root.Add(27173, new CostData(27173, new int[] {3000, 0, 0}, new int[] {276946645, 0, 0}));
root.Add(27174, new CostData(27174, new int[] {3000, 0, 0}, new int[] {276946645, 0, 0}));
root.Add(27175, new CostData(27175, new int[] {3000, 0, 0}, new int[] {276946645, 0, 0}));
root.Add(27176, new CostData(27176, new int[] {3000, 0, 0}, new int[] {276946645, 0, 0}));
root.Add(27177, new CostData(27177, new int[] {3000, 0, 0}, new int[] {276946645, 0, 0}));
root.Add(27178, new CostData(27178, new int[] {3000, 0, 0}, new int[] {276946645, 0, 0}));
root.Add(27179, new CostData(27179, new int[] {3000, 0, 0}, new int[] {276946645, 0, 0}));
root.Add(27180, new CostData(27180, new int[] {3000, 0, 0}, new int[] {276946645, 0, 0}));
root.Add(27181, new CostData(27181, new int[] {3000, 0, 0}, new int[] {276946645, 0, 0}));
root.Add(27182, new CostData(27182, new int[] {3000, 0, 0}, new int[] {276946645, 0, 0}));
root.Add(27183, new CostData(27183, new int[] {3000, 0, 0}, new int[] {276946645, 0, 0}));
root.Add(27184, new CostData(27184, new int[] {3000, 0, 0}, new int[] {276946645, 0, 0}));
root.Add(27185, new CostData(27185, new int[] {3000, 0, 0}, new int[] {276946645, 0, 0}));
root.Add(27186, new CostData(27186, new int[] {3000, 0, 0}, new int[] {276946645, 0, 0}));
root.Add(27187, new CostData(27187, new int[] {3000, 0, 0}, new int[] {276946645, 0, 0}));
root.Add(27188, new CostData(27188, new int[] {3000, 0, 0}, new int[] {276946645, 0, 0}));
root.Add(27189, new CostData(27189, new int[] {3000, 0, 0}, new int[] {276946645, 0, 0}));
root.Add(27190, new CostData(27190, new int[] {3000, 0, 0}, new int[] {276946645, 0, 0}));
root.Add(27191, new CostData(27191, new int[] {3000, 0, 0}, new int[] {276946645, 0, 0}));
root.Add(27192, new CostData(27192, new int[] {3000, 0, 0}, new int[] {276946645, 0, 0}));
root.Add(27193, new CostData(27193, new int[] {3000, 0, 0}, new int[] {276946645, 0, 0}));
root.Add(27194, new CostData(27194, new int[] {3000, 0, 0}, new int[] {276946645, 0, 0}));
root.Add(27195, new CostData(27195, new int[] {3000, 0, 0}, new int[] {276946645, 0, 0}));
root.Add(27196, new CostData(27196, new int[] {3000, 0, 0}, new int[] {276946645, 0, 0}));
root.Add(27197, new CostData(27197, new int[] {3000, 0, 0}, new int[] {276946645, 0, 0}));
root.Add(27198, new CostData(27198, new int[] {3000, 0, 0}, new int[] {276946645, 0, 0}));
root.Add(27199, new CostData(27199, new int[] {3000, 0, 0}, new int[] {276946645, 0, 0}));
root.Add(27200, new CostData(27200, new int[] {3000, 0, 0}, new int[] {276946645, 0, 0}));
root.Add(27201, new CostData(27201, new int[] {3000, 0, 0}, new int[] {276946645, 0, 0}));
root.Add(27202, new CostData(27202, new int[] {3000, 0, 0}, new int[] {276946645, 0, 0}));
root.Add(27203, new CostData(27203, new int[] {3000, 0, 0}, new int[] {276946645, 0, 0}));
root.Add(27204, new CostData(27204, new int[] {3000, 0, 0}, new int[] {276946645, 0, 0}));
root.Add(27205, new CostData(27205, new int[] {3000, 0, 0}, new int[] {276946645, 0, 0}));
root.Add(27206, new CostData(27206, new int[] {3000, 0, 0}, new int[] {276946645, 0, 0}));
root.Add(27207, new CostData(27207, new int[] {3000, 0, 0}, new int[] {276946645, 0, 0}));
root.Add(27208, new CostData(27208, new int[] {3000, 0, 0}, new int[] {276946645, 0, 0}));
root.Add(27209, new CostData(27209, new int[] {3000, 0, 0}, new int[] {276946645, 0, 0}));
root.Add(27210, new CostData(27210, new int[] {3000, 0, 0}, new int[] {276946645, 0, 0}));
root.Add(27211, new CostData(27211, new int[] {3000, 0, 0}, new int[] {276946645, 0, 0}));
root.Add(27212, new CostData(27212, new int[] {3000, 0, 0}, new int[] {276946645, 0, 0}));
root.Add(27213, new CostData(27213, new int[] {3000, 0, 0}, new int[] {276946645, 0, 0}));
root.Add(27214, new CostData(27214, new int[] {3000, 0, 0}, new int[] {276946645, 0, 0}));
root.Add(27215, new CostData(27215, new int[] {3000, 0, 0}, new int[] {276946645, 0, 0}));
root.Add(27216, new CostData(27216, new int[] {3000, 0, 0}, new int[] {276946645, 0, 0}));
root.Add(27217, new CostData(27217, new int[] {3000, 0, 0}, new int[] {276946645, 0, 0}));
root.Add(27218, new CostData(27218, new int[] {3000, 0, 0}, new int[] {276946645, 0, 0}));
root.Add(27219, new CostData(27219, new int[] {3000, 0, 0}, new int[] {276946645, 0, 0}));
root.Add(27220, new CostData(27220, new int[] {3000, 0, 0}, new int[] {276946645, 0, 0}));
root.Add(27221, new CostData(27221, new int[] {3000, 0, 0}, new int[] {276946645, 0, 0}));
root.Add(27222, new CostData(27222, new int[] {3000, 0, 0}, new int[] {276946645, 0, 0}));
root.Add(27223, new CostData(27223, new int[] {3000, 0, 0}, new int[] {276946645, 0, 0}));
root.Add(27224, new CostData(27224, new int[] {3000, 0, 0}, new int[] {276946645, 0, 0}));
root.Add(27225, new CostData(27225, new int[] {3000, 0, 0}, new int[] {276946645, 0, 0}));
root.Add(27226, new CostData(27226, new int[] {3000, 0, 0}, new int[] {276946645, 0, 0}));
root.Add(27227, new CostData(27227, new int[] {3000, 0, 0}, new int[] {276946645, 0, 0}));
root.Add(27228, new CostData(27228, new int[] {3000, 0, 0}, new int[] {276946645, 0, 0}));
root.Add(27229, new CostData(27229, new int[] {3000, 0, 0}, new int[] {276946645, 0, 0}));
root.Add(27230, new CostData(27230, new int[] {3000, 0, 0}, new int[] {276946645, 0, 0}));
root.Add(27231, new CostData(27231, new int[] {3000, 0, 0}, new int[] {276946645, 0, 0}));
root.Add(27232, new CostData(27232, new int[] {3000, 0, 0}, new int[] {276946645, 0, 0}));
root.Add(27233, new CostData(27233, new int[] {3000, 0, 0}, new int[] {276946645, 0, 0}));
root.Add(27234, new CostData(27234, new int[] {3000, 0, 0}, new int[] {276946645, 0, 0}));
root.Add(27235, new CostData(27235, new int[] {3000, 0, 0}, new int[] {276946645, 0, 0}));
root.Add(27236, new CostData(27236, new int[] {3000, 0, 0}, new int[] {276946645, 0, 0}));
root.Add(27237, new CostData(27237, new int[] {3000, 0, 0}, new int[] {276946645, 0, 0}));
root.Add(27238, new CostData(27238, new int[] {3000, 0, 0}, new int[] {276946645, 0, 0}));
root.Add(27239, new CostData(27239, new int[] {3000, 0, 0}, new int[] {276946645, 0, 0}));
root.Add(27240, new CostData(27240, new int[] {3000, 0, 0}, new int[] {276946645, 0, 0}));
root.Add(27241, new CostData(27241, new int[] {3000, 0, 0}, new int[] {276946645, 0, 0}));
root.Add(27242, new CostData(27242, new int[] {3000, 0, 0}, new int[] {276946645, 0, 0}));
root.Add(27243, new CostData(27243, new int[] {3000, 0, 0}, new int[] {276946645, 0, 0}));
root.Add(27244, new CostData(27244, new int[] {3000, 0, 0}, new int[] {276946645, 0, 0}));
root.Add(27245, new CostData(27245, new int[] {3000, 0, 0}, new int[] {276946645, 0, 0}));
root.Add(27246, new CostData(27246, new int[] {3000, 0, 0}, new int[] {276946645, 0, 0}));
root.Add(27247, new CostData(27247, new int[] {3000, 0, 0}, new int[] {276946645, 0, 0}));
root.Add(27248, new CostData(27248, new int[] {3000, 0, 0}, new int[] {276946645, 0, 0}));
root.Add(27249, new CostData(27249, new int[] {3000, 0, 0}, new int[] {276946645, 0, 0}));
root.Add(27250, new CostData(27250, new int[] {3000, 0, 0}, new int[] {276946645, 0, 0}));
root.Add(27251, new CostData(27251, new int[] {3000, 0, 0}, new int[] {276946645, 0, 0}));
root.Add(27252, new CostData(27252, new int[] {3000, 0, 0}, new int[] {276946645, 0, 0}));
root.Add(27253, new CostData(27253, new int[] {3000, 0, 0}, new int[] {276946645, 0, 0}));
root.Add(27254, new CostData(27254, new int[] {3000, 0, 0}, new int[] {276946645, 0, 0}));
root.Add(27255, new CostData(27255, new int[] {3000, 0, 0}, new int[] {276946645, 0, 0}));
root.Add(27256, new CostData(27256, new int[] {3000, 0, 0}, new int[] {276946645, 0, 0}));
root.Add(27257, new CostData(27257, new int[] {3000, 0, 0}, new int[] {276946645, 0, 0}));
root.Add(27258, new CostData(27258, new int[] {3000, 0, 0}, new int[] {276946645, 0, 0}));
root.Add(27259, new CostData(27259, new int[] {3000, 0, 0}, new int[] {276946645, 0, 0}));
root.Add(27260, new CostData(27260, new int[] {3000, 0, 0}, new int[] {276946645, 0, 0}));
root.Add(27261, new CostData(27261, new int[] {3000, 0, 0}, new int[] {276946645, 0, 0}));
root.Add(27262, new CostData(27262, new int[] {3000, 0, 0}, new int[] {276946645, 0, 0}));
root.Add(27263, new CostData(27263, new int[] {3000, 0, 0}, new int[] {276946645, 0, 0}));
root.Add(27264, new CostData(27264, new int[] {3000, 0, 0}, new int[] {276946645, 0, 0}));
root.Add(27265, new CostData(27265, new int[] {3000, 0, 0}, new int[] {276946645, 0, 0}));
root.Add(27266, new CostData(27266, new int[] {3000, 0, 0}, new int[] {276946645, 0, 0}));
root.Add(27267, new CostData(27267, new int[] {3000, 0, 0}, new int[] {276946645, 0, 0}));
root.Add(27268, new CostData(27268, new int[] {3000, 0, 0}, new int[] {276946645, 0, 0}));
root.Add(27269, new CostData(27269, new int[] {3000, 0, 0}, new int[] {276946645, 0, 0}));
root.Add(27270, new CostData(27270, new int[] {3000, 0, 0}, new int[] {276946645, 0, 0}));
root.Add(27271, new CostData(27271, new int[] {3000, 0, 0}, new int[] {276946645, 0, 0}));
root.Add(27272, new CostData(27272, new int[] {3000, 0, 0}, new int[] {276946645, 0, 0}));
root.Add(27273, new CostData(27273, new int[] {3000, 0, 0}, new int[] {276946645, 0, 0}));
root.Add(27274, new CostData(27274, new int[] {3000, 0, 0}, new int[] {276946645, 0, 0}));
root.Add(27275, new CostData(27275, new int[] {3000, 0, 0}, new int[] {276946645, 0, 0}));
root.Add(27276, new CostData(27276, new int[] {3000, 0, 0}, new int[] {276946645, 0, 0}));
root.Add(27277, new CostData(27277, new int[] {3000, 0, 0}, new int[] {276946645, 0, 0}));
root.Add(27278, new CostData(27278, new int[] {3000, 0, 0}, new int[] {276946645, 0, 0}));
root.Add(27279, new CostData(27279, new int[] {3000, 0, 0}, new int[] {276946645, 0, 0}));
root.Add(27280, new CostData(27280, new int[] {3000, 0, 0}, new int[] {276946645, 0, 0}));
root.Add(27281, new CostData(27281, new int[] {3000, 0, 0}, new int[] {276946645, 0, 0}));
root.Add(27282, new CostData(27282, new int[] {3000, 0, 0}, new int[] {276946645, 0, 0}));
root.Add(27283, new CostData(27283, new int[] {3000, 0, 0}, new int[] {276946645, 0, 0}));
root.Add(27284, new CostData(27284, new int[] {3000, 0, 0}, new int[] {276946645, 0, 0}));
root.Add(27285, new CostData(27285, new int[] {3000, 0, 0}, new int[] {276946645, 0, 0}));
root.Add(27286, new CostData(27286, new int[] {3000, 0, 0}, new int[] {276946645, 0, 0}));
root.Add(27287, new CostData(27287, new int[] {3000, 0, 0}, new int[] {276946645, 0, 0}));
root.Add(27288, new CostData(27288, new int[] {3000, 0, 0}, new int[] {276946645, 0, 0}));
root.Add(27289, new CostData(27289, new int[] {3000, 0, 0}, new int[] {276946645, 0, 0}));
root.Add(27290, new CostData(27290, new int[] {3000, 0, 0}, new int[] {276946645, 0, 0}));
root.Add(27291, new CostData(27291, new int[] {3000, 0, 0}, new int[] {276946645, 0, 0}));
root.Add(27292, new CostData(27292, new int[] {3000, 0, 0}, new int[] {276946645, 0, 0}));
root.Add(27293, new CostData(27293, new int[] {3000, 0, 0}, new int[] {276946645, 0, 0}));
root.Add(27294, new CostData(27294, new int[] {3000, 0, 0}, new int[] {276946645, 0, 0}));
root.Add(27295, new CostData(27295, new int[] {3000, 0, 0}, new int[] {276946645, 0, 0}));
root.Add(27296, new CostData(27296, new int[] {3000, 0, 0}, new int[] {276946645, 0, 0}));
root.Add(27297, new CostData(27297, new int[] {3000, 0, 0}, new int[] {276946645, 0, 0}));
root.Add(27298, new CostData(27298, new int[] {3000, 0, 0}, new int[] {276946645, 0, 0}));
root.Add(27299, new CostData(27299, new int[] {3000, 0, 0}, new int[] {276946645, 0, 0}));
root.Add(27300, new CostData(27300, new int[] {3000, 0, 0}, new int[] {276946645, 0, 0}));
root.Add(27301, new CostData(27301, new int[] {3000, 0, 0}, new int[] {276946645, 0, 0}));
root.Add(27302, new CostData(27302, new int[] {3000, 0, 0}, new int[] {276946645, 0, 0}));
root.Add(27303, new CostData(27303, new int[] {3000, 0, 0}, new int[] {276946645, 0, 0}));
root.Add(27304, new CostData(27304, new int[] {3000, 0, 0}, new int[] {276946645, 0, 0}));
root.Add(27305, new CostData(27305, new int[] {3000, 0, 0}, new int[] {276946645, 0, 0}));
root.Add(27306, new CostData(27306, new int[] {3000, 0, 0}, new int[] {276946645, 0, 0}));
root.Add(27307, new CostData(27307, new int[] {3000, 0, 0}, new int[] {276946645, 0, 0}));
root.Add(27308, new CostData(27308, new int[] {3000, 0, 0}, new int[] {276946645, 0, 0}));
root.Add(27309, new CostData(27309, new int[] {3000, 0, 0}, new int[] {276946645, 0, 0}));
root.Add(27310, new CostData(27310, new int[] {3000, 0, 0}, new int[] {276946645, 0, 0}));
root.Add(27311, new CostData(27311, new int[] {3000, 0, 0}, new int[] {276946645, 0, 0}));
root.Add(27312, new CostData(27312, new int[] {3000, 0, 0}, new int[] {276946645, 0, 0}));
root.Add(27313, new CostData(27313, new int[] {3000, 0, 0}, new int[] {276946645, 0, 0}));
root.Add(27314, new CostData(27314, new int[] {3000, 0, 0}, new int[] {276946645, 0, 0}));
root.Add(27315, new CostData(27315, new int[] {3000, 0, 0}, new int[] {276946645, 0, 0}));
root.Add(27316, new CostData(27316, new int[] {3000, 0, 0}, new int[] {276946645, 0, 0}));
root.Add(27317, new CostData(27317, new int[] {3000, 0, 0}, new int[] {276946645, 0, 0}));
root.Add(27318, new CostData(27318, new int[] {3000, 0, 0}, new int[] {276946645, 0, 0}));
root.Add(27319, new CostData(27319, new int[] {3000, 0, 0}, new int[] {276946645, 0, 0}));
root.Add(27320, new CostData(27320, new int[] {3000, 0, 0}, new int[] {276946645, 0, 0}));
root.Add(27321, new CostData(27321, new int[] {3000, 0, 0}, new int[] {276946645, 0, 0}));
root.Add(27322, new CostData(27322, new int[] {3000, 0, 0}, new int[] {276946645, 0, 0}));
root.Add(27323, new CostData(27323, new int[] {3000, 0, 0}, new int[] {276946645, 0, 0}));
root.Add(27324, new CostData(27324, new int[] {3000, 0, 0}, new int[] {276946645, 0, 0}));
root.Add(27325, new CostData(27325, new int[] {3000, 0, 0}, new int[] {276946645, 0, 0}));
root.Add(27326, new CostData(27326, new int[] {3000, 0, 0}, new int[] {276946645, 0, 0}));
root.Add(27327, new CostData(27327, new int[] {3000, 0, 0}, new int[] {276946645, 0, 0}));
root.Add(27328, new CostData(27328, new int[] {3000, 0, 0}, new int[] {276946645, 0, 0}));
root.Add(27329, new CostData(27329, new int[] {3000, 0, 0}, new int[] {276946645, 0, 0}));
root.Add(27330, new CostData(27330, new int[] {3000, 0, 0}, new int[] {276946645, 0, 0}));
root.Add(27331, new CostData(27331, new int[] {3000, 0, 0}, new int[] {276946645, 0, 0}));
root.Add(27332, new CostData(27332, new int[] {3000, 0, 0}, new int[] {276946645, 0, 0}));
root.Add(27333, new CostData(27333, new int[] {3000, 0, 0}, new int[] {276946645, 0, 0}));
root.Add(27334, new CostData(27334, new int[] {3000, 0, 0}, new int[] {276946645, 0, 0}));
root.Add(27335, new CostData(27335, new int[] {3000, 0, 0}, new int[] {276946645, 0, 0}));
root.Add(27336, new CostData(27336, new int[] {3000, 0, 0}, new int[] {276946645, 0, 0}));
root.Add(27337, new CostData(27337, new int[] {3000, 0, 0}, new int[] {276946645, 0, 0}));
root.Add(27338, new CostData(27338, new int[] {3000, 0, 0}, new int[] {276946645, 0, 0}));
root.Add(27339, new CostData(27339, new int[] {3000, 0, 0}, new int[] {276946645, 0, 0}));
}
public CostData GetReadData(int ID){
if (root.ContainsKey(ID))
return root[ID];
else{
object obj = MMFramework.ModifyExcelModule.Instance.GetModifyedData(ID);
if (obj != null)return obj as CostData;
Debug.LogError("在表格 CostData中没有找到ID" + ID);
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
CostData data = GetReadData(key);
Type type = data.GetType();
System.Reflection.FieldInfo[] filedinfos = type.GetFields();
for (int i = 0; i < filedinfos.Length; i++)
{System.Reflection.FieldInfo field = filedinfos[i];
pairs.Add(field.Name, field.GetValue(data).ToString());}
return pairs;}
}
public static CostData GetData(int ID){
return CostDataReader.Instance.GetReadData(ID);
}
public static Dictionary<string, string> GetDictionary(int key)
{ return CostDataReader.Instance.GetReadDictionary(key);}
public static int GetNum(){
return CostDataReader.Instance.GetCount();
}
public static List<int> GetKeys(){
return CostDataReader.Instance.GetDataKeys();
}
public static void SaveToFile(string path){
CostDataReader.Instance.WriteToFile(path);
}

}