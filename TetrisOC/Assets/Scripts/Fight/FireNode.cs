using System;
using System.Collections.Generic;
namespace MMGame
{
    [Serializable]
    public class FireNode
    {
        public int fireID;
        public List<FireNode> next;
    }
}