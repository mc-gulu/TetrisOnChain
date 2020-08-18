using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using MMFramework;
namespace MMGame
{
    public class MMCoinText : MonoBehaviour
    {
        Text text;
        Animation anim;
        // Use this for initialization
        int current = -1;
        int target = 0;
        bool ischanging = false;

        protected virtual int GetTargetValue()
        {
            return 0;
        }

        protected virtual System.Enum ListenEnum()
        {
            return NoticeEnum.NONE;
        }

        void Awake()
        {
            anim = GetComponent<Animation>();
            text = GetComponent<Text>();
            SetValue(GetTargetValue());
        }

        public void SetValue(int v)
        {
            target = v;
            if (target != current && !IsChanging())
            {
                StartChange();
            }
        }

        // Update is called once per frame
        void UpdateText()
        {
            //
            if (current < 0 || target <= current)
                current = target;
            else
            {
                int d = target - current;
                if (d < 5)
                    d = 1;
                else if (d < 50)
                    d = 7;
                else if (d < 500)
                    d = 49;
                else
                    d = 371;
                current += d;
            }
            text.text = current.ToString();
        }

        void CheckStop()
        {
            if (current == target)
                StopChange();
        }

        void StartChange()
        {
            anim.Play();
            ischanging = true;
        }

        bool IsChanging()
        {
            return ischanging;
        }

        void StopChange()
        {
            ischanging = false;
            anim.Stop();
        }

        void NoticeHandler(System.Enum noticeEnum, object[] objects)
        {
            SetValue(GetTargetValue());
        }

        void OnEnable()
        {
            NoticeTool.RegisterNotice(ListenEnum(), NoticeHandler);
        }

        void OnDisable()
        {
            NoticeTool.UnRegisterNotice(ListenEnum(), NoticeHandler);
        }
    }
}