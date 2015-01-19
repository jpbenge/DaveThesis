// Shader created with Shader Forge v1.02 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.02;sub:START;pass:START;ps:flbk:,lico:1,lgpr:1,nrmq:1,limd:1,uamb:True,mssp:True,lmpd:False,lprd:False,rprd:False,enco:False,frtr:True,vitr:True,dbil:False,rmgx:True,rpth:0,hqsc:True,hqlp:False,tesm:0,blpr:0,bsrc:0,bdst:1,culm:0,dpts:2,wrdp:True,ufog:True,aust:True,igpj:False,qofs:0,qpre:1,rntp:1,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,ofsf:0,ofsu:0,f2p0:True;n:type:ShaderForge.SFN_Final,id:133,x:34161,y:32428,varname:node_133,prsc:2|diff-5207-OUT,spec-9405-OUT,gloss-8930-OUT,normal-2177-OUT,amdfl-8412-OUT;n:type:ShaderForge.SFN_Tex2d,id:611,x:32059,y:32057,ptovrint:False,ptlb:Oil Normal,ptin:_OilNormal,varname:node_611,prsc:2,tex:963d0620b29a64461a3a00158128db59,ntxv:3,isnm:True;n:type:ShaderForge.SFN_Tex2d,id:3091,x:30977,y:31784,ptovrint:False,ptlb:Oil Diffuse,ptin:_OilDiffuse,varname:node_3091,prsc:2,tex:034da740aef294e518e6d974983b0131,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Slider,id:4017,x:31863,y:31627,ptovrint:False,ptlb:Oil,ptin:_Oil,varname:node_4017,prsc:2,min:0,cur:0,max:1;n:type:ShaderForge.SFN_Slider,id:1430,x:33339,y:33161,ptovrint:False,ptlb:Water,ptin:_Water,varname:node_4017,prsc:2,min:0,cur:0,max:1;n:type:ShaderForge.SFN_Lerp,id:8270,x:32312,y:31378,varname:node_8270,prsc:2|A-6903-RGB,B-3091-RGB,T-4017-OUT;n:type:ShaderForge.SFN_Tex2d,id:6903,x:31929,y:31267,ptovrint:False,ptlb:Base Diffuse,ptin:_BaseDiffuse,varname:node_6903,prsc:2,tex:b0a0186890be9b647bd1a3623cbd86a4,ntxv:2,isnm:False;n:type:ShaderForge.SFN_Tex2d,id:8734,x:31908,y:31428,ptovrint:False,ptlb:Base Normal,ptin:_BaseNormal,varname:node_6903,prsc:2,tex:dd243bc6a69423d43a7d11b793882fe3,ntxv:3,isnm:True;n:type:ShaderForge.SFN_Tex2d,id:6725,x:31908,y:31627,ptovrint:False,ptlb:Base Spec,ptin:_BaseSpec,varname:node_6903,prsc:2,tex:da2e28888ae774f5e9d37174aec8e22b,ntxv:1,isnm:False;n:type:ShaderForge.SFN_Lerp,id:6430,x:32312,y:31506,varname:node_6430,prsc:2|A-8734-RGB,B-611-RGB,T-4017-OUT;n:type:ShaderForge.SFN_Lerp,id:1826,x:32312,y:31641,varname:node_1826,prsc:2|A-6725-RGB,B-3091-B,T-4017-OUT;n:type:ShaderForge.SFN_Tex2d,id:9705,x:32183,y:32469,ptovrint:False,ptlb:Ice Diffuse,ptin:_IceDiffuse,varname:node_6903,prsc:2,tex:ef799823d14ec4c3f8a32f567cebf7fa,ntxv:2,isnm:False;n:type:ShaderForge.SFN_Tex2d,id:2985,x:32183,y:32650,ptovrint:False,ptlb:Ice Normal,ptin:_IceNormal,varname:node_6903,prsc:2,tex:70f442b36a8b04fcda0bfa4edf5adfa6,ntxv:3,isnm:True;n:type:ShaderForge.SFN_Tex2d,id:3334,x:32198,y:32832,ptovrint:False,ptlb:Ice Spec,ptin:_IceSpec,varname:node_6903,prsc:2,tex:fb364cf83766e47ac861bd2e0261985c,ntxv:1,isnm:False;n:type:ShaderForge.SFN_Lerp,id:6024,x:33036,y:32320,varname:node_6024,prsc:2|A-1826-OUT,B-3334-RGB,T-1851-OUT;n:type:ShaderForge.SFN_Lerp,id:4633,x:33036,y:32185,varname:node_4633,prsc:2|A-6430-OUT,B-2985-RGB,T-1851-OUT;n:type:ShaderForge.SFN_Lerp,id:6713,x:33036,y:32057,varname:node_6713,prsc:2|A-8270-OUT,B-9705-RGB,T-1851-OUT;n:type:ShaderForge.SFN_Slider,id:641,x:32034,y:31937,ptovrint:False,ptlb:Oil Shininess,ptin:_OilShininess,varname:node_4017,prsc:2,min:0,cur:0,max:1;n:type:ShaderForge.SFN_Slider,id:6139,x:32056,y:31789,ptovrint:False,ptlb:Base Shininess,ptin:_BaseShininess,varname:node_4017,prsc:2,min:0,cur:0,max:1;n:type:ShaderForge.SFN_Lerp,id:5730,x:32477,y:31775,varname:node_5730,prsc:2|A-6139-OUT,B-641-OUT,T-4017-OUT;n:type:ShaderForge.SFN_Lerp,id:1288,x:33036,y:32476,varname:node_1288,prsc:2|A-5730-OUT,B-9552-OUT,T-1851-OUT;n:type:ShaderForge.SFN_Slider,id:9552,x:32493,y:32505,ptovrint:False,ptlb:Ice Shininess,ptin:_IceShininess,varname:node_9552,prsc:2,min:0,cur:0,max:1;n:type:ShaderForge.SFN_Slider,id:1851,x:32469,y:32761,ptovrint:False,ptlb:Ice,ptin:_Ice,varname:node_4017,prsc:2,min:0,cur:0,max:1;n:type:ShaderForge.SFN_Tex2d,id:8044,x:33447,y:32418,ptovrint:False,ptlb:Water Diffuse,ptin:_WaterDiffuse,varname:node_6903,prsc:2,tex:ef799823d14ec4c3f8a32f567cebf7fa,ntxv:2,isnm:False;n:type:ShaderForge.SFN_Tex2d,id:4809,x:33447,y:32599,ptovrint:False,ptlb:Water Normal,ptin:_WaterNormal,varname:node_6903,prsc:2,tex:70f442b36a8b04fcda0bfa4edf5adfa6,ntxv:3,isnm:True;n:type:ShaderForge.SFN_Tex2d,id:610,x:33462,y:32781,ptovrint:False,ptlb:Water Spec,ptin:_WaterSpec,varname:node_6903,prsc:2,tex:fb364cf83766e47ac861bd2e0261985c,ntxv:1,isnm:False;n:type:ShaderForge.SFN_Slider,id:7321,x:33373,y:32987,ptovrint:False,ptlb:Water Shininess,ptin:_WaterShininess,varname:node_9552,prsc:2,min:0,cur:0,max:1;n:type:ShaderForge.SFN_Lerp,id:5207,x:33757,y:32231,varname:node_5207,prsc:2|A-6713-OUT,B-8044-RGB,T-1430-OUT;n:type:ShaderForge.SFN_Lerp,id:8930,x:33757,y:32650,varname:node_8930,prsc:2|A-1288-OUT,B-7321-OUT,T-1430-OUT;n:type:ShaderForge.SFN_Lerp,id:2177,x:33757,y:32371,varname:node_2177,prsc:2|A-4633-OUT,B-4809-RGB,T-1430-OUT;n:type:ShaderForge.SFN_Lerp,id:9405,x:33757,y:32504,varname:node_9405,prsc:2|A-6024-OUT,B-610-RGB,T-1430-OUT;n:type:ShaderForge.SFN_Slider,id:9822,x:32813,y:32793,ptovrint:False,ptlb:Ice Ambient Diff,ptin:_IceAmbientDiff,varname:node_9822,prsc:2,min:0,cur:0.5,max:1;n:type:ShaderForge.SFN_Vector1,id:7072,x:32892,y:32697,varname:node_7072,prsc:2,v1:0;n:type:ShaderForge.SFN_Lerp,id:8412,x:33197,y:32643,varname:node_8412,prsc:2|A-7072-OUT,B-9822-OUT,T-1851-OUT;proporder:6903-8734-6725-6139-3091-611-641-4017-9705-2985-3334-9552-9822-1851-8044-4809-610-7321-1430;pass:END;sub:END;*/

