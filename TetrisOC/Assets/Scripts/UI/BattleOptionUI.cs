using MMFramework;
using MMGame;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace MMGame
{
    public class BattleOptionUI : MMFrame
    {
        public Button ContinueBtn;
        public Button GiveUpBtn;

        public override void Init(object[] objects)
        {
            ContinueBtn.onClick.AddListener(()=> 
            {
                HideFrame(frameEnum);
                RootModule.Instance.PauseAll(false);
            });
            GiveUpBtn.onClick.AddListener(()=> 
            {
                HideFrame(frameEnum);
                RootModule.Instance.PauseAll(false);
                EventModule.Instance.HandleEvent(EventEnum.TASK_FINISH, new object[] { false });
            });
        }
    }
}