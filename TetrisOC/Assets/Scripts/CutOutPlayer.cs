using MMFramework;
using MMGame;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

namespace MMGame
{
    public class CutOutPlayer : MonoBehaviour
    {
        public GameObject KjSmoke;
        public GameObject[] Smokes;
        PlayableDirector Director;
        TimelineUnit unit;
        public void Init()
        {
            Director = GetComponent<PlayableDirector>();
            unit = new TimelineUnit();
            unit.Init("", Director, Director.playableAsset);
            unit.SetBinding("d_OldMapActive", GameController.Instance.mapobj);
            unit.SetBinding("d_KuangjiPos", GameController.Instance.GetMachinePos());
            unit.SetBinding("d_KuangjiAnim", GameController.Instance.GetMachineAnim());
            unit.SetBinding("d_coin", GameController.Instance.GetMachineCoin());
            for (int i = 0; i < 4; i++)
            {
                var go = GameController.Instance.FakeCreatueList[i];
                if (go)
                    unit.SetBinding("d_HeroPos" + i, go.GetComponentInChildren<Animator>());
            }
            unit.Play();
        }
        public void SetBinding(string trackName, Object o)
        {
            unit.SetBinding(trackName, o);
        }

        public void ActiveSmokes()
        {
            KjSmoke.SetActive(true);
            var list = GameController.Instance.FakeCreatueList;
            for (int i = 0; i < Smokes.Length; i++)
            {
                Smokes[i].SetActive(list[i] != null);
                if (list[i])
                    Smokes[i].transform.position = list[i].transform.position;
            }
        }
    }
}