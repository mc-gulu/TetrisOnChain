using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace MMFramework
{
    public partial class SDKMap
    {
        public static iAnalytics Analytics
        {
            get
            {
                return AnalyticsModuleEmpty.Instance;
            }
        }
#if UNITY_EDITOR
        public static iBuild AnalyticsBuild
        {
            get
            {
                return new AnalyticsModuleEmptyBuild();
            }
        }
#endif
    }
}
