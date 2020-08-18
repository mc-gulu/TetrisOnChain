using UnityEngine;
namespace MMGame
{
    public class BulletStaticCarry
    {
        //-------------逻辑信息
        public int OwnerIndex;
        public int TargetIndex;
        public int SkillConditionID;
        public Transform TargetTrans;
        public float up; //子弹高度
        // public readonly Group Group;

        //-------------战斗数据
        public int fromIndex;//来自于哪个人
        public int fromSkillID;//来自于哪个技能

        // public float Atk;//总攻击常数
        // public float Atk_p;//总攻击修改百分比
        // public float BigP_P;//本次暴击概率
        // public float BigD_P;//本次暴击伤害倍率
        // public bool IsInheritElement;//继承来自角色的元素
        // public CreatureElement Element;//元素
        // public readonly float Truehurt;
        // public readonly float Truehurt_k;
        // public int[] Attachbuff;
        //public readonly float[] Attachbuff_k;
        // public readonly float Big_k;
        // public readonly float Vampire_p;
        // public readonly float Recover;
        // public readonly float Recover_p;
        public BulletStaticCarry() { }
        public BulletStaticCarry(
            int OwnerIndex,
            int TargetIndex,
            Transform TargetTrans,
            float up, //子弹高度
            int index,
            int skillID
        // Group Group,
        // float Atk,
        // float Atk_p,
        // float Truehurt,
        // float Truehurt_k,
        // int[] Attachbuff,
        // //float[] Attachbuff_k,
        // float Big_k,
        // float Vampire_p,
        // float Recover,
        // float Recover_p,
        // int SkillConditionID
        )
        {
            this.OwnerIndex = OwnerIndex;
            this.TargetIndex = TargetIndex;
            this.TargetTrans = TargetTrans;
            this.up = up;
            this.fromIndex = index;
            this.fromSkillID = skillID;
            // this.Group = Group;
            // this.Atk = Atk;
            // this.Atk_p = Atk_p;
            // this.Truehurt = Truehurt;
            // this.Truehurt_k = Truehurt_k;
            // this.Attachbuff = Attachbuff;
            //this.Attachbuff_k = Attachbuff_k;
            // this.Big_k = Big_k;
            // this.Vampire_p = Vampire_p;
            // this.Recover = Recover;
            // this.Recover_p = Recover_p;
            // this.SkillConditionID = SkillConditionID;
        }
    }
}