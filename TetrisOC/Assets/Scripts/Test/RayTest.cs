using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MMFramework;
using IFix.Core;
using System.IO;
using BestHTTP.JSON;

namespace MMGame {
    public class RayTest : MonoBehaviour
    {
        void Start()
        {
            string json = "{" +
                "\"title\":\"json在线解析（简版） -JSON在线解析\"," +
                "\"json.url\":\"https://www.sojson.com/simple_json.html\"," +
                "\"keywords\":\"json在线解析\"," +
                "\"type\":[\"JSON美化\",\"JSON数据类型显示\",\"JSON数组显示角标\",\"高亮显示\",\"错误提示\"]," +
                "\"joinus\":{\"qq群\":\"259217951\"}" +
                "}";
            //JsonData jsonData = JsonMapper.ToObject(json);
            //var dict = jsonData as IDictionary<string, object>;
            var dict2 = Json.Decode(json) as Dictionary<string, object>; ;
            Debug.Log(dict2.String("title"));
            var list = dict2.List("type") ;
            foreach (var item in list)
            {
                Debug.Log(item);
            }
            //Debug.Log(Application.persistentDataPath);

            //HotUpdateModule.Instance.CheckAndDownload(()=> 
            //{
            //    CacheModule.Instance.LoadBundle();
            //});
        }

        

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.P))
            {
                TextAsset bytes = CacheModule.Instance.LoadAsset<TextAsset>(PathTools.patchSuffix);
                if (bytes != null)
                {
                    PatchManager.Load(new MemoryStream(bytes.bytes));
                    Debug.Log("patched");
                }

            }

            if (Input.GetKeyDown(KeyCode.T))
            {
                Testfunc();
            }
        }

        private void Testfunc()
        {
            Debug.Log("Before");
        }
    }

}
