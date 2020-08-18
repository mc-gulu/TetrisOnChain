using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathTools
{
    public static string StreamingAssetsPath
    {
        get
        {

#if UNITY_ANDROID && !UNITY_EDITOR
            return Application.streamingAssetsPath;
#elif UNITY_IPHONE && !UNITY_EDITOR
            return "file://" + Application.streamingAssetsPath;
#elif UNITY_STANDLONE_WIN||UNITY_EDITOR
            return Application.streamingAssetsPath;
#else
            return string.Empty;
#endif
            /*
            在移动平台下，Application.streamingAssetsPath是只读的，不能写入数据。Application.persistentDataPath 可以读取和写入数据。

            在PC下，可以用File类API（如File.ReadAllText）读写StreamingAssets文件夹中的文件；在IOS和Android平台下，不能用File类API读取。

            所有平台上都可以用www方式异步读取StreamingAssets文件夹，PC和IOS平台下，读取路径必须加上"file://"，而安卓不需要。

            在IOS和Android下，还能用AssetBundle.LoadFromFile来同步读取数据。
            */
        }
    }

    public static string PersistentDataPath
    {
        get
        {
            return
#if UNITY_ANDROID && !UNITY_EDITOR
            "file://" + Application.persistentDataPath;
#elif UNITY_IPHONE && !UNITY_EDITOR
            "file:///" + Application.persistentDataPath;
#elif UNITY_STANDLONE_WIN||UNITY_EDITOR
            Application.persistentDataPath;
#else
            string.Empty;
#endif
        }
    }
    public static string AddSpritePath = "Images/UI_cut_520/UI_cut_520_92";

    public static string HeroItemPath = "Prefabs/ui/HeroItem";

    private static string OSSPath = @"https://motestbucket.oss-cn-shenzhen.aliyuncs.com/";
    private static string channelName = "editor";
    private static string jsonName = "ResVersion.json";
    public static string patchSuffix = ".bytes";
    public static int ServAreaNum = 1;

    public static string ResRemoteDir = OSSPath + "/AssetBundles/" + channelName;
    public static string ResLocalDir = PersistentDataPath + "/AssetBundles/";
    public static string VersionJsonRemotePath = ResRemoteDir + "/" + jsonName;

    public static string GetPlatformName()
    {

#if UNITY_EDITOR
        return GetPlatformName(UnityEditor.EditorUserBuildSettings.activeBuildTarget);
#else
            return GetPlatformName(Application.platform);
#endif
    }

#if UNITY_EDITOR
    private static string GetPlatformName(UnityEditor.BuildTarget buildTarget)
    {
        switch (buildTarget)
        {
            case UnityEditor.BuildTarget.StandaloneWindows:
            case UnityEditor.BuildTarget.StandaloneWindows64:
                return "Windows";
            case UnityEditor.BuildTarget.iOS:
                return "iOS";
            case UnityEditor.BuildTarget.Android:
                return "Android";
            case UnityEditor.BuildTarget.StandaloneLinux:
            case UnityEditor.BuildTarget.StandaloneLinux64:
            case UnityEditor.BuildTarget.StandaloneLinuxUniversal:
                return "Linux";
            case UnityEditor.BuildTarget.StandaloneOSX:
                return "OSX";
            case UnityEditor.BuildTarget.WebGL:
                return "WebGL";
            default:
                return null;
        }
    }
#endif

    private static string GetPlatformName(RuntimePlatform runtimePlatform)
    {
        switch (runtimePlatform)
        {
            case RuntimePlatform.WebGLPlayer:
                return "WebgGL";
            case RuntimePlatform.OSXPlayer:
                return "OSX";
            case RuntimePlatform.WindowsPlayer:
                return "Windows";
            case RuntimePlatform.IPhonePlayer:
                return "iOS";
            case RuntimePlatform.Android:
                return "Android";
            default:
                return null;
        }
    }
    public static string IconPath = "Images/icons";
    public static string[] CareerIconNames = new string[]
    {
        "",
        "icons_0",
        "icons_3",
        "icons_5",
        "icons_2",
        "icons_4",
        "icons_1",
        "icons_6"
    };
    public static string[] CareerNames = new string[]
{
        "",
        "KNIGHT",
        "BERSERKER",
        "CLERIC",
        "ALCHEMIST",
        "WIZARD",
        "RANGER",
        "GUNSLINGER"
};
    public static string[] EleIconNames = new string[]
    {
        "",
        "icons_7",
        "icons_9",
        "icons_8",
        "icons_10",
        "icons_11"
    };
    public static string[] EleNames = new string[]
{
        "",
        "FIRE",
        "WIND",
        "WATER",
        "LIGHT",
        "DARK",
        "PHYSICS"
};

    public static string[] careericonpathname = new string[]
    {
        "",
        "Images/icons/icons_0",
        "Images/icons/icons_3",
        "Images/icons/icons_5",
        "Images/icons/icons_2",
        "Images/icons/icons_4",
        "Images/icons/icons_1",
        "Images/icons/icons_6"
    };

    public static string[] elementiconpathname = new string[]
    {
        "",
        "Images/icons/icons_7",
        "Images/icons/icons_9",
        "Images/icons/icons_8",
        "Images/icons/icons_10",
        "Images/icons/icons_11"
    };
}