using MMFramework;
using MMGame;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class RealHeroData
{
    public int id;
    public int creatureid;
    public int lv;
    public int star;
    public int ele { get { return CreatureData.GetData(creatureid).Element; } }
    public int career { get { return CreatureData.GetData(creatureid).Career; } }
    public BaseInfo GetBaseInfo() 
    {
        return new BaseInfo()
        { id = id, creatureID = creatureid, Lv = lv, physiqueIDIndex = IDTools.GetPhysicsID(creatureid, star) };
    }
}

public class HeroListUI : MMFrame
{
    public Transform ItemParent;
    public Transform CareerTogglesParent;
    public Transform EleTogglesParent;
    public Text NumText;
    HeroListItem[] heroListItems;
    List<int> selectCareerNums = new List<int>();
    List<int> selectEleNums = new List<int>();

    ButtonFastLock fastLock = null;

    public override void Init(object[] objects)
    {
        fastLock = GetComponent<ButtonFastLock>();
        if (fastLock == null)
        {
            fastLock = gameObject.AddComponent<ButtonFastLock>();
        }


        GetComponent<RectTransform>().offsetMax = new Vector2(0, 0);
        GetComponent<RectTransform>().offsetMin = new Vector2(0, 0);

        StartCoroutine(ShowHeros());
        heroListItems = ItemParent.GetComponentsInChildren<HeroListItem>();
        var CareerToggles = CareerTogglesParent.GetComponentsInChildren<Toggle>();
        for (int i = 0; i < CareerToggles.Length; i++)
        {
            int num = i;
            CareerToggles[num].onValueChanged.AddListener(ison =>
            {
                if (ison)
                {
                    selectCareerNums.Add(num + 1);
                }
                else
                {
                    selectCareerNums.Remove(num + 1);
                }
                SetItemsActive();
            });
        }
        var EleToggles = EleTogglesParent.GetComponentsInChildren<Toggle>();
        for (int i = 0; i < EleToggles.Length; i++)
        {
            int num = i;
            EleToggles[num].onValueChanged.AddListener(ison =>
            {
                if (ison)
                {
                    selectEleNums.Add(num + 1);
                }
                else
                {
                    selectEleNums.Remove(num + 1);
                }
                SetItemsActive();
            });
        }
    }
    IEnumerator ShowHeros()
    {
        var ids = DataModule.Instance.GetHeroDataDicOrder1().Keys.ToArray();
        NumText.text = string.Format("{0}/{1}", ids.Length, DataModule.Instance.HeroListMax);
        if (ids.Length > DataModule.Instance.HeroListMax) NumText.color = Color.red;
        foreach (var heroid in ids)
        {
            var go = ObjTools.CreatePrefab(ItemParent, PathTools.HeroItemPath);
            go.AddComponent<HeroListItem>().InitHero(int.Parse(heroid), () =>
            {
                if (!fastLock.IsLock)
                {
                    fastLock.IsLock = true;
                    ShowFrame(FrameData.FrameEnum.HeroDetailFrame, new object[] { int.Parse(heroid) });
                }
            });
            yield return 0;
        }
    }
    private void SetItemsActive()
    {
        for (int i = 0; i < heroListItems.Length; i++)
        {
            heroListItems[i].SetActive(selectCareerNums, selectEleNums);
        }
    }
}
