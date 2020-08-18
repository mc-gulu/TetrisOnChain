using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using MMFramework;
namespace MMGame
{
    public enum RuntimeState
    {
        Preload,
        Active,
        Dead
    }
    public enum CreatureType
    {
        partner,
        enimy
    }
    public enum CreatureElement
    {
        fire = 1,
        wind = 2,
        water = 3,
        light = 4,
        dark = 5,
        physics = 6
    }
    public struct OtherDistance
    {
        public int index;
        public float distance;
        public bool inView;
        public CreatureType type;
        /// <summary>
        /// 目标得分
        /// </summary>
        public float point;
    }
    public class CreatureRuntimeData : IAppControl
    {
        public int index;
        public Creature creature;

        public List<SkillRuntimeData> SkillRuntimeDataList;
        public List<OtherDistance> OtherDistanceList;
        /// <summary>
        /// 在领队视野范围内
        /// </summary>
        public bool InView;
        float _hp;
        public float Hp
        {
            get
            {
                float maxhp = MaxHP;
                _hp = Mathf.Clamp(_hp, 0, maxhp);
                return _hp;
            }
            set
            {
                float maxhp = MaxHP;
                float newhp = Mathf.Clamp(value, 0, maxhp);
                var oldhp = _hp;
                _hp = newhp;
                //if (creature != null) creature.topbar.Hp = _hp;
                if (oldhp > float.Epsilon && _hp < float.Epsilon)//死亡
                {
                    Debug.Log(baseInfo.creatureID + "死亡");
                    runtimeState = RuntimeState.Dead;
                    creature.Die();

                    if (baseInfo.ctype.Equals(CreatureType.enimy))
                    {
                        NoticeTool.Broadcast(NoticeEnum.ENIMY_DEAD, new object[] { index });
                        Debug.Log(index + "1");
                    }

                    if (baseInfo.ctype.Equals(CreatureType.partner))
                        NoticeTool.Broadcast(NoticeEnum.HERO_DEAD, new object[] { index });
                }
            }
        }
        public float MaxHP
        {
            get
            {
                return GetFightValue(FType.MAXHP);
            }
        }
        public float BusyTime { get; set; }
        public RuntimeState runtimeState { get; set; }
        public int Pass { get; set; }
        public int BirthIndex { get; set; }
        public Vector3 BirthPos { get; set; }

        public BaseInfo baseInfo = new BaseInfo();

        float[] cachedfloats;
        List<int>[] cachedIDs;

        PETimer bufftimer = new PETimer();

