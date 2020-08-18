using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace MMGame
{
    public class TestScene : MonoBehaviour
    {
        public Button[] buttons;
        void Awake()
        {
            buttons[0].onClick.AddListener(delegate
            {
                Debug.Log("作弊一下");
                DataModule.Instance.Set("diamond", 9999);
            });

            buttons[1].onClick.AddListener(delegate
            {
                Debug.Log("升级英雄");
                int ret = EventModule.Instance.HandleEvent(EventEnum.HERO_LEVELUP, 1);
                Debug.Log("事件返回码:" + ret);
            });
        }
    }
}