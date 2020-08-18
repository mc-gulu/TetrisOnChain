using System.Collections.Generic;
using System.IO;
using UnityEngine;
namespace MMFramework
{
    public class CacheModule : MonoBehaviour, BaseModule
    {
        public static CacheModule Instance
        {
            get
            {
                return RootModule.Instance.GetModule<CacheModule>();
            }
        }

        Dictionary<string, UnityEngine.Object> resourcesdict;
        private AssetBundle bundle;

        public void Init()
        {
            resourcesdict = new Dictionary<string, UnityEngine.Object>();
        }

        public UnityEngine.Object Load(string pathfile)
        {
            if (!resourcesdict.ContainsKey(pathfile))
            {
                resourcesdict[pathfile] = Resources.Load(pathfile);
            }
            if (resourcesdict[pathfile] == null)
                Debug.LogError(pathfile + "未找到");
            return resourcesdict[pathfile];
        }
        public T Load<T>(string pathfile) where T : UnityEngine.Object
        {
            try
            {
                T t = null;
                if (resourcesdict.ContainsKey(pathfile))
                {
                    t = resourcesdict[pathfile] as T;
                }
                else
                {
                    T tmp = Resources.Load<T>(pathfile);
                    if (tmp != null)
                    {
                        t = tmp;
                        resourcesdict[pathfile] = t;
                    }
                    else
                    {
                        string name = Path.GetFileName(pathfile);
                        string path = pathfile.Substring(0, pathfile.Length - name.Length - 1);
                        var images = Resources.LoadAll<Sprite>(path);
                        for (int i = 0; i < images.Length; i++)
                        {
                            string key = path + "/" + images[i].name;
                            resourcesdict[key] = images[i];
                        }
                        t = resourcesdict[pathfile] as T;
                    }

                }
                if (t == null)
                    Debug.LogError(pathfile + "未找到");

                return t;
            }
            catch (System.Exception)
            {
                Debug.LogError(pathfile + "未找到");
                // throw;
                return null;
            }
        }
        public Sprite LoadSprite(string pathfilePath)
        {
            if (string.IsNullOrEmpty(pathfilePath)) return null;
            var last = pathfilePath.LastIndexOf('/');
            return LoadSprite(pathfilePath.Substring(0, last), pathfilePath.Substring(last + 1));
        }

        public Sprite LoadSprite(string pathfile, string spriteName)
        {
            if (!resourcesdict.ContainsKey(pathfile + "/" + spriteName))
            {
                var images = Resources.LoadAll<Sprite>(pathfile);
                for (int i = 0; i < images.Length; i++)
                {
                    string key = pathfile + "/" + images[i].name;
                    resourcesdict[key] = images[i];
                }
            }
            if (resourcesdict.ContainsKey(pathfile + "/" + spriteName))
                return resourcesdict[pathfile + "/" + spriteName] as Sprite;
            else
                return null;
        }

        public void LoadBundle(string path)
        {
            if (File.Exists(path))
            {
                Debug.Log("存在本地当前路径资源包");
                bundle = AssetBundle.LoadFromFile(path);
            }
            Debug.Log("资源包加载完毕");
        }

        public T LoadAsset<T>(string assetName) where T : UnityEngine.Object
        {
            T asset = default;
            if (!bundle) return asset;
            if (!bundle.Contains(assetName)) return asset;

            asset = bundle.LoadAsset(assetName) as T;
            return asset;
        }
    }
}