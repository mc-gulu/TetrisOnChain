using System;
using UnityEngine;
namespace MMFramework
{
    public static class RandomTools
    {
        static int randomindex = 0;

        public static int GetRandomInt(int min, int max)
        {
            long tick = DateTime.Now.Ticks;
            int seed = ((int)(tick & 0xffffffffL) | (int)(tick >> 32) + randomindex++);
            System.Random r = new System.Random(seed);
            return r.Next(min, max);
        }

        public static float Range(float from, float to)
        {
            return UnityEngine.Random.Range(from, to);
        }

        public static bool Rand1(float percent)
        {
            float rand = UnityEngine.Random.Range(0f, 1f);
            bool result = (rand < percent);
            return result;
        }

        public static Vector2 GetRandomPos(Rect rect)
        {
            Vector2 pos = new Vector2();
            pos.x = UnityEngine.Random.Range(rect.xMin, rect.xMax);
            pos.y = UnityEngine.Random.Range(rect.yMin, rect.yMax);
            return pos;
        }
    }
}