using System.Collections;
using System.Collections.Generic;
using System.Linq;
// using DragonBones;
using MMFramework;
using UnityEngine;

namespace MMGame
{
    public class Bullet : MonoBehaviour
    {
        public Rigidbody2D rigid;
        // public CircleCollider2D collision;
        public BulletLauncher launcher;
        public Transform boxtrans;

        public Animator animator;

        bool dead = true; //消失标记
        bool todie = false; //准备消失

        float lifetime; //子弹剩余时间
        int leftcollision; //子弹剩余碰撞数

        float maxradius = 0; //最大跟踪半径
        float maxangle = 0; //最大跟踪转角
        int lifecount = 1;

        bool selfcontinue = false; //是否自我循环

        public Transform spritepoint; //显示图片子节点

        // NoticeID listenID = NoticeID.NONE;

        // float max_delta_angle;

        public int FireID { get { return DynamicCarry.Firenode.fireID; } }
        public int BulletID { get { return FireData.GetData(FireID).BulletID; } }
        public BulletStaticCarry StaticCarry { get; set; }
        public BulletDynamicCarry DynamicCarry;
        BulletData bulletdata;
        //预载入显示
        public void LoadArmature(int bulletID)
        {
            BulletData bulletdata = BulletData.GetData(bulletID);
            animator = transform.GetComponent<Animator>();
            if (animator != null && !string.IsNullOrEmpty(bulletdata.AnimControllerPath))
                animator.runtimeAnimatorController = CacheModule.Instance.Load<RuntimeAnimatorController>(bulletdata.AnimControllerPath);
            spritepoint = transform.Find("spritepoint");
        }

        //载入数据
        public void InitBullet(int bulletID, BulletStaticCarry staticCarry, BulletDynamicCarry dynamicCarry)
        {
            // Debug.Log("Bullet.InitBullet" + bulletID);
            this.StaticCarry = staticCarry;
            this.DynamicCarry = dynamicCarry;

            // collision.enabled = false;
            dead = false;
            todie = false;

            FireData firedata = FireData.GetData(FireID);
            lifetime = firedata.BulletLastTime;
            maxradius = firedata.FollowRange;
            maxangle = firedata.FollowAngle;

            bulletdata = BulletData.GetData(BulletID);
            leftcollision = bulletdata.OnlyCollisionOnetime;
            if (lifetime < 0)
                lifetime = SkillTools.GetAnimatonTime(animator, bulletdata.FlyAction);

            //监听碰撞体大小变化的事件
            // armature.AddEventListener(EventObject.FRAME_EVENT, event_listener_delegate);

            //播放飞行动画
            if (!string.IsNullOrEmpty(bulletdata.FlyAction))
                Play(bulletdata.FlyAction);
            //如果设置了依据动画生成子弹持续时间，设置一下
            // if (lifetime < 0)
            //     lifetime = armature.animation.animations["start"].duration;

            launcher.bulletparent = transform.parent;
        }

        void UpdateFollow()
        {
            if (maxradius <= 0) return;
            Transform target = StaticCarry.TargetTrans;
            if (target != null && target.gameObject.activeInHierarchy) //跟踪的目标存在，并且正在显示
            {
                Vector2 dir = target.position - transform.position;
                float distance = dir.magnitude;
                if (distance < maxradius)
                {
                    //原角度
                    Vector2 speedv = rigid.velocity;
                    float fromangle = AngleTools.GetAngle(speedv);
                    //目标角度
                    float toangle = AngleTools.GetAngle(dir);
                    //本次最大转角
                    float percent = (maxradius - distance) / maxradius;
                    float final_delta_angle = maxangle * percent;
                    //最终角度
                    float newangle = AngleTools.CalculateNewAngle(fromangle, toangle, final_delta_angle);
                    //线速度不变的情况下，改变角度
                    float speedline = speedv.magnitude;
                    Vector2 speednew = new Vector2(
                        Mathf.Cos(AngleTools.AngleToRadian(newangle)) * speedline,
                        Mathf.Sin(AngleTools.AngleToRadian(newangle)) * speedline);
                    rigid.velocity = speednew;

                    SetQuaternion(AngleTools.AngleToRotation(newangle));
                }
            }
        }

