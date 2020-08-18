using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using MMFramework;

namespace MMFramework
{
    public class LogicTag : MonoBehaviour
    {
        public int LogicID;
        public RectTransform recttrans;
        public bool iscamerapos = false;
        public bool canactive = true;

        bool isprepared = false;

        void Start()
        {
            Check();
        }

        void Check()
        {
            isprepared = LogicModule.Instance.IsPrepared(LogicID);
        }

        void Update()
        {
            if (isprepared)
            {
                Vector2 pos = recttrans.position;
                Vector2 size = recttrans.sizeDelta;
                NoticeTool.Broadcast(NoticeEnum.MASK_SHOW, new object[] { LogicID, pos, size, iscamerapos, canactive });
            }
        }

        void Handler(System.Enum noticeID, object[] objects)
        {
            Check();
        }

        private void OnEnable()
        {
            Check();
            NoticeTool.RegisterNotice(NoticeEnum.MASK_UPDATE, Handler);
        }

        private void OnDisable()
        {
            NoticeTool.UnRegisterNotice(NoticeEnum.MASK_UPDATE, Handler);
        }
    }
}