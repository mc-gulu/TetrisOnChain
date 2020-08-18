using MMGame;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using MMFramework;
namespace MMGame
{
    public class MainTopBar : MMFrame
    {
        public Button setbtn;
        public override void Init(object[] objects)
        {
            GetComponent<RectTransform>().offsetMin = new Vector2(0, 0);
            GetComponent<RectTransform>().offsetMax = new Vector2(0, 0);
            GameController.Instance.HomeTargetGroup();

            if (!MMFrameManager.GetShared().HaveFrame(FrameData.FrameEnum.FlyResourcesFrame))
                ShowFrame(FrameData.FrameEnum.FlyResourcesFrame);

            setbtn.onClick.AddListener(delegate
            {
                ShowFrame(FrameData.FrameEnum.SetFrame);
            });
        }

        public RectTransform GetRect(int resourcesID)
        {
            if (resourcesID == 3000)
            {
                return ObjTools.FindChild(transform, "Topbar/coin/GetParticles").GetComponent<RectTransform>();
            }
            else
                return null;
        }
    }
}