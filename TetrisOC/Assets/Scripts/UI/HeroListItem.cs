using MMFramework;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace MMGame
{
    [RequireComponent(typeof(HeroItem))]
    public class HeroListItem : MonoBehaviour
    {
        Button button;
        int careerNum;
        int eleNum;
        int id;
        Action action;
        /// <summary>
        /// 敌人假数据显示
        /// </summary>
        /// <param name="cid"></param>
        public void InitEnimy(int cid) 
        {
            GetComponent<HeroItem>().InitEnimy(cid);
            var data = new RealHeroData() { creatureid = cid };
            Init(null, data);
        }
        /// <summary>
        /// 友方真数据显示
        /// </summary>
        /// <param name="hid"></param>
        /// <param name="btnAction"></param>
        public void InitHero(int hid, Action btnAction)
        {
            id = hid;
            GetComponent<HeroItem>().InitHero(hid);
            var data = DataModule.Instance.GetHeroData(hid);
            Init(btnAction, data);
        }
        private void Init(Action btnAction, RealHeroData data)
        {
            button = GetComponent<Button>();
            action = btnAction;
            var cdata = CreatureData.GetData(data.creatureid);
            careerNum = cdata.Career;
            eleNum = cdata.Element;
            //点击相应
            button.onClick.AddListener(() => { action?.Invoke(); });
        }
        public void ResetData(System.Enum noticeID, object[] objects)
        {
            int heroid = (int)objects[0];
            if (heroid == id)
            {
                button.onClick.RemoveAllListeners();
                InitHero(heroid, action);
            }
        }
        public void SetActive(List<int> careerNums, List<int> eleNums)
        {
            gameObject.SetActive((careerNums.Contains(careerNum) || careerNums.Count == 0) && (eleNums.Contains(eleNum) || eleNums.Count == 0));
            if (gameObject.activeSelf)
            {
                ResetData(null, new object[] { id });
            }
        }
        public void TeamRemove(System.Enum noticeID, object[] objects)
        {
            if ((int)objects[1] == id)
            {
                transform.Find("Select").gameObject.SetActive(false);
            }
        }
        private void OnEnable()
        {
            NoticeTool.RegisterNotice(NoticeEnum.HEROLV_CHANGED, ResetData);
            NoticeTool.RegisterNotice(NoticeEnum.HERO_RESET, ResetData);
            NoticeTool.RegisterNotice(NoticeEnum.TEAM_REMOVE, TeamRemove);
        }
        private void OnDisable()
        {
            NoticeTool.UnRegisterNotice(NoticeEnum.HEROLV_CHANGED, ResetData);
            NoticeTool.UnRegisterNotice(NoticeEnum.HERO_RESET, ResetData);
            NoticeTool.UnRegisterNotice(NoticeEnum.TEAM_REMOVE, TeamRemove);
        }
    }
}