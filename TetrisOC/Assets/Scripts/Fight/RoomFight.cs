using System.Collections;
using System.Collections.Generic;
using MMFramework;
using UnityEngine;
using UnityEngine.Rendering;

namespace MMGame
{
    public class RoomFight : MonoBehaviour
    {
        
        private Transform unitsobjlayer;
        private Transform unitsuilayer;

        List<List<CreatureBuild>> enimies;
        int enimy_num = 0;
        int player_num = 0;

        protected bool can_star_strengh = true;
        protected bool hasactived = false;
        public void InitRoom()
        {
            
            RoomLoader loader = GameController.Instance.roomobj.GetComponent<RoomLoader>();
            unitsobjlayer = loader.unitsobjlayer;
            unitsuilayer = loader.unitsuilayer;
        }
        public void SetPlayerCreatures(List<CreatureBuild> herobuildlist)
        {
            if (herobuildlist == null) return;
            player_num = 0;
            for (int i = 0; i < herobuildlist.Count; i++)
            {
                var rhdata = herobuildlist[i];
                if (rhdata == null) continue;
                var partner = new CreatureRuntimeData(
                        BattlefieldModule.Instance.CreaturesCount(),
                        CreatureType.partner,
                        rhdata.creatureid,
                        IDTools.GetPhysicsID(rhdata.creatureid, rhdata.star),
                        rhdata.lv,
                        rhdata.star,
                        i);
                BattlefieldModule.Instance.AddCreatureData(partner);
                partner.runtimeState = RuntimeState.Active;
                player_num++;
            }
        }
        public virtual void SetEnimies(List<CreatureBuild> enimies)
        {
            if (enimies != null)
            {
                //向battlefield中添加怪物，设置成未出生状态
                for (int i = 0; i < enimies.Count; i++)
                {
                    var list = enimies[i];
                    CreatureRuntimeData rd = new CreatureRuntimeData(
                        BattlefieldModule.Instance.CreaturesCount(),
                        CreatureType.enimy,
                        enimies[i].creatureid,
                        IDTools.GetPhysicsID(enimies[i].creatureid, enimies[i].star),
                        enimies[i].lv,
                        enimies[i].star);
                    rd.Pass = i;
                    rd.BirthIndex = enimies[i].posID;
                    rd.runtimeState = RuntimeState.Preload;
                    BattlefieldModule.Instance.AddCreatureData(rd);
                }
            }
        }
        public void CreateCreatures()
        {
            Transform birth = GameController.Instance.mapobj.transform.GetChild(0).Find("event/playerbirth");
            if (birth == null)
                Debug.LogError("hero找不到出生点");
            List<int> list = BattlefieldModule.Instance.GetHeroRuntimeIDList();
            for (int i = 0; i < list.Count; i++)
            {
                int index = list[i]; 
                var creatureobj = Creature.CreateCreature(unitsobjlayer, index);
                var rdata = BattlefieldModule.Instance.GetCreatureRuntime(index);
                rdata.AddBuffs(BondageTool.GetBuffIDList(DataModule.Instance.GetTeamList()), true);
                Vector2 birthpos = birth.GetChild(rdata.baseInfo.birthIndex).position;
                creatureobj.transform.position = birthpos;
                GameController.Instance.Add2TargetGroup(creatureobj.transform, 1, 1);
            }
        }
        void ActiceEnimy()
        {
            List<int> list = BattlefieldModule.Instance.GetEnimy();
            for (int i = 0; i < list.Count; i++)
            {
                int index = list[i];
                CreatureRuntimeData rd = BattlefieldModule.Instance.GetCreatureRuntime(index);
                BoxCollider2D birthbox = GameController.Instance.mapobj.transform.GetChild(0).Find("event/enimybirth/birth_" + rd.BirthIndex.ToString()).GetComponent<BoxCollider2D>(); ;
                if (birthbox == null)
                    Debug.LogError("hero找不到出生点");
                else if (rd.runtimeState == RuntimeState.Dead)
                {
                    continue;
                }
                else
                {
                    GameObject creatureobj = Creature.CreateCreature(unitsobjlayer, index);
                    Vector2 pos = birthbox.transform.position;
                    Rect rect = new Rect(pos - birthbox.size / 2, birthbox.size);

                    Vector2 birthpos = RandomTools.GetRandomPos(rect);
                    creatureobj.transform.position = birthpos;
                    rd.runtimeState = RuntimeState.Active;
                }
            }
        }
        protected void OnEventHandler(System.Enum noticeID, object[] objects)
        {
            if (noticeID.Equals(NoticeEnum.ACTIVE_ROOM))
            {
                if (enimies != null && enimies.Count > 0 && !hasactived)
                {
                    TestEnimyAndProcess((NoticeEnum)noticeID);
                    hasactived = true;
                }
            }
            else if (noticeID.Equals(NoticeEnum.ENIMY_DEAD))
            {
                enimy_num--;
                if (enimy_num == 0)
                {
                    TestEnimyAndProcess((NoticeEnum)noticeID);
                }
            }
            else if (noticeID.Equals(NoticeEnum.HERO_DEAD))
            {
                OnDead((int)objects[0]);
            }
            else if (noticeID.Equals(NoticeEnum.CLEAR_ROOM))
            {
                BattlefieldModule.Instance.RemoveAllCreature();
                ObjTools.ClearChild(unitsobjlayer);
            }
            else if (noticeID.Equals(NoticeEnum.WARNING_FINISH))
            {
                CreateNextEnimies();
            }
        }
        void OnDead(int index)
        {
            player_num--;
            GameController.Instance.RemoveFromTargetGroup(BattlefieldModule.Instance.GetCreatureRuntime(index).creature.transform);
            if (player_num <= 0)
            {
                TaskFinish(false);
            }
        }

