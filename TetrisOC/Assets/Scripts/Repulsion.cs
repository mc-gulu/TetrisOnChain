using MMFramework;
using MMGame;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MMGame
{
    public class Repulsion : MonoBehaviour
    {
        List<Creature> enterCreatureList;
        Transform self;

        private void Start()
        {
            enterCreatureList = new List<Creature>();
            self = transform.parent;
            var mycollider = GetComponent<CircleCollider2D>();
            var parentcollider = self.Find("box").GetComponent<CircleCollider2D>();
            mycollider.radius = parentcollider.radius + 0.1f;
        }
        private void OnTriggerEnter2D(Collider2D collision)
        {
            var creature = collision.transform.parent.gameObject.GetComponent<Creature>();
            if (creature)
            {
                var type = BattlefieldModule.Instance.GetCreatureRuntime(creature.index).baseInfo.ctype;
                if (type == CreatureType.partner && !enterCreatureList.Contains(creature))
                {
                    enterCreatureList.Add(creature);
                }
            }
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            var creature = collision.transform.parent.gameObject.GetComponent<Creature>();
            if (enterCreatureList.Contains(creature))
            {
                enterCreatureList.Remove(creature);
            }
        }

        private void Update()
        {
            if (enterCreatureList.Count > 0)
            {
                Vector3 vector = Vector3.zero;
                foreach (var item in enterCreatureList)
                {
                    if (item)
                    {
                        var vec = (transform.position - item.transform.position).normalized;
                        vector += vec;
                    }
                }
                self.GetComponent<Rigidbody2D>().AddForce(vector * 20 * TimeTools.TimeUnit);
            }
        }
        private void OnEnable()
        {
            NoticeTool.RegisterNotice(NoticeEnum.ENIMY_DEAD, OnEnimyDead);
        }

        private void OnEnimyDead(Enum noticeId, object[] objects)
        {
            if (self.GetComponentInParent<Creature>().index == (int)objects[0])
            {
                gameObject.SetActive(false);
            }
        }

        private void OnDisable()
        {
            NoticeTool.UnRegisterNotice(NoticeEnum.ENIMY_DEAD, OnEnimyDead);
        }
    }
}