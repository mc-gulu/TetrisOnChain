using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace MMFramework
{
    public class RootModule : MonoBehaviour
    {
        /*
         * 
         * Module之间尽量减少引用,以避免循Init之内互相调用
         * 
         * */
        private static RootModule instance;
        private static object syncRoot = new Object();
        public static RootModule Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                        {
                            GameObject instancego = GameObject.Find("RootModule");
                            if (instancego != null)
                            {
                                instancego.transform.SetParent(null);
                                Object.Destroy(instancego);
                            }

                            GameObject go = new GameObject("RootModule");
                            instance = go.AddComponent<RootModule>();
                            instance.Init();
                            Object.DontDestroyOnLoad(go);
                        }
                    }
                }
                return instance;
            }
        }
        Dictionary<System.Type, BaseModule> dict = new Dictionary<System.Type, BaseModule>();
        public T GetModule<T>() where T : MonoBehaviour, BaseModule
        {
            System.Type moduletype = typeof(T);
            T t = null;
            if (!dict.ContainsKey(moduletype))
            {
                GameObject go = new GameObject();
                go.transform.SetParent(transform);
                go.name = typeof(T).Name;
                t = go.AddComponent<T>();
                dict[moduletype] = t;
                t.Init();
            }
            else
            {
                t = dict[moduletype] as T;
            }
            return t;
        }
        public void ClearAllModules()
        {
            dict.Clear();
        }
        void Init()
        {

        }
        public static void DestroyInstance()
        {
            RootModule.Instance.ClearAllModules();
            DestroyImmediate(RootModule.Instance.gameObject);
            instance = null;
            LoginData = string.Empty;
        }
        public static string LoginData { get; set; }
        private float ScaleTimeNum = 1;
        public void PauseAll(bool pause)
        {
            foreach (var kv in dict)
            {
                var v = kv.Value;

                if (v is IAppControl)
                {
                    ((IAppControl)v).OnPause(pause);
                }
            }
            Time.timeScale = pause ? 0f : ScaleTimeNum;
        }
        public void ScaleGame(float scaleNum)
        {
            foreach (var kv in dict)
            {
                var v = kv.Value;

                if (v is IAppControl)
                {
                    ((IAppControl)v).OnTimeScale(scaleNum);
                }
            }
            ScaleTimeNum = scaleNum;
            if (Time.timeScale != 0)
            {
                Time.timeScale = ScaleTimeNum;
            }
        }
        private void OnApplicationPause(bool pause)
        {
            PauseAll(pause);
        }
    }
}