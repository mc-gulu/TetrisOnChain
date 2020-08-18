using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MMFade : MonoBehaviour
{
    public void Fade(float dur, float to_alpha)
    {
        MaskableGraphic[] images = GetComponentsInChildren<MaskableGraphic>();
        for (int i = 0; i < images.Length; i++)
        {
            images[i].CrossFadeAlpha(to_alpha, dur, true);
        }
    }
}
