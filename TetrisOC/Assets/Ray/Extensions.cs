using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;
using System.Reflection;

namespace MMGame
{
    public static class CSharpExtensions 
    {
        public static void SetHeight(this RectTransform rt, float AddNumber) 
        {
            rt.sizeDelta = new Vector2(rt.sizeDelta.x, rt.sizeDelta.y + AddNumber);
        }
        public static int Int<TKey, TValue>(this Dictionary<TKey, TValue> dictionary, TKey key)
        {
            TValue value;
            dictionary.TryGetValue(key, out value);
            return Convert.ToInt32(value);
        }
        public static long Long<TKey, TValue>(this Dictionary<TKey, TValue> dictionary, TKey key)
        {
            TValue value;
            dictionary.TryGetValue(key, out value);
            return Convert.ToInt64(value);
        }
        public static double Double<TKey, TValue>(this Dictionary<TKey, TValue> dictionary, TKey key)
        {
            TValue value;
            dictionary.TryGetValue(key, out value);
            return Convert.ToDouble(value);
        }
        public static bool Bool<TKey, TValue>(this Dictionary<TKey, TValue> dictionary, TKey key)
        {
            TValue value;
            dictionary.TryGetValue(key, out value);
            return Convert.ToBoolean(value);
        }
        public static float Float<TKey, TValue>(this Dictionary<TKey, TValue> dictionary, TKey key)
        {
            TValue value;
            dictionary.TryGetValue(key, out value);
            return Convert.ToSingle(value);
        }
        public static string String<TKey, TValue>(this Dictionary<TKey, TValue> dictionary, TKey key)
        {
            TValue value;
            dictionary.TryGetValue(key, out value);
            return Convert.ToString(value);
        }
        public static Dictionary<string, object> Dict<TKey, TValue>(this Dictionary<TKey, TValue> dictionary, TKey key)
        {
            TValue value;
            dictionary.TryGetValue(key, out value);
            var result = value as Dictionary<string, object> ?? new Dictionary<string, object>();
            return result;
        }

        public static List<string> SL<TKey, TValue>(this Dictionary<TKey, TValue> dictionary, TKey key)
        {
            TValue value;
            dictionary.TryGetValue(key, out value);
            var result = value as List<object> ?? new List<object>();
            return result.Select(o => Convert.ToString(o)).ToList();
        }

        public static List<int> IL<TKey, TValue>(this Dictionary<TKey, TValue> dictionary, TKey key)
        {
            TValue value;
            dictionary.TryGetValue(key, out value);
            var result = value as List<object> ?? new List<object>();
            return result.Select(o => Convert.ToInt32(o)).ToList();
        }

        public static List<int> GetIL(this object obj)
        {
            var result = obj as List<object> ?? new List<object>();
            return result.Select(o => Convert.ToInt32(o)).ToList();
        }

        public static List<object> List<TKey, TValue>(this Dictionary<TKey, TValue> dictionary, TKey key)
        {
            TValue value;
            dictionary.TryGetValue(key, out value);
            var result = value as List<object> ?? new List<object>();
            return result;
        }

        public static List<Dictionary<string, object>> DL<TKey, TValue>(this Dictionary<TKey, TValue> dictionary, TKey key)
        {
            TValue value;
            dictionary.TryGetValue(key, out value);
            var result = value as List<object> ?? new List<object>();
            return result.Select(o => o as Dictionary<string, object> ?? new Dictionary<string, object>()).ToList();
        }

        public static T ToObject<T>(this IDictionary<string, object> source)
        where T : class, new()
        {
            T result = new T();
            Type type = result.GetType();

            foreach (var item in source)
            {
                FieldInfo property = type.GetField(item.Key);

                if (property == null)
                {
                    continue;
                }

                Type propType = property.FieldType;
                property.SetValue(result, Convert.ChangeType(item.Value, propType));
            }

            return result;

        }

        public static Dictionary<string, object> AsDictionary(this object source, BindingFlags bindingAttr = BindingFlags.DeclaredOnly | BindingFlags.Public | BindingFlags.Instance)
        {
            return source.GetType().GetProperties(bindingAttr).ToDictionary
            (
                propInfo => propInfo.Name,
                propInfo => propInfo.GetValue(source, null)
            );
        }
    }
}