// Made with Amplify Shader Editor
// Available at the Unity Asset Store - http://u3d.as/y3X 
Shader "AE/Singboards_SRP"
{
	Properties
	{
		_Speed_X("Speed_X", Range( -1 , -0.05)) = -0.1
		_Speed_Y("Speed_Y", Range( 0 , 0.3)) = 0
		[Header(Translucency)]
		_Translucency("Strength", Range( 0 , 50)) = 1
		_TransNormalDistortion("Normal Distortion", Range( 0 , 1)) = 0.1
		_TransScattering("Scaterring Falloff", Range( 1 , 50)) = 2
		_TransDirect("Direct", Range( 0 , 1)) = 1
		_TransAmbient("Ambient", Range( 0 , 1)) = 0.2
		_TransShadow("Shadow", Range( 0 , 1)) = 0.9
		[HDR]_Emissev_Power("Emissev_Power", Range( 0 , 15)) = 1
		_Emissive("Emissive", 2D) = "white" {}
		_Albedo("Albedo", 2D) = "white" {}
		_Metallic("Metallic", Range( 0 , 1)) = 0.2
		[HideInInspector] _texcoord( "", 2D ) = "white" {}
		[HideInInspector] __dirty( "", Int ) = 1
	}

	SubShader
	{
		Tags{ "RenderType" = "Transparent"  "Queue" = "Geometry+0" "IsEmissive" = "true"  }
		Cull Back
		CGPROGRAM
		#include "UnityShaderVariables.cginc"
		#include "UnityPBSLighting.cginc"
		#pragma target 3.0
		#pragma surface surf StandardCustom keepalpha addshadow fullforwardshadows exclude_path:deferred 
		struct Input
		{
			float2 uv_texcoord;
		};

		struct SurfaceOutputStandardCustom
		{
			half3 Albedo;
			half3 Normal;
			half3 Emission;
			half Metallic;
			half Smoothness;
			half Occlusion;
			half Alpha;
			half3 Translucency;
		};

		uniform sampler2D _Albedo;
		uniform float _Speed_X;
		uniform float _Speed_Y;
		uniform sampler2D _Emissive;
		uniform float _Emissev_Power;
		uniform float _Metallic;
		uniform half _Translucency;
		uniform half _TransNormalDistortion;
		uniform half _TransScattering;
		uniform half _TransDirect;
		uniform half _TransAmbient;
		uniform half _TransShadow;

		inline half4 LightingStandardCustom(SurfaceOutputStandardCustom s, half3 viewDir, UnityGI gi )
		{
			#if !DIRECTIONAL
			float3 lightAtten = gi.light.color;
			#else
			float3 lightAtten = lerp( _LightColor0.rgb, gi.light.color, _TransShadow );
			#endif
			half3 lightDir = gi.light.dir + s.Normal * _TransNormalDistortion;
			half transVdotL = pow( saturate( dot( viewDir, -lightDir ) ), _TransScattering );
			half3 translucency = lightAtten * (transVdotL * _TransDirect + gi.indirect.diffuse * _TransAmbient) * s.Translucency;
			half4 c = half4( s.Albedo * translucency * _Translucency, 0 );

			SurfaceOutputStandard r;
			r.Albedo = s.Albedo;
			r.Normal = s.Normal;
			r.Emission = s.Emission;
			r.Metallic = s.Metallic;
			r.Smoothness = s.Smoothness;
			r.Occlusion = s.Occlusion;
			r.Alpha = s.Alpha;
			return LightingStandard (r, viewDir, gi) + c;
		}

		inline void LightingStandardCustom_GI(SurfaceOutputStandardCustom s, UnityGIInput data, inout UnityGI gi )
		{
			#if defined(UNITY_PASS_DEFERRED) && UNITY_ENABLE_REFLECTION_BUFFERS
				gi = UnityGlobalIllumination(data, s.Occlusion, s.Normal);
			#else
				UNITY_GLOSSY_ENV_FROM_SURFACE( g, s, data );
				gi = UnityGlobalIllumination( data, s.Occlusion, s.Normal, g );
			#endif
		}

		void surf( Input i , inout SurfaceOutputStandardCustom o )
		{
			float3 appendResult5 = (float3(_Speed_X , _Speed_Y , 0.0));
			float2 panner2 = ( _Time.z * appendResult5.xy + i.uv_texcoord);
			float4 tex2DNode22 = tex2D( _Albedo, panner2 );
			o.Albedo = tex2DNode22.rgb;
			o.Emission = ( tex2D( _Emissive, panner2 ) * _Emissev_Power ).rgb;
			o.Metallic = _Metallic;
			float3 temp_cast_3 = (tex2DNode22.a).xxx;
			o.Translucency = temp_cast_3;
			o.Alpha = 1;
		}

		ENDCG
	}
	Fallback "Diffuse"
	CustomEditor "ASEMaterialInspector"
}
/*ASEBEGIN
Version=18000
-1885;-12;1532;802;1920.292;198.9359;1;True;False
Node;AmplifyShaderEditor.RangedFloatNode;21;-2081.975,341.117;Inherit;False;Property;_Speed_Y;Speed_Y;2;0;Create;True;0;0;False;0;0;0;0;0.3;0;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;3;-2031.915,75.81203;Inherit;False;Property;_Speed_X;Speed_X;1;0;Create;True;0;0;False;0;-0.1;-0.065;-1;-0.05;0;1;FLOAT;0
Node;AmplifyShaderEditor.TimeNode;7;-1376.802,408.004;Inherit;False;0;5;FLOAT4;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.TextureCoordinatesNode;1;-1887.503,-307.6696;Inherit;False;0;-1;2;3;2;SAMPLER2D;;False;0;FLOAT2;1,1;False;1;FLOAT2;0,0;False;5;FLOAT2;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.DynamicAppendNode;5;-1548.03,148.3427;Inherit;False;FLOAT3;4;0;FLOAT;0;False;1;FLOAT;0;False;2;FLOAT;0;False;3;FLOAT;0;False;1;FLOAT3;0
Node;AmplifyShaderEditor.PannerNode;2;-1137.573,-51.63628;Inherit;False;3;0;FLOAT2;0,0;False;2;FLOAT2;0,0;False;1;FLOAT;1;False;1;FLOAT2;0
Node;AmplifyShaderEditor.RangedFloatNode;11;-975.6718,289.1434;Inherit;False;Property;_Emissev_Power;Emissev_Power;10;1;[HDR];Create;True;0;0;False;0;1;3.35;0;15;0;1;FLOAT;0
Node;AmplifyShaderEditor.SamplerNode;13;-744.9515,-0.09474111;Inherit;True;Property;_Emissive;Emissive;11;0;Create;True;0;0;False;0;-1;4cc0832a40cea984084cc90406cb04c6;03b479d32b1bd4c4eba0228036bac598;True;0;False;white;Auto;False;Object;-1;Auto;Texture2D;6;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;10;-269.9227,163.4227;Inherit;False;2;2;0;COLOR;0,0,0,0;False;1;FLOAT;0;False;1;COLOR;0
Node;AmplifyShaderEditor.SamplerNode;22;-457.8102,-299.7922;Inherit;True;Property;_Albedo;Albedo;12;0;Create;True;0;0;False;0;-1;58d46585f0a3c454b9eca09710bce231;03b479d32b1bd4c4eba0228036bac598;True;0;False;white;Auto;False;Object;-1;Auto;Texture2D;6;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.RangedFloatNode;28;778.7555,193.4182;Inherit;False;Property;_Metallic;Metallic;13;0;Create;True;0;0;False;0;0.2;1;0;1;0;1;FLOAT;0
Node;AmplifyShaderEditor.StandardSurfaceOutputNode;27;1346.804,-106.2712;Float;False;True;-1;2;ASEMaterialInspector;0;0;Standard;AE/Singboards_SRP;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;Back;0;False;-1;0;False;-1;False;0;False;-1;0;False;-1;False;0;Custom;0.5;True;True;0;True;Transparent;;Geometry;ForwardOnly;14;all;True;True;True;True;0;False;-1;False;0;False;-1;255;False;-1;255;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;False;2;15;10;25;False;0.5;True;0;0;False;-1;0;False;-1;0;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;0;0,0,0,0;VertexOffset;True;False;Cylindrical;False;Relative;0;;0;3;-1;-1;0;False;0;0;False;-1;-1;0;False;-1;0;0;0;False;0.1;False;-1;0;False;-1;16;0;FLOAT3;0,0,0;False;1;FLOAT3;0,0,0;False;2;FLOAT3;0,0,0;False;3;FLOAT;0;False;4;FLOAT;0;False;5;FLOAT;0;False;6;FLOAT3;0,0,0;False;7;FLOAT3;0,0,0;False;8;FLOAT;0;False;9;FLOAT;0;False;10;FLOAT;0;False;13;FLOAT3;0,0,0;False;11;FLOAT3;0,0,0;False;12;FLOAT3;0,0,0;False;14;FLOAT4;0,0,0,0;False;15;FLOAT3;0,0,0;False;0
WireConnection;5;0;3;0
WireConnection;5;1;21;0
WireConnection;2;0;1;0
WireConnection;2;2;5;0
WireConnection;2;1;7;3
WireConnection;13;1;2;0
WireConnection;10;0;13;0
WireConnection;10;1;11;0
WireConnection;22;1;2;0
WireConnection;27;0;22;0
WireConnection;27;2;10;0
WireConnection;27;3;28;0
WireConnection;27;7;22;4
ASEEND*/
//CHKSM=7CB8E42104356972B3A9BA3129D7EFA695F2401D