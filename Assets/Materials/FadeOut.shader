Shader "Unlit/FadeOut"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _MainColor("Color", Color) = (0, 0, 0, 0)
        _SecondsToFade("Seconds To Fade", Float) = 3.0
        [Toggle(_FADE_OUT)] _FadeIn("Fade Out", Float) = 1.0
    }
    SubShader
    {
        Tags { "RenderType"="Transparent" }
        Blend SrcAlpha OneMinusSrcAlpha

        Pass
        {
            CGPROGRAM
            #pragma vertex vert alpha
            #pragma fragment frag alpha
            #pragma shader_feature _FADE_OUT

            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
            };

            sampler2D _MainTex;
            float4 _MainTex_ST;
            float4 _MainColor;
            float _SecondsToFade;

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.uv, _MainTex) - 0.5;
                return o;
            }

            float InverseLerp(float a, float b, float v) {
                return (v - a) / (b - a);
            }

            fixed4 frag(v2f i) : SV_Target
            {
                float howMuchFade = InverseLerp(0.0, _SecondsToFade, _Time.y);

                #if _FADE_OUT
                    _MainColor.w += howMuchFade;
                #else
                    _MainColor.w -= howMuchFade;
                #endif

                _MainColor.w = frac(_MainColor.w);
     
      
                _MainColor.w *= (1 - (length(i.uv) * 1/(_MainColor.w)));

                return _MainColor;
            }
            ENDCG
        }
    }
}
