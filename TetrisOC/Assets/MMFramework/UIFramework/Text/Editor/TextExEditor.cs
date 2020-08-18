using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using System.IO;
namespace MMFramework
{
    [CustomEditor(typeof(MMFramework.TextEx), true)]
    [CanEditMultipleObjects]
    public class TextExEditor : Editor
    {
        SerializedProperty m_Text;
        SerializedProperty m_FontData;
        SerializedProperty m_Color;
        SerializedProperty m_Material;
        SerializedProperty m_RaycastTarget;
        SerializedProperty m_Localization;
        SerializedProperty m_Style;
        SerializedProperty m_UseStyle;

        protected void OnEnable()
        {
            //     base.OnEnable();
            m_Text = serializedObject.FindProperty("m_Text");
            m_FontData = serializedObject.FindProperty("m_FontData");
            m_Color = serializedObject.FindProperty("m_Color");
            m_Material = serializedObject.FindProperty("m_Material");
            m_RaycastTarget = serializedObject.FindProperty("m_RaycastTarget");
            m_Localization = serializedObject.FindProperty("m_Localization");
            m_Style = serializedObject.FindProperty("m_Style");
            m_UseStyle = serializedObject.FindProperty("m_UseStyle");
        }

        public override void OnInspectorGUI()
        {
            serializedObject.Update();
            EditorGUILayout.PropertyField(m_Text);
            EditorGUILayout.PropertyField(m_UseStyle);

            TextEx textex = target as TextEx;
            if (textex.UseStyle)
            {
                string dir = Path.Combine(Application.dataPath, TextEx.FontPath);
                string[] arrpathname = Directory.GetFiles(dir, "*.prefab", SearchOption.TopDirectoryOnly);
                for (int i = 0; i < arrpathname.Length; i++)
                {
                    arrpathname[i] = Path.GetFileNameWithoutExtension(arrpathname[i]);
                }
                int selecedindex = GetIndex(arrpathname, textex.Style);
                int select = EditorGUILayout.Popup(selecedindex, arrpathname, GUILayout.Width(80));
                if (!select.Equals(selecedindex))
                {
                    // Debug.Log("1");
                    textex.Style = arrpathname[select];
                }
            }
            else
            {
                EditorGUILayout.PropertyField(m_FontData);
                EditorGUILayout.PropertyField(m_Color);
                EditorGUILayout.PropertyField(m_Material);
                EditorGUILayout.PropertyField(m_RaycastTarget);
                EditorGUILayout.PropertyField(m_Localization);
                EditorGUILayout.PropertyField(m_Style);
            }
            //base.OnInspectorGUI();

            //AppearanceControlsGUI();
            serializedObject.ApplyModifiedProperties();
        }

        int GetIndex(string[] strs, string val)
        {
            for (int i = 0; i < strs.Length; i++)
            {
                if (val.Equals(strs[i]))
                    return i;
            }
            return 0;
        }
    }
}