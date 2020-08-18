using MMGame;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeroNewShowFrame : MMFrame
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
        detailPart.Init(id);

        OkBtn.onClick.AddListener(() => 
        {
            HideFrame(FrameData.FrameEnum.HeroNewShowFrame, this);
        });
    }
}
