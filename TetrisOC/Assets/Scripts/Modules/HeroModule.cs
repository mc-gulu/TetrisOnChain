using System.Collections.Generic;
using MMFramework;
using UnityEngine;
using LitJson;
using System.Linq;
using System;
using System.ComponentModel;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Math;

namespace MMGame
{
    //不要存临时数据
    public class HeroModule : MonoBehaviour, BaseModule
    {
        public static HeroModule Instance
        {
            get
            {
                return RootModule.Instance.GetModule<HeroModule>();
            }
        }

        public void Init()
        {

        }
        /// <summary>
        /// -201 最大等级，-202 费用不足
        /// </summary>
        /// <param name="id"></param>
        /// <param name="addlv"></param>
        /// <returns></returns>
        public int CanLevelUp(int id, int addlv)
        {
            var rdata = DataModule.Instance.GetHeroData(id);
            //无此角色
            if (rdata == null)
                return -203;
            //找到角色,计算等级+提升等级，检查是否达到最大等级，达到了返回-201
            if (OverMaxLevel(rdata, addlv))
                return -201;
            //找到升级花费，检查是否不够，不够返回-202
            System.Numerics.BigInteger allcost = 0;
            for (int i = rdata.lv; i < rdata.lv + addlv; i++)
            {
                var cost = CalculateTool.Calculate2BigInt(i, CreatureLevelData.GetData(i).CostID);
                allcost += cost;
            }
            string reason = string.Empty;
            if (allcost > DataModule.Instance.Gold)
                return -202;
            return 0;
        }
        bool OverMaxLevel(RealHeroData rdata, int addlv)
        {
            if (rdata == null) return true;
            var curlv = rdata.lv;
            var phyid = IDTools.GetPhysicsID(rdata.creatureid, rdata.star);
            var maxlv = PhysiqueStarData2.GetData(phyid).LevelUpMax;
            return curlv + addlv > maxlv;
        }
        public void LevelUpHero(int id, int addlv)
        {
            var rdata = DataModule.Instance.GetHeroData(id);
            var oldlv = rdata.lv;
            rdata.lv += addlv;
            DataModule.Instance.Set(DataModule.Instance.HeroDataStr(id), rdata);
            for (int i = oldlv; i < rdata.lv; i++)
            {
                var cost = CalculateTool.Calculate2BigInt(i, CreatureLevelData.GetData(i).CostID);
                DataModule.Instance.Gold -= cost;
            }

            if (LogicModule.Instance.IsPrepared(10) && rdata.lv >= 5)
            {
                LogicModule.Instance.Active(10);
            }
        }
        public int CanStarUp(int upid, int[] remids)
        {
            var upidstr = upid.ToString();
            var dic = DataModule.Instance.GetHeroDataDic();
            // -304无此角色
            if (!dic.ContainsKey(upidstr))
                return -304;
            var updata = dic[upidstr];
            // -301 角色满星
            if (IsMaxStar(dic[upidstr]))
                return -301;
            var remdatas = dic.Values.ToArray().Where(data => remids.Contains(data.id)).ToArray();
            // -303 消耗角色不满足条件
            if (!StarUpCreatureCheck(updata, remdatas))
                return -303;
            return 0;
        }
        public bool IsMaxStar(RealHeroData rdata)
        {
            if (rdata == null) return true;
            var curstar = rdata.star;
            var maxstar = CreatureData.GetData(rdata.creatureid).MaxStar;
            return curstar == maxstar;
        }
        bool StarUpCreatureCheck(RealHeroData updata, RealHeroData[] remdatas)
        {
            var starupdata = CreatureStarUpData.GetData(updata.star);
            var cupdata = CreatureData.GetData(updata.creatureid);
            //个数判断
            if (remdatas.Length != starupdata.CostNum)
                return false;
            for (int i = 0; i < remdatas.Length; i++)
            {
                // 同样元素
                var cremdata = CreatureData.GetData(remdatas[i].creatureid);
                if (!cupdata.Element.Equals(cremdata.Element))
                    return false;
                // 同人物，可选
                if (starupdata.IsSameCreature)
                {
                    if (updata.creatureid != remdatas[i].creatureid)
                        return false;
                }
                //if (starupdata.IsSameElement)
                //{
                //    if (!CreatureData.GetData(updata.creatureid).Element.Equals(CreatureData.GetData(remdatas[i].creatureid).Element))
                //        return false;
                //}
                // 星级
                if (remdatas[i].star != starupdata.CostStar)
                    return false;
            }
            return true;
        }
        /// <summary>
        /// 升星操作
        /// </summary>
        /// <param name="upid"></param>
        /// <param name="remids"></param>
        /// <returns>返回显示的资源返还</returns>
        public System.Numerics.BigInteger StarUpAndRemove(int upid, int[] remids)
        {
            var upidstr = upid.ToString();
            var dic = DataModule.Instance.GetHeroDataDic();
            dic[upidstr].star += 1;
            System.Numerics.BigInteger allcost = 0;
            for (int i = 0; i < remids.Length; i++)
            {
                if (CanResetHero(remids[i]) == 0)
                {
                    allcost += ResetHeroGetCost(remids[i]);
                }
                dic.Remove(remids[i].ToString());
            }
            DataModule.Instance.Set(DataModule.Key_HeroDic, dic);
            return allcost;
        }
        /// <summary>
        /// -401 角色1级，-402 花费不足
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int CanResetHero(int id)
        {
            var data = DataModule.Instance.GetHeroData(id);
            if (data == null)
                return -403;    // -403 无此角色
            if (data.lv == 1)
                return -401;   // -401 角色1级
            string reason = string.Empty;
            if (!CostTool.CostCanAfford(ConfigInGame.ResetHeroCostID, ref reason))
                return -402;    // -402 花费不足
            return 0;
        }
        public void ResetHero(int id)
        {
            var cost = ResetHeroGetCost(id);
            DataModule.Instance.Gold += cost;
        }
        public bool HeroListOverMax()
        {
            return DataModule.Instance.GetHeroDataDic().Count >= DataModule.Instance.HeroListMax;
        }
        private System.Numerics.BigInteger ResetHeroGetCost(int id)
        {
            Dictionary<int, int> costs = new Dictionary<int, int>();
            var data = DataModule.Instance.GetHeroData(id);
            var oldlv = data.lv;
            data.lv = 1;
            DataModule.Instance.Set(DataModule.Instance.HeroDataStr(id), data);
            System.Numerics.BigInteger allcost = 0;
            for (int i = 1; i < oldlv; i++)
            {
                var costid = CreatureLevelData.GetData(i).CostID;
                allcost += CalculateTool.Calculate2BigInt(i, costid);
            }

            return allcost;
        }

