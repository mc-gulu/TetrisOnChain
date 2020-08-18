using MMFramework;
using UnityEngine;
using UnityEngine.UI;

namespace MMGame
{
    public class NextFloorFrame : MMFrame
    {
        public Text LastText, CurText;

        public override void Init(object[] objects)
        {
            int lv = DataModule.Instance.MainLv;
            int lastlv = lv - 1;
            string localstr = LocalModule.Instance.GetValue(StringConfig.PerSecond);
            LastText.text = string.Format(string.Format(localstr, CalculateTool.Calculate2BigInt(lastlv, FloorFightData.GetData(lastlv).GoldSecond)));
            CurText.text = string.Format(string.Format(localstr, CalculateTool.Calculate2BigInt(lv, FloorFightData.GetData(lv).GoldSecond)));
            StartCoroutine(TimeTools.DelayCallback(1f, () =>
            {
                HideFrame(FrameData.FrameEnum.NextFloorFrame, this);
            }));
        }
    }
}