        Dictionary<int, List<int>> runningbuffdict = new Dictionary<int, List<int>>(); //<BuffID,List<计时器ID>>
        Dictionary<int, List<int>> stablebuffdict = new Dictionary<int, List<int>>(); //<BuffID,List<计时器ID>>
        // List<int> stablebufflist = new List<int>(); //<计时器ID>
        public void UpdateTimer()
        {
            bufftimer.Update();
        }
        #region BUFF
        public void AddBuff(int buffID, bool stable, int fromSkillID, BaseInfo fromInfo)
        {
            Dictionary<int, List<int>> buffdict = stable ? stablebuffdict : runningbuffdict;

            BuffData buff = BuffData.GetData(buffID);
            if (buff == null)
            {
                Debug.LogError("没有得到buff:" + buffID);
                return;
            }
            if ((!buffdict.ContainsKey(buffID) || buffdict[buffID].Count == 0) || buff.MultiType == 0) //不包含或单独
            {
                if (!buffdict.ContainsKey(buffID))
                    buffdict[buffID] = new List<int>();
                buffdict[buffID].Add(bufftimer.AddTimeTask(delegate (int tid)
                {
                    int count = bufftimer.GetCount(tid);
                    if (count == 1 && !stable) /*还未减掉本次的时候，是1*/
                    {
                        RemoveBuff(tid, buffID, stable);
                    }

                    //Buff激活
                    ActiveBuff(buffID, fromSkillID, fromInfo);

                }, buff.ActiveInterval,
                PETimeUnit.Second,
                buff.ActiveTime));

                //脏数据
                for (int i = 0; i < buff.AttrArray.Length; i++)
                {
                    int attrID = buff.AttrArray[i];
                    if (attrID > 0)
                    {
                        AttributeData attributeData = AttributeData.GetData(attrID);
                        SetDirty(attributeData.FTypeNum);
                    }
                }

                //BUFF TODO 添加技能
                // ActiveSkillByID();

                creature.AddNewDisplay(buff.DisplayID, float.NaN);
            }
            else if (buff.MultiType == 1) //时间重置
            {
                int timerID = buffdict[buffID][0];
                bufftimer.ResetTimeTaskDesttime(timerID, buff.ActiveInterval, PETimeUnit.Second);
            }
            else if (buff.MultiType == 2) //次数重置
            {
                int timerID = buffdict[buffID][0];
                bufftimer.ResetTimeTaskCount(timerID, buff.ActiveTime);
            }
        }
        public void AddBuffs(List<int> buffIDs, bool stable)
        {
            for (int i = 0; i < buffIDs.Count; i++)
            {
                AddBuff(buffIDs[i], stable, 0, null);
            }
        }
        void RemoveBuff(int tid, int buffID, bool stable)
        {
            if (stable && index == 0)
                Debug.LogError("tid" + tid + " buffID" + buffID);
            Dictionary<int, List<int>> buffdict = stable ? stablebuffdict : runningbuffdict;
            BuffData buff = BuffData.GetData(buffID);

            buffdict[buffID].Remove(tid);
            if (buffdict[buffID].Count == 0)
                buffdict.Remove(buffID);
            creature.RemoveDisplay(buff.DisplayID);

            //脏数据
            for (int i = 0; i < buff.AttrArray.Length; i++)
            {
                int attrID = buff.AttrArray[i];
                if (attrID > 0)
                {
                    AttributeData attributeData = AttributeData.GetData(attrID);
                    SetDirty(attributeData.FTypeNum);
                }
            }

            //BUFF TODO Buff删除技能
        }
        public void ClearBuffs(bool stable)
        {
            Dictionary<int, List<int>> buffdict = stable ? stablebuffdict : runningbuffdict;
            List<int> buffIDs = new List<int>(buffdict.Keys);
            for (int i = 0; i < buffIDs.Count; i++)
            {
                int buffID = buffIDs[i];
                for (int j = 0; j < buffdict[buffID].Count; j++)
                {
                    int timerID = buffdict[buffID][j];
                    bufftimer.DeleteTimeTask(timerID);
                }
            }
            buffdict.Clear();
        }
        float GetBuffValue(Dictionary<int, List<int>> buffs, FType ftype)
        {
            float totalvalue = 0f;
            foreach (var items in buffs)
            {
                int buffID = items.Key;
                int num = items.Value.Count;
                BuffData buffData = BuffData.GetData(buffID);
                float val = AttribTools.GetAttrValues(buffData.AttrArray, (int)ftype);
                totalvalue += val * num;
            }
            return totalvalue;
        }
        List<int> GetBuffAttribList(Dictionary<int, List<int>> buffs, FType ftype)
        {
            List<int> ret = new List<int>();
            foreach (var items in buffs)
            {
                int buffID = items.Key;
                int num = items.Value.Count;
                BuffData buffData = BuffData.GetData(buffID);
                for (int j = 0; j < num; j++)
                {
                    for (int i = 0; i < buffData.AttrArray.Length; i++)
                    {
                        int attrID = buffData.AttrArray[i];
                        if (attrID > 0)
                        {
                            AttributeData data = AttributeData.GetData(attrID);
                            int igenus = data.FTypeNum;
                            if (igenus.Equals((int)ftype))
                            {
                                ret.Add(attrID);
                            }
                        }
                    }
                }
            }
            return ret;
        }
        void ActiveBuff(int buffID, int fromSkillID, BaseInfo fromInfo)
        {
            BuffData buffData = BuffData.GetData(buffID);
            float maxhp = GetFightValue(FType.MAXHP);

            float hp_delta1 = buffData.UnsafeChangeHp;
            float hp_delta2 = maxhp * buffData.ChangeHpByMax;
            float delta = hp_delta1 + hp_delta2;

            if (Mathf.Abs(delta) > float.Epsilon)
            {
                //扣血/回血
                Hp += delta;
                NoticeTool.Broadcast(NoticeEnum.HURT, new object[]
                {
                    new HurtData()
                    { buffid = buffID, damage = -delta, time = Time.time, to = baseInfo, dead = runtimeState == RuntimeState.Dead, skillid = fromSkillID, from = fromInfo}
                });
                //显示飘字
                creature.ShowHpChange(Vector2.zero, buffData.ActiveDisplayID, delta);
            }
        }
        #endregion
        public CreatureRuntimeData(int index, CreatureType ctype, int cID, int physiqueIDIndex, int lv, int star, int birthIndex) : this(index, ctype, cID, physiqueIDIndex, lv, star)
        {
            baseInfo.birthIndex = birthIndex;
        }
        public CreatureRuntimeData(int index, CreatureType ctype, int cID, int physiqueIDIndex, int lv, int star)
        {

            int ftypenum = (int)FType.MAX;
            // Debug.LogError("long" + ftypenum);
            cachedfloats = new float[ftypenum];
            cachedIDs = new List<int>[ftypenum];
            for (int i = 0; i < ftypenum; i++)
            {
                cachedfloats[i] = float.NaN;
                cachedIDs[i] = null;
            }

            OtherDistanceList = new List<OtherDistance>();
            SkillRuntimeDataList = new List<SkillRuntimeData>();

            this.index = index;
            baseInfo.creatureID = cID;
            baseInfo.ctype = ctype;
            baseInfo.physiqueIDIndex = physiqueIDIndex;
            baseInfo.Lv = lv;
            baseInfo.star = star;

            Hp = GetFightValue(FType.MAXHP);
            SetSkill(cID);
        }

