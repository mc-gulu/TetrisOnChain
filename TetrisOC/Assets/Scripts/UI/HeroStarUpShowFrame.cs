using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace MMGame
{
    public class HeroStarUpShowFrame : MMFrame
    {
        public Button OkBtn;
        HeroDetailUI detailPart;
        int id;
        public override void Init(object[] objects)
        {
            GetComponent<RectTransform>().offsetMin = new Vector2(0, 0);
            GetComponent<RectTransform>().offsetMax = new Vector2(0, 0);
            detailPart = GetComponentInChildren<HeroDetailUI>();
            id = (int)objects[1];
            var data = DataModule.Instance.GetHeroData(id);
            detailPart.Init(id);
            OkBtn.onClick.AddListener(() =>
            {
                HideFrame(FrameData.FrameEnum.HeroStarUpShowFrame, this);
            });
            //todo 展示返还资源
            //Dictionary<int, int> allCosts = (Dictionary<int, int>)objects[2];
        }
    }
}