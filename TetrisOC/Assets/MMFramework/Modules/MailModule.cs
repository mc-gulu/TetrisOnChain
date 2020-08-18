using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MMFramework;
namespace MMGame
{
    public enum MailState
    {
        NotRead = 0,
        Read = 1,
        Hide = 2
    }
    public class MailModule : MonoBehaviour, BaseModule
    {
        public static MailModule Instance
        {
            get
            {
                return RootModule.Instance.GetModule<MailModule>();
            }
        }

        // List<MailStruct> publicmails, privatemails;

        public void Init()
        {
            RedModule.Instance.Regist("rightlist.mail", delegate
            {
                int num = 0;
                List<Mail> list = GetMails();
                for (int i = 0; i < list.Count; i++)
                {
                    Mail mail = list[i];
                    MailState state = GetMailState(mail.MailID);
                    if (state.Equals(MailState.NotRead))
                        num++;
                }
                return num;
            });
        }

        public List<Mail> GetMails()
        {
            List<Mail> privatelists = DataModule.Instance.Get<List<Mail>>(DataModule.Key_PrivateMaillist, new List<Mail>(), false);
            List<Mail> publiclists = DataModule.Instance.Get<List<Mail>>(DataModule.Key_PublicMaillist, new List<Mail>(), false);
            publiclists.AddRange(privatelists);
            return publiclists;
        }

        public Mail GetMail(int mailID)
        {
            List<Mail> list = GetMails();
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].MailID == mailID)
                    return list[i];
            }
            return null;
        }

        public MailState GetMailState(int mailID)
        {
            List<int> hidelist = DataModule.Instance.Get<List<int>>(DataModule.Key_MailDelete, new List<int>());
            if (hidelist.Contains(mailID))
                return MailState.Hide;
            else
            {
                List<int> readlist = DataModule.Instance.Get<List<int>>(DataModule.Key_MailRead, new List<int>());
                if (readlist.Contains(mailID))
                    return MailState.Read;
            }
            return MailState.NotRead;
        }

        public void SetMailState(int mailID, MailState state)
        {
            List<int> readlist = DataModule.Instance.Get<List<int>>(DataModule.Key_MailRead, new List<int>());
            List<int> hidelist = DataModule.Instance.Get<List<int>>(DataModule.Key_MailDelete, new List<int>());
            if (state == MailState.Read)
            {
                if (!readlist.Contains(mailID))
                    readlist.Add(mailID);
                if (hidelist.Contains(mailID))
                    hidelist.Remove(mailID);
            }
            else if (state == MailState.Hide)
            {
                if (readlist.Contains(mailID))
                    readlist.Remove(mailID);
                if (!hidelist.Contains(mailID))
                    hidelist.Add(mailID);
            }
            else
            {
                if (readlist.Contains(mailID))
                    readlist.Remove(mailID);
                if (hidelist.Contains(mailID))
                    hidelist.Remove(mailID);
            }
            DataModule.Instance.Set(DataModule.Key_MailRead, readlist);
            DataModule.Instance.Set(DataModule.Key_MailDelete, hidelist);

            NoticeTool.Broadcast(NoticeEnum.UPDATE_REDPOINT, new object[] { "rightlist.mail" });
        }

        public void DeleteAllRead()
        {
            List<int> readlist = DataModule.Instance.Get<List<int>>(DataModule.Key_MailRead, new List<int>());
            DataModule.Instance.Set(DataModule.Key_MailDelete, readlist);
        }



        // public void SetMailState(bool ispublic, string mailid, MailState state)
        // {
        //     DataModule.Instance.SetMailState(ispublic, mailid, (int)state);
        //     NoticeUI.Broadcast(NoticeID.EMAIL_UPDATE);
        // }

        public void RequireMails(System.Action successcall)
        {
            int successnum = 0;
            //分别从服务器请求，更新到临时Json加密里
            ServerModule.Instance.GetPublicValue(DataModule.Key_PublicMaillist, delegate (bool success, LitJson.JsonData resultGetValue)
             {
                 if (success)
                 {
                     if (DataModule.Instance.Verify(false))
                     {
                         string str = resultGetValue["value"].ToString();
                         LitJson.JsonData jsonData = LitJson.JsonMapper.ToObject(str);
                         DataModule.Instance.Set(DataModule.Key_PublicMaillist, jsonData, false);
                         DataModule.Instance.GenerateMd5(false);
                         successnum++;

                         if (successnum == 2)
                         {
                             successcall();
                         }
                     }
                 }
             });
            //分别从服务器请求，更新到临时Json加密里
            ServerModule.Instance.GetValue(DataModule.Instance.Gid, DataModule.Key_PrivateMaillist, delegate (bool success, LitJson.JsonData resultGetValue)
             {
                 if (success)
                 {
                     if (DataModule.Instance.Verify(false))
                     {
                         string str = resultGetValue["value"].ToString();
                         LitJson.JsonData jsonData = LitJson.JsonMapper.ToObject(str);
                         DataModule.Instance.Set<LitJson.JsonData>(DataModule.Key_PrivateMaillist, jsonData, false);
                         DataModule.Instance.GenerateMd5(false);
                         successnum++;

                         if (successnum == 2)
                         {
                             successcall();
                         }
                     }
                 }
             });
            //都完成，调用successcall
        }

        public List<ItemObj> CollectAll()
        {
            List<Mail> list = GetMails();
            List<ItemObj> drops = new List<ItemObj>();
            for (int i = 0; i < list.Count; i++)
            {
                Mail mail = list[i];
                MailState state = GetMailState(mail.MailID);
                if (state == MailState.NotRead && mail.DropID > 0)
                {
                    if (string.IsNullOrEmpty(mail.GetDropErrorMsg))
                    {
                        SetMailState(mail.MailID, MailState.Read);
                        List<ItemObj> items = ItemTools.GetDrops(mail.DropID);
                        drops.AddRange(items);
                    }
                }
            }
            ItemModule.Instance.GetDrop(drops);
            return drops;
        }

        public List<ItemObj> ReadMail(int mailID)
        {
            Mail mail = GetMail(mailID);
            MailState state = GetMailState(mailID);
            if (state == MailState.NotRead)
            {
                SetMailState(mail.MailID, MailState.Read);
                if (mail.DropID > 0 && string.IsNullOrEmpty(mail.GetDropErrorMsg))
                {
                    List<ItemObj> items = ItemTools.GetDrops(mail.DropID);
                    ItemModule.Instance.GetDrop(items);
                    return items;
                }
            }

            return null;
        }

        public void RemoveRead()
        {
            EventModule.Instance.HandleEvent(EventEnum.MAIL_DELETEALL);
        }

        public bool HaveNotRead()
        {
            // bool[] ispublic = { false, true };
            // for (int j = 0; j < ispublic.Length; j++)
            // {
            //     var list = DataModule.Instance.GetMailList(ispublic[j]);
            //     for (int i = 0; i < list.Count; i++)
            //     {
            //         if (GetMailState(ispublic[j], list[i].mailid).Equals(MailState.NotRead))
            //         {
            //             return true;
            //         }
            //     }
            // }
            return false;
        }
    }
}