// Shader created with Shader Forge v1.02 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.02;sub:START;pass:START;ps:flbk:,lico:1,lgpr:1,nrmq:1,limd:1,uamb:True,mssp:True,lmpd:False,lprd:False,rprd:False,enco:False,frtr:True,vitr:True,dbil:False,rmgx:True,rpth:0,hqsc:True,hqlp:False,tesm:0,blpr:0,bsrc:0,bdst:1,culm:0,dpts:2,wrdp:True,ufog:True,aust:True,igpj:False,qofs:0,qpre:1,rntp:1,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,ofsf:0,ofsu:0,f2p0:True;n:type:ShaderForge.SFN_Final,id:133,x:32912,y:31638,varname:node_133,prsc:2|diff-8270-OUT,spec-1826-OUT,gloss-5730-OUT,normal-6430-OUT,amdfl-6342-OUT;n:type:ShaderForge.SFN_Tex2d,id:611,x:32104,y:31595,ptovrint:False,ptlb:Other Normal,ptin:_OtherNormal,varname:node_611,prsc:2,tex:963d0620b29a64461a3a00158128db59,ntxv:3,isnm:True;n:type:ShaderForge.SFN_Tex2d,id:3091,x:32189,y:31160,ptovrint:False,ptlb:Other Diffuse,ptin:_OtherDiffuse,varname:node_3091,prsc:2,tex:034da740aef294e518e6d974983b0131,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Slider,id:4017,x:32095,y:32247,ptovrint:False,ptlb:Transition,ptin:_Transition,varname:node_4017,prsc:2,min:0,cur:0,max:1;n:type:ShaderForge.SFN_Lerp,id:8270,x:32690,y:31542,varname:node_8270,prsc:2|A-6903-RGB,B-3091-RGB,T-4017-OUT;n:type:ShaderForge.SFN_Tex2d,id:6903,x:31907,y:31257,ptovrint:False,ptlb:Base Diffuse,ptin:_BaseDiffuse,varname:node_6903,prsc:2,tex:b0a0186890be9b647bd1a3623cbd86a4,ntxv:2,isnm:False;n:type:ShaderForge.SFN_Tex2d,id:8734,x:31676,y:31433,ptovrint:False,ptlb:Base Normal,ptin:_BaseNormal,varname:node_6903,prsc:2,tex:dd243bc6a69423d43a7d11b793882fe3,ntxv:3,isnm:True;n:type:ShaderForge.SFN_Tex2d,id:6725,x:31866,y:31657,ptovrint:False,ptlb:Base Spec,ptin:_BaseSpec,varname:node_6903,prsc:2,tex:da2e28888ae774f5e9d37174aec8e22b,ntxv:1,isnm:False;n:type:ShaderForge.SFN_Lerp,id:6430,x:32701,y:31673,varname:node_6430,prsc:2|A-939-OUT,B-611-RGB,T-4017-OUT;n:type:ShaderForge.SFN_Lerp,id:1826,x:32690,y:31786,varname:node_1826,prsc:2|A-4878-OUT,B-5864-RGB,T-4017-OUT;n:type:ShaderForge.SFN_Slider,id:641,x:32127,y:31896,ptovrint:False,ptlb:Other Shininess,ptin:_OtherShininess,varname:node_4017,prsc:2,min:0,cur:0,max:1;n:type:ShaderForge.SFN_Slider,id:6139,x:32275,y:31766,ptovrint:False,ptlb:Base Shininess,ptin:_BaseShininess,varname:node_4017,prsc:2,min:0,cur:0.2,max:1;n:type:ShaderForge.SFN_Lerp,id:5730,x:32701,y:31908,varname:node_5730,prsc:2|A-6139-OUT,B-641-OUT,T-4017-OUT;n:type:ShaderForge.SFN_Tex2d,id:5864,x:32114,y:31792,ptovrint:False,ptlb:Other Spec,ptin:_OtherSpec,varname:node_5864,prsc:2,tex:6e24a7cfed5df4463a1b5a498b3a88ab,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Vector1,id:2865,x:31096,y:31479,varname:node_2865,prsc:2,v1:1;n:type:ShaderForge.SFN_Vector1,id:330,x:31096,y:31566,varname:node_330,prsc:2,v1:1;n:type:ShaderForge.SFN_Append,id:1582,x:31272,y:31508,varname:node_1582,prsc:2|A-2865-OUT,B-330-OUT;n:type:ShaderForge.SFN_Append,id:9799,x:31446,y:31549,varname:node_9799,prsc:2|A-1582-OUT,B-9898-OUT;n:type:ShaderForge.SFN_Slider,id:3117,x:30898,y:31683,ptovrint:False,ptlb:Normal Strength,ptin:_NormalStrength,varname:node_3117,prsc:2,min:0,cur:0.8,max:1;n:type:ShaderForge.SFN_OneMinus,id:9898,x:31318,y:31712,varname:node_9898,prsc:2|IN-3117-OUT;n:type:ShaderForge.SFN_Multiply,id:939,x:31907,y:31479,varname:node_939,prsc:2|A-8734-RGB,B-9799-OUT;n:type:ShaderForge.SFN_Slider,id:5100,x:31389,y:31893,ptovrint:False,ptlb:Base Amb Diffuse,ptin:_BaseAmbDiffuse,varname:node_5100,prsc:2,min:0,cur:0.1,max:1;n:type:ShaderForge.SFN_Slider,id:4152,x:31401,y:32079,ptovrint:False,ptlb:Other Amb Diffuse,ptin:_OtherAmbDiffuse,varname:node_5100,prsc:2,min:0,cur:0,max:1;n:type:ShaderForge.SFN_Lerp,id:6342,x:32052,y:31956,varname:node_6342,prsc:2|A-5100-OUT,B-4152-OUT,T-4017-OUT;n:type:ShaderForge.SFN_Color,id:7154,x:32515,y:31255,ptovrint:False,ptlb:Base Spec Color,ptin:_BaseSpecColor,varname:node_7154,prsc:2,glob:False,c1:0.5,c2:0.5,c3:0.5,c4:1;n:type:ShaderForge.SFN_Multiply,id:4878,x:32316,y:31612,varname:node_4878,prsc:2|A-6725-RGB,B-7154-RGB;proporder:6903-5100-8734-3117-7154-6725-6139-3091-4152-611-5864-641-4017;pass:END;sub:END;*/