        internal void FaceToward(int index)
        {
            if (index == this.index) return;
            else creature.SetFaceToward(index);
        }

        private void SetSkill(int cID)
        {
            #region 技能列表处理
            for (int i = 0; i < CreatureData.GetData(cID).SkillGroupArray.Length; i++)
            {
                int skillGroupID = CreatureData.GetData(cID).SkillGroupArray[i];
                int skillID = IDTools.GetSkillID(skillGroupID, baseInfo.Lv);
                if (skillID > 0)
                {
                    bool issp = (i == 0);
                    if (issp)
                        baseInfo.spskillid = skillID;

                    var spskill = new SkillRuntimeData(SkillData.GetData(skillID), issp);
                    SkillRuntimeDataList.Add(spskill);
                }
            }
            //装备技能等 todo
            //技能按优先级排序
            SkillRuntimeDataList = SkillRuntimeDataList.OrderByDescending(item => item.data.Priority).ToList();
            #endregion
        }
        public SkillRuntimeData GetSpSkill()
        {
            for (int i = 0; i < SkillRuntimeDataList.Count; i++)
                if (SkillRuntimeDataList[i].sp) return SkillRuntimeDataList[i];

            return null;
        }
        private void AddTmpSkill(int skillid)
        {
            var tmpskill = new SkillRuntimeData(SkillData.GetData(skillid));
            for (int i = 0; i < SkillRuntimeDataList.Count; i++)
            {
                if (tmpskill.data.Priority >= SkillRuntimeDataList[i].data.Priority)
                {
                    SkillRuntimeDataList.Insert(i, tmpskill);
                    break;
                }
            }
        }
        private void RemoveTmpSkill(int skillid)
        {
            for (int i = 0; i < SkillRuntimeDataList.Count; i++)
            {
                if (SkillRuntimeDataList[i].data.ID == skillid)
                {
                    SkillRuntimeDataList.RemoveAt(i);
                    break;
                }
            }
        }
        public void UseSkill(int skillindex, int creatureindex)
        {
            var skill = SkillRuntimeDataList[skillindex];
            Debug.LogFormat("对{0}使用技能{1}", creatureindex, skill.data.Name);
            bool isnormal = IsNormalAttack(skill);
            float atkspeedscale = 1;
            if (isnormal)
            {
                atkspeedscale = -GetFightValue(FType.ATK_SPEED_UP_P) + GetFightValue(FType.ATK_SPEED_DOWN_P) + 1;
            }

            //计算CD、公共CD
            if ((skill.data.Busy * atkspeedscale) > BusyTime) { BusyTime = skill.data.Busy * atkspeedscale; }
            // if (index == 0)
            //     Debug.LogError(string.Format("{0} {1}", skill.data.ID, BusyTime));
            //能量
            skill.curEnergy = 0;
            for (int i = 0; i < SkillRuntimeDataList.Count; i++)
            {
                SkillRuntimeDataList[i].curEnergy += skill.data.GetEnergy;
            }
            //sp技能使用处理
            if (skill.sp) skill.use = false;

            ActiveSkillByID(skill.data.ID, creatureindex);
        }
        void ActiveSkillByID(int skillID, int targetIndex)
        {
            // Debug.Log("CreatureRuntimeData.ActiveSkillByID" + skillID + "-" + targetIndex + "-" + (creature == null));
            //技能时给自己上的Buff
            List<int> attrlist = null;
            //属性里面
            if (!IDTools.IsSameSide(index, targetIndex))//对敌人攻击
            {
                attrlist = FightValueModule.Instance.GetAttribIDList(baseInfo, FType.ATK_ENIMY_SELF_ATTACH_BUFF);
            }
            else if (IDTools.IsSelf(index, targetIndex))//对自己
            {
                attrlist = FightValueModule.Instance.GetAttribIDList(baseInfo, FType.ATK_SELF_SELF_ATTACH_BUFF);
            }
            else//对队友
            {
                attrlist = FightValueModule.Instance.GetAttribIDList(baseInfo, FType.ATK_PARTENER_SELF_ATTACH_BUFF);
            }
            List<int> attachlist = new List<int>();//由attrib list 整理成 attach list
            for (int i = 0; i < attrlist.Count; i++)
            {
                int attrID = attrlist[i];
                AttributeData attributeData = AttributeData.GetData(attrID);
                int attachbuffID = System.Convert.ToInt32(attributeData.Value);
                attachlist.Add(attachbuffID);
            }
            //技能里面
            SkillData skillData = SkillData.GetData(skillID);
            if (skillData.AttachSelf > 0)
                attachlist.Add(skillData.AttachSelf);

            //给自己上Buff
            for (int i = 0; i < attachlist.Count; i++)
            {
                A_AttachBuffData attach = A_AttachBuffData.GetData(attachlist[i]);
                if (RandomTools.Rand1(attach.Percent))
                {
                    AddBuff(attach.BuffID, false, skillID, baseInfo);
                }
            }

            //生成子弹数据（静态
            BulletStaticCarry staticCarry = new BulletStaticCarry();
            staticCarry.TargetIndex = targetIndex;
            staticCarry.SkillConditionID = SkillData.GetData(skillID).SkillConditionID;

            staticCarry.fromIndex = index;
            staticCarry.fromSkillID = skillID;
            creature.ActiveSkill(skillID, staticCarry);
        }

