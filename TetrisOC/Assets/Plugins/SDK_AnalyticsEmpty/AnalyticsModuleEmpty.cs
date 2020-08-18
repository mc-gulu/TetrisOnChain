using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace MMFramework
{
    public class AnalyticsModuleEmpty : MonoBehaviour, BaseModule, iAnalytics
    {
        public static AnalyticsModuleEmpty Instance
        {
            get
            {
                return RootModule.Instance.GetModule<AnalyticsModuleEmpty>();
            }
        }

        public void Init()
        {
            Debug.Log("AnalyticsModuleEmpty Init");
        }

        public void InitSDK(string channel)
        {
            Debug.Log("AnalyticsModuleEmpty InitSDK " + channel);
        }
        public void SetAccount(int accountID, string accountName)
        {
            Debug.Log("AnalyticsModuleEmpty SetAccount " + accountID + " " + accountName);
        }
        public void OnChargeRequest(string orderID, string iAPID, float payAmount, string payUnit, double getAmount, string payChannelType)
        {
            Debug.Log("AnalyticsModuleEmpty OnChargeRequest " + orderID);
        }
        public void OnChargeSuccess(string orderID)
        {
            Debug.Log("AnalyticsModuleEmpty OnChargeSuccess " + orderID);
        }
        //获得
        public void OnReward(int value, string reason)
        {
            Debug.Log("AnalyticsModuleEmpty OnReward " + value + " " + reason);
        }
        //花费
        public void OnPurchase(string reason, int count, int value)
        {
            Debug.Log("AnalyticsModuleEmpty OnPurchase " + reason);
        }

        public void OnEvent(string key, Dictionary<string, object> dict)
        {
            Debug.Log("AnalyticsModuleEmpty OnEvent1");
        }

        public void OnEvent(string key, int value)
        {
            Debug.Log("AnalyticsModuleEmpty OnEvent2");
        }

        public void UserLevel(int level)
        {
            Debug.Log("AnalyticsModuleEmpty UserLevel " + level);
        }
        int stageID;
        public void StartStage(int stage)
        {
            Debug.Log("AnalyticsModuleEmpty StartStage " + stage);
        }
        public void EndStage(bool success)
        {
            Debug.Log("AnalyticsModuleEmpty EndStage " + success);
        }
    }
}