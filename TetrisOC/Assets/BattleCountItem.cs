using MMFramework;
using MMGame;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleCountItem : MonoBehaviour
{
    public Image Icon;
    public Text CauseDamText, GetDamText, HealText;
    public Slider CauseDamSlider, GetDamSlider, HealSlider;

    public void Init(HeroCountData data, float[] maxArr)
    {
        var smallIconPath = CreatureData.GetData(data.cid).IconPath;
        Icon.sprite = CacheModule.Instance.LoadSprite(smallIconPath);
        Icon.SetNativeSize();
        Icon.rectTransform.anchoredPosition = Vector2.zero;
        Icon.rectTransform.sizeDelta *= 0.85f;
        CauseDamText.text = UITools.ShowNumber(data.WholeCause());
        GetDamText.text = UITools.ShowNumber(data.WholeGet());
        HealText.text = UITools.ShowNumber(data.WholeHeal());
        CauseDamSlider.value = data.WholeCause() / maxArr[0];
        GetDamSlider.value = data.WholeGet() / maxArr[1];
        HealSlider.value = data.WholeHeal() / maxArr[2];
    }

}
