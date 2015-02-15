// Shader created with Shader Forge v1.02 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.02;sub:START;pass:START;ps:flbk:,lico:1,lgpr:1,nrmq:1,limd:1,uamb:True,mssp:True,lmpd:False,lprd:False,rprd:False,enco:False,frtr:True,vitr:True,dbil:False,rmgx:True,rpth:0,hqsc:True,hqlp:False,tesm:0,blpr:0,bsrc:0,bdst:1,culm:0,dpts:2,wrdp:True,ufog:True,aust:True,igpj:False,qofs:0,qpre:1,rntp:1,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,ofsf:0,ofsu:0,f2p0:True;n:type:ShaderForge.SFN_Final,id:133,x:32795,y:31695,varname:node_133,prsc:2|diff-8270-OUT,spec-1826-OUT,gloss-5730-OUT,normal-6430-OUT,amdfl-7080-OUT;n:type:ShaderForge.SFN_Tex2d,id:611,x:32175,y:32006,ptovrint:False,ptlb:Oil Normal,ptin:_OilNormal,varname:node_611,prsc:2,tex:963d0620b29a64461a3a00158128db59,ntxv:3,isnm:True;n:type:ShaderForge.SFN_Tex2d,id:3091,x:30977,y:31784,ptovrint:False,ptlb:Oil Diffuse,ptin:_OilDiffuse,varname:node_3091,prsc:2,tex:034da740aef294e518e6d974983b0131,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Multiply,id:6796,x:31571,y:32012,varname:node_6796,prsc:2|A-3343-OUT,B-8585-OUT;n:type:ShaderForge.SFN_Multiply,id:8585,x:31609,y:32208,varname:node_8585,prsc:2|A-8876-RGB,B-4301-OUT;n:type:ShaderForge.SFN_Slider,id:4301,x:31238,y:32350,ptovrint:False,ptlb:Oil Power,ptin:_OilPower,varname:node_4461,prsc:2,min:0,cur:0.2038835,max:1;n:type:ShaderForge.SFN_Cubemap,id:8876,x:31251,y:32130,ptovrint:False,ptlb:Oil Iridescence,ptin:_OilIridescence,varname:node_8876,prsc:2,cube:4163ca1a4b8abec4ab840aa4f30f28a7,pvfc:0;n:type:ShaderForge.SFN_Lerp,id:4193,x:31846,y:31883,varname:node_4193,prsc:2|A-6796-OUT,B-3091-RGB,T-3091-B;n:type:ShaderForge.SFN_OneMinus,id:6351,x:31189,y:31925,varname:node_6351,prsc:2|IN-3091-RGB;n:type:ShaderForge.SFN_Floor,id:3343,x:31353,y:31949,varname:node_3343,prsc:2|IN-6351-OUT;n:type:ShaderForge.SFN_Slider,id:4017,x:31479,y:31779,ptovrint:False,ptlb:Oil,ptin:_Oil,varname:node_4017,prsc:2,min:0,cur:0,max:1;n:type:ShaderForge.SFN_Lerp,id:8270,x:32312,y:31378,varname:node_8270,prsc:2|A-6903-RGB,B-3091-RGB,T-4017-OUT;n:type:ShaderForge.SFN_Tex2d,id:6903,x:31929,y:31267,ptovrint:False,ptlb:Base Diffuse,ptin:_BaseDiffuse,varname:node_6903,prsc:2,tex:b0a0186890be9b647bd1a3623cbd86a4,ntxv:2,isnm:False;n:type:ShaderForge.SFN_Tex2d,id:8734,x:31298,y:31322,ptovrint:False,ptlb:Base Normal,ptin:_BaseNormal,varname:node_6903,prsc:2,tex:dd243bc6a69423d43a7d11b793882fe3,ntxv:3,isnm:True;n:type:ShaderForge.SFN_Tex2d,id:6725,x:31747,y:31597,ptovrint:False,ptlb:Base Spec,ptin:_BaseSpec,varname:node_6903,prsc:2,tex:da2e28888ae774f5e9d37174aec8e22b,ntxv:1,isnm:False;n:type:ShaderForge.SFN_Lerp,id:6430,x:32312,y:31506,varname:node_6430,prsc:2|A-2759-OUT,B-611-RGB,T-4017-OUT;n:type:ShaderForge.SFN_Lerp,id:1826,x:32312,y:31641,varname:node_1826,prsc:2|A-3408-OUT,B-4193-OUT,T-4017-OUT;n:type:ShaderForge.SFN_Slider,id:641,x:32036,y:31895,ptovrint:False,ptlb:Oil Shininess,ptin:_OilShininess,varname:node_4017,prsc:2,min:0,cur:0,max:1;n:type:ShaderForge.SFN_Slider,id:6139,x:32056,y:31789,ptovrint:False,ptlb:Base Shininess,ptin:_BaseShininess,varname:node_4017,prsc:2,min:0,cur:0,max:1;n:type:ShaderForge.SFN_Lerp,id:5730,x:32435,y:31779,varname:node_5730,prsc:2|A-6139-OUT,B-641-OUT,T-4017-OUT;n:type:ShaderForge.SFN_Slider,id:6065,x:30664,y:31558,ptovrint:False,ptlb:Base Normal Strength,ptin:_BaseNormalStrength,varname:node_6065,prsc:2,min:0,cur:0.8,max:1;n:type:ShaderForge.SFN_Vector1,id:4229,x:30958,y:31359,varname:node_4229,prsc:2,v1:1;n:type:ShaderForge.SFN_Vector1,id:2166,x:30970,y:31429,varname:node_2166,prsc:2,v1:1;n:type:ShaderForge.SFN_Append,id:6372,x:31161,y:31429,varname:node_6372,prsc:2|A-4229-OUT,B-2166-OUT;n:type:ShaderForge.SFN_OneMinus,id:1931,x:31054,y:31574,varname:node_1931,prsc:2|IN-6065-OUT;n:type:ShaderForge.SFN_Append,id:8447,x:31332,y:31510,varname:node_8447,prsc:2|A-6372-OUT,B-1931-OUT;n:type:ShaderForge.SFN_Multiply,id:2759,x:31595,y:31423,varname:node_2759,prsc:2|A-8734-RGB,B-8447-OUT;n:type:ShaderForge.SFN_Color,id:7048,x:31900,y:31462,ptovrint:False,ptlb:Base Spec Color,ptin:_BaseSpecColor,varname:node_7048,prsc:2,glob:False,c1:0.5,c2:0.5,c3:0.5,c4:1;n:type:ShaderForge.SFN_Multiply,id:3408,x:32116,y:31558,varname:node_3408,prsc:2|A-7048-RGB,B-6725-RGB;n:type:ShaderForge.SFN_Lerp,id:7080,x:32091,y:32172,varname:node_7080,prsc:2|A-5982-OUT,B-4468-OUT,T-4017-OUT;n:type:ShaderForge.SFN_Slider,id:5982,x:31670,y:32323,ptovrint:False,ptlb:Base Amb Diffuse,ptin:_BaseAmbDiffuse,varname:node_5982,prsc:2,min:0,cur:0.1,max:1;n:type:ShaderForge.SFN_Slider,id:4468,x:31656,y:32437,ptovrint:False,ptlb:Oil Amb Diffuse,ptin:_OilAmbDiffuse,varname:node_5982,prsc:2,min:0,cur:0.1,max:1;proporder:6903-5982-8734-6065-7048-6725-6139-3091-4468-611-8876-641-4301-4017;pass:END;sub:END;*/

