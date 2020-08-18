using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using MMFramework;
namespace MMGame
{
    public class OfflineHarvestFrame : MMFrame
    {
        public Text timespan;
        public GameObject rewardcontent;
        public IconLoader icontemp;
        public Button getbtn;

        public override void Init(object[] objects)
        {
            icontemp.gameObject.SetActive(false);
            timespan.text = OfflineModule.Instance.OfflineTime();

            List<ItemObj> list = OfflineModule.Instance.OfflineItems();
            for (int i = 0; i < list.Count; i++)
            {
                ItemObj item = list[i];
                GameObject obj = ObjTools.CopyGameObject(rewardcontent, icontemp.gameObject);
                obj.SetActive(true);
                IconLoader icon = obj.GetComponent<IconLoader>();
                icon.Init(item, true);
                // Debug.Log("Icon" + item.ID + " " + item.Value);
            }

            getbtn.onClick.AddListener(delegate
            {
                EventModule.Instance.HandleEvent(EventEnum.OFFLINE_GET);
                MMFrame.HideFrame(FrameData.FrameEnum.OfflineHarvestFrame);
            });
        }
    }
}