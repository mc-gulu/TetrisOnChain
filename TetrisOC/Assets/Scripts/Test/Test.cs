using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Timers;
using BestHTTP.Extensions;
using MMFramework;
using MMGame;
using UnityEngine;
using UnityEngine.UI;
public class Test : MonoBehaviour
{
    float timer;
    float startTime;
    private void Awake()
    {
        //button.onClick.AddListener(delegate
        //{
        //    index = (index + 1) % actions.Length;
        //    // animation.Play(actions[index], PlayMode.StopAll);
        //    // animation.CrossFade(actions[index]);
        //    //string actionname = actions[index];
        //    //Debug.Log(actionname);
        //    //animation.Play(actionname);
        //    // TaskManagerModule.Instance.Enter(TaskType.Maincity);
        //});
        //for (int i = 0; i < 100; i++)
        //{
        //    Debug.Log(i +"____" + CalculateTool.CalculateFormula1(1.04f, 27 / 3.5f, 0, 10, i));
        //}
        //Debug.Log(10 + "____" + CalculateTool.CalculateFormula1(1.04f, 27 / 3.5f, 0, 10, 10)); 
        //Debug.Log(10 + "____" + CalculateTool.CalculateFormula(10, "7.71428571428571*POW(1.04,10)", true));


        startTime = Time.time;
        timer = 0;
        Time.timeScale = 2;
    }

    private void Update()
    {
        timer += Time.deltaTime;
        if (timer > 1)
        {
            timer -= 1;
            Debug.Log(Time.time - startTime);
            Debug.Log(Time.unscaledTime - startTime);
            Debug.Log(Time.realtimeSinceStartup - startTime);
        }
    }


}