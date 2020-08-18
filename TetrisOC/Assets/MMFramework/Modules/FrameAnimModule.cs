using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MMFramework;
namespace MMGame
{
    public enum AnimStage
    {
        Begin,
        End
    }
    public class FrameListen
    {
        public FrameAniType animtype;
        public AnimStage animstage;
        public FrameListen(FrameAniType animtype, AnimStage animstage)
        {
            this.animtype = animtype;
            this.animstage = animstage;
        }
    }
    public class FrameAct
    {
        public FrameData.FrameEnum frameEnum;
        public object[] objects;
        public FrameAniType animtype;
        public string frametag;
        public float delay;
        public FrameAct(string frametag, FrameData.FrameEnum frameEnum, FrameAniType animtype, float delay, params object[] objects)
        {
            this.frametag = frametag;

            this.frameEnum = frameEnum;
            this.animtype = animtype;
            this.delay = delay;
            this.objects = objects;
        }
    }
    public class FrameAnimStruct
    {
        //监听
        public FrameListen listen;
        //触发
        public List<FrameAct> list = new List<FrameAct>();
        public FrameAnimStruct(FrameListen listen, params FrameAct[] actlist)
        {
            this.listen = listen;
            this.list = new List<FrameAct>(actlist);
        }
    }

    public class FrameAnimModule : MonoBehaviour, BaseModule
    {
        public static FrameAnimModule Instance
        {
            get
            {
                return RootModule.Instance.GetModule<FrameAnimModule>();
            }
        }

        // FrameAnimStruct current;
        Dictionary<string, List<FrameAnimStruct>> dict = new Dictionary<string, List<FrameAnimStruct>>();
        Dictionary<string, int> dictnum = new Dictionary<string, int>();

        public void Init()
        {

        }

        public void AddStruct(string frametag, FrameListen listen, params FrameAct[] actarray)
        {
            if (!dict.ContainsKey(frametag))
            {
                dict[frametag] = new List<FrameAnimStruct>();
                dictnum[frametag] = 0;
            }
            dict[frametag].Add(new FrameAnimStruct(listen, actarray));
            // Debug.LogError(string.Format("【Add】{0}增加元素", frametag));

        }

        void Update()
        {
            List<string> keys = new List<string>(dict.Keys);
            for (int i = 0; i < keys.Count; i++)
            {
                string frametag = keys[i];
                if (dict[frametag].Count > 0)
                {
                    if (dict[frametag][0].listen == null)
                    {
                        // Debug.LogError(string.Format("【Auto null】"));
                        ActCurrent(frametag);
                    }
                    else if (dict[frametag][0].listen.animtype == FrameAniType.Out)
                    {
                        if (dictnum[frametag] == 0)
                        {
                            // Debug.LogError(string.Format("【Auto In】"));
                            ActCurrent(frametag);
                        }
                    }
                }
            }
        }

        void ActCurrent(string frametag)
        {
            // Debug.LogError("激活" + frametag);
            if (dict.ContainsKey(frametag) && dict[frametag].Count > 0)
            {
                for (int i = 0; i < dict[frametag][0].list.Count; i++)
                {
                    FrameAct act = dict[frametag][0].list[i];
                    // Debug.LogError(string.Format("【Act】{0} 界面 {1}", act.frameEnum, act.animtype));

                    if (act.animtype.Equals(FrameAniType.In))
                    {
                        dictnum[frametag]++;
                        // Debug.LogError(string.Format("【num+】{0} {1} {2} num = {3}", act.frameEnum, act.animtype, frametag, dictnum[frametag]));
                    }

                    StartCoroutine(TimeTools.DelayCallback(act.delay, delegate
                    {
                        if (act.animtype.Equals(FrameAniType.In))
                        {
                            MMFrame.ShowFrame(act.frameEnum, act.objects, act.frametag);
                        }
                        else
                        {
                            MMFrame.HideFrame(act.frameEnum);
                        }
                    }));
                }
                dict[frametag].RemoveAt(0);
                // Debug.LogError(string.Format("【Del】{0}删除一个元素,还剩{1}", frametag, dict[frametag].Count));

                // if (dict[frametag].Count == 0)
                // {
                //     dict.Remove(frametag);
                //     dictnum.Remove(frametag);
                // }
            }
        }

        void OnHandler(System.Enum noticeID, object[] objects)
        {
            string frametag = (string)objects[0];
            FrameAniType animtype = (FrameAniType)objects[1];
            AnimStage animstage = (AnimStage)objects[2];

            // Debug.LogError(string.Format("【Handler】 {0} {1} {2}", frametag, animtype, animstage));

            if (animtype == FrameAniType.Out && animstage == AnimStage.End)
            {
                dictnum[frametag]--;
                // Debug.LogError(string.Format("【num-】 num = {1}", frametag, dictnum[frametag]));
            }

            if (dict.ContainsKey(frametag) && dict[frametag].Count > 0)
            {
                if (animtype == dict[frametag][0].listen.animtype &&
                    animstage == dict[frametag][0].listen.animstage)
                {
                    ActCurrent(frametag);
                }
            }
        }

        private void OnEnable()
        {
            NoticeTool.RegisterNotice(NoticeEnum.FRAME_TAG_ACTION, OnHandler);
        }

        private void OnDisable()
        {
            NoticeTool.UnRegisterNotice(NoticeEnum.FRAME_TAG_ACTION, OnHandler);
        }
    }
}