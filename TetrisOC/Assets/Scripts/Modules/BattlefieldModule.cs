using System.Collections.Generic;
using System.Linq;
using MMFramework;
using UnityEngine;
namespace MMGame
{
    public enum BattleState
    {
        normal,
        fighting,
    }
    public class BattlefieldModule : MonoBehaviour, BaseModule, IAppControl
    {
        public static BattlefieldModule Instance
        {
            get
            {
                return RootModule.Instance.GetModule<BattlefieldModule>();
            }
        }
        //所有角色都在一起
        List<CreatureRuntimeData> creatures = new List<CreatureRuntimeData>();
        List<CreatureRuntimeData> activeCreatures = new List<CreatureRuntimeData>();
        PETimer logicFrameTimer;
        private float delay = 0.1f;
        public BattleState BattleState { get; set; }
        public Transform MachinePoint { get; set; }
        public void Init() { }
        public void StartFight()
        {
            logicFrameTimer = new PETimer();

            #region 逻辑帧
            logicFrameTimer.AddTimeTask(num => { /*Debug.Log("帧逻辑开始" + num); */ }, delay, PETimeUnit.Second, 0);
            //获取当前活跃角色
            logicFrameTimer.AddTimeTask(num =>
            {
                activeCreatures.Clear();
                for (int i = 0; i < creatures.Count; i++)
                    if (creatures[i].runtimeState == RuntimeState.Active) activeCreatures.Add(creatures[i]);
            }, delay, PETimeUnit.Second, 0);
            //计算自身busy
            logicFrameTimer.AddTimeTask(num =>
            {
                for (int i = 0; i < activeCreatures.Count; i++)
                {
                    var tmpCreature = activeCreatures[i];
                    if (tmpCreature == null) continue;

                    float atkspeed = Mathf.Max((1 + tmpCreature.GetFightPercent(FType.ATK_SPEED_UP_P, FType.ATK_SPEED_DOWN_P)), 0.01f);
                    float normalatkdelay = delay * atkspeed;

                    if (tmpCreature.BusyTime > 0) tmpCreature.BusyTime -= delay;
                }
            }, 100, PETimeUnit.Millisecond, 0);
            //计算所有人和所有人的距离
            logicFrameTimer.AddTimeTask(_ =>
            {
                for (int i = 0; i < activeCreatures.Count; i++)
                {
                    activeCreatures[i].OtherDistanceList.Clear();
                }
                for (int i = 0; i < activeCreatures.Count; i++)
                {
                    var distance = Vector3.Distance(MachinePoint.position, activeCreatures[i].Pos);
                }
                for (int i = 0; i < activeCreatures.Count; i++)
                {
                    for (int j = i; j < activeCreatures.Count; j++)
                    {
                        var cA = activeCreatures[i];
                        var cB = activeCreatures[j];
                        var distance = Vector3.Distance(cA.Pos, cB.Pos);
                        cA.OtherDistanceList.Add(new OtherDistance() { index = activeCreatures[j].index, distance = Mathf.Max((distance - cB.Circle), 0), inView = cB.InView, type = cB.baseInfo.ctype });
                        if (i != j)
                            cB.OtherDistanceList.Add(new OtherDistance() { index = activeCreatures[i].index, distance = Mathf.Max((distance - cA.Circle), 0), inView = cA.InView, type = cA.baseInfo.ctype });
                    }
                }
            }, delay, PETimeUnit.Second, 0);
            //所有人对自己的列表排序
            logicFrameTimer.AddTimeTask(_ =>
            {
                for (int i = 0; i < activeCreatures.Count; i++)
                    activeCreatures[i].OtherDistanceList = activeCreatures[i].OtherDistanceList.OrderBy(item => item.distance).ToList();
            }, delay, PETimeUnit.Second, 0);
            //产生每个人行为
            logicFrameTimer.AddTimeTask(num =>
            {
                for (int i = 0; i < activeCreatures.Count; i++)
                {
                    if (activeCreatures[i].baseInfo.ctype == CreatureType.partner)
                    {
                        Behavior(activeCreatures[i].index, CreatureType.partner, CreatureType.enimy);
                    }
                    else if (activeCreatures[i].baseInfo.ctype == CreatureType.enimy)
                    {
                        Behavior(activeCreatures[i].index, CreatureType.enimy, CreatureType.partner);
                    }
                }
            }, delay, PETimeUnit.Second, 0);

            logicFrameTimer.AddTimeTask(num => { /*Debug.Log("帧逻辑结束" + num);*/ }, delay, PETimeUnit.Second, 0);
            #endregion
        }

