using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using MMFramework;
namespace MMGame
{
    public class HomeFrame : MMFrame
    {
        public Text text;
        public Button loginbtn;
        public override void Init(object[] objects)
        {
            // Debug.Log("初始化");
            loginbtn.onClick.AddListener(delegate
            {
                LogModule.LogScreen("5.登录");
                // GameAccountModule.Instance.ServerLoginProcess();
                RootModule.Instance.GetModule<GameController>();
            });
        }

        protected override void OnAfterAnimation(FrameAniType aniType)
        {
            // Debug.Log("完成动作类型" + aniType.ToString());
        }

        bool isreading = false;
        bool isfinishing = false;
        void Update()
        {
            int process = (int)LoginProcessModule.Instance.State.process;
            text.text = StringConfig.LoginStateString[process];

            CheckNotice();

            CheckShowLogin();

            CheckToGame();
        }

        bool CheckNotice()
        {
            if (!VersionModule.Instance.Inited)
                return false;
            if (!VersionModule.Instance.HaveNotice)
                return false;
            if (VersionModule.Instance.HaveRead)
                return false;
            if (isreading)
                return false;

            isreading = true;
            MMFrame.ShowFrame(FrameData.FrameEnum.EmergencyNoticeFrame);

            return true;
        }

        bool CheckShowLogin()
        {
            if (!VersionModule.Instance.Inited)
                return false;
            if (VersionModule.Instance.HaveNotice && !VersionModule.Instance.HaveRead)
                return false;
            if (!LoginProcessModule.Instance.State.process.Equals(LoginProcess.Login))
                return false;
            if (!ChannelConfigs.NeedShowLogin)
                return false;
            if (loginbtn.gameObject.activeSelf)
                return false;
            loginbtn.gameObject.SetActive(true);
            return true;
        }

        bool CheckToGame()
        {
            if (!VersionModule.Instance.Inited)
            {
                return false;
            }

            if (!LoginProcessModule.Instance.State.process.Equals(LoginProcess.Finish))
            {
                return false;
            }
            if (isfinishing)
            {
                return false;
            }
            if (VersionModule.Instance.HaveNotice && !VersionModule.Instance.HaveRead)
            {
                return false;
            }
            isfinishing = true;
            return true;
        }
    }
}