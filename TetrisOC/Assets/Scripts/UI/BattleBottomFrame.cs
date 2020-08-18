using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MMFramework;
using UnityEngine.UI;

namespace MMGame
{
    public class BattleBottomFrame : MMFrame
    {
        public Transform BtnsParent;
        public Toggle AutoTog;
        public Toggle DoubleTog;
        public Button OptionBtn;
        public override void Init(object[] objects)
        {
            GetComponent<RectTransform>().offsetMin = new Vector2(0, 0);
            GetComponent<RectTransform>().offsetMax = new Vector2(0, 0);
            var indexs = BattlefieldModule.Instance.GetFriendCreaturesIndex();

            for (int i = 0; i < indexs.Length; i++)
            {
                var item = ObjTools.CreatePrefab(BtnsParent, "Prefabs/ui/SpSkillBtn");
                item.GetComponent<SpSkillBtn>().Init(indexs[i]);
            }

            AutoTog.isOn = ConfigInGame.AutoSpSkill;
            AutoTog.GetComponent<ToggleSelfChange>().ToggleChange(AutoTog.isOn);
            AutoTog.onValueChanged.AddListener(isOn =>
            {
                ConfigInGame.AutoSpSkill = isOn;
            });
            DoubleTog.isOn = ConfigInGame.DoubleSpeed;
            DoubleTog.GetComponent<ToggleSelfChange>().ToggleChange(DoubleTog.isOn);
            RootModule.Instance.ScaleGame(DoubleTog.isOn ? 10 : 1);
            DoubleTog.onValueChanged.AddListener(isOn =>
            {
                ConfigInGame.DoubleSpeed = isOn;
                RootModule.Instance.ScaleGame(isOn ? 10 : 1);
            });
            OptionBtn.onClick.AddListener(() =>
            {
                RootModule.Instance.PauseAll(true);
                ShowFrame(FrameData.FrameEnum.BattleOptionUI);
            });
        }
    }
}