        private static void TaskFinish(bool win)
        {
            GameController.Instance.StartCoroutine(TimeTools.DelayCallback(1f, () =>
            {
                EventModule.Instance.HandleEvent(EventEnum.TASK_FINISH, new object[] { win });
            })
            );
        }

        public void StartFight(FightStruct fightStruct)
        {
            InitRoom();
            SetPlayerCreatures(fightStruct.herobuildlist);
            enimies = fightStruct.enimybuildlist;
            CreateCreatures();
            NoticeTool.Broadcast(NoticeEnum.ACTIVE_ROOM);
            BattlefieldModule.Instance.MachinePoint = GameController.Instance.mapobj.transform.GetChild(0).Find("event/machineplace");
            BattlefieldModule.Instance.StartFight();
            BattleCountModule.Instance.BattleStartInit();
        }
        void TestEnimyAndProcess(NoticeEnum noticeID) //出现怪物,处理清空
        {
            //记录上一波的结束时间
            if (noticeID.Equals(NoticeEnum.ENIMY_DEAD))
            {
                NoticeTool.Broadcast(NoticeEnum.GROUPFINISH, new object[] { Time.time });
            }
            if (enimies.Count > 0)
            {
                if (enimies.Count == 1)
                {
                    MMFrame.ShowFrame(FrameData.FrameEnum.WarningFrame, null);
                }
                else
                {
                    CreateNextEnimies();
                }
            }
            else
            {
                Debug.Log("怪物已清空");
                TaskFinish(true);
            }
        }

        private void CreateNextEnimies()
        {
            if (enimies.Count > 0)
            {
                enimy_num += enimies[0].Count;
                SetEnimies(enimies[0]);
                ActiceEnimy();
                enimies.RemoveAt(0);
                BattlefieldModule.Instance.BattleState = BattleState.fighting;
            }
        }

        protected virtual void OnEnable()
        {
            NoticeTool.RegisterNotice(NoticeEnum.ACTIVE_ROOM, OnEventHandler);
            NoticeTool.RegisterNotice(NoticeEnum.FINISH_ROOM, OnEventHandler);
            NoticeTool.RegisterNotice(NoticeEnum.CLEAR_ROOM, OnEventHandler);
            NoticeTool.RegisterNotice(NoticeEnum.ENIMY_DEAD, OnEventHandler);
            NoticeTool.RegisterNotice(NoticeEnum.HERO_DEAD, OnEventHandler);
            NoticeTool.RegisterNotice(NoticeEnum.WARNING_FINISH, OnEventHandler);
        }

        protected virtual void OnDisable()
        {
            NoticeTool.UnRegisterNotice(NoticeEnum.ACTIVE_ROOM, OnEventHandler);
            NoticeTool.UnRegisterNotice(NoticeEnum.FINISH_ROOM, OnEventHandler);
            NoticeTool.UnRegisterNotice(NoticeEnum.CLEAR_ROOM, OnEventHandler);
            NoticeTool.UnRegisterNotice(NoticeEnum.ENIMY_DEAD, OnEventHandler);
            NoticeTool.UnRegisterNotice(NoticeEnum.HERO_DEAD, OnEventHandler);
            NoticeTool.UnRegisterNotice(NoticeEnum.WARNING_FINISH, OnEventHandler);
        }
    }
}