        public float GetFightValue(FType ftype)
        {
            int i = (int)ftype;
            float ret = cachedfloats[i];
            if (float.IsNaN(ret))
            {
                ret = FightValueModule.Instance.CalculateValue(baseInfo, ftype);
                ret += GetBuffValue(stablebuffdict, ftype);
                ret += GetBuffValue(runningbuffdict, ftype);
                cachedfloats[i] = ret;
            }
            return ret;
        }

        public float GetFightValueXXX(FType ftype)
        {
            float ret = 1f;
            List<int> list = GetFightIDs(ftype);
            list.AddRange(GetBuffAttribList(stablebuffdict, ftype));
            list.AddRange(GetBuffAttribList(runningbuffdict, ftype));
            for (int i = 0; i < list.Count; i++)
            {
                float temp = 1 - AttributeData.GetData(list[i]).Value;
                ret = ret * temp;
            }

            return ret;
        }


        public float GetFightPercent(FType uptype, FType downtype)
        {
            return GetFightValue(uptype) - GetFightValue(downtype);
        }
        List<int> GetFightIDs(FType ftype)
        {
            int i = (int)ftype;
            List<int> ret = cachedIDs[i];
            if (ret == null)
            {
                ret = FightValueModule.Instance.GetAttribIDList(baseInfo, ftype);
                cachedIDs[i] = ret;
            }
            return new List<int>(ret);//防止后面改动返回值
        }
        public void SetDirty(int ftype)
        {
            int index = ftype;
            cachedfloats[index] = float.NaN;
            cachedIDs[index] = null;
        }
        public void SetDirty(FType[] fTypes)
        {
            for (int i = 0; i < fTypes.Length; i++)
            {
                int index = (int)fTypes[i];
                cachedfloats[index] = float.NaN;
                cachedIDs[index] = null;
            }
        }

