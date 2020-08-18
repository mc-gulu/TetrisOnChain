using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface iAnalytics
{
    void InitSDK(string channel);
    void SetAccount(int serverID, string accountID);
    void OnChargeRequest(string orderID, string iAPID, float payAmount, string payUnit, double getAmount, string payChannelType);
    void OnChargeSuccess(string orderID);

    void OnReward(int value, string reason);//获得
    void OnPurchase(string reason, int count, int value);//花费

    void OnEvent(string key, Dictionary<string, object> dict);

    void UserLevel(int level);
    void StartStage(int stage);
    void EndStage(bool success);
}