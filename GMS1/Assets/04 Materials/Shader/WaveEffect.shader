Shader "Custom/WaveEffect"
{
    Properties
    {
        _MainTex ("MainTex", 2D) = "white" {}
        _WaveSpeed ("WaveSpeed", float) = 1.0
        _WaveStrength ("WaveStrength", float) = 1.0
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
                float4 vertex : SV_POSITION;
            };

            sampler2D _MainTex;
            float _WaveSpeed;
            float _WaveStrength;

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                float time = _Time.y * _WaveSpeed;

                float2 wave = i.uv + float2(sin(i.uv.y * 10.0 + time) * _WaveStrength, sin(i.uv.x * 10.0 + time) * _WaveStrength);

                float4 col = tex2D(_MainTex, wave);

                return col;
            }
            ENDCG
        }
    }
}