        public List<int> GetBulletAttachBuff(int fromIndex, int toIndex, int skillID)
        {
            List<int> target_attachattriblist = null;
            //属性里面
            if (!IDTools.IsSameSide(fromIndex, toIndex))//对敌人攻击
            {
                target_attachattriblist = FightValueModule.Instance.GetAttribIDList(baseInfo, FType.ATK_ENIMY_ATTACH_BUFF);
            }
            else if (!IDTools.IsSelf(fromIndex, toIndex))//对队友
            {
                target_attachattriblist = FightValueModule.Instance.GetAttribIDList(baseInfo, FType.ATK_PARTERNER_ATTACH_BUFF);
            }
            else//对自己
            {
                //忽略
                target_attachattriblist = new List<int>();
            }
            List<int> target_attachlist = new List<int>();//由attrib list 整理成 attach list
            for (int i = 0; i < target_attachattriblist.Count; i++)
            {
                int attrID = target_attachattriblist[i];
                AttributeData attributeData = AttributeData.GetData(attrID);
                int attachbuffID = System.Convert.ToInt32(attributeData.Value);
                target_attachlist.Add(attachbuffID);
            }
            //技能里面
            SkillData skillData = SkillData.GetData(skillID);
            if (skillData.AttachEnimy > 0)
                target_attachlist.Add(skillData.AttachEnimy);
            return target_attachlist;
        }

