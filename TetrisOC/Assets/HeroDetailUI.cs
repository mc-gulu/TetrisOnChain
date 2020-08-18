using MMFramework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace MMGame
{
    public class HeroDetailUI : MonoBehaviour
    {
        public Image IconImg;
        public Text NameText, LvText, HpText, AtkText, DefText, RangeText;
        public Image CareerImg, EleImg;
        public Text CareerText, EleText;
        public StarParentUI ShowStar;
        public Button BuffBtn;
        public SkillDetailItem SPDetailItem, SkillDetailItem;
        public Text LvupCostText, ResetcostText;
        public Text CEText;
        RealHeroData rdata;

        public void Init(int id)
        {
            Show(id);
            BuffBtn.onClick.AddListener(() =>
            {
                MMFrame.ShowFrame(FrameData.FrameEnum.HeroBuffFrame, new object[] { id });
            });
        }

        public void Show(int id)
        {
            rdata = DataModule.Instance.GetHeroData(id);
            var cdata = CreatureData.GetData(rdata.creatureid);
            NameText.text = cdata.Name;
            if (!string.IsNullOrEmpty(cdata.BigIconPath))
            {
                IconImg.sprite = CacheModule.Instance.LoadSprite(cdata.BigIconPath);
                IconImg.SetNativeSize();
            }
            ShowStar.StarByLv(rdata.star);
            CareerImg.sprite = CacheModule.Instance.LoadSprite(PathTools.IconPath, PathTools.CareerIconNames[cdata.Career]);
            CareerText.text = PathTools.CareerNames[cdata.Career];
            EleImg.sprite = CacheModule.Instance.LoadSprite(PathTools.IconPath, PathTools.EleIconNames[cdata.Element]);
            EleText.text = PathTools.EleNames[cdata.Element];
            UpdatePart(0);
        }

        public void UpdatePart(int addLv)
        {
            var newInfo = rdata.GetBaseInfo();
            newInfo.Lv += addLv;
            LvText.text = "Lv." + newInfo.Lv;
            var maxhp = FightValueModule.Instance.CalculateValue(newInfo, FType.MAXHP);
            var atk = FightValueModule.Instance.CalculateValue(newInfo, FType.ATK);
            var def = FightValueModule.Instance.CalculateValue(newInfo, FType.DEF);
            HpText.text = UITools.ShowIntNumber(maxhp);
            AtkText.text = UITools.ShowIntNumber(atk);
            DefText.text = UITools.ShowIntNumber(def);
            var ceNum = CalculateTool.Calculate2BigInt(ConfigInGame.FormulaID_CE, new float[] { atk, maxhp, newInfo.Lv });
            CEText.text = ceNum.ToString();
            //todo 攻击范围文字显示
            var skillgroupids = CreatureData.GetData(newInfo.creatureID).SkillGroupArray;
            SPDetailItem.Init(skillgroupids[0], newInfo.Lv);
            SkillDetailItem.Init(skillgroupids[1], newInfo.Lv);
            ShowCost(newInfo.Lv);
        }
        private void ShowCost(int lv)
        {
            var cost = ItemTools.IconStr(ItemTools.Gold_ItemIndex) + UITools.ShowBigNumber(CalculateTool.Calculate2BigInt(lv, CreatureLevelData.GetData(lv).CostID));
            LvupCostText.text = cost;
            int resetCostID = CreatureLevelData.GetData(lv).ResetCostID;
            ResetcostText.text = CostTool.CostString(resetCostID);
        }
    }
}