Shader "Unlit/Teste" {
    Properties {
        _MainTex ("Texture", 2D) = "white" {}
        _A("Range A", Range(0,360)) = 0
        _B("Range", Range(-5,5)) = 0
    }
    SubShader {
        Tags { "RenderType"="Opaque" }
        Pass {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"
            struct appdata {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };
            struct v2f {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
            };
            sampler2D _MainTex;
            float4 _MainTex_ST;
            float _A, _B;
            v2f vert (appdata v) {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                return o;
            }
            fixed4 frag (v2f i) : SV_Target {
                /*float2x2 m = float2x2(
                    1, _A* sin(_Time.y)*0.2,
                    _B, 1 
                );*/
                float a = radians(_A);
                float2x2 m = float2x2(
                    cos(a), -sin(a),
                    sin(a), cos(a)
                );
                float2 d = float2(0.5, 0.5);
                float2 p = mul(m, i.uv -d) + d;
                fixed4 col = tex2D(_MainTex, p);
                return col;
            }
            ENDCG
        }
    }
}
