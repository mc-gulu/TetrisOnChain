using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace MMFramework
{
    public class LocalImage : MonoBehaviour
    {
        public Image image;
        public string filepathkey;

        void Awake()
        {
            string localstr = LocalModule.Instance.GetValue(filepathkey, filepathkey);
            image.sprite = Resources.Load<Sprite>(localstr);
            image.SetNativeSize();
        }
    }
}