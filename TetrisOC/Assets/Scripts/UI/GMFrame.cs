using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace MMGame
{
    public class GMFrame : MMFrame
    {
        public Button[] buttons;
        public Button btn, cancel;
        public InputField input;
        public GameObject bottom;
        int index;
        public override void Init(object[] objects)
        {
            Debug.Log("初始化");
            bottom.SetActive(false);
            for (int i = 0; i < buttons.Length; i++)
            {
                int temp = i;
                buttons[i].onClick.AddListener(delegate
                {
                    index = temp;
                    Debug.Log(index);
                    bottom.SetActive(false);
                    if (index == 0)
                    {
                        bottom.SetActive(true);
                        (input.placeholder as Text).text = "请输入掉落ID......";
                    }
                    else if (index == 1)
                    {
                        EventModule.Instance.HandleEvent(EventEnum.GM, 1, "30201");
                        MMFrame.HideFrame(FrameData.FrameEnum.GMFrame);
                    }
                    else if (index == 2)
                    {
                        EventModule.Instance.HandleEvent(EventEnum.GM, 2, "");
                        MMFrame.HideFrame(FrameData.FrameEnum.GMFrame);
                    }
                    else if (index == 3)
                    {
                        EventModule.Instance.HandleEvent(EventEnum.LOTTERY);
                        MMFrame.HideFrame(FrameData.FrameEnum.GMFrame);
                    }
                    else if (index == 4)
                    {
                        MMFrame.HideFrame(FrameData.FrameEnum.GMFrame);
                        MMFrame.ShowTips("标题", "内容");
                    }
                    else if (index == 5)
                    {
                        MMFrame.HideFrame(FrameData.FrameEnum.GMFrame);
                        PlayerPrefs.DeleteAll();
                    }
                    else if (index == 6)
                    {
                        bottom.SetActive(true);
                        (input.placeholder as Text).text = "请输入等级......";
                    }
                    else if (index == 7)
                    {
                        bottom.SetActive(true);
                        (input.placeholder as Text).text = "请输入星级......";
                    }
                    else if (index == 8)
                    {
                        bottom.SetActive(true);
                        (input.placeholder as Text).text = "请输入关卡......";
                    }
                });
            }
            btn.onClick.AddListener(delegate
            {
                EventModule.Instance.HandleEvent(EventEnum.GM, index, input.text);
                MMFrame.HideFrame(FrameData.FrameEnum.GMFrame);
            });
            cancel.onClick.AddListener(delegate
            {
                MMFrame.HideFrame(FrameData.FrameEnum.GMFrame);
            });
        }

        protected override void OnAfterAnimation(FrameAniType aniType)
        {
            Debug.Log("完成动作类型" + aniType.ToString());
        }
    }
}