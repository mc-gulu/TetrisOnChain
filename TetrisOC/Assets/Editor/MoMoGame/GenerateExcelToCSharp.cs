using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Text.RegularExpressions;
using UnityEditor;
using UnityEngine;

public class GenerateExcelToCSharp
{
    [MenuItem("MoMoGame/Clear Cache")]
    static void ClearCache()
    {
        PlayerPrefs.DeleteAll();
    }

    // This row in a excel sheet is Name
    public const int NAME_ROW_INDEX = 0;
    // This row in a excel sheet is Type
    public const int TYPE_ROW_INDEX = 1;

    public const int DESC_ROW_INDEX = 2;
    // This row in a excel sheet is where real data starts
    public const int DATA_START_INDEX = 3;

    static string excelPathKey = "XLSX_PATH";
    static string outputPathKey = "GENE_PATH";

    static void SetFolderMenu(string key)
    {
        //显示原有的,没有显示默认的
        //选完检测
        //合格存储
        string openfolder = EditorPrefs.GetString(key);
        if (string.IsNullOrEmpty(openfolder) || !Directory.Exists(openfolder))
        {
            openfolder = Environment.CurrentDirectory + "/Assets";
            if (!Directory.Exists(openfolder))
            {
                openfolder = Environment.CurrentDirectory;
                if (!Directory.Exists(openfolder))
                {
                    return;
                }
            }
        }

        string selectedpath = EditorUtility.OpenFolderPanel("Select Folder for " + key, openfolder, "");
        if (!string.IsNullOrEmpty(selectedpath))
        {
            EditorPrefs.SetString(key, selectedpath);
        }
        else
        {
            Debug.LogError("Select Output Folder Error");
        }
    }

    static string GetFolder(string key)
    {
        string folder = EditorPrefs.GetString(key);
        if (string.IsNullOrEmpty(folder) || !Directory.Exists(folder))
        {
            SetFolderMenu(key);
            folder = EditorPrefs.GetString(key);
        }
        return folder;
    }


    [MenuItem("MoMoGame/ExcelToTable Type %t")]
    public static void Pass0()
    {
        EditorPrefs.SetBool("converting", true);
        Debug.Log("开始转表");
        Generate(0);
        Debug.Log("刷新......");
        AssetDatabase.Refresh();
    }

    // [MenuItem("MoMoGame/ExcelToData Type %g")]
    [UnityEditor.Callbacks.DidReloadScripts]
    private static void OnScriptsReloaded()
    {
        // Debug.Log("编译完成");
        bool converting = EditorPrefs.GetBool("converting", false);
        if (converting)
        {
            // Debug.Log("脚本编译完成");
            string[] pathlist = CreateAsset.GetFullExcelAndOutFold();
            string datapath = pathlist[2];
            Debug.Log("写入中......");
            DataWritter.WirteToFile(datapath);
            // Debug.Log("开始生成读数据");
            Generate(1);
            AssetDatabase.Refresh();
            Debug.Log("转表完成");
            EditorPrefs.SetBool("converting", false);
        }
    }

    [MenuItem("MoMoGame/Fast ExcelToTable Type %g")]
    public static void Pass2()
    {
        EditorPrefs.SetBool("converting", false);
        Debug.Log("开始转表");
        Generate(2);
        AssetDatabase.Refresh();
        Debug.Log("转表完成");
    }

