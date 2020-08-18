using System.Collections;
using System.Collections.Generic;
using MMFramework;
using UnityEngine;
namespace MMGame
{

    public class CircleMove : MonoBehaviour
    {
        float currentangle;
        float speed;
        float r;
        public void SetInit(float r, float speed, float startangle)
        {
            currentangle = startangle;
            this.speed = speed;
            this.r = r;

            Update();
        }

        void Update()
        {
            float newangle = currentangle + speed * Time.deltaTime;
            currentangle = newangle;
            float fx = r * Mathf.Cos(AngleTools.AngleToRadian(newangle));
            float fy = r * Mathf.Sin(AngleTools.AngleToRadian(newangle));
            transform.localPosition = new Vector3(fx, fy, transform.localPosition.z);
        }
    }
}