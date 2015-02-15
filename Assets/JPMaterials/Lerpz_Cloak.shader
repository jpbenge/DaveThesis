// Shader created with Shader Forge v1.02 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.02;sub:START;pass:START;ps:flbk:Shader Forge/Lerpz_Cloak_Fallback,lico:1,lgpr:1,nrmq:1,limd:1,uamb:True,mssp:True,lmpd:False,lprd:False,rprd:False,enco:False,frtr:True,vitr:True,dbil:False,rmgx:True,rpth:0,hqsc:True,hqlp:False,tesm:0,blpr:1,bsrc:3,bdst:7,culm:0,dpts:2,wrdp:False,ufog:True,aust:True,igpj:True,qofs:0,qpre:3,rntp:2,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:100,fgrf:500,ofsf:0,ofsu:0,f2p0:False;n:type:ShaderForge.SFN_Final,id:152,x:32950,y:32665,varname:node_152,prsc:2|diff-7803-OUT,spec-8449-A,gloss-4898-OUT,normal-6680-RGB,alpha-7727-OUT,refract-4279-OUT;n:type:ShaderForge.SFN_Tex2d,id:8449,x:32006,y:32503,ptovrint:False,ptlb:Diffuse,ptin:_Diffuse,varname:node_8449,prsc:2,tex:1702c13dcd1113a2a0008cea4ada8c59,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Tex2d,id:6680,x:31908,y:33016,ptovrint:False,ptlb:Normal,ptin:_Normal,varname:node_8449,prsc:2,tex:6c5199bacd1113a2a0008cea4ada8c59,ntxv:3,isnm:True;n:type:ShaderForge.SFN_Multiply,id:7803,x:32223,y:32649,varname:node_7803,prsc:2|A-8449-RGB,B-4333-RGB;n:type:ShaderForge.SFN_Color,id:4333,x:32006,y:32704,ptovrint:False,ptlb:Main Color,ptin:_MainColor,varname:node_922,prsc:2,glob:False,c1:1,c2:1,c3:1,c4:1;n:type:ShaderForge.SFN_Slider,id:8753,x:32211,y:32969,ptovrint:False,ptlb:Cloak,ptin:_Cloak,varname:node_4897,prsc:2,min:0,cur:1,max:1;n:type:ShaderForge.SFN_Slider,id:2066,x:32211,y:33128,ptovrint:False,ptlb:X Refract,ptin:_XRefract,varname:node_2066,prsc:2,min:0,cur:0.15,max:0.15;n:type:ShaderForge.SFN_Slider,id:6543,x:32190,y:33270,ptovrint:False,ptlb:Y Refract,ptin:_YRefract,varname:node_2066,prsc:2,min:0,cur:0.15,max:0.15;n:type:ShaderForge.SFN_Multiply,id:4279,x:32752,y:33045,varname:node_4279,prsc:2|A-8753-OUT,B-9948-OUT;n:type:ShaderForge.SFN_Append,id:9948,x:32566,y:33136,varname:node_9948,prsc:2|A-2066-OUT,B-6543-OUT;n:type:ShaderForge.SFN_OneMinus,id:7727,x:32611,y:32921,varname:node_7727,prsc:2|IN-8753-OUT;n:type:ShaderForge.SFN_Slider,id:4898,x:32251,y:32815,ptovrint:False,ptlb:Shininess,ptin:_Shininess,varname:node_4897,prsc:2,min:0,cur:0,max:1;proporder:4333-8449-6680-4898-8753-2066-6543;pass:END;sub:END;*/

