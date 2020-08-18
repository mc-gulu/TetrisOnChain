using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace MMFramework
{
    public class MMdynamicstick : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler
    {
        public RectTransform rect;
        public RectTransform stick;
        public RectTransform bg;
        public float radius;

        int _pointerId = -10;
        bool _is_controlling = false;

        public bool IsControlling()
        {
            return _is_controlling;
        }

        private void Awake()
        {
            SetVisible(false);
        }

        public void OnPointerDown(PointerEventData touchInfo)
        {
            _is_controlling = true;
            //DebugTool.Log("开始控制");
            //DebugTool.LogError("down");
            _pointerId = touchInfo.pointerId;
            SetVisible(true);
            UpdateStickAndBgPos(touchInfo.position);
            NoticeTool.Broadcast(NoticeEnum.HANDLE_CONTROL, new object[] { true });
        }

        public void OnDrag(PointerEventData touchInfo)
        {
            if (touchInfo.pointerId != _pointerId)
                return;
            UpdateStickPos(touchInfo.position);
        }

        public void OnPointerUp(PointerEventData touchInfo)
        {
            _is_controlling = false;
            //DebugTool.Log("结束控制");
            //DebugTool.LogError("up");
            if (touchInfo.pointerId != _pointerId)
                return;
            NoticeTool.Broadcast(NoticeEnum.HANDLE_CONTROL, new object[] { false });
            UpdateStickAndBgPos(rect.position);
            SetVisible(false);
        }

        void UpdateStickAndBgPos(Vector2 worldpos)
        {
            bg.position = worldpos;
            stick.position = worldpos;
        }

        void UpdateStickPos(Vector2 worldpos)
        {
            Vector2 basepos = bg.position;
            Vector2 d = worldpos - basepos;
            d = Vector2.ClampMagnitude(d, radius);
            stick.position = basepos + d;
        }

        void SetVisible(bool visible)
        {
            bg.gameObject.SetActive(visible);
            stick.gameObject.SetActive(visible);
        }

        public Vector2 GetPos()
        {
            return (stick.position - bg.position) / radius;
        }
    }
}