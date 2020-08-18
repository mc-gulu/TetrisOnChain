using System.Collections.Generic;
using MMFramework;
using UnityEngine;
namespace MMGame
{
    public class FightRecordModule : MonoBehaviour, BaseModule
    {
        public static FightRecordModule Instance
        {
            get
            {
                return RootModule.Instance.GetModule<FightRecordModule>();
            }
        }

        Dictionary<string, object> values;
        List<Item> picklist;

        public void Init()
        {
            values = new Dictionary<string, object>();
            picklist = new List<Item>();
        }

        public void Clear()
        {
            values.Clear();
            picklist.Clear();
        }

        public void PlusFloat(string key, float value)
        {
            if (values.ContainsKey(key))
            {
                values[key] = (float)values[key] + value;
            }
            else
            {
                Set(key, value);
            }
        }
        public void PlusInt(string key, int value)
        {
            if (values.ContainsKey(key))
            {
                values[key] = (int)values[key] + value;
            }
            else
            {
                Set(key, value);
            }
        }
        public void Set<T>(string key, T value)
        {
            values[key] = value;
        }
        public void Pick(List<Item> list)
        {
            picklist.AddRange(list);
        }
        public void Pick(Item item)
        {
            picklist.Add(item);
        }
        public T GetValue<T>(string key, T def)
        {
            if (values.ContainsKey(key))
                return (T)values[key];
            else
                return def;
        }
        public List<Item> GetPicklist()
        {
            return picklist;
        }
    }
}