using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
[Serializable]
public class Xbool : Xvalue<bool>
{
    public override bool ConvertFromString(string strvalue)
    {
        return bool.Parse(strvalue);
    }

    public override string ConvertToString(bool value)
    {
        return value.ToString();
    }

    public Xbool(string value)
    {
        Internal = value;
    }

    private Xbool(bool value)
    {
        Value = value;
    }

    public static implicit operator Xbool(string value)
    {
        return new Xbool(value);
    }

    public static implicit operator Xbool(bool value)
    {
        return new Xbool(value);
    }

    public static Xbool operator !(Xbool input)
    {
        input = !input.Value;
        return input;
    }

    public string ToString(IFormatProvider provider)
    {
        return Value.ToString(provider);
    }
}