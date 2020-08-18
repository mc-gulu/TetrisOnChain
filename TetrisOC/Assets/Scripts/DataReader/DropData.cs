using System;
using System.Collections.Generic;
using UnityEngine;
[Serializable]
public class DropData{
/// <summary>
/// 组ID
/// </summary>
public int DropID;
/// <summary>
/// 物品ID
/// </summary>
public int[] IDArray;
/// <summary>
/// 个数
/// </summary>
public int[] NumArray;
public DropData(int DropID, int[] IDArray, int[] NumArray){
this.DropID = DropID;
this.IDArray = IDArray;
this.NumArray = NumArray;
}
class DropDataReader{
static DropDataReader instance;
static object syncRoot = new object();
public static DropDataReader Instance{get{if (instance == null){lock (syncRoot){if (instance == null){instance = new DropDataReader();instance.Load();}}}return instance;}}
Dictionary<int, DropData> root = new Dictionary<int, DropData>();
void Load(){
root.Add(30001, new DropData(30001, new int[] {2000, 30002, 0, 0, 0, 0, 0}, new int[] {1000000, 2, 0, 0, 0, 0, 0}));
root.Add(30002, new DropData(30002, new int[] {0, 0, 0, 0, 0, 0, 0}, new int[] {0, 0, 0, 0, 0, 0, 0}));
root.Add(30003, new DropData(30003, new int[] {0, 0, 0, 0, 0, 0, 0}, new int[] {0, 0, 0, 0, 0, 0, 0}));
root.Add(30004, new DropData(30004, new int[] {0, 0, 0, 0, 0, 0, 0}, new int[] {0, 0, 0, 0, 0, 0, 0}));
root.Add(30005, new DropData(30005, new int[] {0, 0, 0, 0, 0, 0, 0}, new int[] {0, 0, 0, 0, 0, 0, 0}));
root.Add(30006, new DropData(30006, new int[] {0, 0, 0, 0, 0, 0, 0}, new int[] {0, 0, 0, 0, 0, 0, 0}));
root.Add(30007, new DropData(30007, new int[] {41004, 0, 0, 0, 0, 0, 0}, new int[] {10, 0, 0, 0, 0, 0, 0}));
root.Add(30008, new DropData(30008, new int[] {41004, 41005, 0, 0, 0, 0, 0}, new int[] {9, 1, 0, 0, 0, 0, 0}));
root.Add(30009, new DropData(30009, new int[] {41004, 0, 0, 0, 0, 0, 0}, new int[] {1, 0, 0, 0, 0, 0, 0}));
root.Add(30010, new DropData(30010, new int[] {41005, 0, 0, 0, 0, 0, 0}, new int[] {1, 0, 0, 0, 0, 0, 0}));
root.Add(30011, new DropData(30011, new int[] {600103, 600203, 600303, 600403, 600803, 600903, 601003}, new int[] {1, 1, 1, 1, 1, 1, 1}));
root.Add(30012, new DropData(30012, new int[] {601203, 601303, 601503, 601603, 601803, 601903, 602903}, new int[] {1, 1, 1, 1, 1, 1, 1}));
root.Add(30013, new DropData(30013, new int[] {603003, 603103, 604003, 604403, 604503, 604603, 604703}, new int[] {1, 1, 1, 1, 1, 1, 1}));
root.Add(30014, new DropData(30014, new int[] {604803, 604903, 605003, 0, 0, 0, 0}, new int[] {1, 1, 1, 0, 0, 0, 0}));
root.Add(30015, new DropData(30015, new int[] {600104, 600204, 600304, 600404, 600804, 600904, 601004}, new int[] {1, 1, 1, 1, 1, 1, 1}));
root.Add(30016, new DropData(30016, new int[] {601204, 601304, 601504, 601604, 601804, 601904, 602904}, new int[] {1, 1, 1, 1, 1, 1, 1}));
root.Add(30017, new DropData(30017, new int[] {603004, 603104, 604004, 604404, 604504, 604604, 604704}, new int[] {1, 1, 1, 1, 1, 1, 1}));
root.Add(30018, new DropData(30018, new int[] {604804, 604904, 605004, 0, 0, 0, 0}, new int[] {1, 1, 1, 0, 0, 0, 0}));
root.Add(30019, new DropData(30019, new int[] {600105, 600205, 600305, 600405, 600805, 600905, 601005}, new int[] {1, 1, 1, 1, 1, 1, 1}));
root.Add(30020, new DropData(30020, new int[] {601205, 601305, 601505, 601605, 601805, 601905, 602905}, new int[] {1, 1, 1, 1, 1, 1, 1}));
root.Add(30021, new DropData(30021, new int[] {603005, 603105, 604005, 604405, 604505, 604605, 604705}, new int[] {1, 1, 1, 1, 1, 1, 1}));
root.Add(30022, new DropData(30022, new int[] {604805, 604905, 605005, 0, 0, 0, 0}, new int[] {1, 1, 1, 0, 0, 0, 0}));
root.Add(30023, new DropData(30023, new int[] {600106, 600206, 600306, 600406, 600806, 600906, 601006}, new int[] {1, 1, 1, 1, 1, 1, 1}));
root.Add(30024, new DropData(30024, new int[] {601206, 601306, 601506, 601606, 601806, 601906, 602906}, new int[] {1, 1, 1, 1, 1, 1, 1}));
root.Add(30025, new DropData(30025, new int[] {603006, 603106, 604006, 604406, 604506, 604606, 604706}, new int[] {1, 1, 1, 1, 1, 1, 1}));
root.Add(30026, new DropData(30026, new int[] {604806, 604906, 605006, 0, 0, 0, 0}, new int[] {1, 1, 1, 0, 0, 0, 0}));
root.Add(30027, new DropData(30027, new int[] {600103, 0, 0, 0, 0, 0, 0}, new int[] {1, 0, 0, 0, 0, 0, 0}));
root.Add(30100, new DropData(30100, new int[] {41012, 41013, 0, 0, 0, 0, 0}, new int[] {9, 1, 0, 0, 0, 0, 0}));
root.Add(30101, new DropData(30101, new int[] {41012, 41013, 0, 0, 0, 0, 0}, new int[] {8, 2, 0, 0, 0, 0, 0}));
root.Add(30102, new DropData(30102, new int[] {41012, 41013, 0, 0, 0, 0, 0}, new int[] {7, 3, 0, 0, 0, 0, 0}));
root.Add(30103, new DropData(30103, new int[] {41012, 41013, 0, 0, 0, 0, 0}, new int[] {6, 4, 0, 0, 0, 0, 0}));
root.Add(30104, new DropData(30104, new int[] {41012, 41013, 0, 0, 0, 0, 0}, new int[] {5, 5, 0, 0, 0, 0, 0}));
root.Add(30105, new DropData(30105, new int[] {41012, 41013, 0, 0, 0, 0, 0}, new int[] {4, 6, 0, 0, 0, 0, 0}));
root.Add(30106, new DropData(30106, new int[] {41012, 41014, 0, 0, 0, 0, 0}, new int[] {9, 1, 0, 0, 0, 0, 0}));
root.Add(30107, new DropData(30107, new int[] {41012, 41013, 41014, 0, 0, 0, 0}, new int[] {8, 1, 1, 0, 0, 0, 0}));
root.Add(30108, new DropData(30108, new int[] {41012, 41014, 0, 0, 0, 0, 0}, new int[] {8, 2, 0, 0, 0, 0, 0}));
root.Add(30109, new DropData(30109, new int[] {41012, 41013, 41014, 0, 0, 0, 0}, new int[] {7, 2, 1, 0, 0, 0, 0}));
root.Add(30110, new DropData(30110, new int[] {41012, 41013, 41014, 0, 0, 0, 0}, new int[] {7, 1, 2, 0, 0, 0, 0}));
root.Add(30111, new DropData(30111, new int[] {41012, 41013, 41014, 0, 0, 0, 0}, new int[] {6, 3, 1, 0, 0, 0, 0}));
root.Add(30112, new DropData(30112, new int[] {41012, 41013, 41014, 0, 0, 0, 0}, new int[] {6, 2, 2, 0, 0, 0, 0}));
root.Add(30113, new DropData(30113, new int[] {41012, 41013, 41014, 0, 0, 0, 0}, new int[] {6, 1, 3, 0, 0, 0, 0}));
root.Add(30114, new DropData(30114, new int[] {41012, 41014, 0, 0, 0, 0, 0}, new int[] {6, 4, 0, 0, 0, 0, 0}));
root.Add(30115, new DropData(30115, new int[] {41012, 41013, 41014, 0, 0, 0, 0}, new int[] {5, 4, 1, 0, 0, 0, 0}));
root.Add(30116, new DropData(30116, new int[] {41012, 41013, 41014, 0, 0, 0, 0}, new int[] {5, 3, 2, 0, 0, 0, 0}));
root.Add(30117, new DropData(30117, new int[] {41012, 41013, 41014, 0, 0, 0, 0}, new int[] {5, 2, 3, 0, 0, 0, 0}));
root.Add(30118, new DropData(30118, new int[] {41012, 41013, 41014, 0, 0, 0, 0}, new int[] {5, 1, 4, 0, 0, 0, 0}));
root.Add(30119, new DropData(30119, new int[] {41012, 41015, 0, 0, 0, 0, 0}, new int[] {9, 1, 0, 0, 0, 0, 0}));
root.Add(30120, new DropData(30120, new int[] {41012, 41013, 41015, 0, 0, 0, 0}, new int[] {8, 1, 1, 0, 0, 0, 0}));
root.Add(30121, new DropData(30121, new int[] {41012, 41014, 41015, 0, 0, 0, 0}, new int[] {8, 1, 1, 0, 0, 0, 0}));
root.Add(30122, new DropData(30122, new int[] {41012, 41013, 41014, 41015, 0, 0, 0}, new int[] {7, 1, 1, 1, 0, 0, 0}));
root.Add(30123, new DropData(30123, new int[] {41012, 41013, 41015, 0, 0, 0, 0}, new int[] {7, 2, 1, 0, 0, 0, 0}));
root.Add(30124, new DropData(30124, new int[] {41012, 41014, 41015, 0, 0, 0, 0}, new int[] {7, 2, 1, 0, 0, 0, 0}));
root.Add(30125, new DropData(30125, new int[] {41012, 41013, 41015, 0, 0, 0, 0}, new int[] {7, 1, 2, 0, 0, 0, 0}));
root.Add(30126, new DropData(30126, new int[] {41012, 41014, 41015, 0, 0, 0, 0}, new int[] {7, 1, 2, 0, 0, 0, 0}));
root.Add(30127, new DropData(30127, new int[] {41012, 41015, 0, 0, 0, 0, 0}, new int[] {7, 3, 0, 0, 0, 0, 0}));
root.Add(30128, new DropData(30128, new int[] {41012, 41013, 41014, 41015, 0, 0, 0}, new int[] {6, 1, 2, 1, 0, 0, 0}));
root.Add(30129, new DropData(30129, new int[] {41012, 41013, 41014, 41015, 0, 0, 0}, new int[] {6, 2, 1, 1, 0, 0, 0}));
root.Add(30130, new DropData(30130, new int[] {41012, 41013, 41015, 0, 0, 0, 0}, new int[] {6, 3, 1, 0, 0, 0, 0}));
root.Add(30131, new DropData(30131, new int[] {41012, 41014, 41015, 0, 0, 0, 0}, new int[] {6, 3, 1, 0, 0, 0, 0}));
root.Add(30132, new DropData(30132, new int[] {41012, 41013, 41014, 41015, 0, 0, 0}, new int[] {6, 1, 1, 2, 0, 0, 0}));
root.Add(30133, new DropData(30133, new int[] {41012, 41013, 41015, 0, 0, 0, 0}, new int[] {6, 2, 2, 0, 0, 0, 0}));
root.Add(30134, new DropData(30134, new int[] {41012, 41014, 41015, 0, 0, 0, 0}, new int[] {6, 2, 2, 0, 0, 0, 0}));
root.Add(30135, new DropData(30135, new int[] {41012, 41013, 41015, 0, 0, 0, 0}, new int[] {6, 1, 3, 0, 0, 0, 0}));
root.Add(30136, new DropData(30136, new int[] {41012, 41014, 41015, 0, 0, 0, 0}, new int[] {6, 1, 3, 0, 0, 0, 0}));
root.Add(30200, new DropData(30200, new int[] {5000, 0, 0, 0, 0, 0, 0}, new int[] {3, 0, 0, 0, 0, 0, 0}));
root.Add(30201, new DropData(30201, new int[] {30011, 30012, 30013, 30014, 0, 0, 0}, new int[] {1, 1, 1, 1, 0, 0, 0}));
root.Add(30202, new DropData(30202, new int[] {0, 0, 0, 0, 0, 0, 0}, new int[] {0, 0, 0, 0, 0, 0, 0}));
root.Add(30203, new DropData(30203, new int[] {0, 0, 0, 0, 0, 0, 0}, new int[] {0, 0, 0, 0, 0, 0, 0}));
root.Add(30204, new DropData(30204, new int[] {0, 0, 0, 0, 0, 0, 0}, new int[] {0, 0, 0, 0, 0, 0, 0}));
root.Add(30205, new DropData(30205, new int[] {2000, 0, 0, 0, 0, 0, 0}, new int[] {3000, 0, 0, 0, 0, 0, 0}));
root.Add(30206, new DropData(30206, new int[] {2000, 0, 0, 0, 0, 0, 0}, new int[] {3000, 0, 0, 0, 0, 0, 0}));
root.Add(30207, new DropData(30207, new int[] {2000, 0, 0, 0, 0, 0, 0}, new int[] {3000, 0, 0, 0, 0, 0, 0}));
root.Add(30208, new DropData(30208, new int[] {2000, 0, 0, 0, 0, 0, 0}, new int[] {3000, 0, 0, 0, 0, 0, 0}));
root.Add(30209, new DropData(30209, new int[] {2000, 0, 0, 0, 0, 0, 0}, new int[] {3000, 0, 0, 0, 0, 0, 0}));
root.Add(30210, new DropData(30210, new int[] {2000, 0, 0, 0, 0, 0, 0}, new int[] {3000, 0, 0, 0, 0, 0, 0}));
root.Add(30211, new DropData(30211, new int[] {2000, 0, 0, 0, 0, 0, 0}, new int[] {3000, 0, 0, 0, 0, 0, 0}));
root.Add(30301, new DropData(30301, new int[] {2000, 0, 0, 0, 0, 0, 0}, new int[] {100, 0, 0, 0, 0, 0, 0}));
root.Add(30302, new DropData(30302, new int[] {2000, 3000, 0, 0, 0, 0, 0}, new int[] {100, 1000, 0, 0, 0, 0, 0}));
root.Add(30303, new DropData(30303, new int[] {2000, 0, 0, 0, 0, 0, 0}, new int[] {100, 0, 0, 0, 0, 0, 0}));
root.Add(30304, new DropData(30304, new int[] {2000, 600803, 0, 0, 0, 0, 0}, new int[] {100, 1, 0, 0, 0, 0, 0}));
root.Add(30305, new DropData(30305, new int[] {2000, 0, 0, 0, 0, 0, 0}, new int[] {100, 0, 0, 0, 0, 0, 0}));
root.Add(30306, new DropData(30306, new int[] {2000, 0, 0, 0, 0, 0, 0}, new int[] {100, 0, 0, 0, 0, 0, 0}));
root.Add(30307, new DropData(30307, new int[] {2000, 0, 0, 0, 0, 0, 0}, new int[] {100, 0, 0, 0, 0, 0, 0}));
root.Add(30308, new DropData(30308, new int[] {2000, 0, 0, 0, 0, 0, 0}, new int[] {100, 0, 0, 0, 0, 0, 0}));
root.Add(30309, new DropData(30309, new int[] {2000, 0, 0, 0, 0, 0, 0}, new int[] {100, 0, 0, 0, 0, 0, 0}));
root.Add(30310, new DropData(30310, new int[] {2000, 0, 0, 0, 0, 0, 0}, new int[] {100, 0, 0, 0, 0, 0, 0}));
root.Add(30311, new DropData(30311, new int[] {2000, 0, 0, 0, 0, 0, 0}, new int[] {100, 0, 0, 0, 0, 0, 0}));
root.Add(30312, new DropData(30312, new int[] {2000, 0, 0, 0, 0, 0, 0}, new int[] {100, 0, 0, 0, 0, 0, 0}));
root.Add(30313, new DropData(30313, new int[] {2000, 0, 0, 0, 0, 0, 0}, new int[] {100, 0, 0, 0, 0, 0, 0}));
root.Add(30314, new DropData(30314, new int[] {2000, 0, 0, 0, 0, 0, 0}, new int[] {100, 0, 0, 0, 0, 0, 0}));
root.Add(30315, new DropData(30315, new int[] {2000, 0, 0, 0, 0, 0, 0}, new int[] {100, 0, 0, 0, 0, 0, 0}));
root.Add(30316, new DropData(30316, new int[] {2000, 0, 0, 0, 0, 0, 0}, new int[] {100, 0, 0, 0, 0, 0, 0}));
root.Add(30317, new DropData(30317, new int[] {2000, 0, 0, 0, 0, 0, 0}, new int[] {100, 0, 0, 0, 0, 0, 0}));
root.Add(30318, new DropData(30318, new int[] {2000, 0, 0, 0, 0, 0, 0}, new int[] {100, 0, 0, 0, 0, 0, 0}));
root.Add(30319, new DropData(30319, new int[] {2000, 0, 0, 0, 0, 0, 0}, new int[] {100, 0, 0, 0, 0, 0, 0}));
root.Add(30320, new DropData(30320, new int[] {2000, 0, 0, 0, 0, 0, 0}, new int[] {100, 0, 0, 0, 0, 0, 0}));
root.Add(30321, new DropData(30321, new int[] {2000, 0, 0, 0, 0, 0, 0}, new int[] {100, 0, 0, 0, 0, 0, 0}));
root.Add(30322, new DropData(30322, new int[] {2000, 0, 0, 0, 0, 0, 0}, new int[] {100, 0, 0, 0, 0, 0, 0}));
root.Add(30323, new DropData(30323, new int[] {2000, 0, 0, 0, 0, 0, 0}, new int[] {100, 0, 0, 0, 0, 0, 0}));
root.Add(30324, new DropData(30324, new int[] {2000, 0, 0, 0, 0, 0, 0}, new int[] {100, 0, 0, 0, 0, 0, 0}));
root.Add(30325, new DropData(30325, new int[] {2000, 0, 0, 0, 0, 0, 0}, new int[] {100, 0, 0, 0, 0, 0, 0}));
root.Add(30326, new DropData(30326, new int[] {2000, 0, 0, 0, 0, 0, 0}, new int[] {100, 0, 0, 0, 0, 0, 0}));
root.Add(30327, new DropData(30327, new int[] {2000, 0, 0, 0, 0, 0, 0}, new int[] {100, 0, 0, 0, 0, 0, 0}));
root.Add(30328, new DropData(30328, new int[] {2000, 0, 0, 0, 0, 0, 0}, new int[] {100, 0, 0, 0, 0, 0, 0}));
root.Add(30329, new DropData(30329, new int[] {2000, 0, 0, 0, 0, 0, 0}, new int[] {100, 0, 0, 0, 0, 0, 0}));
root.Add(30330, new DropData(30330, new int[] {2000, 0, 0, 0, 0, 0, 0}, new int[] {100, 0, 0, 0, 0, 0, 0}));
root.Add(30331, new DropData(30331, new int[] {2000, 0, 0, 0, 0, 0, 0}, new int[] {100, 0, 0, 0, 0, 0, 0}));
root.Add(30332, new DropData(30332, new int[] {2000, 0, 0, 0, 0, 0, 0}, new int[] {100, 0, 0, 0, 0, 0, 0}));
root.Add(30333, new DropData(30333, new int[] {2000, 0, 0, 0, 0, 0, 0}, new int[] {100, 0, 0, 0, 0, 0, 0}));
root.Add(30334, new DropData(30334, new int[] {2000, 0, 0, 0, 0, 0, 0}, new int[] {100, 0, 0, 0, 0, 0, 0}));
root.Add(30335, new DropData(30335, new int[] {2000, 0, 0, 0, 0, 0, 0}, new int[] {100, 0, 0, 0, 0, 0, 0}));
root.Add(30336, new DropData(30336, new int[] {2000, 0, 0, 0, 0, 0, 0}, new int[] {100, 0, 0, 0, 0, 0, 0}));
root.Add(30337, new DropData(30337, new int[] {2000, 0, 0, 0, 0, 0, 0}, new int[] {100, 0, 0, 0, 0, 0, 0}));
root.Add(30338, new DropData(30338, new int[] {2000, 0, 0, 0, 0, 0, 0}, new int[] {100, 0, 0, 0, 0, 0, 0}));
root.Add(30339, new DropData(30339, new int[] {2000, 0, 0, 0, 0, 0, 0}, new int[] {100, 0, 0, 0, 0, 0, 0}));
root.Add(30340, new DropData(30340, new int[] {2000, 0, 0, 0, 0, 0, 0}, new int[] {100, 0, 0, 0, 0, 0, 0}));
root.Add(30341, new DropData(30341, new int[] {2000, 0, 0, 0, 0, 0, 0}, new int[] {100, 0, 0, 0, 0, 0, 0}));
root.Add(30342, new DropData(30342, new int[] {2000, 0, 0, 0, 0, 0, 0}, new int[] {100, 0, 0, 0, 0, 0, 0}));
root.Add(30343, new DropData(30343, new int[] {2000, 0, 0, 0, 0, 0, 0}, new int[] {100, 0, 0, 0, 0, 0, 0}));
root.Add(30344, new DropData(30344, new int[] {2000, 0, 0, 0, 0, 0, 0}, new int[] {100, 0, 0, 0, 0, 0, 0}));
root.Add(30345, new DropData(30345, new int[] {2000, 0, 0, 0, 0, 0, 0}, new int[] {100, 0, 0, 0, 0, 0, 0}));
root.Add(30346, new DropData(30346, new int[] {2000, 0, 0, 0, 0, 0, 0}, new int[] {100, 0, 0, 0, 0, 0, 0}));
root.Add(30347, new DropData(30347, new int[] {2000, 0, 0, 0, 0, 0, 0}, new int[] {100, 0, 0, 0, 0, 0, 0}));
root.Add(30348, new DropData(30348, new int[] {2000, 0, 0, 0, 0, 0, 0}, new int[] {100, 0, 0, 0, 0, 0, 0}));
root.Add(30349, new DropData(30349, new int[] {2000, 0, 0, 0, 0, 0, 0}, new int[] {100, 0, 0, 0, 0, 0, 0}));
root.Add(30350, new DropData(30350, new int[] {2000, 0, 0, 0, 0, 0, 0}, new int[] {100, 0, 0, 0, 0, 0, 0}));
root.Add(30351, new DropData(30351, new int[] {2000, 0, 0, 0, 0, 0, 0}, new int[] {100, 0, 0, 0, 0, 0, 0}));
root.Add(30352, new DropData(30352, new int[] {2000, 0, 0, 0, 0, 0, 0}, new int[] {100, 0, 0, 0, 0, 0, 0}));
root.Add(30353, new DropData(30353, new int[] {2000, 0, 0, 0, 0, 0, 0}, new int[] {100, 0, 0, 0, 0, 0, 0}));
root.Add(30354, new DropData(30354, new int[] {2000, 0, 0, 0, 0, 0, 0}, new int[] {100, 0, 0, 0, 0, 0, 0}));
root.Add(30355, new DropData(30355, new int[] {2000, 0, 0, 0, 0, 0, 0}, new int[] {100, 0, 0, 0, 0, 0, 0}));
root.Add(30356, new DropData(30356, new int[] {2000, 0, 0, 0, 0, 0, 0}, new int[] {100, 0, 0, 0, 0, 0, 0}));
root.Add(30357, new DropData(30357, new int[] {2000, 0, 0, 0, 0, 0, 0}, new int[] {100, 0, 0, 0, 0, 0, 0}));
root.Add(30358, new DropData(30358, new int[] {2000, 0, 0, 0, 0, 0, 0}, new int[] {100, 0, 0, 0, 0, 0, 0}));
root.Add(30359, new DropData(30359, new int[] {2000, 0, 0, 0, 0, 0, 0}, new int[] {100, 0, 0, 0, 0, 0, 0}));
root.Add(30360, new DropData(30360, new int[] {2000, 0, 0, 0, 0, 0, 0}, new int[] {100, 0, 0, 0, 0, 0, 0}));
root.Add(30361, new DropData(30361, new int[] {2000, 0, 0, 0, 0, 0, 0}, new int[] {100, 0, 0, 0, 0, 0, 0}));
root.Add(30362, new DropData(30362, new int[] {2000, 0, 0, 0, 0, 0, 0}, new int[] {100, 0, 0, 0, 0, 0, 0}));
root.Add(30363, new DropData(30363, new int[] {2000, 0, 0, 0, 0, 0, 0}, new int[] {100, 0, 0, 0, 0, 0, 0}));
root.Add(30364, new DropData(30364, new int[] {2000, 0, 0, 0, 0, 0, 0}, new int[] {100, 0, 0, 0, 0, 0, 0}));
root.Add(30365, new DropData(30365, new int[] {2000, 0, 0, 0, 0, 0, 0}, new int[] {100, 0, 0, 0, 0, 0, 0}));
root.Add(30366, new DropData(30366, new int[] {2000, 0, 0, 0, 0, 0, 0}, new int[] {100, 0, 0, 0, 0, 0, 0}));
root.Add(30367, new DropData(30367, new int[] {2000, 0, 0, 0, 0, 0, 0}, new int[] {100, 0, 0, 0, 0, 0, 0}));
root.Add(30368, new DropData(30368, new int[] {2000, 0, 0, 0, 0, 0, 0}, new int[] {100, 0, 0, 0, 0, 0, 0}));
root.Add(30369, new DropData(30369, new int[] {2000, 0, 0, 0, 0, 0, 0}, new int[] {100, 0, 0, 0, 0, 0, 0}));
root.Add(30370, new DropData(30370, new int[] {2000, 0, 0, 0, 0, 0, 0}, new int[] {100, 0, 0, 0, 0, 0, 0}));
root.Add(30371, new DropData(30371, new int[] {2000, 0, 0, 0, 0, 0, 0}, new int[] {100, 0, 0, 0, 0, 0, 0}));
root.Add(30372, new DropData(30372, new int[] {2000, 0, 0, 0, 0, 0, 0}, new int[] {100, 0, 0, 0, 0, 0, 0}));
root.Add(30373, new DropData(30373, new int[] {2000, 0, 0, 0, 0, 0, 0}, new int[] {100, 0, 0, 0, 0, 0, 0}));
root.Add(30374, new DropData(30374, new int[] {2000, 0, 0, 0, 0, 0, 0}, new int[] {100, 0, 0, 0, 0, 0, 0}));
root.Add(30375, new DropData(30375, new int[] {2000, 0, 0, 0, 0, 0, 0}, new int[] {100, 0, 0, 0, 0, 0, 0}));
root.Add(30376, new DropData(30376, new int[] {2000, 0, 0, 0, 0, 0, 0}, new int[] {100, 0, 0, 0, 0, 0, 0}));
root.Add(30377, new DropData(30377, new int[] {2000, 0, 0, 0, 0, 0, 0}, new int[] {100, 0, 0, 0, 0, 0, 0}));
root.Add(30378, new DropData(30378, new int[] {2000, 0, 0, 0, 0, 0, 0}, new int[] {100, 0, 0, 0, 0, 0, 0}));
root.Add(30379, new DropData(30379, new int[] {2000, 0, 0, 0, 0, 0, 0}, new int[] {100, 0, 0, 0, 0, 0, 0}));
root.Add(30380, new DropData(30380, new int[] {2000, 0, 0, 0, 0, 0, 0}, new int[] {100, 0, 0, 0, 0, 0, 0}));
root.Add(30381, new DropData(30381, new int[] {2000, 0, 0, 0, 0, 0, 0}, new int[] {100, 0, 0, 0, 0, 0, 0}));
root.Add(30382, new DropData(30382, new int[] {2000, 0, 0, 0, 0, 0, 0}, new int[] {100, 0, 0, 0, 0, 0, 0}));
root.Add(30383, new DropData(30383, new int[] {2000, 0, 0, 0, 0, 0, 0}, new int[] {100, 0, 0, 0, 0, 0, 0}));
root.Add(30384, new DropData(30384, new int[] {2000, 0, 0, 0, 0, 0, 0}, new int[] {100, 0, 0, 0, 0, 0, 0}));
root.Add(30385, new DropData(30385, new int[] {2000, 0, 0, 0, 0, 0, 0}, new int[] {100, 0, 0, 0, 0, 0, 0}));
root.Add(30386, new DropData(30386, new int[] {2000, 0, 0, 0, 0, 0, 0}, new int[] {100, 0, 0, 0, 0, 0, 0}));
root.Add(30387, new DropData(30387, new int[] {2000, 0, 0, 0, 0, 0, 0}, new int[] {100, 0, 0, 0, 0, 0, 0}));
root.Add(30388, new DropData(30388, new int[] {2000, 0, 0, 0, 0, 0, 0}, new int[] {100, 0, 0, 0, 0, 0, 0}));
root.Add(30389, new DropData(30389, new int[] {2000, 0, 0, 0, 0, 0, 0}, new int[] {100, 0, 0, 0, 0, 0, 0}));
root.Add(30390, new DropData(30390, new int[] {2000, 0, 0, 0, 0, 0, 0}, new int[] {100, 0, 0, 0, 0, 0, 0}));
root.Add(30391, new DropData(30391, new int[] {2000, 0, 0, 0, 0, 0, 0}, new int[] {100, 0, 0, 0, 0, 0, 0}));
root.Add(30392, new DropData(30392, new int[] {2000, 0, 0, 0, 0, 0, 0}, new int[] {100, 0, 0, 0, 0, 0, 0}));
root.Add(30393, new DropData(30393, new int[] {2000, 0, 0, 0, 0, 0, 0}, new int[] {100, 0, 0, 0, 0, 0, 0}));
root.Add(30394, new DropData(30394, new int[] {2000, 0, 0, 0, 0, 0, 0}, new int[] {100, 0, 0, 0, 0, 0, 0}));
root.Add(30395, new DropData(30395, new int[] {2000, 0, 0, 0, 0, 0, 0}, new int[] {100, 0, 0, 0, 0, 0, 0}));
root.Add(30396, new DropData(30396, new int[] {2000, 0, 0, 0, 0, 0, 0}, new int[] {100, 0, 0, 0, 0, 0, 0}));
root.Add(30397, new DropData(30397, new int[] {2000, 0, 0, 0, 0, 0, 0}, new int[] {100, 0, 0, 0, 0, 0, 0}));
root.Add(30398, new DropData(30398, new int[] {2000, 0, 0, 0, 0, 0, 0}, new int[] {100, 0, 0, 0, 0, 0, 0}));
root.Add(30399, new DropData(30399, new int[] {2000, 0, 0, 0, 0, 0, 0}, new int[] {100, 0, 0, 0, 0, 0, 0}));
root.Add(30400, new DropData(30400, new int[] {2000, 0, 0, 0, 0, 0, 0}, new int[] {100, 0, 0, 0, 0, 0, 0}));
root.Add(30401, new DropData(30401, new int[] {2000, 0, 0, 0, 0, 0, 0}, new int[] {100, 0, 0, 0, 0, 0, 0}));
root.Add(30402, new DropData(30402, new int[] {2000, 0, 0, 0, 0, 0, 0}, new int[] {100, 0, 0, 0, 0, 0, 0}));
root.Add(30403, new DropData(30403, new int[] {2000, 0, 0, 0, 0, 0, 0}, new int[] {100, 0, 0, 0, 0, 0, 0}));
root.Add(30404, new DropData(30404, new int[] {2000, 0, 0, 0, 0, 0, 0}, new int[] {100, 0, 0, 0, 0, 0, 0}));
root.Add(30405, new DropData(30405, new int[] {2000, 0, 0, 0, 0, 0, 0}, new int[] {100, 0, 0, 0, 0, 0, 0}));
root.Add(30406, new DropData(30406, new int[] {2000, 0, 0, 0, 0, 0, 0}, new int[] {100, 0, 0, 0, 0, 0, 0}));
root.Add(30407, new DropData(30407, new int[] {2000, 0, 0, 0, 0, 0, 0}, new int[] {100, 0, 0, 0, 0, 0, 0}));
root.Add(30408, new DropData(30408, new int[] {2000, 0, 0, 0, 0, 0, 0}, new int[] {100, 0, 0, 0, 0, 0, 0}));
root.Add(30409, new DropData(30409, new int[] {2000, 0, 0, 0, 0, 0, 0}, new int[] {100, 0, 0, 0, 0, 0, 0}));
root.Add(30410, new DropData(30410, new int[] {2000, 0, 0, 0, 0, 0, 0}, new int[] {100, 0, 0, 0, 0, 0, 0}));
root.Add(30411, new DropData(30411, new int[] {2000, 0, 0, 0, 0, 0, 0}, new int[] {100, 0, 0, 0, 0, 0, 0}));
root.Add(30412, new DropData(30412, new int[] {2000, 0, 0, 0, 0, 0, 0}, new int[] {100, 0, 0, 0, 0, 0, 0}));
root.Add(30413, new DropData(30413, new int[] {2000, 0, 0, 0, 0, 0, 0}, new int[] {100, 0, 0, 0, 0, 0, 0}));
root.Add(30414, new DropData(30414, new int[] {2000, 0, 0, 0, 0, 0, 0}, new int[] {100, 0, 0, 0, 0, 0, 0}));
root.Add(30415, new DropData(30415, new int[] {2000, 0, 0, 0, 0, 0, 0}, new int[] {100, 0, 0, 0, 0, 0, 0}));
root.Add(30416, new DropData(30416, new int[] {2000, 0, 0, 0, 0, 0, 0}, new int[] {100, 0, 0, 0, 0, 0, 0}));
root.Add(30417, new DropData(30417, new int[] {2000, 0, 0, 0, 0, 0, 0}, new int[] {100, 0, 0, 0, 0, 0, 0}));
root.Add(30418, new DropData(30418, new int[] {2000, 0, 0, 0, 0, 0, 0}, new int[] {100, 0, 0, 0, 0, 0, 0}));
root.Add(30419, new DropData(30419, new int[] {2000, 0, 0, 0, 0, 0, 0}, new int[] {100, 0, 0, 0, 0, 0, 0}));
root.Add(30420, new DropData(30420, new int[] {2000, 0, 0, 0, 0, 0, 0}, new int[] {100, 0, 0, 0, 0, 0, 0}));
root.Add(30421, new DropData(30421, new int[] {2000, 0, 0, 0, 0, 0, 0}, new int[] {100, 0, 0, 0, 0, 0, 0}));
root.Add(30422, new DropData(30422, new int[] {2000, 0, 0, 0, 0, 0, 0}, new int[] {100, 0, 0, 0, 0, 0, 0}));
root.Add(30423, new DropData(30423, new int[] {2000, 0, 0, 0, 0, 0, 0}, new int[] {100, 0, 0, 0, 0, 0, 0}));
root.Add(30424, new DropData(30424, new int[] {2000, 0, 0, 0, 0, 0, 0}, new int[] {100, 0, 0, 0, 0, 0, 0}));
root.Add(30425, new DropData(30425, new int[] {2000, 0, 0, 0, 0, 0, 0}, new int[] {100, 0, 0, 0, 0, 0, 0}));
root.Add(30426, new DropData(30426, new int[] {2000, 0, 0, 0, 0, 0, 0}, new int[] {100, 0, 0, 0, 0, 0, 0}));
root.Add(30427, new DropData(30427, new int[] {2000, 0, 0, 0, 0, 0, 0}, new int[] {100, 0, 0, 0, 0, 0, 0}));
root.Add(30428, new DropData(30428, new int[] {2000, 0, 0, 0, 0, 0, 0}, new int[] {100, 0, 0, 0, 0, 0, 0}));
root.Add(30429, new DropData(30429, new int[] {2000, 0, 0, 0, 0, 0, 0}, new int[] {100, 0, 0, 0, 0, 0, 0}));
root.Add(30430, new DropData(30430, new int[] {2000, 0, 0, 0, 0, 0, 0}, new int[] {100, 0, 0, 0, 0, 0, 0}));
root.Add(30431, new DropData(30431, new int[] {2000, 0, 0, 0, 0, 0, 0}, new int[] {100, 0, 0, 0, 0, 0, 0}));
root.Add(30432, new DropData(30432, new int[] {2000, 0, 0, 0, 0, 0, 0}, new int[] {100, 0, 0, 0, 0, 0, 0}));
root.Add(30433, new DropData(30433, new int[] {2000, 0, 0, 0, 0, 0, 0}, new int[] {100, 0, 0, 0, 0, 0, 0}));
root.Add(30434, new DropData(30434, new int[] {2000, 0, 0, 0, 0, 0, 0}, new int[] {100, 0, 0, 0, 0, 0, 0}));
root.Add(30435, new DropData(30435, new int[] {2000, 0, 0, 0, 0, 0, 0}, new int[] {100, 0, 0, 0, 0, 0, 0}));
root.Add(30436, new DropData(30436, new int[] {2000, 0, 0, 0, 0, 0, 0}, new int[] {100, 0, 0, 0, 0, 0, 0}));
root.Add(30437, new DropData(30437, new int[] {2000, 0, 0, 0, 0, 0, 0}, new int[] {100, 0, 0, 0, 0, 0, 0}));
root.Add(30438, new DropData(30438, new int[] {2000, 0, 0, 0, 0, 0, 0}, new int[] {100, 0, 0, 0, 0, 0, 0}));
root.Add(30439, new DropData(30439, new int[] {2000, 0, 0, 0, 0, 0, 0}, new int[] {100, 0, 0, 0, 0, 0, 0}));
root.Add(30440, new DropData(30440, new int[] {2000, 0, 0, 0, 0, 0, 0}, new int[] {100, 0, 0, 0, 0, 0, 0}));
root.Add(30441, new DropData(30441, new int[] {2000, 0, 0, 0, 0, 0, 0}, new int[] {100, 0, 0, 0, 0, 0, 0}));
root.Add(30442, new DropData(30442, new int[] {2000, 0, 0, 0, 0, 0, 0}, new int[] {100, 0, 0, 0, 0, 0, 0}));
root.Add(30443, new DropData(30443, new int[] {2000, 0, 0, 0, 0, 0, 0}, new int[] {100, 0, 0, 0, 0, 0, 0}));
root.Add(30444, new DropData(30444, new int[] {2000, 0, 0, 0, 0, 0, 0}, new int[] {100, 0, 0, 0, 0, 0, 0}));
root.Add(30445, new DropData(30445, new int[] {2000, 0, 0, 0, 0, 0, 0}, new int[] {100, 0, 0, 0, 0, 0, 0}));
root.Add(30446, new DropData(30446, new int[] {2000, 0, 0, 0, 0, 0, 0}, new int[] {100, 0, 0, 0, 0, 0, 0}));
root.Add(30447, new DropData(30447, new int[] {2000, 0, 0, 0, 0, 0, 0}, new int[] {100, 0, 0, 0, 0, 0, 0}));
root.Add(30448, new DropData(30448, new int[] {2000, 0, 0, 0, 0, 0, 0}, new int[] {100, 0, 0, 0, 0, 0, 0}));
root.Add(30449, new DropData(30449, new int[] {2000, 0, 0, 0, 0, 0, 0}, new int[] {100, 0, 0, 0, 0, 0, 0}));
root.Add(30450, new DropData(30450, new int[] {2000, 0, 0, 0, 0, 0, 0}, new int[] {100, 0, 0, 0, 0, 0, 0}));
root.Add(30451, new DropData(30451, new int[] {2000, 0, 0, 0, 0, 0, 0}, new int[] {100, 0, 0, 0, 0, 0, 0}));
root.Add(30452, new DropData(30452, new int[] {2000, 0, 0, 0, 0, 0, 0}, new int[] {100, 0, 0, 0, 0, 0, 0}));
root.Add(30453, new DropData(30453, new int[] {2000, 0, 0, 0, 0, 0, 0}, new int[] {100, 0, 0, 0, 0, 0, 0}));
root.Add(30454, new DropData(30454, new int[] {2000, 0, 0, 0, 0, 0, 0}, new int[] {100, 0, 0, 0, 0, 0, 0}));
root.Add(30455, new DropData(30455, new int[] {2000, 0, 0, 0, 0, 0, 0}, new int[] {100, 0, 0, 0, 0, 0, 0}));
root.Add(30456, new DropData(30456, new int[] {2000, 0, 0, 0, 0, 0, 0}, new int[] {100, 0, 0, 0, 0, 0, 0}));
root.Add(30457, new DropData(30457, new int[] {2000, 0, 0, 0, 0, 0, 0}, new int[] {100, 0, 0, 0, 0, 0, 0}));
root.Add(30458, new DropData(30458, new int[] {2000, 0, 0, 0, 0, 0, 0}, new int[] {100, 0, 0, 0, 0, 0, 0}));
root.Add(30459, new DropData(30459, new int[] {2000, 0, 0, 0, 0, 0, 0}, new int[] {100, 0, 0, 0, 0, 0, 0}));
root.Add(30460, new DropData(30460, new int[] {2000, 0, 0, 0, 0, 0, 0}, new int[] {100, 0, 0, 0, 0, 0, 0}));
root.Add(30461, new DropData(30461, new int[] {2000, 0, 0, 0, 0, 0, 0}, new int[] {100, 0, 0, 0, 0, 0, 0}));
root.Add(30462, new DropData(30462, new int[] {2000, 0, 0, 0, 0, 0, 0}, new int[] {100, 0, 0, 0, 0, 0, 0}));
root.Add(30463, new DropData(30463, new int[] {2000, 0, 0, 0, 0, 0, 0}, new int[] {100, 0, 0, 0, 0, 0, 0}));
root.Add(30464, new DropData(30464, new int[] {2000, 0, 0, 0, 0, 0, 0}, new int[] {100, 0, 0, 0, 0, 0, 0}));
root.Add(30465, new DropData(30465, new int[] {2000, 0, 0, 0, 0, 0, 0}, new int[] {100, 0, 0, 0, 0, 0, 0}));
root.Add(30466, new DropData(30466, new int[] {2000, 0, 0, 0, 0, 0, 0}, new int[] {100, 0, 0, 0, 0, 0, 0}));
root.Add(30467, new DropData(30467, new int[] {2000, 0, 0, 0, 0, 0, 0}, new int[] {100, 0, 0, 0, 0, 0, 0}));
root.Add(30468, new DropData(30468, new int[] {2000, 0, 0, 0, 0, 0, 0}, new int[] {100, 0, 0, 0, 0, 0, 0}));
root.Add(30469, new DropData(30469, new int[] {2000, 0, 0, 0, 0, 0, 0}, new int[] {100, 0, 0, 0, 0, 0, 0}));
root.Add(30470, new DropData(30470, new int[] {2000, 0, 0, 0, 0, 0, 0}, new int[] {100, 0, 0, 0, 0, 0, 0}));
root.Add(30471, new DropData(30471, new int[] {2000, 0, 0, 0, 0, 0, 0}, new int[] {100, 0, 0, 0, 0, 0, 0}));
root.Add(30472, new DropData(30472, new int[] {2000, 0, 0, 0, 0, 0, 0}, new int[] {100, 0, 0, 0, 0, 0, 0}));
root.Add(30473, new DropData(30473, new int[] {2000, 0, 0, 0, 0, 0, 0}, new int[] {100, 0, 0, 0, 0, 0, 0}));
root.Add(30474, new DropData(30474, new int[] {2000, 0, 0, 0, 0, 0, 0}, new int[] {100, 0, 0, 0, 0, 0, 0}));
root.Add(30475, new DropData(30475, new int[] {2000, 0, 0, 0, 0, 0, 0}, new int[] {100, 0, 0, 0, 0, 0, 0}));
root.Add(30476, new DropData(30476, new int[] {2000, 0, 0, 0, 0, 0, 0}, new int[] {100, 0, 0, 0, 0, 0, 0}));
root.Add(30477, new DropData(30477, new int[] {2000, 0, 0, 0, 0, 0, 0}, new int[] {100, 0, 0, 0, 0, 0, 0}));
root.Add(30478, new DropData(30478, new int[] {2000, 0, 0, 0, 0, 0, 0}, new int[] {100, 0, 0, 0, 0, 0, 0}));
root.Add(30479, new DropData(30479, new int[] {2000, 0, 0, 0, 0, 0, 0}, new int[] {100, 0, 0, 0, 0, 0, 0}));
root.Add(30480, new DropData(30480, new int[] {2000, 0, 0, 0, 0, 0, 0}, new int[] {100, 0, 0, 0, 0, 0, 0}));
root.Add(30481, new DropData(30481, new int[] {2000, 0, 0, 0, 0, 0, 0}, new int[] {100, 0, 0, 0, 0, 0, 0}));
root.Add(30482, new DropData(30482, new int[] {2000, 0, 0, 0, 0, 0, 0}, new int[] {100, 0, 0, 0, 0, 0, 0}));
root.Add(30483, new DropData(30483, new int[] {2000, 0, 0, 0, 0, 0, 0}, new int[] {100, 0, 0, 0, 0, 0, 0}));
root.Add(30484, new DropData(30484, new int[] {2000, 0, 0, 0, 0, 0, 0}, new int[] {100, 0, 0, 0, 0, 0, 0}));
root.Add(30485, new DropData(30485, new int[] {2000, 0, 0, 0, 0, 0, 0}, new int[] {100, 0, 0, 0, 0, 0, 0}));
root.Add(30486, new DropData(30486, new int[] {2000, 0, 0, 0, 0, 0, 0}, new int[] {100, 0, 0, 0, 0, 0, 0}));
root.Add(30487, new DropData(30487, new int[] {2000, 0, 0, 0, 0, 0, 0}, new int[] {100, 0, 0, 0, 0, 0, 0}));
root.Add(30488, new DropData(30488, new int[] {2000, 0, 0, 0, 0, 0, 0}, new int[] {100, 0, 0, 0, 0, 0, 0}));
root.Add(30489, new DropData(30489, new int[] {2000, 0, 0, 0, 0, 0, 0}, new int[] {100, 0, 0, 0, 0, 0, 0}));
root.Add(30490, new DropData(30490, new int[] {2000, 0, 0, 0, 0, 0, 0}, new int[] {100, 0, 0, 0, 0, 0, 0}));
root.Add(30491, new DropData(30491, new int[] {2000, 0, 0, 0, 0, 0, 0}, new int[] {100, 0, 0, 0, 0, 0, 0}));
root.Add(30492, new DropData(30492, new int[] {2000, 0, 0, 0, 0, 0, 0}, new int[] {100, 0, 0, 0, 0, 0, 0}));
root.Add(30493, new DropData(30493, new int[] {2000, 0, 0, 0, 0, 0, 0}, new int[] {100, 0, 0, 0, 0, 0, 0}));
root.Add(30494, new DropData(30494, new int[] {2000, 0, 0, 0, 0, 0, 0}, new int[] {100, 0, 0, 0, 0, 0, 0}));
root.Add(30495, new DropData(30495, new int[] {2000, 0, 0, 0, 0, 0, 0}, new int[] {100, 0, 0, 0, 0, 0, 0}));
root.Add(30496, new DropData(30496, new int[] {2000, 0, 0, 0, 0, 0, 0}, new int[] {100, 0, 0, 0, 0, 0, 0}));
root.Add(30497, new DropData(30497, new int[] {2000, 0, 0, 0, 0, 0, 0}, new int[] {100, 0, 0, 0, 0, 0, 0}));
root.Add(30498, new DropData(30498, new int[] {2000, 0, 0, 0, 0, 0, 0}, new int[] {100, 0, 0, 0, 0, 0, 0}));
root.Add(30499, new DropData(30499, new int[] {2000, 0, 0, 0, 0, 0, 0}, new int[] {100, 0, 0, 0, 0, 0, 0}));
root.Add(30500, new DropData(30500, new int[] {2000, 0, 0, 0, 0, 0, 0}, new int[] {100, 0, 0, 0, 0, 0, 0}));
root.Add(30501, new DropData(30501, new int[] {2000, 0, 0, 0, 0, 0, 0}, new int[] {100, 0, 0, 0, 0, 0, 0}));
root.Add(30502, new DropData(30502, new int[] {2000, 0, 0, 0, 0, 0, 0}, new int[] {100, 0, 0, 0, 0, 0, 0}));
root.Add(30503, new DropData(30503, new int[] {2000, 0, 0, 0, 0, 0, 0}, new int[] {100, 0, 0, 0, 0, 0, 0}));
root.Add(30504, new DropData(30504, new int[] {2000, 0, 0, 0, 0, 0, 0}, new int[] {100, 0, 0, 0, 0, 0, 0}));
root.Add(30505, new DropData(30505, new int[] {2000, 0, 0, 0, 0, 0, 0}, new int[] {100, 0, 0, 0, 0, 0, 0}));
root.Add(30506, new DropData(30506, new int[] {2000, 0, 0, 0, 0, 0, 0}, new int[] {100, 0, 0, 0, 0, 0, 0}));
root.Add(30507, new DropData(30507, new int[] {2000, 0, 0, 0, 0, 0, 0}, new int[] {100, 0, 0, 0, 0, 0, 0}));
root.Add(30508, new DropData(30508, new int[] {2000, 0, 0, 0, 0, 0, 0}, new int[] {100, 0, 0, 0, 0, 0, 0}));
root.Add(30509, new DropData(30509, new int[] {2000, 0, 0, 0, 0, 0, 0}, new int[] {100, 0, 0, 0, 0, 0, 0}));
root.Add(30510, new DropData(30510, new int[] {2000, 0, 0, 0, 0, 0, 0}, new int[] {100, 0, 0, 0, 0, 0, 0}));
root.Add(30511, new DropData(30511, new int[] {2000, 0, 0, 0, 0, 0, 0}, new int[] {100, 0, 0, 0, 0, 0, 0}));
root.Add(30512, new DropData(30512, new int[] {2000, 0, 0, 0, 0, 0, 0}, new int[] {100, 0, 0, 0, 0, 0, 0}));
root.Add(30513, new DropData(30513, new int[] {2000, 0, 0, 0, 0, 0, 0}, new int[] {100, 0, 0, 0, 0, 0, 0}));
root.Add(30514, new DropData(30514, new int[] {2000, 0, 0, 0, 0, 0, 0}, new int[] {100, 0, 0, 0, 0, 0, 0}));
root.Add(30515, new DropData(30515, new int[] {2000, 0, 0, 0, 0, 0, 0}, new int[] {100, 0, 0, 0, 0, 0, 0}));
root.Add(30516, new DropData(30516, new int[] {2000, 0, 0, 0, 0, 0, 0}, new int[] {100, 0, 0, 0, 0, 0, 0}));
root.Add(30517, new DropData(30517, new int[] {2000, 0, 0, 0, 0, 0, 0}, new int[] {100, 0, 0, 0, 0, 0, 0}));
root.Add(30518, new DropData(30518, new int[] {2000, 0, 0, 0, 0, 0, 0}, new int[] {100, 0, 0, 0, 0, 0, 0}));
root.Add(30519, new DropData(30519, new int[] {2000, 0, 0, 0, 0, 0, 0}, new int[] {100, 0, 0, 0, 0, 0, 0}));
root.Add(30520, new DropData(30520, new int[] {2000, 0, 0, 0, 0, 0, 0}, new int[] {100, 0, 0, 0, 0, 0, 0}));
root.Add(30521, new DropData(30521, new int[] {2000, 0, 0, 0, 0, 0, 0}, new int[] {100, 0, 0, 0, 0, 0, 0}));
root.Add(30522, new DropData(30522, new int[] {2000, 0, 0, 0, 0, 0, 0}, new int[] {100, 0, 0, 0, 0, 0, 0}));
root.Add(30523, new DropData(30523, new int[] {2000, 0, 0, 0, 0, 0, 0}, new int[] {100, 0, 0, 0, 0, 0, 0}));
root.Add(30524, new DropData(30524, new int[] {2000, 0, 0, 0, 0, 0, 0}, new int[] {100, 0, 0, 0, 0, 0, 0}));
root.Add(30525, new DropData(30525, new int[] {2000, 0, 0, 0, 0, 0, 0}, new int[] {100, 0, 0, 0, 0, 0, 0}));
root.Add(30526, new DropData(30526, new int[] {2000, 0, 0, 0, 0, 0, 0}, new int[] {100, 0, 0, 0, 0, 0, 0}));
root.Add(30527, new DropData(30527, new int[] {2000, 0, 0, 0, 0, 0, 0}, new int[] {100, 0, 0, 0, 0, 0, 0}));
root.Add(30528, new DropData(30528, new int[] {2000, 0, 0, 0, 0, 0, 0}, new int[] {100, 0, 0, 0, 0, 0, 0}));
root.Add(30529, new DropData(30529, new int[] {2000, 0, 0, 0, 0, 0, 0}, new int[] {100, 0, 0, 0, 0, 0, 0}));
root.Add(30530, new DropData(30530, new int[] {2000, 0, 0, 0, 0, 0, 0}, new int[] {100, 0, 0, 0, 0, 0, 0}));
root.Add(30531, new DropData(30531, new int[] {2000, 0, 0, 0, 0, 0, 0}, new int[] {100, 0, 0, 0, 0, 0, 0}));
root.Add(30532, new DropData(30532, new int[] {2000, 0, 0, 0, 0, 0, 0}, new int[] {100, 0, 0, 0, 0, 0, 0}));
root.Add(30533, new DropData(30533, new int[] {2000, 0, 0, 0, 0, 0, 0}, new int[] {100, 0, 0, 0, 0, 0, 0}));
root.Add(30534, new DropData(30534, new int[] {2000, 0, 0, 0, 0, 0, 0}, new int[] {100, 0, 0, 0, 0, 0, 0}));
root.Add(30535, new DropData(30535, new int[] {2000, 0, 0, 0, 0, 0, 0}, new int[] {100, 0, 0, 0, 0, 0, 0}));
root.Add(30536, new DropData(30536, new int[] {2000, 0, 0, 0, 0, 0, 0}, new int[] {100, 0, 0, 0, 0, 0, 0}));
root.Add(30537, new DropData(30537, new int[] {2000, 0, 0, 0, 0, 0, 0}, new int[] {100, 0, 0, 0, 0, 0, 0}));
root.Add(30538, new DropData(30538, new int[] {2000, 0, 0, 0, 0, 0, 0}, new int[] {100, 0, 0, 0, 0, 0, 0}));
root.Add(30539, new DropData(30539, new int[] {2000, 0, 0, 0, 0, 0, 0}, new int[] {100, 0, 0, 0, 0, 0, 0}));
root.Add(31000, new DropData(31000, new int[] {3000, 0, 0, 0, 0, 0, 0}, new int[] {1, 0, 0, 0, 0, 0, 0}));
root.Add(31001, new DropData(31001, new int[] {600103, 0, 0, 0, 0, 0, 0}, new int[] {1, 0, 0, 0, 0, 0, 0}));
root.Add(31002, new DropData(31002, new int[] {600104, 0, 0, 0, 0, 0, 0}, new int[] {2, 0, 0, 0, 0, 0, 0}));
root.Add(31003, new DropData(31003, new int[] {600106, 0, 0, 0, 0, 0, 0}, new int[] {3, 0, 0, 0, 0, 0, 0}));
root.Add(31004, new DropData(31004, new int[] {600108, 0, 0, 0, 0, 0, 0}, new int[] {4, 0, 0, 0, 0, 0, 0}));
root.Add(31005, new DropData(31005, new int[] {600110, 0, 0, 0, 0, 0, 0}, new int[] {5, 0, 0, 0, 0, 0, 0}));
root.Add(31006, new DropData(31006, new int[] {600103, 0, 0, 0, 0, 0, 0}, new int[] {6, 0, 0, 0, 0, 0, 0}));
}
public DropData GetReadData(int ID){
if (root.ContainsKey(ID))
return root[ID];
else{
object obj = MMFramework.ModifyExcelModule.Instance.GetModifyedData(ID);
if (obj != null)return obj as DropData;
Debug.LogError("在表格 DropData中没有找到ID" + ID);
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
DropData data = GetReadData(key);
Type type = data.GetType();
System.Reflection.FieldInfo[] filedinfos = type.GetFields();
for (int i = 0; i < filedinfos.Length; i++)
{System.Reflection.FieldInfo field = filedinfos[i];
pairs.Add(field.Name, field.GetValue(data).ToString());}
return pairs;}
}
public static DropData GetData(int ID){
return DropDataReader.Instance.GetReadData(ID);
}
public static Dictionary<string, string> GetDictionary(int key)
{ return DropDataReader.Instance.GetReadDictionary(key);}
public static int GetNum(){
return DropDataReader.Instance.GetCount();
}
public static List<int> GetKeys(){
return DropDataReader.Instance.GetDataKeys();
}
public static void SaveToFile(string path){
DropDataReader.Instance.WriteToFile(path);
}

}