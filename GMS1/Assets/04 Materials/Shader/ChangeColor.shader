Shader "Custom/ChangeColor"
{
    Properties
    {
        _Color("Base Color", Color) = (1, 0, 0, 1)
        _Float("TimeScale", float) = 5.0
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
            #pragma multi_compile_fog

            #include "UnityCG.cginc"

            fixed4 _Color;

            float _Float;

            struct appdata
            {
                float4 vertex : POSITION;
            };

            struct v2f
            {
                float4 vertex : SV_POSITION;
            };

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                return o;
            }

            fixed3 HSVToRGB(fixed3 hsv)
            {
                fixed3 rgb;
                fixed h = hsv.x; // Hue (색조)
                fixed s = hsv.y; // Saturation (채도)
                fixed v = hsv.z; // Value (명도)

                fixed c = v * s; // Chroma 계산(채도에 따른 색상 강도)  **색상의 강도는 색상의 밝기와 선명도**
                fixed x = c * (1.0 - abs(fmod(h, 2.0) - 1.0)); // 색상에 따른 중간 값 색이 섞이는 정도
                fixed m = v - c; // 최종 밝기 조정 값

                // 색상 (Hue) 값에 따라 RGB를 계산
                if (h < 1.0)        rgb = fixed3(c, x, 0.0);  // 빨간색 -> 초록색
                else if (h < 2.0)   rgb = fixed3(x, c, 0.0);  // 초록색 -> 파란색
                else if (h < 3.0)   rgb = fixed3(0.0, c, x);  // 파란색 -> 빨간색
                else if (h < 4.0)   rgb = fixed3(0.0, x, c);  // 빨간색 -> 초록색
                else if (h < 5.0)   rgb = fixed3(x, 0.0, c);  // 초록색 -> 파란색
                else                rgb = fixed3(c, 0.0, x);  // 파란색 -> 빨간색

                // 최종 색상에 밝기 조정 값 m을 더함
                return rgb + fixed3(m, m, m);  // 최종 RGB 색상
            }

            fixed4 frag (v2f i) : SV_Target
            {
                float hue = sin(_Time * _Float) * 2.5 + 2.5;

                fixed3 rgbColor = HSVToRGB(fixed3(hue, 1.0, 1.0));
                return fixed4(rgbColor, 1.0);
            }
            ENDCG
        }
    }
}
