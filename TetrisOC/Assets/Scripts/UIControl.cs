using System.Collections;
using System.Collections.Generic;
using MMFramework;
using UnityEngine;
namespace MMGame
{
    public class UIControl : MonoBehaviour
    {
        public MMdynamicstick stick;

        void Update()
        {
            if (stick.IsControlling())
            {
                Vector2 pos = stick.GetPos();
                BattlefieldModule.Instance.controlling = true;
            }
            else
            {
                BattlefieldModule.Instance.controlling = false;
            }
        }

        void OnHandler(System.Enum noticeID, object[] objects)
        {
            bool control = (bool)objects[0];
        }

        private void OnEnable()
        {
            NoticeTool.RegisterNotice(NoticeEnum.HANDLE_CONTROL, OnHandler);
        }

        private void OnDisable()
        {
            NoticeTool.UnRegisterNotice(NoticeEnum.HANDLE_CONTROL, OnHandler);
        }
    }
}