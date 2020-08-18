using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MMFramework;
using UnityEngine.UI;
namespace MMGame
{
    public class Redpoint : MonoBehaviour
    {
        Image redpoint;
        public string path;

        void Awake()
        {
            redpoint = GetComponent<Image>();
        }

        void Handler(System.Enum NoticeEnum, object[] objects = null)
        {
            string noticepath = (string)objects[0];
            if (noticepath.StartsWith(path))
            {
                UpdateUI();
            }
        }

        void UpdateUI()
        {
            int num = RedModule.Instance.GetRedNum(path);

            if (redpoint != null)
            {
                redpoint.gameObject.SetActive(num > 0);
            }
        }

        void OnEnable()
        {
            NoticeTool.RegisterNotice(NoticeEnum.UPDATE_REDPOINT, Handler);
            UpdateUI();
        }

        void OnDisable()
        {
            NoticeTool.UnRegisterNotice(NoticeEnum.UPDATE_REDPOINT, Handler);
        }
    }
}