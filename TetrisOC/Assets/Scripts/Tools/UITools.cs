using System.Collections.Generic;
using MMFramework;
using System.Numerics;
using UnityEngine;
namespace MMGame
{
    public static class UITools
    {
        public static float LengthPixel = 100.0f;

        static string[] postfixes = new string[] {
            "", "K", "M", "G", "B", "T"
            };
        public static string ShowBigNumber(System.Numerics.BigInteger big)
        {
            if (big.Equals(0))
                return 0.ToString();
            double d = BigInteger.Log10(big);
            int num = UnityEngine.Mathf.FloorToInt(System.Convert.ToSingle(d));
            if (num > 1)
                num--;
            int index = num / 3;
            int num2 = index * 3;
            // Debug.LogError(big + ":" + num2);
            BigInteger s = big / BigInteger.Pow(10, num2);
            // Debug.Log(big.ToString() + "/" + BigInteger.Pow(10, num2) + "=" + s.ToString("N0") + "  " + postfixes[index]);
            // string postfix = postfixes[index];

            // Debug.Log(index);
            string postfix = string.Empty;
            if (index < postfixes.Length)
                postfix = postfixes[index];
            else
            {
                int i = index - postfixes.Length;
                char i1 = (char)((int)'a' + i / 26);
                char i2 = (char)('a' + i % 26);
                postfix = i1.ToString() + i2.ToString();
            }
            return s.ToString("N0") + " " + postfix;
        }
        public static string ShowIntNumber(int big)
        {
            return string.Format("0:N", big);
        }
        public static string ShowIntNumber(float big)
        {
            return string.Format("{0:N0}", Mathf.FloorToInt(big));
        }
        public static string ShowNumber(float val)
        {
            if (val > 99)
                return val.ToString("F0");
            return val.ToString("G2");
        }
    }
}