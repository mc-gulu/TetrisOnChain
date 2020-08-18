using MMFramework;
using System;
using System.Collections.Generic;
using UnityEngine;
namespace MMGame
{
    public static class IDTools
    {

        public static int GetCreatureStarUpID(int id, int star)
        {
            return id * 100 + star;
        }

        public static bool IsSameSide(int fromIndex, int toIndex)
        {
            if (BattlefieldModule.Instance.GetCreatureRuntime(fromIndex).baseInfo.ctype.Equals(CreatureType.enimy) && BattlefieldModule.Instance.GetCreatureRuntime(toIndex).baseInfo.ctype.Equals(CreatureType.enimy))
                return true;
            else if (!BattlefieldModule.Instance.GetCreatureRuntime(fromIndex).baseInfo.ctype.Equals(CreatureType.enimy) && !BattlefieldModule.Instance.GetCreatureRuntime(toIndex).baseInfo.ctype.Equals(CreatureType.enimy))
                return true;
            else
                return false;
        }

        public static bool IsSelf(int fromIndex, int toIndex)
        {
            return fromIndex.Equals(toIndex);
        }

        public static int RandPick(Xfloat[] list)
        {
            float[] ilist = Xfloat.ConvertArray(list);
            return RandPick(ilist);
        }

        public static int RandPick(float[] list)
        {
            float sum = 0;
            foreach (var item in list)
            {
                sum = sum + item;
            }
            long tick = System.DateTime.Now.Ticks;
            float rand = UnityEngine.Random.Range(0, sum);
            for (int i = 0; i < list.Length; i++)
            {
                if (rand > list[i])
                {
                    rand = rand - list[i];
                }
                else
                {
                    return i;
                }
            }
            UnityEngine.Debug.LogError("RandPick(float[]) Error");
            return 0;
        }

        public static int IndexFinal(int indexID, int index)
        {
            if (index > ItemData.GetData(ItemTools.Item_ItemIndex).MinID)
            {
                int itemtype = ItemTools.GetIDType(index);
                ItemData itemData = ItemData.GetData(itemtype);
                index = index - itemData.MinID - 1;
            }
            return IndexData.GetData(indexID).IDArray[index];
        }

        public static int GetPhysicsID(int creatureID, int star)
        {
            return CreatureData.GetData(creatureID).PhysicsGroupID * 100 + star;
        }

        public static int GetSkillID(int skillGroupID, int lv)
        {
            if (skillGroupID <= 0)
                return 0;
            int ret = 0;
            SkillGroupData skillGroupData = SkillGroupData.GetData(skillGroupID);
            for (int i = 0; i < skillGroupData.IDArray.Length; i++)
            {
                if (skillGroupData.IDArray[i] > 0 && skillGroupData.LvArray[i] <= lv)
                    ret = skillGroupData.IDArray[i];
                else
                    return ret;
            }
            return ret;
        }


        public static int GetNewHeroID()
        {
            Dictionary<string, RealHeroData> herodict = DataModule.Instance.GetHeroDataDic();

            for (int i = 1; i < ConfigInGame.MaxCreatureNumber; i++)
            {
                if (!herodict.ContainsKey(i.ToString()))
                {
                    return i;
                }
            }
            Debug.LogError("无法分配新ID");
            return -1;
        }

        public static int ThemeIndex(int themeID)
        {
            return themeID - ItemData.GetData(ItemTools.Theme_ItemIndex).MinID;
        }
    }
}