using MMFramework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

namespace MMGame
{
    [System.Serializable]
    public class UIActiveAsset : PlayableAsset
    {
        public bool Active;
        // Factory method that generates a playable based on this asset
        public override Playable CreatePlayable(PlayableGraph graph, GameObject go)
        {
            //Get access to the Playable Behaviour script
            UIActiveBehaviour uiActiveBehaviour = new UIActiveBehaviour();
            uiActiveBehaviour.Active = Active;
            //Create a custom playable from this script using the Player Behaviour script
            return ScriptPlayable<UIActiveBehaviour>.Create(graph, uiActiveBehaviour);
        }
    }
    public class UIActiveBehaviour : PlayableBehaviour
    {
        public bool Active;
        // Called when the owning graph starts playing
        public override void OnGraphStart(Playable playable)
        {

        }

        // Called when the owning graph stops playing
        public override void OnGraphStop(Playable playable)
        {

        }
        // Called when the state of the playable is set to Play
        public override void OnBehaviourPlay(Playable playable, UnityEngine.Playables.FrameData info)
        {
            for (int i = 0; i < 4; i++)
            {
                var go = GameController.Instance.FakeCreatueList[i];
                if (go)
                {
                    var uipoint = ObjTools.FindChild(go.transform, "uipoint");
                    if (uipoint)
                        uipoint.gameObject.SetActive(Active);
                }
            }
        }

        // Called when the state of the playable is set to Paused
        public override void OnBehaviourPause(Playable playable, UnityEngine.Playables.FrameData info)
        {
        }

        // Called each frame while the state is set to Play
        public override void PrepareFrame(Playable playable, UnityEngine.Playables.FrameData info)
        {

        }
    }
}