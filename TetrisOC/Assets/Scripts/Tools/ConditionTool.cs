using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

namespace MMGame {
    public class ConditionTool
    {
        public static float GetPoint(SkillData skilldata, int selfIndex, OtherDistance other, out bool thresholdPass)
        {
            float point = 0;
            var threshold = SkillConditionData.GetData(skilldata.SkillConditionID).Threshold;
            var singleConditionArr = SkillConditionData.GetData(skilldata.SkillConditionID).ConditionArray;
            var selfCRData = BattlefieldModule.Instance.GetCreatureRuntime(selfIndex);
            var otherCRdata = BattlefieldModule.Instance.GetCreatureRuntime(other.index);
            var isSelf = selfIndex == other.index;
            var isHostile = selfCRData.GetHostileType() == otherCRdata.baseInfo.ctype;
            for (int i = 0; i < singleConditionArr.Length; i++)
            {
                if (singleConditionArr[i] == 0) continue;
                var condition = SingleConditionData.GetData(singleConditionArr[i]);

                if (condition.ConditionType == 1) //血量越低分数越高
                {
                    var singleConditionData = SingleConditionData.GetData(singleConditionArr[i]);
                    point += (1 - otherCRdata.Hp / otherCRdata.GetFightValue(FType.MAXHP)) * 10;
                }
                else if (condition.ConditionType == 2)//距离
                {
                    point += skilldata.Range / (skilldata.Range + other.distance);
                }
                else if (condition.ConditionType == 4)//目标是敌人
                {
                    if (!isHostile) point += -10000;
                }
                else if (condition.ConditionType == 5)//目标是友军
                {
                    if (isHostile) point += -10000;
                }
                else if (condition.ConditionType == 6)//目标自己
                {
                    if (!isSelf) point += -10000;
                }
                else if (condition.ConditionType == 7)//不含自己
                {
                    if (isSelf) point += -10000;
                }
                else if (condition.ConditionType == 8) //随机角色
                {
                    point += Random.Range(0.01f, 1);
                }
            }
            thresholdPass = point >= threshold;
            return point;
        }

        public static bool BulletCollidePoint(int ConditionID,int ownerindex, int CollideIndex) 
        {
            float point = 0;
            var singleConditionArr = SkillConditionData.GetData(ConditionID).ConditionArray;
            var selfCRData = BattlefieldModule.Instance.GetCreatureRuntime(ownerindex);
            var otherCRdata = BattlefieldModule.Instance.GetCreatureRuntime(CollideIndex);
            var isSelf = ownerindex == CollideIndex;
            var isHostile = selfCRData.GetHostileType() == otherCRdata.baseInfo.ctype;
            for (int i = 0; i < singleConditionArr.Length; i++)
            {
                if (singleConditionArr[i] == 0) continue;
                var condition = SingleConditionData.GetData(singleConditionArr[i]);

                if (condition.ConditionType == 1) //血量越低分数越高
                {
                    var singleConditionData = SingleConditionData.GetData(singleConditionArr[i]);
                    point += (1 - otherCRdata.Hp / otherCRdata.GetFightValue(FType.MAXHP)) * 10;
                }
                else if (condition.ConditionType == 4)//目标是敌人
                {
                    if (!isHostile) point += -10000;
                }
                else if (condition.ConditionType == 5)//目标是友军
                {
                    if (isHostile) point += -10000;
                }
                else if (condition.ConditionType == 6)//目标自己
                {
                    if (!isSelf) point += -10000;
                }
                else if (condition.ConditionType == 7)//不含自己
                {
                    if (isSelf) point += -10000;
                }
            }
            return point >= 0;
        }

    }
}