#if UNITY_EDITOR
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
// #if UNITY_IOS
using UnityEditor.iOS.Xcode;
// #endif
using UnityEngine;

public class AdModuleEmptyBuild : iBuild
{
    // #if UNITY_IOS
    public void iOSBuild(PBXProject project, string targetGUID, string path, PlistDocument plist)
    {

    }
    // #elif UNITY_ANDROID 
    public void AndroidBuild(string projpath)
    {

    }
    // #endif
}
#endif