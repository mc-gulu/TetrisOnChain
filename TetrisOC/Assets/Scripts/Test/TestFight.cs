using System.Collections;
using System.Collections.Generic;
using MMFramework;
using MMGame;
using UnityEngine;
using UnityEngine.UI;
public class TestFight : MonoBehaviour
{
    public Button[] button;

    private void Awake()
    {
        button[0].onClick.AddListener(delegate
        {

        });
    }
}