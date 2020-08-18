using System.Collections.Generic;
using MMFramework;
using UnityEngine;
using LitJson;
using UnityEngine.UI;
namespace MMGame
{
    public class LotteryModule : MonoBehaviour, BaseModule
    {
        public static LotteryModule Instance
        {
            get
            {
                return RootModule.Instance.GetModule<LotteryModule>();
            }
        }

        public void Init()
        {

        }

        public List<ItemObj> EventLottery(int lotteryIndex)
        {

            Debug.LogError(lotteryIndex);

            List<ItemObj> drops = Lottery(lotteryIndex);
            ItemModule.Instance.GetDrop(drops);

            LotteryData lottery = LotteryData.GetData(lotteryIndex);
            int times = DataModule.Instance.Get(lottery.Tag, 0);
            DataModule.Instance.Set(lottery.Tag, times + 1);

            if (lotteryIndex.Equals(ConfigInGame.One_AdLotteryID))
            {
                TimeLeftCountModule.Instance.Eat((int)TimeLeftCountModule.IndexType.LotteryAd);
            }

            return drops;
        }

        public List<ItemObj> Lottery(int lotteryindex)
        {
            float percent = GetPercent(lotteryindex);
            bool isgood = RandomTools.Rand1(percent);

            LotteryData lottery = LotteryData.GetData(lotteryindex);

            int dropID = isgood ? lottery.DropGood : lottery.DropNormal;

            if (isgood)
            {
                DataModule.Instance.Set(lottery.Tag, 0);
            }

            return ItemTools.GetDrops(dropID);
        }

        public static float GetPercent(int lotteryID)
        {
            LotteryData lottery = LotteryData.GetData(lotteryID);
            int times = DataModule.Instance.Get(lottery.Tag, 0);
            float percent = lottery.GoodBasePercent + lottery.GoodPerPercent * times;
            return percent;
        }

    }
}