        public void SetQuaternion(Quaternion quaternion)
        {

            spritepoint.localRotation = quaternion;
            if (boxtrans != null)
                boxtrans.localRotation = quaternion;
        }

        public void OnTriggerEnter2D(Collider2D collider)
        {
            Transform p = collider.transform;
            if (p != null)
            {
                Creature creature = p.parent.GetComponent<Creature>();
                if (creature != null)
                {
                    bool alive = false;
                    if (BattlefieldModule.Instance.BattleState == BattleState.fighting)
                    {
                        alive = BattlefieldModule.Instance.GetCreatureRuntime(creature.index).runtimeState != RuntimeState.Dead;
                    }
                    if (alive)
                    {
                        if (FireData.GetData(DynamicCarry.Firenode.fireID).TargetOnly && creature.index == StaticCarry.TargetIndex)
                        {
                            FireData fireData = FireData.GetData(FireID);
                            bool iscollision = true; //todie leftcollision 碰撞目标
                            if (iscollision) //判断是否碰撞
                            {
                                //碰撞
                                Vector2 dir = transform.position - creature.transform.position;
                                CollisionType ctype = (CollisionType)(int)fireData.AtkBackType;
                                if (ctype == CollisionType.SPEED_FORCE)
                                {
                                    Vector2 v = collider.attachedRigidbody.velocity;
                                    Vector2 vforce = v.normalized * fireData.AtkBack;
                                    creature.AddForce(vforce * TimeTools.TimeUnit);
                                }
                                else if (ctype == CollisionType.CENTER_FORCE)
                                {
                                    Vector2 v = creature.transform.position - transform.position;
                                    Vector2 cforce = v.normalized * fireData.AtkBack;
                                    creature.AddForce(cforce * TimeTools.TimeUnit);
                                }

                                BattlefieldModule.Instance.BulletColide(creature.index, dir, StaticCarry, DynamicCarry);

                                leftcollision--;
                                if (leftcollision <= 0)
                                {
                                    rigid.velocity = Vector2.zero;
                                }
                            }
                        }
                        else if (!FireData.GetData(DynamicCarry.Firenode.fireID).TargetOnly)
                        {
                            var owner = BattlefieldModule.Instance.GetCreatureRuntime(StaticCarry.OwnerIndex);
                            var isHostile = owner.GetHostileType() == BattlefieldModule.Instance.GetCreatureRuntime(creature.index).baseInfo.ctype;
                            var iscollision = ConditionTool.BulletCollidePoint(StaticCarry.SkillConditionID, owner.index, creature.index);
                            if (iscollision) //判断是否碰撞
                            {
                                FireData fireData = FireData.GetData(FireID);
                                //碰撞
                                Vector2 dir = transform.position - creature.transform.position;
                                CollisionType ctype = (CollisionType)(int)fireData.AtkBackType;
                                if (ctype == CollisionType.SPEED_FORCE)
                                {
                                    Vector2 v = collider.attachedRigidbody.velocity;
                                    Vector2 vforce = v.normalized * fireData.AtkBack;
                                    creature.AddForce(vforce * TimeTools.TimeUnit);
                                }
                                else if (ctype == CollisionType.CENTER_FORCE)
                                {
                                    Vector2 v = creature.transform.position - transform.position;
                                    Vector2 cforce = v.normalized * fireData.AtkBack;
                                    creature.AddForce(cforce * TimeTools.TimeUnit);
                                }

                                //碰撞
                                // Vector2 dir = transform.position - creature.transform.position;
                                BattlefieldModule.Instance.BulletColide(creature.index, dir, StaticCarry, DynamicCarry);

                                leftcollision--;
                                if (leftcollision <= 0)
                                {
                                    rigid.velocity = Vector2.zero;
                                }
                            }
                        }
                    }
                }
                else if (p.gameObject.layer.Equals(LayerMask.NameToLayer("wall")))
                {
                    if (BulletData.GetData(BulletID).WallCollision)
                    {
                        leftcollision = 0;
                        rigid.velocity = Vector2.zero;
                    }
                }
            }

        }

