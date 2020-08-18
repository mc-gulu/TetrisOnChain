using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
namespace MMFramework
{
    public class MMMaskManager : MonoBehaviour
    {
        public GuideHighlightMask mask;
        // public Transform finger;
        int logicID;
        bool canactive;
        // Vector2 oldpos = Vector2.zero;
        // Vector2 oldsize = Vector2.zero;
        Coroutine coroutine = null;
        Coroutine dotween_coroutine = null;
        string fingerprefabname = string.Empty;

        GameObject fingerobj = null;
        void Awake()
        {
            mask.action = delegate
            {
                if (canactive)
                {
                    // Debug.LogError("mask action");
                    int oldlogicID = logicID;
                    StartCoroutine(TimeTools.DelayCallback(0.001f, delegate
                    {
                        NoticeTool.Broadcast(NoticeEnum.MASK_LOGIC_FINISH, new object[] { oldlogicID });
                    }));
                }
            };

            mask.lightRect.gameObject.SetActive(false);
            mask.touchRect.gameObject.SetActive(false);
            // finger.gameObject.SetActive(false);
            mask.gameObject.SetActive(false);
        }

        void ShowHandler(System.Enum noticeID, object[] objects)
        {
            int templogicID = (int)objects[0];
            Vector2 pos = (Vector2)objects[1];
            Vector2 size = (Vector2)objects[2];
            bool iscamerapos = (bool)objects[3];
            canactive = (bool)objects[4];
            if (iscamerapos)
            {
                pos = ObjTools.Worldpos2UIpos(pos);
                size = size * 100;
            }

            Vector2 oldpos = mask.touchRect.position;
            Vector2 oldsize = mask.touchRect.sizeDelta;

            if (logicID != templogicID ||
            Mathf.Abs(oldpos.x - pos.x) > 1f ||
            Mathf.Abs(oldpos.y - pos.y) > 1f ||
            Mathf.Abs(oldsize.x - size.x) > 1f ||
            Mathf.Abs(oldsize.y - size.y) > 1f)
            {
                // Debug.LogError(string.Format("{0} {1} {2} {3} {4}", templogicID, pos.x, pos.y, size.x, size.y));


                mask.touchRect.position = pos;
                mask.touchRect.sizeDelta = size;

                if (fingerobj != null)
                {
                    fingerobj.transform.position = pos;
                    // Debug.LogError(false);
                    fingerobj.SetActive(false);
                }


                mask.lightRect.position = mask.touchRect.position;
                if (logicID != templogicID)
                    mask.lightRect.sizeDelta = mask.touchRect.sizeDelta * 5;

                logicID = templogicID;

                if (dotween_coroutine != null)
                    StopCoroutine(dotween_coroutine);
                dotween_coroutine = StartCoroutine(TimeTools.DelayCallback(0.8f, delegate
                {
                    dotween_coroutine = null;

                    string newprefab = LogicData.GetData(logicID).Prefab;
                    if (!fingerprefabname.Equals(newprefab))
                    {
                        fingerprefabname = newprefab;
                        fingerobj = ObjTools.CreatePrefab(transform, LogicData.GetData(logicID).Prefab);
                        fingerobj.transform.position = pos;
                    }
                    if (fingerobj != null)
                    {
                        // Debug.LogError(true);
                        fingerobj.SetActive(true);
                    }
                }));

                mask.touchRect.gameObject.SetActive(true);
                mask.lightRect.gameObject.SetActive(true);
                mask.gameObject.SetActive(true);

                if (coroutine != null)
                    StopCoroutine(coroutine);
            }
        }

        void Update()
        {
            // mask.lightRect.position = mask.lightRect.position + mask.touchRect.position / 2;
            // Debug.LogError(string.Format("({0},{1}) ({2},{3})",
            // mask.touchRect.sizeDelta.x,
            // mask.touchRect.sizeDelta.y,
            // mask.lightRect.sizeDelta.x,
            // mask.lightRect.sizeDelta.y
            // ));
            if (Mathf.Abs(mask.lightRect.sizeDelta.x - mask.touchRect.sizeDelta.x) > 1f || Mathf.Abs(mask.lightRect.sizeDelta.y - mask.touchRect.sizeDelta.y) > 1f)
            {
                float r = 0.97f;
                mask.lightRect.sizeDelta = r * mask.lightRect.sizeDelta + (1 - r) * mask.touchRect.sizeDelta;
            }
        }

        void ClearHandler(System.Enum noticeID, object[] objects)
        {
            coroutine = StartCoroutine(TimeTools.DelayCallback(0.01f, delegate
            {
                coroutine = null;
                mask.touchRect.gameObject.SetActive(false);
                mask.lightRect.gameObject.SetActive(false);

                DestroyImmediate(fingerobj);
                fingerobj = null;
                // Debug.LogError(null);
                fingerprefabname = string.Empty;

                mask.gameObject.SetActive(false);

                if (dotween_coroutine != null)
                    StopCoroutine(dotween_coroutine);
            }));
        }

        private void OnEnable()
        {
            NoticeTool.RegisterNotice(NoticeEnum.MASK_SHOW, ShowHandler);
            NoticeTool.RegisterNotice(NoticeEnum.MASK_CLEAR, ClearHandler);
        }

        private void OnDisable()
        {
            NoticeTool.UnRegisterNotice(NoticeEnum.MASK_SHOW, ShowHandler);
            NoticeTool.RegisterNotice(NoticeEnum.MASK_CLEAR, ClearHandler);
        }
    }
}