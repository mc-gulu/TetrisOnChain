using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace MMFramework
{
    public class MMCanvusSettings : MonoBehaviour
    {
        private void Awake()
        {
            CanvasScaler scaler = GetComponent<CanvasScaler>();
            float h_w_design = scaler.referenceResolution.y / scaler.referenceResolution.x;
            float h_w_screen = Screen.height / Screen.width;
            if (h_w_screen > h_w_design)
                scaler.matchWidthOrHeight = 0;
            else
                scaler.matchWidthOrHeight = 1;
        }
    }
}