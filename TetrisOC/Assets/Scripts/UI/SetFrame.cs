using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using MMFramework;
namespace MMGame
{
    public class SetFrame : MMFrame
    {
        public Button maskbtn;
        public Button musicon, musicoff, audioon, audiooff;
        public Text versiontext;

        public override void Init(object[] objects)
        {
            if (maskbtn != null)
                maskbtn.onClick.AddListener(delegate
                {
                    MMFrame.HideFrame(FrameData.FrameEnum.SetFrame);
                });
            if (musicon)
                musicon.onClick.AddListener(delegate
                {
                    AudioModule.Instance.Music = true;
                    UpdateUI();
                });
            if (musicoff)
                musicoff.onClick.AddListener(delegate
                {
                    AudioModule.Instance.Music = false;
                    UpdateUI();
                });
            if (audioon)
                audioon.onClick.AddListener(delegate
                {
                    AudioModule.Instance.Audio = true;
                    UpdateUI();
                });
            if (audiooff)
                audiooff.onClick.AddListener(delegate
                {
                    AudioModule.Instance.Audio = false;
                    UpdateUI();
                });
            versiontext.text = string.Format("{0}", Application.version);
        }

        void UpdateUI()
        {
            audioon.gameObject.SetActive(!AudioModule.Instance.Audio);
            audiooff.gameObject.SetActive(AudioModule.Instance.Audio);

            musicon.gameObject.SetActive(!AudioModule.Instance.Music);
            musicoff.gameObject.SetActive(AudioModule.Instance.Music);
        }
    }
}