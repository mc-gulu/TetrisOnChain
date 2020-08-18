using System;
using System.Collections;
using System.Collections.Generic;
using BestHTTP;
using UnityEngine;
using MMFramework;
namespace MMGame
{
    public class ServerModule : MonoBehaviour, BaseModule
    {
        enum NetType
        {
            Post,
            Get,
        }
        class ConnectData
        {
            public NetType netType;
            public string url;
            public Dictionary<string, string> fields;
            public System.Action<bool, LitJson.JsonData> callback;
            public ConnectData(NetType netType, string url, Dictionary<string, string> fields, System.Action<bool, LitJson.JsonData> callback)
            {
                this.netType = netType;
                this.url = url;
                this.fields = fields;
                this.callback = callback;
            }
            public int unknown_retry = 0;
        }
        public static ServerModule Instance
        {
            get
            {
                return RootModule.Instance.GetModule<ServerModule>();
            }
        }

        public void Init()
        {

        }
        int[] PayConfirmTime = { 2, 5, 10, 30, 60, 120, 300, 300, 300, 300 };
        int ConfirmPayStartCount = 1;
        int CountMax = 10;
        System.Action<ErrorType, string, LitJson.JsonData, System.Action> errorHandler;
        string URL { get; set; }
        public string Ticket { get; set; }
        public void InitModule(string url)
        {
            URL = url;
        }

        public void Login(string gid, string token, System.Action<bool, LitJson.JsonData> callback)
        {
            Xint a = new Xint(SDK_Configs.a);
            Xint b = new Xint(SDK_Configs.b);
            Xint c = new Xint(SDK_Configs.c);
            string currentversion = a.ToString() + "." + b.ToString() + "." + c.ToString();
            string secret = AABB.Secret();
            Debug.Log(currentversion);
            Debug.Log(gid);
            string cmd = "user_login";
            string url = URL + cmd;
            string data = AABB.EncodeInterweaved(string.Format("{0}:{1}", token, currentversion), gid, secret);
            Dictionary<string, string> fields = new Dictionary<string, string>()
            { { "gid", gid }, /*{ "invite_code", KnightAccountModule.Instance.InviteCode }, { "token", token },*/ { "data", data }
            };
            // StartCoroutine(Connect(new ConnectData(NetType.Post, url, fields, callback)));
            // Debug.Log("url" + url);
            // foreach (var item in fields)
            // {
            //     Debug.Log(item.Key + ":" + item.Value);
            // }
            Request(new ConnectData(NetType.Post, url, fields, callback));
        }
        public enum ErrorType
        {
            Connect,
            Parse,
            ServerLogic,
        }
        void ErrorHandler(
                    ErrorType errorType,
                    string message,
                    LitJson.JsonData resultData,
                    ConnectData connectData)
        {
            if (errorHandler != null)
                errorHandler(errorType, message, resultData, delegate
                {
                    Request(connectData);
                });
        }

        public void SetValue(string gid, LitJson.JsonData json, string reason, System.Action<bool, LitJson.JsonData> callback)
        {
            if (string.IsNullOrEmpty(gid))
            {
                Debug.LogError("Have Not Login");
                return;
            }
            string cmd = "user_set_many";
            string url = URL + cmd;
            string secret = AABB.Secret();
            System.Text.StringBuilder builder = new System.Text.StringBuilder("many|");

            builder.Append(json.ToJson());

            if (!string.IsNullOrEmpty(reason))
                builder.Append("|" + reason);
            // Debug.Log(builder.ToString());
            Dictionary<string, string> fields = new Dictionary<string, string>()
            { { "gid", gid },
                { "data", AABB.EncodeInterweaved(builder.ToString(), gid, secret) }, { "ticket", Ticket }
            };

            Request(new ConnectData(NetType.Post, url, fields, callback), 0, true, builder.ToString());
        }

