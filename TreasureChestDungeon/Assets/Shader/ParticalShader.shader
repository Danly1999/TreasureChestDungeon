Shader "URP/ParticalShader"
{
    Properties
    {
        _MainTex ("MainTex", 2D) = "white" {}
        _MaskTex ("MaskTex", 2D) = "white" {}
        _NoiseScale ("Scale.x,Scale.y,Speed.x,Speed.y", vector) = (0,0,0,0)
        [Enum(UnityEngine.Rendering.BlendMode)] _DstBlend ("DstBlend", Int) = 1
        _StencilComp ("Stencil Comparison", Float) = 8
        _Stencil ("Stencil ID", Float) = 0
        _StencilOp ("Stencil Operation", Float) = 0
        _StencilWriteMask ("Stencil Write Mask", Float) = 255
        _StencilReadMask ("Stencil Read Mask", Float) = 255
        _ColorMask ("Color Mask", Float) = 15
    }
    SubShader
    {
        Tags { "Queue" = "Transparent"}
        LOD 100
        Blend SrcAlpha [_DstBlend]

        Pass
        {
            HLSLPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Core.hlsl"

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
                half4 color : COLOR;
            };

            struct v2f
            {
                float4 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
                half4 color : COLOR;
            };

            TEXTURE2D(_MainTex);
            SAMPLER(sampler_MainTex);
            TEXTURE2D(_MaskTex);
            SAMPLER(sampler_MaskTex);
            float4 _MainTex_ST;
            float4 _MaskTex_ST;
            half4 _NoiseScale;

            v2f vert (appdata v)
            {
                v2f o;
                VertexPositionInputs posInput = GetVertexPositionInputs(v.vertex.xyz);
                o.vertex = posInput.positionCS;
                o.color = v.color;
                o.uv.xy = TRANSFORM_TEX(v.uv, _MainTex);
                o.uv.zw = TRANSFORM_TEX(v.uv, _MaskTex);
                return o;
            }

            half4 frag (v2f i) : SV_Target
            {
                // sample the texture
                half mask = SAMPLE_TEXTURE2D(_MaskTex,sampler_MaskTex, i.uv.zw).r;
                half2 noise = SAMPLE_TEXTURE2D(_MaskTex,sampler_MaskTex, i.uv.zw+ _NoiseScale.zw* _Time.y).gb;
                half4 col  = SAMPLE_TEXTURE2D(_MainTex,sampler_MainTex, i.uv.xy+ noise* _NoiseScale.xy)*i.color;
                col.a *= mask.r*col.a;
                return col;
            }
            ENDHLSL
        }
    }
}
