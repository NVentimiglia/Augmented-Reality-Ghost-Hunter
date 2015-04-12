Shader "Custom/WebCamera" 
{
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
			return tex2D(_WebTexture, i.uv);
		}

		ENDCG
		} 
	}
}
