Shader "Custom/LineShader"
{
    Properties
    {
        _ColorA("Colour A", Color ) = (1,1,1,1)
        _ColorB("Colour B", Color ) = (1,1,1,1)
        _Transparency("Transparency", Range(0,1)) = 1
        _Distortion("Distortion", Range(0,50) ) = 1
        _WaveCount("Wave Count", Range(0,10) ) = 1
        _WaveSpeed("Wave Speed", Range(0,10)) = 1
    }
    SubShader
    {
        Tags {
            "RenderPipeline"="UniversalPipeline"
            "RenderType"="Opaque"
            "Queue"="Transparent" 
        }
        LOD 100

        Pass
        {
            Cull Off
            ZWrite Off
            Blend One One

            HLSLPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Core.hlsl" 
            #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Lighting.hlsl"

            struct Attributes
            {
                float4 vertex : POSITION;
                float3 normals : NORMAL;
                float4 uv0 : TEXCOORD0;
            };

            struct Varyings
            {
                float4 vertex : SV_POSITION;
                float3 normal : TEXCOORD0;
                float2 uv : TEXCOORD1;
            };


            CBUFFER_START(UnityPerMaterial)
                float4 _ColorA;
                float4 _ColorB;
                float _Transparency;
                float _Distortion;
                float _WaveCount;
                float _WaveSpeed;
            CBUFFER_END


            Varyings vert (Attributes IN)
            {
                Varyings OUT;

                OUT.vertex = IN.vertex;

                OUT.vertex = TransformObjectToHClip(OUT.vertex);
                OUT.normal = TransformObjectToWorldNormal(IN.normals);
                OUT.uv = IN.uv0;

                return OUT;
            }

            float4 frag (Varyings inp) : SV_Target
            {               
                float transparency = cos((inp.uv.x - _Time.y * _WaveSpeed * 0.1) * _WaveCount * 5) * 0.5 + 0.5;
                transparency *= _Transparency;

                float waves = transparency;
                float4 gradient = lerp( _ColorA, _ColorB, inp.uv.x );

                return gradient * waves;
            }
            ENDHLSL
        }
    }
}
