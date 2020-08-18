using MMFramework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

namespace MMGame
{
    [System.Serializable]
    public class NoticeAsset : PlayableAsset
    {
        public string noticestr;
        // Factory method that generates a playable based on this asset
        public override Playable CreatePlayable(PlayableGraph graph, GameObject go)
        {
            //Get access to the Playable Behaviour script
            NoticeBehaviour noticeBehaviour = new NoticeBehaviour();
            noticeBehaviour.noticestr = noticestr;


            //Create a custom playable from this script using the Player Behaviour script
            return ScriptPlayable<NoticeBehaviour>.Create(graph, noticeBehaviour);
        }
    }
    public class NoticeBehaviour : PlayableBehaviour
    {
        public string noticestr;
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
            NoticeEnum noticeenum = (NoticeEnum)System.Enum.Parse(typeof(NoticeEnum), noticestr);
            NoticeTool.Broadcast(noticeenum);
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