using System;
using System.Collections.Generic;
using UnityEngine;
[Serializable]
public class PhysiqueStarData2{
/// <summary>
/// 属性ID
/// </summary>
public int PhysiqueID;
/// <summary>
/// 升级上限
/// </summary>
public int LevelUpMax;
/// <summary>
/// 公式
/// </summary>
public int AtkFormula;
/// <summary>
/// a
/// </summary>
public float[] AtkParameterArray;
/// <summary>
/// 公式
/// </summary>
public int DefFormula;
/// <summary>
/// a
/// </summary>
public float[] DefParameterArray;
/// <summary>
/// 公式
/// </summary>
public int HpFormula;
/// <summary>
/// a
/// </summary>
public float[] HpParameterArray;
public PhysiqueStarData2(int PhysiqueID, int LevelUpMax, int AtkFormula, float[] AtkParameterArray, int DefFormula, float[] DefParameterArray, int HpFormula, float[] HpParameterArray){
this.PhysiqueID = PhysiqueID;
this.LevelUpMax = LevelUpMax;
this.AtkFormula = AtkFormula;
this.AtkParameterArray = AtkParameterArray;
this.DefFormula = DefFormula;
this.DefParameterArray = DefParameterArray;
this.HpFormula = HpFormula;
this.HpParameterArray = HpParameterArray;
}
class PhysiqueStarData2Reader{
static PhysiqueStarData2Reader instance;
static object syncRoot = new object();
public static PhysiqueStarData2Reader Instance{get{if (instance == null){lock (syncRoot){if (instance == null){instance = new PhysiqueStarData2Reader();instance.Load();}}}return instance;}}
Dictionary<int, PhysiqueStarData2> root = new Dictionary<int, PhysiqueStarData2>();
void Load(){
root.Add(700101, new PhysiqueStarData2(700101, 40, 1, new float[] {1.04f, 5.33333333333333f, 0f, 20f}, 1, new float[] {1.04f, 2f, 0f, 20f}, 1, new float[] {1.04f, 135f, 0f, 20f}));
root.Add(700102, new PhysiqueStarData2(700102, 80, 1, new float[] {1.04f, 5.33333333333333f, 0f, 20f}, 1, new float[] {1.04f, 2f, 0f, 20f}, 1, new float[] {1.04f, 135f, 0f, 20f}));
root.Add(700103, new PhysiqueStarData2(700103, 120, 1, new float[] {1.04f, 5.33333333333333f, 0f, 20f}, 1, new float[] {1.04f, 2f, 0f, 20f}, 1, new float[] {1.04f, 135f, 0f, 20f}));
root.Add(700104, new PhysiqueStarData2(700104, 160, 1, new float[] {1.04f, 5.33333333333333f, 0f, 20f}, 1, new float[] {1.04f, 2f, 0f, 20f}, 1, new float[] {1.04f, 135f, 0f, 20f}));
root.Add(700105, new PhysiqueStarData2(700105, 200, 1, new float[] {1.04f, 5.33333333333333f, 0f, 20f}, 1, new float[] {1.04f, 2f, 0f, 20f}, 1, new float[] {1.04f, 135f, 0f, 20f}));
root.Add(700106, new PhysiqueStarData2(700106, 250, 1, new float[] {1.04f, 5.33333333333333f, 0f, 20f}, 1, new float[] {1.04f, 2f, 0f, 20f}, 1, new float[] {1.04f, 135f, 0f, 20f}));
root.Add(700107, new PhysiqueStarData2(700107, 300, 1, new float[] {1.04f, 5.33333333333333f, 0f, 20f}, 1, new float[] {1.04f, 2f, 0f, 20f}, 1, new float[] {1.04f, 135f, 0f, 20f}));
root.Add(700108, new PhysiqueStarData2(700108, 300, 1, new float[] {1.04f, 5.33333333333333f, 0f, 20f}, 1, new float[] {1.04f, 2f, 0f, 20f}, 1, new float[] {1.04f, 135f, 0f, 20f}));
root.Add(700109, new PhysiqueStarData2(700109, 300, 1, new float[] {1.04f, 5.33333333333333f, 0f, 20f}, 1, new float[] {1.04f, 2f, 0f, 20f}, 1, new float[] {1.04f, 135f, 0f, 20f}));
root.Add(700110, new PhysiqueStarData2(700110, 300, 1, new float[] {1.04f, 5.33333333333333f, 0f, 20f}, 1, new float[] {1.04f, 2f, 0f, 20f}, 1, new float[] {1.04f, 135f, 0f, 20f}));
root.Add(700201, new PhysiqueStarData2(700201, 40, 1, new float[] {1.04f, 7f, 0f, 20f}, 1, new float[] {1.04f, 2f, 0f, 20f}, 1, new float[] {1.04f, 105f, 0f, 20f}));
root.Add(700202, new PhysiqueStarData2(700202, 80, 1, new float[] {1.04f, 7f, 0f, 20f}, 1, new float[] {1.04f, 2f, 0f, 20f}, 1, new float[] {1.04f, 105f, 0f, 20f}));
root.Add(700203, new PhysiqueStarData2(700203, 120, 1, new float[] {1.04f, 7f, 0f, 20f}, 1, new float[] {1.04f, 2f, 0f, 20f}, 1, new float[] {1.04f, 105f, 0f, 20f}));
root.Add(700204, new PhysiqueStarData2(700204, 160, 1, new float[] {1.04f, 7f, 0f, 20f}, 1, new float[] {1.04f, 2f, 0f, 20f}, 1, new float[] {1.04f, 105f, 0f, 20f}));
root.Add(700205, new PhysiqueStarData2(700205, 200, 1, new float[] {1.04f, 7f, 0f, 20f}, 1, new float[] {1.04f, 2f, 0f, 20f}, 1, new float[] {1.04f, 105f, 0f, 20f}));
root.Add(700206, new PhysiqueStarData2(700206, 250, 1, new float[] {1.04f, 7f, 0f, 20f}, 1, new float[] {1.04f, 2f, 0f, 20f}, 1, new float[] {1.04f, 105f, 0f, 20f}));
root.Add(700207, new PhysiqueStarData2(700207, 300, 1, new float[] {1.04f, 7f, 0f, 20f}, 1, new float[] {1.04f, 2f, 0f, 20f}, 1, new float[] {1.04f, 105f, 0f, 20f}));
root.Add(700208, new PhysiqueStarData2(700208, 300, 1, new float[] {1.04f, 7f, 0f, 20f}, 1, new float[] {1.04f, 2f, 0f, 20f}, 1, new float[] {1.04f, 105f, 0f, 20f}));
root.Add(700209, new PhysiqueStarData2(700209, 300, 1, new float[] {1.04f, 7f, 0f, 20f}, 1, new float[] {1.04f, 2f, 0f, 20f}, 1, new float[] {1.04f, 105f, 0f, 20f}));
root.Add(700210, new PhysiqueStarData2(700210, 300, 1, new float[] {1.04f, 7f, 0f, 20f}, 1, new float[] {1.04f, 2f, 0f, 20f}, 1, new float[] {1.04f, 105f, 0f, 20f}));
root.Add(700301, new PhysiqueStarData2(700301, 40, 1, new float[] {1.04f, 7f, 0f, 20f}, 1, new float[] {1.04f, 2f, 0f, 20f}, 1, new float[] {1.04f, 75f, 0f, 20f}));
root.Add(700302, new PhysiqueStarData2(700302, 80, 1, new float[] {1.04f, 7f, 0f, 20f}, 1, new float[] {1.04f, 2f, 0f, 20f}, 1, new float[] {1.04f, 75f, 0f, 20f}));
root.Add(700303, new PhysiqueStarData2(700303, 120, 1, new float[] {1.04f, 7f, 0f, 20f}, 1, new float[] {1.04f, 2f, 0f, 20f}, 1, new float[] {1.04f, 75f, 0f, 20f}));
root.Add(700304, new PhysiqueStarData2(700304, 160, 1, new float[] {1.04f, 7f, 0f, 20f}, 1, new float[] {1.04f, 2f, 0f, 20f}, 1, new float[] {1.04f, 75f, 0f, 20f}));
root.Add(700305, new PhysiqueStarData2(700305, 200, 1, new float[] {1.04f, 7f, 0f, 20f}, 1, new float[] {1.04f, 2f, 0f, 20f}, 1, new float[] {1.04f, 75f, 0f, 20f}));
root.Add(700306, new PhysiqueStarData2(700306, 250, 1, new float[] {1.04f, 7f, 0f, 20f}, 1, new float[] {1.04f, 2f, 0f, 20f}, 1, new float[] {1.04f, 75f, 0f, 20f}));
root.Add(700307, new PhysiqueStarData2(700307, 300, 1, new float[] {1.04f, 7f, 0f, 20f}, 1, new float[] {1.04f, 2f, 0f, 20f}, 1, new float[] {1.04f, 75f, 0f, 20f}));
root.Add(700308, new PhysiqueStarData2(700308, 300, 1, new float[] {1.04f, 7f, 0f, 20f}, 1, new float[] {1.04f, 2f, 0f, 20f}, 1, new float[] {1.04f, 75f, 0f, 20f}));
root.Add(700309, new PhysiqueStarData2(700309, 300, 1, new float[] {1.04f, 7f, 0f, 20f}, 1, new float[] {1.04f, 2f, 0f, 20f}, 1, new float[] {1.04f, 75f, 0f, 20f}));
root.Add(700310, new PhysiqueStarData2(700310, 300, 1, new float[] {1.04f, 7.55555555555556f, 0f, 20f}, 1, new float[] {1.04f, 2f, 0f, 20f}, 1, new float[] {1.04f, 75f, 0f, 20f}));
root.Add(700401, new PhysiqueStarData2(700401, 40, 1, new float[] {1.04f, 7.55555555555556f, 0f, 20f}, 1, new float[] {1.04f, 2f, 0f, 20f}, 1, new float[] {1.04f, 66f, 0f, 20f}));
root.Add(700402, new PhysiqueStarData2(700402, 80, 1, new float[] {1.04f, 7.55555555555556f, 0f, 20f}, 1, new float[] {1.04f, 2f, 0f, 20f}, 1, new float[] {1.04f, 66f, 0f, 20f}));
root.Add(700403, new PhysiqueStarData2(700403, 120, 1, new float[] {1.04f, 7.55555555555556f, 0f, 20f}, 1, new float[] {1.04f, 2f, 0f, 20f}, 1, new float[] {1.04f, 66f, 0f, 20f}));
root.Add(700404, new PhysiqueStarData2(700404, 160, 1, new float[] {1.04f, 7.55555555555556f, 0f, 20f}, 1, new float[] {1.04f, 2f, 0f, 20f}, 1, new float[] {1.04f, 66f, 0f, 20f}));
root.Add(700405, new PhysiqueStarData2(700405, 200, 1, new float[] {1.04f, 7.55555555555556f, 0f, 20f}, 1, new float[] {1.04f, 2f, 0f, 20f}, 1, new float[] {1.04f, 66f, 0f, 20f}));
root.Add(700406, new PhysiqueStarData2(700406, 250, 1, new float[] {1.04f, 7.55555555555556f, 0f, 20f}, 1, new float[] {1.04f, 2f, 0f, 20f}, 1, new float[] {1.04f, 66f, 0f, 20f}));
root.Add(700407, new PhysiqueStarData2(700407, 300, 1, new float[] {1.04f, 7.55555555555556f, 0f, 20f}, 1, new float[] {1.04f, 2f, 0f, 20f}, 1, new float[] {1.04f, 66f, 0f, 20f}));
root.Add(700408, new PhysiqueStarData2(700408, 300, 1, new float[] {1.04f, 7.55555555555556f, 0f, 20f}, 1, new float[] {1.04f, 2f, 0f, 20f}, 1, new float[] {1.04f, 66f, 0f, 20f}));
root.Add(700409, new PhysiqueStarData2(700409, 300, 1, new float[] {1.04f, 7.55555555555556f, 0f, 20f}, 1, new float[] {1.04f, 2f, 0f, 20f}, 1, new float[] {1.04f, 66f, 0f, 20f}));
root.Add(700410, new PhysiqueStarData2(700410, 300, 1, new float[] {1.04f, 7.55555555555556f, 0f, 20f}, 1, new float[] {1.04f, 2f, 0f, 20f}, 1, new float[] {1.04f, 66f, 0f, 20f}));
root.Add(700501, new PhysiqueStarData2(700501, 40, 1, new float[] {1.04f, 8.45161290322581f, 0f, 20f}, 1, new float[] {1.04f, 2f, 0f, 20f}, 1, new float[] {1.04f, 63f, 0f, 20f}));
root.Add(700502, new PhysiqueStarData2(700502, 80, 1, new float[] {1.04f, 8.45161290322581f, 0f, 20f}, 1, new float[] {1.04f, 2f, 0f, 20f}, 1, new float[] {1.04f, 63f, 0f, 20f}));
root.Add(700503, new PhysiqueStarData2(700503, 120, 1, new float[] {1.04f, 8.45161290322581f, 0f, 20f}, 1, new float[] {1.04f, 2f, 0f, 20f}, 1, new float[] {1.04f, 63f, 0f, 20f}));
root.Add(700504, new PhysiqueStarData2(700504, 160, 1, new float[] {1.04f, 8.45161290322581f, 0f, 20f}, 1, new float[] {1.04f, 2f, 0f, 20f}, 1, new float[] {1.04f, 63f, 0f, 20f}));
root.Add(700505, new PhysiqueStarData2(700505, 200, 1, new float[] {1.04f, 8.45161290322581f, 0f, 20f}, 1, new float[] {1.04f, 2f, 0f, 20f}, 1, new float[] {1.04f, 63f, 0f, 20f}));
root.Add(700506, new PhysiqueStarData2(700506, 250, 1, new float[] {1.04f, 8.45161290322581f, 0f, 20f}, 1, new float[] {1.04f, 2f, 0f, 20f}, 1, new float[] {1.04f, 63f, 0f, 20f}));
root.Add(700507, new PhysiqueStarData2(700507, 300, 1, new float[] {1.04f, 8.45161290322581f, 0f, 20f}, 1, new float[] {1.04f, 2f, 0f, 20f}, 1, new float[] {1.04f, 63f, 0f, 20f}));
root.Add(700508, new PhysiqueStarData2(700508, 300, 1, new float[] {1.04f, 8.45161290322581f, 0f, 20f}, 1, new float[] {1.04f, 2f, 0f, 20f}, 1, new float[] {1.04f, 63f, 0f, 20f}));
root.Add(700509, new PhysiqueStarData2(700509, 300, 1, new float[] {1.04f, 8.45161290322581f, 0f, 20f}, 1, new float[] {1.04f, 2f, 0f, 20f}, 1, new float[] {1.04f, 63f, 0f, 20f}));
root.Add(700510, new PhysiqueStarData2(700510, 300, 1, new float[] {1.04f, 8.45161290322581f, 0f, 20f}, 1, new float[] {1.04f, 2f, 0f, 20f}, 1, new float[] {1.04f, 63f, 0f, 20f}));
root.Add(700601, new PhysiqueStarData2(700601, 40, 1, new float[] {1.04f, 24.2222222222222f, 0f, 20f}, 1, new float[] {1.04f, 2f, 0f, 20f}, 1, new float[] {1.04f, 75f, 0f, 20f}));
root.Add(700602, new PhysiqueStarData2(700602, 80, 1, new float[] {1.04f, 24.2222222222222f, 0f, 20f}, 1, new float[] {1.04f, 2f, 0f, 20f}, 1, new float[] {1.04f, 75f, 0f, 20f}));
root.Add(700603, new PhysiqueStarData2(700603, 120, 1, new float[] {1.04f, 24.2222222222222f, 0f, 20f}, 1, new float[] {1.04f, 2f, 0f, 20f}, 1, new float[] {1.04f, 75f, 0f, 20f}));
root.Add(700604, new PhysiqueStarData2(700604, 160, 1, new float[] {1.04f, 24.2222222222222f, 0f, 20f}, 1, new float[] {1.04f, 2f, 0f, 20f}, 1, new float[] {1.04f, 75f, 0f, 20f}));
root.Add(700605, new PhysiqueStarData2(700605, 200, 1, new float[] {1.04f, 24.2222222222222f, 0f, 20f}, 1, new float[] {1.04f, 2f, 0f, 20f}, 1, new float[] {1.04f, 75f, 0f, 20f}));
root.Add(700606, new PhysiqueStarData2(700606, 250, 1, new float[] {1.04f, 24.2222222222222f, 0f, 20f}, 1, new float[] {1.04f, 2f, 0f, 20f}, 1, new float[] {1.04f, 75f, 0f, 20f}));
root.Add(700607, new PhysiqueStarData2(700607, 300, 1, new float[] {1.04f, 24.2222222222222f, 0f, 20f}, 1, new float[] {1.04f, 2f, 0f, 20f}, 1, new float[] {1.04f, 75f, 0f, 20f}));
root.Add(700608, new PhysiqueStarData2(700608, 300, 1, new float[] {1.04f, 24.2222222222222f, 0f, 20f}, 1, new float[] {1.04f, 2f, 0f, 20f}, 1, new float[] {1.04f, 75f, 0f, 20f}));
root.Add(700609, new PhysiqueStarData2(700609, 300, 1, new float[] {1.04f, 24.2222222222222f, 0f, 20f}, 1, new float[] {1.04f, 2f, 0f, 20f}, 1, new float[] {1.04f, 75f, 0f, 20f}));
root.Add(700610, new PhysiqueStarData2(700610, 300, 1, new float[] {1.04f, 24.2222222222222f, 0f, 20f}, 1, new float[] {1.04f, 2f, 0f, 20f}, 1, new float[] {1.04f, 75f, 0f, 20f}));
root.Add(700701, new PhysiqueStarData2(700701, 40, 1, new float[] {1.04f, 14.5f, 0f, 20f}, 1, new float[] {1.04f, 2f, 0f, 20f}, 1, new float[] {1.04f, 81f, 0f, 20f}));
root.Add(700702, new PhysiqueStarData2(700702, 80, 1, new float[] {1.04f, 14.5f, 0f, 20f}, 1, new float[] {1.04f, 2f, 0f, 20f}, 1, new float[] {1.04f, 81f, 0f, 20f}));
root.Add(700703, new PhysiqueStarData2(700703, 120, 1, new float[] {1.04f, 14.5f, 0f, 20f}, 1, new float[] {1.04f, 2f, 0f, 20f}, 1, new float[] {1.04f, 81f, 0f, 20f}));
root.Add(700704, new PhysiqueStarData2(700704, 160, 1, new float[] {1.04f, 14.5f, 0f, 20f}, 1, new float[] {1.04f, 2f, 0f, 20f}, 1, new float[] {1.04f, 81f, 0f, 20f}));
root.Add(700705, new PhysiqueStarData2(700705, 200, 1, new float[] {1.04f, 14.5f, 0f, 20f}, 1, new float[] {1.04f, 2f, 0f, 20f}, 1, new float[] {1.04f, 81f, 0f, 20f}));
root.Add(700706, new PhysiqueStarData2(700706, 250, 1, new float[] {1.04f, 14.5f, 0f, 20f}, 1, new float[] {1.04f, 2f, 0f, 20f}, 1, new float[] {1.04f, 81f, 0f, 20f}));
root.Add(700707, new PhysiqueStarData2(700707, 300, 1, new float[] {1.04f, 14.5f, 0f, 20f}, 1, new float[] {1.04f, 2f, 0f, 20f}, 1, new float[] {1.04f, 81f, 0f, 20f}));
root.Add(700708, new PhysiqueStarData2(700708, 300, 1, new float[] {1.04f, 14.5f, 0f, 20f}, 1, new float[] {1.04f, 2f, 0f, 20f}, 1, new float[] {1.04f, 81f, 0f, 20f}));
root.Add(700709, new PhysiqueStarData2(700709, 300, 1, new float[] {1.04f, 14.5f, 0f, 20f}, 1, new float[] {1.04f, 2f, 0f, 20f}, 1, new float[] {1.04f, 81f, 0f, 20f}));
root.Add(700710, new PhysiqueStarData2(700710, 300, 1, new float[] {1.04f, 14.5f, 0f, 20f}, 1, new float[] {1.04f, 2f, 0f, 20f}, 1, new float[] {1.04f, 81f, 0f, 20f}));
root.Add(700801, new PhysiqueStarData2(700801, 300, 2, new float[] {1.04f, 5f, 0f, 0f}, 2, new float[] {1.04f, 2f, 0f, 0f}, 2, new float[] {1.04f, 20f, 0f, 0f}));
root.Add(700802, new PhysiqueStarData2(700802, 300, 2, new float[] {1.04f, 5f, 0f, 0f}, 2, new float[] {1.04f, 2f, 0f, 0f}, 2, new float[] {1.04f, 20f, 0f, 0f}));
root.Add(700803, new PhysiqueStarData2(700803, 300, 2, new float[] {1.04f, 5f, 0f, 0f}, 2, new float[] {1.04f, 2f, 0f, 0f}, 2, new float[] {1.04f, 20f, 0f, 0f}));
root.Add(700804, new PhysiqueStarData2(700804, 300, 2, new float[] {1.04f, 5f, 0f, 0f}, 2, new float[] {1.04f, 2f, 0f, 0f}, 2, new float[] {1.04f, 20f, 0f, 0f}));
root.Add(700805, new PhysiqueStarData2(700805, 300, 2, new float[] {1.04f, 5f, 0f, 0f}, 2, new float[] {1.04f, 2f, 0f, 0f}, 2, new float[] {1.04f, 20f, 0f, 0f}));
root.Add(700806, new PhysiqueStarData2(700806, 300, 2, new float[] {1.04f, 5f, 0f, 0f}, 2, new float[] {1.04f, 2f, 0f, 0f}, 2, new float[] {1.04f, 20f, 0f, 0f}));
root.Add(700807, new PhysiqueStarData2(700807, 300, 2, new float[] {1.04f, 5f, 0f, 0f}, 2, new float[] {1.04f, 2f, 0f, 0f}, 2, new float[] {1.04f, 20f, 0f, 0f}));
root.Add(700808, new PhysiqueStarData2(700808, 300, 2, new float[] {1.04f, 5f, 0f, 0f}, 2, new float[] {1.04f, 2f, 0f, 0f}, 2, new float[] {1.04f, 20f, 0f, 0f}));
root.Add(700809, new PhysiqueStarData2(700809, 300, 2, new float[] {1.04f, 5f, 0f, 0f}, 2, new float[] {1.04f, 2f, 0f, 0f}, 2, new float[] {1.04f, 20f, 0f, 0f}));
root.Add(700810, new PhysiqueStarData2(700810, 300, 2, new float[] {1.04f, 5f, 0f, 0f}, 2, new float[] {1.04f, 2f, 0f, 0f}, 2, new float[] {1.04f, 20f, 0f, 0f}));
root.Add(700901, new PhysiqueStarData2(700901, 300, 2, new float[] {1.04f, 5f, 0f, 0f}, 2, new float[] {1.04f, 2f, 0f, 0f}, 2, new float[] {1.04f, 18.1818181818182f, 0f, 0f}));
root.Add(700902, new PhysiqueStarData2(700902, 300, 2, new float[] {1.04f, 5f, 0f, 0f}, 2, new float[] {1.04f, 2f, 0f, 0f}, 2, new float[] {1.04f, 18.1818181818182f, 0f, 0f}));
root.Add(700903, new PhysiqueStarData2(700903, 300, 2, new float[] {1.04f, 5f, 0f, 0f}, 2, new float[] {1.04f, 2f, 0f, 0f}, 2, new float[] {1.04f, 18.1818181818182f, 0f, 0f}));
root.Add(700904, new PhysiqueStarData2(700904, 300, 2, new float[] {1.04f, 5f, 0f, 0f}, 2, new float[] {1.04f, 2f, 0f, 0f}, 2, new float[] {1.04f, 18.1818181818182f, 0f, 0f}));
root.Add(700905, new PhysiqueStarData2(700905, 300, 2, new float[] {1.04f, 5f, 0f, 0f}, 2, new float[] {1.04f, 2f, 0f, 0f}, 2, new float[] {1.04f, 18.1818181818182f, 0f, 0f}));
root.Add(700906, new PhysiqueStarData2(700906, 300, 2, new float[] {1.04f, 5f, 0f, 0f}, 2, new float[] {1.04f, 2f, 0f, 0f}, 2, new float[] {1.04f, 18.1818181818182f, 0f, 0f}));
root.Add(700907, new PhysiqueStarData2(700907, 300, 2, new float[] {1.04f, 5f, 0f, 0f}, 2, new float[] {1.04f, 2f, 0f, 0f}, 2, new float[] {1.04f, 18.1818181818182f, 0f, 0f}));
root.Add(700908, new PhysiqueStarData2(700908, 300, 2, new float[] {1.04f, 5f, 0f, 0f}, 2, new float[] {1.04f, 2f, 0f, 0f}, 2, new float[] {1.04f, 18.1818181818182f, 0f, 0f}));
root.Add(700909, new PhysiqueStarData2(700909, 300, 2, new float[] {1.04f, 5f, 0f, 0f}, 2, new float[] {1.04f, 2f, 0f, 0f}, 2, new float[] {1.04f, 18.1818181818182f, 0f, 0f}));
root.Add(700910, new PhysiqueStarData2(700910, 300, 2, new float[] {1.04f, 5f, 0f, 0f}, 2, new float[] {1.04f, 2f, 0f, 0f}, 2, new float[] {1.04f, 18.1818181818182f, 0f, 0f}));
root.Add(701001, new PhysiqueStarData2(701001, 300, 2, new float[] {1.04f, 5f, 0f, 0f}, 2, new float[] {1.04f, 2f, 0f, 0f}, 2, new float[] {1.04f, 10f, 0f, 0f}));
root.Add(701002, new PhysiqueStarData2(701002, 300, 2, new float[] {1.04f, 5f, 0f, 0f}, 2, new float[] {1.04f, 2f, 0f, 0f}, 2, new float[] {1.04f, 10f, 0f, 0f}));
root.Add(701003, new PhysiqueStarData2(701003, 300, 2, new float[] {1.04f, 5f, 0f, 0f}, 2, new float[] {1.04f, 2f, 0f, 0f}, 2, new float[] {1.04f, 10f, 0f, 0f}));
root.Add(701004, new PhysiqueStarData2(701004, 300, 2, new float[] {1.04f, 5f, 0f, 0f}, 2, new float[] {1.04f, 2f, 0f, 0f}, 2, new float[] {1.04f, 10f, 0f, 0f}));
root.Add(701005, new PhysiqueStarData2(701005, 300, 2, new float[] {1.04f, 5f, 0f, 0f}, 2, new float[] {1.04f, 2f, 0f, 0f}, 2, new float[] {1.04f, 10f, 0f, 0f}));
root.Add(701006, new PhysiqueStarData2(701006, 300, 2, new float[] {1.04f, 5f, 0f, 0f}, 2, new float[] {1.04f, 2f, 0f, 0f}, 2, new float[] {1.04f, 10f, 0f, 0f}));
root.Add(701007, new PhysiqueStarData2(701007, 300, 2, new float[] {1.04f, 5f, 0f, 0f}, 2, new float[] {1.04f, 2f, 0f, 0f}, 2, new float[] {1.04f, 10f, 0f, 0f}));
root.Add(701008, new PhysiqueStarData2(701008, 300, 2, new float[] {1.04f, 5f, 0f, 0f}, 2, new float[] {1.04f, 2f, 0f, 0f}, 2, new float[] {1.04f, 10f, 0f, 0f}));
root.Add(701009, new PhysiqueStarData2(701009, 300, 2, new float[] {1.04f, 5f, 0f, 0f}, 2, new float[] {1.04f, 2f, 0f, 0f}, 2, new float[] {1.04f, 10f, 0f, 0f}));
root.Add(701010, new PhysiqueStarData2(701010, 300, 2, new float[] {1.04f, 5f, 0f, 0f}, 2, new float[] {1.04f, 2f, 0f, 0f}, 2, new float[] {1.04f, 10f, 0f, 0f}));
root.Add(701101, new PhysiqueStarData2(701101, 300, 2, new float[] {1.04f, 5f, 0f, 0f}, 2, new float[] {1.04f, 2f, 0f, 0f}, 2, new float[] {1.04f, 40f, 0f, 0f}));
root.Add(701102, new PhysiqueStarData2(701102, 300, 2, new float[] {1.04f, 5f, 0f, 0f}, 2, new float[] {1.04f, 2f, 0f, 0f}, 2, new float[] {1.04f, 40f, 0f, 0f}));
root.Add(701103, new PhysiqueStarData2(701103, 300, 2, new float[] {1.04f, 5f, 0f, 0f}, 2, new float[] {1.04f, 2f, 0f, 0f}, 2, new float[] {1.04f, 40f, 0f, 0f}));
root.Add(701104, new PhysiqueStarData2(701104, 300, 2, new float[] {1.04f, 5f, 0f, 0f}, 2, new float[] {1.04f, 2f, 0f, 0f}, 2, new float[] {1.04f, 40f, 0f, 0f}));
root.Add(701105, new PhysiqueStarData2(701105, 300, 2, new float[] {1.04f, 5f, 0f, 0f}, 2, new float[] {1.04f, 2f, 0f, 0f}, 2, new float[] {1.04f, 40f, 0f, 0f}));
root.Add(701106, new PhysiqueStarData2(701106, 300, 2, new float[] {1.04f, 5f, 0f, 0f}, 2, new float[] {1.04f, 2f, 0f, 0f}, 2, new float[] {1.04f, 40f, 0f, 0f}));
root.Add(701107, new PhysiqueStarData2(701107, 300, 2, new float[] {1.04f, 5f, 0f, 0f}, 2, new float[] {1.04f, 2f, 0f, 0f}, 2, new float[] {1.04f, 40f, 0f, 0f}));
root.Add(701108, new PhysiqueStarData2(701108, 300, 2, new float[] {1.04f, 5f, 0f, 0f}, 2, new float[] {1.04f, 2f, 0f, 0f}, 2, new float[] {1.04f, 40f, 0f, 0f}));
root.Add(701109, new PhysiqueStarData2(701109, 300, 2, new float[] {1.04f, 5f, 0f, 0f}, 2, new float[] {1.04f, 2f, 0f, 0f}, 2, new float[] {1.04f, 40f, 0f, 0f}));
root.Add(701110, new PhysiqueStarData2(701110, 300, 2, new float[] {1.04f, 5f, 0f, 0f}, 2, new float[] {1.04f, 2f, 0f, 0f}, 2, new float[] {1.04f, 40f, 0f, 0f}));
root.Add(701201, new PhysiqueStarData2(701201, 300, 2, new float[] {1.04f, 5f, 0f, 0f}, 2, new float[] {1.04f, 2f, 0f, 0f}, 2, new float[] {1.04f, 240f, 0f, 0f}));
root.Add(701202, new PhysiqueStarData2(701202, 300, 2, new float[] {1.04f, 5f, 0f, 0f}, 2, new float[] {1.04f, 2f, 0f, 0f}, 2, new float[] {1.04f, 240f, 0f, 0f}));
root.Add(701203, new PhysiqueStarData2(701203, 300, 2, new float[] {1.04f, 5f, 0f, 0f}, 2, new float[] {1.04f, 2f, 0f, 0f}, 2, new float[] {1.04f, 240f, 0f, 0f}));
root.Add(701204, new PhysiqueStarData2(701204, 300, 2, new float[] {1.04f, 5f, 0f, 0f}, 2, new float[] {1.04f, 2f, 0f, 0f}, 2, new float[] {1.04f, 240f, 0f, 0f}));
root.Add(701205, new PhysiqueStarData2(701205, 300, 2, new float[] {1.04f, 5f, 0f, 0f}, 2, new float[] {1.04f, 2f, 0f, 0f}, 2, new float[] {1.04f, 240f, 0f, 0f}));
root.Add(701206, new PhysiqueStarData2(701206, 300, 2, new float[] {1.04f, 5f, 0f, 0f}, 2, new float[] {1.04f, 2f, 0f, 0f}, 2, new float[] {1.04f, 240f, 0f, 0f}));
root.Add(701207, new PhysiqueStarData2(701207, 300, 2, new float[] {1.04f, 5f, 0f, 0f}, 2, new float[] {1.04f, 2f, 0f, 0f}, 2, new float[] {1.04f, 240f, 0f, 0f}));
root.Add(701208, new PhysiqueStarData2(701208, 300, 2, new float[] {1.04f, 5f, 0f, 0f}, 2, new float[] {1.04f, 2f, 0f, 0f}, 2, new float[] {1.04f, 240f, 0f, 0f}));
root.Add(701209, new PhysiqueStarData2(701209, 300, 2, new float[] {1.04f, 5f, 0f, 0f}, 2, new float[] {1.04f, 2f, 0f, 0f}, 2, new float[] {1.04f, 240f, 0f, 0f}));
root.Add(701210, new PhysiqueStarData2(701210, 300, 2, new float[] {1.04f, 5f, 0f, 0f}, 2, new float[] {1.04f, 2f, 0f, 0f}, 2, new float[] {1.04f, 240f, 0f, 0f}));
}
public PhysiqueStarData2 GetReadData(int ID){
if (root.ContainsKey(ID))
return root[ID];
else{
object obj = MMFramework.ModifyExcelModule.Instance.GetModifyedData(ID);
if (obj != null)return obj as PhysiqueStarData2;
Debug.LogError("在表格 PhysiqueStarData2中没有找到ID" + ID);
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
PhysiqueStarData2 data = GetReadData(key);
Type type = data.GetType();
System.Reflection.FieldInfo[] filedinfos = type.GetFields();
for (int i = 0; i < filedinfos.Length; i++)
{System.Reflection.FieldInfo field = filedinfos[i];
pairs.Add(field.Name, field.GetValue(data).ToString());}
return pairs;}
}
public static PhysiqueStarData2 GetData(int ID){
return PhysiqueStarData2Reader.Instance.GetReadData(ID);
}
public static Dictionary<string, string> GetDictionary(int key)
{ return PhysiqueStarData2Reader.Instance.GetReadDictionary(key);}
public static int GetNum(){
return PhysiqueStarData2Reader.Instance.GetCount();
}
public static List<int> GetKeys(){
return PhysiqueStarData2Reader.Instance.GetDataKeys();
}
public static void SaveToFile(string path){
PhysiqueStarData2Reader.Instance.WriteToFile(path);
}

}