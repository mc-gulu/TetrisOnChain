using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MMFramework;
namespace MMGame
{
    public class IconLoader : MonoBehaviour
    {
        // public GameObject iconhero;
        // public GameObject iconitem;
        IconInterface icon;
        public void Init(ItemObj item, bool canClick)
        {
            int ID = item.ID;
            ItemData.ItemEnum itemType = item.ItemType;
            GameObject go;
            if (itemType.Equals(ItemData.ItemEnum.Creature))
                go = ObjTools.CreatePrefab(transform, ConfigInGame.IconHeroPath);
            else
                go = ObjTools.CreatePrefab(transform, ConfigInGame.IconItemPath);

            icon = go.GetComponent<IconInterface>();
            icon.Init(item, canClick);
        }

        public float GetAnimationTime()
        {
            return icon.GetAnimationTime();
        }

        public void PlayAnimation()
        {
            icon.PlayAnimation();
        }
    }
}