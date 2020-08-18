using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
[Serializable]
public abstract class Xvalue<T> : IComparable, IComparable<Xvalue<T>>, IEquatable<Xvalue<T>> where T : IComparable, IComparable<T>, IEquatable<T>
{
    //加密
    static string Encrypt(string value)
    {
        return Convert.ToBase64String(Encoding.ASCII.GetBytes(value));
    }

    //解密
    static string Decrypt(string value)
    {
        byte[] bytes = Convert.FromBase64String(value);
        return Encoding.ASCII.GetString(bytes);
    }
    #region Convert

    public abstract T ConvertFromString(string strvalue);
    public abstract string ConvertToString(T t);

    #endregion

    // public static string XKey = "_hurt_me_plenty_";

    // public static string XOR(string key, string input)
    // {
    //     StringBuilder sb = new StringBuilder();
    //     for (int i = 0; i < input.Length; i++)
    //         sb.Append((char)(input[i] ^ key[(i % key.Length)]));
    //     String result = sb.ToString();
    //     return result;
    // }

    [SerializeField]
    private string InternalData;

    protected T Value
    {
        get
        {
            try
            {
                //解密成string
                string strvalue = Decrypt(Internal);
                //string转化成T
                return ConvertFromString(strvalue);
            }
            catch (System.Exception)
            {
                return default(T);
            }
        }
        set
        {
            //T转化成string
            string strvalue = ConvertToString(value);
            //string加密
            Internal = Encrypt(strvalue);
        }
    }

    protected string Internal
    {
        get
        {
            return InternalData;
        }
        set
        {
            InternalData = value;
        }
    }

    public static string TableToEncrypt(string tablevalue)
    {
        return Encrypt(tablevalue);
    }

    public static implicit operator T(Xvalue<T> value)
    {
        return value.Value;
    }

    public override int GetHashCode()
    {
        return Value.GetHashCode();
    }

    public override string ToString()
    {
        return Value.ToString();
    }

    public override bool Equals(object obj)
    {
        if (obj is Xvalue<T>)
            return Equals((Xvalue<T>)obj);
        else if (obj is T)
            return Equals((T)obj);
        else
            return false;
    }

    public bool Equals(Xvalue<T> obj)
    {
        T val1 = Value;
        T val2 = obj.Value;
        return val1.Equals(val2);
    }

    public bool Equals(T obj)
    {
        return Value.Equals(obj);
    }

    public int CompareTo(Xvalue<T> other)
    {
        return Value.CompareTo(other.Value);
    }

    public int CompareTo(T other)
    {
        return Value.CompareTo(other);
    }

    public int CompareTo(object obj)
    {
        if (obj is Xvalue<T>)
            return Value.CompareTo(((Xvalue<T>)obj).Value);
        else if (obj is int)
            return Value.CompareTo((T)obj);
        else if (obj == null)
            return 1;
        else
            throw new ArgumentException("Argument must be int");
    }
}