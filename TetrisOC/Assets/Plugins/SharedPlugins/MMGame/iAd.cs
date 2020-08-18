using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum AdEvent
{
    onInitSuccess,
    onInitFailed,
    onLoadSuccess,
    onLoadFailed,
    onShowSuccess,
    onShowFailed,
}
public interface iAd
{
    void SetUser(string userID);
    void InitSDK(System.Action<AdEvent, string> callback);
    void ShowReward(int reason);
    bool Ready();
    List<string> GetNesPermissions();
    List<string> GetOptPermissions();
}