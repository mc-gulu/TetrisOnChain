using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace MMGame
{
    public class TestFrame : MMFrame
    {
        public override void Init(object[] objects)
        {
            Debug.Log("初始化");
        }

        protected override void OnAfterAnimation(FrameAniType aniType)
        {
            Debug.Log("完成动作类型" + aniType.ToString());
        }
    }
}