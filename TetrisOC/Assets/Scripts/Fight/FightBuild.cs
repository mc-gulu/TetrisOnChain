using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LitJson;
namespace MMGame
{
    public static class FightBuild
    {
        public static FightStruct DownFloor(int floorID)
        {
            FightStruct fs = new FightStruct();
            List<RealHeroData> heros = DataModule.Instance.GetTeamListData();
            fs.herobuildlist = new List<CreatureBuild>();
            for (int i = 0; i < heros.Count; i++)
            {
                if (heros[i] == null)
                {
                    fs.herobuildlist.Add(null);
                }
                else if (heros[i] != null && heros[i].creatureid > 0)
                {
                    CreatureBuild cb = new CreatureBuild();
                    cb.posID = i;
                    cb.lv = heros[i].lv;
                    cb.star = heros[i].star;
                    cb.creatureid = heros[i].creatureid;
                    cb.delay = 0;
                    fs.herobuildlist.Add(cb);
                }
            }

            FloorFightData ffd = FloorFightData.GetData(floorID);
            List<List<EnimyStruct>> enimies = EnimyModule.Instance.GetEnimies(ffd.EnimyTag);
            fs.enimybuildlist = new List<List<CreatureBuild>>();
            for (int i = 0; i < enimies.Count; i++)
            {
                fs.enimybuildlist.Add(new List<CreatureBuild>());
                for (int j = 0; j < enimies[i].Count; j++)
                {
                    EnimyStruct es = enimies[i][j];
                    if (ItemTools.IsIndexID(es.creatureID))
                        es.creatureID = IDTools.IndexFinal(es.creatureID, ffd.ThemeID);
                    es.lv += ffd.EnimyLevelAdd;
                    es.star += ffd.EnimyStarAdd;
                    enimies[i][j] = es;
                    for (int k = 0; k < es.num; k++)
                    {
                        CreatureBuild cb = new CreatureBuild();
                        cb.posID = es.birthIndex;
                        cb.lv = es.lv;
                        cb.star = es.star;
                        cb.creatureid = es.creatureID;
                        cb.delay = j * 3;

                        fs.enimybuildlist[i].Add(cb);
                    }
                }
            }
            return fs;
        }

        public static FightStruct PVP(string enimyjson)
        {
            FightStruct fs = new FightStruct();
            List<RealHeroData> heros = DataModule.Instance.GetTeamListData();
            fs.herobuildlist = new List<CreatureBuild>();
            for (int i = 0; i < heros.Count; i++)
            {
                if (heros[i].creatureid > 0)
                {
                    CreatureBuild cb = new CreatureBuild();
                    cb.posID = i;
                    cb.lv = heros[i].lv;
                    cb.star = heros[i].star;
                    cb.creatureid = heros[i].creatureid;
                    cb.delay = 0;
                    fs.herobuildlist.Add(cb);
                }
            }

            fs.enimybuildlist = new List<List<CreatureBuild>>();
            fs.enimybuildlist.Add(new List<CreatureBuild>());
            List<RealHeroData> enimies = GetHeroByJson(enimyjson);
            for (int i = 0; i < enimies.Count; i++)
            {
                if (enimies[i].creatureid > 0)
                {
                    CreatureBuild cb = new CreatureBuild();
                    cb.posID = i;
                    cb.lv = enimies[i].lv;
                    cb.star = enimies[i].star;
                    cb.creatureid = enimies[i].creatureid;
                    cb.delay = 0;
                    fs.enimybuildlist[0].Add(cb);
                }
            }
            return fs;
        }

        public static string GetHeroJson()
        {
            List<RealHeroData> heros = DataModule.Instance.GetTeamListData();
            return LitJson.JsonMapper.ToJson(heros);
        }

        public static List<RealHeroData> GetHeroByJson(string json)
        {
            return LitJson.JsonMapper.ToObject<List<RealHeroData>>(json);
        }
    }
}
