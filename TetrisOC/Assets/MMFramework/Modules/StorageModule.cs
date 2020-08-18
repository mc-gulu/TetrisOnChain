using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace MMFramework
{
    public class StorageModule : MonoBehaviour, BaseModule
    {

        Dictionary<StorageKey, int> datas = new Dictionary<StorageKey, int>();

        public void Init()
        {

        }

        int Get(StorageKey key, int def)
        {
            if (datas.ContainsKey(key))
                return datas[key];
            else
            {
                string ValueName = key.ToString();
                if (DataTools.HasStruct(ValueName))
                {
                    datas[key] = DataTools.LoadStruct<int>(ValueName);
                    return datas[key];
                }
                else
                    return def;
            }
        }

        void Set(StorageKey key, int v)
        {
            datas[key] = v;
            string ValueName = key.ToString();
            DataTools.SaveStruct(ValueName, datas[key]);
        }

        void Remove(StorageKey key)
        {
            if (datas.ContainsKey(key))
                datas.Remove(key);
            RemoveStorage(key);
        }

        public static int LoadInt(StorageKey key, int def) //删除时也要考虑
        {
            return RootModule.Instance.GetModule<StorageModule>().Get(key, def);
        }

        public static void SaveInt(StorageKey key, int v)
        {
            RootModule.Instance.GetModule<StorageModule>().Set(key, v);
        }

        public static void RemoveInt(StorageKey key)
        {
            RootModule.Instance.GetModule<StorageModule>().Remove(key);
        }

        public static void SaveStruct<T>(StorageKey key, T data)
        {
            DataTools.SaveStruct(key.ToString(), data);
        }

        public static void SaveStruct<T>(StorageKey key, int index, T data)
        {
            DataTools.SaveStruct(key.ToString() + index.ToString(), data);
        }

        public static T LoadStruct<T>(StorageKey key)
        {
            return DataTools.LoadStruct<T>(key.ToString());
        }

        public static T LoadStruct<T>(StorageKey key, int index)
        {
            return DataTools.LoadStruct<T>(key.ToString() + index.ToString());
        }

        public static T LoadStructDef<T>(StorageKey key, T def)
        {
            if (HasStruct(key))
                return DataTools.LoadStruct<T>(key.ToString());
            else
                return def;
        }

        public static T LoadStructDef<T>(StorageKey key, int index, T def)
        {
            if (HasStruct(key, index))
                return DataTools.LoadStruct<T>(key.ToString() + index.ToString());
            else
                return def;
        }

        public static bool HasStruct(StorageKey key)
        {
            return DataTools.HasStruct(key.ToString());
        }

        public static bool HasStruct(StorageKey key, int index)
        {
            return DataTools.HasStruct(key.ToString() + index.ToString());
        }

        public static void RemoveStorage(StorageKey key)
        {
            if (HasStruct(key))
            {
                DataTools.RemoveStruct(key.ToString());
            }
        }

        public static void RemoveStorage(StorageKey key, int index)
        {
            if (HasStruct(key))
            {
                DataTools.RemoveStruct(key.ToString() + index.ToString());
            }
        }

        public static void DeleteOldVersionData()
        {
            if (!DataTools.HasStruct(SDK_Configs.PublishVersion))
            {
                PlayerPrefs.DeleteAll();
                DataTools.SaveStruct(SDK_Configs.PublishVersion, true);
            }
        }

        public static void ClearOldUserData()
        {
            PlayerPrefs.DeleteAll();
            DataTools.SaveStruct(SDK_Configs.PublishVersion, true);
        }
    }
}