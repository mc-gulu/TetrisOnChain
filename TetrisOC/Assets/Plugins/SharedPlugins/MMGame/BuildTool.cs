#if UNITY_EDITOR
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor.iOS.Xcode;
using UnityEngine;

public static class BuildTool
{
    public static void SetInfoDictValue(PlistDocument plist, string key, string subkey, PlistElement value)
    {
        if (!plist.root.values.ContainsKey(key))
            plist.root.CreateDict(key);
        if (!plist.root[key].AsDict().values.ContainsKey(subkey))
            plist.root[key].AsDict().values.Add(subkey, value);
        else
            plist.root[key].AsDict()[subkey] = value;
    }

    public static void RemoveInfoDict(PlistDocument plist, string key, string subkey, PlistElement value)
    {
        if (plist.root.values.ContainsKey(key))
        {
            plist.root.values.Remove(key);
        }
    }

    public static void AddInfoArrayString(PlistDocument plist, string key, string val)
    {
        if (!plist.root.values.ContainsKey(key))
            plist.root.CreateArray(key);
        PlistElement element = plist.root[key].AsArray().values.Find(delegate (PlistElement ele)
        {
            return ele.AsString().Equals(val);
        });
        if (element == null)
            plist.root[key].AsArray().values.Add(new PlistElementString(val));
    }

    public static void SetInfoString(PlistDocument plist, string key, string val)
    {
        if (!plist.root.values.ContainsKey(key))
            plist.root.SetString(key, val);
    }

    public static void SetInfoBoolean(PlistDocument plist, string key, bool val)
    {
        if (!plist.root.values.ContainsKey(key))
            plist.root.SetBoolean(key, val);
    }

    public static void ReplaceText(string pathfile, string oldtext, string newtext)
    {
        if (!System.IO.File.Exists(pathfile))
        {
            Debug.LogError(pathfile + "路径下文件不存在");
            return;
        }

        StreamReader streamReader = new StreamReader(pathfile);
        string text_all = streamReader.ReadToEnd();
        streamReader.Close();

        int beginIndex = text_all.IndexOf(oldtext, System.StringComparison.Ordinal);
        int newbeginIndex = text_all.IndexOf(newtext, System.StringComparison.Ordinal);
        if (beginIndex == -1)
        {
            Debug.LogError(pathfile + "中没有找到标致" + oldtext);
            return;
        }

        if (newbeginIndex != -1)
        {
            Debug.LogError(pathfile + "已有标志" + newtext);
            return;
        }

        text_all = text_all.Replace(oldtext, newtext);
        StreamWriter streamWriter = new StreamWriter(pathfile);
        streamWriter.Write(text_all);
        streamWriter.Close();
    }

    public static void AddFrameworks(PBXProject project, string targetGUID)
    {
        // Frameworks
        project.AddFrameworkToProject(targetGUID, "libz.dylib", false);
        project.AddFrameworkToProject(targetGUID, "libsqlite3.tbd", false);
        project.AddFrameworkToProject(targetGUID, "CoreTelephony.framework", false);
    }

    public static bool CopyAndReplaceDirectory(string srcPath, string dstPath)
    {
        if (Directory.Exists(srcPath))
        {
            if (Directory.Exists(dstPath))
                Directory.Delete(dstPath, true);
            if (File.Exists(dstPath))
                File.Delete(dstPath);
            Directory.CreateDirectory(dstPath);
            foreach (var file in Directory.GetFiles(srcPath))
                if (!file.EndsWith(".meta", System.StringComparison.Ordinal) && !file.EndsWith(".DS_Store", System.StringComparison.Ordinal))
                {
                    File.Copy(file, Path.Combine(dstPath, Path.GetFileName(file)));
                }
            foreach (var dir in Directory.GetDirectories(srcPath))
                CopyAndReplaceDirectory(dir, Path.Combine(dstPath, Path.GetFileName(dir)));
            return true;
        }
        return false;
    }

    public static bool CopyAndReplaceFile(string srcPath, string dstPath, string filePath)
    {
        if (File.Exists(srcPath))
        {
            if (File.Exists(dstPath + filePath))
                File.Delete(dstPath + filePath);
            Directory.CreateDirectory(dstPath);
            if (!filePath.EndsWith(".meta", System.StringComparison.Ordinal) && !filePath.EndsWith(".DS_Store", System.StringComparison.Ordinal))
            {
                File.Copy(srcPath, dstPath + filePath);
            }
            return true;
        }
        return false;
    }

    public static void DeleteDirectory(string dir)
    {
        if (Directory.Exists(dir))
            Directory.Delete(dir, true);
    }

    public static void DeleteFile(string dir)
    {
        if (File.Exists(dir))
            File.Delete(dir);
    }

    public static string GetName(string path)
    {
        if (path.Contains(@"\"))
        {
            return path.Substring(path.LastIndexOf(@"\", System.StringComparison.Ordinal) + 1);
        }
        else
        {
            return path.Substring(path.LastIndexOf("/", System.StringComparison.Ordinal) + 1);
        }
    }
}
#endif