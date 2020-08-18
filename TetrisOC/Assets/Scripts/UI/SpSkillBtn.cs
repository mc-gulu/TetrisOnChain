using MMFramework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace MMGame
{
    public class SpSkillBtn : MonoBehaviour
    {
        public Button Button;
        public Slider HpBar;
        public Slider EnergyBar;
        public Text Name;
        public Image IconImg;
        public Image BGImg;
        public Sprite[] BGSprites;

        private CreatureRuntimeData data;
        public void Init(int index)
        {
            data = BattlefieldModule.Instance.GetCreatureRuntime(index);
            Name.text = data.index.ToString();
            IconImg.sprite = CacheModule.Instance.LoadSprite(CreatureData.GetData(data.baseInfo.creatureID).BigIconPath);
            IconImg.SetNativeSize();
            Button.onClick.AddListener(() =>
            {
                data.GetSpSkill().use = true;
            });
            SetBackground(data.baseInfo.star / 2);
        }
        public void SetBackground(int index)
        {
            if (BGImg.sprite != BGSprites[index])
                BGImg.sprite = BGSprites[index];
        }
        bool pause = false;
        private void Update()
        {
            if (data != null)
            {
                if (data.runtimeState != RuntimeState.Active)
                {
                    HpBar.gameObject.SetActive(false);
                    EnergyBar.gameObject.SetActive(false);
                    Button.interactable = false;
                    SetBackground(0);
                }
                else
                {
                    Button.interactable = false;
                    HpBar.value = data.Hp / data.MaxHP;
                    if (data.GetSpSkill() != null)
                    {
                        EnergyBar.value = data.GetSpSkill().curEnergy / data.GetSpSkill().data.NeedEnergy;
                        if (EnergyBar.value >= 1)
                        {
                            Button.interactable = true;
                            if (!pause && LogicModule.Instance.IsPrepared(6))
                            {
                                pause = true;
                                RootModule.Instance.PauseAll(true);
                                LogicModule.Instance.Active(6);
                            }
                        }
                    }
                }
            }
        }
    }
}