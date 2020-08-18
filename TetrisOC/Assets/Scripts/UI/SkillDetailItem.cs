using MMFramework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace MMGame 
{
    public class SkillDetailItem : MonoBehaviour
    {
        public Text NameText;
        public Text LvText;
        public Image IconImg;
        public Text DetailText;

        public void Init(int skillgroupid, int lv) 
        {
            int skillID = IDTools.GetSkillID(skillgroupid, lv);
            var sgdata = SkillGroupData.GetData(skillgroupid);
            NameText.text = SkillData.GetData(skillID).Name;
            LvText.text = "LV" + skillID.ToString().Substring(4);
            IconImg.sprite = CacheModule.Instance.LoadSprite(sgdata.Icon);
            IconImg.SetNativeSize();
            DetailText.text = SkillTools.GetSkillDesc(skillgroupid, lv);
        }
    }
}