using UnityEngine;
using System.Collections;
using UnityEngine.UI;

using System.Collections.Generic;
using UnityEngine.Serialization;
namespace MMFramework
{
    public class GuideHighlightMask : MaskableGraphic, ICanvasRaycastFilter
    {
        public RectTransform touchRect;
        public RectTransform lightRect;
        public Vector2 center = Vector2.zero;
        public Vector2 size = new Vector2(100, 100);
        public System.Action action;
        // Vector4 inner;
        public void DoUpdate()
        {
            // 当引导箭头位置或者大小改变后更新，注意：未处理拉伸模式
            if (lightRect && center != lightRect.anchoredPosition || size != lightRect.sizeDelta)
            {
                this.center = lightRect.anchoredPosition;
                this.size = lightRect.sizeDelta;
                SetAllDirty();
            }
        }

        // public void SetInner(Vector4 iinnner)
        // {
        //     this.inner = iinnner;
        //     SetAllDirty();
        // }

        public bool IsRaycastLocationValid(Vector2 sp, Camera eventCamera)
        {
            // 点击在箭头框内部则无效，否则生效
            bool act = !RectTransformUtility.RectangleContainsScreenPoint(touchRect, sp, eventCamera);
            if (act && Input.GetMouseButtonUp(0))
            {

            }
            else if (Input.GetMouseButtonUp(0))
            {
                if (action != null)
                    action();
            }
            return act;
        }

        protected override void OnPopulateMesh(VertexHelper vh)
        {
            Vector4 outer = new Vector4(-rectTransform.pivot.x * rectTransform.rect.width,
                                        -rectTransform.pivot.y * rectTransform.rect.height,
                                        (1 - rectTransform.pivot.x) * rectTransform.rect.width,
                                        (1 - rectTransform.pivot.y) * rectTransform.rect.height);

            Vector4 inner = new Vector4(center.x - size.x / 2,
                                        center.y - size.y / 2,
                                        center.x + size.x * 0.5f,
                                       center.y + size.y * 0.5f);
            // Debug.LogError(outer.ToString() + "  " + inner.ToString());
            vh.Clear();

            // base.OnPopulateMesh(vh);

            UIVertex[] verts = new UIVertex[4];
            for (int i = 0; i < verts.Length; i++)
            {
                verts[i] = UIVertex.simpleVert;
            }

            // // inner
            // verts[0].position = new Vector2(outer.x, inner.y);
            // verts[0].color = color;

            // verts[1].position = new Vector2(inner.x, inner.w);
            // verts[1].color = color;

            // verts[2].position = new Vector2(inner.z, inner.w);
            // verts[2].color = color;

            // verts[3].position = new Vector2(inner.z, inner.y);
            // verts[3].color = color;
            // vh.AddUIVertexQuad(verts);

            // left
            verts[0].position = new Vector2(outer.x, outer.y);
            verts[0].color = color;
            // vh.AddVert(vert);

            verts[1].position = new Vector2(outer.x, outer.w);
            verts[1].color = color;
            // vh.AddVert(vert);

            verts[2].position = new Vector2(inner.x, outer.w);
            verts[2].color = color;
            // vh.AddVert(vert);

            verts[3].position = new Vector2(inner.x, outer.y);
            verts[3].color = color;
            // vh.AddVert(vert);
            vh.AddUIVertexQuad(verts);

            // top
            verts[0].position = new Vector2(inner.x, inner.w);
            verts[0].color = color;
            // vh.AddVert(vert);

            verts[1].position = new Vector2(inner.x, outer.w);
            verts[1].color = color;
            // vh.AddVert(vert);

            verts[2].position = new Vector2(inner.z, outer.w);
            verts[2].color = color;
            // vh.AddVert(vert);

            verts[3].position = new Vector2(inner.z, inner.w);
            verts[3].color = color;
            // vh.AddVert(vert);
            vh.AddUIVertexQuad(verts);

            // right
            verts[0].position = new Vector2(inner.z, outer.y);
            verts[0].color = color;
            // vh.AddVert(vert);

            verts[1].position = new Vector2(inner.z, outer.w);
            verts[1].color = color;
            // vh.AddVert(vert);

            verts[2].position = new Vector2(outer.z, outer.w);
            verts[2].color = color;
            // vh.AddVert(vert);

            verts[3].position = new Vector2(outer.z, outer.y);
            verts[3].color = color;
            // vh.AddVert(vert);
            vh.AddUIVertexQuad(verts);

            // bottom
            verts[0].position = new Vector2(inner.x, outer.y);
            verts[0].color = color;
            // vh.AddVert(vert);

            verts[1].position = new Vector2(inner.x, inner.y);
            verts[1].color = color;
            // vh.AddVert(vert);

            verts[2].position = new Vector2(inner.z, inner.y);
            verts[2].color = color;
            // vh.AddVert(vert);

            verts[3].position = new Vector2(inner.z, outer.y);
            verts[3].color = color;
            // vh.AddVert(vert);
            vh.AddUIVertexQuad(verts);

        }

        private void Update()
        {
            DoUpdate();
        }
    }
}