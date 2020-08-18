using System.Collections.Generic;
using MMFramework;
using UnityEngine;
using LitJson;
using UnityEngine.UI;
namespace MMGame
{
    public class LogModule : MonoBehaviour, BaseModule
    {
        public static LogModule Instance
        {
            get
            {
                return RootModule.Instance.GetModule<LogModule>();
            }
        }

        Text text;

        public void Init()
        {
            Canvas canvas = gameObject.AddComponent<Canvas>();
            canvas.renderMode = RenderMode.ScreenSpaceOverlay;
            text = gameObject.AddComponent<Text>();
            text.font = Resources.Load<Font>("Font/SourceHanSansCN-Bold");
            text.color = Color.grey;
        }

        public void Log(object message)
        {
            // text.text += "\n" + message.ToString();
            Debug.Log(message);
        }

        public static void LogScreen(object message)
        {
            Instance.Log(message);
        }

    }
}