using LitJson;
using System;
using System.Collections;
using System.IO;
using UnityEngine;
using UnityEngine.Networking;

namespace MMFramework
{
    public class RayServerModule : MonoBehaviour, BaseModule
    {
        public void Init()
        {
        }

        private static RayServerModule instance;

        public static RayServerModule Instance { get => RootModule.Instance.GetModule<RayServerModule>(); }

        public void GetRemoteVerJson(Action<string> afterGet)
        {
            StartCoroutine(RequestRemoteVerJson(resVersion => afterGet(resVersion)));
        }

        public void DownloadBundle(string path, string savepath, Action onFinish)
        {
            StartCoroutine(RequestRemoteBundle(path, savepath, onFinish));
        }

        private IEnumerator RequestRemoteVerJson(Action<string> onJsonGetted)
        {
            var remoteResVersionPath = PathTools.VersionJsonRemotePath;

            var request = new UnityWebRequest(remoteResVersionPath);
            request.downloadHandler = new DownloadHandlerBuffer();
            yield return request.SendWebRequest();
            if (request.isHttpError || request.isNetworkError)
            {
                Debug.Log(request.error);
                if (request.error.Contains("404"))
                {
                    Debug.Log("找不到配置文件，证明没有热更包");
                    onJsonGetted(null);
                }
                else
                {
                    //todo
                }
            }
            else
            {
                var jsonString = request.downloadHandler.text;
                onJsonGetted(jsonString);
            }
        }

        private IEnumerator RequestRemoteBundle(string path, string savepath, Action onFinish)
        {
            var remoteBundlePath = path;
            var request = new UnityWebRequest(remoteBundlePath);
            request.downloadHandler = new DownloadHandlerBuffer();
            yield return request.SendWebRequest();
            if (request.isHttpError || request.isNetworkError)
            {
                Debug.Log(request.error);
            }
            else
            {
                var bundleBytes = request.downloadHandler.data;
                if (!Directory.Exists(savepath.Substring(0, savepath.LastIndexOf('/'))))
                {
                    Directory.CreateDirectory(savepath.Substring(0, savepath.LastIndexOf('/')));
                }
                File.WriteAllBytes(savepath, bundleBytes);
                onFinish();
            }
        }
    }
}