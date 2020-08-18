using System.Collections.Generic;
using MMFramework;
using UnityEngine;
using LitJson;
using System;
using System.Linq;

namespace MMGame
{

    public class DataModule : MonoBehaviour, BaseModule
    {
        //用户持久变量
        public const string Key_Diamond = "Idiamond";
        public const string Key_Gold = "Sgold";
        public const string Key_Exp = "Iexp";
        public const string Key_battery = "Ibattery";
        public const string Key_batteryend = "Ibatteryend";
        public const string Key_mainlv = "Imainlv";
        public const string Key_cache_sync_timestamp = "Lsynctime";
        public const string Key_HeroDic = "Oherodic";
        public const string Key_Team = "OTeam";
        public const string Key_MailRead = "OMailRead";
        public const string Key_MailDelete = "OMailDelete";
        public const string Key_OfflineList = "Oofflinelist";
        public const string Key_OfflineTime = "Lofflinetime";
        public const string Key_EverydayLastTickN = "LeverydaycountLasttick";
        public const string Key_EverydayLeftN = "Ieverydaycountleft";
        public const string Key_CountdownLastN = "Lcountdown_timestemp";
        public const string Key_CheckinN = "ICheckin";
        public const string Key_LastDay = "ILastday";
        public const string Key_LoginDays = "ILogindays";
        public const string Key_ContinueLoginDays = "IContinueLogindays";
        public const string Key_HeroListMax = "IHeroListMax";

        public const string Key_GetGoldTime = "Lgetgoldtime";
        public const string Key_BatteryStartTime = "Lbatterystarttime";
        public const string Key_FirstGetHero = "Ofirstgethero";
        public const string Key_AutoHeroTeamUp = "IAutoHeroTeamUp";

        //临时加密变量
        public const string Key_GoldCache = "Sgoldcache";
        public const string Key_ExpCache = "Iexpcache";
        public const string Key_Timestamp = "Ltimestamp";
        public const string Key_PrivateMaillist = "OPrivateMail";
        public const string Key_PublicMaillist = "OPublicMail";

        List<System.Enum> event_changed_notice = new List<Enum>();

        public static DataModule Instance
        {
            get
            {
                return RootModule.Instance.GetModule<DataModule>();
            }
        }

        public string Gid { get; set; }

        public List<Mail> GetMails()
        {
            return null;
        }

        public System.Numerics.BigInteger Gold
        {
            get
            {
                return System.Numerics.BigInteger.Parse(Get(Key_Gold, "0")) + GoldCache;
            }
            set
            {
                Set(Key_Gold, value.ToString());
                Set(Key_GoldCache, "0", false);
                AddEvent(NoticeEnum.GOLD);
            }
        }

        public System.Numerics.BigInteger GoldCache
        {
            get
            {
                return System.Numerics.BigInteger.Parse(Get(Key_GoldCache, "0", false));
            }
            set
            {
                Set(Key_GoldCache, value.ToString(), false);
                NoticeTool.Broadcast(NoticeEnum.GOLD);
            }
        }

        public List<ItemObj> OfflineItems
        {
            get
            {
                return Get(Key_OfflineList, new List<ItemObj>());
            }
            set
            {
                Set(Key_OfflineList, value);
            }
        }

        public static string CombineKey(string key, int index)
        {
            return string.Format("{0}{1}", key, index);
        }
        public bool AutoHeroTeamUp 
        {
            get 
            {
                return Get(Key_AutoHeroTeamUp, 1) == 1;
            }
            set 
            {
                Set(Key_AutoHeroTeamUp, value ? 1 : 0);
            }
        }
        public int Exp
        {
            get
            {
                return Get(Key_Exp, 0, true) + Get(Key_ExpCache, 0, false);
            }
            set
            {
                Set(Key_Exp, value, true);
                Set(Key_ExpCache, 0, false);
                AddEvent(NoticeEnum.Exp);
            }
        }

        public int ExpCache
        {
            get
            {
                return Get(Key_ExpCache, 0, false);
            }
            set
            {
                Set(Key_ExpCache, value, false);

            }
        }

