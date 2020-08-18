using MMFramework;
using MMGame;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
namespace MMGame
{
    public class LotteryFrame : MMFrame
    {
        public Button tenbtn;

        public Text oneAdCostText, onePayCostText, tenCostText;

        public GameObject adnode;
        public Button oneadbtn;

        public GameObject onepaynode;
        public Button onepaybtn;

        public Text percentText;
        public Scrollbar bar;

        public Text leftcounttext;

        public override void Init(object[] objects)
        {
            tenbtn.onClick.AddListener(delegate
            {
                string tips = string.Empty;
                if (!CostTool.CostCanAfford(ConfigInGame.TenPayCostID, ref tips))
                {
                    MMFrame.ShowTips(StringConfig.Tips_Title, tips);

                }
                else if (HeroModule.Instance.HeroListOverMax())
                {
                    MMFrame.ShowTips(StringConfig.Tips_Title, StringConfig.HeroBagMax);
                }
                else
                {
                    EventModule.Instance.HandleEvent(EventEnum.LOTTERY, ConfigInGame.Ten_LotteryID, ConfigInGame.TenPayCostID);
                }
            });

            oneadbtn.onClick.AddListener(delegate
            {
                int count = TimeLeftCountModule.Instance.GetCount((int)TimeLeftCountModule.IndexType.LotteryAd);
                if (HeroModule.Instance.HeroListOverMax())
                {
                    MMFrame.ShowTips(StringConfig.Tips_Title, StringConfig.HeroBagMax);
                }
                else if (count > 0)
                {
                    EventModule.Instance.HandleEvent(EventEnum.LOTTERY, ConfigInGame.One_AdLotteryID);
                }
            });

            onepaybtn.onClick.AddListener(delegate
            {
                string tips = string.Empty;
                if (!CostTool.CostCanAfford(ConfigInGame.OnePayCostID, ref tips))
                {
                    MMFrame.ShowTips(StringConfig.Tips_Title, tips);

                }
                else if (HeroModule.Instance.HeroListOverMax())
                {
                    MMFrame.ShowTips(StringConfig.Tips_Title, StringConfig.HeroBagMax);
                }
                else
                {
                    EventModule.Instance.HandleEvent(EventEnum.LOTTERY, ConfigInGame.One_PayLotteryID, ConfigInGame.OnePayCostID);
                }
            });

            UpdateUI();

            oneAdCostText.text = "$";
            onePayCostText.text = CostTool.CostString(ConfigInGame.OnePayCostID);
            tenCostText.text = CostTool.CostString(ConfigInGame.TenPayCostID);

        }

        bool IsAd()
        {
            int count = TimeLeftCountModule.Instance.GetCount((int)TimeLeftCountModule.IndexType.LotteryAd);
            return count > 0;
        }

        void UpdateUI()
        {
            onepaynode.SetActive(!IsAd());
            adnode.SetActive(IsAd());
            float percent = LotteryModule.GetPercent(ConfigInGame.Ten_LotteryID);
            bar.size = percent;

            percentText.text = string.Format(StringConfig.LotteryBetterPercent, percent);

            int count = TimeLeftCountModule.Instance.GetCount((int)TimeLeftCountModule.IndexType.LotteryAd);
            leftcounttext.text = string.Format(StringConfig.LotteryLeftCount, count);
        }

        void OnHandler(System.Enum noticeID, object[] objects)
        {
            UpdateUI();
        }

        private void OnEnable()
        {
            NoticeTool.RegisterNotice(NoticeEnum.UPDATE_LOTTERY, OnHandler);
        }

        private void OnDisable()
        {
            NoticeTool.UnRegisterNotice(NoticeEnum.UPDATE_LOTTERY, OnHandler);
        }
    }
}