using System.Collections.Generic;
using MMFramework;
using UnityEngine;
using LitJson;
namespace MMGame
{
    public class GameAccountModule : MonoBehaviour, BaseModule
    {
        public static GameAccountModule Instance
        {
            get
            {
                return RootModule.Instance.GetModule<GameAccountModule>();
            }
        }

        public void Init()
        {

        }

        public void ServerLoginProcess()
        {
            LogModule.LogScreen("SDK登录");
            DataModule.Instance.Gid = CommonTools.Gid;
            LogModule.LogScreen("游戏服登录" + DataModule.Instance.Gid);
            ServerModule.Instance.Login(DataModule.Instance.Gid, string.Empty, delegate (bool successLogin, LitJson.JsonData resultLogin)
            {
                if (!successLogin)
                {
                    LogModule.LogScreen("登录失败");
                    return; //TODO 登录 逻辑错误处理
                }
                ServerModule.Instance.Ticket = resultLogin["ticket"].ToString();
                LogModule.LogScreen("登录成功");
                LoginProcessModule.Instance.State.state = ProcessState.Done;
                LoginProcessModule.Instance.Log();
            });
        }

        public void LoadAllValues()
        {
            LogModule.LogScreen("获取用户数据" + DataModule.Instance.Gid);
            ServerModule.Instance.GetAllValues(DataModule.Instance.Gid, delegate (bool successGetAllValues, LitJson.JsonData resultGetAllValues)
            {
                if (!successGetAllValues)
                    return; //TODO 获取所有数据 逻辑错误处理
                LogModule.LogScreen("获取用户数据成功");

                string json = resultGetAllValues["values"].ToJson();
                EventModule.Instance.HandleEvent(EventEnum.LOAD_ALL_DATA, json);

                LoginProcessModule.Instance.State.state = ProcessState.Done;
                LoginProcessModule.Instance.Log();

            });
        }

        // public T Get<T>(string key)
        // {
        //     return null;
        // }
    }
}