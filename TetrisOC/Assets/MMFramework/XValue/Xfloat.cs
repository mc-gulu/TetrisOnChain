using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
[Serializable]
public class Xfloat : Xvalue<float>, IFormattable
{
    public override float ConvertFromString(string strvalue)
    {
        return float.Parse(strvalue);
    }

    public override string ConvertToString(float value)
    {
        return value.ToString();
    }

    public Xfloat(string value)
    {
        Internal = value;
    }

    private Xfloat(float value)
    {
        Value = value;
    }

    public static implicit operator Xfloat(string value)
    {
        return new Xfloat(value);
    }

    public static implicit operator Xfloat(float value)
    {
        return new Xfloat(value);
    }

    public static Xfloat operator ++(Xfloat input)
    {
        return Increment(input, 1);
    }

    public static Xfloat operator --(Xfloat input)
    {
        return Increment(input, -1);
    }

    private static Xfloat Increment(Xfloat input, float increment)
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

    public static float[] ConvertArray(Xfloat[] array)
    {
        int length = array.Length;
        float[] ret = new float[length];
        for (int i = 0; i < length; i++)
        {
            ret[i] = array[i];
        }
        return ret;
    }
}