using MMFramework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace MMGame
{
    public class PreBattleFrame : MMFrame
    {
        public Button BackBtn;
        public Button FightBtn;
        public Toggle OpenToggle;
        public Text TeamNumberText;
        public Text TaskLvText;

        public Transform ItemParent;
        public Transform EnimyParent;
        public GameObject ItemPrefab;

        public Transform BuffParent;
        public GameObject BuffPrefab;

        private Animation uiAnim;
        private Animation cameraAnim;
        private List<int> teamlist;
        int teamNum { get { return teamlist.Where(item => item != 0).Count(); } }

        public override void Init(object[] objects)
        {
            GetComponent<RectTransform>().offsetMin = new Vector2(0, 0);
            GetComponent<RectTransform>().offsetMax = new Vector2(0, 0);
            GameController.Instance.PreBattleTargetGroup();
            //动画初始化
            var camanimstr = "cameraup";
            cameraAnim = GameObject.Find("CM vcam1").GetComponent<Animation>();
            cameraAnim.AddClip(Resources.Load<AnimationClip>("Animation/cameraup"), camanimstr);
            var open = "open";
            uiAnim = GetComponent<Animation>();
            uiAnim.AddClip(Resources.Load<AnimationClip>("Animation/PreBattleOpen"), open);
            //显示敌人
            var tasklv = DataModule.Instance.MainLv;
            var enimycids = FightBuild.DownFloor(tasklv).GetSingleEnimy();
            StartCoroutine(ShowEnimy(enimycids));
            //显示下场按钮
            GameController.Instance.ActiveFakeBtn(frameEnum);
            //下方列表显示
            var rherodic = DataModule.Instance.GetHeroDataDicOrder1();

            teamlist = DataModule.Instance.GetTeamList();
            StartCoroutine(ShowHeros(rherodic));
            //ui显示
            ShowTeamNumber();
            TaskLvText.text = string.Format("LEVEL {0}", tasklv);
            //按钮事件
            BackBtn.onClick.AddListener(() =>
            {
                EventModule.Instance.HandleEvent(EventEnum.TEAM_CHANGED, new object[]
                {
                    teamlist,
                    new Action(()=>{
                        HideFrame(frameEnum);
                        ShowFrame(FrameData.FrameEnum.MainTopBar);
                        ShowFrame(FrameData.FrameEnum.MainBottom);
                    })
                });
            });
            FightBtn.onClick.AddListener(() =>
            {
                EventModule.Instance.HandleEvent(EventEnum.TEAM_CHANGED, new object[]
                {
                    teamlist,
                    new Action(()=>{
                        var zeronum = 0;
                        for (int i = 0; i < teamlist.Count; i++)
                            if (teamlist[i] == 0) zeronum ++;
                        if (zeronum < 4)
                        {
                            GameController.Instance.LoadFight();
                            HideFrame(frameEnum);
                            ShowFrame(FrameData.FrameEnum.BattleBottomFrame);
                            if (OpenToggle.isOn)
                            {
                                cameraAnim.Play(camanimstr);
                                cameraAnim[camanimstr].time = cameraAnim[camanimstr].clip.length;
                                cameraAnim[camanimstr].speed = -1;
                            }
                        }
                        else
                        {
                            ShowTips("WARNING","不可以无人上阵开始战斗");
                        }
                    })
                });

            });
            OpenToggle.onValueChanged.AddListener(ison =>
            {
                if (ison)
                {
                    uiAnim.Play(open);
                    uiAnim[open].time = 0;
                    uiAnim[open].speed = 1;
                    cameraAnim.Play(camanimstr);
                    cameraAnim[camanimstr].time = 0;
                    cameraAnim[camanimstr].speed = 1;
                }
                else
                {
                    uiAnim.Play(open);
                    uiAnim[open].time = uiAnim[open].clip.length;
                    uiAnim[open].speed = -1;
                    cameraAnim.Play(camanimstr);
                    cameraAnim[camanimstr].time = cameraAnim[camanimstr].clip.length;
                    cameraAnim[camanimstr].speed = -1;
                }
            });
        }

        IEnumerator ShowHeros(Dictionary<string, RealHeroData> rherodic)
        {
            foreach (var item in rherodic)
            {
                var id = int.Parse(item.Key);
                var go = Instantiate(ItemPrefab, ItemParent);
                go.SetActive(true);
                go.transform.Find("Select").gameObject.SetActive(teamlist.Contains(id));
                go.AddComponent<HeroListItem>().InitHero(id, () =>
                {
                    if (teamlist.Contains(id))
                    {
                        go.transform.Find("Select").gameObject.SetActive(false);
                        var index = teamlist.IndexOf(id);
                        TeamRemove(null, new object[] { index });
                    }
                    else
                    {
                        if (!teamlist.Contains(0)) return;
                        foreach (var partner in teamlist)
                        {
                            if (rherodic.ContainsKey(partner.ToString()) && rherodic[partner.ToString()].creatureid == item.Value.creatureid)
                            {
                                ShowTips("WARNING", "不可上场两个同类英雄");
                                return;
                            }
                        }
                        go.transform.Find("Select").gameObject.SetActive(true);
                        var index = teamlist.IndexOf(0);
                        teamlist[index] = id;
                        GameController.Instance.CreateFake(id, index, true);
                        GameController.Instance.ActiveFakeBtn(frameEnum);
                        ShowTeamNumber();
                        ShowBuff();
                    }
                });
                yield return 0;
            }
        }

        IEnumerator ShowEnimy(List<int> enimycids)
        {
            foreach (var cid in enimycids)
            {
                var go = Instantiate(ItemPrefab, EnimyParent);
                go.SetActive(true);
                go.AddComponent<HeroListItem>().InitEnimy(cid);
                yield return 0;
            }
        }

        public void TeamRemove(System.Enum noticeID, object[] objects)
        {
            var index = (int)objects[0];
            teamlist[index] = 0;
            GameController.Instance.ClearFake(index);
            if (DataModule.Instance.AutoHeroTeamUp)
                DataModule.Instance.AutoHeroTeamUp = false;
            ShowTeamNumber();
            ShowBuff();
        }

        private void ShowTeamNumber()
        {
            TeamNumberText.text = string.Format("TO POEPAOE {0}/4", teamNum);
        }

        private void OnEnable()
        {
            NoticeTool.RegisterNotice(NoticeEnum.TEAM_REMOVE, TeamRemove);
        }
        private void OnDisable()
        {
            NoticeTool.UnRegisterNotice(NoticeEnum.TEAM_REMOVE, TeamRemove);
        }

        public void ShowBuff()
        {
            Dictionary<string, string> bondageNameDescDic = BondageTool.GetBuffDesc(teamlist);
            ObjTools.ClearChild(BuffParent);
            foreach (var item in bondageNameDescDic)
            {
                var go = Instantiate(BuffPrefab, BuffParent);
                go.SetActive(true);
                go.GetComponentInChildren<Text>().text = item.Key + ":" + item.Value;
            }
        }
    }
}