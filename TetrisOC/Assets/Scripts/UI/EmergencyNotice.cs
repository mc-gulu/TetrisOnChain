using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using MMFramework;
namespace MMGame
{
    public class EmergencyNotice : MMFrame
    {
        public Button button;
        public Text text;
        public override void Init(object[] objects)
        {
            Debug.Log("初始化");
            button.onClick.AddListener(delegate
            {
                MMFrame.HideFrame(FrameData.FrameEnum.EmergencyNoticeFrame);
            });

            text.text = VersionModule.Instance.UrgentNotice;
        }

        protected override void OnAfterAnimation(FrameAniType aniType)
        {
            Debug.Log("完成动作类型" + aniType.ToString());
            if (aniType.Equals(FrameAniType.Out))
            {
                VersionModule.Instance.HaveRead = true;
            }
        }
    }
}