Shader "Shader Forge/FloortoOther_Fallback" {
    Properties {
        _BaseDiffuse ("Base Diffuse", 2D) = "black" {}
        _BaseAmbDiffuse ("Base Amb Diffuse", Range(0, 1)) = 0.1
        _BaseNormal ("Base Normal", 2D) = "bump" {}
        _NormalStrength ("Normal Strength", Range(0, 1)) = 0.8
        _BaseSpecColor ("Base Spec Color", Color) = (0.5,0.5,0.5,1)
        _BaseSpec ("Base Spec", 2D) = "gray" {}
        _BaseShininess ("Base Shininess", Range(0, 1)) = 0.2
        _OtherDiffuse ("Other Diffuse", 2D) = "white" {}
        _OtherAmbDiffuse ("Other Amb Diffuse", Range(0, 1)) = 0
        _OtherNormal ("Other Normal", 2D) = "bump" {}
        _OtherSpec ("Other Spec", 2D) = "white" {}
        _OtherShininess ("Other Shininess", Range(0, 1)) = 0
        _Transition ("Transition", Range(0, 1)) = 0
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
            uniform sampler2D _OtherNormal; uniform float4 _OtherNormal_ST;
            uniform sampler2D _OtherDiffuse; uniform float4 _OtherDiffuse_ST;
            uniform float _Transition;
            uniform sampler2D _BaseDiffuse; uniform float4 _BaseDiffuse_ST;
            uniform sampler2D _BaseNormal; uniform float4 _BaseNormal_ST;
            uniform sampler2D _BaseSpec; uniform float4 _BaseSpec_ST;
            uniform float _OtherShininess;
            uniform float _BaseShininess;
            uniform sampler2D _OtherSpec; uniform float4 _OtherSpec_ST;
            uniform float _NormalStrength;
            uniform float _BaseAmbDiffuse;
            uniform float _OtherAmbDiffuse;
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
                float3 _OtherNormal_var = UnpackNormal(tex2D(_OtherNormal,TRANSFORM_TEX(i.uv0, _OtherNormal)));
                float3 normalLocal = lerp((_BaseNormal_var.rgb*float3(float2(1.0,1.0),(1.0 - _NormalStrength))),_OtherNormal_var.rgb,_Transition);
                float3 normalDirection = normalize(mul( normalLocal, tangentTransform )); // Perturbed normals
                float3 lightDirection = normalize(_WorldSpaceLightPos0.xyz);
                float3 lightColor = _LightColor0.rgb;
                float3 halfDirection = normalize(viewDirection+lightDirection);
////// Lighting:
                float attenuation = LIGHT_ATTENUATION(i);
                float3 attenColor = attenuation * _LightColor0.xyz;
///////// Gloss:
                float gloss = lerp(_BaseShininess,_OtherShininess,_Transition);
                float specPow = exp2( gloss * 10.0+1.0);
////// Specular:
                float NdotL = max(0, dot( normalDirection, lightDirection ));
                float4 _BaseSpec_var = tex2D(_BaseSpec,TRANSFORM_TEX(i.uv0, _BaseSpec));
                float4 _OtherSpec_var = tex2D(_OtherSpec,TRANSFORM_TEX(i.uv0, _OtherSpec));
                float3 specularColor = lerp((_BaseSpec_var.rgb*_BaseSpecColor.rgb),_OtherSpec_var.rgb,_Transition);
                float3 directSpecular = (floor(attenuation) * _LightColor0.xyz) * pow(max(0,dot(halfDirection,normalDirection)),specPow);
                float3 specular = directSpecular * specularColor;
/////// Diffuse:
                NdotL = max(0.0,dot( normalDirection, lightDirection ));
                float3 indirectDiffuse = float3(0,0,0);
                float3 directDiffuse = max( 0.0, NdotL) * attenColor;
                indirectDiffuse += UNITY_LIGHTMODEL_AMBIENT.rgb; // Ambient Light
                float node_6342 = lerp(_BaseAmbDiffuse,_OtherAmbDiffuse,_Transition);
                indirectDiffuse += float3(node_6342,node_6342,node_6342); // Diffuse Ambient Light
                float4 _BaseDiffuse_var = tex2D(_BaseDiffuse,TRANSFORM_TEX(i.uv0, _BaseDiffuse));
                float4 _OtherDiffuse_var = tex2D(_OtherDiffuse,TRANSFORM_TEX(i.uv0, _OtherDiffuse));
                float3 diffuse = (directDiffuse + indirectDiffuse) * lerp(_BaseDiffuse_var.rgb,_OtherDiffuse_var.rgb,_Transition);
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
            uniform sampler2D _OtherNormal; uniform float4 _OtherNormal_ST;
            uniform sampler2D _OtherDiffuse; uniform float4 _OtherDiffuse_ST;
            uniform float _Transition;
            uniform sampler2D _BaseDiffuse; uniform float4 _BaseDiffuse_ST;
            uniform sampler2D _BaseNormal; uniform float4 _BaseNormal_ST;
            uniform sampler2D _BaseSpec; uniform float4 _BaseSpec_ST;
            uniform float _OtherShininess;
            uniform float _BaseShininess;
            uniform sampler2D _OtherSpec; uniform float4 _OtherSpec_ST;
            uniform float _NormalStrength;
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
                float3 _OtherNormal_var = UnpackNormal(tex2D(_OtherNormal,TRANSFORM_TEX(i.uv0, _OtherNormal)));
                float3 normalLocal = lerp((_BaseNormal_var.rgb*float3(float2(1.0,1.0),(1.0 - _NormalStrength))),_OtherNormal_var.rgb,_Transition);
                float3 normalDirection = normalize(mul( normalLocal, tangentTransform )); // Perturbed normals
                float3 lightDirection = normalize(lerp(_WorldSpaceLightPos0.xyz, _WorldSpaceLightPos0.xyz - i.posWorld.xyz,_WorldSpaceLightPos0.w));
                float3 lightColor = _LightColor0.rgb;
                float3 halfDirection = normalize(viewDirection+lightDirection);
////// Lighting:
                float attenuation = LIGHT_ATTENUATION(i);
                float3 attenColor = attenuation * _LightColor0.xyz;
///////// Gloss:
                float gloss = lerp(_BaseShininess,_OtherShininess,_Transition);
                float specPow = exp2( gloss * 10.0+1.0);
////// Specular:
                float NdotL = max(0, dot( normalDirection, lightDirection ));
                float4 _BaseSpec_var = tex2D(_BaseSpec,TRANSFORM_TEX(i.uv0, _BaseSpec));
                float4 _OtherSpec_var = tex2D(_OtherSpec,TRANSFORM_TEX(i.uv0, _OtherSpec));
                float3 specularColor = lerp((_BaseSpec_var.rgb*_BaseSpecColor.rgb),_OtherSpec_var.rgb,_Transition);
                float3 directSpecular = attenColor * pow(max(0,dot(halfDirection,normalDirection)),specPow);
                float3 specular = directSpecular * specularColor;
/////// Diffuse:
                NdotL = max(0.0,dot( normalDirection, lightDirection ));
                float3 directDiffuse = max( 0.0, NdotL) * attenColor;
                float4 _BaseDiffuse_var = tex2D(_BaseDiffuse,TRANSFORM_TEX(i.uv0, _BaseDiffuse));
                float4 _OtherDiffuse_var = tex2D(_OtherDiffuse,TRANSFORM_TEX(i.uv0, _OtherDiffuse));
                float3 diffuse = directDiffuse * lerp(_BaseDiffuse_var.rgb,_OtherDiffuse_var.rgb,_Transition);
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
