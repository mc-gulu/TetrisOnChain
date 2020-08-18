using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using MMFramework;
using UnityEngine;

namespace MMGame
{
    public class MMFrameManager : MonoBehaviour
    {
        Dictionary<FrameData.FrameEnum, List<MMFrame>> layers = new Dictionary<FrameData.FrameEnum, List<MMFrame>>();

        static MMFrameManager shared = null;
        public static MMFrameManager GetShared()
        {
            return shared;
        }
        void Awake()
        {
            shared = this;
        }

        void OnDestroy()
        {
            StopAllCoroutines();
            if (shared.Equals(this))
                shared = null;
        }

        public void add_frame(Enum noticeID, object[] objects)
        {
            if (objects.Length > 0)
            {
                FrameData.FrameEnum frameEnum = (FrameData.FrameEnum)objects[0];
                string frametag = (string)objects[1];

                object[] newobjs = new object[objects.Length - 1];
                newobjs[0] = objects[0];
                for (int i = 2; i < objects.Length; i++)
                {
                    newobjs[i - 1] = objects[i];
                }

                FrameData fd = FrameData.GetData(frameEnum);
                int layerIndex = fd.LayerIndex;
                //层节点
                Transform layertrans = GetTransform(layerIndex);
                //页面列表
                if (!layers.ContainsKey(frameEnum))
                    layers.Add(frameEnum, new List<MMFrame>());
                //添加页面
                GameObject frameobj = ObjTools.CreatePrefab(layertrans, fd.PrefabPathFile);
                MMFrame frame = frameobj.GetComponent<MMFrame>();
                layers[frameEnum].Add(frame);
                if (frame == null)
                    Debug.LogError(fd.PrefabPathFile);
                frame.PreInit(frametag, newobjs);
                frame.Init(newobjs);
                AudioModule.Instance.Sound_UI(frameEnum.ToString(), "in");
                // if (!string.IsNullOrEmpty(fd.StartAnim))
                frame.AnimationPlay(fd.StartAnim, FrameAniType.In);
            }
        }

        Transform GetTransform(int layerIndex)
        {
            Transform layertrans = transform.Find("layer" + layerIndex);
            if (layertrans == null)
            {
                GameObject obj = new GameObject();
                RectTransform rect = obj.AddComponent<RectTransform>();

                //名字，挂载
                obj.name = "layer" + layerIndex;
                layertrans = obj.transform;
                layertrans.SetParent(transform);
                // layertrans.SetSiblingIndex(layerIndex);

                //位置和大小
                rect.anchorMin = Vector2.zero;
                rect.anchorMax = Vector2.one;
                rect.sizeDelta = Vector2.zero;
                obj.transform.localPosition = Vector3.zero;
                obj.transform.localScale = Vector3.one;

                //排序
                List<string> layernames = new List<string>();
                for (int i = 0; i < transform.childCount; i++)
                {
                    string layername = transform.GetChild(i).gameObject.name;
                    if (layername.StartsWith("layer", System.StringComparison.Ordinal))
                        layernames.Add(layername);
                }
                layernames.Sort();
                for (int i = 0; i < layernames.Count; i++)
                {
                    transform.Find(layernames[i]).SetAsLastSibling();
                }
            }
            return layertrans;
        }

        public void del_frame(System.Enum noticeID, object[] objects)
        {
            if (objects.Length > 0)
            {
                FrameData.FrameEnum frameEnum = (FrameData.FrameEnum)objects[0];
                MMFrame frame = null;
                if (objects.Length > 1)
                    frame = (MMFrame)objects[1];

                FrameData fd = FrameData.GetData(frameEnum);
                if (layers.ContainsKey(frameEnum))
                {
                    List<MMFrame> framelist = layers[frameEnum];
                    for (int i = framelist.Count - 1; i >= 0; i--)
                    {
                        float closetime = 0f;
                        MMFrame targetframe = framelist[i];
                        bool needbreak = false;
                        if (frame != null)
                        {
                            if (targetframe.Equals(frame))
                                needbreak = true;
                            else
                                continue;
                        }

                        // if (!string.IsNullOrEmpty(fd.EndAnim))
                        closetime = targetframe.AnimationPlay(fd.EndAnim, FrameAniType.Out);

                        AudioModule.Instance.Sound_UI(frameEnum.ToString(), "out");

                        StartCoroutine(TimeTools.DelayCallback(closetime, delegate
                        {
                            framelist.Remove(targetframe);
                            targetframe.transform.SetParent(null);
                            Destroy(targetframe.gameObject);
                        }));

                        if (needbreak)
                        {
                            break;
                        }
                    }
                }
            }
        }

        public void delall_frame(System.Enum noticeID, object[] objects)
        {
            List<FrameData.FrameEnum> framekeys = new List<FrameData.FrameEnum>(layers.Keys);
            for (int i = 0; i < framekeys.Count; i++)
            {
                FrameData.FrameEnum key = framekeys[i];
                FrameData fd = FrameData.GetData(key);
                List<MMFrame> list = layers[key];
                for (int j = list.Count - 1; j >= 0; j--)
                {
                    float clothtime = 0f;
                    MMFrame frame = list[j];
                    // if (!string.IsNullOrEmpty(fd.EndAnim))
                    clothtime = frame.AnimationPlay(fd.EndAnim, FrameAniType.Out);

                    AudioModule.Instance.Sound_UI(key.ToString(), "out");

                    StartCoroutine(TimeTools.DelayCallback(clothtime, delegate
                    {
                        list.Remove(frame);
                        frame.transform.SetParent(null);
                        Destroy(frame.gameObject);
                    }));
                }
            }
        }

        public bool HaveFrame(FrameData.FrameEnum frameEnum)
        {
            if (layers.ContainsKey(frameEnum) && layers[frameEnum].Count > 0)
                return true;
            else
                return false;
        }

        public MMFrame GetFrame(FrameData.FrameEnum frameEnum)
        {
            if (layers.ContainsKey(frameEnum) && layers[frameEnum].Count > 0)
                return layers[frameEnum][0];
            else
                return null;
        }

        void OnEnable()
        {
            NoticeTool.RegisterNotice(NoticeEnum.FRAME_ADD, add_frame);
            // NoticeTool.RegisterNotice(NoticeEnum.FRAME_ADD_V2, add_frame_v2);
            NoticeTool.RegisterNotice(NoticeEnum.FRAME_DEL, del_frame);
            NoticeTool.RegisterNotice(NoticeEnum.FRAME_DEL_ALL, delall_frame);
        }


        void OnDisable()
        {
            NoticeTool.UnRegisterNotice(NoticeEnum.FRAME_ADD, add_frame);
            // NoticeTool.UnRegisterNotice(NoticeEnum.FRAME_ADD_V2, add_frame_v2);
            NoticeTool.UnRegisterNotice(NoticeEnum.FRAME_DEL, del_frame);
            NoticeTool.UnRegisterNotice(NoticeEnum.FRAME_DEL_ALL, delall_frame);
        }
    }
}