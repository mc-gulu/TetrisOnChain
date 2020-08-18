using System.Collections.Generic;
using MMFramework;
using UnityEngine;
namespace MMGame
{
    public class FightValueModule : MonoBehaviour, BaseModule
    {
        public static FightValueModule Instance
        {
            get
            {
                return RootModule.Instance.GetModule<FightValueModule>();
            }
        }

        List<FightValueInterface> fightmodules;

        public void Init()
        {
            fightmodules = new List<FightValueInterface>();
            fightmodules.Add(PhysiqueModule.Instance);
        }

        public float CalculateValue(BaseInfo baseinfo, FType ftype)
        {
            float ret = 0f;
            for (int i = 0; i < fightmodules.Count; i++)
            {
                ret += fightmodules[i].CalculateValue(baseinfo, ftype);
            }
            return ret;
        }

        public List<int> GetAttribIDList(BaseInfo baseinfo, FType ftype)
        {
            List<int> idlist = new List<int>();
            for (int i = 0; i < fightmodules.Count; i++)
            {
                List<int> list = fightmodules[i].GetAttribIDList(baseinfo, ftype);
                if (list != null)
                    idlist.AddRange(list);
            }
            return idlist;
        }

        public void SetDirty(int heroID, FType[] ftypes)
        {
            BattlefieldModule.Instance.SetHeroDirty(heroID, ftypes);
        }
    }
}