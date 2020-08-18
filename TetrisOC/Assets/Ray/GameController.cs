using MMFramework;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEditor.iOS;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace MMGame
{
    /// <summary>
    /// todo 修改合适类名
    /// </summary>
    public class GameController : MonoBehaviour, BaseModule
    {
        public GameObject mapobj;
        public GameObject roomobj;
        public GameObject MachineObj;
        public GameObject TimelineObj;
        private Transform unitsobjlayer;
        private Cinemachine.CinemachineTargetGroup targetGroup;
        private Cinemachine.CinemachineTargetGroup TargetGroup
        {
            get
            {
                if (!targetGroup)
                {
                    targetGroup = GameObject.Find("TargetGroup1").GetComponent<Cinemachine.CinemachineTargetGroup>();
                }
                return targetGroup;
            }
        }
        public List<GameObject> FakeCreatueList = CommonTools.DefList<GameObject>(4);
        public static GameController Instance
        {
            get
            {
                return RootModule.Instance.GetModule<GameController>();
            }
        }

        public bool golduiFlash;
        public void Init()
        {

            //DataModule.Instance.SyncData("team", null);
            EnterScene();
        }
        public void EnterScene()
        {
            string scenestr = "scene_new";
            SceneManager.LoadScene(scenestr);
            SceneManager.activeSceneChanged += LoadScene;
        }
        public void LoadScene(Scene scene1, Scene scene2)
        {
            Transform parent = null;
            string roomname = "Prefabs/Room";
            roomobj = ObjTools.CreatePrefab(parent, roomname);
            unitsobjlayer = roomobj.GetComponent<RoomLoader>().unitsobjlayer;
            CreateMapObj();
            CreateMachineObj();
            if (!SDK_Configs.Tutorial || StorageModule.HasStruct(StorageKey.Tutorial))
            {
                CreateFakeCreatures();
                MMFrame.ShowFrame(FrameData.FrameEnum.MainTopBar);
                MMFrame.ShowFrame(FrameData.FrameEnum.MainBottom);
                AudioModule.Instance.Sound_Custom(ConfigInGame.Key_MUSIC_HOME);
            }
            else
            {
                StartCoroutine(TimeTools.DelayCallback(1f, delegate
                {
                    AudioModule.Instance.Sound_Custom(ConfigInGame.Key_MUSIC_Tutorial);
                    CreatureTutorialTimeline();
                }));
            }

            SceneManager.activeSceneChanged -= LoadScene;
            HomeTargetGroup();
        }
        public void CreateMapObj()
        {
            if (mapobj) Destroy(mapobj);
            var mappoint = new GameObject();
            mappoint.transform.position = Vector3.zero;
            mappoint.transform.parent = roomobj.transform;
            var ffdata = FloorFightData.GetData(DataModule.Instance.MainLv);
            var mapid = IDTools.IndexFinal(ffdata.MapID, ffdata.ThemeID);
            string mapPrefabPath = ZZZ_MapData.GetData(mapid).Prefab;
            var map = ObjTools.CreatePrefab(mappoint.transform, mapPrefabPath);
            map.name = "map";
            mapobj = mappoint;
        }
        #region TargetGroup
        public void PreBattleTargetGroup()
        {
            ClearTargetGroup();
            targetGroup = GameObject.Find("TargetGroup1").GetComponent<Cinemachine.CinemachineTargetGroup>();
            Transform birthparent = mapobj.transform.GetChild(0).Find("event/playerbirth");
            for (int i = 0; i < birthparent.childCount; i++)
            {
                targetGroup.AddMember(birthparent.GetChild(i), 1, 0);
            }
        }
        public void HomeTargetGroup()
        {
            ClearTargetGroup();
            Transform birthparent = mapobj.transform.GetChild(0).Find("event/playerbirth");
            TargetGroup.AddMember(mapobj.transform.GetChild(0).Find("event/machineplace"), 10, 0);
            for (int i = 0; i < birthparent.childCount; i++)
            {
                TargetGroup.AddMember(birthparent.GetChild(i), 1, 0);
            }
        }
        public void RemoveFromTargetGroup(Transform t)
        {
            TargetGroup.RemoveMember(t);
        }
        public void Add2TargetGroup(Transform t, int w, int r)
        {
            TargetGroup.AddMember(t, w, r);
        }
        public void ClearTargetGroup()
        {
            Transform birthparent = mapobj.transform.GetChild(0).Find("event/playerbirth");
            TargetGroup.RemoveMember(mapobj.transform.GetChild(0).Find("event/machineplace"));
            for (int i = 0; i < birthparent.childCount; i++)
            {
                TargetGroup.RemoveMember(birthparent.GetChild(i));
            }
        }
        #endregion
        private void CreateMachineObj()
        {
            Transform machinePoint = mapobj.transform.GetChild(0).Find("event/machineplace");
            MachineObj = ObjTools.CreatePrefab(null, "Prefabs/DrillingMachine");
            MachineObj.transform.position = machinePoint.position;
        }
        public Animator GetMachinePos()
        {
            return ObjTools.FindChild(MachineObj.transform, "kuangji").GetComponent<Animator>();
        }
        public Animator GetMachineAnim()
        {
            return ObjTools.FindChild(MachineObj.transform, "boby").GetComponent<Animator>();
        }
        public GameObject GetMachineCoin()
        {
            return ObjTools.FindChild(MachineObj.transform, "boby/coin").gameObject;
        }
        #region FakeCreature
        public void CreateFakeCreatures()
        {
            var heroids = DataModule.Instance.GetTeamList();
            for (int i = 0; i < heroids.Count; i++)
            {
                CreateFake(heroids[i], i, false);
            }
        }
        public void ActiveFakeBtn(FrameData.FrameEnum frameEnum)
        {
            foreach (var item in FakeCreatueList)
            {
                if (item)
                {
                    var ui = ObjTools.FindChild(item.transform, "FakeCreatureUI").GetComponent<FakeCreatureUI>();
                    if (frameEnum.Equals(FrameData.FrameEnum.PreBattleFrame))
                    {
                        ui.SetPrebattleUIState();
                    }
                    else if (frameEnum.Equals(FrameData.FrameEnum.HomeUI))
                    {
                        ui.SetHomeState();
                    }
                }
            }
        }
        public void CreateFake(int heroid, int birthindex, bool btnactive)
        {
            var data = DataModule.Instance.GetHeroData(heroid);
            Transform birthparent = mapobj.transform.GetChild(0).Find("event/playerbirth");
            if (birthparent == null)
            {
                Debug.LogError("hero找不到出生点");
                return;
            }
            if (data == null)
            {
                FakeCreatueList[birthindex] = null;
                return;
            }

            GameObject creatureobj = Creature.CreateCreatureFake(unitsobjlayer, data, birthindex);
            Vector2 birthpos = birthparent.GetChild(birthindex).position;
            creatureobj.transform.position = birthpos;
            FakeCreatueList[birthindex] = creatureobj;
            return;
        }

        public void ClearAllFake()
        {
            for (int i = 0; i < FakeCreatueList.Count; i++)
            {
                if (FakeCreatueList[i])
                {
                    ClearFake(i);
                }
            }
        }
        public void ClearFake(int index) 
        {
            Destroy(FakeCreatueList[index]);
            FakeCreatueList[index] = null;
        }
        #endregion
        public void LoadFight()
        {
            ClearAllFake();
            ClearTargetGroup();
            Destroy(GetComponent<RoomFight>());
            var roomfight = gameObject.AddComponent<RoomFight>();
            roomfight.StartFight(FightBuild.DownFloor(DataModule.Instance.MainLv));
            FloorFightData ffd = FloorFightData.GetData(DataModule.Instance.MainLv);
            AudioModule.Instance.Sound_Custom(string.Format(ConfigInGame.Key_MUSIC_FIGHT, IDTools.ThemeIndex(ffd.ThemeID)));
        }

        public void LoadMain()
        {
            CreateFakeCreatures();
            HomeTargetGroup();
        }
        public void DestroyTimeline()
        {
            if (TimelineObj)
            {
                Destroy(TimelineObj);
            }
        }

        bool wait = false;
        public void WaitForTouch()
        {

            wait = true;
            if (start == 3)
            {
                MMFrame.HideAllFrame();
                GameController.Instance.LoadFight();
                MMFrame.ShowFrame(FrameData.FrameEnum.BattleBottomFrame);
                if (TimelineObj)
                {
                    Destroy(TimelineObj);
                }
            }
            else
            {
                if (TimelineObj != null)
                {
                    StartTutorialHandler sth = TimelineObj.GetComponent<StartTutorialHandler>();
                    if (sth != null)
                    {
                        sth.Pause();
                    }
                }
            }
        }
        int start = 0;
        public void TouchHandler(System.Enum noticeenum, object[] objects)
        {
            if (wait)
            {
                wait = false;
                if (TimelineObj != null)
                {
                    StartTutorialHandler sth = TimelineObj.GetComponent<StartTutorialHandler>();
                    if (sth != null)
                    {
                        sth.Resume();
                        start++;
                    }
                }
            }
        }

        private void Update()
        {
            //if (Input.GetKeyDown(KeyCode.A))
            //{
            //    CreateTimeline();
            //}
        }

        public void CreateTimeline()
        {
            AudioModule.Instance.Sound_Custom(ConfigInGame.Key_MUSIC_GoDown);
            TimelineObj = Instantiate(Resources.Load<GameObject>("Images/TransformLevel/prefab/timeline"));
            TimelineObj.GetComponent<CutOutPlayer>().Init();
        }

        public void CreatureTutorialTimeline()
        {
            StorageModule.SaveStruct(StorageKey.Tutorial, true);
            TimelineObj = ObjTools.CreatePrefab(null, "Prefabs/timeline_tutorial");
            StartTutorialHandler sth = TimelineObj.GetComponent<StartTutorialHandler>();
            if (sth != null)
                TimelineObj.GetComponent<StartTutorialHandler>().Init();
        }

        void UIHander(System.Enum noticeenum, object[] objects)
        {
            if (noticeenum.Equals(NoticeEnum.FailedReturn))
            {
                MMFrame.ShowFrame(FrameData.FrameEnum.MainTopBar);
                MMFrame.ShowFrame(FrameData.FrameEnum.MainBottom);
                AudioModule.Instance.Sound_Custom(ConfigInGame.Key_MUSIC_HOME);
            }
            else if (noticeenum.Equals(NoticeEnum.TimelineFinish))
            {
                MMFrame.ShowFrame(FrameData.FrameEnum.MainTopBar);
                MMFrame.ShowFrame(FrameData.FrameEnum.MainBottom);
                AudioModule.Instance.Sound_Custom(ConfigInGame.Key_MUSIC_HOME);
                if (LogicModule.Instance.IsPrepared(99))
                    LogicModule.Instance.Active(99);
                golduiFlash = true;
            }
            else if (noticeenum.Equals(NoticeEnum.TutorialDrop))
            {
                EventModule.Instance.HandleEvent(EventEnum.TUTORIAL_DROP);
            }
        }

        private void OnEnable()
        {
            NoticeTool.RegisterNotice(NoticeEnum.GUILD_GET_GOLD, TouchHandler);
            NoticeTool.RegisterNotice(NoticeEnum.FailedReturn, UIHander);
            NoticeTool.RegisterNotice(NoticeEnum.TimelineFinish, UIHander);
            NoticeTool.RegisterNotice(NoticeEnum.TutorialDrop, UIHander);
        }

        private void OnDisable()
        {
            NoticeTool.UnRegisterNotice(NoticeEnum.GUILD_GET_GOLD, TouchHandler);
            NoticeTool.UnRegisterNotice(NoticeEnum.FailedReturn, UIHander);
            NoticeTool.UnRegisterNotice(NoticeEnum.TimelineFinish, UIHander);
            NoticeTool.UnRegisterNotice(NoticeEnum.TutorialDrop, UIHander);
        }

    }
}