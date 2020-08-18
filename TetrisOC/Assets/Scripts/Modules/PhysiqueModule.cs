using System.Collections.Generic;
using MMFramework;
using UnityEngine;
namespace MMGame
{
    public class PhysiqueModule : MonoBehaviour, BaseModule, FightValueInterface
    {
        public static PhysiqueModule Instance
        {
            get
            {
                return RootModule.Instance.GetModule<PhysiqueModule>();
            }
        }

        public void Init()
        {

        }

        public void Upgrade(int heroID, int tolv)
        {
            FightValueModule.Instance.SetDirty(heroID, new FType[] { FType.ATK, FType.MAXHP });
        }

        public float CalculateValue(BaseInfo baseinfo, FType ftype)
        {
            if (ftype.Equals(FType.ATK))
            {
                CreatureData creatureData = CreatureData.GetData(baseinfo.creatureID);
                PhysiqueStarData2 physiqueData = PhysiqueStarData2.GetData(baseinfo.physiqueIDIndex);
                return CalculateTool.CalculateFormula(baseinfo.Lv, physiqueData.AtkFormula, physiqueData.AtkParameterArray, true);
            }
            else if (ftype.Equals(FType.DEF))
            {
                CreatureData creatureData = CreatureData.GetData(baseinfo.creatureID);
                PhysiqueStarData2 physiqueData = PhysiqueStarData2.GetData(baseinfo.physiqueIDIndex);
                return CalculateTool.CalculateFormula(baseinfo.Lv, physiqueData.DefFormula, physiqueData.DefParameterArray, true);
            }
            else if (ftype.Equals(FType.MAXHP))
            {
                CreatureData creatureData = CreatureData.GetData(baseinfo.creatureID);
                PhysiqueStarData2 physiqueData = PhysiqueStarData2.GetData(baseinfo.physiqueIDIndex);
                return CalculateTool.CalculateFormula(baseinfo.Lv, physiqueData.HpFormula, physiqueData.HpParameterArray, true);
            }
            // else if (ftype.Equals(FType.TOU))
            // {
            //     CreatureData creatureData = CreatureData.GetData(baseinfo.creatureID);
            //     PhysiqueStarData physiqueData = PhysiqueStarData.GetData(baseinfo.physiqueIDIndex);
            //     return CalculateTool.CalculateFormula(baseinfo.Lv, physiqueData.ToughFormula);
            // }
            else
                return 0;
        }

        public List<int> GetAttribIDList(BaseInfo baseinfo, FType ftype)
        {
            return null;
        }

        public FType[] GetMask(BaseInfo baseinfo)
        {
            return new FType[0];
        }

    }
}