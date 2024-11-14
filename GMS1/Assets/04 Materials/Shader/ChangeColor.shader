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
                fixed h = hsv.x; // Hue (����)
                fixed s = hsv.y; // Saturation (ä��)
                fixed v = hsv.z; // Value (��)

                fixed c = v * s; // Chroma ���(ä���� ���� ���� ����)  **������ ������ ������ ���� ����**
                fixed x = c * (1.0 - abs(fmod(h, 2.0) - 1.0)); // ���� ���� �߰� �� ���� ���̴� ����
                fixed m = v - c; // ���� ��� ���� ��

                // ���� (Hue) ���� ���� RGB�� ���
                if (h < 1.0)        rgb = fixed3(c, x, 0.0);  // ������ -> �ʷϻ�
                else if (h < 2.0)   rgb = fixed3(x, c, 0.0);  // �ʷϻ� -> �Ķ���
                else if (h < 3.0)   rgb = fixed3(0.0, c, x);  // �Ķ��� -> ������
                else if (h < 4.0)   rgb = fixed3(0.0, x, c);  // ������ -> �ʷϻ�
                else if (h < 5.0)   rgb = fixed3(x, 0.0, c);  // �ʷϻ� -> �Ķ���
                else                rgb = fixed3(c, 0.0, x);  // �Ķ��� -> ������

                // ���� ���� ��� ���� �� m�� ����
                return rgb + fixed3(m, m, m);  // ���� RGB ����
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
