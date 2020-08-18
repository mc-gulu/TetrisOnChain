using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using MMFramework;

namespace MMGame
{
    public class FlyResourcesFrame : MMFrame
    {
        public RectTransform targgettransform;
        public ParticleSystem ps;
        bool reached = false;//飞出的资源是否到达

        public float scalev = 1.5f;
        public float percent = 0.95f;
        public float max_delta_angle = 20f;
        public float finalspeed = 1000;
        public float speeddelta = 20f;
        public float scalepos = 26;

        Canvas canvas;
        Camera camera;

        public override void Init(object[] objects)
        {
            ps.Stop();
        }

        protected override void OnAfterAnimation(FrameAniType aniType)
        {

        }

        void Start()
        {

        }

        public void FlyHandler(System.Enum noticeenum, object[] objects)
        {
            reached = false;
            MainTopBar topbar = (MainTopBar)MMFrameManager.GetShared().GetFrame(FrameData.FrameEnum.MainTopBar);
            targgettransform = topbar.GetRect(3000);

            int resourcesID = (int)objects[0];
            Vector2[] uiposlist = (Vector2[])objects[1];
            int postype = (int)objects[2];

            int num = uiposlist.Length;
            ParticleSystem.Particle[] p = new ParticleSystem.Particle[num];
            ps.Emit(num);

            int l = ps.GetParticles(p);
            for (int i = 0; i < num; i++)
            {
                Vector3 pos = uiposlist[i];
                p[i].position = postype == 0 ? ObjTools.Worldpos2UIpos(pos) : pos;
            }
            ps.SetParticles(p, num);
        }

        void LateUpdate()
        {
            if (ps == null || targgettransform == null)
            {
                return;
            }

            ParticleSystem.Particle[] p = new ParticleSystem.Particle[ps.particleCount + 1];
            int l = ps.GetParticles(p);

            int j = 0;

            float radius = targgettransform.sizeDelta.x / 2;

            //for each particle
            while (j < l)
            {
                Vector3 tarv = targgettransform.position - p[j].position;
                tarv.z = 0;
                float distance = tarv.magnitude;
                if (distance < radius)
                {
                    p[j].remainingLifetime = 0;
                    j++;
                    if (!reached)
                    {
                        reached = true;
                        NoticeTool.Broadcast(NoticeEnum.GOLD, new object[] { l });
                    }
                    continue;
                }

                float tarangle = AngleTools.GetAngle(tarv);
                float speedangle = AngleTools.GetAngle(p[j].velocity);

                float final_delta_angle = max_delta_angle * percent;
                float speedline = p[j].velocity.magnitude;
                if (speedline < finalspeed)
                    speedline += speeddelta;
                float newrf = AngleTools.CalculateNewAngle(speedangle, tarangle, final_delta_angle);
                Vector2 speednew = new Vector2(Mathf.Cos(AngleTools.AngleToRadian(newrf)) * speedline,
                                                                       Mathf.Sin(AngleTools.AngleToRadian(newrf)) * speedline);
                p[j].velocity = speednew;
                j++;
            }

            ps.SetParticles(p, l);

        }

        private void OnEnable()
        {
            NoticeTool.RegisterNotice(NoticeEnum.FLY_RESOURCES, FlyHandler);
        }

        private void OnDisable()
        {
            NoticeTool.UnRegisterNotice(NoticeEnum.FLY_RESOURCES, FlyHandler);
        }
    }
}