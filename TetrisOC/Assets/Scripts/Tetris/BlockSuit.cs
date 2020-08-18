using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MMGame
{
    public class BlockSuit : MonoBehaviour
    {
        public Block[] blocks;

        public void Change(int blockindex, int dir)
        {
            Debug.LogError(blockindex + " " + dir);
            int[,] blocksuit = ConfigInGame.Blocks[blockindex][dir];
            for (int i = 0; i < blocks.Length; i++)
            {
                int x = blocksuit[i, 0];
                int y = blocksuit[i, 1];
                blocks[i].transform.localPosition = new Vector3(x * blocks[i].Width, y * blocks[i].Height);
            }
        }

        public static int getwidth(int blockindex, int dir)
        {
            int max_x = 0;
            int[,] block = ConfigInGame.Blocks[blockindex][dir];
            for (int i = 0; i < block.GetLength(0); i++)
            {
                int x = block[i, 0];
                if (x > max_x)
                    max_x = x;
            }
            return max_x + 1;
        }

        public void SetPerBlockMoney(float money)
        {
            for (int i = 0; i < blocks.Length; i++)
            {
                blocks[i].SetMoney(money);
            }
        }

        public void SetPreview()
        {
            for (int i = 0; i < blocks.Length; i++)
            {
                blocks[i].SetPreview();
            }
        }
    }
}