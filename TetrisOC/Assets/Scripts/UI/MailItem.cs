using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using MMFramework;
namespace MMGame
{
    public class Mail
    {
        public string Title;
        public string Desc;
        public int DropID;
        public int MailID;
        public string Minversion;
        public string Beforetime;
        public string GetDropErrorMsg
        {
            get
            {
                string currentversion = CommonTools.GetGameVersion();
                if (!string.IsNullOrEmpty(Minversion) && CommonTools.IsExpired(currentversion, Minversion))
                    return StringConfig.Tips_Low_Version;
                return string.Empty;
            }
        }

        public override string ToString()
        {
            return LitJson.JsonMapper.ToJson(this);
        }
    }
    public class MailItem : MonoBehaviour
    {
        public Text title, content;
        public Button getbtn;
        public GameObject notreadobj, readobj;

        public void InitItem(Mail mail, MailState state, UnityEngine.Events.UnityAction action)
        {
            notreadobj.SetActive(state.Equals(MailState.NotRead));
            readobj.SetActive(!state.Equals(MailState.NotRead));

            title.text = mail.Title;
            content.text = mail.Desc;

            getbtn.onClick.AddListener(action);
        }
    }
}