Shader "Custom/BlinkingLoadingShader"
{
    Properties
    {
        _Color ("Color", Color) = (1, 1, 1, 1)
        _Speed ("Speed", Range(1, 10)) = 2
    }
    SubShader
    {
        Tags { "Queue" = "Transparent" }
        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"

            struct appdata_t
            {
                float4 vertex : POSITION;
            };

            struct v2f
            {
                float4 vertex : SV_POSITION;
                float2 uv : TEXCOORD0;
            };

            float4 _Color;
            float _Speed;

            v2f vert (appdata_t v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.vertex.xy; // 使用顶点坐标作为纹理坐标
                return o;
            }

            half4 frag (v2f i) : SV_Target
            {
                // 创建一个闪烁的加载中效果
                float t = frac(_Time.y * _Speed); // 使用frac函数来制造闪烁
                float pulse = (t < 0.5) ? 1.0 : 0.0; // 0.5秒内显示，0.5秒内不显示
                return _Color * pulse;
            }
            ENDCG
        }
    }
}