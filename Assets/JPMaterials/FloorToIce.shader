// Shader created with Shader Forge v1.02 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.02;sub:START;pass:START;ps:flbk:Shader Forge/FloortoIce_Fallback,lico:1,lgpr:1,nrmq:1,limd:1,uamb:True,mssp:True,lmpd:False,lprd:False,rprd:False,enco:False,frtr:True,vitr:True,dbil:False,rmgx:True,rpth:0,hqsc:True,hqlp:False,tesm:0,blpr:0,bsrc:0,bdst:1,culm:0,dpts:2,wrdp:True,ufog:True,aust:True,igpj:False,qofs:0,qpre:1,rntp:1,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,ofsf:0,ofsu:0,f2p0:False;n:type:ShaderForge.SFN_Final,id:133,x:33353,y:31615,varname:node_133,prsc:2|diff-8270-OUT,spec-1826-OUT,gloss-5730-OUT,normal-6430-OUT,amdfl-1414-OUT;n:type:ShaderForge.SFN_Tex2d,id:611,x:32156,y:31585,ptovrint:False,ptlb:Ice Normal,ptin:_IceNormal,varname:node_611,prsc:2,tex:70f442b36a8b04fcda0bfa4edf5adfa6,ntxv:3,isnm:True;n:type:ShaderForge.SFN_Tex2d,id:3091,x:32372,y:31129,ptovrint:False,ptlb:Ice Diffuse,ptin:_IceDiffuse,varname:node_3091,prsc:2,tex:866f143fd05a64e349dded3f9c9eeb77,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Slider,id:4017,x:32139,y:32131,ptovrint:False,ptlb:Ice,ptin:_Ice,varname:node_4017,prsc:2,min:0,cur:0,max:1;n:type:ShaderForge.SFN_Lerp,id:8270,x:32675,y:31502,varname:node_8270,prsc:2|A-6903-RGB,B-3091-RGB,T-4017-OUT;n:type:ShaderForge.SFN_Tex2d,id:6903,x:31929,y:31267,ptovrint:False,ptlb:Base Diffuse,ptin:_BaseDiffuse,varname:node_6903,prsc:2,tex:b0a0186890be9b647bd1a3623cbd86a4,ntxv:2,isnm:False;n:type:ShaderForge.SFN_Tex2d,id:8734,x:31664,y:31468,ptovrint:False,ptlb:Base Normal,ptin:_BaseNormal,varname:node_6903,prsc:2,tex:dd243bc6a69423d43a7d11b793882fe3,ntxv:3,isnm:True;n:type:ShaderForge.SFN_Tex2d,id:6725,x:32280,y:31666,ptovrint:False,ptlb:Base Spec,ptin:_BaseSpec,varname:node_6903,prsc:2,tex:da2e28888ae774f5e9d37174aec8e22b,ntxv:1,isnm:False;n:type:ShaderForge.SFN_Lerp,id:6430,x:32691,y:31632,varname:node_6430,prsc:2|A-458-OUT,B-611-RGB,T-4017-OUT;n:type:ShaderForge.SFN_Lerp,id:1826,x:32675,y:31770,varname:node_1826,prsc:2|A-3536-OUT,B-5864-RGB,T-4017-OUT;n:type:ShaderForge.SFN_Slider,id:641,x:32212,y:32229,ptovrint:False,ptlb:Ice Shininess,ptin:_IceShininess,varname:node_4017,prsc:2,min:0,cur:0,max:1;n:type:ShaderForge.SFN_Slider,id:6139,x:31829,y:31810,ptovrint:False,ptlb:Base Shininess,ptin:_BaseShininess,varname:node_4017,prsc:2,min:0,cur:0.15,max:1;n:type:ShaderForge.SFN_Lerp,id:5730,x:32798,y:31903,varname:node_5730,prsc:2|A-6139-OUT,B-641-OUT,T-4017-OUT;n:type:ShaderForge.SFN_Tex2d,id:5864,x:32456,y:32035,ptovrint:False,ptlb:Ice Spec,ptin:_IceSpec,varname:node_5864,prsc:2,tex:fb364cf83766e47ac861bd2e0261985c,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Slider,id:3913,x:31761,y:32048,ptovrint:False,ptlb:Ice Amb Diffuse,ptin:_IceAmbDiffuse,varname:node_3913,prsc:2,min:0,cur:0,max:1;n:type:ShaderForge.SFN_Lerp,id:1414,x:32316,y:31829,varname:node_1414,prsc:2|A-7568-OUT,B-3913-OUT,T-4017-OUT;n:type:ShaderForge.SFN_Color,id:490,x:32318,y:31475,ptovrint:False,ptlb:Base Spec Color,ptin:_BaseSpecColor,varname:node_490,prsc:2,glob:False,c1:0.5,c2:0.5,c3:0.5,c4:1;n:type:ShaderForge.SFN_Multiply,id:3536,x:32466,y:31700,varname:node_3536,prsc:2|A-490-RGB,B-6725-RGB;n:type:ShaderForge.SFN_Slider,id:7568,x:31761,y:31929,ptovrint:False,ptlb:Base Amb Diffuse,ptin:_BaseAmbDiffuse,varname:node_3913,prsc:2,min:0,cur:0.1,max:1;n:type:ShaderForge.SFN_Multiply,id:458,x:31976,y:31532,varname:node_458,prsc:2|A-8734-RGB,B-1489-OUT;n:type:ShaderForge.SFN_Slider,id:1438,x:31008,y:31692,ptovrint:False,ptlb:Normal Strength,ptin:_NormalStrength,varname:node_1438,prsc:2,min:0,cur:0,max:1;n:type:ShaderForge.SFN_OneMinus,id:2172,x:31373,y:31651,varname:node_2172,prsc:2|IN-1438-OUT;n:type:ShaderForge.SFN_Append,id:1966,x:31517,y:31535,varname:node_1966,prsc:2|A-6483-OUT,B-8009-OUT;n:type:ShaderForge.SFN_Append,id:1489,x:31642,y:31668,varname:node_1489,prsc:2|A-1966-OUT,B-2172-OUT;n:type:ShaderForge.SFN_Vector1,id:6483,x:31275,y:31500,varname:node_6483,prsc:2,v1:1;n:type:ShaderForge.SFN_Vector1,id:8009,x:31249,y:31556,varname:node_8009,prsc:2,v1:1;proporder:6903-7568-8734-1438-490-6725-6139-3091-3913-611-5864-641-4017;pass:END;sub:END;*/

