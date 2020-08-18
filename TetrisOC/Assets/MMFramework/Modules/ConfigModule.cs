using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MMFramework;
namespace MMGame
{
    public class OneKeyStruct
    {
        public string QQGroupUin;
        public string QQGroupiOSKey;
        public string QQGroupAndroidKey;
        public bool Show;
    }
    public class ConfigModule : MonoBehaviour, BaseModule
    {
        public static ConfigModule Instance
        {
            get
            {
                return RootModule.Instance.GetModule<ConfigModule>();
            }
        }

        public OneKeyStruct OneKey { get; set; }
        public string MinVersion { get; set; }
        public int TimeZoneOffset = 8;
        public string MainCityPrefab_suffix { get; set; }
        public string NowVersion { get; set; }
        public bool Inited { get; set; }
        public int FirstBuyReset { get; set; }
        public void Init()
        {

        }

        public bool SetData(LitJson.JsonData jsonData)
        {
            try
            {
                OneKey = new OneKeyStruct();
                OneKey.QQGroupUin = jsonData["data"]["uin"].ToString();
                OneKey.QQGroupiOSKey = jsonData["data"]["ioskey"].ToString();
                OneKey.QQGroupAndroidKey = jsonData["data"]["androidkey"].ToString();
                string key = "showaddgroup";
                if (jsonData["data"].ContainsKey(key) && (bool)jsonData["data"][key])
                    OneKey.Show = true;
                else
                    OneKey.Show = false;

                if (jsonData["data"].ContainsKey("timezoneoffset"))
                    TimeZoneOffset = (int)jsonData["data"]["timezoneoffset"];

                MinVersion = jsonData["data"]["minversion"].ToString();

                if (jsonData["data"].ContainsKey("nowversion"))
                    NowVersion = jsonData["data"]["nowversion"].ToString();
                else
                    NowVersion = Application.version;

                if (jsonData["data"].ContainsKey("FirstBuyReset"))
                    FirstBuyReset = (int)jsonData["data"]["FirstBuyReset"];
                else
                    FirstBuyReset = 0;



                Inited = true;
                return true;
            }
            catch (System.Exception ex)
            {
                OneKey = null;
                return false;
            }
        }
    }
}