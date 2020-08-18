using LitJson;
using System;
using System.IO;
using UnityEngine;

namespace MMFramework
{
    public class HotUpdateModule : MonoBehaviour, BaseModule
    {
        public void Init()
        {
        }
        private static HotUpdateModule instance;
        public static HotUpdateModule Instance { get => RootModule.Instance.GetModule<HotUpdateModule>(); }

        #region 判断新版本和下载本地逻辑
        private void CheckVersion()
        {
            RayServerModule.Instance.GetRemoteVerJson(json =>
            {
                if (string.IsNullOrEmpty(json))
                {
                    //没报错且没有配置文件，直接进下一步
                    // LoginProcessModule.Instance.State.state = ProcessState.Done;
                }
                else
                {
                    JsonData data = JsonMapper.ToObject(json);
                    if (data["data"].ContainsKey("urgentmsg"))
                    {
                        //todo 有紧急通知
                    }
                    bool isexpiredMin = CommonTools.IsExpired(Application.version, (string)data["data"]["minver"]);
                    bool isexpiredNew = CommonTools.IsExpired(Application.version, (string)data["data"]["newver"]);
                    if (isexpiredMin)
                    {
                        //todo 小于最小要求版本，跳转至下载新版本页面
                        //此处弹出页面，可以跳转商店或者退出程序
                    }
                    else if (isexpiredNew)
                    {
                        //todo 小于最新版本，提示去下载最新版本但不强制，对比AB包的名字
                        //此处弹出页面，可以跳转应用商店或者进入对比ab包名字

                    }
                    else
                    {
                        //当前大于等于最新版本，对比ab包名字
                        CheckBundle(data);
                    }
                }
            });
        }

        private void CheckBundle(JsonData data)
        {
            if (data["data"].ContainsKey("v" + Application.version))
            {
                if (data["data"]["v" + Application.version].ContainsKey("d" + PathTools.ServAreaNum))
                {
                    //获得当前版本当前区服ab包包名，寻找本地是否有此包，有则加载，没有下载
                    string bundleName = (string)data["data"]["v" + Application.version]["d" + PathTools.ServAreaNum];
                    LoadBundleByName(bundleName);
                }
                else if (data["data"]["v" + Application.version].ContainsKey("common"))
                {
                    //获得当前版本通用ab包包名，寻找本地是否有此包，有则加载，没有下载
                    string bundleName = (string)data["data"]["v" + Application.version]["common"];
                    LoadBundleByName(bundleName);
                }
                else
                {
                    //无区服包也无通用包，直接进入下一步
                    // LoginProcessModule.Instance.State.state = ProcessState.Done;
                }
            }
            else
            {
                //不存在当前app版本的ab包，直接进入下一步
                // LoginProcessModule.Instance.State.state = ProcessState.Done;
            }
        }

        private void LoadBundleByName(string bundleName)
        {
            if (File.Exists(PathTools.ResLocalDir + "/" + bundleName))
            {
                //加载ab包
                CacheModule.Instance.LoadBundle(PathTools.ResLocalDir + "/" + bundleName);
                //加载结束进入下一步
                // LoginProcessModule.Instance.State.state = ProcessState.Done;
            }
            else
            {
                //下载ab包并加载ab包
                RayServerModule.Instance.DownloadBundle(PathTools.ResRemoteDir + "/" + bundleName, PathTools.ResLocalDir + "/" + bundleName,
                    () =>
                    {
                        CacheModule.Instance.LoadBundle(PathTools.ResLocalDir + "/" + bundleName);
                        //加载结束进入下一步
                        // LoginProcessModule.Instance.State.state = ProcessState.Done;
                    });
            }
        }

        #endregion
    }
}