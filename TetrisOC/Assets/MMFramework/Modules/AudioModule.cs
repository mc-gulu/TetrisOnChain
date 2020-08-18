using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MMFramework
{
    public class AudioModule : MonoBehaviour, BaseModule
    {
        public static AudioModule Instance
        {
            get
            {
                return RootModule.Instance.GetModule<AudioModule>();
            }
        }

        bool music_switch;
        bool audio_switch;
        bool playing_video = false;
        bool playing_ad = false;
        Dictionary<int, KeyValuePair<string, AudioSource>> channelsounds = new Dictionary<int, KeyValuePair<string, AudioSource>>();
        public bool Audio
        {
            get
            {
                return audio_switch;
            }
            set
            {
                audio_switch = value;
                StorageModule.SaveStruct<bool>(StorageKey.Audio, audio_switch);
                // Debug.Log("音效" + audio_switch);
                GetChannel(MMGame.ConfigInGame.AudioChannel).gameObject.SetActive(audio_switch && (!playing_video) && (!playing_ad));
            }
        }

        public bool Music
        {
            get
            {
                return music_switch;
            }
            set
            {
                music_switch = value;
                StorageModule.SaveStruct<bool>(StorageKey.Music, music_switch);
                // Debug.Log("音乐" + music_switch);
                GetChannel(MMGame.ConfigInGame.MusicChannel).gameObject.SetActive(music_switch && (!playing_video) && (!playing_ad));
            }
        }

        public bool PlayingVideo
        {
            get
            {
                return playing_video;
            }
            set
            {
                playing_video = value;
                GetChannel(MMGame.ConfigInGame.AudioChannel).gameObject.SetActive(audio_switch && (!playing_video) && (!playing_ad));
                GetChannel(MMGame.ConfigInGame.MusicChannel).gameObject.SetActive(music_switch && (!playing_video) && (!playing_ad));
            }
        }

        public bool PlayingAd
        {
            get
            {
                return playing_ad;
            }
            set
            {
                playing_ad = value;
                GetChannel(MMGame.ConfigInGame.AudioChannel).gameObject.SetActive(audio_switch && (!playing_video) && (!playing_ad));
                GetChannel(MMGame.ConfigInGame.MusicChannel).gameObject.SetActive(music_switch && (!playing_video) && (!playing_ad));
            }
        }

        public void Init()
        {
            if (StorageModule.HasStruct(StorageKey.Audio))
                audio_switch = StorageModule.LoadStruct<bool>(StorageKey.Audio);
            else
            {
                audio_switch = true;
            }
            GetChannel(MMGame.ConfigInGame.AudioChannel).gameObject.SetActive(audio_switch);

            if (StorageModule.HasStruct(StorageKey.Music))
                music_switch = StorageModule.LoadStruct<bool>(StorageKey.Music);
            else
            {
                music_switch = true;
            }
            GetChannel(MMGame.ConfigInGame.MusicChannel).gameObject.SetActive(music_switch);
        }

        void PlaySoundByKey(string key)
        {
            // Debug.LogError("soundkey:" + key);
            if (SoundData.GetKeys().Contains(key))
            {
                SoundData sd = SoundData.GetData(key);
                if (sd.delay > 0)
                    StartCoroutine(DelayPlay(sd.delay, key));
                else
                    Sound(key);
            }
        }

        IEnumerator DelayDelAudioSource(float delay, AudioSource audioSource, int channel)
        {
            yield return new WaitForSecondsRealtime(delay);
            if (channel != 0)
            {
                channelsounds.Remove(channel);
            }
            Destroy(audioSource);
        }

        IEnumerator DelayPlay(float delay, string key)
        {
            yield return new WaitForSecondsRealtime(delay);
            Sound(key);
        }

        Transform GetChannel(int channel)
        {
            string channelname = "channel" + channel.ToString();
            Transform tranchannel = transform.Find(channelname);
            if (tranchannel == null)
            {
                GameObject obj = new GameObject();
                obj.name = channelname;
                obj.transform.SetParent(transform);
                tranchannel = obj.transform;
            }
            return tranchannel;
        }

        void Sound(string key)
        {
            //DebugTool.LogError("播放" + key);
            SoundData sd = SoundData.GetData(key);
            if (sd.channel != 0)
            {
                if (channelsounds.ContainsKey(sd.channel))
                {
                    if (string.IsNullOrEmpty(channelsounds[sd.channel].Key))
                    {
                        Debug.LogError("没有声音文件");
                    }
                    else if (channelsounds[sd.channel].Key.Equals(sd.sound))
                    {
                        Debug.Log("声音文件相等");
                        return;
                    }
                    else
                    {
                        Destroy(channelsounds[sd.channel].Value);
                        channelsounds.Remove(sd.channel);
                    }
                }
            }
            AudioClip ac = CacheModule.Instance.Load<AudioClip>(sd.sound);
            if (ac != null)
            {
                Transform tranchannel = GetChannel(sd.channel);
                AudioSource audioSource = tranchannel.gameObject.AddComponent<AudioSource>();
                audioSource.volume = sd.volume;
                // audioSource.pitch = sd.pitch;
                audioSource.loop = sd.loop;
                audioSource.clip = ac;
                audioSource.Play();

                if (sd.channel != 0)
                    channelsounds[sd.channel] = new KeyValuePair<string, AudioSource>(sd.sound, audioSource);

                if (!sd.loop)
                    StartCoroutine(DelayDelAudioSource(ac.length, audioSource, sd.channel));
            }
        }

        public void Sound_UI(string prefab, string reason) //ok
        {
            if (!string.IsNullOrEmpty(prefab) && !string.IsNullOrEmpty(reason))
            {
                string newprefab = prefab.Replace("(Clone)", string.Empty);
                string key = newprefab + "/" + reason;
                // Debug.Log("key:" + key);
                PlaySoundByKey(key);
            }
        }

        public void Sound_Skill(int skillID) //ok
        {
            if (skillID > 0)
            {
                string key = skillID.ToString();
                // Debug.Log("key:" + key);
                PlaySoundByKey(key);
            }
        }

        public void Sound_Fire(int fireID) //ok
        {
            if (fireID > 0)
            {
                string key = fireID.ToString();
                // Debug.Log("key:" + key);
                PlaySoundByKey(key);
            }
        }

        public void Sound_Display(int displayID) //ok
        {
            if (displayID != 0)
            {
                string key = displayID.ToString();
                // Debug.Log("key:" + key);
                PlaySoundByKey(key);
            }
        }

        public void Sound_KeyFrame(string dragonbone, string animation, string keyframe) //ok
        {
            if (!string.IsNullOrEmpty(dragonbone) && !string.IsNullOrEmpty(animation) && !string.IsNullOrEmpty(keyframe))
            {
                string key = dragonbone + "/" + animation + "/" + keyframe;
                //DebugTool.LogError("key:" + key);
                PlaySoundByKey(key);
            }
        }
        public void Sound_Map(int mapID)
        {
            if (mapID > 0)
            {
                string key = mapID.ToString();
                //DebugTool.LogError("key:" + key);
                PlaySoundByKey(key);
            }
        }
        public void Sound_Custom(string customkey)
        {
            if (!string.IsNullOrEmpty(customkey))
            {
                string key = customkey;
                PlaySoundByKey(key);
            }
        }
        // public void Sound_RoguelikeRoom(RoomType roomtype, int themeID) //ok
        // {
        //     if (roomtype != RoomType.None && ZZZ_ThemeData.GetKeys().Contains(themeID))
        //     {
        //         string key = roomtype.ToString() + "/" + themeID.ToString();
        //         //DebugTool.LogError(key);
        //         PlaySoundByKey(key);
        //     }
        // }

        // void DragonBonesEventListener(string type, DragonBones.EventObject eventObject)
        // {
        //     Sound_KeyFrame(eventObject.armature.name, eventObject.animationState.name, eventObject.name);
        // }

        private void OnEnable()
        {
            // var f = DragonBones.UnityFactory.factory;

            // if (f != null)
            // {
            //     f.AnimationCallback += Sound_Animation;

            //     var sm = f.soundEventManager;
            //     if (sm != null)
            //         sm.AddEventListener(DragonBones.EventObject.SOUND_EVENT, DragonBonesEventListener);
            // }
            // else
            // {
            //     Debug.LogError("未成功初始化声音模块");
            // }
        }

        private void OnDisable()
        {
            // var f = DragonBones.UnityFactory.factory;

            // if (f != null)
            // {
            //     var sm = f.soundEventManager;
            //     if (sm != null)
            //         sm.RemoveEventListener(DragonBones.EventObject.SOUND_EVENT, DragonBonesEventListener);

            //     f.AnimationCallback -= Sound_Animation;
            // }
            // else
            // {
            //     Debug.LogError("未成功注销声音模块");
            // }

            StopAllCoroutines();
        }
    }
}