Shader "Custom/WebCamera" 
{
	Properties
	{
		_MainTex ("Base (RGB)", 2D) = "white" {}		
	}

	SubShader
	{
		Pass
		{
		
		CGPROGRAM
		#pragma vertex vert_img
		#pragma fragment frag
		#pragma target 3.0		
		
		#include "UnityCG.cginc"

		uniform sampler2D _WebTexture;
		
		float4 frag(v2f_img i) : COLOR
		{
			float4 c = tex2D(_WebTexture, i.uv);
			return c;
		}

		ENDCG
		} 
	}
	}