        //行为
        private void Behavior(int index, CreatureType friends, CreatureType hostiles)
        {
            var creature = creatures[index];
            if (creature.BusyTime > 0)
            {
                return;
            }

            var skills = creature.SkillRuntimeDataList;
            OtherDistance curTarget = new OtherDistance() { index = -1, point = -1 };
            int curskillIndex = -1;
            //攻击范围内第一轮遍历
            for (int i = 0; i < skills.Count; i++)
            {
                var skill = skills[i];
                if (!skill.Ready()) continue;
                //每个角色
                for (int j = 0; j < creature.OtherDistanceList.Count; j++)
                {
                    var other = creature.OtherDistanceList[j];
                    if (other.distance > skill.data.Range) { }
                    else
                    {
                        other.point = ConditionTool.GetPoint(skill.data, index, other, out bool thresholdPass);
                        //超过阈值直接返回，未超过查看是否替换
                        if (thresholdPass)
                        {
                            curTarget = other;
                            curskillIndex = i;
                            break;
                        }
                        else if ((curTarget.Equals(default) && other.point >= 0) || other.point > curTarget.point)
                        {
                            curTarget = other;
                            curskillIndex = i;
                        }
                    }
                }
                //目标确定
                if (!curTarget.Equals(default) && curTarget.index != -1 && curskillIndex != -1)
                {
                    creature.Idle();
                    creature.FaceToward(curTarget.index);
                    creature.UseSkill(curskillIndex, curTarget.index);
                    // creature.IsMoving(false);
                    Debug.Log(index + "对" + curTarget.index + "使用" + curskillIndex);
                    return;
                }
            }

            //无目标，视野范围内第二轮遍历
            for (int i = 0; i < skills.Count; i++)
            {
                var skill = skills[i];
                if (!skill.Ready()) continue;
                if (friends == creature.baseInfo.ctype)
                    for (int j = 0; j < creature.OtherDistanceList.Count; j++)
                    {
                        var other = creature.OtherDistanceList[j];
                        //清理不在视野和第一次遍历过的
                        if ((!other.inView) || other.distance <= skill.data.Range) continue;
                        bool thresholdPass = false;
                        other.point = ConditionTool.GetPoint(skill.data, index, other, out thresholdPass);
                        if (thresholdPass)
                        {
                            curTarget = other;
                            break;
                        }
                        else if ((curTarget.Equals(default) && other.point >= 0) || other.point > curTarget.point)
                        {
                            curTarget = other;
                        }
                    }
                else
                    //类别为敌人时
                    for (int j = 0; j < creature.OtherDistanceList.Count; j++)
                    {
                        var other = creature.OtherDistanceList[j];
                        if (other.distance < ConfigInGame.enemyViewDistance)
                        {
                            other.point = ConditionTool.GetPoint(skill.data, index, other, out bool thresholdPass);
                            if (thresholdPass)
                            {
                                curTarget = other;
                                break;
                            }
                            else if ((curTarget.Equals(default) && other.point >= 0) || other.point > curTarget.point)
                            {
                                curTarget = other;
                            }
                        }
                        other.point = 1;
                        if (curTarget.point < other.point)
                            curTarget = other;
                    }
                //存在目标则走向目标
                if (!curTarget.Equals(default) && curTarget.index != -1)
                {
                    creature.MoveTo(creatures[curTarget.index].Pos);
                    return;
                }
            }

            if (creature.baseInfo.ctype.Equals(CreatureType.partner))
            {
                //没有目标，
                if (Vector2.Distance(creature.BirthPos, creature.Pos) > ConfigInGame.transportDistance)
                {
                    creature.Pos = creature.BirthPos;
                    // Debug.Log("瞬移到出生点");
                }
                else if (Vector2.Distance(creature.BirthPos, creature.Pos) > ConfigInGame.followDistance)
                {
                    creature.MoveTo(creature.BirthPos);
                    // Debug.Log("走走向出生点");
                }
                else
                {
                    creature.Idle();
                    // Debug.Log("不动");
                }
            }
            else
            {
                creature.Idle();
                // Debug.Log(index + "不动");
            }

        }

