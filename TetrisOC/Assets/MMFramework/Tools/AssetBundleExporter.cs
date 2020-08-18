using System.IO;
using UnityEditor;
using UnityEngine;

namespace MMFramework
{
#if UNITY_EDITOR
	public class AssetBundleExpoter 
	{
		[MenuItem("MMFramework/Build AssetBundles", false)]
		static void BuildAssetBundles()
		{
			var outputPath = Application.dataPath + "/AssetBundles/" + PathTools.GetPlatformName() + "/" + Application.version;

			if (!Directory.Exists(outputPath))
			{
				Directory.CreateDirectory(outputPath);
			}

			BuildPipeline.BuildAssetBundles(outputPath, BuildAssetBundleOptions.ChunkBasedCompression,
				EditorUserBuildSettings.activeBuildTarget);

			//ResVersion version = new ResVersion() {AppVersion = Application.version, BundleVersion = VersionConfig.bundleVersion };
			//var json = JsonUtility.ToJson(version);
			//File.WriteAllText(outputPath + "/ResVersion.json", json);

			AssetDatabase.Refresh();
		}
	}
#endif
}