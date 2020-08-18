using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace MMFramework
{
    public class ButtonSound : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
    {
        public string PressDownEventKey;
        public string PressUpEventKey;
        public void OnPointerDown(PointerEventData eventData)
        {
            AudioModule.Instance.Sound_Custom(PressDownEventKey);
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            AudioModule.Instance.Sound_Custom(PressUpEventKey);
        }
    }
}