using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class HomeBtnListUI : MonoBehaviour
{
    public Toggle Toggle;
    public float perBtnHeight;
    public float BaseHeight;
    public Transform BtnParent;
    public int UnOpenShowNum;

    // Start is called before the first frame update
    void Start()
    {
        var rT = GetComponent<RectTransform>();
        rT.sizeDelta = new Vector2(rT.sizeDelta.x, BaseHeight + perBtnHeight * UnOpenShowNum);
        if (UnOpenShowNum < BtnParent.childCount)
        {
            Toggle.onValueChanged.AddListener(ison =>
            {
                if (ison)
                {
                    rT.DOSizeDelta(new Vector2(rT.sizeDelta.x, BaseHeight + (BtnParent.childCount) * perBtnHeight), 0.2f);

                }
                else
                {
                    rT.DOSizeDelta(new Vector2(rT.sizeDelta.x, BaseHeight + UnOpenShowNum * perBtnHeight), 0.2f);
                }
            });
        }
        else 
        {
            Toggle.interactable = false;
        }
    }
}
