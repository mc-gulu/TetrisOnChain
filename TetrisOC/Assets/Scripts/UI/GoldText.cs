using UnityEngine.UI;
using UnityEngine;
using MMFramework;
namespace MMGame
{
    public class GoldText : MonoBehaviour
    {
        Text text;
        Animation anim;
        // Use this for initialization
        System.Numerics.BigInteger current = -1;
        System.Numerics.BigInteger target = 0;
        bool ischanging = false;

        System.Numerics.BigInteger GetTargetValue()
        {
            return DataModule.Instance.Gold;
        }

        System.Enum ListenEnum()
        {
            return NoticeEnum.GOLD;
        }

        void Awake()
        {
            anim = GetComponent<Animation>();
            text = GetComponent<Text>();
            // SetValue(GetTargetValue());
            current = GetTargetValue();
            text.text = UITools.ShowBigNumber(current);
        }

        public void SetValue(System.Numerics.BigInteger v)
        {
            // text.text = UITools.ShowBigNumber(v);
            // current = v;
            target = v;
            StartChange();
        }

        // System.Numerics.BigInteger finalv;
        // public void SetValuePart(System.Numerics.BigInteger v, int part)
        // {
        //     finalv = v;

        // }

        // Update is called once per frame
        void UpdateText()
        {
            //
            if (current < 0 || target <= current)
                current = target;
            else
            {
                System.Numerics.BigInteger d = target - current;
                if (d < 2)
                    current += d;
                else
                    current += d / 2;
            }
            text.text = UITools.ShowBigNumber(current);
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

        void NoticeHandlerPart(System.Enum noticeEnum, object[] objects)
        {
            int num = (int)objects[0];
            // SetValuePart(GetTargetValue(), num);
        }

        void OnEnable()
        {
            NoticeTool.RegisterNotice(ListenEnum(), NoticeHandler);
            NoticeTool.RegisterNotice(NoticeEnum.GOLD_PART, NoticeHandlerPart);
        }

        void OnDisable()
        {
            NoticeTool.UnRegisterNotice(ListenEnum(), NoticeHandler);
            NoticeTool.UnRegisterNotice(NoticeEnum.GOLD_PART, NoticeHandlerPart);
        }
    }
}