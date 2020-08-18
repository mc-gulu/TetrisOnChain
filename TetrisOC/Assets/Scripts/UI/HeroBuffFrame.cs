using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace MMGame
{
    public class HeroBuffFrame : MMFrame
    {
        public Transform Content;
        public GameObject Item;
        public Button BackBtn;
        public override void Init(object[] objects)
        {
            GetComponent<RectTransform>().offsetMin = new Vector2(0, 0);
            GetComponent<RectTransform>().offsetMax = new Vector2(0, 0);
            var id = (int)objects[1];
            var showdatas = BondageTool.GetHeroBuffDesc(id);
            for (int i = 0; i < showdatas.Count; i++)
            {
                var go = Instantiate(Item, Content);
                go.GetComponent<BuffDetailItem>().Init(showdatas[i]);
            }
            BackBtn.onClick.AddListener(()=> 
            {
                HideFrame(frameEnum);
            });
        }
    }
}