Shader "Shader Forge/FloortoOil_Fallback" {
    Properties {
        _BaseDiffuse ("Base Diffuse", 2D) = "black" {}
        _BaseAmbDiffuse ("Base Amb Diffuse", Range(0, 1)) = 0.1
        _BaseNormal ("Base Normal", 2D) = "bump" {}
        _BaseNormalStrength ("Base Normal Strength", Range(0, 1)) = 0.8
        _BaseSpecColor ("Base Spec Color", Color) = (0.5,0.5,0.5,1)
        _BaseSpec ("Base Spec", 2D) = "gray" {}
        _BaseShininess ("Base Shininess", Range(0, 1)) = 0
        _OilDiffuse ("Oil Diffuse", 2D) = "white" {}
        _OilAmbDiffuse ("Oil Amb Diffuse", Range(0, 1)) = 0.1
        _OilNormal ("Oil Normal", 2D) = "bump" {}
        _OilIridescence ("Oil Iridescence", Cube) = "_Skybox" {}
        _OilShininess ("Oil Shininess", Range(0, 1)) = 0
        _OilPower ("Oil Power", Range(0, 1)) = 0.2038835
        _Oil ("Oil", Range(0, 1)) = 0
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
            uniform float _OilPower;
            uniform samplerCUBE _OilIridescence;
            uniform float _Oil;
            uniform sampler2D _BaseDiffuse; uniform float4 _BaseDiffuse_ST;
            uniform sampler2D _BaseNormal; uniform float4 _BaseNormal_ST;
            uniform sampler2D _BaseSpec; uniform float4 _BaseSpec_ST;
            uniform float _OilShininess;
            uniform float _BaseShininess;
            uniform float _BaseNormalStrength;
            uniform float4 _BaseSpecColor;
            uniform float _BaseAmbDiffuse;
            uniform float _OilAmbDiffuse;
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
                float3 normalLocal = lerp((_BaseNormal_var.rgb*float3(float2(1.0,1.0),(1.0 - _BaseNormalStrength))),_OilNormal_var.rgb,_Oil);
                float3 normalDirection = normalize(mul( normalLocal, tangentTransform )); // Perturbed normals
                float3 viewReflectDirection = reflect( -viewDirection, normalDirection );
                float3 lightDirection = normalize(_WorldSpaceLightPos0.xyz);
                float3 lightColor = _LightColor0.rgb;
                float3 halfDirection = normalize(viewDirection+lightDirection);
////// Lighting:
                float attenuation = LIGHT_ATTENUATION(i);
                float3 attenColor = attenuation * _LightColor0.xyz;
///////// Gloss:
                float gloss = lerp(_BaseShininess,_OilShininess,_Oil);
                float specPow = exp2( gloss * 10.0+1.0);
////// Specular:
                float NdotL = max(0, dot( normalDirection, lightDirection ));
                float4 _BaseSpec_var = tex2D(_BaseSpec,TRANSFORM_TEX(i.uv0, _BaseSpec));
                float4 _OilDiffuse_var = tex2D(_OilDiffuse,TRANSFORM_TEX(i.uv0, _OilDiffuse));
                float3 specularColor = lerp((_BaseSpecColor.rgb*_BaseSpec_var.rgb),lerp((floor((1.0 - _OilDiffuse_var.rgb))*(texCUBE(_OilIridescence,viewReflectDirection).rgb*_OilPower)),_OilDiffuse_var.rgb,_OilDiffuse_var.b),_Oil);
                float3 directSpecular = (floor(attenuation) * _LightColor0.xyz) * pow(max(0,dot(halfDirection,normalDirection)),specPow);
                float3 specular = directSpecular * specularColor;
/////// Diffuse:
                NdotL = max(0.0,dot( normalDirection, lightDirection ));
                float3 indirectDiffuse = float3(0,0,0);
                float3 directDiffuse = max( 0.0, NdotL) * attenColor;
                indirectDiffuse += UNITY_LIGHTMODEL_AMBIENT.rgb; // Ambient Light
                float node_7080 = lerp(_BaseAmbDiffuse,_OilAmbDiffuse,_Oil);
                indirectDiffuse += float3(node_7080,node_7080,node_7080); // Diffuse Ambient Light
                float4 _BaseDiffuse_var = tex2D(_BaseDiffuse,TRANSFORM_TEX(i.uv0, _BaseDiffuse));
                float3 diffuse = (directDiffuse + indirectDiffuse) * lerp(_BaseDiffuse_var.rgb,_OilDiffuse_var.rgb,_Oil);
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
            uniform float _OilPower;
            uniform samplerCUBE _OilIridescence;
            uniform float _Oil;
            uniform sampler2D _BaseDiffuse; uniform float4 _BaseDiffuse_ST;
            uniform sampler2D _BaseNormal; uniform float4 _BaseNormal_ST;
            uniform sampler2D _BaseSpec; uniform float4 _BaseSpec_ST;
            uniform float _OilShininess;
            uniform float _BaseShininess;
            uniform float _BaseNormalStrength;
            uniform float4 _BaseSpecColor;
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
                float3 normalLocal = lerp((_BaseNormal_var.rgb*float3(float2(1.0,1.0),(1.0 - _BaseNormalStrength))),_OilNormal_var.rgb,_Oil);
                float3 normalDirection = normalize(mul( normalLocal, tangentTransform )); // Perturbed normals
                float3 viewReflectDirection = reflect( -viewDirection, normalDirection );
                float3 lightDirection = normalize(lerp(_WorldSpaceLightPos0.xyz, _WorldSpaceLightPos0.xyz - i.posWorld.xyz,_WorldSpaceLightPos0.w));
                float3 lightColor = _LightColor0.rgb;
                float3 halfDirection = normalize(viewDirection+lightDirection);
////// Lighting:
                float attenuation = LIGHT_ATTENUATION(i);
                float3 attenColor = attenuation * _LightColor0.xyz;
///////// Gloss:
                float gloss = lerp(_BaseShininess,_OilShininess,_Oil);
                float specPow = exp2( gloss * 10.0+1.0);
////// Specular:
                float NdotL = max(0, dot( normalDirection, lightDirection ));
                float4 _BaseSpec_var = tex2D(_BaseSpec,TRANSFORM_TEX(i.uv0, _BaseSpec));
                float4 _OilDiffuse_var = tex2D(_OilDiffuse,TRANSFORM_TEX(i.uv0, _OilDiffuse));
                float3 specularColor = lerp((_BaseSpecColor.rgb*_BaseSpec_var.rgb),lerp((floor((1.0 - _OilDiffuse_var.rgb))*(texCUBE(_OilIridescence,viewReflectDirection).rgb*_OilPower)),_OilDiffuse_var.rgb,_OilDiffuse_var.b),_Oil);
                float3 directSpecular = attenColor * pow(max(0,dot(halfDirection,normalDirection)),specPow);
                float3 specular = directSpecular * specularColor;
/////// Diffuse:
                NdotL = max(0.0,dot( normalDirection, lightDirection ));
                float3 directDiffuse = max( 0.0, NdotL) * attenColor;
                float4 _BaseDiffuse_var = tex2D(_BaseDiffuse,TRANSFORM_TEX(i.uv0, _BaseDiffuse));
                float3 diffuse = directDiffuse * lerp(_BaseDiffuse_var.rgb,_OilDiffuse_var.rgb,_Oil);
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