        public void ButtleCollideMe(Vector2 dir, BulletStaticCarry staticCarry, BulletDynamicCarry dynamicCarry)
        {
            // Debug.LogError(string.Format("{0} {1}", staticCarry.fromIndex, dynamicCarry.Firenode.fireID));
            int fromIndex = staticCarry.fromIndex;
            int fromSkillID = staticCarry.fromSkillID;

            CreatureRuntimeData fromRuntime = BattlefieldModule.Instance.GetCreatureRuntime(fromIndex);
            SkillData skillData = SkillData.GetData(fromSkillID);
            FireData firedata = FireData.GetData(dynamicCarry.Firenode.fireID);

            int toIndex = index;
            CreatureRuntimeData toRuntime = this;

            //被打到时候，打我的子弹附带给我的debuff
            List<int> attachedbuffs = fromRuntime.GetBulletAttachBuff(fromIndex, toIndex, fromSkillID);
            for (int i = 0; i < attachedbuffs.Count; i++)
            {
                int attachID = attachedbuffs[i];
                A_AttachBuffData attach = A_AttachBuffData.GetData(attachID);
                if (RandomTools.Rand1(attach.Percent))
                {
                    AddBuff(attach.BuffID, false, staticCarry.fromSkillID, fromRuntime.baseInfo);
                }
            }

            //计算公式

            /*
            子弹附带元素
                攻击-防御) 
                x 暴击Fire系数 或 非暴击Fire系数
                x (1 + 攻击者攻击伤害加成系数和 + 防御者防御伤害加深系数和) 
                x (攻击者攻击伤害减弱系数乘 x 防御者(不考虑属性)抗性系数乘) 

            子弹不附带元素
                攻击-防御) 
                x 暴击Fire系数 或 非暴击Fire系数
                x (1 + 攻击者攻击伤害加成系数和 + 防御者防御伤害加深系数和 + 攻击者元素加成 + 防御者元素抗性减成) 
                x (攻击者攻击伤害减弱系数乘 x 防御者(不考虑属性)抗性系数乘 x (1 - 攻击者元素减成和) x (1 - 防御者元素抗性和)) 
                x 元素克制系数

            加血
                攻击
                x 暴击Fire系数 或 非暴击Fire系数
                x 攻击者攻击伤害加成系数和
            */


            float atk = fromRuntime.GetFightValue(FType.ATK);
            float def = toRuntime.GetFightValue(FType.DEF);

            float damage = atk - def;

            float bigp = GetFightPercent(FType.BIGP_UP_P, FType.BIGP_DOWN_P);
            bool isbig = RandomTools.Rand1(bigp);
            float skillr = isbig ? firedata.BigAtkr : firedata.Atkr;

            bool iselement = skillData.InheritCreatureElement;
            float elementr = 1;

            float fromupr = fromRuntime.GetFightValue(FType.ATK_UP_P);
            float downupr = toRuntime.GetFightValue(FType.DEF_DOWN_P);

            float upr = (1 + fromupr + downupr);
            float downr = fromRuntime.GetFightValueXXX(FType.ATK_DOWN_P) * toRuntime.GetFightValueXXX(FType.DEF_UP_P);
            if (iselement)
            {
                upr += fromRuntime.GetElementAtkUp() + toRuntime.GetElementDefDown();
                downr = downr * (1 - fromRuntime.GetElementAtkDown()) * (1 - toRuntime.GetElementDefUp());
                int fromelementindex = fromRuntime.GetElementIndex();
                int toelementindex = toRuntime.GetElementIndex();
                elementr = CElementRestrain.GetData(fromelementindex).Arr[toelementindex];
            }
            float finaldamage = 0;
            if (damage > 1)
            {
                //等级差削弱问题
                float lv_r = 1f;
                //只有人打怪时候考虑等级差，怪打人不考虑
                if (fromRuntime.baseInfo.ctype.Equals(CreatureType.partner) && toRuntime.baseInfo.ctype.Equals(CreatureType.enimy))
                {
                    if (fromRuntime.baseInfo.Lv < toRuntime.baseInfo.Lv)
                    {
                        lv_r = (1f - ConfigInGame.LvR * (toRuntime.baseInfo.Lv - fromRuntime.baseInfo.Lv));
                        lv_r = Mathf.Max(lv_r, 0.01f);
                    }
                    // Debug.LogError(string.Format("{0} {1}", (toRuntime.baseInfo.Lv - fromRuntime.baseInfo.Lv), lv_r));
                }


                finaldamage = damage * skillr * upr * downr * elementr * lv_r;

                if (finaldamage > 0 && finaldamage < 1)
                    finaldamage = 1;
            }
            else if (damage > 0)
                finaldamage = 1;
            else if (skillr < 0)
            {
                finaldamage = atk * skillr * (1 + fromupr);
            }

            // if (index == 0)
            //     Debug.LogError(string.Format("skillID {0} {1} {2} {3} {4} {5} {6} {7}", fromSkillID, finaldamage, atk, def, skillr, upr, downr, elementr));

            /*
                //常数A
                var ANUM = ConfigInGame.fightnumA;
                //暴击伤害倍数
                var atkBigDamPer = (UnityEngine.Random.Range(0f, 100.0f) < staticCarry.BigP_P * 100 ? staticCarry.BigD_P : 0) + FireData.GetData(dynamicCarry.Firenode.fireID).BigAtkr;
                //技能伤害系数
                var atkr = FireData.GetData(dynamicCarry.Firenode.fireID).Atkr;
                //攻击计算
                var ATKFINAL = staticCarry.Atk * (1 + staticCarry.Atk_p) * atkr * atkBigDamPer;
                var DEFFINAL = 1f;
                if (staticCarry.IsInheritElement)
                    DEFFINAL = (1 / (GetFightValue(FType.DEF) * (1 + GetFightPercent(FType.DEF_UP_P, FType.DEF_DOWN_P))) * (1 + GetElementDETP(staticCarry.Element) * GetElementRestrain(staticCarry.Element))) * (1 - GetFightValue(FType.REALDAM_P)) + GetFightValue(FType.REALDAM_P);
                else
                    DEFFINAL = (1 / (GetFightValue(FType.DEF) * (1 + GetFightPercent(FType.DEF_UP_P, FType.DEF_DOWN_P)))) * (1 - GetFightValue(FType.REALDAM_P)) + GetFightValue(FType.REALDAM_P);
                var damage = ANUM * ATKFINAL * DEFFINAL;
                Hp -= damage > 0 ? damage : 0;
            */


            //发送伤害事件
            NoticeTool.Broadcast(NoticeEnum.HURT, new object[]
            {
                new HurtData(){from = fromRuntime.baseInfo, to = baseInfo, damage = finaldamage, dead = runtimeState == RuntimeState.Dead, skillid = staticCarry.fromSkillID, buffid = -1, time = Time.time }
            });
            if (runtimeState == RuntimeState.Dead) return;
            FireData fireData = FireData.GetData(dynamicCarry.Firenode.fireID);
            var displayIDs = fireData.ColliderDisplayIDArray;

            for (int i = 0; i < SkillRuntimeDataList.Count; i++)
            {
                SkillRuntimeDataList[i].curEnergy += (ConfigInGame.HitEnergy * (finaldamage / GetFightValue(FType.MAXHP)));
            }
            for (int i = 0; i < displayIDs.Length; i++)
            {
                creature.ShowHpChange(dir, displayIDs[i], finaldamage);
            }

            Hp -= finaldamage;
        }

