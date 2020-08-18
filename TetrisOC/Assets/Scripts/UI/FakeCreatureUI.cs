using DG.Tweening;
using MMFramework;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace MMGame
{

    public class FakeCreatureUI : MonoBehaviour
    {
        public Button TeamDownBtn;
        public Button UpgradeBtn;
        public Text ChangeShow;
        public Text LvText;

        Xint addlv = 0;
        float timer = 0;
        bool click;
        BaseInfo baseInfo;
        Tweener tweener;
        public void Init(int rid, int birthindex)
        {
            var data = DataModule.Instance.GetHeroData(rid);
            baseInfo = new BaseInfo()
            { id = data.id, creatureID = data.creatureid, Lv = data.lv, physiqueIDIndex = IDTools.GetPhysicsID(data.creatureid, data.star) };
            LvText.text = "LV " + data.lv; 

            TeamDownBtn.onClick.AddListener(() =>
            {
                NoticeTool.Broadcast(NoticeEnum.TEAM_REMOVE, new object[] { birthindex, rid });
            });

        }
        private void Update()
        {
            if (click)
            {
                if (tweener != null) 
                    tweener.Kill();
                ChangeShow.rectTransform.anchoredPosition = new Vector2(0, -30);
                ChangeShow.gameObject.SetActive(true);
                if (timer == 0)
                {
                    var backnum = HeroModule.Instance.CanLevelUp(baseInfo.id, addlv + 1);
                    if (backnum == 0)
                    {
                        StopCoroutine("delayLevelUpEvent");
                        addlv++;
                        StopCoroutine("ShowAddNum");
                        StartCoroutine("ShowAddNum", baseInfo);
                        var backnum2 = HeroModule.Instance.CanLevelUp(baseInfo.id, addlv + 1);
                        if (backnum2 != 0)
                        {
                            UpgradeBtn.gameObject.SetActive(false);
                            UpgradeClickUp();
                        }
                    }
                    timer += Time.deltaTime;
                }
                else
                {
                    timer += Time.deltaTime;
                    if (timer > 0.2f)
                    {
                        timer = 0;
                    }
                }
            }
        }
        public void UpgradeClickDown()
        {
            click = true;
            timer = 0;
        }
        public void UpgradeClickUp()
        {
            click = false;
            timer = 0;
            StartCoroutine("delayLevelUpEvent");
        }
        IEnumerator ShowAddNum(BaseInfo baseInfo)
        {
            var str = "";
            str += SingleShow(baseInfo, FType.MAXHP, "HP+") + "\n";
            str += SingleShow(baseInfo, FType.ATK, "ATK+") + "\n";
            str += SingleShow(baseInfo, FType.DEF, "DEF+") + "\n";
            ChangeShow.text = str;
            LvText.text = "LV " + (baseInfo.Lv + addlv);
            yield return new WaitForSeconds(0.3f);
            tweener = ChangeShow.rectTransform.DOAnchorPosY(10, 1f);
            tweener.OnComplete(() => 
            {
                ChangeShow.gameObject.SetActive(false);
            });
        }
        IEnumerator delayLevelUpEvent()
        {
            yield return new WaitForSecondsRealtime(0.5f);
            EventModule.Instance.HandleEvent(EventEnum.HERO_LEVELUP, new object[] { baseInfo.id, addlv });
            baseInfo.Lv += addlv;
            addlv = 0;
        }
        private string SingleShow(BaseInfo baseInfo, FType fType, string text)
        {
            var newinfo = new BaseInfo() { id = baseInfo.id, creatureID = baseInfo.creatureID, Lv = baseInfo.Lv + addlv, physiqueIDIndex = baseInfo.physiqueIDIndex };
            var change = Mathf.CeilToInt(FightValueModule.Instance.CalculateValue(newinfo, fType) - FightValueModule.Instance.CalculateValue(baseInfo, fType));
            return text + change;
        }
        FrameData.FrameEnum frameState = FrameData.FrameEnum.None;
        public void SetHomeState() 
        {
            TeamDownBtn.gameObject.SetActive(false);
            UpgradeBtn.gameObject.SetActive(HeroModule.Instance.CanLevelUp(baseInfo.id, addlv + 1) == 0);
            frameState = FrameData.FrameEnum.HomeUI;
        }
        public void SetPrebattleUIState() 
        {
            TeamDownBtn.gameObject.SetActive(DataModule.Instance.GetHeroDataDic().Count > 4);
            UpgradeBtn.gameObject.SetActive(false);
            frameState = FrameData.FrameEnum.PreBattleFrame;
        }

        private void OnEnable()
        {
            NoticeTool.RegisterNotice(NoticeEnum.GOLD, OnHandler);
        }
        private void OnDisable()
        {
            NoticeTool.UnRegisterNotice(NoticeEnum.GOLD, OnHandler);
        }

        private void OnHandler(Enum noticeId, object[] objects)
        {
            if (frameState == FrameData.FrameEnum.HomeUI)
            {
                TeamDownBtn.gameObject.SetActive(false);
                UpgradeBtn.gameObject.SetActive(HeroModule.Instance.CanLevelUp(baseInfo.id, addlv + 1) == 0);
            }
        }
    }
}