    public static void Generate(int pass)
    {
        //byte[] contentbytes = Encoding.Unicode.GetBytes("这是中文");
        //string str = Encoding.Unicode.GetString(contentbytes);
        //Console.WriteLine(str + ":" + contentbytes.Length);
        //string excelfolder = GetFolder(excelPathKey);
        //string outfolder = GetFolder(outputPathKey);

        /*
        0
            更新Writter 刷新Data名字
            更新Data    带root.Add 带写文件代码
        1
            写文件
            更新Data    不带root.Add 带读文件代码
        */

        /*
        2
            不加密
            //删除Writter 内容
            更新Data    带root.Add 无读写
        */

        string[] pathlist = CreateAsset.GetFullExcelAndOutFold();
        string excelfolder = pathlist[0];
        string outfolder = pathlist[1];
        string datapath = pathlist[2];
        string datawriterpath = pathlist[3];

        List<string> classnames = new List<string>();
        string[] arrpathname = Directory.GetFiles(excelfolder + "/", "*.xlsx", SearchOption.TopDirectoryOnly);
        string datalist_code = string.Empty;
        datalist_code += "public class DataWritter{\n";
        datalist_code += "public static void WirteToFile(string path){\n";

        int changednum = 0;
        foreach (var item in arrpathname)
        {
            string filename = item.Substring(item.LastIndexOf("/", StringComparison.Ordinal) + 1);
            if (!filename.StartsWith("~$", StringComparison.Ordinal))
            {
                Console.Write(filename);
                string class_name = filename.Substring(0, filename.LastIndexOf(".xlsx", System.StringComparison.Ordinal));

                var sheetData = ExcelReader.AsStringArray(item);

                string reader_code = string.Empty;
                //string class_data_function = string.Empty;
                //string class_reader = string.Empty;
                bool success = GetClassStruct(sheetData,
                    class_name,
                    pass,
                    ref reader_code);
                if (success)
                {
                    string filepathname = Path.Combine(outfolder, class_name + ".cs");
                    bool need_save = true;
                    if (File.Exists(filepathname))
                    {
                        //FileStream fs = new FileStream(filepathname, FileMode.Open);
                        StreamReader sr = new StreamReader(filepathname);
                        string content = sr.ReadToEnd();
                        if (content.GetHashCode().Equals(reader_code.GetHashCode()))
                        {
                            need_save = false;
                        }
                        sr.Close();
                        sr.Dispose();
                    }
                    if (need_save)
                    {
                        changednum++;
                        if (pass == 2)
                            Debug.Log("--<color=#ff5555>" + class_name + "</color>--");
                        StreamWriter sw = new StreamWriter(filepathname, false);
                        sw.Write(reader_code);
                        sw.Flush();
                        sw.Close();
                        sw.Dispose();
                    }
                    else
                    {
                        Console.Write("(ok)");
                    }
                    datalist_code += class_name + ".SaveToFile(path);\n";
                    classnames.Add(class_name);
                }
                else
                {
                    Console.Write("( **** 读取失败 ****)");
                }
                Console.WriteLine();
            }
        }
        datalist_code += "}}";

        if (pass == 0) //刷新类别
        {
            StreamWriter streamwriter = new StreamWriter(Path.Combine(datawriterpath, "DataWritter" + ".cs"), false);
            streamwriter.Write(datalist_code);
            streamwriter.Flush();
            streamwriter.Close();
            streamwriter.Dispose();
        }

        Debug.Log(string.Format("共解析{0}个文件,修改了<color=red>{1}</color>个类型", classnames.Count, changednum));
    }

    public static void ClearKey()
    {
        EditorPrefs.DeleteKey(excelPathKey);
        EditorPrefs.DeleteKey(outputPathKey);
    }

