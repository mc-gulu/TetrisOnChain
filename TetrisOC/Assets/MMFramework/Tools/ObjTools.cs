using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
namespace MMFramework
{
    public static class ObjTools
    {
        public static GameObject CreatePrefab(Transform parent, string pathName)
        {
            UnityEngine.Object obj = CacheModule.Instance.Load(pathName);
            if (obj != null)
            {
                GameObject prefabgo = (GameObject)UnityEngine.Object.Instantiate(obj);
                if (parent)
                    prefabgo.transform.SetParent(parent);
                prefabgo.transform.localPosition = Vector3.zero;
                prefabgo.transform.localScale = Vector3.one;
                return prefabgo;
            }
            else
            {
                Debug.LogError("未发现Prefab" + pathName);
                return null;
            }
        }
        //同类深拷贝
        public static T DeepCopy<T>(T obj)
        {
            T t;
            MemoryStream memoryStream = new MemoryStream();
            BinaryFormatter formatter = new BinaryFormatter();
            formatter.Serialize(memoryStream, obj);
            memoryStream.Position = 0;
            t = (T)formatter.Deserialize(memoryStream);
            return t;
        }

        /// 查找子物体（递归查找）  
        /// </summary> 
        /// <param name="trans">父物体</param>
        /// <param name="goName">子物体的名称</param>
        /// <returns>找到的相应子物体</returns>
        public static Transform FindChild(Transform trans, string name)
        {
            Transform child = trans.Find(name);
            if (child != null)
                return child;

            Transform go = null;
            for (int i = 0; i < trans.childCount; i++)
            {
                child = trans.GetChild(i);
                go = FindChild(child, name);
                if (go != null)
                    return go;
            }
            return null;
        }

        public static void CopyValues<T>(T from, T to)
        {
            var json = JsonUtility.ToJson(from);
            JsonUtility.FromJsonOverwrite(json, to);
        }
        public static void ClearChild(Transform transform)
        {
            for (int i = transform.childCount - 1; i > -1; i--)
            {
                Object.Destroy(transform.GetChild(i).gameObject);
            }
        }

        public static GameObject CopyGameObject(GameObject parent, GameObject template)
        {
            GameObject go = GameObject.Instantiate(template) as GameObject;

#if UNITY_EDITOR && !UNITY_3_5 && !UNITY_4_0 && !UNITY_4_1 && !UNITY_4_2
            UnityEditor.Undo.RegisterCreatedObjectUndo(go, "Create Object");
#endif
            if (go != null && parent != null)
            {
                Transform t = go.transform;
                t.SetParent(parent.transform);
                t.localPosition = template.transform.localPosition;
                t.localRotation = template.transform.localRotation;
                t.localScale = template.transform.localScale;
                go.layer = parent.layer;
            }
            return go;
        }

        public static Vector3 Worldpos2UIpos(Vector3 worldpos)
        {
            Vector3 ScreenPos = Camera.main.WorldToScreenPoint(worldpos);
            return ScreenPos;
        }
    }
}