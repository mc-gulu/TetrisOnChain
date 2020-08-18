// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

Shader "UISprites/DefaultWhite"
{
    Properties
    {
        [PerRendererData] _MainTex ("Sprite Texture", 2D) = "white" {}
        _Color ("Tint", Color) = (1,1,1,1)
        [MaterialToggle] PixelSnap ("Pixel snap", Float) = 0

        //---Add---
        // Change the brightness of the Sprite
        _GrayScale ("GrayScale", Range(0,1)) = 1
        //---Add---
        _Colora ("Tint2", Color) = (1,1,1,1)
        _ColorType ("ColorType", Int) = 1
        _CutOff("Cut off", float) = 0.1
    }

    SubShader
    {
        Tags
        { 
            "Queue"="Transparent" 
            "IgnoreProjector"="True" 
            "RenderType"="TransparentCutout" 
            "PreviewType"="Plane"
            "CanUseSpriteAtlas"="True"
        }

        Cull Off
        Lighting Off
        ZWrite Off
        ZTest LEqual
        Blend SrcAlpha OneMinusSrcAlpha

        Pass
        {
        CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #pragma multi_compile _ PIXELSNAP_ON
            #include "UnityCG.cginc"

            struct appdata_t
            {
                float4 vertex   : POSITION;
                float4 color    : COLOR;
                float2 texcoord : TEXCOORD0;
            };

            struct v2f
            {
                float4 vertex   : SV_POSITION;
                fixed4 color    : COLOR;
                half2 texcoord  : TEXCOORD0;
            };

            fixed4 _Color;

            v2f vert(appdata_t IN)
            {
                v2f OUT;
                OUT.vertex = UnityObjectToClipPos(IN.vertex);
                OUT.texcoord = IN.texcoord;
                OUT.color = IN.color * _Color;
                #ifdef PIXELSNAP_ON
                OUT.vertex = UnityPixelSnap (OUT.vertex);
                #endif

                return OUT;
            }

            sampler2D _MainTex;
            float _GrayScale;
            fixed4 _Colora;
            int _ColorType;
            float _CutOff;

            fixed4 frag(v2f IN) : SV_Target
            {
                fixed4 c = tex2D(_MainTex, IN.texcoord) * IN.color;
                if (c.a < _CutOff)
                    discard;

                //---Add--
                //float cc = 1;
                //cc *= _GrayScale;
                //c.r = c.g = c.b = cc;
                if (_ColorType == 0){
                    c.r = _Colora.r * _GrayScale + c.r * (1 - _GrayScale);
                    c.g = _Colora.g * _GrayScale + c.g * (1 - _GrayScale);
                    c.b = _Colora.b * _GrayScale + c.b * (1 - _GrayScale);
                    c.a = _Colora.a * _GrayScale + c.a * (1 - _GrayScale);
                }else if (_ColorType == 1){
                    c.r = c.r * _Colora.r * _GrayScale + c.r * (1 - _GrayScale);
                    c.g = c.g * _Colora.g * _GrayScale + c.g * (1 - _GrayScale);
                    c.b = c.b * _Colora.b * _GrayScale + c.b * (1 - _GrayScale);
                    c.a = c.a * _Colora.a * _GrayScale + c.a * (1 - _GrayScale);
                }
                
                //---Add--

                //c.a = c.a * _GrayScale;
                return c;
            }
        ENDCG
        }
    }
}