        public void NewHeroCheck(int id)
        {
            var gotlist = DataModule.Instance.FirstGetHeroList;
            var cid = DataModule.Instance.GetHeroData(id).creatureid;

            if (gotlist.Contains(cid))
            {
                return;
            }

            gotlist.Add(cid);
            DataModule.Instance.FirstGetHeroList = gotlist;

            FrameAnimModule.Instance.AddStruct("newHeroShow", new FrameListen(FrameAniType.Out, AnimStage.End),
                new FrameAct("newHeroShow", FrameData.FrameEnum.HeroNewShowFrame, FrameAniType.In, 0, new object[] { id }));
        }

        public void AutoHeroTeam(Action action)
        {
            if (!DataModule.Instance.AutoHeroTeamUp) {
                action();
                return;    
            }
            var list = DataModule.Instance.GetTeamList();
            var dickeys = DataModule.Instance.GetHeroDataDicOrder1().Keys.ToList();
            int i = 0, j = 0;
            int zeroNum = 4;
            while (i < list.Count && j < dickeys.Count)
            {
                if (list[i] != 0)
                {
                    i++; zeroNum--; continue;
                }
                if (list.Contains(int.Parse(dickeys[j])))
                {
                    j++; continue;
                }
                list[i] = int.Parse(dickeys[j]);
                i++;
                zeroNum--;
            }
            DataModule.Instance.AutoHeroTeamUp = zeroNum != 0;
            EventModule.Instance.HandleEvent(EventEnum.TEAM_CHANGED, 
                new object[]{ list, action});
        }
    }
}