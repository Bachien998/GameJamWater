Shader "Custom/PolygonalWater"
{
    Properties
    {
        _Color ("Water Color", Color) = (0.0, 0.5, 0.8, 1.0)
        _LightIntensity ("Light Intensity", Range(0, 10)) = 1.0
        _WaveShadowStrength ("Wave Shadow Strength", Range(0, 100)) = 0.5
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 200

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"

            struct v2f
            {
                float4 pos : SV_POSITION;
                float3 worldPos : TEXCOORD0;
            };

            float4 _Color;
            float _LightIntensity;
            float _WaveShadowStrength;

            v2f vert (float4 vertex : POSITION)
            {
                v2f o;
                o.pos = UnityObjectToClipPos(vertex);
                o.worldPos = mul(unity_ObjectToWorld, vertex).xyz;
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                // Calcul de la normale à partir des dérivées (dans le fragment shader)
                float3 worldNormal = normalize(cross(ddx(i.worldPos), ddy(i.worldPos)));

                // Simuler l'ombrage local sur les vagues
                float shadowFactor = 1.0 - (worldNormal.y * 0.5 + 0.5); 
                shadowFactor = lerp(1.0, shadowFactor, _WaveShadowStrength); 

                // Simuler l'intensité lumineuse manuelle
                float lightEffect = _LightIntensity;

                // Application de la couleur avec l'ombrage local
                fixed4 color = _Color * lightEffect * shadowFactor;

                return color;
            }

            ENDCG
        }
    }
    FallBack "Diffuse"
}
