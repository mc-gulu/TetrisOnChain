using UnityEngine;
using UnityEngine.UI;
namespace MMFramework
{
    public static class AngleTools
    {
        public static float AngleToRadian(float angle)
        {
            return angle / 180f * Mathf.PI;
        }
        public static Quaternion AngleToRotation(float angle)
        {
            return Quaternion.Euler(0, 0, angle);
        }
        public static float GetAngle(Vector2 v)
        {
            float angle = Vector2.Angle(Vector2.right, v);
            if (v.y < 0)
            {
                angle = 360 - angle;
            }
            return angle;
        }

        public static bool IsLeft(float angle)
        {
            float temp = (angle + 360) % 360;
            return (temp > 90f && temp < 270f);
        }
        public static float CalculateNewAngle(float a, float tara, float d)
        {
            float newangle = tara;
            if ((tara - a) > 180)
            {
                a = a + 360;
            }
            else if ((tara - a) < -180)
            {
                tara = tara + 360;
            }
            if (a > tara)
            {
                newangle = a - d;
                if (newangle < tara)
                {
                    newangle = tara;
                }
            }
            else if (a < tara)
            {
                newangle = a + d;
                if (newangle > tara)
                {
                    newangle = tara;
                }
            }
            return newangle % 360;
        }
    }
}