using MMFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using UnityEngine;

namespace MMGame
{
    class HurtData
    {
        public BaseInfo from;
        public BaseInfo to;
        public int skillid;
        public int buffid;
        public float damage;
        public float time;
        public bool dead;
    }
    public class HeroCountData 
    {
        public int cid;
        public string herocountid;
        public List<float> causedamage = new List<float>();
        public List<float> getdamage = new List<float>();
        public List<float> heal = new List<float>();
        public void AddDamageData(bool cause, int group, float dam) 
        {
            if (group > causedamage.Count - 1)
            {
                for (int i = causedamage.Count - 1; i < group; i++)
                {
                    causedamage.Add(0);
                }
            }
            if (group > getdamage.Count - 1)
            {
                for (int i = getdamage.Count - 1; i < group; i++)
                {
                    getdamage.Add(0);
                }
            }
            if (group > heal.Count - 1)
            {
                for (int i = heal.Count - 1; i < group; i++)
                {
                    heal.Add(0);
                }
            }
            if (dam > 0)
            {
                if (cause)
                    causedamage[group] += dam;
                else
                    getdamage[group] += dam;
            }
            else 
            {
                if (cause)
                {
                    heal[group] -= dam;
                }
            }

        }
        public float WholeCause() 
        {
            return causedamage.Sum();
        }
        public float WholeGet() 
        {
            return getdamage.Sum();
        }
        public float WholeHeal() 
        {
            return heal.Sum();
        }
    }

    public class BattleCountModule : MonoBehaviour, BaseModule
    {
        public static BattleCountModule Instance
        {
            get
            {
                return RootModule.Instance.GetModule<BattleCountModule>();
            }
        }
        private float startTime;
        private List<HurtData> hurtlist;
        private List<float> groupfinishlist;
        private List<HurtData> deaddata;
        public void Init()
        {
        }

        public void BattleStartInit()
        {
            startTime = Time.time;
            hurtlist = new List<HurtData>();
            groupfinishlist = new List<float>();
            deaddata = new List<HurtData>();
        }


        private void OnCreatureHurt(Enum noticeId, object[] objects)
        {
            var tmp = (HurtData)objects[0];
            hurtlist.Add(tmp);
            if (tmp.dead)
            {
                deaddata.Add(tmp);
            }
        }
        private void OnGroupFinish(Enum noticeId, object[] objects)
        {
            groupfinishlist.Add((float)objects[0]);
        }
        private int getdamageAtGroup(float time) 
        {
            if (groupfinishlist.Count == 0)
            {
                return 0;
            }
            for (int i = 0; i < groupfinishlist.Count; i++)
            {
                if (time < groupfinishlist[i])
                {
                    return i;
                }
            }
            return groupfinishlist.Count;
        }
        private void OnEnable()
        {
            NoticeTool.RegisterNotice(NoticeEnum.HURT, OnCreatureHurt);
            NoticeTool.RegisterNotice(NoticeEnum.GROUPFINISH, OnGroupFinish);
        }
        private void OnDisable()
        {
            NoticeTool.UnRegisterNotice(NoticeEnum.HURT, OnCreatureHurt);
            NoticeTool.UnRegisterNotice(NoticeEnum.GROUPFINISH, OnGroupFinish);
        }

#if UNITY_EDITOR
        private void OnGUI()
        {
            if (Input.GetKey(KeyCode.F1))
            {
                var datas = AllPartnerData();
                GUILayout.BeginVertical(style: "box");
                foreach (var item in datas)
                {
                    GUILayout.Label(string.Format("角色 : {0}， 造成伤害 : {1}， 受到伤害 : {2}, 造成治疗 : {3}", item.Value.herocountid, item.Value.WholeCause(), item.Value.WholeGet(), item.Value.WholeHeal()));
                }
                GUILayout.EndVertical();
            }
            else if (Input.GetKey(KeyCode.F2))
            {
                ShowSingle(0);
            }
            else if (Input.GetKey(KeyCode.F3))
            {
                ShowSingle(1);
            }
            else if (Input.GetKey(KeyCode.F4))
            {
                ShowSingle(2);
            }
            else if (Input.GetKey(KeyCode.F5))
            {
                ShowSingle(3);
            }
            else if (Input.GetKey(KeyCode.H))
            {
                GUILayout.BeginVertical(style: "box");
                GUILayout.Label("F1--显示我方角色伤害和承受伤害");
                GUILayout.Label("F2--显示A角色每波伤害和承受伤害");
                GUILayout.Label("F3--显示B角色每波伤害和承受伤害");
                GUILayout.Label("F4--显示C角色每波伤害和承受伤害");
                GUILayout.Label("F5--显示D角色每波伤害和承受伤害");
                GUILayout.EndVertical();
            }
            else 
            {
                GUILayout.BeginVertical(style: "box");
                GUILayout.Label("H");
                GUILayout.EndVertical();
            }
        }

        private void ShowSingle(int num)
        {
            var datas = AllPartnerData();
            GUILayout.BeginVertical(style: "box");
            if (datas.Count > num)
            {
                var item = datas.Values.ToArray()[num];
                GUILayout.Label(string.Format("角色 : {0}", item.herocountid));
                for (int i = 0; i < item.causedamage.Count; i++)
                {
                    GUILayout.Label(string.Format("第{0}波， 造成伤害 : {1}， 受到伤害 : {2}, 造成治疗 : {3}", i + 1, item.causedamage[i], item.getdamage[i], item.heal[i]));
                }
                foreach (var dead in deaddata)
                {
                    var tmpid = dead.to.creatureID + "_" + dead.to.Lv + "_" + dead.to.star;
                    if (tmpid == item.herocountid)
                    {
                        GUILayout.Label("角色死亡");
                    }
                }
            }
            else
            {
                GUILayout.Label("暂无数据");
            }
            GUILayout.EndVertical();
        }
#endif
        public float[] EachMax(Dictionary<string, HeroCountData> datas) 
        {
            float[] arr = new float[3];
            foreach (var item in datas)
            {
                var data = item.Value;
                if (data.WholeCause() > arr[0]) arr[0] = data.WholeCause();
                if (data.WholeGet() > arr[1]) arr[1] = data.WholeGet();
                if (data.WholeHeal() > arr[2]) arr[2] = data.WholeHeal();
            }
            return arr;
        }
        public Dictionary<string, HeroCountData> AllPartnerData() 
        {
            Dictionary<string, HeroCountData> dic = new Dictionary<string, HeroCountData>();
            foreach (var item in hurtlist)
            {
                if (item.to.ctype != CreatureType.partner && item.from.ctype != CreatureType.partner) continue;
                if (item.from.ctype == CreatureType.partner)
                {
                    var id = item.from.creatureID + "_" + item.from.Lv + "_" + item.from.star;
                    if (!dic.ContainsKey(id))
                        dic.Add(id, new HeroCountData() { herocountid = id, cid = item.from.creatureID});
                    dic[id].AddDamageData(true, getdamageAtGroup(item.time), item.damage);
                }
                if (item.to.ctype == CreatureType.partner)
                {
                    var id = item.to.creatureID + "_"  + item.to.Lv +"_"+ item.to.star;
                    if (!dic.ContainsKey(id))
                        dic.Add(id, new HeroCountData() { herocountid = id, cid = item.to.creatureID });
                    dic[id].AddDamageData(false, getdamageAtGroup(item.time), item.damage);
                }
            }
            return dic;
        }
    }
}