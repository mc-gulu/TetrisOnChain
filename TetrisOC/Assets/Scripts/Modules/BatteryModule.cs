using System.Collections.Generic;
using MMFramework;
using UnityEngine;
using LitJson;
using UnityEngine.UI;
namespace MMGame
{
    public class BatteryModule : MonoBehaviour, BaseModule
    {
        public static BatteryModule Instance
        {
            get
            {
                return RootModule.Instance.GetModule<BatteryModule>();
            }
        }

        public void Init()
        {

        }

        private void OnEnable()
        {

        }

        private void OnDisable()
        {

        }
    }
}