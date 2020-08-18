using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace MMFramework
{
    public class MMTouchManager : MonoBehaviour
    {
        public Button maskbtn;

        float busy = -1f;
        int touch = 0;

        void Awake()
        {
            maskbtn.onClick.AddListener(delegate
            {
                touch++;
                // Debug.LogError(string.Format("onClick {0}", touch));
                if (touch >= MMGame.ConfigInGame.UnlockBusytimeCount)
                {
                    float oldbusy = busy;
                    busy = -1f;
                    // Debug.LogError(string.Format("onClick BusyHander {0}->{1}", oldbusy, busy));
                    if (oldbusy * busy <= 0)
                        BusyChanged(busy > 0);
                }
            });
            BusyChanged(busy > 0);
        }

        void BusyHander(System.Enum noticeID, object[] objects)
        {
            float oldbusy = busy;
            float newbusy = (float)objects[0];
            // Debug.LogError(string.Format("BusyHander {0}->{1}", oldbusy, newbusy));
            busy = Mathf.Max(busy, newbusy);
            if (oldbusy * busy <= 0)
                BusyChanged(busy > 0);
        }

        void FixedUpdate()
        {
            float oldbusy = busy;
            busy -= Time.fixedDeltaTime;
            // Debug.Log(busy);
            if (oldbusy * busy <= 0)
            {
                // Debug.LogError(string.Format("FixedUpdate {0}->{1}", oldbusy, busy));
                BusyChanged(busy > 0);
            }
        }

        void BusyChanged(bool isbusy)
        {
            maskbtn.gameObject.SetActive(isbusy);
            touch = 0;
        }

        private void OnEnable()
        {
            NoticeTool.RegisterNotice(NoticeEnum.TOUCH_MASK_BUSY, BusyHander);
        }

        private void OnDisable()
        {
            NoticeTool.RegisterNotice(NoticeEnum.TOUCH_MASK_BUSY, BusyHander);
        }
    }
}