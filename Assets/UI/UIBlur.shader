Shader "Unlit/UIBlur"
{
    
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _BlurSize ("Blur Strength", Range(0, 15)) = 10
        _Wash ("White Wash", Range(0, 1)) = 0.25
    }

    SubShader
    {
        Tags { "Queue"="Transparent" "RenderType"="Transparent" }
        Pass
        {
            ZWrite Off
            Blend SrcAlpha OneMinusSrcAlpha

            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"

            sampler2D _MainTex;
            float4 _MainTex_TexelSize;
            float _BlurSize;
            float _Wash;

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

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                fixed4 col = 0;
                float2 off = _MainTex_TexelSize.xy * _BlurSize;

                // dekat
                col += tex2D(_MainTex, i.uv + off);
                col += tex2D(_MainTex, i.uv - off);
                col += tex2D(_MainTex, i.uv + float2(off.x, -off.y));
                col += tex2D(_MainTex, i.uv + float2(-off.x, off.y));

                // medium
                col += tex2D(_MainTex, i.uv + off * 2);
                col += tex2D(_MainTex, i.uv - off * 2);
                col += tex2D(_MainTex, i.uv + off * 3);
                col += tex2D(_MainTex, i.uv - off * 3);

                // jauh
                col += tex2D(_MainTex, i.uv + off * 4);
                col += tex2D(_MainTex, i.uv - off * 4);
                col += tex2D(_MainTex, i.uv + off * 5);
                col += tex2D(_MainTex, i.uv - off * 5);

                col /= 12;

                // wash putih (mata silau)
                col.rgb = lerp(col.rgb, 1.0, _Wash);

                return col;
            }
            ENDCG
        }
    }
}