Shader "Shader Forge/Lerpz_Cloak" {
    Properties {
        _MainColor ("Main Color", Color) = (1,1,1,1)
        _Diffuse ("Diffuse", 2D) = "white" {}
        _Normal ("Normal", 2D) = "bump" {}
        _Shininess ("Shininess", Range(0, 1)) = 0
        _Cloak ("Cloak", Range(0, 1)) = 1
        _XRefract ("X Refract", Range(0, 0.15)) = 0.15
        _YRefract ("Y Refract", Range(0, 0.15)) = 0.15
        [HideInInspector]_Cutoff ("Alpha cutoff", Range(0,1)) = 0.5
    }
    SubShader {
        Tags {
            "IgnoreProjector"="True"
            "Queue"="Transparent"
            "RenderType"="Transparent"
        }
        GrabPass{ }
        Pass {
            Name "ForwardBase"
            Tags {
                "LightMode"="ForwardBase"
            }
            Blend SrcAlpha OneMinusSrcAlpha
            ZWrite Off
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDBASE
            #include "UnityCG.cginc"
            #pragma multi_compile_fwdbase
            #pragma exclude_renderers xbox360 ps3 flash d3d11_9x 
            #pragma target 3.0
            uniform float4 _LightColor0;
            uniform sampler2D _GrabTexture;
            uniform sampler2D _Diffuse; uniform float4 _Diffuse_ST;
            uniform sampler2D _Normal; uniform float4 _Normal_ST;
            uniform float4 _MainColor;
            uniform float _Cloak;
            uniform float _XRefract;
            uniform float _YRefract;
            uniform float _Shininess;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float4 tangent : TANGENT;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float4 posWorld : TEXCOORD1;
                float3 normalDir : TEXCOORD2;
                float3 tangentDir : TEXCOORD3;
                float3 binormalDir : TEXCOORD4;
                float4 screenPos : TEXCOORD5;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o;
                o.uv0 = v.texcoord0;
                o.normalDir = mul(_Object2World, float4(v.normal,0)).xyz;
                o.tangentDir = normalize( mul( _Object2World, float4( v.tangent.xyz, 0.0 ) ).xyz );
                o.binormalDir = normalize(cross(o.normalDir, o.tangentDir) * v.tangent.w);
                o.posWorld = mul(_Object2World, v.vertex);
                float3 lightColor = _LightColor0.rgb;
                o.pos = mul(UNITY_MATRIX_MVP, v.vertex);
                o.screenPos = o.pos;
                return o;
            }
            fixed4 frag(VertexOutput i) : COLOR {
                #if UNITY_UV_STARTS_AT_TOP
                    float grabSign = -_ProjectionParams.x;
                #else
                    float grabSign = _ProjectionParams.x;
                #endif
                i.normalDir = normalize(i.normalDir);
                i.screenPos = float4( i.screenPos.xy / i.screenPos.w, 0, 0 );
                i.screenPos.y *= _ProjectionParams.x;
                float2 sceneUVs = float2(1,grabSign)*i.screenPos.xy*0.5+0.5 + (_Cloak*float2(_XRefract,_YRefract));
                float4 sceneColor = tex2D(_GrabTexture, sceneUVs);
                float3x3 tangentTransform = float3x3( i.tangentDir, i.binormalDir, i.normalDir);
/////// Vectors:
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 _Normal_var = UnpackNormal(tex2D(_Normal,TRANSFORM_TEX(i.uv0, _Normal)));
                float3 normalLocal = _Normal_var.rgb;
                float3 normalDirection = normalize(mul( normalLocal, tangentTransform )); // Perturbed normals
                float3 lightDirection = normalize(_WorldSpaceLightPos0.xyz);
                float3 lightColor = _LightColor0.rgb;
                float3 halfDirection = normalize(viewDirection+lightDirection);
////// Lighting:
                float attenuation = 1;
                float3 attenColor = attenuation * _LightColor0.xyz;
///////// Gloss:
                float gloss = _Shininess;
                float specPow = exp2( gloss * 10.0+1.0);
////// Specular:
                float NdotL = max(0, dot( normalDirection, lightDirection ));
                float4 _Diffuse_var = tex2D(_Diffuse,TRANSFORM_TEX(i.uv0, _Diffuse));
                float3 specularColor = float3(_Diffuse_var.a,_Diffuse_var.a,_Diffuse_var.a);
                float3 directSpecular = (floor(attenuation) * _LightColor0.xyz) * pow(max(0,dot(halfDirection,normalDirection)),specPow);
                float3 specular = directSpecular * specularColor;
/////// Diffuse:
                NdotL = max(0.0,dot( normalDirection, lightDirection ));
                float3 indirectDiffuse = float3(0,0,0);
                float3 directDiffuse = max( 0.0, NdotL) * attenColor;
                indirectDiffuse += UNITY_LIGHTMODEL_AMBIENT.rgb; // Ambient Light
                float3 diffuse = (directDiffuse + indirectDiffuse) * (_Diffuse_var.rgb*_MainColor.rgb);
/// Final Color:
                float3 finalColor = diffuse + specular;
                return fixed4(lerp(sceneColor.rgb, finalColor,(1.0 - _Cloak)),1);
            }
            ENDCG
        }
        Pass {
            Name "ForwardAdd"
            Tags {
                "LightMode"="ForwardAdd"
            }
            Blend One One
            ZWrite Off
            
            Fog { Color (0,0,0,0) }
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDADD
            #include "UnityCG.cginc"
            #include "AutoLight.cginc"
            #pragma multi_compile_fwdadd
            #pragma exclude_renderers xbox360 ps3 flash d3d11_9x 
            #pragma target 3.0
            uniform float4 _LightColor0;
            uniform sampler2D _GrabTexture;
            uniform sampler2D _Diffuse; uniform float4 _Diffuse_ST;
            uniform sampler2D _Normal; uniform float4 _Normal_ST;
            uniform float4 _MainColor;
            uniform float _Cloak;
            uniform float _XRefract;
            uniform float _YRefract;
            uniform float _Shininess;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float4 tangent : TANGENT;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float4 posWorld : TEXCOORD1;
                float3 normalDir : TEXCOORD2;
                float3 tangentDir : TEXCOORD3;
                float3 binormalDir : TEXCOORD4;
                float4 screenPos : TEXCOORD5;
                LIGHTING_COORDS(6,7)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o;
                o.uv0 = v.texcoord0;
                o.normalDir = mul(_Object2World, float4(v.normal,0)).xyz;
                o.tangentDir = normalize( mul( _Object2World, float4( v.tangent.xyz, 0.0 ) ).xyz );
                o.binormalDir = normalize(cross(o.normalDir, o.tangentDir) * v.tangent.w);
                o.posWorld = mul(_Object2World, v.vertex);
                float3 lightColor = _LightColor0.rgb;
                o.pos = mul(UNITY_MATRIX_MVP, v.vertex);
                o.screenPos = o.pos;
                TRANSFER_VERTEX_TO_FRAGMENT(o)
                return o;
            }
            fixed4 frag(VertexOutput i) : COLOR {
                #if UNITY_UV_STARTS_AT_TOP
                    float grabSign = -_ProjectionParams.x;
                #else
                    float grabSign = _ProjectionParams.x;
                #endif
                i.normalDir = normalize(i.normalDir);
                i.screenPos = float4( i.screenPos.xy / i.screenPos.w, 0, 0 );
                i.screenPos.y *= _ProjectionParams.x;
                float2 sceneUVs = float2(1,grabSign)*i.screenPos.xy*0.5+0.5 + (_Cloak*float2(_XRefract,_YRefract));
                float4 sceneColor = tex2D(_GrabTexture, sceneUVs);
                float3x3 tangentTransform = float3x3( i.tangentDir, i.binormalDir, i.normalDir);
/////// Vectors:
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 _Normal_var = UnpackNormal(tex2D(_Normal,TRANSFORM_TEX(i.uv0, _Normal)));
                float3 normalLocal = _Normal_var.rgb;
                float3 normalDirection = normalize(mul( normalLocal, tangentTransform )); // Perturbed normals
                float3 lightDirection = normalize(lerp(_WorldSpaceLightPos0.xyz, _WorldSpaceLightPos0.xyz - i.posWorld.xyz,_WorldSpaceLightPos0.w));
                float3 lightColor = _LightColor0.rgb;
                float3 halfDirection = normalize(viewDirection+lightDirection);
////// Lighting:
                float attenuation = LIGHT_ATTENUATION(i);
                float3 attenColor = attenuation * _LightColor0.xyz;
///////// Gloss:
                float gloss = _Shininess;
                float specPow = exp2( gloss * 10.0+1.0);
////// Specular:
                float NdotL = max(0, dot( normalDirection, lightDirection ));
                float4 _Diffuse_var = tex2D(_Diffuse,TRANSFORM_TEX(i.uv0, _Diffuse));
                float3 specularColor = float3(_Diffuse_var.a,_Diffuse_var.a,_Diffuse_var.a);
                float3 directSpecular = attenColor * pow(max(0,dot(halfDirection,normalDirection)),specPow);
                float3 specular = directSpecular * specularColor;
/////// Diffuse:
                NdotL = max(0.0,dot( normalDirection, lightDirection ));
                float3 directDiffuse = max( 0.0, NdotL) * attenColor;
                float3 diffuse = directDiffuse * (_Diffuse_var.rgb*_MainColor.rgb);
/// Final Color:
                float3 finalColor = diffuse + specular;
                return fixed4(finalColor * (1.0 - _Cloak),0);
            }
            ENDCG
        }
    }
    FallBack "Shader Forge/Lerpz_Cloak_Fallback"
    CustomEditor "ShaderForgeMaterialInspector"
}
