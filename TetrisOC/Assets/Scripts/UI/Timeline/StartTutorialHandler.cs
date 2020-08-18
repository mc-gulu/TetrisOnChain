using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

namespace MMGame
{
    public class StartTutorialHandler : MonoBehaviour
    {
        PlayableDirector Director;
        TimelineUnit unit;

        public void Init()
        {
            Director = GetComponent<PlayableDirector>();
            unit = new TimelineUnit();
            unit.Init("", Director, Director.playableAsset);
            //unit.SetBinding("d_kuangji", GameController.Instance.GetMachineAnim());
            unit.Play();
        }
        public void SetBinding(string trackName, Object o)
        {
            unit.SetBinding(trackName, o);
        }

        public void Pause()
        {
            // Debug.LogError("Pause");
            unit.Pause();
        }

        public void Resume()
        {
            // Debug.LogError("Resume");
            unit.Resume();
        }
    }
}