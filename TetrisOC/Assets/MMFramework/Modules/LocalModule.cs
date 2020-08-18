using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MMFramework
{
    public class LocalModule : MonoBehaviour, BaseModule
    {
        public static LocalModule Instance
        {
            get
            {
                return RootModule.Instance.GetModule<LocalModule>();
            }
        }

        private Dictionary<string, string> dic = new Dictionary<string, string>();
        /// <summary>  
        /// 读取配置文件，将文件信息保存到字典里  
        /// </summary>  

        public void Init()
        {
            List<string> keys = LanguageData.GetKeys();
            for (int i = 0; i < keys.Count; i++)
            {
                LanguageData lan = LanguageData.GetData(keys[i]);
                string val;
                if (Application.systemLanguage == SystemLanguage.Chinese || Application.systemLanguage == SystemLanguage.ChineseSimplified)
                    val = lan.chinese;
                else if (Application.systemLanguage == SystemLanguage.English)
                    val = lan.english;
                else if (Application.systemLanguage == SystemLanguage.ChineseTraditional)
                    val = lan.traditionalchinese;
                else
                    val = lan.english;

                // if (ConfigInGame.ForceChinese)
                // {
                //     val = lan.chinese;
                // }

                dic[keys[i]] = val;
            }

            TextEx.TranslateCall = Local;
        }

        /// <summary>  
        /// 获取value  
        /// </summary>  
        /// <param name="key"></param>  
        /// <returns></returns>

        public static string Local(string key, string def)
        {
            return RootModule.Instance.GetModule<LocalModule>().GetValue(key, def);
        }

        public string GetValue(string key, string def = null)
        {
            if (!dic.ContainsKey(key))
            {
                return (def == null) ? key : def;
            }
            string value = null;
            dic.TryGetValue(key, out value);
            return value;
        }
    }
}