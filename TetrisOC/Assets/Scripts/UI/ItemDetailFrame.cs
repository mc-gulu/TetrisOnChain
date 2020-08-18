using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace MMGame
{
    public class ItemDetailFrame : MMFrame
    {
        public IconLoader icon;
        public Text title;
        public Text text;
        public Button close;
        public override void Init(object[] objects)
        {
            ItemObj item = (ItemObj)objects[1];
            icon.Init(item, false);
            ItemData itemData = ItemData.GetData(ItemTools.GetIDType(item.ID));

            if (itemData.ItemType.Equals(ItemData.ItemEnum.Gold) ||
            itemData.ItemType.Equals(ItemData.ItemEnum.Diamond) ||
            itemData.ItemType.Equals(ItemData.ItemEnum.Exp))
            {
                title.text = itemData.Name;
                text.text = itemData.Desc;
            }
            else if (itemData.ItemType.Equals(ItemData.ItemEnum.Creature))
            {
                int creatureID = item.ID;
                CreatureData creature = CreatureData.GetData(creatureID);
                title.text = creature.Name;
                text.text = creature.Desc;
            }

            close.onClick.AddListener(delegate
            {
                MMFrame.HideFrame(FrameData.FrameEnum.ItemDetailFrame);
            });
        }

        protected override void OnAfterAnimation(FrameAniType aniType)
        {
            Debug.Log("完成动作类型" + aniType.ToString());
        }
    }
}