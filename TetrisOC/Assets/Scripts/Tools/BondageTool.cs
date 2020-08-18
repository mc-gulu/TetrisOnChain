using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace MMGame
{
    public class BondageDecsData
    {
        public string desc;
        public List<string> iconpaths = new List<string>();
    }

    public class BondageTool
    {
        public static List<BondageDecsData> GetHeroBuffDesc(int id)
        {
            List<BondageDecsData> list = new List<BondageDecsData>();
            var realdata = DataModule.Instance.GetHeroData(id);
            var bArray = CreatureData.GetData(realdata.creatureid).BondageArray;
            if (bArray == null) return list;
            for (int i = 0; i < bArray.Length; i++)
            {
                if (bArray[i] == 0) continue;
                var bdata = BondageData.GetData(bArray[i] * 10 + realdata.star / 2);
                if (bdata == null)
                {
                    Debug.LogError("羁绊不存在");
                    continue;
                }
                if (!bdata.ShowDesc) continue;
                if (!string.IsNullOrEmpty(bdata.DescArray[3]))
                {
                    var data = new BondageDecsData();
                    var str = "";
                    str += bdata.Name + "\n";
                    str += bdata.DescArray[3];
                    data.desc = str;
                    foreach (var item in bdata.IconPathArray)
                    {
                        if (!string.IsNullOrEmpty(item))
                            data.iconpaths.Add(item);
                    }
                    list.Add(data);
                }
            }
            return list;
        }
        public static Dictionary<string, string> GetBuffDesc(List<int> teamlist)
        {
            Dictionary<int, int> bondageNumDic = GetBondageDicData(teamlist);
            Dictionary<string, string> bondageNameDescDic = GetDescdicData(bondageNumDic);
            return bondageNameDescDic;
        }
        public static List<int> GetBuffIDList(List<int> teamlist)
        {
            Dictionary<int, int> bondageNumDic = GetBondageDicData(teamlist);
            return GetBuffList(bondageNumDic);
        }
        private static List<int> GetBuffList(Dictionary<int, int> bondageNumDic)
        {
            List<int> buffIDList = new List<int>();
            foreach (var item in bondageNumDic)
            {
                if (item.Value < 2) continue;
                var bdata = BondageData.GetData(item.Key);
                if (bdata == null)
                {
                    Debug.LogError("这个bondage没有配好");
                    continue;
                }
                if (item.Value >= 4 && bdata.E4BuffArray[0] != 0)
                {
                    AddBuffid2List(buffIDList, bdata.E4BuffArray);
                }
                else if (item.Value >= 3 && bdata.E3BuffArray[0] != 0)
                {
                    AddBuffid2List(buffIDList, bdata.E3BuffArray);
                }
                else if (item.Value >= 2 && bdata.E2BuffArray[0] != 0)
                {
                    AddBuffid2List(buffIDList, bdata.E2BuffArray);
                }
            }
            return buffIDList;
        }

        private static void AddBuffid2List(List<int> buffIDList, Xint[] buffarray)
        {
            int[] ibuffarray = Xint.ConvertArray(buffarray);
            AddBuffid2List(buffIDList, ibuffarray);
        }

        private static void AddBuffid2List(List<int> buffIDList, int[] buffarray)
        {
            foreach (var buffid in buffarray)
            {
                if (buffid != 0) buffIDList.Add(buffid);
            }
        }

        private static Dictionary<string, string> GetDescdicData(Dictionary<int, int> bondageNumDic)
        {
            Dictionary<string, string> bondageNameDescDic = new Dictionary<string, string>();
            foreach (var item in bondageNumDic)
            {
                if (item.Value < 2) continue;
                var bdata = BondageData.GetData(item.Key);
                if (bdata == null)
                {
                    Debug.LogWarning("这个bondage没有配好");
                    continue;
                }
                if (item.Value >= 4 && bdata.E4BuffArray[0] != 0)
                {
                    bondageNameDescDic.Add(bdata.Name, bdata.DescArray[2]);
                }
                else if (item.Value >= 3 && bdata.E3BuffArray[0] != 0)
                {
                    bondageNameDescDic.Add(bdata.Name, bdata.DescArray[1]);
                }
                else if (item.Value >= 2 && bdata.E2BuffArray[0] != 0)
                {
                    bondageNameDescDic.Add(bdata.Name, bdata.DescArray[0]);
                }
            }
            return bondageNameDescDic;
        }
        private static Dictionary<int, int> GetBondageDicData(List<int> teamlist)
        {
            Dictionary<int, int> bondageNumDic = new Dictionary<int, int>();
            Dictionary<int, int> doubleBondageNumDic = new Dictionary<int, int>();
            foreach (var item in teamlist)
            {
                if (item == 0) continue;
                var herodata = DataModule.Instance.GetHeroData(item);
                var star = herodata.star;
                var cid = herodata.creatureid;
                var bArray = CreatureData.GetData(cid).BondageArray;
                foreach (var bondage in bArray)
                {
                    AddBondageNum(bondageNumDic, bondage, star / 2);
                }
            }
            foreach (var item in bondageNumDic)
            {
                if (item.Value < 2) continue;
                var bdata = BondageData.GetData(item.Key);
                var starNum = CalculateTool.FindNum(item.Key, 1);
                if (bdata == null)
                {
                    Debug.LogError("这个bondage没有配好");
                    continue;
                }
                if (item.Value >= 4 && bdata.E4BuffArray[0] != 0)
                {
                    for (int i = 0; i < bdata.BondageArray.Length; i++)
                    {
                        AddBondageNum(doubleBondageNumDic, bdata.BondageArray[i], starNum);
                    }
                }
                else if (item.Value >= 3 && bdata.E3BuffArray[0] != 0)
                {
                    for (int i = 0; i < bdata.BondageArray.Length; i++)
                    {
                        AddBondageNum(doubleBondageNumDic, bdata.BondageArray[i], starNum);
                    }
                }
                else if (item.Value >= 2 && bdata.E2BuffArray[0] != 0)
                {
                    for (int i = 0; i < bdata.BondageArray.Length; i++)
                    {
                        AddBondageNum(doubleBondageNumDic, bdata.BondageArray[i], starNum);
                    }
                }
            }
            bondageNumDic = bondageNumDic.Concat(doubleBondageNumDic).ToDictionary(k => k.Key, v => v.Value);
            return bondageNumDic;
        }

        private static void AddBondageNum(Dictionary<int, int> bondageNumDic, Xint bondage, int wholestar)
        {
            if (bondage == 0) return;
            var key = bondage * 10 + wholestar;
            for (int i = 1; i < 6; i++)
            {
                var curkey = bondage * 10 + i;
                if (bondageNumDic.ContainsKey(curkey))
                {
                    if (i >= wholestar)
                    {
                        bondageNumDic[curkey] += 1;
                        return;
                    }
                    else
                    {
                        bondageNumDic.Add(key, bondageNumDic[curkey] + 1);
                        bondageNumDic.Remove(bondage * 10 + i);
                        return;
                    }
                }
            }
            bondageNumDic.Add(key, 1);
        }
    }
}