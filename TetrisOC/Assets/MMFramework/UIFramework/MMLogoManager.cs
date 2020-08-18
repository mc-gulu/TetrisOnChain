using MMFramework;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class LogoStruct
{
    public MMFade animation;
    public float start_delay;
    public float fadein;
    public float dur;
    public float fadeout;
}
namespace MMGame
{
    public class MMLogoManager : MonoBehaviour
    {
        public LogoStruct[] logos;
        //public string nextscene;
        private void Awake()
        {
            for (int i = 0; i < logos.Length; i++)
            {
                LogoStruct ls = logos[i];
                ls.animation.Fade(0, 0);
            }
        }

        private void Start()
        {
            StartCoroutine(activelogo());
        }
        IEnumerator activelogo()
        {
            for (int i = 0; i < logos.Length; i++)
            {
                LogoStruct ls = logos[i];

                ls.animation.Fade(0, 0);
                yield return new WaitForSecondsRealtime(ls.start_delay);

                ls.animation.Fade(ls.fadein, 1);
                yield return new WaitForSecondsRealtime(ls.fadein + ls.dur);

                ls.animation.Fade(ls.fadeout, 0);
                yield return new WaitForSecondsRealtime(ls.fadeout);
            }
            yield return new WaitForEndOfFrame();
            // Debug.LogError("activelogo out");
            UnityEngine.SceneManagement.SceneManager.LoadScene("scene_new");
        }
    }
}