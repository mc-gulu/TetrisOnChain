using MMFramework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace MMGame
{
    public class BattleResultFrame : MMFrame
    {
        public GameObject VTitle;
        public GameObject DTitle;
        public Text LvText;
        public Button DoubleRewardBtn_2;
        public Button Back2MainBtn_2;
        public Button Back2MainBtn_1;
        public GameObject NodeDouble;
        public GameObject NodeSingle;
        public BattleCountItem[] UICountItems;

        public GameObject content1, content2;
        public IconLoader icontemp;

        public override void Init(object[] objects)
        {
            var success = (bool)objects[1];
            int lv = (int)objects[2];
            LvText.text = "LV" + lv;
            List<ItemObj> drops = (List<ItemObj>)objects[3];
            Back2MainBtn_2.onClick.AddListener(() =>
            {
                NoticeTool.Broadcast(NoticeEnum.CLEAR_ROOM);
                HideFrame(frameEnum);

                GameController.Instance.LoadMain();
                if (success)
                {
                    GameController.Instance.StartCoroutine(TimeTools.DelayCallback(1f, delegate { GameController.Instance.CreateTimeline(); }));
                }
                else
                {
                    NoticeTool.Broadcast(NoticeEnum.FailedReturn);
                }
            });
            Back2MainBtn_1.onClick.AddListener(() =>
            {
                NoticeTool.Broadcast(NoticeEnum.CLEAR_ROOM);
                HideFrame(frameEnum);

                GameController.Instance.LoadMain();
                if (success)
                {
                    GameController.Instance.StartCoroutine(TimeTools.DelayCallback(1f, delegate { GameController.Instance.CreateTimeline(); }));
                }
                else
                {
                    NoticeTool.Broadcast(NoticeEnum.FailedReturn);
                }
            });
            DoubleRewardBtn_2.onClick.AddListener(delegate
            {
                DoubleRewardBtn_2.enabled = false;
                EventModule.Instance.HandleEvent(EventEnum.TASK_DOUBLE);
            });
            if (success)
            {
                VTitle.SetActive(true);
            }
            else
            {
                DTitle.SetActive(true);
            }
            var countdatas = BattleCountModule.Instance.AllPartnerData();
            var maxarr = BattleCountModule.Instance.EachMax(countdatas);
            List<string> keys = new List<string>(countdatas.Keys);
            for (int i = 0; i < keys.Count; i++)
            {
                UICountItems[i].transform.Find("IconNode").gameObject.SetActive(true);
                UICountItems[i].Init(countdatas[keys[i]], maxarr);
            }

            if (drops != null)
            {
                for (int i = 0; i < drops.Count; i++)
                {
                    ItemObj item = drops[i];
                    GameObject obj = ObjTools.CopyGameObject(content1, icontemp.gameObject);
                    obj.SetActive(true);
                    IconLoader icon = obj.GetComponent<IconLoader>();
                    icon.Init(item, true);
                }
            }
            FloorFightData ffd = FloorFightData.GetData(lv);
            NodeDouble.SetActive(ffd.AdDouble && success);
            NodeSingle.SetActive(!ffd.AdDouble || !success);
        }

        void Handler(System.Enum noticeID, object[] objects)
        {
            List<ItemObj> extradrops = (List<ItemObj>)objects[0];

            for (int i = 0; i < extradrops.Count; i++)
            {
                ItemObj item = extradrops[i];
                GameObject obj = ObjTools.CopyGameObject(content1, icontemp.gameObject);
                obj.SetActive(true);
                IconLoader icon = obj.GetComponent<IconLoader>();
                icon.Init(item, true);
            }
        }

        void OnEnable()
        {
            NoticeTool.RegisterNotice(NoticeEnum.TASK_REWARD_EXTRA, Handler);
        }

        void OnDisable()
        {
            NoticeTool.UnRegisterNotice(NoticeEnum.TASK_REWARD_EXTRA, Handler);
        }
    }
}