using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using MMFramework;
namespace MMGame
{
    public class MailListFrame : MMFrame
    {
        public GameObject content;
        public MailItem itemtemp;
        public Button getall, removeread, close;

        public override void Init(object[] objects)
        {
            itemtemp.gameObject.SetActive(false);
            UpdateUI();
            getall.onClick.AddListener(delegate
            {
                EventModule.Instance.HandleEvent(EventEnum.MAIL_GETALL);
            });

            removeread.onClick.AddListener(delegate
            {
                MailModule.Instance.RemoveRead();
            });

            close.onClick.AddListener(delegate
            {
                MMFrame.HideFrame(FrameData.FrameEnum.MailListFrame);
            });

            MailModule.Instance.RequireMails(delegate
            {
                UpdateUI();
                NoticeTool.Broadcast(NoticeEnum.UPDATE_REDPOINT, new object[] { "rightlist.mail" });
            });
        }

        protected override void OnAfterAnimation(FrameAniType aniType)
        {
            Debug.Log("完成动作类型" + aniType.ToString());
        }

        void OnHandleEmailUpdate(System.Enum noticeID, object[] objects)
        {
            UpdateUI();
        }

        void UpdateUI()
        {
            for (int i = content.transform.childCount - 1; i >= 0; i--)
            {
                Transform item = content.transform.GetChild(i);
                if (!item.gameObject.Equals(itemtemp.gameObject))
                {
                    item.SetParent(null);
                    Object.DestroyImmediate(item.gameObject);
                }
            }

            var list = MailModule.Instance.GetMails();
            for (int i = 0; i < list.Count; i++)
            {
                Mail mail = list[i];
                MailState mailState = MailModule.Instance.GetMailState(mail.MailID);
                if (!mailState.Equals(MailState.Hide))
                {
                    GameObject itemobj = ObjTools.CopyGameObject(content, itemtemp.gameObject);
                    itemobj.SetActive(true);
                    MailItem item = itemobj.GetComponent<MailItem>();
                    int mailID = mail.MailID;
                    item.InitItem(mail, mailState, delegate
                    {
                        //显示邮件，index
                        MMFrame.ShowFrame(FrameData.FrameEnum.MailDetailFrame, new object[] { mailID });
                    });
                }
            }

        }

        private void OnEnable()
        {
            NoticeTool.RegisterNotice(NoticeEnum.EMAIL_UPDATE, OnHandleEmailUpdate);
        }

        private void OnDisable()
        {
            NoticeTool.UnRegisterNotice(NoticeEnum.EMAIL_UPDATE, OnHandleEmailUpdate);
        }
    }
}