Shader "Shader Forge/FloorOilWaterIce_Fallback" {
    Properties {
        _BaseDiffuse ("Base Diffuse", 2D) = "black" {}
        _BaseNormal ("Base Normal", 2D) = "bump" {}
        _BaseSpec ("Base Spec", 2D) = "gray" {}
        _BaseShininess ("Base Shininess", Range(0, 1)) = 0
        _OilDiffuse ("Oil Diffuse", 2D) = "white" {}
        _OilNormal ("Oil Normal", 2D) = "bump" {}
        _OilShininess ("Oil Shininess", Range(0, 1)) = 0
        _Oil ("Oil", Range(0, 1)) = 0
        _IceDiffuse ("Ice Diffuse", 2D) = "black" {}
        _IceNormal ("Ice Normal", 2D) = "bump" {}
        _IceSpec ("Ice Spec", 2D) = "gray" {}
        _IceShininess ("Ice Shininess", Range(0, 1)) = 0
        _IceAmbientDiff ("Ice Ambient Diff", Range(0, 1)) = 0.5
        _Ice ("Ice", Range(0, 1)) = 0
        _WaterDiffuse ("Water Diffuse", 2D) = "black" {}
        _WaterNormal ("Water Normal", 2D) = "bump" {}
        _WaterSpec ("Water Spec", 2D) = "gray" {}
        _WaterShininess ("Water Shininess", Range(0, 1)) = 0
        _Water ("Water", Range(0, 1)) = 0
    }
    SubShader {
        Tags {
            "RenderType"="Opaque"
        }
        Pass {
            Name "ForwardBase"
            Tags {
                "LightMode"="ForwardBase"
            }
            
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDBASE
            #include "UnityCG.cginc"
            #include "AutoLight.cginc"
            #pragma multi_compile_fwdbase_fullshadows
            #pragma exclude_renderers xbox360 ps3 flash d3d11_9x 
            #pragma target 2.0
            uniform float4 _LightColor0;
            uniform sampler2D _OilNormal; uniform float4 _OilNormal_ST;
            uniform sampler2D _OilDiffuse; uniform float4 _OilDiffuse_ST;
            uniform float _Oil;
            uniform float _Water;
            uniform sampler2D _BaseDiffuse; uniform float4 _BaseDiffuse_ST;
            uniform sampler2D _BaseNormal; uniform float4 _BaseNormal_ST;
            uniform sampler2D _BaseSpec; uniform float4 _BaseSpec_ST;
            uniform sampler2D _IceDiffuse; uniform float4 _IceDiffuse_ST;
            uniform sampler2D _IceNormal; uniform float4 _IceNormal_ST;
            uniform sampler2D _IceSpec; uniform float4 _IceSpec_ST;
            uniform float _OilShininess;
            uniform float _BaseShininess;
            uniform float _IceShininess;
            uniform float _Ice;
            uniform sampler2D _WaterDiffuse; uniform float4 _WaterDiffuse_ST;
            uniform sampler2D _WaterNormal; uniform float4 _WaterNormal_ST;
            uniform sampler2D _WaterSpec; uniform float4 _WaterSpec_ST;
            uniform float _WaterShininess;
            uniform float _IceAmbientDiff;
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
                LIGHTING_COORDS(5,6)
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
                TRANSFER_VERTEX_TO_FRAGMENT(o)
                return o;
            }
            fixed4 frag(VertexOutput i) : COLOR {
                i.normalDir = normalize(i.normalDir);
                float3x3 tangentTransform = float3x3( i.tangentDir, i.binormalDir, i.normalDir);
/////// Vectors:
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 _BaseNormal_var = UnpackNormal(tex2D(_BaseNormal,TRANSFORM_TEX(i.uv0, _BaseNormal)));
                float3 _OilNormal_var = UnpackNormal(tex2D(_OilNormal,TRANSFORM_TEX(i.uv0, _OilNormal)));
                float3 _IceNormal_var = UnpackNormal(tex2D(_IceNormal,TRANSFORM_TEX(i.uv0, _IceNormal)));
                float3 _WaterNormal_var = UnpackNormal(tex2D(_WaterNormal,TRANSFORM_TEX(i.uv0, _WaterNormal)));
                float3 normalLocal = lerp(lerp(lerp(_BaseNormal_var.rgb,_OilNormal_var.rgb,_Oil),_IceNormal_var.rgb,_Ice),_WaterNormal_var.rgb,_Water);
                float3 normalDirection = normalize(mul( normalLocal, tangentTransform )); // Perturbed normals
                float3 lightDirection = normalize(_WorldSpaceLightPos0.xyz);
                float3 lightColor = _LightColor0.rgb;
                float3 halfDirection = normalize(viewDirection+lightDirection);
////// Lighting:
                float attenuation = LIGHT_ATTENUATION(i);
                float3 attenColor = attenuation * _LightColor0.xyz;
///////// Gloss:
                float gloss = lerp(lerp(lerp(_BaseShininess,_OilShininess,_Oil),_IceShininess,_Ice),_WaterShininess,_Water);
                float specPow = exp2( gloss * 10.0+1.0);
////// Specular:
                float NdotL = max(0, dot( normalDirection, lightDirection ));
                float4 _BaseSpec_var = tex2D(_BaseSpec,TRANSFORM_TEX(i.uv0, _BaseSpec));
                float4 _OilDiffuse_var = tex2D(_OilDiffuse,TRANSFORM_TEX(i.uv0, _OilDiffuse));
                float4 _IceSpec_var = tex2D(_IceSpec,TRANSFORM_TEX(i.uv0, _IceSpec));
                float4 _WaterSpec_var = tex2D(_WaterSpec,TRANSFORM_TEX(i.uv0, _WaterSpec));
                float3 specularColor = lerp(lerp(lerp(_BaseSpec_var.rgb,float3(_OilDiffuse_var.b,_OilDiffuse_var.b,_OilDiffuse_var.b),_Oil),_IceSpec_var.rgb,_Ice),_WaterSpec_var.rgb,_Water);
                float3 directSpecular = (floor(attenuation) * _LightColor0.xyz) * pow(max(0,dot(halfDirection,normalDirection)),specPow);
                float3 specular = directSpecular * specularColor;
/////// Diffuse:
                NdotL = max(0.0,dot( normalDirection, lightDirection ));
                float3 indirectDiffuse = float3(0,0,0);
                float3 directDiffuse = max( 0.0, NdotL) * attenColor;
                indirectDiffuse += UNITY_LIGHTMODEL_AMBIENT.rgb; // Ambient Light
                float node_8412 = lerp(0.0,_IceAmbientDiff,_Ice);
                indirectDiffuse += float3(node_8412,node_8412,node_8412); // Diffuse Ambient Light
                float4 _BaseDiffuse_var = tex2D(_BaseDiffuse,TRANSFORM_TEX(i.uv0, _BaseDiffuse));
                float4 _IceDiffuse_var = tex2D(_IceDiffuse,TRANSFORM_TEX(i.uv0, _IceDiffuse));
                float4 _WaterDiffuse_var = tex2D(_WaterDiffuse,TRANSFORM_TEX(i.uv0, _WaterDiffuse));
                float3 diffuse = (directDiffuse + indirectDiffuse) * lerp(lerp(lerp(_BaseDiffuse_var.rgb,_OilDiffuse_var.rgb,_Oil),_IceDiffuse_var.rgb,_Ice),_WaterDiffuse_var.rgb,_Water);
/// Final Color:
                float3 finalColor = diffuse + specular;
                return fixed4(finalColor,1);
            }
            ENDCG
        }
        Pass {
            Name "ForwardAdd"
            Tags {
                "LightMode"="ForwardAdd"
            }
            Blend One One
            
            
            Fog { Color (0,0,0,0) }
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDADD
            #include "UnityCG.cginc"
            #include "AutoLight.cginc"
            #pragma multi_compile_fwdadd_fullshadows
            #pragma exclude_renderers xbox360 ps3 flash d3d11_9x 
            #pragma target 2.0
            uniform float4 _LightColor0;
            uniform sampler2D _OilNormal; uniform float4 _OilNormal_ST;
            uniform sampler2D _OilDiffuse; uniform float4 _OilDiffuse_ST;
            uniform float _Oil;
            uniform float _Water;
            uniform sampler2D _BaseDiffuse; uniform float4 _BaseDiffuse_ST;
            uniform sampler2D _BaseNormal; uniform float4 _BaseNormal_ST;
            uniform sampler2D _BaseSpec; uniform float4 _BaseSpec_ST;
            uniform sampler2D _IceDiffuse; uniform float4 _IceDiffuse_ST;
            uniform sampler2D _IceNormal; uniform float4 _IceNormal_ST;
            uniform sampler2D _IceSpec; uniform float4 _IceSpec_ST;
            uniform float _OilShininess;
            uniform float _BaseShininess;
            uniform float _IceShininess;
            uniform float _Ice;
            uniform sampler2D _WaterDiffuse; uniform float4 _WaterDiffuse_ST;
            uniform sampler2D _WaterNormal; uniform float4 _WaterNormal_ST;
            uniform sampler2D _WaterSpec; uniform float4 _WaterSpec_ST;
            uniform float _WaterShininess;
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
                LIGHTING_COORDS(5,6)
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
                TRANSFER_VERTEX_TO_FRAGMENT(o)
                return o;
            }
            fixed4 frag(VertexOutput i) : COLOR {
                i.normalDir = normalize(i.normalDir);
                float3x3 tangentTransform = float3x3( i.tangentDir, i.binormalDir, i.normalDir);
/////// Vectors:
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 _BaseNormal_var = UnpackNormal(tex2D(_BaseNormal,TRANSFORM_TEX(i.uv0, _BaseNormal)));
                float3 _OilNormal_var = UnpackNormal(tex2D(_OilNormal,TRANSFORM_TEX(i.uv0, _OilNormal)));
                float3 _IceNormal_var = UnpackNormal(tex2D(_IceNormal,TRANSFORM_TEX(i.uv0, _IceNormal)));
                float3 _WaterNormal_var = UnpackNormal(tex2D(_WaterNormal,TRANSFORM_TEX(i.uv0, _WaterNormal)));
                float3 normalLocal = lerp(lerp(lerp(_BaseNormal_var.rgb,_OilNormal_var.rgb,_Oil),_IceNormal_var.rgb,_Ice),_WaterNormal_var.rgb,_Water);
                float3 normalDirection = normalize(mul( normalLocal, tangentTransform )); // Perturbed normals
                float3 lightDirection = normalize(lerp(_WorldSpaceLightPos0.xyz, _WorldSpaceLightPos0.xyz - i.posWorld.xyz,_WorldSpaceLightPos0.w));
                float3 lightColor = _LightColor0.rgb;
                float3 halfDirection = normalize(viewDirection+lightDirection);
////// Lighting:
                float attenuation = LIGHT_ATTENUATION(i);
                float3 attenColor = attenuation * _LightColor0.xyz;
///////// Gloss:
                float gloss = lerp(lerp(lerp(_BaseShininess,_OilShininess,_Oil),_IceShininess,_Ice),_WaterShininess,_Water);
                float specPow = exp2( gloss * 10.0+1.0);
////// Specular:
                float NdotL = max(0, dot( normalDirection, lightDirection ));
                float4 _BaseSpec_var = tex2D(_BaseSpec,TRANSFORM_TEX(i.uv0, _BaseSpec));
                float4 _OilDiffuse_var = tex2D(_OilDiffuse,TRANSFORM_TEX(i.uv0, _OilDiffuse));
                float4 _IceSpec_var = tex2D(_IceSpec,TRANSFORM_TEX(i.uv0, _IceSpec));
                float4 _WaterSpec_var = tex2D(_WaterSpec,TRANSFORM_TEX(i.uv0, _WaterSpec));
                float3 specularColor = lerp(lerp(lerp(_BaseSpec_var.rgb,float3(_OilDiffuse_var.b,_OilDiffuse_var.b,_OilDiffuse_var.b),_Oil),_IceSpec_var.rgb,_Ice),_WaterSpec_var.rgb,_Water);
                float3 directSpecular = attenColor * pow(max(0,dot(halfDirection,normalDirection)),specPow);
                float3 specular = directSpecular * specularColor;
/////// Diffuse:
                NdotL = max(0.0,dot( normalDirection, lightDirection ));
                float3 directDiffuse = max( 0.0, NdotL) * attenColor;
                float4 _BaseDiffuse_var = tex2D(_BaseDiffuse,TRANSFORM_TEX(i.uv0, _BaseDiffuse));
                float4 _IceDiffuse_var = tex2D(_IceDiffuse,TRANSFORM_TEX(i.uv0, _IceDiffuse));
                float4 _WaterDiffuse_var = tex2D(_WaterDiffuse,TRANSFORM_TEX(i.uv0, _WaterDiffuse));
                float3 diffuse = directDiffuse * lerp(lerp(lerp(_BaseDiffuse_var.rgb,_OilDiffuse_var.rgb,_Oil),_IceDiffuse_var.rgb,_Ice),_WaterDiffuse_var.rgb,_Water);
/// Final Color:
                float3 finalColor = diffuse + specular;
                return fixed4(finalColor * 1,0);
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
