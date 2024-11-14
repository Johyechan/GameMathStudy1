Shader "Custom/FadeInOut"
{
    Properties
    {
        _Color ("Color", Color) = (1, 1, 1, 1)
        _FadeSpeed ("Fade Speed", float) = 0.0
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 100

        Pass
        {
            Blend SrcAlpha OneMinusSrcAlpha
            ZWrite On

            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            // make fog work
            #pragma multi_compile_fog

            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float2 texcoord : TEXCOORD0;
            };

            struct v2f
            {
                float2 texcoord : TEXCOORD0;
                UNITY_FOG_COORDS(1)
                float4 vertex : SV_POSITION;
            };

            fixed4 _Color;

            float _FadeSpeed;

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.texcoord = v.texcoord;
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                float alpha = sin(_Time.x * _FadeSpeed) * 0.5 + 0.5;

                fixed4 colorAlpha = _Color;
                colorAlpha.a = alpha;

                return colorAlpha;
            }
            ENDCG
        }
    }
}
