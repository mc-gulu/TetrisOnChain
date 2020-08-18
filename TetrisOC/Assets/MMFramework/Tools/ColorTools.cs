using UnityEngine;
using UnityEngine.UI;
namespace MMFramework
{
    public static class ColorTools
    {
        public static void SetGray(GameObject go, bool gray)
        {
            Image[] images = go.GetComponentsInChildren<Image>();
            for (int i = 0; i < images.Length; i++)
            {
                SetImageGray(images[i], gray);
            }
        }

        public static void SetImageGray(MaskableGraphic image, bool gray)
        {
            if (gray)
            {
                image.material = CacheModule.Instance.Load<Material>("GrayMaterial");
            }
            else
            {
                image.material = CacheModule.Instance.Load<Material>("Default UI Material");
            }
        }

        public static Color ToColor(this string colorName)
        {
            var v = int.Parse(colorName, System.Globalization.NumberStyles.HexNumber);
            return new Color32
            {
                a = System.Convert.ToByte((v >> 24) & 255),
                    r = System.Convert.ToByte((v >> 16) & 255),
                    g = System.Convert.ToByte((v >> 8) & 255),
                    b = System.Convert.ToByte((v >> 0) & 255)
            };
        }
    }
}