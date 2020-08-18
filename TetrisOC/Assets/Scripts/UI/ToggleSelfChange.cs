using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace MMGame
{
    [RequireComponent(typeof(Toggle))]
    public class ToggleSelfChange : MonoBehaviour
    {
        public List<GoActive> ActiveControl;
        public List<WHScale> ScaleControl;
        public List<UIColor> ColorControl;
        private bool last;
        private Toggle toggle;
        private void Awake()
        {
            toggle = GetComponent<Toggle>();
            toggle.onValueChanged.AddListener(ison =>
            {
                ToggleChange(ison);
            });
            last = toggle.isOn;
        }

        public void ToggleChange(bool ison)
        {
            if (ison == last) return;
            ActiveChange(ison);
            SizeChange(ison);
            ColorChange(ison);
            last = ison;
        }

        private void ColorChange(bool ison)
        {
            if (ColorControl.Count == 0) return;
            for (int i = 0; i < ColorControl.Count; i++)
            {
                if (!ColorControl[i].Graphic) continue;
                ColorControl[i].Graphic.color = ison ? ColorControl[i].OnColor : ColorControl[i].OffColor;
            }
        }

        private void SizeChange(bool ison)
        {
            if (ScaleControl.Count == 0) return;
            for (int i = 0; i < ScaleControl.Count; i++)
            {
                if (!ScaleControl[i].Rt) continue;
                ScaleControl[i].Rt.sizeDelta = ison ? ScaleControl[i].Rt.sizeDelta * ScaleControl[i].MutiNum : ScaleControl[i].Rt.sizeDelta / ScaleControl[i].MutiNum;
            }
        }

        private void ActiveChange(bool ison)
        {
            if (ActiveControl.Count == 0) return;
            for (int i = 0; i < ActiveControl.Count; i++)
            {
                if (!ActiveControl[i].Go) continue;
                ActiveControl[i].Go.SetActive(ison ^ ActiveControl[i].InActive);
            }
        }
    }

    [System.Serializable]
    public struct GoActive
    {
        public GameObject Go;
        public bool InActive;
    }
    [System.Serializable]
    public struct WHScale 
    {
        public RectTransform Rt;
        public float MutiNum;
    }
    [System.Serializable]
    public struct UIColor 
    {
        public MaskableGraphic Graphic;
        public Color OffColor;
        public Color OnColor;
    }
}