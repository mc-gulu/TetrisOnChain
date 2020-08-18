using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using MMFramework;
namespace MMGame
{
    public class MailDetailFrame : MMFrame
    {
        public Text title, text;
        public GameObject rewardcontent;
        public Button button;
        public Text buttontext;
        public GameObject gettag;
        public GameObject iconloadertemp;

        public override void Init(object[] objects)
        {
            int mailID = (int)objects[1];
            Mail mail = MailModule.Instance.GetMail(mailID);
            if (mail != null)
            {
                title.text = mail.Title;
                text.text = mail.Desc;

                if (mail.DropID > 0)
                {
                    rewardcontent.gameObject.SetActive(true);
                    List<ItemObj> itemlist = ItemTools.GetDrops(mail.DropID);
                    for (int i = 0; i < itemlist.Count; i++)
                    {
                        ItemObj itemObj = itemlist[i];
                        GameObject item = ObjTools.CopyGameObject(rewardcontent, iconloadertemp);
                        item.SetActive(true);
                        IconLoader itemloader = item.GetComponent<IconLoader>();
                        itemloader.Init(itemObj, true);
                        // int index = i;
                        // StartCoroutine(TimeTools.DelayCallback(index * 0.1f, delegate
                        // {
                        //     itemloader.PlayAnimation();
                        // }));
                    }

                    if (MailModule.Instance.GetMailState(mail.MailID).Equals(MailState.NotRead))
                    {
                        gettag.SetActive(false);
                        buttontext.text = StringConfig.PostButtonTextWithDropID;
                        button.onClick.AddListener(delegate
                        {
                            string err_msg = mail.GetDropErrorMsg;
                            if (string.IsNullOrEmpty(err_msg))
                            {
                                EventModule.Instance.HandleEvent(EventEnum.MAIL_READ, mail.MailID);
                            }
                            else
                            {
                                MMFrame.ShowTips(StringConfig.Tips_Title, err_msg);
                            }
                            MMFrame.HideFrame(FrameData.FrameEnum.MailDetailFrame);
                        });
                    }
                    else
                    {
                        gettag.SetActive(true);
                        buttontext.text = StringConfig.PostButtonTextWithNoDropID;
                        button.onClick.AddListener(delegate
                        {
                            MMFrame.HideFrame(FrameData.FrameEnum.MailDetailFrame);
                        });
                    }
                }
                else
                {
                    rewardcontent.gameObject.SetActive(false);
                    gettag.SetActive(false);
                    buttontext.text = StringConfig.PostButtonTextWithNoDropID;
                    button.onClick.AddListener(delegate
                    {
                        EventModule.Instance.HandleEvent(EventEnum.MAIL_READ, mail.MailID);
                        MMFrame.HideFrame(FrameData.FrameEnum.MailDetailFrame);
                    });
                }
            }
            else
            {
                rewardcontent.gameObject.SetActive(false);
                gettag.SetActive(false);
                text.text = StringConfig.PostHaveDelete;
                buttontext.text = StringConfig.PostButtonTextWithNoDropID;
                button.onClick.AddListener(delegate
                {
                    EventModule.Instance.HandleEvent(EventEnum.MAIL_READ, mail.MailID);
                    MMFrame.HideFrame(FrameData.FrameEnum.MailDetailFrame);
                });
            }
        }
    }
}