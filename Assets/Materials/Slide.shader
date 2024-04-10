Shader "Unlit/Slide"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _SlideTo("Slide Distance", Range(0, 1)) = 0.3
        _SpringConst("Spring Constant", Float) = 50
        _AnchorDist("Anchor Distance", Range(0, 1)) = 0.8
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 100

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            // make fog work

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

            //float totalCount;

            float _SlideTo;
            float _SpringConst;
            float _AnchorDist;

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);

                //using sin wave and vertices
                //totalCount += _Time.x * 100;
                //o.vertex.x += (0.01 * sin(totalCount));
                
                float springForce = _SpringConst * (_SlideTo - o.uv.x);
                o.vertex.x += springForce * _Time.x;

                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                // sample the texture
                fixed4 col = tex2D(_MainTex, i.uv);
                // apply fog
                UNITY_APPLY_FOG(i.fogCoord, col);
                return col;
            }
            ENDCG
        }
    }
}
