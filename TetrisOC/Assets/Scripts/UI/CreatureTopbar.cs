using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using MMFramework;
namespace MMGame
{
    public class CreatureTopbar : MonoBehaviour
    {
        public GameObject hpgo;
        public SpriteRenderer hp;
        public TextMeshPro creaturename;

        void Awake()
        {
            hpgo.gameObject.SetActive(false);
        }

        public string Name
        {
            set
            {
                creaturename.text = value;
            }
        }

        float _hpmax;
        public float HpMax
        {
            set
            {
                _hpmax = value;
            }
        }

        public float Hp
        {
            set
            {
                float _hp = value;
                float percent = _hp / _hpmax;
                hp.size = new Vector2(percent * 2, hp.size.y);

                hpgo.gameObject.SetActive(true);
                StopAllCoroutines();
                StartCoroutine(TimeTools.DelayCallback(ConfigInGame.HpShowTime, delegate
                {
                    hpgo.gameObject.SetActive(false);
                }));
            }
        }
    }
}