using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using MMFramework;
namespace MMGame
{
    public class CheckinFrame : MMFrame
    {
        public GameObject content;
        public GameObject itemtemp;
        public Button close;
        // public Scrollv
        // public Button close;
        // public GameObject content;
        // public CheckinItem checkinitem;
        // public Text info;

        public override void Init(object[] objects)
        {
            if (close)
                close.onClick.AddListener(delegate
                {
                    MMFrame.HideFrame(FrameData.FrameEnum.CheckinFrame);
                });

            itemtemp.gameObject.SetActive(false);

            List<int> checkinlist = CheckinData.GetKeys();


            for (int i = 0; i < checkinlist.Count; i++)
            {
                int checkinID = checkinlist[i];

                GameObject itemobj = ObjTools.CopyGameObject(content, itemtemp);
                itemobj.SetActive(true);
                CheckinItem item = itemobj.GetComponent<CheckinItem>();
                item.UpdateUI(checkinID, delegate
                {
                    CheckinStateEnum stateEnum = CheckinModule.Instance.GetState(checkinID);
                    if (stateEnum.Equals(CheckinStateEnum.Ready))
                    {
                        EventModule.Instance.HandleEvent(EventEnum.CHECKIN, checkinID);
                    }
                });
            }

            int skipnum = 0;
            for (int i = 0; i < checkinlist.Count; i++)
            {
                int checkinID = checkinlist[i];
                CheckinStateEnum stateEnum = CheckinModule.Instance.GetState(checkinID);
                if (stateEnum.Equals(CheckinStateEnum.Got))
                {
                    skipnum++;
                }
                else
                {
                    break;
                }
            }
            if (skipnum > 0)
                StartCoroutine(TimeTools.DelayCallback(0.2f, delegate
                {
                    iTween.MoveBy(content, new Vector3(0, 250 * skipnum, 0), 1f);
                }));

        }
    }
}