        public int Diamond
        {
            get
            {
                int v = Get(Key_Diamond, 0);
                // Debug.Log("Get" + v);
                return v;
            }
            set
            {
                // Debug.Log("Set" + value);
                Set(Key_Diamond, value);
                AddEvent(NoticeEnum.DIAMOND);
            }
        }

        public int MainLv
        {
            get
            {
                return Get<int>(Key_mainlv, 1);
            }
            set
            {
                Set<int>(Key_mainlv, value);
                AddEvent(NoticeEnum.MAINLV_UPDATE);
            }
        }

        public int Battery
        {
            get
            {
                return Get(Key_battery, 0);
            }
            set
            {
                // Debug.LogError("Battery:" + value);
                Set(Key_battery, value);
                AddEvent(NoticeEnum.BATTERY);
            }
        }
        public List<int> FirstGetHeroList 
        {
            get { return Get(Key_FirstGetHero, new List<int>()); }
            set { Set(Key_FirstGetHero, value); }
        }
        public int HeroListMax
        {
            get
            {
                return Get(Key_HeroListMax, 100);
            }
            set
            {
                Set(Key_HeroListMax, value);
            }
        }
        public List<int> GetTeamList()
        {
            var tmp = Get(Key_Team, CommonTools.DefList<int>(4));
            var list = GetHeroDataDic().Keys.ToList();
            for (int i = 0; i < tmp.Count; i++)
            {
                if (list.Contains(tmp[i].ToString())) continue;
                tmp[i] = 0;
            }
            return tmp;
        }
        //获取当前队伍data列表
        public List<RealHeroData> GetTeamListData()
        {
            List<int> rids = GetTeamList();
            var hlist = new List<RealHeroData>();
            for (int i = 0; i < rids.Count; i++)
            {
                if (rids[i] != 0)
                    hlist.Add(GetHeroData(rids[i]));
                else
                    hlist.Add(null);
            }
            return hlist;
        }
        public RealHeroData GetHeroData(int id)
        {
            var idstr = id.ToString();
            return Get<RealHeroData>(HeroDataStr(id), null);
        }
        public string HeroDataStr(int id)
        {
            return string.Format("{0}/{1}", Key_HeroDic, id);
        }
        /// <summary>
        /// 升星页面排序
        /// </summary>
        /// <returns></returns>
        public Dictionary<string, RealHeroData> GetHeroDataDicOrder2()
        {
            var tmpdic = GetHeroDataDic();
            var updic = new Dictionary<string, RealHeroData>();
            var unupdic = new Dictionary<string, RealHeroData>();
            var tagdic = new Dictionary<string, int>();
            var starNums = new Dictionary<string, int>();
            foreach (var item in tmpdic)
            {
                var rdata = item.Value;
                if (rdata.star % 2 == 0)//同角色
                {
                    if (!starNums.ContainsKey(rdata.creatureid + "_" + rdata.star))
                        starNums.Add(rdata.creatureid + "_" + rdata.star, CreatureStarUpData.GetData(rdata.star).CostNum);

                    if (!tagdic.ContainsKey(rdata.creatureid + "_" + rdata.star))
                        tagdic.Add(rdata.creatureid + "_" + rdata.star, 1);
                    else
                        tagdic[rdata.creatureid + "_" + rdata.star] += 1;
                }
                else
                {
                    if (!starNums.ContainsKey(rdata.ele + "_" + rdata.star))
                        starNums.Add(rdata.ele + "_" + rdata.star, CreatureStarUpData.GetData(rdata.star).CostNum);

                    if (!tagdic.ContainsKey(rdata.ele + "_" + rdata.star))
                        tagdic.Add(rdata.ele + "_" + rdata.star, 1);
                    else
                        tagdic[rdata.ele + "_" + rdata.star] += 1;
                }
            }
            foreach (var item in tmpdic)
            {
                var rdata = item.Value;
                if (rdata.star % 2 == 0)//同角色
                {
                    if (tagdic[rdata.creatureid + "_" + rdata.star] >= starNums[rdata.creatureid + "_" + rdata.star] + 1)
                        updic.Add(item.Key, item.Value);
                    else
                    {
                        unupdic.Add(item.Key, item.Value);
                    }
                }
                else
                {
                    if (tagdic[rdata.ele + "_" + rdata.star] >= starNums[rdata.ele + "_" + rdata.star] + 1)
                        updic.Add(item.Key, item.Value);
                    else
                    {
                        unupdic.Add(item.Key, item.Value);
                    }
                }
            }
            updic = updic.OrderByDescending(kv => kv.Value.star)
                .ThenBy(kv => kv.Value.ele)
                .ThenBy(kv => kv.Value.creatureid)
                .ThenByDescending(kv => kv.Value.lv)
                .ThenBy(kv => kv.Value.career)
                .ToDictionary(k => k.Key, v => v.Value);
            foreach (var item in unupdic)
            {
                updic.Add(item.Key, item.Value);
            }
            return updic;
        }
        /// <summary>
        /// 英雄列表页面和上阵页面排序
        /// </summary>
        /// <returns></returns>
        public Dictionary<string, RealHeroData> GetHeroDataDicOrder1()
        {
            return GetHeroDataDic()
                .OrderByDescending(kv => kv.Value.lv)
                .ThenByDescending(kv => kv.Value.star)
                .ThenBy(kv => kv.Value.career)
                .ThenBy(kv => kv.Value.creatureid)
                .ThenBy(kv => kv.Value.ele)
                .ToDictionary(k => k.Key, v => v.Value);
        }
        public Dictionary<string, RealHeroData> GetHeroDataDic()
        {
            return Get(Key_HeroDic, new Dictionary<string, RealHeroData>());
        }
        public void SetHeroDataDic(Dictionary<string, RealHeroData> dict)
        {
            Set(Key_HeroDic, dict);
        }
        JsonData temp_json;
        string temp_md5;

