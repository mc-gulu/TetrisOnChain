using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TestSprite : MonoBehaviour
{
    public Image image;
    // Start is called before the first frame update
    Dictionary<string, Sprite> dict = new Dictionary<string, Sprite>();
    void Start()
    {
        image.sprite = LoadSprite("Ase/juese_animation", "juese_animation_0");
    }

    public Sprite LoadSprite(string atlas, string spritename)
    {
        if (!dict.ContainsKey(spritename))
        {
            Sprite[] sprites = Resources.LoadAll<Sprite>(atlas);
            for (int i = 0; i < sprites.Length; i++)
            {
                dict[sprites[i].name] = sprites[i];
            }
        }
        return dict[spritename];
    }

    // Update is called once per frame
    void Update()
    {

    }
}