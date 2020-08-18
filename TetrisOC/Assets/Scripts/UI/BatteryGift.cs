using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using MMFramework;
namespace MMGame
{
    public class BatteryGift : MonoBehaviour
    {
        public Button button;
        public Text text;
        public GameObject effect;

        void Awake()
        {
            button.onClick.AddListener(delegate
            {
                EventModule.Instance.HandleEvent(EventEnum.BATTERY_GIFT);
            });
            UpdateUI();
        }

        void UpdateUI()
        {
            long count = CountdownModule.Instance.CheckCount(ConfigInGame.BatteryGiftCount, CountdownModule.BatteryGift);
            if (count > 0)
            {
                button.enabled = true;
                text.text = string.Empty;
                effect.SetActive(true);
            }
            else
            {
                button.enabled = false;
                long smalltick = CountdownModule.Instance.LeftTime_SmallTick(ConfigInGame.BatteryGiftCount, CountdownModule.BatteryGift);
                text.text = TimeTools.ShortTime(smalltick, false);
                effect.SetActive(false);
            }
        }

        void OnEnable()
        {
            InvokeRepeating("UpdateUI", 1, 1);
        }

        void OnDisable()
        {
            CancelInvoke("UpdateUI");
        }
    }
}