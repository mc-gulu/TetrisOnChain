using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MMFramework;
using IFix.Core;
using System.IO;

namespace MMGame {
    public class RayHotUpdateTest : MonoBehaviour
    {
        void Start()
        {
            Debug.Log(Application.persistentDataPath);
        }

        

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.P))
            {
                TextAsset bytes = CacheModule.Instance.LoadAsset<TextAsset>(PathTools.patchSuffix);
                if (bytes != null)
                {
                    PatchManager.Load(new MemoryStream(bytes.bytes));
                    Debug.Log("patched");
                }

            }

            if (Input.GetKeyDown(KeyCode.T))
            {
                Testfunc();
            }
        }

        private void Testfunc()
        {
            Debug.Log("Before");
        }
    }

}
