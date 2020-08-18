using System.Collections;
using System.Collections.Generic;
using MMFramework;
using UnityEngine;
using UnityEngine.UI;
namespace MMGame
{
    public class DrillingMachine : MonoBehaviour
    {
        // public GameObject batteryin, batteryout, normalmachine, highmachine;
        public Text text;
        public Text addcache_text;
        public GameObject textcontent;

        public GameObject kuangji;
        public Animator animator;
        public ParticleSystem coinps;
        public ParticleSystem groundcoinps;
        public GameObject batteryout;

        public Button button;

        public Text groundgold;
        float groundmoney = 0;

        void Awake()
        {
            // normalmachine.SetActive(false);
            // highmachine.SetActive(false);

            // batteryin.SetActive(false);
            // batteryout.SetActive(false);

            button.onClick.AddListener(delegate
            {
                System.Numerics.BigInteger gold = DrillingModule.Instance.CalculateGroundGold();
                if (!gold.IsZero)
                {
                    addcache_text.text = string.Format("+{0}", gold.ToString());
                    GameObject go = ObjTools.CopyGameObject(textcontent, addcache_text.gameObject);
                    go.SetActive(true);
                    StartCoroutine(TimeTools.DelayCallback(1f, delegate
                    {
                        UnityEngine.Object.Destroy(go);
                    }));
                    EventModule.Instance.HandleEvent(EventEnum.HARVEST_GROUNDGOLD);
                }
                NoticeTool.Broadcast(NoticeEnum.GUILD_GET_GOLD);

            });
        }

        void HarvestUI()
        {
            ParticleSystem ps = coinps.subEmitters.GetSubEmitterSystem(0);
            ParticleSystem.Particle[] p = new ParticleSystem.Particle[ps.particleCount + 1];
            int l = ps.GetParticles(p);
            Vector2[] poslist = new Vector2[l];

            for (int i = 0; i < l; i++)
            {
                Vector3 pos = p[i].position;
                poslist[i] = ps.transform.TransformPoint(pos);
            }

            coinps.Clear();
            NoticeTool.Broadcast(NoticeEnum.FLY_RESOURCES, new object[] { 3000, poslist, 0 });
        }

        public Vector3 World2UI(Vector3 worldpos)
        {
            Vector3 ScreenPos = Camera.main.WorldToScreenPoint(worldpos);
            return ScreenPos;
        }

        float deltatime = 0f;
        int beginnum = 0;
        void Update()
        {
            if (DrillingModule.inited)
            {
                deltatime += Time.deltaTime;

                int particle = DrillingModule.Instance.OneDrop();
                coinps.maxParticles = particle;
                groundcoinps.maxParticles = DrillingModule.Instance.GroundNeedParticles();
                if (DrillingModule.Instance.IsEnergy())
                {
                    groundcoinps.maxParticles *= 10;
                }
                if (particle != 0 && beginnum < 5)
                {
                    coinps.maxParticles = groundcoinps.maxParticles - groundcoinps.particleCount;
                }

                bool isenergy = DrillingModule.Instance.IsEnergy();
                long updatetick = isenergy ? ConfigInGame.DrillingTick_Battery : ConfigInGame.DrillingTick;
                float updatetime = (float)updatetick / (float)ConfigInGame.SmallTickPerSecond;
                if (deltatime > updatetime)
                {
                    deltatime -= updatetime;

                    beginnum++;

                    // if (animator.GetCurrentAnimatorStateInfo(0).IsName("kuangji_hight"))
                    // {
                    //     coinps.maxParticles = 20;
                    // }
                    // else if (animator.GetCurrentAnimatorStateInfo(0).IsName("kuangji_idle"))
                    // {
                    //     coinps.maxParticles = 1;
                    // }

                    string timestr = DrillingModule.Instance.GetBatteryLefttime();
                    if (string.IsNullOrEmpty(timestr))
                        text.gameObject.SetActive(false);
                    else
                    {
                        text.gameObject.SetActive(true);
                        text.text = timestr;
                    }

                    groundgold.text = DrillingModule.Instance.CalculateGroundGold().ToString();

                }
            }
        }

        void Effect(bool isin)
        {
            string statename = isin ? "kuangji_battery_in" : "kuangji_battery_out";
            animator.Play(statename);
            if (!isin)
            {
                batteryout.SetActive(false);

                StartCoroutine(TimeTools.DelayCallback(0.1f, delegate
                {
                    batteryout.SetActive(true);
                }));
            }
        }

        void InHandler(System.Enum noticeEnum, object[] objects)
        {
            Effect(true);
        }

        void OutHandler(System.Enum noticeEnum, object[] objects)
        {
            Effect(false);
        }

        // void AddHandler(System.Enum noticeEnum, object[] objects)
        // {
        //     int num = (int)objects[0];
        //     addcache_text.text = string.Format("+{0}", num);
        //     GameObject go = ObjTools.CopyGameObject(textcontent, addcache_text.gameObject);
        //     go.SetActive(true);
        //     StartCoroutine(TimeTools.DelayCallback(1f, delegate
        //     {
        //         UnityEngine.Object.Destroy(go);
        //     }));
        // }

        void HandleHarvestUI(System.Enum noticeEnum, object[] objects)
        {
            HarvestUI();
        }

        void GetCacheEvent()
        {
            EventModule.Instance.HandleEvent(EventEnum.SYNC_CACHE);
        }

        void OnEnable()
        {
            NoticeTool.RegisterNotice(NoticeEnum.HARVESTGROUND_UI, HandleHarvestUI);
            NoticeTool.RegisterNotice(NoticeEnum.BATTERY_IN, InHandler);
            NoticeTool.RegisterNotice(NoticeEnum.BATTERY_OUT, OutHandler);
            // NoticeTool.RegisterNotice(NoticeEnum.GOLD_CACHE_ADD, AddHandler);
            // InvokeRepeating("GetCacheEvent", ConfigInGame.SyncSecond, ConfigInGame.SyncSecond);
        }

        void OnDisable()
        {
            NoticeTool.UnRegisterNotice(NoticeEnum.HARVESTGROUND_UI, HandleHarvestUI);
            NoticeTool.UnRegisterNotice(NoticeEnum.BATTERY_IN, InHandler);
            NoticeTool.UnRegisterNotice(NoticeEnum.BATTERY_OUT, OutHandler);
            // NoticeTool.UnRegisterNotice(NoticeEnum.GOLD_CACHE_ADD, AddHandler);
            // CancelInvoke("GetCacheEvent");
        }
    }
}