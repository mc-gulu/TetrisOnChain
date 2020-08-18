using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum AccountEvent
{
    onInitSuccess,
    onInitFailed,
    onLoginSuccess,
    onSwitchAccountSuccess,
    onLoginFailed,
    onLogoutSuccess,
    onPaySuccess,
    onPayFailed,
    onPayCancel,
    onExitSuccess,
    onFuncSuccess,
    onFuncFailed,
}
public enum AccountFunction
{
    GOODS_INFO,
    SET_REGIST_TIME,
}

public interface iAccount
{
    void InitSDK(System.Action<AccountEvent, object> callback, bool review = false);
    void ShowLogin();
    void Logout();
    //void Purchase(string purchaseID, int payvalue, int getvalue, string itemname, string getkey);
    void Purchase(string cpOrderID, string purchaseID, float paymoney, string goodsname, string extra);
    bool HasExitDialog();
    void Exit(bool tips);
    string SDKVersion();
    string ChannelUserName();
    int ChannelID();
    void CreateHero();
    void UseHero();
    void Function(AccountFunction funcenum, params object[] param);
}

public class iAccountUserInfo : iAccountErrorMsg
{
    public string uid;
    public string userName;
    public string token;
}

public class iAccountErrorMsg
{
    public string errMsg;
}

// 支付信息，支付回调中使用
public class iAccountPayResult
{
    public string orderId;
    public string cpOrderId;
    public string extraParam;
}