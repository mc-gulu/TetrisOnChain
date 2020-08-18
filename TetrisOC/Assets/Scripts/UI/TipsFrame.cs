using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using MMFramework;
namespace MMGame
{
    public class TipsFrame : MMFrame
    {
        public Text title, text;
        public Button maskbtn;
        public Button tempbtn;

        private int wadd = 52, hadd = 65;

        public override void Init(object[] objects)
        {
            string titlestr = (string)objects[1];
            string textstr = (string)objects[2];
            title.text = titlestr;
            text.text = textstr;

            tempbtn.gameObject.SetActive(false);

            if (objects.Length > 3 && objects[3] != null)
            {
                ButtonData buttonData1 = (ButtonData)objects[3];

                GameObject btn1 = ObjTools.CopyGameObject(tempbtn.transform.parent.gameObject, tempbtn.gameObject);
                btn1.SetActive(true);
                btn1.GetComponentInChildren<Text>().text = buttonData1.text;
                btn1.GetComponent<Button>().onClick.AddListener(delegate
                {
                    buttonData1.action();
                });
            }

            if (objects.Length > 4 && objects[4] != null)
            {
                ButtonData buttonData2 = (ButtonData)objects[4];
                GameObject btn2 = ObjTools.CopyGameObject(tempbtn.transform.parent.gameObject, tempbtn.gameObject);
                btn2.SetActive(true);
                btn2.GetComponentInChildren<Text>().text = buttonData2.text;
                btn2.GetComponent<Button>().onClick.AddListener(delegate
                {
                    buttonData2.action();
                });
            }

            if (objects.Length <= 3)
            {
                if (maskbtn != null)
                    maskbtn.onClick.AddListener(delegate
                    {
                        MMFrame.HideFrame(FrameData.FrameEnum.TipsFrame);
                    });

                GameObject btn1 = ObjTools.CopyGameObject(tempbtn.transform.parent.gameObject, tempbtn.gameObject);
                btn1.SetActive(true);
                btn1.GetComponent<Button>().onClick.AddListener(delegate
                {
                    MMFrame.HideFrame(FrameData.FrameEnum.TipsFrame);
                });
            }
        }
    }
    public class ButtonData
    {
        public string text;
        public System.Action action;
        public ButtonData(string text, System.Action action)
        {
            this.text = text;
            this.action = action;
        }
    }
}