using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace MMGame
{
    public interface FightValueInterface
    {
        float CalculateValue(BaseInfo baseinfo, FType ftype);
        List<int> GetAttribIDList(BaseInfo baseinfo, FType ftype);
        FType[] GetMask(BaseInfo baseInfo);
    }
}