    static bool GetClassStruct(ExcelReader.SheetData sheetData,
        string class_name,
        int pass,
        ref string reader_code)
    {
        try
        {
            //解析变量

            string class_para_def = string.Empty;
            string class_constructure_def = string.Empty;
            //string build_data_function = string.Empty;
            string class_reader = string.Empty;

            string parastring = string.Empty; //构造参数
            string initstring = string.Empty; //构造赋值

            string enumstring = string.Empty; //枚举

            Dictionary<string, List<string>> enumdict = new Dictionary<string, List<string>>();

            //过滤字段
            List<int> activecol = new List<int>();
            for (int col = 0; col < sheetData.columnCount; col++)
            {
                if (string.IsNullOrEmpty(sheetData.At(NAME_ROW_INDEX, col)))
                    break;
                string paraname = sheetData.At(NAME_ROW_INDEX, col);
                if (!paraname.StartsWith("_", StringComparison.Ordinal))
                {
                    activecol.Add(col);
                }
            }
            int activeColCount = activecol.Count;
            string[] variableName = new string[activeColCount];
            for (int index = 0; index < activeColCount; index++)
            {
                int col = activecol[index];
                variableName[index] = sheetData.At(NAME_ROW_INDEX, col);
            }

            //获取类型,构造参数,构造赋值
            string[] variableType = new string[activeColCount];
            string[] variableDesc = new string[activeColCount];
            for (int index = 0; index < activeColCount; index++)
            {
                int col = activecol[index];
                string cellInfo = sheetData.At(TYPE_ROW_INDEX, col);
                if (index > 0)
                {
                    cellInfo = ConvertType(cellInfo, pass);
                }
                variableType[index] = cellInfo;
                variableDesc[index] = sheetData.At(DESC_ROW_INDEX, col);

                string varName = variableName[index];
                string varType = variableType[index];
                string varDesc = variableDesc[index];

                //定义
                class_para_def += "/// <summary>\n/// " + varDesc + "\n/// </summary>\n";
                class_para_def += "public " + varType + " " + varName + ";\n";

                //构造参数和构造赋值
                parastring += ((index == 0) ? string.Empty : ", ") + varType + " " + varName;
                initstring += "this." + varName + " = " + varName + ";\n";
                if (varType.EndsWith("[]", StringComparison.Ordinal))
                {
                    for (int array_index = 1;
                        (index + 1) < activeColCount && variableName[index + 1].Equals(array_index.ToString()); array_index++)
                    {
                        index = index + 1;
                    }
                }

                if (IsEnum(varType))
                {
                    string singletype = varType.Replace("[]", string.Empty);
                    enumdict.Add(singletype, new List<string>());
                    string noneval = ConvertToValue(singletype, string.Empty);
                    enumdict[singletype].Add(noneval);
                }
            }
            string keytype = variableType[0];
            string adddata = string.Empty;
            for (int row = DATA_START_INDEX; row < sheetData.rowCount; ++row)
            {
                //生成字典的key（Excel的第一列）
                int col0 = activecol[0];
                string val0 = sheetData.At(row, col0).Replace("\n", "\\n");
                if (val0.StartsWith("_", StringComparison.Ordinal))
                    continue;
                if (keytype.EndsWith("[]", StringComparison.Ordinal))
                {
                    Console.WriteLine("不可以用数组作为Key");
                    return false;
                }
                val0 = ConvertToValue(keytype, val0);

                string rowstring = "root.Add(";

                string keytypehead = string.Empty;
                if (enumdict.ContainsKey(keytype))
                {
                    keytypehead = keytype + ".";
                    if (!enumdict[keytype].Contains(val0))
                        enumdict[keytype].Add(val0);
                }

                rowstring += keytypehead + val0 + ", ";
                rowstring += "new " + class_name + "(" + keytypehead + val0;

                //生成字典的value（Excel的每一行是一个对象，一行中的每个数据对应对象的每一个成员变量）
                for (int index = 1; index < activeColCount; ++index)
                {
                    int col = activecol[index];

                    //获取Excel数据格子对应的类型
                    //string name = variableName[index];
                    string type = variableType[index];
                    string singletype = type.Replace("[]", string.Empty);

                    //获取Excel数据格子内填写的内容（字符串
                    string val = sheetData.At(row, col).Replace("\n", "\\n");
                    val = ConvertToValue(type, val); //如果没有填写，补上默认类型

                    // 如果是需要加密的类型
                    val = TryXvalue(type, val);

                    string typehead = string.Empty;
                    if (enumdict.ContainsKey(singletype)) //如果是枚举类型，积累枚举类型的枚举值
                    {
                        typehead = singletype + ".";
                        if (!enumdict[singletype].Contains(val))
                            enumdict[singletype].Add(val);
                    }

                    if (type.EndsWith("[]", StringComparison.Ordinal)) //如果是数组
                    {
                        string valarray = "new " + type + " {" + typehead + val;
                        if (enumdict.ContainsKey(singletype))
                        {
                            if (!enumdict[singletype].Contains(val))
                                enumdict[singletype].Add(val);
                        }
                        //数组头
                        for (int array_index = 1;
                            (index + 1) < activeColCount && variableName[index + 1].Equals(array_index.ToString()); array_index++)
                        {
                            index = index + 1;

                            int subcol = activecol[index];
                            string subval = sheetData.At(row, subcol).Replace("\n", "\\n");
                            subval = ConvertToValue(type, subval);
                            if (enumdict.ContainsKey(singletype))
                            {
                                if (!enumdict[singletype].Contains(subval))
                                    enumdict[singletype].Add(subval);
                            }
                            subval = TryXvalue(type, subval);
                            valarray += ", " + typehead + subval;
                        }
                        //数组尾
                        valarray += "}";
                        rowstring += ", " + valarray;
                    }
                    else
                    {
                        rowstring += ", " + typehead + val; //(可能的数值前缀(枚举)+数值)
                    }
                }
                rowstring += "));\n";
                adddata += rowstring;
            }

            string class_reader_name = class_name + "Reader";
            class_reader += "class " + class_reader_name + "{" + "\n";
            class_reader += "static " + class_reader_name + " instance;" + "\n";
            class_reader += "static object syncRoot = new object();" + "\n";
            class_reader += "public static " + class_reader_name + " Instance{get{if (instance == null){lock (syncRoot){if (instance == null){instance = new " + class_reader_name + "();instance.Load();}}}return instance;}}" + "\n";
            string dict_type = "Dictionary<" + keytype + ", " + class_name + ">";
            class_reader += dict_type + " root = new " + dict_type + "();\n";
            class_reader += "void Load(){" + "\n";

            if (pass == 0)
            {
                class_reader += adddata;
            }
            else if (pass == 2)
            {
                class_reader += adddata;
            }
            else
            {
                class_reader += "root = (" + dict_type + ")MMFramework.DataTools.LoadFromFile(\"" + class_name + "\");\n";
            }

            class_reader += "}" + "\n";

            //Reader Get
            class_reader += "public " + class_name + " GetReadData(" + keytype + " ID){" + "\n";
            class_reader += "if (root.ContainsKey(ID))" + "\n";
            class_reader += "return root[ID];" + "\n";
            class_reader += "else{" + "\n";
            if (!class_name.Equals("StyleData"))
            {
                class_reader += "object obj = MMFramework.ModifyExcelModule.Instance.GetModifyedData(ID);" + "\n";
                class_reader += "if (obj != null)return obj as " + class_name + ";" + "\n";
            }
            class_reader += "Debug.LogError(\"在表格 " + class_name + "中没有找到ID\" + ID);" + "\n";
            class_reader += "return null;}" + "\n";
            class_reader += "}" + "\n";

            //写文件
            string content = string.Empty;
            if (pass == 0)
            {
                string datafilename = class_name + ".bytes";
                content += "MMFramework.DataTools.SaveToFile(root, System.IO.Path.Combine(path,\"" + datafilename + "\"));";
            }
            class_reader += "public void WriteToFile(string path){" + content + "}\n";
            //写文件完成

            class_reader += "public int GetCount(){" + "\n";
            class_reader += "return root.Count;" + "\n";
            class_reader += "}" + "\n";

            class_reader += "public List<" + keytype + "> GetDataKeys(){" + "\n";
            class_reader += "return new List<" + keytype + ">(root.Keys);" + "\n";
            class_reader += "}" + "\n";
            class_reader += "public Dictionary<string, string> GetReadDictionary(" + keytype + " key)" + "\n";
            class_reader += "{Dictionary<string, string> pairs = new Dictionary<string, string>();" + "\n";
            class_reader += class_name + " data = GetReadData(key);" + "\n";
            class_reader += "Type type = data.GetType();" + "\n";
            class_reader += "System.Reflection.FieldInfo[] filedinfos = type.GetFields();" + "\n";
            class_reader += "for (int i = 0; i < filedinfos.Length; i++)" + "\n";
            class_reader += "{System.Reflection.FieldInfo field = filedinfos[i];" + "\n";
            class_reader += "pairs.Add(field.Name, field.GetValue(data).ToString());}" + "\n";
            class_reader += "return pairs;}" + "\n";
            class_reader += "}" + "\n";
            class_reader += "public static " + class_name + " GetData(" + keytype + " ID){" + "\n";
            class_reader += "return " + class_reader_name + ".Instance.GetReadData(ID);" + "\n";
            class_reader += "}" + "\n";
            class_reader += "public static Dictionary<string, string> GetDictionary(" + keytype + " key)" + "\n";
            class_reader += "{ return " + class_reader_name + ".Instance.GetReadDictionary(key);}" + "\n";
            class_reader += "public static int GetNum(){" + "\n";
            class_reader += "return " + class_reader_name + ".Instance.GetCount();" + "\n";
            class_reader += "}" + "\n";
            class_reader += "public static List<" + keytype + "> GetKeys(){" + "\n";
            class_reader += "return " + class_reader_name + ".Instance.GetDataKeys();" + "\n";
            class_reader += "}" + "\n";
            class_reader += "public static void SaveToFile(string path){" + "\n";
            class_reader += class_reader_name + ".Instance.WriteToFile(path);" + "\n";
            class_reader += "}" + "\n";
            class_constructure_def += "public " + class_name + "(" + parastring + "){\n";
            class_constructure_def += initstring;
            class_constructure_def += "}\n";

            //类内枚举
            foreach (var enumitem in enumdict)
            {
                string enumname = enumitem.Key;
                List<string> enumvalues = enumitem.Value;
                enumstring += "public enum " + enumname + "{\n";
                for (int i = 0; i < enumvalues.Count; i++)
                {
                    enumstring += enumvalues[i] + ",\n";
                }
                enumstring += "}\n";
            }

            reader_code = "using System;\n" +
                "using System.Collections.Generic;\n" +
                "using UnityEngine;\n" +
                "[Serializable]\n" +
                "public class " +
                class_name +
                "{\n" +
                enumstring +
                class_para_def +
                class_constructure_def +
                class_reader +
                "\n}";
            return true;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
            return false;
        }
    }

