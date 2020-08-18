using MMFramework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MMGame
{
    public class WarningFrame : MMFrame
    {
        private void OnDisable()
        {
            NoticeTool.Broadcast(NoticeEnum.WARNING_FINISH);
        }
    }
}