using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
namespace MMFramework
{
    public static class DataTools
    {
        public static void SaveToFile(object obj, string fileout)
        {
            string oldcontent = string.Empty;
            if (File.Exists(fileout))
            {
                StreamReader sr = new StreamReader(fileout);

                oldcontent = sr.ReadToEnd();
                sr.Close();
                sr.Dispose();
            }

            using (FileStream fs = new FileStream(fileout, FileMode.OpenOrCreate))
            {
                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(fs, obj);
                fs.Flush();
            }

            {
                StreamReader sr = new StreamReader(fileout);

                string content = sr.ReadToEnd();

                sr.Close();
                sr.Dispose();

                if (!oldcontent.Equals(content))
                    Debug.Log(Path.GetFileName(fileout));
            }
        }

        public static object LoadFromFile(string fileout)
        {
            TextAsset ta = Resources.Load<TextAsset>("data/" + fileout);
            byte[] bytes = ta.bytes;
            using (MemoryStream fs = new MemoryStream(bytes))
            {
                BinaryFormatter bf = new BinaryFormatter();
                return bf.Deserialize(fs);
            }
        }

        public static bool HasStruct(string dataname)
        {
            return PlayerPrefs.HasKey(dataname);
        }

        public static void SaveStruct<T>(string dataname, T data)
        {
            IFormatter formatter = new BinaryFormatter();
            MemoryStream stream = new MemoryStream();
            formatter.Serialize(stream, data);
            stream.Position = 0;
            byte[] buffer = new byte[stream.Length];
            stream.Read(buffer, 0, buffer.Length);
            stream.Flush();
            stream.Close();
            string bagData = System.Convert.ToBase64String(buffer);
            PlayerPrefs.SetString(dataname, bagData);
        }

        public static T LoadStruct<T>(string dataname)
        {
            string bagData = PlayerPrefs.GetString(dataname);
            IFormatter formatter = new BinaryFormatter();
            byte[] buffer = System.Convert.FromBase64String(bagData);
            MemoryStream stream = new MemoryStream(buffer);
            T data = (T)formatter.Deserialize(stream);
            stream.Flush();
            stream.Close();
            return data;
        }

        public static void RemoveStruct(string dataname)
        {
            PlayerPrefs.DeleteKey(dataname);
        }
    }
}