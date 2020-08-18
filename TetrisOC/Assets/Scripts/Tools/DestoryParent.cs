using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MMGame
{
    public class DestoryParent : MonoBehaviour
    {
        public void DestoryParentFunction()
        {
            Destroy(transform.parent.gameObject);
        }
    }
}
