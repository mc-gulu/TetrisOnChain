using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
namespace MMFramework
{
    public class ModifyExcelModule : MonoBehaviour, BaseModule
    {
        public static ModifyExcelModule Instance
        {
            get
            {
                return RootModule.Instance.GetModule<ModifyExcelModule>();
            }
        }
        // Dictionary<string, Dictionary<int, object>> exceldict = new Dictionary<string, Dictionary<int, object>>();
        Dictionary<int, object> modifiedcache = new Dictionary<int, object>();
        public void Init()
        {
            //载入数据
            // List<int> modifylist = ModifyExcelData.GetKeys();

            // modifylist.Add(1);
            // modifylist.Add(2);
            // modifylist.Add(3);
            // modifylist.Add(4);
        }

        public object GetModifyedData(int key)
        {
            if (!modifiedcache.ContainsKey(key))
            {
                if (!ModifyExcelData.GetKeys().Contains(key))//不能直接GetData，否则死循环
                    return null;
                ModifyExcelData med = ModifyExcelData.GetData(key);
                string excel = med.Data;
                int basekey = med.Key;
                string name = med.Name;
                string value = med.Value;
                int index = med.ArrayIndex;

                Type type = Type.GetType(med.Data);
                object obj = type.InvokeMember("GetData",
                            System.Reflection.BindingFlags.InvokeMethod |
                            System.Reflection.BindingFlags.Static |
                            System.Reflection.BindingFlags.Public,
                            null,
                            null,
                            new object[]
                            {
                                (int)basekey
                            });
                obj = ObjTools.DeepCopy(obj);

                Type valuetype = type.GetField(name).FieldType;
                object valueobj;
                if (valuetype.Equals(typeof(Xfloat)) || valuetype.Equals(typeof(Xfloat[])))
                {
                    Xfloat v = new Xfloat("");
                    v = float.Parse(value);
                    valueobj = v;
                }
                else if (valuetype.Equals(typeof(Xint)) || valuetype.Equals(typeof(Xint[])))
                {
                    Xint v = new Xint("");
                    v = int.Parse(value);
                    valueobj = v;
                }
                else if (valuetype.Equals(typeof(Xbool)) || valuetype.Equals(typeof(Xbool[])))
                {
                    Xbool v = new Xbool("");
                    v = bool.Parse(value);
                    valueobj = v;
                }
                if (valuetype.Equals(typeof(float)) || valuetype.Equals(typeof(float[])))
                {
                    valueobj = float.Parse(value);
                }
                else if (valuetype.Equals(typeof(int)) || valuetype.Equals(typeof(int[])))
                {
                    valueobj = int.Parse(value);
                }
                else if (valuetype.Equals(typeof(bool)) || valuetype.Equals(typeof(bool[])))
                {
                    valueobj = bool.Parse(value);
                }
                else if (valuetype.Equals(typeof(string)) || valuetype.Equals(typeof(string[])))
                {
                    valueobj = value;
                }
                else
                {
                    valueobj = null;
                    Debug.LogError(type + "." + name + "不支持的类型" + valuetype.ToString());
                }

                if (valuetype.IsArray)
                {
                    Array a = (Array)type.GetField(name).GetValue(obj);
                    a.SetValue(valueobj, index);
                }
                else
                {
                    type.GetField(name).SetValue(obj, valueobj);
                }
                modifiedcache[key] = obj;
            }
            return modifiedcache[key];
        }

        public object GetModifyedData(System.Enum key)
        {
            // if (exceldict.ContainsKey(excel) && exceldict[excel].ContainsKey(key))
            //     return exceldict[excel][key];
            // else
            return null;
        }

        public object GetModifyedData(string key)
        {
            // if (exceldict[excel].ContainsKey(key))
            //     return exceldict[excel][key];
            // else
            return null;
        }

        public object GetModifyedData(float key)
        {
            // if (exceldict[excel].ContainsKey(key))
            //     return exceldict[excel][key];
            // else
            return null;
        }
    }
}