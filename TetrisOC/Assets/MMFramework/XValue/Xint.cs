using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
[Serializable]
public class Xint : Xvalue<int>, IFormattable
{
    public override int ConvertFromString(string strvalue)
    {
        return Int32.Parse(strvalue);
    }

    public override string ConvertToString(int value)
    {
        return value.ToString();
    }

    public Xint(string value)
    {
        Internal = value;
    }

    private Xint(int value)
    {
        Value = value;
    }

    public static implicit operator Xint(string value)
    {
        return new Xint(value);
    }
    //int->set
    public static implicit operator Xint(int value)
    {
        return new Xint(value);
    }

    public static Xint operator ++(Xint input)
    {
        return Increment(input, 1);
    }

    public static Xint operator --(Xint input)
    {
        return Increment(input, -1);
    }

    private static Xint Increment(Xint input, int increment)
    {
        input = input.Value + increment;
        return input;
    }

    public string ToString(string format)
    {
        return Value.ToString(format);
    }

    public string ToString(IFormatProvider provider)
    {
        return Value.ToString(provider);
    }

    public string ToString(string format, IFormatProvider provider)
    {
        return Value.ToString(format, provider);
    }

    public static int[] ConvertArray(Xint[] array)
    {
        int length = array.Length;
        int[] ret = new int[length];
        for (int i = 0; i < length; i++)
        {
            ret[i] = array[i];
        }
        return ret;
    }
}