Shader "Custom/LavaSurfaceShader"
{
    Properties
    {
        _MainTex ("Lava Texture", 2D) = "white" {}
        _Color ("Lava Color", Color) = (1.0, 0.2, 0.0, 1.0)
        _Speed ("Lava Speed", Range(0, 10)) = 1.0
        _Glow ("Glow Intensity", Range(0, 1)) = 0.5
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
            #include "UnityCG.cginc"
 
            struct appdata_t
            {
                float4 vertex : POSITION;
                float2 texcoord : TEXCOORD0;
            };
 
            struct v2f
            {
                float2 texcoord : TEXCOORD0;
                float4 pos : SV_POSITION;
            };
 
            sampler2D _MainTex;
            float4 _Color;
            float _Speed;
            float _Glow;
 
            v2f vert (appdata_t v)
            {
                v2f o;
                o.pos = UnityObjectToClipPos(v.vertex);
                o.texcoord = v.texcoord;
                return o;
            }
 
            half4 frag (v2f i) : SV_Target
            {
                // Simule o movimento da lava usando seno
                float time = _Time.y * _Speed;
                float wave1 = sin(i.texcoord.x * 10.0 + time) * 0.02;
                float wave2 = sin(i.texcoord.y * 10.0 + time * 1.5) * 0.02;
 
                // Combine as ondulações
                float2 distortedUV = i.texcoord + float2(wave1, wave2);
 
                // Amostra a textura de lava usando as coordenadas distorcidas
                half4 lavaColor = tex2D(_MainTex, distortedUV) * _Color;
 
                // Adicione um efeito de brilho
                lavaColor.rgb += _Glow;
 
                return lavaColor;
            }
            ENDCG
        }
    }
}
