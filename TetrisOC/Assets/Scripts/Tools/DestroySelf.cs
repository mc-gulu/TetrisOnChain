using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MMGame
{
    public class DestroySelf : MonoBehaviour
    {
        public void DestroyMySelf()
        {
            Destroy(gameObject);
        }
        public void WarningFrameClose()
        {
            MMFrame.HideFrame(FrameData.FrameEnum.WarningFrame);
        }
    }
}
