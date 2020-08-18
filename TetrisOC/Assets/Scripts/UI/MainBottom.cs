using MMGame;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using MMFramework;
namespace MMGame
{
    public class MainBottom : MMFrame
    {
        public Toggle HomeTog;
        public Toggle HeroListTog;
        public Toggle HeroStarUpTog;
        public Toggle StoreTog;
        public Button ExploreBtn;
        private Toggle lastTog;
        private List<Toggle> toggles = new List<Toggle>();
        FrameData.FrameEnum currentFrame = FrameData.FrameEnum.None;
        public override void Init(object[] objects)
        {
            GetComponent<RectTransform>().offsetMin = new Vector2(0, 0);
            GetComponent<RectTransform>().offsetMax = new Vector2(0, 0);
            lastTog = null;
            HomeTog.onValueChanged.AddListener(ison =>
            {
                ToggleClick(HomeTog, ison, FrameData.FrameEnum.HomeUI);
            });
            HeroListTog.onValueChanged.AddListener(ison =>
            {
                ToggleClick(HeroListTog, ison, FrameData.FrameEnum.HeroListUI);
            });
            HeroStarUpTog.onValueChanged.AddListener(ison =>
            {
                ToggleClick(HeroStarUpTog, ison, FrameData.FrameEnum.HeroStarUpUI);
            });
            StoreTog.onValueChanged.AddListener(ison =>
            {
                ToggleClick(StoreTog, ison, FrameData.FrameEnum.LotteryFrame);
            });
            ExploreBtn.onClick.AddListener(() =>
            {
                ShowTips("TIPS", "COMING SOON");
            });
            toggles.Add(HomeTog);
            toggles.Add(HeroListTog);
            toggles.Add(StoreTog);
            toggles[0].isOn = true;
        }

        private void ToggleClick(Toggle toggle, bool ison, FrameData.FrameEnum frameEnum)
        {
            // if (ison)
            // {
            //     if (lastTog == toggle) return;
            //     ShowFrame(frameEnum);
            //     lastTog = toggle;
            // }
            // else
            //     HideFrame(frameEnum);
            if (ison)
            {

                NoticeTool.Broadcast(NoticeEnum.TOUCH_MASK_BUSY, new object[] { ConfigInGame.ClickBtnBusyTime });

                if (lastTog == toggle) return;
                lastTog = toggle;

                // Debug.LogError(string.Format("{0}->{1}", currentFrame, frameEnum));

                //旧的删除,不必监听事件
                if (currentFrame != FrameData.FrameEnum.None)
                    FrameAnimModule.Instance.AddStruct("mainbottom",
                        null,
                        new FrameAct("mainbottom", currentFrame, FrameAniType.Out, 0, null));

                //新的添加,监听旧的删除
                FrameAnimModule.Instance.AddStruct("mainbottom",
                    new FrameListen(FrameAniType.Out, AnimStage.End),
                    new FrameAct("mainbottom", frameEnum, FrameAniType.In, 0, null));

                currentFrame = frameEnum;
            }
        }
    }
}