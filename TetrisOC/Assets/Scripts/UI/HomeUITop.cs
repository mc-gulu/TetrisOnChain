using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using MMFramework;

namespace MMGame
{
    public class HomeUITop : MonoBehaviour
    {
        public Text chaptername;
        public Text levelname;
        public GameObject content;
        public HomeUITopItem itemtemp;
        public GameObject nextchapter;
        public Text addgold;
        List<HomeUITopItem> items = new List<HomeUITopItem>();
        int themeID, startlv, endlv;

        void Awake()
        {
            UpdateUI();
        }

        void UpdateUI()
        {
            itemtemp.gameObject.SetActive(false);
            nextchapter.SetActive(false);

            int lv = DataModule.Instance.MainLv;

            string localstr = LocalModule.Instance.GetValue(StringConfig.PerSecond);
            addgold.text = string.Format(string.Format(localstr, CalculateTool.Calculate2BigInt(lv, FloorFightData.GetData(lv).GoldSecond)));

            FloorFightData ffd = FloorFightData.GetData(lv);
            ThemeData themedata = ThemeData.GetData(ffd.ThemeID);
            chaptername.text = themedata.ThemeName;
            levelname.text = ffd.StageName;

            if (ffd.ThemeID.Equals(themeID))
            {
                for (int ilv = startlv; ilv <= endlv; ilv++)
                {
                    int i = ilv - startlv;
                    items[i].UpdateUI(ilv.ToString(), ilv < lv, ilv == lv);
                }
            }
            else
            {
                //删除旧的
                int childcount = content.transform.childCount;
                for (int i = childcount - 1; i >= 0; i--)
                {
                    DestroyImmediate(content.transform.GetChild(i).gameObject);
                }
                items.Clear();

                //计算前后
                themeID = ffd.ThemeID;
                int templv = lv;
                startlv = templv;
                endlv = templv;
                List<int> ffdkeys = FloorFightData.GetKeys();
                //向前
                while (true)
                {
                    templv--;
                    if (ffdkeys.Contains(templv) && FloorFightData.GetData(templv).ThemeID.Equals(themeID))
                    {
                        startlv = templv;
                    }
                    else
                        break;
                }
                //向后
                templv = lv;
                while (true)
                {
                    templv++;
                    if (ffdkeys.Contains(templv) && FloorFightData.GetData(templv).ThemeID.Equals(themeID))
                    {
                        endlv = templv;
                    }
                    else
                        break;
                }
                //添加新的
                for (int ilv = startlv; ilv <= endlv; ilv++)
                {
                    itemtemp.UpdateUI(ilv.ToString(), ilv < lv, ilv == lv);
                    GameObject item = ObjTools.CopyGameObject(content, itemtemp.gameObject);
                    item.SetActive(true);

                    items.Add(item.GetComponent<HomeUITopItem>());
                }
                GameObject nextchapterobj = ObjTools.CopyGameObject(content, nextchapter);
                nextchapterobj.SetActive(true);
            }

            StartCoroutine(TimeTools.DelayCallback(0.1f, delegate
            {
                int currentindex = lv - startlv;
                currentindex = System.Math.Max(currentindex, 3);
                currentindex = System.Math.Min(currentindex, endlv - startlv - 3);

                float x = items[currentindex].transform.localPosition.x - items[startlv + 3].transform.localPosition.x;
                // Debug.LogError(string.Format("{0}  {1}  {2}  {3}  {4}", lv, startlv, items[currentindex].transform.localPosition.x, items[startlv + 3].transform.localPosition.x, items[endlv - 3].transform.localPosition.x));
                Vector3 pos = content.transform.localPosition;
                float barwidth = content.transform.parent.GetComponent<RectTransform>().rect.width;
                float contentwidth = content.GetComponent<RectTransform>().sizeDelta.x;
                pos.x = Mathf.Clamp(-x, -(contentwidth - barwidth), 0);
                content.transform.localPosition = pos;
            }));
        }

        void Hander(System.Enum noticeId, object[] objects)
        {
            UpdateUI();
        }

        void OnEnable()
        {
            NoticeTool.RegisterNotice(NoticeEnum.MAINLV_UPDATE, Hander);
        }

        void OnDisable()
        {
            NoticeTool.UnRegisterNotice(NoticeEnum.MAINLV_UPDATE, Hander);
        }
    }
}