using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

namespace MMGame
{
    public enum timeline_frame_Behavior
    {
        show,
        hide,
        hide_all,
    }
    [System.Serializable]
    public class FrameControlAsset : PlayableAsset
    {
        // public FrameData.FrameEnum frame;
        public string frameEnumStr;
        public timeline_frame_Behavior behavior;

        // Factory method that generates a playable based on this asset
        public override Playable CreatePlayable(PlayableGraph graph, GameObject go)
        {
            //Get access to the Playable Behaviour script
            FrameControlBehaviour playableBehaviour = new FrameControlBehaviour();
            playableBehaviour.frameEnumStr = frameEnumStr;
            playableBehaviour.behavior = behavior;

            //Create a custom playable from this script using the Player Behaviour script
            return ScriptPlayable<FrameControlBehaviour>.Create(graph, playableBehaviour);
        }
    }
    public class FrameControlBehaviour : PlayableBehaviour
    {
        // public FrameData.FrameEnum frame;
        public string frameEnumStr;
        public timeline_frame_Behavior behavior;
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
            FrameData.FrameEnum frame = (FrameData.FrameEnum)System.Enum.Parse(typeof(FrameData.FrameEnum), frameEnumStr);
            switch (behavior)
            {
                case timeline_frame_Behavior.show:
                    MMFrame.ShowFrame(frame);
                    break;
                case timeline_frame_Behavior.hide:
                    MMFrame.HideFrame(frame);
                    break;
                case timeline_frame_Behavior.hide_all:
                    MMFrame.HideAllFrame();
                    break;
                default:
                    break;
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