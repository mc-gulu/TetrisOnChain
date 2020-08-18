using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using UnityEngine;
using UnityEngine.UI;
using MMFramework;
namespace MMGame
{
    public class DataLoader : MonoBehaviour
    {
        public Text text;
        void Awake()
        {
            StartCoroutine(PreLoadData());
        }

        //预加载表格
        IEnumerator PreLoadData()
        {
            yield return new WaitForEndOfFrame();
            UnityEngine.SceneManagement.SceneManager.LoadScene("test"); //后续场景
        }
    }
}