        void Request(ConnectData connectData, int count = 0, bool needshowprogress = true, string r = "")
        {
            HTTPMethods method = HTTPMethods.Post;
            if (connectData.netType == NetType.Get)
                method = HTTPMethods.Get;
            HTTPRequest httprequest = new HTTPRequest(new Uri(connectData.url), method, delegate (HTTPRequest request, HTTPResponse response)
            {
                if (response == null)
                {
                    if (needshowprogress)
                        ErrorHandler(ErrorType.Connect, request.Exception.HResult + request.Exception.Message, null, connectData);
                }
                else
                {
                    string text = response.DataAsText;
                    byte[] buffer = System.Convert.FromBase64String(text);
                    string secret = AABB.Secret();
                    for (int i = 0; i < buffer.Length; i++)
                        buffer[i] ^= (byte)secret[i % secret.Length];
                    text = System.Text.Encoding.Default.GetString(buffer);
                    // Debug.LogError("ServerReceive:" + text + " SendText:" + r);

                    try
                    {
                        if (connectData.url.Contains("user_get"))
                        {
                            // Debug.Log("change");
                            // Debug.Log(text);
                            text = text.Replace("\\\"\"", "");
                            text = text.Replace("\"\\\"", "");
                            text = text.Replace("\"\"[", "\"[");
                            text = text.Replace("]\"\"", "]\"");
                            // Debug.Log(text);
                            LitJson.JsonData jsonDatasub = LitJson.JsonMapper.ToObject(text);
                            // Debug.Log(jsonDatasub.ToJson());
                        }
                        LitJson.JsonData jsonData = LitJson.JsonMapper.ToObject(text);
                        /* 
                            使用getvalue协议 并且 是json数组[...] 的时候, 
                            返回{"result":1, "value":"[...]"}, 在数组里面没有内容时,会在解析json时候报错(LitJson.JsonMapper.ToObject(text);)
                            如果LitJson.JsonData 对象是一个数组(推测Object同理), 返回jsonData.ToString()会返回"JsonData array",而不会返回具体的值,需要ToJson()
                        */
                        int result = (int)jsonData["result"];
                        if (result > 0)
                        {
                            if (connectData.callback != null)
                                connectData.callback(result > 0, jsonData);
                        }
                        else
                        {
                            if (connectData.callback != null)
                                connectData.callback(result > 0, jsonData);
                            if (result.Equals(-2))
                            {
                                if (count > 0 && count <= CountMax)
                                    StartCoroutine(TimeTools.DelayCallback(PayConfirmTime[count - 1], delegate
                                    {
                                        Request(connectData, count + 1);
                                    }));
                            }
                            else if (result.Equals(-6))
                            {
                                Debug.Log("Network ServerLogic Error: " + result + ":" + jsonData["detail"].ToString() + " url:" + connectData.url);
                                ErrorHandler(ErrorType.ServerLogic, jsonData["detail"].ToString(), jsonData, connectData);
                            }
                            else
                            {

                                Debug.LogError("Network ServerLogic Error: " + result + ":" + jsonData["detail"].ToString() + " url:" + connectData.url);
                                ErrorHandler(ErrorType.ServerLogic, jsonData["detail"].ToString(), jsonData, connectData);
                            }
                        }
                    }
                    catch (System.Exception ex)
                    {
                        Debug.LogError("Network Parse Error: " + text + ":" + ex.Message + " url:" + connectData.url + " line " + ex.StackTrace);
                        ErrorHandler(ErrorType.Parse, ex.Message, null, connectData);
                    }
                }
            });
            if (connectData.fields != null)
            {
                BestHTTP.Forms.HTTPUrlEncodedForm form = new BestHTTP.Forms.HTTPUrlEncodedForm();
                foreach (var item in connectData.fields)
                {
                    form.AddField(item.Key, item.Value);
                }
                httprequest.SetForm(form);
            }
            httprequest.Send();
        }

        public void GetPublicValue(string key, System.Action<bool, LitJson.JsonData> callback)
        {
            string cmd = "user_get";
            string gid = string.Format("{0}@{1}", CommonTools.ChannelID, 0);
            string param = string.Format("?gid={0}&name={1}&ticket={2}", gid, key, "000000");
            string url = URL + cmd + param;
            // Debug.Log("url:" + url);
            Request(new ConnectData(NetType.Get, url, null, callback));
        }

        public void GetValue(string gid, string key, System.Action<bool, LitJson.JsonData> callback)
        {
            if (string.IsNullOrEmpty(gid))
            {
                Debug.LogError("Have Not Login");
                return;
            }
            string cmd = "user_get";
            //string param = string.Format("?gid={0}&name={1}", Gid, key);
            string param = string.Format("?gid={0}&name={1}&ticket={2}", gid, key, Ticket);
            string url = URL + cmd + param;
            // StartCoroutine(Connect(new ConnectData(NetType.Get, url, null, callback)));
            Request(new ConnectData(NetType.Get, url, null, callback));
        }

        public void GetAllValues(string gid, System.Action<bool, LitJson.JsonData> callback)
        {
            if (string.IsNullOrEmpty(gid))
            {
                Debug.LogError("Have Not Login");
                return;
            }
            string cmd = "user_get_all";
            //string param = string.Format("?gid={0}", Gid);
            string param = string.Format("?gid={0}&ticket={1}", gid, Ticket);
            string url = URL + cmd + param;
            Request(new ConnectData(NetType.Get, url, null, callback));
        }

        public void GetServerTime(System.Action<bool, LitJson.JsonData> callback)
        {
            string cmd = "time";
            string url = URL + cmd;
            Request(new ConnectData(NetType.Get, url, null, callback));
        }
    }

}