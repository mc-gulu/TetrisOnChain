using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MMFramework;
using UnityEngine.UI;
namespace MMGame
{
    public class IconItem : MonoBehaviour, IconInterface
    {
        public Image head;
        public Image bg;
        public Text lineup;
        public Text linedown;
        Animation anim;
        public Button button;
        public string[] animations;
        ItemObj item;
        public virtual void Init(ItemObj itemobj, bool canClick)
        {
            this.item = itemobj;
            int ID = item.ID;
            int num = item.Value;
            int itemID = ItemTools.GetIDType(ID);
            ItemData itemdata = ItemData.GetData(itemID);

            head.sprite = CacheModule.Instance.Load<Sprite>(itemdata.IconArray[0]);
            head.SetNativeSize();

            lineup.text = num == 1 ? string.Empty : string.Format("x{0}", num);
            linedown.text = itemdata.Name;

            if (canClick)
            {
                button.onClick.AddListener(delegate
                {
                    MMFrame.ShowFrame(FrameData.FrameEnum.ItemDetailFrame, new object[] { item });
                });
            }
            anim = GetComponent<Animation>();
            AnimationClip clip = CacheModule.Instance.Load<AnimationClip>(animations[Quality]);
            anim.AddClip(clip, animations[Quality]);
            anim.clip = clip;
        }

        public virtual float GetAnimationTime()
        {
            return anim.clip.length;
        }

        public virtual void PlayAnimation()
        {
            anim.Play(animations[Quality]);
        }

        int Quality
        {
            get
            {
                int num = item.Value;
                if (item.ItemType.Equals(ItemData.ItemEnum.Diamond))
                {
                    if (num > 1000)
                        return 2;
                    else if (num > 50)
                        return 1;
                }

                return 0;
            }
        }
    }
}