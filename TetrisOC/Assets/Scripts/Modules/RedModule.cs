using System.Collections.Generic;
using MMFramework;
using UnityEngine;
using LitJson;
using UnityEngine.UI;
namespace MMGame
{
    public interface iRedpoint
    {
        int RedNum();
    }

    public class RedModule : MonoBehaviour, BaseModule
    {
        public static RedModule Instance
        {
            get
            {
                return RootModule.Instance.GetModule<RedModule>();
            }
        }

        // Dictionary<iRedpoint, List<RedTag>> dict;
        Dictionary<string, System.Func<int>> dict;

        public void Init()
        {
            dict = new Dictionary<string, System.Func<int>>();
        }

        public void Regist(string path, System.Func<int> func)
        {
            dict[path] = func;
        }

        public void UnRegist(string path)
        {
            if (dict.ContainsKey(path))
                dict.Remove(path);
        }

        public int GetRedNum(string path)
        {
            int num = 0;
            foreach (var item in dict)
            {
                if (item.Key.StartsWith(path))
                {
                    num += dict[item.Key]();
                }
            }

            return num;
        }
    }
}