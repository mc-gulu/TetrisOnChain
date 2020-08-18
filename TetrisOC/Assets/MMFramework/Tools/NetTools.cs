using System;
using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
namespace MMFramework
{
    public static class NetTools
    {
        //检查网络,从远程下载,存储缓存,结束回调(存储完成,下载失败)
        public static IEnumerator GetRemoteContent(string url, System.Action<bool, string> delegatecall)
        {
            MMGame.LogModule.LogScreen("下载" + url);
            UnityWebRequest request = UnityWebRequest.Get(url);
            request.timeout = 30;
            yield return request.SendWebRequest();
            string content;
            if (request.isNetworkError || request.isHttpError)
            {
                // ServerLogModule.Instance.PushError("VersionModuleUnknownError: " + request.error + request.responseCode + url);
            }
            if (request.isNetworkError)
            {
                // DebugTool.LogError("Get RemoteFile Error:" + request.error);
                content = string.Empty;
            }
            else
            {
                // DebugTool.Log("Get RemoteFile Success");
                content = request.downloadHandler.text;
            }

            delegatecall(!request.isNetworkError, content);
            request.Dispose();
            request = null;
        }
    }
}