using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;


namespace MMGame
{
    [System.Serializable]
    public class NewPlayableAsset : PlayableAsset
    {
        // Factory method that generates a playable based on this asset
        public override Playable CreatePlayable(PlayableGraph graph, GameObject go)
        {
            //Get access to the Playable Behaviour script
            ChangeMapBehaviour playableBehaviour = new ChangeMapBehaviour();

            //Create a custom playable from this script using the Player Behaviour script
            return ScriptPlayable<ChangeMapBehaviour>.Create(graph, playableBehaviour);
        }
    }

    public class ChangeMapBehaviour : PlayableBehaviour
    {
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
            GameController.Instance.CreateMapObj();
            GameController.Instance.TimelineObj.GetComponent<CutOutPlayer>().SetBinding("d_NewMapActive", GameController.Instance.mapobj);
            GameController.Instance.mapobj.AddComponent<Animator>();
            GameController.Instance.TimelineObj.GetComponent<CutOutPlayer>().SetBinding("d_NewMapAnim", GameController.Instance.mapobj.GetComponent<Animator>());

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