        JsonData serversave_json;
        string serversave_md5;
        List<string> serversave_dirtykeys;

        public void Init()
        {
            temp_json = new JsonData();
            temp_json.SetJsonType(JsonType.Object);

            serversave_json = new JsonData();
            serversave_dirtykeys = new List<string>();
        }

        public void SetRoot(string rootjsonstr)
        {
            Debug.Log("root:" + rootjsonstr);
            serversave_json = JsonMapper.ToObject(rootjsonstr);
            List<string> keys = new List<string>(serversave_json.Keys);
            for (int i = 0; i < keys.Count; i++)
            {
                string key = keys[i];
                //对象
                //数组
                //Int
                //Float，Double
                //Bool
                //String
                string valuestr = serversave_json[key].ToString();
                if (key.StartsWith("O"))
                {
                    JsonData jsondata = LitJson.JsonMapper.ToObject(valuestr);
                    serversave_json[key] = jsondata;
                }
                else if (key.StartsWith("A"))
                {
                    JsonData jsondata = LitJson.JsonMapper.ToObject(valuestr);
                    serversave_json[key] = jsondata;
                }
                else if (key.StartsWith("I"))
                {
                    JsonData jsondata = new JsonData(Convert.ToInt32(valuestr));
                    serversave_json[key] = jsondata;
                }
                else if (key.StartsWith("L"))
                {
                    JsonData jsondata = new JsonData(Convert.ToInt64(valuestr));
                    serversave_json[key] = jsondata;
                }
                else if (key.StartsWith("D"))
                {
                    JsonData jsondata = new JsonData(Convert.ToDouble(valuestr));
                    serversave_json[key] = jsondata;
                }
                else if (key.StartsWith("B"))
                {
                    JsonData jsondata = new JsonData(Convert.ToBoolean(valuestr));
                    serversave_json[key] = jsondata;
                }
                else if (key.StartsWith("S"))
                {
                    JsonData jsondata = new JsonData(valuestr);
                    serversave_json[key] = jsondata;
                }
                else
                {
                    Debug.Log("未解析" + key);
                }
            }

            temp_json.Clear();

            //写入数据和验证
            GenerateMd5();
            GenerateMd5(false);
        }

