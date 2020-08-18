using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace MMFramework
{
    public interface BaseModule
    {
        void Init();
    }

    public interface IAppControl 
    {
        void OnPause(bool pause);
        void OnTimeScale(float scaleNum);
    }
}