using UnityEngine;
using UnityEngine.UI;
public class SpriteSet : MonoBehaviour
{
    public int a;
    public Image image;
    public Sprite[] sprites;
    private void Update()
    {
        image.sprite = sprites[a];
    }
}