    static string ConvertType(string typename, int pass)
    {
        if (pass == 2)
            return typename;
        else if (typename.StartsWith("int") || typename.StartsWith("float") || typename.StartsWith("bool"))
            return "X" + typename;
        else return typename;
    }

    static string TryXvalue(string typename, string val)
    {
        string ret = string.Empty;
        if (typename == "Xint" || typename == "Xint[]")
        {
            string encryptstr = Xint.TableToEncrypt(val);
            ret = string.Format("\"{0}\"", encryptstr);
        }
        else if (typename == "Xfloat" || typename == "Xfloat[]")
        {
            string encryptstr = Xfloat.TableToEncrypt(val);
            ret = string.Format("\"{0}\"", encryptstr);
        }
        else if (typename == "Xbool" || typename == "Xbool[]")
        {
            string encryptstr = Xbool.TableToEncrypt(val);
            ret = string.Format("\"{0}\"", encryptstr);
        }
        else
        {
            //Not a X type
            ret = val;
        }

        return ret;
    }

    public static bool IsEnum(string typename)
    {
        return typename.ToLower().EndsWith("enum", StringComparison.Ordinal) ||
            typename.ToLower().EndsWith("enum[]", StringComparison.Ordinal);
    }
    public static string ConvertToValue(string type, string str)
    {
        string val = str;
        if ((type.Equals("bool") || type.Equals("bool[]")) && string.IsNullOrEmpty(val))
            val = "FALSE";
        else if (IsEnum(type) && string.IsNullOrEmpty(val))
            val = "None";
        else if (!type.Equals("string") && !type.Equals("string[]") && string.IsNullOrEmpty(val))
            val = "0";

        if (type.Equals("string") || type.Equals("string[]"))
            val = "\"" + val + "\"";
        else if (type.Equals("float") || type.Equals("float[]"))
            val = val + "f";
        else if (type.Equals("bool") || type.Equals("bool[]"))
            val = val.ToLower();
        return val;
    }
}