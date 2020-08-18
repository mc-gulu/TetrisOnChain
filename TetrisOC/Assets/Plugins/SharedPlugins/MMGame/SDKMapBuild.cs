#if UNITY_EDITOR
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace MMFramework
{
    public class SDKMapBuild
    {
        public static List<iBuild> BuildSDK
        {
            get
            {
                List<iBuild> list = new List<iBuild>();
                // list.Add(SDKMap.AccountBuild);
                list.Add(SDKMap.AdBuild);
                list.Add(SDKMap.AnalyticsBuild);
                // list.AddRange(SDKMap.SDKBuilds);
                return list;
            }
        }
    }
}
#endif