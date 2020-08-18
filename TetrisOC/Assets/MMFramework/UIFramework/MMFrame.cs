using System.Collections;
using System.Collections.Generic;
using System.IO;
using MMFramework;
using UnityEngine;
using UnityEngine.UI;
namespace MMGame
{
    public enum FrameAniType
    {
        In,
        Out,
        Custom
    }
    public class MMFrame : MonoBehaviour
    {
        Animation anim;
        protected FrameData.FrameEnum frameEnum;

        string frametag;

        public void PreInit(string frametag, object[] objects)
        {
            anim = GetComponent<Animation>();
            if (anim == null)
                anim = gameObject.AddComponent<Animation>();
            frameEnum = (FrameData.FrameEnum)objects[0];
            this.frametag = frametag;
        }

        public virtual void Init(object[] objects)
        {

        }
        public static float GetClipLength(string pathfile)
        {
            if (!string.IsNullOrEmpty(pathfile))
            {
                string actionname = System.IO.Path.GetFileNameWithoutExtension(pathfile);

                var clip = Resources.Load<AnimationClip>(pathfile);

                return clip.length + 0.1f;
            }
            return 0f;
        }
        public float AnimationPlay(string pathfile, FrameAniType animtype)
        {
            if (anim != null && !string.IsNullOrEmpty(pathfile))
            {
                string actionname = System.IO.Path.GetFileNameWithoutExtension(pathfile);
                AnimationClip clip = anim.GetClip(actionname);
                if (clip == null)
                {
                    clip = Resources.Load<AnimationClip>(pathfile);
                    anim.AddClip(clip, actionname);
                }

                AnimationEvent animevent = new AnimationEvent();
                animevent.functionName = "Callback";
                animevent.intParameter = (int)animtype;
                animevent.time = clip.length;
                clip.AddEvent(animevent);
                anim.Play(actionname);

                if (frametag != null)
                {
                    NoticeTool.Broadcast(NoticeEnum.FRAME_TAG_ACTION, new object[] { frametag, animtype, AnimStage.Begin });
                    StartCoroutine(TimeTools.DelayCallback(animevent.time, delegate
                    {
                        NoticeTool.Broadcast(NoticeEnum.FRAME_TAG_ACTION, new object[] { frametag, animtype, AnimStage.End });
                    }));
                }
                NoticeTool.Broadcast(NoticeEnum.TOUCH_MASK_BUSY, new object[] { animevent.time });

                return animevent.time + 0.1f;
            }
            if (frametag != null)
            {
                NoticeTool.Broadcast(NoticeEnum.FRAME_TAG_ACTION, new object[] { frametag, animtype, AnimStage.Begin });
                NoticeTool.Broadcast(NoticeEnum.FRAME_TAG_ACTION, new object[] { frametag, animtype, AnimStage.End });
            }
            return 0f;
        }

        void Callback(int inttype)
        {
            // Debug.Log(inttype);
            OnAfterAnimation((FrameAniType)inttype);
        }

        protected virtual void OnAfterAnimation(FrameAniType aniType)
        {

        }

        public static void ShowTips(string title, string text)
        {
            ShowFrame(FrameData.FrameEnum.TipsFrame, new object[] { title, text });
        }

        public static void ShowTips(string title, string text, ButtonData buttonData1, ButtonData buttonData2)
        {
            ShowFrame(FrameData.FrameEnum.TipsFrame, new object[] { title, text, buttonData1, buttonData2 });
        }

        public static void ShowFrame(FrameData.FrameEnum frameEnum, object[] objects = null, string frametag = null)
        {
            List<object> objlist = new List<object>();
            objlist.Add(frameEnum);
            objlist.Add(frametag);
            if (objects != null)
                for (int i = 0; i < objects.Length; i++)
                {
                    objlist.Add(objects[i]);
                }
            NoticeTool.Broadcast(NoticeEnum.FRAME_ADD, objlist.ToArray());
        }

        public static void HideFrame(FrameData.FrameEnum frameEnum, MMFrame frame = null)
        {
            List<object> objlist = new List<object>();
            objlist.Add(frameEnum);
            objlist.Add(frame);
            NoticeTool.Broadcast(NoticeEnum.FRAME_DEL, objlist.ToArray());
        }

        public static void HideAllFrame()
        {
            NoticeTool.Broadcast(NoticeEnum.FRAME_DEL_ALL);
        }

    }
}