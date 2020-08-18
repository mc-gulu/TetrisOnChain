using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using System;
namespace MMFramework
{
    public static class CommonTools
    {
        const int DivideNum = 10;
        const string DIDKey = "DeviceID";
        public static string DeviceID
        {
            get
            {
                if (!PlayerPrefs.HasKey(DIDKey))
                {
                    long utcnowlong = DateTime.UtcNow.Ticks % 1000000;
                    long randomlong = RandomTools.GetRandomInt(0, 1000) * 1000000;
                    // Debug.Log(utcnowlong.ToString() + "==" + randomlong.ToString());
                    long deviceid = utcnowlong + randomlong;
                    PlayerPrefs.SetString(DIDKey, deviceid.ToString());
                }
                string did = PlayerPrefs.GetString(DIDKey);
                return did;
            }
        }

        public static int ChannelID
        {
            get
            {
                return ChannelConfigs.ChannelID;
            }
        }

        public static string Gid
        {
            get
            {
                return string.Format("{0}@{1}", ChannelID, DeviceID);
            }
        }

        public static int GetDistrict()
        {
            string[] parts = DeviceID.Split('@');
            string val = parts[parts.Length - 1];

            return System.Convert.ToInt32(long.Parse(val) / 10 % (long)DivideNum);
        }

        public static string GetGameVersion()
        {
            Xint a = new Xint(SDK_Configs.a);
            Xint b = new Xint(SDK_Configs.b);
            Xint c = new Xint(SDK_Configs.c);
            string currentversion = a.ToString() + "." + b.ToString() + "." + c.ToString();
            return currentversion;
        }

        public static bool IsExpired(string myversion, string minversion)
        {
            System.Version my = new System.Version(myversion);
            System.Version min = new System.Version(minversion);

            return my < min;
        }

        public static bool IsList(this Type type)
        {
            return type.IsGenericType && type.GetGenericTypeDefinition() == typeof(List<>);
        }

        public static bool IsDictionary(this Type type)
        {
            return type.IsGenericType && type.GetGenericTypeDefinition() == typeof(Dictionary<,>);
        }

        public static T Get<T>(this LitJson.JsonData json, string key, T def)
        {
            LitJson.JsonData jsondata = json.GetJsonData(key);
            if (jsondata != null)
                return jsondata.Convert<T>();
            else
                return def;
        }

        public static T Convert<T>(this LitJson.JsonData jsonData)
        {
            if (typeof(T).Equals(typeof(int)))
                return (T)(object)(int)jsonData;
            else if (typeof(T).Equals(typeof(double)))
                return (T)(object)(double)jsonData;
            else if (typeof(T).Equals(typeof(float)))
                return (T)(object)(System.Convert.ToSingle((double)jsonData));
            else if (typeof(T).Equals(typeof(bool)))
                return (T)(object)(bool)jsonData;
            else if (typeof(T).Equals(typeof(string)))
                return (T)(object)(string)jsonData;
            else if (typeof(T).Equals(typeof(long)))
                return (T)(object)(long)jsonData;
            else if (typeof(T).IsList())
                return LitJson.JsonMapper.ToObject<T>(jsonData.ToJson());
            else if (typeof(T).IsDictionary())
                return LitJson.JsonMapper.ToObject<T>(jsonData.ToJson());
            else if (typeof(T).IsClass)
                return LitJson.JsonMapper.ToObject<T>(jsonData.ToJson());
            else
                return default(T);
        }

        public static LitJson.JsonData GetJsonData(this LitJson.JsonData json, string key)
        {
            LitJson.JsonData retjson = json;
            string[] keys = key.Split('/');
            for (int i = 0; i < keys.Length; i++)
            {
                bool isarray = retjson.IsArray;
                string ikey = keys[i];
                int index;
                if (isarray && int.TryParse(ikey, out index) && retjson.Count > index)
                {
                    retjson = retjson[index];
                }
                else if (!isarray && retjson.ContainsKey(ikey))
                {
                    retjson = retjson[ikey];
                }
                else
                {
                    retjson = null;
                    break;
                }
            }
            return retjson;
        }

        public static void Set<T>(this LitJson.JsonData json, string key, T value)
        {
            LitJson.JsonData jsondata;
            if (typeof(T).Equals(typeof(int))
            || typeof(T).Equals(typeof(double))
            || typeof(T).Equals(typeof(bool))
            || typeof(T).Equals(typeof(string))
            || typeof(T).Equals(typeof(long)))
            {
                jsondata = new LitJson.JsonData(value);
            }
            else if (typeof(T).Equals(typeof(float)))
            {
                jsondata = new LitJson.JsonData(System.Convert.ToDouble(value));
            }
            else
            {
                string jsonstr = LitJson.JsonMapper.ToJson(value);
                jsondata = LitJson.JsonMapper.ToObject(jsonstr);
            }

            SetJsonData(json, key, jsondata);
        }

        public static void SetJsonData(this LitJson.JsonData json, string key, LitJson.JsonData jsonvalue)
        {
            LitJson.JsonData retjson = json;
            string[] keys = key.Split('/');
            for (int i = 0; i < keys.Length - 1; i++)
            {
                bool isarray = retjson.IsArray;
                string ikey = keys[i];
                int index;
                if (isarray && int.TryParse(ikey, out index) && retjson.Count > index)
                {
                    retjson = retjson[index];
                }
                else if (!isarray && retjson.ContainsKey(ikey))
                {
                    retjson = retjson[ikey];
                }
                else
                {
                    if (!isarray && !int.TryParse(ikey, out index))
                    {
                        retjson.SetJsonType(LitJson.JsonType.Object);
                        retjson.SetJsonData(ikey, new LitJson.JsonData());
                        retjson = retjson[ikey];
                        // retjson[ikey] = new LitJson.JsonData();
                    }
                    else
                    {
                        retjson = null;
                        break;
                    }
                }
            }

            if (retjson != null)
            {
                bool isarray = retjson.IsArray;
                int keyindex = keys.Length - 1;
                string ikey = keys[keyindex];
                if (isarray)
                {
                    int index = int.Parse(ikey);
                    retjson[index] = jsonvalue;
                }
                else
                {
                    retjson[ikey] = jsonvalue;
                    // Debug.Log(ikey + ":" + jsonvalue.ToJson());
                }
            }
            else
            {
                Debug.Log("数据不存在");
            }
        }
        public static string RelativePath(string basepath, string path)
        {
            Uri u1 = new Uri(basepath, UriKind.Absolute);
            Uri u2 = new Uri(path, UriKind.Absolute);
            Uri u3 = u1.MakeRelativeUri(u2); //u2相对于u1的uri
                                             //Debug.LogError("Path:" + u3.ToString());
            return u3.ToString();
        }

        public static List<T> DefList<T>(int Count, T def = default)
        {
            var list = new List<T>();
            for (int i = 0; i < Count; i++)
            {
                list.Add(def);
            }
            return list;
        }
    }
}