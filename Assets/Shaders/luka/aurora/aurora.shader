//|===============================================|
//|			    <3  readme.txt  <3	        	  |
//|===============================================|
// (✿◠‿◠) henlo! why are you in the code? 
// well, it doesn't really matter. i hope u r happy!
// for licensing: see eula.md and the shader ui
// copyright: do not share under any circumstances
// copyright: the license is for you only
// see contact details at the end of the shader.
Shader "luka/aurora"
{
    
    // properties
    Properties {
        [Header(luka aurora borealis)]
        [Space(10)]
        [Header(Display Settings)]
        [Space(5)]
        _MainTex ("Aurora Guide", 2D) = "white" {}
        _LukaAuroraGuidePower("Guide Power", Range(0, 3)) = 0.8
        _LukaAuroraBrightness("Aurora Brightness", Range(1, 30)) = 4
        _LukaAuroraGlow("Aurora Glow", Range(10, 0)) = 2
        _LukaAuroraClamp("Alpha Clamp (1 for No Post-Processing)", Float) = 1
        [HDR] _LukaAuroraColorOne("Aurora Color One", Color) = (0.1, 0.8, 0.4, 1)
        [HDR] _LukaAuroraColorTwo("Aurora Color Two", Color) = (0.1, 0.4, 0.8, 1)
        [Space(10)]
        [Header(Aurora Generation Settings)]
        [Space(5)]
        _LukaAuroraSpeedY("Scrolling Up Speed", Range(0, 2)) = 0.2
        _LukaAuroraSpeedNoise("Color Shifting Speed", Range(0, 0.1)) = 0.005
        _LukaAuroraLines("Aurora Lines", Range(1, 50)) = 7
        _LukaAuroraNoiseScale("Aurora Scale", Range(0.1, 2)) = 1
        [Space(10)]
        [Header(Vertex Settings)]
        [Space(5)]
        _LukaAuroraWaveSpeed("Vertex Wave Speed", Range(0, 3)) = 0.5
        _LukaAuroraWaveFrequency("Vertex Wave Frequency", Range(0, 100)) = 20
        _LukaAuroraWaveAmplitude("Vertex Wave Amplitude", Range(0, 1)) = 0.2
        [Space(10)]
        [Header(Advanced Settings)]
        [Space(5)]
        _LukaAuroraSeed("Generation Seed", Float) = 0
	[Enum(UnityEngine.Rendering.BlendMode)] _LukaAuroraBlendSrc("Blend Mode Source", Int) = 5
		[Enum(UnityEngine.Rendering.BlendMode)] _LukaAuroraBlendDst("Blend Mode Destination", Int) = 10
        [Space(25)]
        [Header(Contact)]
        [Space(5)]
        [Header(Website... luka.moe)]
        [Header(Discord... luka 8375)]
        [Header(Email... lukazoeysong gmail.com)]
        [Space(5)]
        _LukaAuroraVersion("Version", Range(1, 1)) = 1
    }

    // subshader
    SubShader {
        
        // render settings
        Tags { "Queue"="Transparent+1000" "RenderType"="Transparent" }
        Blend [_LukaAuroraBlendSrc] [_LukaAuroraBlendDst]
        Cull Off

        Pass {
            CGPROGRAM

            // unity definitions   
            #pragma vertex vertex
            #pragma fragment pixel
            #include "UnityCG.cginc"

            // structures
            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };
            struct v2f
            {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
            };

            // vertex definitions
            float _LukaAuroraWaveSpeed, _LukaAuroraWaveFrequency, _LukaAuroraWaveAmplitude;
            sampler2D _MainTex;
            float4 _MainTex_ST;

            v2f vertex(appdata v) {
                v2f o;
                v.vertex.y += cos((v.vertex.x + _Time.y * _LukaAuroraWaveSpeed) * _LukaAuroraWaveFrequency) * _LukaAuroraWaveAmplitude * (v.vertex.x - 5);
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                return o;
            }

            // unity noise libraries
            // attribution: unity technologies
            inline float unity_noise_randomValue (float2 uv)
            {
                return frac(sin(dot(uv, float2(12.9898, 78.233)))*43758.5453);
            }

            inline float unity_noise_interpolate (float a, float b, float t)
            {
                return (1.0-t)*a + (t*b);
            }

            inline float unity_valueNoise (float2 uv)
            {
                float2 i = floor(uv);
                float2 f = frac(uv);
                f = f * f * (3.0 - 2.0 * f);
                uv = abs(frac(uv) - 0.5);
                float2 c0 = i + float2(0.0, 0.0);
                float2 c1 = i + float2(1.0, 0.0);
                float2 c2 = i + float2(0.0, 1.0);
                float2 c3 = i + float2(1.0, 1.0);
                float r0 = unity_noise_randomValue(c0);
                float r1 = unity_noise_randomValue(c1);
                float r2 = unity_noise_randomValue(c2);
                float r3 = unity_noise_randomValue(c3);
                float bottomOfGrid = unity_noise_interpolate(r0, r1, f.x);
                float topOfGrid = unity_noise_interpolate(r2, r3, f.x);
                float t = unity_noise_interpolate(bottomOfGrid, topOfGrid, f.y);
                return t;
            }

            void unity_simpleNoise_float(float2 UV, float Scale, out float Out)
            {
                float t = 0.0;
                float freq = pow(2.0, float(0));
                float amp = pow(0.5, float(3-0));
                t += unity_valueNoise(float2(UV.x*Scale/freq, UV.y*Scale/freq))*amp;
                freq = pow(2.0, float(1));
                amp = pow(0.5, float(3-1));
                t += unity_valueNoise(float2(UV.x*Scale/freq, UV.y*Scale/freq))*amp;
                freq = pow(2.0, float(2));
                amp = pow(0.5, float(3-2));
                t += unity_valueNoise(float2(UV.x*Scale/freq, UV.y*Scale/freq))*amp;
                Out = t;
            }

            void unity_Remap_float(float In, float2 InMinMax, float2 OutMinMax, out float Out)
            {
                Out = OutMinMax.x + (In - InMinMax.x) * (OutMinMax.y - OutMinMax.x) / (InMinMax.y - InMinMax.x);
            }

            // pixel definitions
            float _LukaAuroraSpeedY, _LukaAuroraSpeedNoise, _LukaAuroraGlow,
            _LukaAuroraNoiseScale, _LukaAuroraGuidePower, _LukaAuroraBrightness,
            _LukaAuroraLines, _LukaAuroraSeed, _LukaAuroraClamp;
            float4 _LukaAuroraColorOne, _LukaAuroraColorTwo;

            float4 pixel(v2f i) : SV_Target {
                // setting up
                float4 auroraMask = tex2D(_MainTex, i.uv);
                float2 auroraUVs[2];
                i.uv *= _LukaAuroraNoiseScale;
                auroraUVs[0] = i.uv * 2.0; // aurora uvs 
                float4 auroraColor = _LukaAuroraColorOne;
                auroraUVs[0].y += (_Time.y * _LukaAuroraSpeedY);
                float simpleNoise = 0;
                auroraUVs[1] = auroraUVs[0] * float2(_LukaAuroraLines, 0.11); // noise uvs
                unity_simpleNoise_float(auroraUVs[1], 30.0, simpleNoise);
                auroraColor = lerp(auroraColor, _LukaAuroraColorTwo, simpleNoise);
                auroraColor.rgb *= simpleNoise;
                float colorNoise = 0.0;
                unity_simpleNoise_float(auroraUVs[1] + (_Time.y * _LukaAuroraSpeedNoise) - _LukaAuroraSeed, 30.0, colorNoise);
                colorNoise = pow(colorNoise, _LukaAuroraGlow);
                auroraColor.a *= pow(auroraMask.r * colorNoise, _LukaAuroraGuidePower); 
                auroraColor.a *= _LukaAuroraBrightness;
                auroraColor.a = clamp(auroraColor.a, 0, _LukaAuroraClamp);
                return auroraColor;
            }

            ENDCG
        }
    }
}

// contact.. 
// website: www.luka.moe
// discord: luka#8375
// email: lukazoeysong@gmail.com

//
//       ...    
//     .::'     
//    :::            luka song
//    :::    zoey, princess of the moon
//    `::.     
//      `':..  
//