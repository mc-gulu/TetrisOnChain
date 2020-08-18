using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
namespace MMFramework
{
    [CustomEditor(typeof(MMGame.BulletTest), true)]
    [CanEditMultipleObjects]
    public class TBulletTestEditor : Editor
    {
        // SerializedProperty m_Text;
        // SerializedProperty m_FontData;
        // SerializedProperty m_Color;
        // SerializedProperty m_Material;
        // SerializedProperty m_RaycastTarget;
        // SerializedProperty m_Localization;
        // SerializedProperty m_Style;
        // SerializedProperty m_UseStyle;

        // static string[] descs = null;
        GUIStyle okstyle, errorstyle;
        protected void OnEnable()
        {
            okstyle = new GUIStyle();
            okstyle.normal.textColor = Color.green;
            errorstyle = new GUIStyle();
            errorstyle.normal.textColor = Color.red;
            // base.OnEnable();
            // m_Text = serializedObject.FindProperty("m_Text");
            // m_FontData = serializedObject.FindProperty("m_FontData");
            // m_Color = serializedObject.FindProperty("m_Color");
            // m_Material = serializedObject.FindProperty("m_Material");
            // m_RaycastTarget = serializedObject.FindProperty("m_RaycastTarget");
            // m_Localization = serializedObject.FindProperty("m_Localization");
            // m_Style = serializedObject.FindProperty("m_Style");
            // m_UseStyle = serializedObject.FindProperty("m_UseStyle");
        }

        public override void OnInspectorGUI()
        {
            Component component = target as Component;
            var s = component.transform.Find("spritepoint");
            EditorGUILayout.LabelField("根结点下有spritepoint", (s == null) ? errorstyle : okstyle);

            var show = component.transform.Find("spritepoint/show");
            EditorGUILayout.LabelField("spritepoint有show节点", (show == null) ? errorstyle : okstyle);

            Renderer[] renders = component.gameObject.GetComponentsInChildren<Renderer>(true);
            Renderer[] renders2 = (show != null) ? show.gameObject.GetComponentsInChildren<Renderer>(true) : new Renderer[0];
            EditorGUILayout.LabelField("所有显示都在show下", renders.Length == renders2.Length ? okstyle : errorstyle);

            var box = component.transform.Find("box");
            EditorGUILayout.LabelField("根结点下有box", (box == null) ? errorstyle : okstyle);

            Collider2D[] colliders = component.gameObject.GetComponentsInChildren<Collider2D>(true);
            Collider2D[] colliders2 = (box != null) ? box.gameObject.GetComponentsInChildren<Collider2D>(true) : new Collider2D[0];
            EditorGUILayout.LabelField("所有Collider都在box下", colliders.Length == colliders2.Length ? okstyle : errorstyle);

            ParticleSystem[] ps = component.gameObject.GetComponentsInChildren<ParticleSystem>(true);
            if (ps.Length > 0 && show != null)
            {
                ParticleSystem[] ps2 = show.gameObject.GetComponentsInChildren<ParticleSystem>(true);
                EditorGUILayout.LabelField("所有粒子都在show下", ps.Length == ps2.Length ? okstyle : errorstyle);
            }

            Animator[] animators = component.gameObject.GetComponentsInChildren<Animator>(true);
            Animator[] animators2 = component.gameObject.GetComponents<Animator>();
            bool animatorok = (animators.Length == animators2.Length && animators.Length <= 1);
            EditorGUILayout.LabelField("只在根结点存在一个animator 或者不存在 animator", animatorok ? okstyle : errorstyle);
        }
    }
}