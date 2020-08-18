using MMFramework;
using System.Collections;
using System.Collections.Generic;
// using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

namespace MMGame
{
    [RequireComponent(typeof(HeroItem))]
    public class StarUpItem : MonoBehaviour
    {
        public RealHeroData data;
        GameObject tick;
        GameObject Tick
        {
            get
            {
                if (!tick) tick = transform.Find("Tick").gameObject;
                return tick;
            }
        }
        GameObject mask;
        GameObject Mask 
        {
            get 
            {
                if (!mask) mask = transform.Find("Mask").gameObject;
                return mask;
            }
        }
        HeroItem showitem;
        HeroItem Showitem
        {
            get
            {
                if (!showitem) showitem = GetComponent<HeroItem>();
                return showitem;
            }
        }
        Button button;
        int eleNum;
        public void Init(int hid)
        {
            data = DataModule.Instance.GetHeroData(hid);
            eleNum = CreatureData.GetData(data.creatureid).Element;
            var canvasgroup = GetComponent<CanvasGroup>();
            if (canvasgroup) canvasgroup.alpha = 1;
            Showitem.InitHero(hid);
            button = GetComponent<Button>();
        }

        public void SelStarUpState()
        {
            Tick.SetActive(false);
            if (HeroModule.Instance.IsMaxStar(data))
            {
                button.interactable = false;
                Mask.SetActive(true);
            }
            else
            {
                button.interactable = true;
                Mask.SetActive(false);
            }
        }
        public void SelMatState(RealHeroData updata, CreatureStarUpData csdata)
        {
            Mask.SetActive(true);
            if (updata.id == data.id)
            {
                button.interactable = true;
                Mask.SetActive(false);
                return;
            }
            if (csdata.CostStar != data.star)
            {
                button.interactable = false;
                return;
            }
            if (csdata.IsSameCreature && updata.creatureid != data.creatureid)
            {
                button.interactable = false;
                return;
            }
            if (csdata.IsSameElement && !CreatureData.GetData(updata.creatureid).Element.Equals(CreatureData.GetData(data.creatureid).Element))
            {
                button.interactable = false;
                return;
            }
            button.interactable = true;
            Mask.SetActive(false);
        }
        public void SetMatFake(RealHeroData updata)
        {
            var csdata = CreatureStarUpData.GetData(updata.star);
            updata.star = csdata.CostStar;
            Showitem.InitMatFake(updata, csdata.IsSameCreature);
        }
        public void SetActive(int tmpeleNum)
        {
            gameObject.SetActive(tmpeleNum == eleNum || tmpeleNum == 0);
        }
        public void SetTick(List<RealHeroData> datas)
        {
            Tick.SetActive(false);
            for (int i = 0; i < datas.Count; i++)
            {
                if (datas[i].id == data.id)
                {
                    Tick.SetActive(true);
                    return;
                }
            }
        }
    }
}