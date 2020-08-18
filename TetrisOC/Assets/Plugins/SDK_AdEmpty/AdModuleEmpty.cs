using System;
using System.Collections.Generic;
using UnityEngine;
namespace MMFramework
{
    public class AdModuleEmpty : MonoBehaviour, BaseModule, iAd
    {
        public static AdModuleEmpty Instance
        {
            get
            {
                return RootModule.Instance.GetModule<AdModuleEmpty>();
            }
        }
        Action<AdEvent, string> callback = null;
        public void Init()
        {
            // Debug.Log("AdModuleEmpty Init");
        }

        public void SetUser(string userID)
        {

        }

        public void SetErrorCall(System.Action<string> errorcall)
        {

        }

        public void InitSDK(Action<AdEvent, string> callback)
        {
            this.callback = callback;
            // Debug.Log("AdModuleEmpty InitSDK");
        }

        public void ShowReward(int reason)
        {
            // Debug.Log("AdModuleEmpty ShowReward");
            if (callback != null)
                callback(AdEvent.onShowSuccess, string.Empty);
        }

        public bool Ready()
        {
            // Debug.Log("AdModuleEmpty Ready");
            return false;
        }

        public void LoadAd()
        {
            // Debug.Log("AdModuleEmpty LoadAd");
        }

        public List<string> GetNesPermissions()
        {
            return new List<string>();
        }

        public List<string> GetOptPermissions()
        {
            return new List<string>();
        }
    }
}