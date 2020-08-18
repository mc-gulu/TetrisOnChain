using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LitJson;
using MMFramework;
namespace MMGame
{
    public class A
    {
        public int a;
    }
    public enum LoginProcess
    {
        Start,//开始流程
        VersionJson,//下载VersionJson文件
        Update,//热更新
        TableData,//加载数据表
        ServerConfig,//读取动态配置
        ServerNotice,//读取游戏公告
        TimeDate,//同步时间日期
        Login,//登录
        LoadAllData,//获取玩家数据
        FillData,//补全初始玩家数据
        UPDATE_DAYS,
        LoadMail,//拉取公共邮件
        // Replenishment,//商城检测、补单
        Finish,
    }
    public enum ProcessState
    {
        Doing,
        Done,
        Error,
    }
    public struct StateData
    {
        public LoginProcess process;
        public ProcessState state;
        public string message;
    }
    public enum LoginPopWindow
    {
        EmergencyNotice,
        LoginShow,
    }

    public class LoginProcessModule : MonoBehaviour, BaseModule
    {
        public static LoginProcessModule Instance
        {
            get
            {
                return RootModule.Instance.GetModule<LoginProcessModule>();
            }
        }

        public StateData State;
        public List<LoginPopWindow> poplist = new List<LoginPopWindow>();

        public void Init()
        {
        }
        StateData old_state;
        public void Log()
        {
            if (old_state.process != State.process
            || old_state.state != State.state
            || !old_state.message.Equals(State.message))
            {
                old_state = State;
                LogModule.LogScreen(State.process.ToString() + ":" + State.state.ToString() + ":" + State.message);
            }
        }

        public void StartLoginProcess()
        {
            State.process = LoginProcess.Start;
            StateDone();
            Log();
            StartCoroutine(Process());
        }

        IEnumerator Process()
        {
            while (true)
            {
                if (State.process.Equals(LoginProcess.Finish))
                {
                    LogModule.LogScreen("登录流程完成");
                    break;
                }
                if (State.state.Equals(ProcessState.Done))
                {
                    NextProcess();
                }
                else if (State.state.Equals(ProcessState.Error))
                {
                    break;
                }
                // Debug.LogError("1");
                yield return new WaitForEndOfFrame();
            }
        }

        void NextProcess()
        {
            if (!State.process.Equals(LoginProcess.Finish))
            {
                State.process = (LoginProcess)(State.process + 1);
                State.state = ProcessState.Doing;
                State.message = string.Empty;
                Handler(State.process);
            }
        }

        void Handler(LoginProcess process)
        {
            if (process.Equals(LoginProcess.VersionJson))
            {
                LogModule.LogScreen("1.开始从OSS下载Version.json");
                VersionModule.Instance.LoadVersion();
            }
            else if (process.Equals(LoginProcess.Update))
            {
                LogModule.LogScreen("2.更新DLL(跳过");
                StateDone();
                Log();
            }
            else if (process.Equals(LoginProcess.TableData))
            {
                LogModule.LogScreen("3.载入表格数据(跳过");
                StateDone();
            }
            else if (process.Equals(LoginProcess.ServerConfig))
            {
                LogModule.LogScreen("4.读取Config(跳过");
                StateDone();
            }
            else if (process.Equals(LoginProcess.ServerNotice))
            {
                LogModule.LogScreen("5.读取Notice(跳过");
                StateDone();
            }
            else if (process.Equals(LoginProcess.TimeDate))
            {
                LogModule.LogScreen("6.同步日期时间");
                RootModule.Instance.GetModule<TimeModule>();
            }
            else if (process.Equals(LoginProcess.Login))
            {
                if (!ChannelConfigs.NeedShowLogin)
                {
                    LogModule.LogScreen("7.登录");
                    GameAccountModule.Instance.ServerLoginProcess();
                }
            }
            else if (process.Equals(LoginProcess.LoadAllData))
            {
                LogModule.LogScreen("8.拉取玩家数据");
                GameAccountModule.Instance.LoadAllValues();
            }

            else if (process.Equals(LoginProcess.FillData))
            {
                LogModule.LogScreen("9.补全玩家数据");
                EventModule.Instance.HandleEvent(EventEnum.FILL_DATA);
            }
            else if (process.Equals(LoginProcess.UPDATE_DAYS))
            {
                LogModule.LogScreen("10.更新登录日期");
                EventModule.Instance.HandleEvent(EventEnum.UPDATE_DAYS);
            }
            else if (process.Equals(LoginProcess.LoadMail))
            {
                LogModule.LogScreen("11.拉取公私邮件");
                MailModule.Instance.RequireMails(delegate
                {
                    NoticeTool.Broadcast(NoticeEnum.UPDATE_REDPOINT, new object[] { "rightlist.mail" });
                    StateDone();
                });
            }
            else
            {
                //测试掉落代码
                // int dropID = 30001;
                // List<ItemObj> list = ItemTools.GetDrops(dropID);
                // for (int i = 0; i < list.Count; i++)
                // {
                //     ItemObj obj = list[i];
                //     // Debug.Log(obj.ID + ":" + obj.Value);
                // }

                //测试花费代码
                // int costID = 27001;
                // string coststr = CostTool.CostString(costID);
                // Debug.Log(coststr);//显示花费

                // string cannot_afford_reason = string.Empty;
                // if (CostTool.CostCanAfford(costID, ref cannot_afford_reason))//判断花费
                // {
                //     CostTool.PayCost(costID);//应用花费
                // }
                // else
                // {
                //     Debug.LogError(cannot_afford_reason);//弹框，花费不起的tips
                // }

                DrillingModule.Instance.Init();
                DrillingModule.inited = true;
                CheckinModule check = CheckinModule.Instance;
                RootModule.Instance.InitModules();

                StateDone();
            }
        }

        public void StateDone()
        {
            Debug.Log(State.process.ToString() + ":done");
            State.state = ProcessState.Done;
        }

        public void StateError(string message)
        {
            State.state = ProcessState.Error;
            State.message = message;
        }
    }
}