        public float GetElementRestrain(CreatureElement bulletEle)
        {
            return CElementRestrain.GetData((int)bulletEle).Arr[(int)GetElement()];
        }

        public float GetElementAtkUp()
        {
            CreatureElement cur = GetElement();
            FType[] ftypes = {
                FType.ATK_FIRE_UP_P,
                FType.ATK_WIND_UP_P,
                FType.ATK_WATER_UP_P,
                FType.ATK_LIGHT_UP_P,
                FType.ATK_DARK_UP_P,
                FType.ATK_PHY_UP_P
            };
            int elementindex = CreatureData.GetData(baseInfo.creatureID).Element - 1;
            return GetFightValue(ftypes[elementindex]);
        }

        public float GetElementAtkDown()
        {
            CreatureElement cur = GetElement();
            FType[] ftypes = {
                FType.ATK_FIRE_DOWN_P,
                FType.ATK_WIND_DOWN_P,
                FType.ATK_WATER_DOWN_P,
                FType.ATK_LIGHT_DOWN_P,
                FType.ATK_DARK_DOWN_P,
                FType.ATK_PHY_DOWN_P
            };
            int elementindex = CreatureData.GetData(baseInfo.creatureID).Element - 1;
            return GetFightValue(ftypes[elementindex]);
        }

        public float GetElementDefUp()
        {
            CreatureElement cur = GetElement();
            FType[] ftypes = {
                FType.DEF_FIRE_UP_P,
                FType.DEF_WIND_UP_P,
                FType.DEF_WATER_UP_P,
                FType.DEF_LIGHT_UP_P,
                FType.DEF_DARK_UP_P,
                FType.DEF_PHY_UP_P
            };
            int elementindex = CreatureData.GetData(baseInfo.creatureID).Element - 1;
            return GetFightValue(ftypes[elementindex]);
        }

        public float GetElementDefDown()
        {
            CreatureElement cur = GetElement();
            FType[] ftypes = {
                FType.DEF_FIRE_DOWN_P,
                FType.DEF_WIND_DOWN_P,
                FType.DEF_WATER_DOWN_P,
                FType.DEF_LIGHT_DOWN_P,
                FType.DEF_DARK_DOWN_P,
                FType.DEF_PHY_DOWN_P
            };
            int elementindex = CreatureData.GetData(baseInfo.creatureID).Element - 1;
            return GetFightValue(ftypes[elementindex]);
        }

