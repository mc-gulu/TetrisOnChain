using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;


namespace MMGame
{
    [System.Serializable]
    public class DestroyAsset : PlayableAsset
    {
        // Factory method that generates a playable based on this asset
        public override Playable CreatePlayable(PlayableGraph graph, GameObject go)
        {
            //Get access to the Playable Behaviour script
            DestroyBehaviour playableBehaviour = new DestroyBehaviour();

            //Create a custom playable from this script using the Player Behaviour script
            return ScriptPlayable<DestroyBehaviour>.Create(graph, playableBehaviour);
        }
    }

    public class DestroyBehaviour : PlayableBehaviour
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
            GameController.Instance.DestroyTimeline();
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