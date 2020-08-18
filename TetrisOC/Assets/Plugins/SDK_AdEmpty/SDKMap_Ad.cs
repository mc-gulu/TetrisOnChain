using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace MMFramework
{
    public partial class SDKMap
    {
        public static iAd Ad
        {
            get
            {
                return AdModuleEmpty.Instance;
            }
        }
#if UNITY_EDITOR
        public static iBuild AdBuild
        {
            get
            {
                return new AdModuleEmptyBuild();
            }
        }
#endif
    }
}