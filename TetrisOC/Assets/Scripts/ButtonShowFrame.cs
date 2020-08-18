using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using MMFramework;
namespace MMGame
{
    public class ButtonShowFrame : MonoBehaviour
    {
        public string frameEnumStr;
        void Awake()
        {
            GetComponent<Button>().onClick.AddListener(delegate
            {
                FrameData.FrameEnum frameEnum = (FrameData.FrameEnum)System.Enum.Parse(typeof(FrameData.FrameEnum), frameEnumStr);
                MMFrame.ShowFrame(frameEnum);
            });
        }
    }
}