        public void SyncData(string reason, System.Action<bool, JsonData> callback)
        {
            GenerateMd5();
            GenerateMd5(false);
            if (serversave_dirtykeys.Count > 0)
            {
                JsonData json = new JsonData();
                for (int i = 0; i < serversave_dirtykeys.Count; i++)
                {
                    string key = serversave_dirtykeys[i];
                    JsonData jsonData = serversave_json.GetJsonData(key);
                    if (jsonData.IsString)
                        json[key] = jsonData.ToString();
                    else
                        json[key] = serversave_json.GetJsonData(key).ToJson();

                }
                serversave_dirtykeys.Clear();
                ServerModule.Instance.SetValue(Gid, json, reason, callback);
            }
            else
            {
                JsonData json = new JsonData();
                json.SetJsonType(JsonType.Object);
                json["result"] = 1;
                callback(true, json);
            }
        }

        public void Set<T>(string key, T value, bool isserver = true)
        {
            if (isserver)
            {
                serversave_json.Set(key, value);
                var dirtykey = key.Split('/')[0];
                if (!serversave_dirtykeys.Contains(dirtykey))
                {
                    serversave_dirtykeys.Add(dirtykey);
                }
            }
            else
            {
                temp_json.Set(key, value);
            }
        }

        public T Get<T>(string key, T def, bool isserver = true)
        {
            if (!Have(key, isserver))
                return def;
            JsonData json = isserver ? serversave_json : temp_json;
            JsonData jsondata = json.GetJsonData(key);
            if (jsondata != null)
            {
                return jsondata.Convert<T>();
            }
            else
                return def;
        }

        public bool Have(string key, bool isserver = true)
        {
            JsonData json = isserver ? serversave_json : temp_json;
            return json.GetJsonData(key) != null;
        }

        public bool Verify(bool isserver = true)
        {
            if (isserver)
            {
                string newmd5 = AABB.GetMD5Verify(serversave_json.ToJson(), Gid);
                return serversave_md5.Equals(newmd5);
            }
            else
            {
                string newmd5 = AABB.GetMD5Verify(temp_json.ToJson(), Gid);
                return temp_md5.Equals(newmd5);
            }
        }

        public void GenerateMd5(bool isserver = true)
        {
            if (isserver)
            {
                serversave_md5 = AABB.GetMD5Verify(serversave_json.ToJson(), Gid);
            }
            else
                temp_md5 = AABB.GetMD5Verify(temp_json.ToJson(), Gid);
        }

        void AddEvent(System.Enum noticeenum)
        {
            // Debug.LogError("AddEvent" + noticeenum);
            if (!event_changed_notice.Contains(noticeenum))
            {
                event_changed_notice.Add(noticeenum);
            }
        }

        public void ApplyValueChangedToUI()
        {
            // Debug.Log("Start " + event_changed_notice.Count);
            //ERROR 在广播消息的时候，可能会添加新的消息，倒序删除，不影响新加(倒序会因为原有消息与新加消息重复导致添加不进来，不行)
            // for (int i = event_changed_notice.Count - 1; i >= 0; i--)
            // {
            //     System.Enum noticeenum = event_changed_notice[i];
            //     NoticeTool.Broadcast(noticeenum);
            //     event_changed_notice.RemoveAt(i);
            // }

            //使用临时list，以便在处理小的时候，添加新消息到list里
            List<System.Enum> tempeventlist = new List<Enum>();
            for (int i = 0; i < event_changed_notice.Count; i++)
            {
                tempeventlist.Add(event_changed_notice[i]);
            }
            event_changed_notice.Clear();

            for (int i = 0; i < tempeventlist.Count; i++)
            {
                System.Enum noticeenum = tempeventlist[i];
                NoticeTool.Broadcast(noticeenum);
            }
            // Debug.Log("Finish " + event_changed_notice.Count);
        }
    }
}