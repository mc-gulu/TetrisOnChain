using MMFramework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace MMGame
{
    public class BuffDetailItem : MonoBehaviour
    {
        public Text DescText;
        public Image[] IconImgs;
        public void Init(BondageDecsData data) 
        {
            DescText.text = data.desc;
            for (int i = 0; i < data.iconpaths.Count; i++)
            {
                IconImgs[i].gameObject.SetActive(true);
                IconImgs[i].sprite = CacheModule.Instance.LoadSprite(data.iconpaths[i]);
            }
            var height = DescText.preferredHeight;
            DescText.rectTransform.sizeDelta = new Vector2(DescText.rectTransform.sizeDelta.x, height);
            GetComponent<RectTransform>().sizeDelta = GetComponent<RectTransform>().sizeDelta + new Vector2(0, height);
        }

    }
}