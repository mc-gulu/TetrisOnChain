using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using MMFramework;
namespace MMGame
{
    public class Guid_GetGold : MonoBehaviour
    {
        void Awake()
        {
            GetComponent<Button>().onClick.AddListener(delegate
            {
                NoticeTool.Broadcast(NoticeEnum.GUILD_GET_GOLD);
            });
        }
    }
}