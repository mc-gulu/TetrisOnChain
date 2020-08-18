using System.Collections.Generic;
using MMFramework;
using UnityEngine;
using LitJson;
using UnityEngine.UI;
namespace MMGame
{
    public class VersionModule : MonoBehaviour, BaseModule
    {
        public static VersionModule Instance
        {
            get
            {
                return RootModule.Instance.GetModule<VersionModule>();
            }
        }

        public void Init()
        {

        }
        public bool Inited { get; set; }
        public bool HaveNotice
        {
            get
            {
                return !string.IsNullOrEmpty(UrgentNotice);
            }
        }
        public bool HaveRead { get; set; }
        public string UrgentNotice { get; set; }

        public void LoadVersion()
        {
            StartCoroutine(NetTools.GetRemoteContent(ChannelConfigs.OSSURLJSON, delegate (bool osssuccess, string content)
            {
                if (osssuccess)
                {
                    // LogModule.LogScreen("下载完成");
                    JsonData json = JsonMapper.ToObject(content);

                    Debug.Log(json.ToJson());

                    // json.Set("list2", new List<A>());
                    // List<A> list2 = json.Get("list2", new List<A>());
                    // Debug.Log("-----" + list2.Count);

                    // A aa = new A();
                    // aa.a = 888;
                    // json.Set("list/2", aa);

                    // json.Set("aaa/bbb/ccc", 666);
                    // int av = json.Get("aaa/bbb/ccc", 0);
                    // Debug.Log("-----" + av);

                    // Debug.Log(json.ToJson());

                    // List<A> list = json.Get("list", new List<A>());
                    // Debug.Log("-----" + list[0].a);

                    // A aobj = json.Get("list/2", new A());
                    // Debug.Log("-----" + aobj.a);

                    // int avalue = json.Get("list/2/a", 0);
                    // Debug.Log("-----" + avalue);

                    //必须的初始化
                    if (json.ContainsKey("gameurl"))
                    {
                        string URL = json["gameurl"].ToString();
                        ServerModule.Instance.InitModule(URL);
                        LoginProcessModule.Instance.StateDone();
                    }
                    else
                        LoginProcessModule.Instance.StateError("version.json中未找到gameurl");

                    if (json.ContainsKey("urgentmsg"))
                    {
                        UrgentNotice = json["urgentmsg"].ToString();
                    }






                    Inited = true;
                }
                else
                    LoginProcessModule.Instance.StateError("下载失败");
            }));
        }
    }
}