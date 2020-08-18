using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MMFramework;
using UnityEngine.UI;
namespace MMGame
{
    public class CheckinItem : MonoBehaviour
    {
        public Text text;
        public GameObject NotRealy, Ready, Got;
        public Button getbtn;
        public GameObject itemcontent;
        public GameObject iconloadertemp;
        int checkinID;
        UnityEngine.Events.UnityAction action;
        public void UpdateUI(int icheckinID, UnityEngine.Events.UnityAction iaction)
        {
            this.checkinID = icheckinID;
            this.action = iaction;

            CheckinData checkin = CheckinData.GetData(checkinID);
            text.text = checkin.Info;
            getbtn.onClick.RemoveAllListeners();
            getbtn.onClick.AddListener(action);

            iconloadertemp.gameObject.SetActive(false);

            List<ItemObj> itemlist = ItemTools.GetDrops(checkin.DropID);
            for (int i = itemcontent.transform.childCount - 1; i >= 0; i--)
            {
                Transform child = itemcontent.transform.GetChild(i);
                if (child.gameObject.activeSelf)
                    Destroy(child.gameObject);
            }

            for (int i = 0; i < itemlist.Count; i++)
            {
                ItemObj itemObj = itemlist[i];
                GameObject item = ObjTools.CopyGameObject(itemcontent, iconloadertemp);
                item.SetActive(true);
                IconLoader itemloader = item.GetComponent<IconLoader>();
                itemloader.Init(itemObj, true);
                // int index = i;
                // StartCoroutine(TimeTools.DelayCallback(index * 0.1f, delegate
                // {
                //     itemloader.PlayAnimation();
                // }));
            }

            CheckinStateEnum stateEnum = CheckinModule.Instance.GetState(checkinID);
            NotRealy.SetActive(false);
            Ready.SetActive(false);
            Got.SetActive(false);

            if (stateEnum.Equals(CheckinStateEnum.NotReady))
            {
                NotRealy.SetActive(true);
            }
            else if (stateEnum.Equals(CheckinStateEnum.Ready))
            {
                Ready.SetActive(true);
            }
            else if (stateEnum.Equals(CheckinStateEnum.Got))
            {
                Got.SetActive(true);
            }

            getbtn.enabled = stateEnum.Equals(CheckinStateEnum.Ready);
        }


        void Handler(System.Enum noticeID, object[] objects)
        {
            UpdateUI(checkinID, action);
        }

        void OnEnable()
        {
            NoticeTool.RegisterNotice(NoticeEnum.CHECKIN_UPDATE, Handler);
            NoticeTool.RegisterNotice(NoticeEnum.UPDATE_DAYS, Handler);
        }

        void OnDisable()
        {
            NoticeTool.UnRegisterNotice(NoticeEnum.CHECKIN_UPDATE, Handler);
            NoticeTool.UnRegisterNotice(NoticeEnum.UPDATE_DAYS, Handler);
        }
    }
}