using System.Collections.Generic;
using UnityEngine;

namespace MMFramework
{
    public delegate void NoticeCall(System.Enum noticeId, object[] objects);
    public class NoticeTool
    {
        private static Dictionary<System.Enum, List<NoticeCall>> g_calldict = new Dictionary<System.Enum, List<NoticeCall>>();
        public static void RegisterNotice(System.Enum noticeId, NoticeCall onEvent)
        {
            List<NoticeCall> eventList;
            if (g_calldict.TryGetValue(noticeId, out eventList))
            {
                if (!eventList.Contains(onEvent))
                {
                    eventList.Add(onEvent);
                }
            }
            else
            {
                eventList = new List<NoticeCall>();
                eventList.Add(onEvent);
                g_calldict.Add(noticeId, eventList);
            }
        }

        public static void UnRegisterNotice(System.Enum noticeId, NoticeCall onEvent)
        {
            List<NoticeCall> eventList;
            if (g_calldict.TryGetValue(noticeId, out eventList))
            {
                if (eventList.Contains(onEvent))
                {
                    eventList.Remove(onEvent);
                }
                if (eventList.Count <= 0)
                {
                    g_calldict.Remove(noticeId);
                }
            }
        }

        public static void Broadcast(System.Enum noticeId, object[] objects = null)
        {
            List<NoticeCall> eventList;
            if (g_calldict.TryGetValue(noticeId, out eventList))
            {
                NoticeCall onEvent = null;
                int eventCount = eventList.Count;
                for (int i = (eventCount - 1); i >= 0; i--)
                {
                    onEvent = eventList[i];
                    try
                    {
                        onEvent(noticeId, objects);
                    }
                    catch (System.Exception e)
                    {
                        Debug.LogError(e.Message + e.StackTrace);
                    }
                }
            }
        }
    }

}; //End NB