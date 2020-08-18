using System.Collections;
using System.Collections.Generic;
using MMFramework;
using UnityEngine;
namespace MMGame
{
    public class BulletPool : MonoBehaviour, BaseModule
    {
        public Dictionary<int, List<GameObject>> Objects = new Dictionary<int, List<GameObject>>();
        Dictionary<int, int> usedict = new Dictionary<int, int>();

        public static BulletPool Instance
        {
            get
            {
                return RootModule.Instance.GetModule<BulletPool>();
            }
        }

        public void Init()
        {

        }

        public void Clear()
        {
            for (int i = transform.childCount - 1; i >= 0; i--)
            {
                Transform item = transform.GetChild(i);

                item.SetParent(null);
                Object.DestroyImmediate(item.gameObject);

            }
            Objects.Clear();
            usedict.Clear();
        }

        public void ClearUnused()
        {
            for (int i = transform.childCount - 1; i >= 0; i--)
            {
                Transform item = transform.GetChild(i);
                int objID = item.gameObject.GetInstanceID();

                if (usedict.ContainsKey(objID) && usedict[objID] > 2)
                {
                    //使用频繁的，保留
                }
                else
                {
                    int bulletID = item.GetComponent<Bullet>().BulletID;

                    if (Objects.ContainsKey(bulletID) && Objects[bulletID].Contains(item.gameObject))
                    {
                        Objects[bulletID].Remove(item.gameObject);
                    }

                    item.SetParent(null);
                    Object.DestroyImmediate(item.gameObject);
                }
            }

            usedict.Clear();
        }

        public void Preload(int bulletID, int num)
        {
            List<GameObject> arr = null;

            if (!this.Objects.TryGetValue(bulletID, out arr))
            {
                this.Objects[bulletID] = new List<GameObject>();
                arr = this.Objects[bulletID];
            }

            int deltanum = num - arr.Count;
            if (deltanum > 0)
            {
                for (int i = 0; i < deltanum; i++)
                {
                    string prefab_pathname = BulletData.GetData(bulletID).Prefab;
                    GameObject newlyCreated = ObjTools.CreatePrefab(transform, prefab_pathname);
                    newlyCreated.GetComponent<BulletTest>().GenerateBullet();
                    Bullet bullet = newlyCreated.GetComponent<Bullet>();
                    bullet.LoadArmature(bulletID);
                    bullet.gameObject.SetActive(false);
                    this.Objects[bulletID].Add(newlyCreated);
                    newlyCreated.name = bulletID.ToString();
                }
            }
        }

        public void Recycle(int bulletID, GameObject go)
        {
            List<GameObject> arr = null;
            if (!this.Objects.TryGetValue(bulletID, out arr))
            {
                arr = new List<GameObject>();
                this.Objects[bulletID] = arr;
            }
            arr.Add(go);
            go.SetActive(false);
            go.transform.SetParent(transform);
            go.name = bulletID.ToString();
        }

        public GameObject Spawn(Transform parentTrans, int bulletID)
        {
            List<GameObject> arr = null;
            if (this.Objects.TryGetValue(bulletID, out arr))
            {
                if (arr.Count > 0)
                {
                    GameObject go = arr[arr.Count - 1];
                    arr.RemoveAt(arr.Count - 1);
                    go.transform.parent = parentTrans;
                    go.SetActive(true);

                    Used(go);

                    return go;
                }
            }
            else
            {
                this.Objects[bulletID] = new List<GameObject>();
            }

            // 这里是真正需要创建新对象的时候
            string prefab_pathname = BulletData.GetData(bulletID).Prefab;
            GameObject newlyCreated = ObjTools.CreatePrefab(parentTrans, prefab_pathname);
            newlyCreated.GetComponent<BulletTest>().GenerateBullet();
            Bullet bullet = newlyCreated.GetComponent<Bullet>();
            bullet.LoadArmature(bulletID);

            Used(newlyCreated);

            //this.Objects[bulletID].Add(newlyCreated);
            return newlyCreated;
        }

        void Used(GameObject go)
        {
            int objID = go.GetInstanceID();
            if (usedict.ContainsKey(objID))
            {
                usedict[objID]++;
            }
            else
            {
                usedict[objID] = 1;
            }
        }
    }
}