Shader "Shader Forge/FloortoIce" {
    Properties {
        _BaseDiffuse ("Base Diffuse", 2D) = "black" {}
        _BaseAmbDiffuse ("Base Amb Diffuse", Range(0, 1)) = 0.1
        _BaseNormal ("Base Normal", 2D) = "bump" {}
        _NormalStrength ("Normal Strength", Range(0, 1)) = 0
        _BaseSpecColor ("Base Spec Color", Color) = (0.5,0.5,0.5,1)
        _BaseSpec ("Base Spec", 2D) = "gray" {}
        _BaseShininess ("Base Shininess", Range(0, 1)) = 0.15
        _IceDiffuse ("Ice Diffuse", 2D) = "white" {}
        _IceAmbDiffuse ("Ice Amb Diffuse", Range(0, 1)) = 0
        _IceNormal ("Ice Normal", 2D) = "bump" {}
        _IceSpec ("Ice Spec", 2D) = "white" {}
        _IceShininess ("Ice Shininess", Range(0, 1)) = 0
        _Ice ("Ice", Range(0, 1)) = 0
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
            #pragma target 3.0
            uniform float4 _LightColor0;
            uniform sampler2D _IceNormal; uniform float4 _IceNormal_ST;
            uniform sampler2D _IceDiffuse; uniform float4 _IceDiffuse_ST;
            uniform float _Ice;
            uniform sampler2D _BaseDiffuse; uniform float4 _BaseDiffuse_ST;
            uniform sampler2D _BaseNormal; uniform float4 _BaseNormal_ST;
            uniform sampler2D _BaseSpec; uniform float4 _BaseSpec_ST;
            uniform float _IceShininess;
            uniform float _BaseShininess;
            uniform sampler2D _IceSpec; uniform float4 _IceSpec_ST;
            uniform float _IceAmbDiffuse;
            uniform float4 _BaseSpecColor;
            uniform float _BaseAmbDiffuse;
            uniform float _NormalStrength;
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
                float3 _IceNormal_var = UnpackNormal(tex2D(_IceNormal,TRANSFORM_TEX(i.uv0, _IceNormal)));
                float3 normalLocal = lerp((_BaseNormal_var.rgb*float3(float2(1.0,1.0),(1.0 - _NormalStrength))),_IceNormal_var.rgb,_Ice);
                float3 normalDirection = normalize(mul( normalLocal, tangentTransform )); // Perturbed normals
                float3 lightDirection = normalize(_WorldSpaceLightPos0.xyz);
                float3 lightColor = _LightColor0.rgb;
                float3 halfDirection = normalize(viewDirection+lightDirection);
////// Lighting:
                float attenuation = LIGHT_ATTENUATION(i);
                float3 attenColor = attenuation * _LightColor0.xyz;
///////// Gloss:
                float gloss = lerp(_BaseShininess,_IceShininess,_Ice);
                float specPow = exp2( gloss * 10.0+1.0);
////// Specular:
                float NdotL = max(0, dot( normalDirection, lightDirection ));
                float4 _BaseSpec_var = tex2D(_BaseSpec,TRANSFORM_TEX(i.uv0, _BaseSpec));
                float4 _IceSpec_var = tex2D(_IceSpec,TRANSFORM_TEX(i.uv0, _IceSpec));
                float3 specularColor = lerp((_BaseSpecColor.rgb*_BaseSpec_var.rgb),_IceSpec_var.rgb,_Ice);
                float3 directSpecular = (floor(attenuation) * _LightColor0.xyz) * pow(max(0,dot(halfDirection,normalDirection)),specPow);
                float3 specular = directSpecular * specularColor;
/////// Diffuse:
                NdotL = max(0.0,dot( normalDirection, lightDirection ));
                float3 indirectDiffuse = float3(0,0,0);
                float3 directDiffuse = max( 0.0, NdotL) * attenColor;
                indirectDiffuse += UNITY_LIGHTMODEL_AMBIENT.rgb; // Ambient Light
                float node_1414 = lerp(_BaseAmbDiffuse,_IceAmbDiffuse,_Ice);
                indirectDiffuse += float3(node_1414,node_1414,node_1414); // Diffuse Ambient Light
                float4 _BaseDiffuse_var = tex2D(_BaseDiffuse,TRANSFORM_TEX(i.uv0, _BaseDiffuse));
                float4 _IceDiffuse_var = tex2D(_IceDiffuse,TRANSFORM_TEX(i.uv0, _IceDiffuse));
                float3 diffuse = (directDiffuse + indirectDiffuse) * lerp(_BaseDiffuse_var.rgb,_IceDiffuse_var.rgb,_Ice);
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
            #pragma target 3.0
            uniform float4 _LightColor0;
            uniform sampler2D _IceNormal; uniform float4 _IceNormal_ST;
            uniform sampler2D _IceDiffuse; uniform float4 _IceDiffuse_ST;
            uniform float _Ice;
            uniform sampler2D _BaseDiffuse; uniform float4 _BaseDiffuse_ST;
            uniform sampler2D _BaseNormal; uniform float4 _BaseNormal_ST;
            uniform sampler2D _BaseSpec; uniform float4 _BaseSpec_ST;
            uniform float _IceShininess;
            uniform float _BaseShininess;
            uniform sampler2D _IceSpec; uniform float4 _IceSpec_ST;
            uniform float4 _BaseSpecColor;
            uniform float _NormalStrength;
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
                float3 _IceNormal_var = UnpackNormal(tex2D(_IceNormal,TRANSFORM_TEX(i.uv0, _IceNormal)));
                float3 normalLocal = lerp((_BaseNormal_var.rgb*float3(float2(1.0,1.0),(1.0 - _NormalStrength))),_IceNormal_var.rgb,_Ice);
                float3 normalDirection = normalize(mul( normalLocal, tangentTransform )); // Perturbed normals
                float3 lightDirection = normalize(lerp(_WorldSpaceLightPos0.xyz, _WorldSpaceLightPos0.xyz - i.posWorld.xyz,_WorldSpaceLightPos0.w));
                float3 lightColor = _LightColor0.rgb;
                float3 halfDirection = normalize(viewDirection+lightDirection);
////// Lighting:
                float attenuation = LIGHT_ATTENUATION(i);
                float3 attenColor = attenuation * _LightColor0.xyz;
///////// Gloss:
                float gloss = lerp(_BaseShininess,_IceShininess,_Ice);
                float specPow = exp2( gloss * 10.0+1.0);
////// Specular:
                float NdotL = max(0, dot( normalDirection, lightDirection ));
                float4 _BaseSpec_var = tex2D(_BaseSpec,TRANSFORM_TEX(i.uv0, _BaseSpec));
                float4 _IceSpec_var = tex2D(_IceSpec,TRANSFORM_TEX(i.uv0, _IceSpec));
                float3 specularColor = lerp((_BaseSpecColor.rgb*_BaseSpec_var.rgb),_IceSpec_var.rgb,_Ice);
                float3 directSpecular = attenColor * pow(max(0,dot(halfDirection,normalDirection)),specPow);
                float3 specular = directSpecular * specularColor;
/////// Diffuse:
                NdotL = max(0.0,dot( normalDirection, lightDirection ));
                float3 directDiffuse = max( 0.0, NdotL) * attenColor;
                float4 _BaseDiffuse_var = tex2D(_BaseDiffuse,TRANSFORM_TEX(i.uv0, _BaseDiffuse));
                float4 _IceDiffuse_var = tex2D(_IceDiffuse,TRANSFORM_TEX(i.uv0, _IceDiffuse));
                float3 diffuse = directDiffuse * lerp(_BaseDiffuse_var.rgb,_IceDiffuse_var.rgb,_Ice);
/// Final Color:
                float3 finalColor = diffuse + specular;
                return fixed4(finalColor * 1,0);
            }
            ENDCG
        }
    }
    FallBack "Shader Forge/FloortoIce_Fallback"
    CustomEditor "ShaderForgeMaterialInspector"
}
