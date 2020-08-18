using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MMFramework
{
    public class ButtonFastLock : MonoBehaviour
    {
        float locktime = 0;
        const float LOCK_TIME = 0.5f;
        // Update is called once per frame
        void Update()
        {
            if (locktime > 0)
                locktime -= Time.deltaTime;
        }
        public bool IsLock { get { return locktime > 0; } set { locktime = value ? LOCK_TIME : -1; } }
    }
}