        //子弹碰撞的处理
        public void BulletColide(int index, Vector2 dir, BulletStaticCarry staticCarry, BulletDynamicCarry dynamicCarry)
        {
            creatures[index].ButtleCollideMe(dir, staticCarry, dynamicCarry);
        }

        public List<int> GetHeroRuntimeIDList()
        {
            List<int> ret = new List<int>();
            for (int i = 0; i < creatures.Count; i++)
            {
                if (creatures[i].baseInfo.ctype.Equals(CreatureType.partner))
                    ret.Add(i);
            }
            return ret;
        }

        public List<int> GetEnimy()
        {
            List<int> ret = new List<int>();
            for (int i = 0; i < creatures.Count; i++)
            {
                if (creatures[i].baseInfo.ctype.Equals(CreatureType.enimy))
                    ret.Add(i);
            }
            return ret;
        }

        public CreatureRuntimeData GetCreatureRuntime(int index)
        {
            if (creatures.Count > index)
            {
                return creatures[index];
            }
            else
                return null;
        }
        public int[] GetFriendCreaturesIndex()
        {
            return creatures.Where(crd => crd.baseInfo.ctype != CreatureType.enimy).Select(crd => crd.index).ToArray();
        }
        public void AddCreatureData(CreatureRuntimeData rd)
        {
            creatures.Add(rd);
        }
        public void RemoveAllCreature()
        {
            for (int i = creatures.Count - 1; i >= 0; i--)
            {
                if (creatures[i].creature)
                    creatures[i].UnRegist(creatures[i].creature);
                creatures.RemoveAt(i);
            }
        }
        public void RemoveDeadEnimy()
        {
            for (int i = creatures.Count - 1; i >= 0; i--)
            {
                if (creatures[i].baseInfo.ctype == CreatureType.enimy && creatures[i].runtimeState == RuntimeState.Dead)
                {
                    if (creatures[i].creature)
                        creatures[i].UnRegist(creatures[i].creature);
                    creatures.RemoveAt(i);
                }

            }
        }
        public int CreaturesCount()
        {
            return creatures.Count;
        }
        public int ActiveEnimyByPass(int pass)
        {
            int ret = 0;
            for (int i = 0; i < creatures.Count; i++)
            {
                CreatureRuntimeData rd = creatures[i];
                if (rd.Pass == pass && rd.baseInfo.ctype == CreatureType.enimy && rd.runtimeState == RuntimeState.Preload)
                {
                    rd.runtimeState = RuntimeState.Active;
                    ret++;
                }
            }

            return ret;
        }

        public bool controlling;
        private void Update()
        {
            for (int i = 0; i < creatures.Count; i++)
            {
                CreatureRuntimeData runtimeData = creatures[i];
                if (runtimeData.runtimeState == RuntimeState.Active)
                {
                    runtimeData.UpdateTimer();
                }
            }
            if (logicFrameTimer != null)
                logicFrameTimer.Update();
        }

        private void OnDestroy()
        {
            if (logicFrameTimer != null)
            {
                logicFrameTimer.Reset();
                logicFrameTimer = null;
            }
        }

        public void SetHeroDirty(int heroID, FType[] fTypes)
        {
            for (int i = 0; i < creatures.Count; i++)
            {
                if (creatures[i].baseInfo.creatureID == heroID)
                {
                    creatures[i].SetDirty(fTypes);
                    break;
                }
            }
        }

        public void OnPause(bool pause)
        {
            Debug.Log("_____pause_____" + pause);
            for (int i = 0; i < creatures.Count; i++)
            {
                creatures[i].OnPause(pause);
            }
            logicFrameTimer.PauseAllTask(pause);
        }

        public void OnTimeScale(float scaleNum)
        {
            for (int i = 0; i < creatures.Count; i++)
            {
                creatures[i].OnTimeScale(scaleNum);
            }
            logicFrameTimer.MutiSpeedChangeAllTask(scaleNum);
        }
    }
}