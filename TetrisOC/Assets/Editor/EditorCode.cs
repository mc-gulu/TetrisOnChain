using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEditor.Callbacks;
#if UNITY_EDITOR
using UnityEditor.iOS.Xcode;
#endif
using UnityEngine;
namespace MMFramework
{
    public class EditorCode : MonoBehaviour
    {
#if UNITY_EDITOR
        [PostProcessBuildAttribute(1)]
        public static void OnPostProcessBuild(BuildTarget target, string path)
        {
            if (target.Equals(BuildTarget.iOS))
            {
                List<iBuild> list = SDKMapBuild.BuildSDK;
                for (int i = 0; i < list.Count; i++)
                {
                    string projectPath = PBXProject.GetPBXProjectPath(path);
                    PBXProject project = new PBXProject();
                    project.ReadFromString(File.ReadAllText(projectPath));
                    string targetName = "";
                    string targetGUID = project.TargetGuidByName(targetName);
                    string infopath = Path.Combine(path, "Info.plist");
                    PlistDocument plist = new PlistDocument();
                    plist.ReadFromFile(infopath);
                    list[i].iOSBuild(project, targetGUID, path, plist);

                    File.WriteAllText(projectPath, project.WriteToString());
                    plist.WriteToFile(infopath);

                }
            }
            else if (target.Equals(BuildTarget.Android))
            {
                string pathfile = Path.Combine(path, Application.productName);
                List<iBuild> list = SDKMapBuild.BuildSDK;
                for (int i = 0; i < list.Count; i++)
                {
                    list[i].AndroidBuild(pathfile);

                }
            }
        }
#endif
        [MenuItem("MoMoGame/Editor")]
        static void Quick1()
        {
            ChangeSDKs("Editor");
        }
        [MenuItem("MoMoGame/AppStore海外")]
        static void Quick2()
        {
            ChangeSDKs("AppStoreOverseas");
        }
        [MenuItem("MoMoGame/AppStore国内")]
        static void Quick3()
        {
            ChangeSDKs("AppStoreChina");
        }
        [MenuItem("MoMoGame/GooglePlay")]
        static void Quick4()
        {
            ChangeSDKs("GooglePlay");
        }
        [MenuItem("MoMoGame/Taptap")]
        static void Quick5()
        {
            ChangeSDKs("Taptap");
        }

        static void ChangeSDKs(string dir)
        {
            //删除非shared
            string channeldir = dir;
            string frompath = Path.Combine("PluginsCollection", channeldir);
            string pluginspath = Path.Combine("Assets", "Plugins");
            foreach (string path in Directory.GetDirectories(pluginspath))
            {
                string name = BuildTool.GetName(path);
                if (!name.StartsWith("Shared"))
                {
                    Debug.Log("deletedir " + path);
                    BuildTool.DeleteDirectory(path);
                }
            }
            foreach (string path in Directory.GetFiles(pluginspath))
            {
                string name = BuildTool.GetName(path);

                if (!name.StartsWith("Shared"))
                {
                    Debug.Log("delete " + path);
                    BuildTool.DeleteFile(path);

                }
            }

            //移动过来
            foreach (string path in Directory.GetDirectories(frompath))
            {
                string name = BuildTool.GetName(path);
                string topath = Path.Combine(pluginspath, name);
                Debug.Log("copydir " + path);
                BuildTool.CopyAndReplaceDirectory(path, topath);
            }
            foreach (string path in Directory.GetFiles(frompath))
            {
                string name = BuildTool.GetName(path);

                Debug.Log("copy " + path);
                BuildTool.CopyAndReplaceFile(path, pluginspath, "/" + name);
            }
            AssetDatabase.Refresh();
        }
    }
}