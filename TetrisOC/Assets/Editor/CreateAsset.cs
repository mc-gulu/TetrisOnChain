using System;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

public class CreateAsset : Editor
{
    public static string[] GetFullExcelAndOutFold()
    {
        string configpathfile = ConfigPathFile();

        ExcelConfig excelConfig = AssetDatabase.LoadAssetAtPath<ExcelConfig>(configpathfile);
        string[] pathlist;
        if ((excelConfig == null) ||
            (string.IsNullOrEmpty(excelConfig.excelpath) || string.IsNullOrEmpty(excelConfig.codepath) || string.IsNullOrEmpty(excelConfig.datapath) || string.IsNullOrEmpty(excelConfig.writterpath)))
        {
            pathlist = Change();
        }
        else
        {
            string excelpath = Path.GetFullPath(Path.Combine(Application.dataPath, excelConfig.excelpath));
            string codepath = Path.GetFullPath(Path.Combine(Application.dataPath, excelConfig.codepath));
            string datapath = Path.GetFullPath(Path.Combine(Application.dataPath, excelConfig.datapath));
            string writterpath = Path.GetFullPath(Path.Combine(Application.dataPath, excelConfig.writterpath));

            if (!Directory.Exists(excelpath) || !Directory.Exists(codepath) || !Directory.Exists(datapath) || !Directory.Exists(writterpath))
                pathlist = Change();
            else
            {
                pathlist = new string[] { excelpath, codepath, datapath, writterpath };
            }
        }
        return pathlist;
    }

    [MenuItem("MoMoGame/ChangeExcelFold")]
    static string[] Change() //存储是相对路径，导出是绝对路径
    {
        ExcelConfig excelConfig = new ExcelConfig();
        string excelpath = SetFolderMenu("选择Excel表格所在文件夹", Environment.CurrentDirectory);
        string codepath = SetFolderMenu("选择DataReader文件夹", Application.dataPath);
        string datapath = SetFolderMenu("选择bytes文件夹", Application.dataPath);
        string writterpath = SetFolderMenu("选择writter文件夹", Application.dataPath);

        //从绝对路径获取相对于Environment的相对路径
        excelConfig.excelpath = RelativePath(Application.streamingAssetsPath, excelpath);
        excelConfig.codepath = RelativePath(Application.streamingAssetsPath, codepath);
        excelConfig.datapath = RelativePath(Application.streamingAssetsPath, datapath);
        excelConfig.writterpath = RelativePath(Application.streamingAssetsPath, writterpath);

        string configpathfile = ConfigPathFile();
        AssetDatabase.CreateAsset(excelConfig, configpathfile);

        return new string[] { excelpath, codepath, datapath, writterpath };
    }
    static string ConfigPathFile()
    {
        string editorpath = Path.Combine(Application.dataPath, "Editor");
        string configpath = Path.Combine(editorpath, string.Format("{0}.asset", typeof(ExcelConfig)));
        return RelativePath(Application.dataPath, configpath);
    }
    static string RelativePath(string basepath, string path)
    {
        Uri u1 = new Uri(basepath, UriKind.Absolute);
        Uri u2 = new Uri(path, UriKind.Absolute);
        Uri u3 = u1.MakeRelativeUri(u2); //u2相对于u1的uri
        //Debug.LogError("Path:" + u3.ToString());
        return u3.ToString();
    }

    static string SetFolderMenu(string title, string old)
    {
        string openfolder = old;
        if (string.IsNullOrEmpty(openfolder) || !Directory.Exists(openfolder))
        {
            openfolder = Environment.CurrentDirectory;
            if (!Directory.Exists(openfolder))
            {
                Debug.LogError("Environment.CurrentDirectory路径错误:" + openfolder);
                return string.Empty;
            }

        }

        string selectedpath = EditorUtility.OpenFolderPanel(title, openfolder, "");
        return selectedpath;
    }
}