Shader "Unlit/BG_vert_sin_blob"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _GameTime ("GameTime", float) = 0
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
            #pragma multi_compile_fog

            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                UNITY_FOG_COORDS(1)
                float4 vertex : SV_POSITION;
            };

            sampler2D _MainTex;
            float4 _MainTex_ST;
            float _GameTime;

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                UNITY_TRANSFER_FOG(o,o.vertex);
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                

                float osciSpeed = _GameTime/4;
                float osciHeight = 1;
                float scrollSpeed = _GameTime/3;

                float2 newUV = float2( i.uv[0] , i.uv[1] + sin(i.uv[0]*3.1)  +  osciHeight *  sin(i.uv[1] * 6 - osciSpeed) - scrollSpeed);
                fixed4 mainTex = tex2D(_MainTex, newUV);
                // sample the texture

                float4 colorSin = float4(sin(_GameTime)/6 - 0.1,sin(_GameTime)/6 - 0.1,sin(_GameTime)/6 - 0.1 ,1);

                fixed4 col = mainTex + colorSin;
                // apply fog
                //UNITY_APPLY_FOG(i.fogCoord, col);
                return col;
            }
            ENDCG
        }
    }
}
