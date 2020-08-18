using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using MMFramework;
namespace MMGame
{
    public class Icon : MonoBehaviour
    {
        public TextEx lineup;
        public TextEx linedown;
        public Image icon;
        public Image frame;//颜色框
        public Image back;//背衬板
        public GameObject bigstar;
        public GameObject smallstar;
        public Animator animator;
        public GameObject show;
        public Button button;
        bool _canclick;
        public bool CanClick
        {
            get
            {
                return _canclick;
            }
            set
            {
                _canclick = value;
                if (button != null)
                    button.enabled = _canclick;
            }
        }
        public StarParentUI stars;
        public void Init(int ID, int num)
        {
            ItemData.ItemEnum itemenum = ItemTools.GetIDEnum(ID);
            if (itemenum.Equals(ItemData.ItemEnum.Gold))
            {
                Init_Gold(ID, num);
            }
            else if (itemenum.Equals(ItemData.ItemEnum.Diamond))
            {
                Init_Diamond(ID, num);
            }
            else if (itemenum.Equals(ItemData.ItemEnum.Exp))
            {
                Init_Exp(ID, num);
            }
            else if (itemenum.Equals(ItemData.ItemEnum.Battery))
            {
                Init_Battery(ID, num);
            }
            else if (itemenum.Equals(ItemData.ItemEnum.Creature))
            {
                Init_Hero(ID, num);
            }
            // animator.enabled = false;
            if (button != null)
                button.onClick.AddListener(delegate
                {
                    if (!MMFrameManager.GetShared().HaveFrame(FrameData.FrameEnum.ItemDetailFrame))
                        MMFrame.ShowFrame(FrameData.FrameEnum.ItemDetailFrame, new object[] { new ItemObj(ID, num) });
                });
        }

        public void Hide()
        {
            if (show != null)
                show.SetActive(false);
        }

        public void Show()
        {
            if (show != null)
                show.SetActive(true);
            if (animator != null)
                animator.SetTrigger("StartPlay");
        }

        public void FastShow()
        {
            if (show != null)
                show.SetActive(true);
            if (animator != null)
                animator.SetTrigger("FastPlay");
        }

        void Init_Gold(int ID, int num)
        {
            int itemID = ItemTools.GetIDType(ID);
            ItemData itemdata = ItemData.GetData(itemID);
            if (icon != null)
            {
                icon.sprite = CacheModule.Instance.Load<Sprite>(itemdata.IconArray[0]);
                icon.SetNativeSize();
            }
            if (lineup != null)
                lineup.text = num == 1 ? string.Empty : string.Format("x{0}", num);
            if (linedown != null)
                linedown.text = itemdata.Name;
        }

        void Init_Diamond(int ID, int num)
        {
            int itemID = ItemTools.GetIDType(ID);
            ItemData itemdata = ItemData.GetData(itemID);
            if (icon != null)
            {
                icon.sprite = CacheModule.Instance.Load<Sprite>(itemdata.IconArray[0]);
                icon.SetNativeSize();
            }
            if (lineup != null)
                lineup.text = num == 1 ? string.Empty : string.Format("x{0}", num);
            if (linedown != null)
                linedown.text = itemdata.Name;
        }

        void Init_Battery(int ID, int num)
        {
            int itemID = ItemTools.GetIDType(ID);
            ItemData itemdata = ItemData.GetData(itemID);
            if (icon != null)
            {
                icon.sprite = CacheModule.Instance.Load<Sprite>(itemdata.IconArray[0]);
                icon.SetNativeSize();
            }
            if (lineup != null)
                lineup.text = num == 1 ? string.Empty : string.Format("x{0}", num);
            if (linedown != null)
                linedown.text = itemdata.Name;
        }

        void Init_Exp(int ID, int num)
        {
            int itemID = ItemTools.GetIDType(ID);
            ItemData itemdata = ItemData.GetData(itemID);
            if (icon != null)
            {
                icon.sprite = CacheModule.Instance.Load<Sprite>(itemdata.IconArray[0]);
                icon.SetNativeSize();
            }
            if (lineup != null)
                lineup.text = num == 1 ? string.Empty : string.Format("x{0}", num);
            if (linedown != null)
                linedown.text = itemdata.Name;
        }

        void Init_Hero(int ID, int star)
        {
            Debug.Log("ID" + ID + " star" + star);
            CreatureData creature = CreatureData.GetData(ID);
            if (frame != null)
                frame.gameObject.SetActive(true);
            if (icon != null)
            {
                icon.sprite = CacheModule.Instance.Load<Sprite>(creature.IconPath);
                icon.SetNativeSize();
            }
            if (lineup != null)
                lineup.text = "Lv.1";
            if (linedown != null)
                linedown.text = creature.Name;

            if (stars != null)
            {
                stars.StarByLv(star);
            }

            back.sprite = CacheModule.Instance.Load<Sprite>(ConfigInGame.StarBGPath[star / 2]);
        }
    }
}