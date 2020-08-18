using MMFramework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace MMGame 
{
    public class HeroStarUpUI : MMFrame
    {
        public Transform ItemParent;
        public GameObject ItemPrefab;
        public Transform UpStarItem;
        public List<Transform> Mats;

        public Transform SelectBorder;
        public Button UpStarBtn;

        public StarParentUI CurStar, NextStar;
        public GameObject SelectedTitle;

        public GameObject EleToggleParent;

        private RealHeroData upstarhero;
        private List<RealHeroData> matheros = new List<RealHeroData>();
        private List<StarUpItem> items = new List<StarUpItem>();
        private int onToggle = 0;
        public override void Init(object[] objects)
        {
            GetComponent<RectTransform>().offsetMax = new Vector2(0, 0);
            GetComponent<RectTransform>().offsetMin = new Vector2(0, 0);
            StartCoroutine(ShowHeros());
            UpStarBtn.onClick.AddListener(() =>
            {
                if (upstarhero == null)
                    return;
                if (matheros.Count == 0)
                    return;
                var matidarr = matheros.Select(data => data.id).ToArray();
                var eventobjs = new object[] { upstarhero.id, matidarr };
                EventModule.Instance.HandleEvent(EventEnum.HERO_STARUP, eventobjs);
            });
            var toggles = EleToggleParent.GetComponentsInChildren<Toggle>();
            for (int i = 0; i < toggles.Length; i++)
            {
                var num = i;
                toggles[i].onValueChanged.AddListener(ison =>
                {
                    if (ison)
                    {
                        onToggle = num;
                        SetItemsActiveState();
                    }
                });
            }
            UpStarItem.GetComponent<Button>().onClick.AddListener(() =>
            {
                if (upstarhero == null)
                {
                    return;
                }
                else
                {
                    upstarhero = null;
                    UpHeroSelectChange(null);
                }
            });
            SetStarUpBtnState();
        }

        IEnumerator ShowHeros()
        {
            var dic = DataModule.Instance.GetHeroDataDicOrder2();
            foreach (var item in dic)
            {
                var itemPrefab = Instantiate(ItemPrefab, ItemParent);
                var starupitem = itemPrefab.AddComponent<StarUpItem>();
                starupitem.Init(item.Value.id);
                starupitem.SelStarUpState();
                items.Add(starupitem);
                itemPrefab.GetComponent<Button>().onClick.AddListener(() =>
                {
                    if (upstarhero == null)
                    {
                        upstarhero = item.Value;
                        UpHeroSelectChange(itemPrefab);
                    }
                    else if (upstarhero.Equals(item.Value))
                    {
                        upstarhero = null;
                        UpHeroSelectChange(itemPrefab);
                    }
                    else
                    {
                        MatHeroListChange(item.Value);
                    }
                });
                starupitem.SetActive(onToggle);
                yield return 0;
            }
        }

        private void SetItemsActiveState()
        {
            foreach (var item in items)
            {

                item.SetActive(onToggle);
            }
        }
        private void MatHeroListChange(RealHeroData rdata)
        {
            if (matheros.Contains(rdata))
            {
                matheros.Remove(rdata);
            }
            else if (matheros.Count < CreatureStarUpData.GetData(upstarhero.star).CostNum)
            {
                matheros.Add(rdata);
            }
            foreach (var item in items)
            {
                item.SetTick(matheros);
            }

            for (int i = 0; i < Mats.Count; i++)
            {
                var num = i;
                if (i < matheros.Count)
                {
                    Mats[i].GetComponent<StarUpItem>().Init(matheros[i].id);
                    Mats[i].GetComponent<Button>().onClick.RemoveAllListeners();
                    Mats[i].GetComponent<Button>().onClick.AddListener(() =>
                    {
                        MatHeroListChange(matheros[num]);
                    });
                }
                else if (Mats[i].gameObject.activeSelf)
                {
                    Mats[i].GetComponent<StarUpItem>().SetMatFake(upstarhero);
                    Mats[i].GetComponent<Button>().onClick.RemoveAllListeners();
                }
            }
            SetStarUpBtnState();
        }
        private void UpHeroSelectChange(GameObject itemPrefab)
        {
            if (upstarhero == null)
            {
                UpStarItem.gameObject.SetActive(false);
                foreach (var item in Mats)
                {
                    item.gameObject.SetActive(false);
                }
                SelectBorder.gameObject.SetActive(false);
                foreach (var item in items)
                {
                    item.SelStarUpState();
                }
                SelectedTitle.SetActive(false);
                matheros.Clear();
            }
            else
            {
                //上方升星角色显示
                var csdata = CreatureStarUpData.GetData(upstarhero.star);
                var cdata = CreatureData.GetData(upstarhero.creatureid);
                SelectBorder.SetParent(itemPrefab.transform);
                SelectBorder.localPosition = Vector3.zero;
                SelectBorder.gameObject.SetActive(true);
                UpStarItem.gameObject.SetActive(true);
                UpStarItem.GetComponent<StarUpItem>().Init(upstarhero.id);

                SelectedTitle.SetActive(true);
                CurStar.StarByLv(upstarhero.star);
                NextStar.StarByLv(upstarhero.star + 1);
                //素材角色提示
                for (int i = 0; i < csdata.CostNum; i++)
                {
                    Mats[i].gameObject.SetActive(true);
                    Mats[i].GetComponent<StarUpItem>().SetMatFake(upstarhero);
                }
                foreach (var item in items)
                {
                    item.SelMatState(upstarhero, csdata);
                }
            }
            SetStarUpBtnState();
        }
        private void OnEnable()
        {
            NoticeTool.RegisterNotice(NoticeEnum.HERO_STARUP, ResetData);
        }
        private void OnDisable()
        {
            NoticeTool.UnRegisterNotice(NoticeEnum.HERO_STARUP, ResetData);
        }
        public void ResetData(System.Enum noticeID, object[] objects)
        {
            upstarhero = null;
            UpHeroSelectChange(null);
            matheros.Clear();
            items.Clear();
            SelectBorder.SetParent(transform);
            SelectBorder.gameObject.SetActive(false);
            ObjTools.ClearChild(ItemParent);
            SetStarUpBtnState();
            StartCoroutine(ShowHeros());
        }
        public void SetStarUpBtnState()
        {
            bool canStarup = false;
            var matidarr = matheros.Select(data => data.id).ToArray();
            if (upstarhero != null)
            {
                canStarup = HeroModule.Instance.CanStarUp(upstarhero.id, matidarr) == 0;
            }
            
            if (canStarup)
            {
                UpStarBtn.interactable = true;
                ColorTools.SetGray(UpStarBtn.gameObject, false);
            }
            else 
            {
                UpStarBtn.interactable = false;
                ColorTools.SetGray(UpStarBtn.gameObject, true);
            }
        }
    }
}
