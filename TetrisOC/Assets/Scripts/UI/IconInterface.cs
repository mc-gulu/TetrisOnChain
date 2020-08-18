using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace MMGame
{
    public interface IconInterface
    {
        void Init(ItemObj item, bool canClick);
        float GetAnimationTime();
        void PlayAnimation();
    }
}