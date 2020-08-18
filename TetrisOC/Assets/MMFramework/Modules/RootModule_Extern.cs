using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MMFramework;
using MMGame;
namespace MMGame
{
    public static class RootModule_Extern
    {
        public static void InitModules(this RootModule root)
        {
            root.GetModule<TimeModule>();

            Screen.sleepTimeout = 180;

            root.GetModule<LocalModule>();

            root.GetComponent<LogicModule>();

            // root.GetModule<AdModule>();

            // root.GetModule<AudioModule>();//不初始化 HOME背景没声音
            //DebugTool.LogError("load IAPModule");
            //GetModule<IAPModule>();//不初始化,第一次点击store报错
            //DebugTool.LogError("load module");

            // root.GetModule<CheckinModule>();

            // root.GetModule<ReplenishmentModule>();

            // string oldgid = PlayerPrefs.GetString("gid", string.Empty);
            // OtherSDKsModule.Instance.InitSDKs(AccountModule.Instance.ChannelID.ToString(), "old" + oldgid);

            // AnalyticsModule am = AnalyticsModule.Instance;

            // TimeOnlineModule.Instance.AddCallback(TimeOnlineModule.PP, PPModule.Instance.AddOnePP);
            // TimeOnlineModule.Instance.AddCallback(TimeOnlineModule.MainBox, MainBoxModule.Instance.AddOne);
        }



        public static void Init_BeforeHomeNotice(this RootModule root)
        {

        }

        public static void Init_AfterLogin(this RootModule root)
        {

        }
    }
}