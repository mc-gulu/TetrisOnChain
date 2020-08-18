#if UNITY_EDITOR
using System.Collections;
using System.Collections.Generic;
// #if UNITY_IOS
using UnityEditor.iOS.Xcode;
// #endif
using UnityEngine;

public interface iBuild
{
    // #if UNITY_IOS
    void iOSBuild(PBXProject project, string targetGUID, string path, PlistDocument plist);
    // #elif UNITY_ANDROID 
    void AndroidBuild(string projpath);
    // #endif
}
#endif