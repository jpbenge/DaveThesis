Shader "floorToIce"
{
	Properties 
	{
_Diffuse1("_Diffuse1", 2D) = "gray" {}
_Diffuse2("_Diffuse2", 2D) = "black" {}
_Normal1("_Normal1", 2D) = "bump" {}
_Normal2("_Normal2", 2D) = "bump" {}
_shine("_shine", Range(0,1) ) = 0
_blend("_blend", Range(0,1) ) = 0

	}
	
	SubShader 
	{
		Tags
		{
"Queue"="Geometry"
"IgnoreProjector"="False"
"RenderType"="Opaque"

		}

		
Cull Back
ZWrite On
ZTest LEqual
ColorMask RGBA
Fog{
}


		CGPROGRAM
#pragma surface surf BlinnPhongEditor  vertex:vert
#pragma target 2.0


sampler2D _Diffuse1;
sampler2D _Diffuse2;
sampler2D _Normal1;
sampler2D _Normal2;
float _shine;
float _blend;

			struct EditorSurfaceOutput {
				half3 Albedo;
				half3 Normal;
				half3 Emission;
				half3 Gloss;
				half Specular;
				half Alpha;
				half4 Custom;
			};
			
			inline half4 LightingBlinnPhongEditor_PrePass (EditorSurfaceOutput s, half4 light)
			{
half3 spec = light.a * s.Gloss;
half4 c;
c.rgb = (s.Albedo * light.rgb + light.rgb * spec);
c.a = s.Alpha;
return c;

			}

			inline half4 LightingBlinnPhongEditor (EditorSurfaceOutput s, half3 lightDir, half3 viewDir, half atten)
			{
				half3 h = normalize (lightDir + viewDir);
				
				half diff = max (0, dot ( lightDir, s.Normal ));
				
				float nh = max (0, dot (s.Normal, h));
				float spec = pow (nh, s.Specular*128.0);
				
				half4 res;
				res.rgb = _LightColor0.rgb * diff;
				res.w = spec * Luminance (_LightColor0.rgb);
				res *= atten * 2.0;

				return LightingBlinnPhongEditor_PrePass( s, res );
			}
			
			struct Input {
				float2 uv_Diffuse1;
float2 uv_Diffuse2;
float2 uv_Normal1;
float2 uv_Normal2;

			};

			void vert (inout appdata_full v, out Input o) {
float4 VertexOutputMaster0_0_NoInput = float4(0,0,0,0);
float4 VertexOutputMaster0_1_NoInput = float4(0,0,0,0);
float4 VertexOutputMaster0_2_NoInput = float4(0,0,0,0);
float4 VertexOutputMaster0_3_NoInput = float4(0,0,0,0);


			}
			

			void surf (Input IN, inout EditorSurfaceOutput o) {
				o.Normal = float3(0.0,0.0,1.0);
				o.Alpha = 1.0;
				o.Albedo = 0.0;
				o.Emission = 0.0;
				o.Gloss = 0.0;
				o.Specular = 0.0;
				o.Custom = 0.0;
				
float4 Subtract0=float4( 1.0, 1.0, 1.0, 1.0 ) - _blend.xxxx;
float4 Tex2D1=tex2D(_Diffuse1,(IN.uv_Diffuse1.xyxy).xy);
float4 Multiply0=Subtract0 * Tex2D1;
float4 Tex2D2=tex2D(_Diffuse2,(IN.uv_Diffuse2.xyxy).xy);
float4 Multiply2=_blend.xxxx * Tex2D2;
float4 Add0=Multiply0 + Multiply2;
float4 Subtract1=float4( 1.0, 1.0, 1.0, 1.0 ) - _blend.xxxx;
float4 Tex2D0=tex2D(_Normal1,(IN.uv_Normal1.xyxy).xy);
float4 Multiply4=Subtract1 * Tex2D0;
float4 Tex2D3=tex2D(_Normal2,(IN.uv_Normal2.xyxy).xy);
float4 Multiply5=_blend.xxxx * Tex2D3;
float4 Add2=Multiply4 + Multiply5;
float4 UnpackNormal0=float4(UnpackNormal(Add2).xyz, 1.0);
float4 Multiply1=Subtract0 * Tex2D1.aaaa;
float4 Multiply3=_blend.xxxx * Tex2D2.aaaa;
float4 Add1=Multiply1 + Multiply3;
float4 Master0_2_NoInput = float4(0,0,0,0);
float4 Master0_5_NoInput = float4(1,1,1,1);
float4 Master0_7_NoInput = float4(0,0,0,0);
float4 Master0_6_NoInput = float4(1,1,1,1);
o.Albedo = Add0;
o.Normal = UnpackNormal0;
o.Specular = _shine.xxxx;
o.Gloss = Add1;

				o.Normal = normalize(o.Normal);
			}
		ENDCG
	}
	Fallback "Diffuse"
}