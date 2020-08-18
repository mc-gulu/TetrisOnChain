using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum OtherSDKFuntionEnum
{
    TapTapForum
}
public interface iSDK
{

    void InitSDK(string channel, string defaultUserID);
    void SetAccount(string accountID);
    bool IsSupportFunction(OtherSDKFuntionEnum enumfunc);
    object CallFunction(OtherSDKFuntionEnum enumfunc, object obj);
}