using System;
using UnityEngine;
using UnityEngine.UI;

namespace MMFramework
{
    [Serializable]
    public class TextEx : Text
    {
        public static string FontPath
        {
            get
            {
                return System.IO.Path.Combine("Resources", _FontPath);
            }
        }
        const string _FontPath = "Prefabs/font";
        // [SerializeField]
        string storekey = String.Empty;

        public static System.Func<string, string, string> TranslateCall = null;

        // [SerializeField]
        public bool m_UseStyle;
        public bool UseStyle
        {
            get
            {
                return m_UseStyle;
            }
            set
            {
                m_UseStyle = value;
            }
        }
        // [SerializeField]
        public string m_Style;
        public string Style
        {
            get
            {
                return m_Style;
            }
            set
            {
                if (UseStyle)
                    ChangeStyle(value);
                m_Style = value;
            }
        }

        // [SerializeField]
        public bool m_Localization;
        public bool Localization
        {
            get
            {
                return m_Localization;
            }
            set
            {
                m_Localization = value;
            }
        }

        public void ChangeStyle(string style)
        {
            string oldtext = text;
            bool oldusestyle = UseStyle;

            // Debug.Log("改变 " + textex.Style + "->" + select);

            string pathname = System.IO.Path.Combine(_FontPath, style);
            // Debug.Log(pathname);
            GameObject go_temp = Resources.Load<GameObject>(pathname);
            if (go_temp == null)
                Debug.LogError(pathname);
            GameObject go_targ = gameObject;

            Component[] comps_temp = go_temp.GetComponents<Component>();
            Component[] comps_targ = go_targ.GetComponents<Component>();

            for (int i = comps_targ.Length - 1; i >= 0; i--)
            {
                Component comp_temp = null;
                Component comp_targ = comps_targ[i];
                // Debug.Log(comp_targ.GetType().Name);

                if (comp_targ.GetType().Equals(typeof(Transform)) ||
                    comp_targ.GetType().Equals(typeof(RectTransform)) ||
                    comp_targ.GetType().Equals(typeof(CanvasRenderer)))
                {
                    continue;
                }
                if (!go_temp.TryGetComponent(comp_targ.GetType(), out comp_temp))
                {

                    // comp_targ = go_targ.AddComponent(comp_temp.GetType());
                    // Debug.Log("删除" + comp_targ.GetType().Name);
                    DestroyImmediate(comp_targ);
                }
            }

            for (int i = 0; i < comps_temp.Length; i++)
            {
                Component comp_temp = comps_temp[i];
                Component comp_targ = null;
                // Debug.Log(comp_temp.GetType().Name);

                if (comp_temp.GetType().Equals(typeof(Transform)) ||
                    comp_temp.GetType().Equals(typeof(RectTransform)) ||
                    comp_temp.GetType().Equals(typeof(CanvasRenderer)))
                {
                    continue;
                }

                // UnityEditorInternal.ComponentUtility.CopyComponent(comp_temp);
                if (!go_targ.TryGetComponent(comp_temp.GetType(), out comp_targ))
                {
                    comp_targ = go_targ.AddComponent(comp_temp.GetType());
                }
                ObjTools.CopyValues(comp_temp, comp_targ);
            }

            m_Style = style;//恢复自身的style（不使用目标style文本）

            text = oldtext;
            UseStyle = oldusestyle;
        }

        protected override void Awake()
        {
            if (Application.isPlaying)
            {
                //DebugTool.LogError("TextEx Awake");
                if (Localization && string.IsNullOrEmpty(storekey))
                {
                    string key = text;
                    //DebugTool.Log(key);
                    string def = text;
                    storekey = key;
                    base.text = Translate(storekey, def);
                }
            }
            else
                base.Awake();
            if (UseStyle)
                ChangeStyle(Style);
        }

        public override string text
        {
            get
            {
                return base.text;
            }
            set
            {
                if (Application.isPlaying)
                {
                    //DebugTool.LogError("TextEx text");
                    if (Localization)
                    {
                        if (string.IsNullOrEmpty(storekey))
                        {
                            storekey = value;
                            string def = value;
                            base.text = Translate(storekey, def);
                        }
                        else if (string.IsNullOrEmpty(value))
                        {
                            storekey = value;
                            base.text = value;
                        }
                        else if (!storekey.Equals(value))
                        {
                            storekey = value;
                            string def = value;
                            base.text = Translate(storekey, def);
                        }
                    }
                    else
                        base.text = value;
                }
                else
                    base.text = value;
            }
        }

        string Translate(string key, string def)
        {
            return RootModule.Instance.GetModule<LocalModule>().GetValue(key, def);
        }
    }
}