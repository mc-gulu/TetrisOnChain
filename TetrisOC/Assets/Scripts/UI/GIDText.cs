using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MMFramework;
using UnityEngine.UI;
namespace MMGame
{
    public class GIDText : MonoBehaviour
    {
        void Awake()
        {
            Text text = GetComponent<Text>();
            if (text != null)
            {
                text.text = DataModule.Instance.Gid;
            }
        }
    }
}