        Coroutine dying = null;
        void Update()
        {
            //Debug.Log(GetInstanceID() + "(" + transform.position.x + "," + transform.position.y + ")");
            if (dead)
                return;

            lifetime -= Time.deltaTime;
            if (lifetime <= 0 || leftcollision <= 0 || BattlefieldModule.Instance.BattleState == BattleState.normal)
                todie = true;

            if (todie)
            {
                float delaydie = 0f;

                if (selfcontinue && lifetime > 0) //闪灵技能是自我持续的
                {
                    FireNode nextfirenode = DynamicCarry.Firenode;
                    BulletDynamicCarry nextdynamiccarry = new BulletDynamicCarry();
                    nextdynamiccarry.Shoottans = transform;
                    nextdynamiccarry.Firenode = nextfirenode;
                    nextdynamiccarry.Collisions = 0;
                    nextdynamiccarry.Generation = DynamicCarry.Generation + 1;
                    //转角
                    if (rigid.velocity.magnitude < float.Epsilon && animator != null)
                        nextdynamiccarry.Angle = animator.transform.eulerAngles.z;
                    else
                        nextdynamiccarry.Angle = AngleTools.GetAngle(rigid.velocity);

                    StartCoroutine(Fire(nextdynamiccarry.Firenode.fireID, StaticCarry, nextdynamiccarry));
                    delaydie = 0.5f;
                }
                else
                if (DynamicCarry.Firenode.next != null && DynamicCarry.Firenode.next.Count > 0) //如果有接下来的子弹ID,则生成
                {
                    for (int i = 0; i < DynamicCarry.Firenode.next.Count; i++)
                    {
                        FireNode nextfirenode = DynamicCarry.Firenode.next[i];
                        BulletDynamicCarry nextdynamiccarry = new BulletDynamicCarry();
                        nextdynamiccarry.Shoottans = transform;
                        nextdynamiccarry.Firenode = nextfirenode;
                        nextdynamiccarry.Collisions = 0;
                        nextdynamiccarry.Generation = DynamicCarry.Generation + 1;
                        //转角
                        if (rigid.velocity.magnitude < float.Epsilon && animator != null)
                            nextdynamiccarry.Angle = animator.transform.eulerAngles.z;
                        else
                            nextdynamiccarry.Angle = AngleTools.GetAngle(rigid.velocity);

                        StartCoroutine(Fire(nextdynamiccarry.Firenode.fireID, StaticCarry, nextdynamiccarry));
                    }
                    delaydie = SkillTools.GetAnimatonTime(animator, bulletdata.HitAction);
                }
                else
                {
                    delaydie = SkillTools.GetAnimatonTime(animator, bulletdata.HitAction);
                    // Debug.LogError(delaydie);
                }
                dying = StartCoroutine(DeleteSelf(delaydie));
                dead = true;
            }
            else
            {
                if (BattlefieldModule.Instance.GetCreatureRuntime(StaticCarry.TargetIndex).runtimeState == RuntimeState.Active)
                {
                    UpdateFollow();
                }
            }
        }

        IEnumerator Fire(int fireID, BulletStaticCarry staticcarry, BulletDynamicCarry dynamiccarry)
        {
            FireData firedata = FireData.GetData(fireID);
            if (firedata.BulletID > 0)
            {
                yield return new WaitForSecondsRealtime(firedata.FireDelay);
                //DebugTool.LogError("fireID" + fireID);
                launcher.Launch(fireID, staticcarry, dynamiccarry);
            }
        }

        IEnumerator DeleteSelf(float delay)
        {
            Play(bulletdata.HitAction);
            yield return new WaitForSeconds(delay);

            dying = null;

            BulletPool.Instance.Recycle(BulletID, gameObject);
        }

        public void SetShowUp(float up)
        {
            if (BulletID > 0 && !BulletData.GetData(BulletID).Ground)
            {
                spritepoint.localPosition = new Vector3(0, up, 0);
            }
        }

        void Play(string statename)
        {
            if (animator != null)
                animator.Play(statename);
        }

        public void SetSelfcontinue()
        {
            selfcontinue = true;
        }

    }
}