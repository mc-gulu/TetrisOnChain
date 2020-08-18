using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
namespace MMFramework
{
    public class AABB
    {
        static public void Show(string key)
        {
            List<int> s1list = new List<int>();
            for (int i = 0; i < key.Length; i++)
            {
                s1list.Add(key[i]);
            }
            List<int> keylist = new List<int>();
            for (int i = 0; i < s1list.Count; i++)
            {
                keylist.Add(s1list[i] - i);
            }
            string showstr = "{";
            for (int i = 0; i < keylist.Count; i++)
            {
                showstr = showstr + keylist[i] + ",";
            }
            showstr = showstr.Remove(showstr.Length - 1);
            showstr = showstr + "}";
            Debug.Log(showstr);
        }

        static public string Secret()
        {
            int[] array = { 49, 115, 47, 119, 91, 47, 89, 102, 113, 112, 85, 98, 93, 84, 97, 93, 89, 80, 92 };
            string s2 = string.Empty;
            for (int i = 0; i < array.Length; i++)
            {
                char c = (char)(array[i] + i);
                s2 = s2 + c;
            }
            return s2;
        }

        static public string EncodeInterweaved(string sourceData, string gid, string secret)
        {
            string t1, t2;
            Interweave(gid, secret, out t1, out t2);
            //DebugTool.LogFormat("P1: {0} {1}", t1, t2);

            string d1 = t1 + sourceData;
            string d2 = MD5(d1);
            //DebugTool.LogFormat("P2: {0} {1}", d1, d2);

            return Encode(d2 + d1, t2);
        }

        public static string MD5(string input)
        {
            // Use input string to calculate MD5 hash
            using (System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create())
            {
                byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                // Convert the byte array to hexadecimal string
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    sb.Append(hashBytes[i].ToString("x2"));
                }
                return sb.ToString();
            }
        }

        static public void Interweave(string s1, string s2, out string t1, out string t2)
        {
            t1 = "";
            t2 = "";
            //byte[] bytes = System.Text.Encoding.Default.GetBytes(s1 + s1.Length.ToString() + s2 + s2.Length.ToString());
            string full = s1 + s1.Length.ToString() + s2 + s2.Length.ToString();
            for (int i = 0; i < full.Length; ++i)
            {
                if (i % 2 == 0)
                {
                    t1 += full[i];
                }
                else
                {
                    t2 += full[i];
                }
            }

            if (t1.Length != t2.Length)
            {
                t2 += "$";
            }
        }

        static public string Encode(string src, string key)
        {

            try
            {
                byte[] data = System.Text.Encoding.Default.GetBytes(src);
                byte[] keys = System.Text.Encoding.Default.GetBytes(key);

                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < data.Length; i++)
                {
                    int n = (0xff & data[i]) + (0xff & keys[i % keys.Length]);
                    sb.Append("@" + n);
                }
                return sb.ToString();
            }
            catch (Exception e)
            {
                return src;
            }

        }

        public static string GetMD5Verify(string input, string gid)
        {
            string data = AABB.EncodeInterweaved(input, gid, "1");
            return MD5(data);
        }
    }
}