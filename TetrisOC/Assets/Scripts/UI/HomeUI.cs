using MMGame;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HomeUI : MMFrame
{
    public Button mailbtn;
    public Button checkinbtn;
    public Button FightBtn;

    public Animator UIflashAnimator;
    public override void Init(object[] objects)
    {
        GetComponent<RectTransform>().offsetMin = new Vector2(0, 0);
        GetComponent<RectTransform>().offsetMax = new Vector2(0, 0);
        // var nextlv = DataModule.Instance.MainLv + 1;
        // NextLvText.text = string.Format("LEVEL {0}", nextlv);
        // MoneyPerSecText.text = string.Format("{0}/Sec", FloorFightData.GetData(nextlv).GoldSecond * 2);
        FightBtn.onClick.AddListener(() =>
        {
            HeroModule.Instance.AutoHeroTeam(() =>
            {
                GameController.Instance.ClearAllFake();
                GameController.Instance.CreateFakeCreatures();
                HideAllFrame();
                ShowFrame(FrameData.FrameEnum.PreBattleFrame);
            });
        });

        mailbtn.onClick.AddListener(delegate
        {
            ShowFrame(FrameData.FrameEnum.MailListFrame);
        });
        checkinbtn.onClick.AddListener(delegate
        {
            ShowFrame(FrameData.FrameEnum.CheckinFrame);
        });
        GameController.Instance.ActiveFakeBtn(frameEnum);
    }

    void OnEnable()
    {
        StartCoroutine(CheckOffline());
    }

    IEnumerator CheckOffline()
    {
        yield return new WaitForSeconds(0.1f);
        if (OfflineModule.Instance.HaveOffline)
        {
            MMFrame.ShowFrame(FrameData.FrameEnum.OfflineHarvestFrame);
        }
    }

    private void Update()
    {
        if (GameController.Instance.golduiFlash)
        {
            GameController.Instance.golduiFlash = false;
            UIflashAnimator.SetTrigger("Play");
        }
    }
}
