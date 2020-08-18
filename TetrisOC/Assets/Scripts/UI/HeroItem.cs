using MMFramework;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace MMGame
{
    /// <summary>
    /// 只管理显示
    /// </summary>
    public class HeroItem : MonoBehaviour
    {
        public Text LvText;
        public Text NameText;
        public Image IconImg;
        public StarParentUI StarUI;
        public Image CareerImg;
        public Image EleImg;
        public Image BGImg;
        public Sprite[] BGSprites;

        /// <summary>
        /// 敌人假数据显示
        /// </summary>
        /// <param name="cid"></param>
        public void InitEnimy(int cid)
        {
            var data = new RealHeroData() { creatureid = cid };
            Init(data);
            IconImg.rectTransform.localScale = new Vector3(-1, 1, 1);
        }
        /// <summary>
        /// 友方真数据显示
        /// </summary>
        /// <param name="hid"></param>
        public void InitHero(int hid)
        {
            var data = DataModule.Instance.GetHeroData(hid);
            Init(data);
        }
        public void InitMatFake(RealHeroData data, bool sameCreature) 
        {
            Init(data);
            LvText.gameObject.SetActive(false);
            NameText.gameObject.SetActive(false);
            if (sameCreature)
            {
                CareerImg.gameObject.SetActive(true);
            }
            else 
            {
                CareerImg.gameObject.SetActive(false);
                IconImg.sprite = null;
                IconImg.sprite = CacheModule.Instance.LoadSprite(PathTools.AddSpritePath);
                IconImg.SetNativeSize();
            }
            GetComponent<CanvasGroup>().alpha = 0.6f;
        }
        public void Init(RealHeroData data)
        {
            //等级显示
            if (data.lv == 0)
                LvText.gameObject.SetActive(false);
            else
            {
                LvText.text = "Lv." + data.lv;
                LvText.gameObject.SetActive(true);
            }
            //星级显示
            if (data.star == 0)
            {
                StarUI.gameObject.SetActive(false);
                GetComponent<RectTransform>().SetHeight(-StarUI.GetComponent<RectTransform>().sizeDelta.y);
            }
            else
            {
                StarUI.gameObject.SetActive(true);
                StarUI.StarByLv(data.star);
            }
            SetBackground(data.star / 2);

            //名字，职业,元素图标
            var cdata = CreatureData.GetData(data.creatureid);
            NameText.gameObject.SetActive(true);
            NameText.text = cdata.Name;
            var careerSprite = CacheModule.Instance.LoadSprite(PathTools.IconPath, PathTools.CareerIconNames[cdata.Career]);
            SetSprite(CareerImg, careerSprite);
            var elesprite = CacheModule.Instance.LoadSprite(PathTools.IconPath, PathTools.EleIconNames[cdata.Element]);
            SetSprite(EleImg, elesprite);
            if (!string.IsNullOrEmpty(cdata.BigIconPath))
            {
                IconImg.sprite = CacheModule.Instance.LoadSprite(cdata.BigIconPath);
                IconImg.SetNativeSize();
            }
        }
        private void SetSprite(Image image, Sprite sprite)
        {
            if (sprite)
            {
                image.sprite = sprite;
                image.gameObject.SetActive(true);
                image.SetNativeSize();
            }
            else
            {
                image.gameObject.SetActive(false);
            }
        }
        public void SetBackground(int index) 
        {
            BGImg.sprite = BGSprites[index];
        }
    }
}
