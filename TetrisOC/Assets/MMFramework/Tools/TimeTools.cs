using System.Collections;
using UnityEngine;
namespace MMFramework
{
    public static class TimeTools
    {
        public static IEnumerator DelayCallback(float delay, System.Action callback)
        {
            yield return new WaitForSecondsRealtime(delay);
            callback();
        }

        public static IEnumerator DelayScaleCallback(float delay, System.Action callback)
        {
            yield return new WaitForSeconds(delay);
            callback();
        }

        public static string ShortTime(long smalltick, bool showmillisecond = true)
        {
            // Debug.LogError(smalltick);
            System.TimeSpan ts = new System.TimeSpan(smalltick);
            return ShortTime(ts, showmillisecond);
        }

        public static string ShortTime(System.TimeSpan ts, bool showmillisecond = false)
        {
            string text = string.Empty;
            if (ts.Days > 0)
                text += ts.Days.ToString() + " ";

            if (text.Length > 0)
                text += ts.Hours.ToString("D2") + ":";
            else if (ts.Hours > 0)
                text += ts.Hours.ToString("D") + ":";

            if (text.Length > 0)
                text += ts.Minutes.ToString("D2") + ":";
            else if (ts.Minutes > 0)
                text += ts.Minutes.ToString("D") + ":";

            text += ts.Seconds.ToString("D2");

            if (showmillisecond)
            {
                text += "." + ts.Milliseconds.ToString("D3");
            }

            return text;
        }

        public static float TimeUnit
        {
            get
            {
                return 1f / Time.timeScale;
            }
        }
    }
}