        public float GetElementATKP()
        {
            CreatureElement cur = GetElement();
            float per = 0;
            switch (cur)
            {
                case CreatureElement.fire:
                    per = GetFightPercent(FType.ATK_FIRE_UP_P, FType.ATK_FIRE_DOWN_P); break;
                case CreatureElement.wind:
                    per = GetFightPercent(FType.ATK_WIND_UP_P, FType.ATK_WIND_DOWN_P); break;
                case CreatureElement.water:
                    per = GetFightPercent(FType.ATK_WATER_UP_P, FType.ATK_WATER_DOWN_P); break;
                case CreatureElement.light:
                    per = GetFightPercent(FType.ATK_LIGHT_UP_P, FType.ATK_LIGHT_DOWN_P); break;
                case CreatureElement.dark:
                    per = GetFightPercent(FType.ATK_DARK_UP_P, FType.ATK_DARK_DOWN_P); break;
                case CreatureElement.physics:
                    per = GetFightPercent(FType.ATK_PHY_UP_P, FType.ATK_PHY_DOWN_P); break;
                default:
                    break;
            }
            return per;
        }
        public float GetElementDETP(CreatureElement bulletEle)
        {
            CreatureElement cur = bulletEle;
            float per = 0;
            switch (cur)
            {
                case CreatureElement.fire:
                    per = GetFightPercent(FType.DEF_FIRE_UP_P, FType.DEF_FIRE_DOWN_P); break;
                case CreatureElement.wind:
                    per = GetFightPercent(FType.DEF_WIND_UP_P, FType.DEF_WIND_DOWN_P); break;
                case CreatureElement.water:
                    per = GetFightPercent(FType.DEF_WATER_UP_P, FType.DEF_WATER_DOWN_P); break;
                case CreatureElement.light:
                    per = GetFightPercent(FType.DEF_LIGHT_UP_P, FType.DEF_LIGHT_DOWN_P); break;
                case CreatureElement.dark:
                    per = GetFightPercent(FType.DEF_DARK_UP_P, FType.DEF_DARK_DOWN_P); break;
                case CreatureElement.physics:
                    per = GetFightPercent(FType.DEF_PHY_UP_P, FType.DEF_PHY_DOWN_P); break;
                default:
                    break;
            }
            return per;
        }
        public int GetElementIndex()
        {
            return CreatureData.GetData(baseInfo.creatureID).Element;
        }
        private CreatureElement GetElement()
        {
            return (CreatureElement)Enum.ToObject(typeof(CreatureElement), CreatureData.GetData(baseInfo.creatureID).Element);
        }

        public void Regist(Creature creature)
        {
            this.creature = creature;
        }

        public void UnRegist(Creature creature)
        {
            if (this.creature && this.creature.Equals(creature))
                this.creature = null;
        }

        public Vector2 Pos { get { return creature ? (Vector2)creature.transform.position : Vector2.zero; } set { creature.transform.position = value; } }
        public Vector2 TargetPos
        {
            get { return creature ? creature.TargetPos : default; }
            set { creature.TargetPos = value; }
        }
        public float Circle
        {
            get
            {
                if (creature != null)
                {
                    return creature.GetCircle();
                }
                else
                {
                    return 0;
                }
            }
        }
        public void Move(Vector2 dir)
        {
            if (creature) creature.Move(dir);
        }
        public void Idle()
        {
            if (creature != null) creature.Idle();
        }
        public void MoveTo(Vector3 pos)
        {
            if (creature != null) creature.MoveTo(pos);
        }


        public CreatureType GetHostileType()
        {

            if (baseInfo.ctype == CreatureType.partner)
                return CreatureType.enimy;
            else
                return CreatureType.partner;
        }

        public void OnPause(bool pause)
        {
            bufftimer.PauseAllTask(pause);
        }

        public void OnTimeScale(float scaleNum)
        {
            bufftimer.MutiSpeedChangeAllTask(scaleNum);
        }

        // public void IsMoving(bool move)
        // {
        //     creature.move = move;
        // }

        public bool IsNormalAttack(SkillRuntimeData skill)
        {
            CreatureData creatureData = CreatureData.GetData(baseInfo.creatureID);
            int skillID = IDTools.GetSkillID(creatureData.SkillGroupArray[2], baseInfo.Lv);
            if (skillID.Equals(skill.data.ID))
            {
                return true;
            }
            return false;
        }
    }
}