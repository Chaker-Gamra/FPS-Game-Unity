// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

// Shader created with Shader Forge v1.13 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.13;sub:START;pass:START;ps:flbk:Standard,lico:1,lgpr:1,nrmq:1,nrsp:0,limd:0,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,rprd:False,enco:False,rmgx:True,rpth:0,hqsc:True,hqlp:False,tesm:0,bsrc:0,bdst:1,culm:0,dpts:2,wrdp:True,dith:0,ufog:True,aust:True,igpj:False,qofs:0,qpre:1,rntp:1,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.02,fgrn:0,fgrf:300,ofsf:0,ofsu:0,f2p0:False;n:type:ShaderForge.SFN_Final,id:4282,x:32784,y:33145,varname:node_4282,prsc:2|emission-5230-OUT;n:type:ShaderForge.SFN_Tex2d,id:7457,x:32223,y:32692,ptovrint:False,ptlb:Texture,ptin:_Texture,varname:node_7457,prsc:2,tex:0f8b3dc02c8c303448c1e80f738f76f9,ntxv:3,isnm:False;n:type:ShaderForge.SFN_Tex2d,id:1506,x:31997,y:32836,ptovrint:False,ptlb:Mask,ptin:_Mask,varname:node_1506,prsc:2,tex:f525095a6afaaea49bf7b1dbe35b1770,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Color,id:142,x:31981,y:33101,ptovrint:False,ptlb:Color One,ptin:_ColorOne,varname:node_142,prsc:2,glob:False,c1:1,c2:1,c3:1,c4:1;n:type:ShaderForge.SFN_Color,id:6732,x:31981,y:33276,ptovrint:False,ptlb:Color Two,ptin:_ColorTwo,varname:node_6732,prsc:2,glob:False,c1:1,c2:1,c3:1,c4:1;n:type:ShaderForge.SFN_Color,id:7363,x:32003,y:33455,ptovrint:False,ptlb:Color Three,ptin:_ColorThree,varname:node_7363,prsc:2,glob:False,c1:1,c2:1,c3:1,c4:1;n:type:ShaderForge.SFN_Min,id:4072,x:32259,y:33023,varname:node_4072,prsc:2|A-142-RGB,B-1506-R;n:type:ShaderForge.SFN_Min,id:4727,x:32293,y:33185,varname:node_4727,prsc:2|A-6732-RGB,B-1506-G;n:type:ShaderForge.SFN_Min,id:6899,x:32251,y:33394,varname:node_6899,prsc:2|A-7363-RGB,B-1506-B;n:type:ShaderForge.SFN_Add,id:1424,x:32589,y:33057,varname:node_1424,prsc:2|A-4072-OUT,B-4727-OUT,C-6910-OUT;n:type:ShaderForge.SFN_Add,id:3213,x:32235,y:32871,varname:node_3213,prsc:2|A-1506-R,B-1506-G,C-1506-B;n:type:ShaderForge.SFN_Subtract,id:6910,x:32418,y:32827,varname:node_6910,prsc:2|A-7457-RGB,B-3213-OUT;n:type:ShaderForge.SFN_Blend,id:5230,x:32589,y:33267,varname:node_5230,prsc:2,blmd:5,clmp:True|SRC-404-OUT,DST-6899-OUT;n:type:ShaderForge.SFN_Lerp,id:404,x:32770,y:32714,varname:node_404,prsc:2|A-7457-RGB,B-1424-OUT,T-1275-OUT;n:type:ShaderForge.SFN_Vector1,id:3707,x:32581,y:32783,varname:node_3707,prsc:2,v1:0.45;n:type:ShaderForge.SFN_Slider,id:1275,x:32484,y:32629,ptovrint:False,ptlb:CrossOver,ptin:_CrossOver,varname:node_1275,prsc:2,min:0,cur:0.45,max:1;proporder:7457-1506-142-6732-7363-1275;pass:END;sub:END;*/

Shader "Custom/CustomColorsUnlit" {
    Properties {
        _Texture ("Texture", 2D) = "bump" {}
        _Mask ("Mask", 2D) = "white" {}
        _ColorOne ("Color One", Color) = (1,1,1,1)
        _ColorTwo ("Color Two", Color) = (1,1,1,1)
        _ColorThree ("Color Three", Color) = (1,1,1,1)
        _CrossOver ("CrossOver", Range(0, 1)) = 0.45
    }
    SubShader {
        Tags {
            "RenderType"="Opaque"
        }
        Pass {
            Name "FORWARD"
            Tags {
                "LightMode"="ForwardBase"
            }
            
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDBASE
            #include "UnityCG.cginc"
            #pragma multi_compile_fwdbase_fullshadows
            #pragma multi_compile_fog
            #pragma target 3.0
            uniform sampler2D _Texture; uniform float4 _Texture_ST;
            uniform sampler2D _Mask; uniform float4 _Mask_ST;
            uniform float4 _ColorOne;
            uniform float4 _ColorTwo;
            uniform float4 _ColorThree;
            uniform float _CrossOver;
            struct VertexInput {
                float4 vertex : POSITION;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                UNITY_FOG_COORDS(1)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.pos = UnityObjectToClipPos(v.vertex);
                UNITY_TRANSFER_FOG(o,o.pos);
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
/////// Vectors:
////// Lighting:
////// Emissive:
                float4 _Texture_var = tex2D(_Texture,TRANSFORM_TEX(i.uv0, _Texture));
                float4 _Mask_var = tex2D(_Mask,TRANSFORM_TEX(i.uv0, _Mask));
                float3 node_4072 = min(_ColorOne.rgb,_Mask_var.r);
                float3 node_4727 = min(_ColorTwo.rgb,_Mask_var.g);
                float3 node_6899 = min(_ColorThree.rgb,_Mask_var.b);
                float3 emissive = saturate(max(lerp(_Texture_var.rgb,(node_4072+node_4727+(_Texture_var.rgb-(_Mask_var.r+_Mask_var.g+_Mask_var.b))),_CrossOver),node_6899));
                float3 finalColor = emissive;
                fixed4 finalRGBA = fixed4(finalColor,1);
                UNITY_APPLY_FOG(i.fogCoord, finalRGBA);
                return finalRGBA;
            }
            ENDCG
        }
    }
    FallBack "Standard"
    CustomEditor "ShaderForgeMaterialInspector"
}
