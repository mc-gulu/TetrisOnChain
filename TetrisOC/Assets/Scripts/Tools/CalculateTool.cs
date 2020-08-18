using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

namespace MMGame {
    public class CalculateTool
    {
        private static DataTable calculater = new DataTable();
        private static float e = 2.71828f;

        internal static float CalcByDataTable(string expression)
        {
            object result = calculater.Compute(expression, "");
            return float.Parse(result + "");
        }
        /// <summary>
        /// 计算公式结果,可解析LOG(a,N);POW(a,n);LN(N);FLOOR(a);CEIL(a)。未知数必须仅是x
        /// </summary>
        /// <param name="x"></param>
        /// <param name="formula"></param>
        /// <param name="withMathFunc">是否含需要解析的方法，默认有，没有可节省计算量</param>
        /// <returns></returns>
        private static float CalculateFormula(int x, string formula, bool withMathFunc = true)
        {
            formula = formula.Replace("x", x.ToString());
            if (withMathFunc) return CalcMathFunc(formula);
            else return CalcByDataTable(formula);
        }
        /// <summary>
        /// 动态未知数是x，静态未知数为a,b,c...
        /// </summary>
        /// <param name="x"></param>
        /// <param name="formulaid"></param>
        /// <param name="parameters"></param>
        /// <param name="withMathFunc"></param>
        /// <returns></returns>
        public static float CalculateFormula(int x, int formulaid, float[] parameters, bool withMathFunc = true)
        {
            var formula = MathFormulaData.GetData(formulaid).Formula;
            for (int i = 0; i < parameters.Length; i++)
            {
                formula = formula.Replace(((char)(97 + i)).ToString(), parameters[i].ToString());
            }
            return CalculateFormula(x, formula, withMathFunc);
        }
        public static System.Numerics.BigInteger Calculate2BigInt(int x, string formula) 
        {
            return new System.Numerics.BigInteger(CalculateFormula(x, formula));
        }        
        public static System.Numerics.BigInteger Calculate2BigInt(int formulaid, float[] parameters) 
        {
            return new System.Numerics.BigInteger(CalculateFormula(formulaid, parameters));
        }
        /// <summary>
        /// 仅含有从a开始的参数
        /// </summary>
        /// <param name="formula"></param>
        /// <param name="parameters"></param>
        /// <param name="withMathFunc"></param>
        /// <returns></returns>
        public static float CalculateFormula(int formulaid, float[] parameters, bool withMathFunc = true)
        {
            var formula = MathFormulaData.GetData(formulaid).Formula;
            for (int i = 0; i < parameters.Length; i++)
            {
                formula = formula.Replace(((char)(97 + i)).ToString(), parameters[i].ToString());
            }
            if (withMathFunc) return CalcMathFunc(formula);
            else return CalcByDataTable(formula);
        }
        private static float CalcMathFunc(string str) 
        {
            if (str.Contains("LOG("))
            {
                var startIndex = str.IndexOf("LOG(");
                var endIndex = 0;
                var cutstr = getCutStr(str, startIndex, ref endIndex, 4);
                var commaindex = getMidCommainIndex(cutstr);
                var left = cutstr.Substring(0, commaindex);
                var right = cutstr.Substring(commaindex + 1, cutstr.Length - commaindex - 1);
                var leftres = CalcMathFunc(left);
                var rightres = CalcMathFunc(right);
                var res = Mathf.Log(rightres, leftres);
                str = str.Replace(str.Substring(startIndex, endIndex - startIndex + 1), res.ToString());
                return CalcMathFunc(str);
            }
            else if (str.Contains("LN(")) 
            {
                var startIndex = str.IndexOf("LN(");
                var endIndex = 0;
                var cutstr = getCutStr(str, startIndex, ref endIndex, 3);
                var rightres = CalcMathFunc(cutstr);
                var res = Mathf.Log(rightres, e);
                str = str.Replace(str.Substring(startIndex, endIndex - startIndex + 1), res.ToString());
                return CalcMathFunc(str);
            }
            else if (str.Contains("POW("))
            {
                var startIndex = str.IndexOf("POW(");
                var endIndex = 0;
                var cutstr = getCutStr(str, startIndex, ref endIndex, 4);
                var commaindex = getMidCommainIndex(cutstr);
                var left = cutstr.Substring(0, commaindex);
                var right = cutstr.Substring(commaindex + 1, cutstr.Length - commaindex - 1);
                var leftres = CalcMathFunc(left);
                var rightres = CalcMathFunc(right);
                var res = Mathf.Pow(leftres, rightres);
                str = str.Replace(str.Substring(startIndex, endIndex - startIndex + 1), res.ToString());
                return CalcMathFunc(str);
            }
            else if (str.Contains("FLOOR("))
            {
                var startIndex = str.IndexOf("FLOOR(");
                var endIndex = 0;
                var cutstr = getCutStr(str, startIndex, ref endIndex, 6);
                var inres = CalcMathFunc(cutstr);
                var res = Mathf.Floor(inres);
                str = str.Replace(str.Substring(startIndex, endIndex - startIndex + 1), res.ToString());
                return CalcMathFunc(str);
            }            
            else if (str.Contains("CEIL("))
            {
                var startIndex = str.IndexOf("CEIL(");
                var endIndex = 0;
                var cutstr = getCutStr(str, startIndex, ref endIndex, 5);
                var inres = CalcMathFunc(cutstr);
                var res = Mathf.Ceil(inres);
                str = str.Replace(str.Substring(startIndex, endIndex - startIndex + 1), res.ToString());
                return CalcMathFunc(str);
            }
            else
            {
                return CalcByDataTable(str);
            }
        }
        /// <summary>
        /// 获取两个数据中间分割的括号
        /// </summary>
        /// <param name="cutstr"></param>
        /// <returns></returns>
        private static int getMidCommainIndex(string cutstr)
        {
            var commaindex = 0;
            int bracketGroup = 0;
            for (int i = 0; i < cutstr.Length; i++)
            {
                if (cutstr[i] == ',' && bracketGroup == 0)
                {
                    commaindex = i;
                    break;
                }
                else if (cutstr[i] == '(') bracketGroup++;
                else if (cutstr[i] == ')') bracketGroup--;
            }

            return commaindex;
        }
        /// <summary>
        /// 获取括号里面的内容
        /// </summary>
        /// <param name="str"></param>
        /// <param name="startIndex"></param>
        /// <param name="endIndex"></param>
        /// <param name="startLength"></param>
        /// <returns></returns>
        private static string getCutStr(string str, int startIndex, ref int endIndex, int startLength)
        {
            int bracketGroup = 1;
            for (int i = startIndex + startLength; i < str.Length; i++)
            {
                if (str[i] == '(') bracketGroup++;
                else if (str[i] == ')') bracketGroup--;
                if (bracketGroup == 0)
                {
                    endIndex = i;
                    break;
                }
            }
            var re = str.Substring(startIndex + startLength, endIndex - (startIndex + startLength));
            return re;
        }


        /// <summary>
        /// 求num在n位上的数字,取个位,取十位
        /// </summary>
        /// <param name="num">正整数</param>
        /// <param name="n">所求数字位置(个位 1,十位 2 依此类推)</param>
        public static int FindNum(int num, int n)
        {
            int power = (int)Math.Pow(10, n);
            return (num - num / power * power) * 10 / power;
        }
    }
}
