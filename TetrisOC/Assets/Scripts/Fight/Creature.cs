using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using MMFramework;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace MMGame
{

    public class DisplayMsg
    {
        public float leftTime;
        public CreatureDisplayData data;
        public List<GameObject> gos;
        public DisplayMsg(CreatureDisplayData data)
        {
            this.data = data;
            this.gos = new List<GameObject>();
        }
    }
    public class Creature : MonoBehaviour
    {

        public int index;
        Coroutine fire_coroutine = null;
        public Vector3 TargetPos;
        public BulletLauncher launcher;
        GameObject RepulsionObj;

        Animator creatureAnimator;
        Transform weaponpoint;
        Transform frontpoint;
        Transform backpoint;
        Transform toppoint;
        Transform bottompoint;
        Transform uipoint;
        Transform flipXtrans;
        Transform box;
        SpriteRenderer bodyrenderer;

        CreatureTopbar topbar;

        public static GameObject CreateCreatureFake(Transform parent, RealHeroData rdata, int birthindex)
        {
            var bpoint = new GameObject();
            bpoint.transform.SetParent(parent);
            bpoint.name = "bpoint" + birthindex;

            CreatureData creaturedata = CreatureData.GetData(rdata.creatureid);
            GameObject creatureobj = ObjTools.CreatePrefab(bpoint.transform, creaturedata.PrefabPath);
            Creature creature = creatureobj.GetComponent<Creature>();
            creature.InitFake(rdata, birthindex);
            return bpoint;
        }

        public static GameObject CreateCreature(Transform parent, int index)
        {
            CreatureRuntimeData runtime = BattlefieldModule.Instance.GetCreatureRuntime(index);
            CreatureData creaturedata = CreatureData.GetData(runtime.baseInfo.creatureID);
            GameObject creatureobj = ObjTools.CreatePrefab(parent, creaturedata.PrefabPath);
            Creature creature = creatureobj.GetComponent<Creature>();
            creature.Init(index);
            return creatureobj;
        }

        public void Init(int index)
        {
            // Debug.Log("Init");
            this.index = index;
            CreatureRuntimeData runtime = BattlefieldModule.Instance.GetCreatureRuntime(index);
            Transform bodypoint = ObjTools.FindChild(transform, "body");
            bodyrenderer = bodypoint.GetComponent<SpriteRenderer>();
            weaponpoint = ObjTools.FindChild(transform, "weaponpoint");
            frontpoint = ObjTools.FindChild(transform, "frontpoint");
            backpoint = ObjTools.FindChild(transform, "backpoint");
            toppoint = ObjTools.FindChild(transform, "toppoint");
            bottompoint = ObjTools.FindChild(transform, "bottompoint");
            uipoint = ObjTools.FindChild(transform, "uipoint");
            flipXtrans = ObjTools.FindChild(transform, "flipX");
            creatureAnimator = GetComponent<Animator>();

            box = ObjTools.FindChild(transform, "box");

            // creatureAnimator.runtimeAnimatorController = Resources.Load<RuntimeAnimatorController>(creaturedata.ControllerPath);
            runtime.Regist(this);
            runtime.BirthPos = transform.position;
            OpenRepulsion(runtime.baseInfo.ctype == CreatureType.enimy);
            launcher.bulletparent = transform.parent;

            CreatureData creaturedata = CreatureData.GetData(runtime.baseInfo.creatureID);
            GameObject obj = ObjTools.CreatePrefab(uipoint, "Prefabs/topbar");
            topbar = obj.GetComponent<CreatureTopbar>();
            // topbar.Name = creaturedata.ID.ToString();
            topbar.Name = string.Empty;
            topbar.HpMax = runtime.GetFightValue(FType.MAXHP);
            // topbar.Hp = runtime.Hp;
            AddNewDisplay(CreatureData.GetData(GetCurRuntimeData().baseInfo.creatureID).BornDisplayID, float.NaN);
        }

        public float GetCircle()
        {
            CircleCollider2D circle = box.GetComponent<CircleCollider2D>();
            if (circle != null)
                return circle.radius;
            return 0f;
        }

        public void InitFake(RealHeroData rdata, int birthindex)
        {
            creatureAnimator = GetComponent<Animator>();
            box = ObjTools.FindChild(transform, "box");
            uipoint = ObjTools.FindChild(transform, "uipoint");
            box.gameObject.SetActive(false);
            var ui = ObjTools.CreatePrefab(uipoint, "Prefabs/ui/FakeCreatureUI");
            ui.gameObject.name = "FakeCreatureUI";
            ui.GetComponent<Canvas>().worldCamera = Camera.main;
            ui.GetComponent<Canvas>().sortingLayerName = "top";
            ui.transform.localScale = 0.01f * Vector3.one;
            ui.GetComponent<FakeCreatureUI>().Init(rdata.id, birthindex);
        }
        #region 身上状态
        List<DisplayMsg> displayObjList = new List<DisplayMsg>();
        public void AddNewDisplay(int id, float time)
        {
            if (id == 0) return;
            CreatureDisplayData data = CreatureDisplayData.GetData(id);
            var msg = new DisplayMsg(data);
            Add2Point(frontpoint, data.FrontAdd, msg);
            Add2Point(backpoint, data.BackAdd, msg);
            Add2Point(toppoint, data.TopAdd, msg);
            Add2Point(bottompoint, data.DownAdd, msg);
            msg.leftTime = time;
            displayObjList.Add(msg);
            OnDisplayDicChange();

            AudioModule.Instance.Sound_Display(id);
        }
        public void RemoveDisplay(int id)
        {
            DisplayMsg msg = null;
            for (int i = 0; i < displayObjList.Count; i++)
                if (displayObjList[i].data.CreatureDisplayID == id) { msg = displayObjList[i]; break; }
            if (msg == null) return;
            for (int i = 0; i < msg.gos.Count; i++)
            {
                Destroy(msg.gos[i]);
            }
            displayObjList.Remove(msg);
            OnDisplayDicChange();
        }
        private void OnDisplayDicChange()
        {
            if (displayObjList.Count == 0)
            {
                curAnim = null;
                if (GetCurState() == RuntimeState.Active) ChangeBodyAnim("idle");
                // else ChangeBodyAnim("die");
                // bodyrenderer.color = Color.white;
                return;
            }
            var animmsg = displayObjList.OrderBy(msg => msg.data.ActionPriority).Last();
            if (!string.IsNullOrEmpty(animmsg.data.CreatureAction))
            {
                curAnim = animmsg.data.CreatureAction;
                ChangeBodyAnim(curAnim);
            }
            else
            {
                curAnim = null;
                ChangeBodyAnim("idle");
            }

            var colormsg = displayObjList.OrderBy(msg => msg.data.ColorPriority).Last();
            if (!string.IsNullOrEmpty(colormsg.data.Color))
            {
                // bodyrenderer.color = animmsg.data.Color.ToColor();
                SetNodeBlendColor(colormsg.data.Color.ToColor(), colormsg.data.ColorScale, colormsg.data.ColorType);
            }
            else
                RecoverNodeBlendColor();// bodyrenderer.color = Color.white;
        }

        private void AddFlyText(int displayID, bool fromleft, float damage)
        {
            if (displayID == 0) return;
            CreatureDisplayData data = CreatureDisplayData.GetData(displayID);
            if (string.IsNullOrEmpty(data.DigitalPrefab)) return;
            var go = ObjTools.CreatePrefab(transform.parent, data.DigitalPrefab);
            go.GetComponentInChildren<TextMeshPro>().text = ((int)Math.Abs(damage)).ToString();

            go.GetComponentInChildren<Animator>().Play(data.LeftAnim);
            go.transform.position = uipoint.position;
        }
        private void Add2Point(Transform point, string path, DisplayMsg msg)
        {
            if (!string.IsNullOrEmpty(path))
            {
                var go = ObjTools.CreatePrefab(point, path);
                go.SetActive(true);
                msg.gos.Add(go);
            }
        }
        private void ClearPoint(Transform point)
        {
            for (int i = point.childCount - 1; i >= 0; i--)
            {
                Destroy(point.GetChild(i).gameObject);
            }
        }
        private void ClearAllPoint()
        {
            ClearPoint(toppoint);
            ClearPoint(bottompoint);
            ClearPoint(frontpoint);
            ClearPoint(backpoint);
            displayObjList.Clear();

            OnDisplayDicChange();
        }
        private CreatureRuntimeData GetCurRuntimeData()
        {
            return BattlefieldModule.Instance.GetCreatureRuntime(index);
        }
        private RuntimeState GetCurState()
        {
            return BattlefieldModule.Instance.GetCreatureRuntime(index).runtimeState;
        }
        #endregion
        #region 动画
        string curAnim;
        /// <summary>
        /// 身体播放动画切换
        /// </summary>
        /// <param name="state"></param>
        public void ChangeBodyAnim(string name)
        {
            //             if(index == 0)
            // Debug.LogError("ChangeBodyAnim"+index);
            if (!string.IsNullOrEmpty(curAnim))
            {
                if (!creatureAnimator.GetCurrentAnimatorStateInfo(0).IsName(curAnim))
                    creatureAnimator.Play(curAnim, 0, 0f);
                // if (index == 0)
                //     Debug.LogError(curAnim);
            }
            else
            {
                if (!creatureAnimator.GetCurrentAnimatorStateInfo(0).IsName(name))
                    creatureAnimator.Play(name);
                // if (index == 0)
                // Debug.LogError(name);
            }
        }
        public void Move(Vector2 dir)
        {
            ChangeBodyAnim("run");
            Vector3 newdir = dir;
            transform.position += newdir;
            flipXtrans.localScale = dir.x > 0 ? Vector2.one : new Vector2(-1, 1);

        }
        public void Idle()
        {
            ChangeBodyAnim("idle");
            TargetPos = default;
        }
        public void MoveTo(Vector3 pos)
        {
            ChangeBodyAnim("run");
            TargetPos = pos;
        }
        public void Die()
        {
            TargetPos = default;
            ClearAllPoint();
            AddNewDisplay(CreatureData.GetData(GetCurRuntimeData().baseInfo.creatureID).DieDisplayID, float.NaN);
            SpriteRenderer[] renders = GetComponentsInChildren<SpriteRenderer>();
            for (int i = 0; i < renders.Length; i++)
            {
                renders[i].sortingLayerName = "ground";
            }
            box.gameObject.SetActive(false);
            topbar.gameObject.SetActive(false);

            if (fire_coroutine != null)
                StopCoroutine(fire_coroutine);

            StartCoroutine(TimeTools.DelayCallback(2f, delegate
            {
                gameObject.SetActive(false);
            }));
        }
        #endregion
        public void OpenRepulsion(bool v)
        {
            if (v)
            {
                if (!RepulsionObj)
                    RepulsionObj = ObjTools.CreatePrefab(transform, "Prefabs/repulsion");

                RepulsionObj.SetActive(true);
            }
            else
                if (RepulsionObj)
                RepulsionObj.SetActive(false);
        }
        public void OnTriggerEnter2D(Collider2D collider)
        {
            // Debug.Log("Creature OnTriggerEnter2D");
            // Debug.Log(collider.gameObject.name);
            string[] strvals = collider.gameObject.name.Split('_');
            // for (int i = 0; i < strvals.Length; i++)
            // {
            //     Debug.Log(strvals[i]);
            // }
            string trigger = strvals[0];
            int val = 0;
            if (strvals.Length > 1 && int.TryParse(strvals[1], out val))
            {

            }
            // Tiled2Unity.TmxObject data = collider.GetComponent<Tiled2Unity.TmxObject>();
            //if (IsFlag)
            //{
            //    if (trigger.StartsWith("finishroom", System.StringComparison.Ordinal))
            //    {
            //        int index = val;
            //        NoticeTool.Broadcast(NoticeEnum.FINISH_ROOM, new object[] { index });
            //    }
            //    else if (trigger.Equals("Portal"))
            //    {
            //        int roomID = val;
            //        // TaskManagerModule.Instance.Enter(TaskType.Maincity, roomID);
            //    }
            //    else if (trigger.Equals("selectlevel"))
            //    {
            //        Debug.Log("select" + trigger);
            //        // TaskManagerModule.Instance.Enter(TaskType.Floorfight, DataModule.Instance.Get<int>("mainlv", 1));
            //    }
            //    else if (trigger.Equals("activeroom"))
            //    {
            //        collider.enabled = false;
            //        StartCoroutine(TimeTools.DelayCallback(0.5f, delegate
            //        {
            //            NoticeTool.Broadcast(NoticeEnum.ACTIVE_ROOM);
            //        }));
            //    }
            //} 
        }
        internal void SetFaceToward(int index)
        {
            Vector2 vector = BattlefieldModule.Instance.GetCreatureRuntime(index).Pos - (Vector2)transform.position;
            flipXtrans.localScale = vector.x > 0 ? Vector2.one : new Vector2(-1, 1);
        }
        public void ShowHpChange(Vector2 dir, int displayID, float deltahp)
        {
            if (displayID != 0)
            {
                CreatureDisplayData displayData = CreatureDisplayData.GetData(displayID);
                AddNewDisplay(displayID, displayData.Time);
                AddFlyText(displayID, dir.x <= 0, deltahp);

                CreatureRuntimeData runtime = BattlefieldModule.Instance.GetCreatureRuntime(index);
                topbar.Hp = runtime.Hp;
            }
        }
        public void AddForce(Vector2 force)
        {
            // Debug.LogError(string.Format("AddForce ({0},{1})", force.x, force.y));
            GetComponent<Rigidbody2D>().AddForce(force * TimeTools.TimeUnit);
        }
        private void OnEnable()
        {
            // Debug.Log("enable");
        }
        private void OnDisable()
        {
            CreatureRuntimeData runtime = BattlefieldModule.Instance.GetCreatureRuntime(index);
            if (runtime != null)
            {
                runtime.UnRegist(this);
            }
            // Debug.Log("disable");
        }
        private void Update()
        {
            for (int i = 0; i < displayObjList.Count; i++)
            {
                if (displayObjList[i].leftTime != float.NaN)
                {
                    displayObjList[i].leftTime -= Time.deltaTime;
                    if (displayObjList[i].leftTime <= 0)
                    {
                        RemoveDisplay(displayObjList[i].data.CreatureDisplayID);
                    }
                }

            }

            if (TargetPos != default)
            {
                Vector3 dir = (TargetPos - transform.position).normalized;
                // CreatureRuntimeData runtime = BattlefieldModule.Instance.GetCreatureRuntime(index);
                GetComponent<Rigidbody2D>().AddForce(dir * Time.deltaTime * ConfigInGame.moveSpeed);
                flipXtrans.localScale = dir.x > 0 ? Vector2.one : new Vector2(-1, 1);
            }
        }

        public void ActiveSkill(int skillID, BulletStaticCarry staticCarry)
        {
            // Debug.Log("Creature.ActiveSkill" + skillID);
            staticCarry.OwnerIndex = index;
            staticCarry.TargetTrans = BattlefieldModule.Instance.GetCreatureRuntime(staticCarry.TargetIndex).creature.transform;
            float angle = AngleTools.GetAngle(staticCarry.TargetTrans.position - transform.position);
            staticCarry.up = BulletLauncher.GetPysicsDown(launcher.transform, transform, angle);
            List<FireNode> firenodes = SkillTools.GetFireNode(skillID);
            for (int i = 0; i < firenodes.Count; i++)
            {
                FireNode firenode = firenodes[i];
                int fireID = firenode.fireID;

                fire_coroutine = StartCoroutine(Fire(fireID, staticCarry, firenode));
            }

            AudioModule.Instance.Sound_Skill(skillID);
        }

        IEnumerator Fire(int fireID, BulletStaticCarry staticcarry, FireNode firenode)
        {
            FireData firedata = FireData.GetData(fireID);

            // if (index == 0)
            //     Debug.LogError("FireID " + fireID);

            if (firedata.FireDisplayID != 0)
            {
                CreatureDisplayData displayData = CreatureDisplayData.GetData(firedata.FireDisplayID);
                float time = displayData.Time;
                if (time < 0)
                {
                    time = SkillTools.MatchAnimatonTime(creatureAnimator, displayData.CreatureAction);
                }
                AddNewDisplay(firedata.FireDisplayID, time);
            }

            yield return new WaitForSeconds(firedata.FireDelay);


            BulletDynamicCarry dynamicCarry = new BulletDynamicCarry();
            dynamicCarry.Collisions = 0; //第0次碰撞
            dynamicCarry.Firenode = firenode;
            dynamicCarry.Shoottans = launcher.transform;
            Vector2 dir = staticcarry.TargetTrans.position - transform.position;
            dynamicCarry.Angle = AngleTools.GetAngle(dir); //计算角度
            dynamicCarry.Generation = 0; //第0代
            /*子弹动态数据是在此动态生成的*/

            launcher.Launch(fireID, staticcarry, dynamicCarry);
            // }
            // else
            //     yield return null;
            fire_coroutine = null;
        }
        // public bool move;

        Shader shader = null;
        void SetNodeBlendColor(Color color, float scale, float colortype)
        {
            if (shader == null)
                shader = bodyrenderer.material.shader;
            bodyrenderer.material.shader = CacheModule.Instance.Load<Shader>("Shaders/Sprites-DefaultWhite");
            bodyrenderer.material.SetFloat("_GrayScale", scale);
            bodyrenderer.material.SetColor("_Colora", color);
            bodyrenderer.material.SetFloat("_ColorType", colortype);
        }

        void RecoverNodeBlendColor()
        {
            if (shader != null)
                bodyrenderer.material.shader = shader;
        }
    }
}