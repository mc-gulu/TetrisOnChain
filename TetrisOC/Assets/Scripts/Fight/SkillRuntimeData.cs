using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace MMGame {
    public class SkillRuntimeData
    {
        public SkillData data;

        public Xfloat curEnergy;
        public bool sp;
        public bool use;

        public SkillRuntimeData(SkillData data)
        {
            this.data = data;
            curEnergy = 0;
        }
        public SkillRuntimeData(SkillData data, bool sp)
        {
            this.data = data;
            curEnergy = 0;
            this.sp = sp;
        }

        /// <summary>
        /// 是否可以释放
        /// </summary>
        /// <returns></returns>
        internal bool Ready()
        {
            if (sp && !ConfigInGame.AutoSpSkill)
            {
                return (curEnergy >= data.NeedEnergy) && use;
            }
            else
            {
                return (curEnergy >= data.NeedEnergy);
            }
        }
    }
}