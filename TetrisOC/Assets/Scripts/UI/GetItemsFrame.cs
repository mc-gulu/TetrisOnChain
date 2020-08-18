using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using MMFramework;
using DG.Tweening;
namespace MMGame
{
    public class GetItemsFrame : MMFrame
    {
        public Icon icontemp;
        public GameObject content;
        public Button close;
        public Animation animation;
        public Button maskbtn;
        public Transform movetrans;
        const float onetime = 1.2f;
        const float width = 65;
        bool fast = false;
        public List<Icon> icons = new List<Icon>();
        List<Coroutine> coroutines = new List<Coroutine>();
        public override void Init(object[] objects)
        {
            Debug.Log("初始化");
            List<ItemObj> list = (List<ItemObj>)objects[1];
            int onerownum = System.Math.Min(5, list.Count);
            for (int i = 0; i < list.Count; i++)
            {
                ItemObj item = list[i];
                GameObject obj = ObjTools.CopyGameObject(content, icontemp.gameObject);
                Icon icon = obj.GetComponent<Icon>();
                icon.Init(item.ID, item.Value);
                icons.Add(icon);
                int index = i;
                icon.Hide();
                icon.CanClick = false;
                // icon.Show();
                Coroutine coroutine = StartCoroutine(TimeTools.DelayScaleCallback(index * onetime, delegate
                   {
                       icon.Show();
                   }));
                coroutines.Add(coroutine);
                // if (index != 0)
                // {
                Coroutine coroutinemove = StartCoroutine(TimeTools.DelayScaleCallback(index * onetime, delegate
                 {
                     float x = ((onerownum - 1) / 2f - index % onerownum) * width;
                     Move(x);
                 }));
                coroutines.Add(coroutinemove);
                // }
            }
            // movetrans.localPosition -= new Vector3(width * (list.Count - 1) / 2, 0, 0);

            icontemp.gameObject.SetActive(false);

            close.onClick.AddListener(delegate
            {
                MMFrame.HideFrame(FrameData.FrameEnum.GetItemsFrame);
            });
            // animation.clip = animation.GetClip("GetItemStart");
            // animation.Play();
            Coroutine finishcoroutine = StartCoroutine(TimeTools.DelayScaleCallback(list.Count * onetime, delegate
            {
                Finish();
            }));
            // coroutines.Add(finishcoroutine);

            maskbtn.onClick.AddListener(delegate
            {
                if (!fast)
                {
                    fast = true;
                    for (int i = 0; i < icons.Count; i++)
                    {
                        icons[i].FastShow();
                        icons[i].CanClick = true;
                    }
                    // for (int i = 0; i < coroutines.Count; i++)
                    // {
                    //     StopCoroutine(coroutines[i]);
                    // }
                    StopAllCoroutines();
                    Finish();
                }
            });
        }

        void Finish()
        {
            // Debug.Log("Finish");

            movetrans.DOLocalMoveX(0, 0.5f);

            // animation.clip = animation.GetClip("GetItemFinish");
            StartCoroutine(TimeTools.DelayScaleCallback(0.5f, delegate
            {
                animation.Play();
                maskbtn.enabled = false;
                content.transform.localPosition += new Vector3(1000, 0, 0);
                for (int i = 0; i < icons.Count; i++)
                {
                    icons[i].CanClick = true;
                }
            }));

        }

        protected override void OnAfterAnimation(FrameAniType aniType)
        {
            Debug.Log("完成动作类型" + aniType.ToString());
        }

        public void Move(float x)
        {
            movetrans.DOLocalMoveX(x, 0.2f);
        }
    }
}