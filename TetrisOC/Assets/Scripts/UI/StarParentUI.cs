using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace MMGame
{
    public class StarParentUI : MonoBehaviour
    {
        public GameObject StarGo;
        public Transform StarParent;
        public void StarByLv(int star)
        {
            for (int i = StarParent.childCount - 1; i > 0; i--)
            {
                Destroy(StarParent.GetChild(i).gameObject);
            }
            var rnum = star / 2;
            var haveh = star % 2 > 0;
            for (int i = 0; i < 5; i++)
            {
                if (i < rnum)
                {
                    ShowStar(true);
                }
                else if (i == rnum && haveh)
                {
                    ShowStar(true, true);
                }
            }
        }

        private void ShowStar(bool light, bool half = false)
        {
            var go = Instantiate(StarGo, StarParent);
            go.SetActive(true);
            if (light)
            {
                if (!half)
                    go.transform.GetChild(0).gameObject.SetActive(true);
                else
                    go.transform.GetChild(1).gameObject.SetActive(true);
            }
        }
    }
}