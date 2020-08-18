using DG.Tweening;
using MMFramework;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace MMGame
{
    public class HeroDetailFrame : MMFrame
    {
        public Button ResetLvBtn;
        public Button BackBtn;
        public GameObject ShowChangePrefab;

        HeroDetailUI detailPart;
        Xint addlv = 0;
        int id;
        float timer = 0;
        bool click;
        Tweener tweener;
        public override void Init(object[] objects)
        {
            GetComponent<RectTransform>().offsetMin = new Vector2(0, 0);
            GetComponent<RectTransform>().offsetMax = new Vector2(0, 0);
            detailPart = GetComponentInChildren<HeroDetailUI>();
            id = (int)objects[1];
            var data = DataModule.Instance.GetHeroData(id);
            detailPart.Init(id);
            ResetLvBtn.onClick.AddListener(() =>
            {
                var backnum = HeroModule.Instance.CanResetHero(id);
                if (backnum == 0)
                {
                    EventModule.Instance.HandleEvent(EventEnum.HERO_RESET, new object[] { id });
                }
                else if (backnum == -401)
                {
                    ShowTips("WARNING", "角色1级");
                }
                else if (backnum == -402)
                {
                    ShowTips("WARNING", "花费不足");
                }
            });
            BackBtn.onClick.AddListener(() =>
            {
                HideFrame(FrameData.FrameEnum.HeroDetailFrame);
            });
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
        IEnumerator ShowAddNum()
        {
            var baseInfo = DataModule.Instance.GetHeroData(id).GetBaseInfo();
            if (tweener != null)
            {
                tweener.Kill();
            }
            ShowChangePrefab.GetComponent<CanvasGroup>().alpha = 1;
            var str = "";
            str += SingleStr(baseInfo, FType.MAXHP, "HP+") + "\n";
            str += SingleStr(baseInfo, FType.ATK, "ATK+") + "\n";
            str += SingleStr(baseInfo, FType.DEF, "DEF+") + "\n";
            ShowChangePrefab.GetComponent<Text>().text = str;
            yield return new WaitForSeconds(0.3f);
            tweener = ShowChangePrefab.GetComponent<CanvasGroup>().DOFade(0, 0.5f);
        }

        private string SingleStr(BaseInfo baseInfo, FType fType, string text)
        {
            var newInfo = new BaseInfo() { id = baseInfo.id, creatureID = baseInfo.creatureID, Lv = baseInfo.Lv + addlv, physiqueIDIndex = baseInfo.physiqueIDIndex };
            var change = Mathf.CeilToInt(FightValueModule.Instance.CalculateValue(newInfo, fType) - FightValueModule.Instance.CalculateValue(baseInfo, fType));
            return string.Format("{0}{1}", text, change);
        }

        IEnumerator delayLevelUpEvent()
        {
            yield return new WaitForSecondsRealtime(0.5f);
            if (addlv != 0)
            {
                EventModule.Instance.HandleEvent(EventEnum.HERO_LEVELUP, new object[] { id, addlv });
                addlv = 0;
            }
        }
        private void OnEnable()
        {
            NoticeTool.RegisterNotice(NoticeEnum.HERO_RESET, ResetData);
            NoticeTool.RegisterNotice(NoticeEnum.HEROLV_CHANGED, OnLevelChanged);
        }
        private void OnDisable()
        {
            NoticeTool.UnRegisterNotice(NoticeEnum.HERO_RESET, ResetData);
            NoticeTool.UnRegisterNotice(NoticeEnum.HEROLV_CHANGED, OnLevelChanged);
        }
        private void Update()
        {
            if (click)
            {
                if (timer == 0)
                {
                    var backnum = HeroModule.Instance.CanLevelUp(id, addlv + 1);
                    if (backnum == 0)
                    {
                        StopCoroutine("delayLevelUpEvent");
                        addlv++;
                        detailPart.UpdatePart(addlv);
                        StopCoroutine("ShowAddNum");
                        StartCoroutine("ShowAddNum");
                    }
                    else if (backnum == -201)
                    {
                        ShowTips("WARNING", "英雄已经到达当前星级最大等级"); UpgradeClickUp();
                    }
                    else if (backnum == -202) 
                    {
                        ShowTips("WARNING", "金币不足"); UpgradeClickUp();
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
        public void ResetData(System.Enum noticeID, object[] objects)
        {
            var id = (int)objects[0];
            if (this.id == id)
            {
                detailPart.Show(id);
            }
        }
        private void OnLevelChanged(Enum noticeId, object[] objects)
        {
            var id = (int)objects[0];
            if (this.id == id)
            {
                detailPart.Show(id);
            }
        }
    }
}