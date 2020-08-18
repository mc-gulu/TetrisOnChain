using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace MMGame
{
    public class HomeUITopItem : MonoBehaviour
    {
        public Text text;
        public GameObject[] state0;
        public GameObject[] state1;
        public GameObject tagobj;


        public void UpdateUI(string title, bool passed, bool tag)
        {
            text.text = title;
            for (int i = 0; i < state0.Length; i++)
            {
                state0[i].SetActive(!passed);
            }
            for (int i = 0; i < state1.Length; i++)
            {
                state1[i].SetActive(passed);
            }
            tagobj.SetActive(tag);
        }
    }
}