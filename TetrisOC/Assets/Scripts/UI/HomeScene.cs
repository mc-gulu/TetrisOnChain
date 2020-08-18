using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MMFramework;

namespace MMGame
{
    public class HomeScene : MonoBehaviour
    {
        // Start is called before the first frame update
        void Awake()
        {
            MMFrame.ShowFrame(FrameData.FrameEnum.HomeFrame);
            // MMFrame.ShowFrame(FrameData.FrameEnum.EmergencyNoticeFrame);
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}