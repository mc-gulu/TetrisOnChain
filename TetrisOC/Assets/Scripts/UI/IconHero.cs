using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MMFramework;
using UnityEngine.UI;
namespace MMGame
{
    public class IconHero : MonoBehaviour, IconInterface
    {
        public Image head;
        public Image bg;
        public Text text;
        public StarParentUI stars;
        Animation anim;
        public Button button;
        public Image careericon;
        public Image eleicon;
        public AnimationClip[] animations;
        ItemObj item;
        public virtual void Init(ItemObj itemobj, bool canClick)
        {
            this.item = itemobj;
            int creatureID = item.ID;
            int star = item.Value;

            CreatureData creature = CreatureData.GetData(creatureID);
            head.sprite = CacheModule.Instance.Load<Sprite>(creature.IconPath);
            head.SetNativeSize();

            text.text = creature.Name;

            stars.StarByLv(star);

            if (canClick)
            {
                button.onClick.AddListener(delegate
                {
                    MMFrame.ShowFrame(FrameData.FrameEnum.ItemDetailFrame, new object[] { item });
                });
            }
            anim = GetComponent<Animation>();
            AnimationClip clip = animations[Quality];
            anim.AddClip(clip, clip.name);
            anim.clip = clip;

            careericon.sprite = CacheModule.Instance.Load<Sprite>(PathTools.careericonpathname[creature.Career]);
            eleicon.sprite = CacheModule.Instance.Load<Sprite>(PathTools.elementiconpathname[creature.Element]);

            bg.sprite = CacheModule.Instance.Load<Sprite>(ConfigInGame.StarBGPath[star / 2]);
        }

        public virtual float GetAnimationTime()
        {
            return anim.clip.length;
        }

        public virtual void PlayAnimation()
        {
            anim.Play(anim.clip.name);
        }

        int Quality
        {
            get
            {
                int star = item.Value;
                if (star >= 5)
                {
                    return 2;
                }
                else if (star >= 3)
                {
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
        }
    }
}