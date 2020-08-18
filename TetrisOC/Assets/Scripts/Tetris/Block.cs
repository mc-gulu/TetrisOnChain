using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace MMGame
{
    public class Block : MonoBehaviour
    {
        public Image image;
        public Image preview;
        public Animator animator;

        public Color[] colors;

        public static float W
        {
            get
            {
                return 50f;
            }
        }

        public static float H
        {
            get
            {
                return 50f;
            }
        }

        public void Light()
        {

        }

        public float Width
        {
            get
            {
                return GetComponent<RectTransform>().sizeDelta.x;
            }
        }

        public float Height
        {
            get
            {
                return GetComponent<RectTransform>().sizeDelta.y;
            }
        }

        public void SetMoney(float money)
        {
            int colorindex = 0;
            if (money >= 1f)
            {
                colorindex = 4;
            }
            else if (money >= 0.5f)
            {
                colorindex = 3;
            }
            else if (money >= 0.1f)
            {
                colorindex = 2;
            }
            else if (money >= 0.05f)
            {
                colorindex = 1;
            }

            image.color = colors[colorindex];
        }

        public void SetPreview()
        {
            preview.gameObject.SetActive(true);
            image.gameObject.SetActive(false);
        }
    }
}