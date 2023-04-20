//////////////////////////////////////////
//
// NOTE: This is *not* a valid shader file
//
///////////////////////////////////////////
Shader "Sprites/Outline" {
Properties {
_Size ("Size", Float) = 1
_BlurSize ("Blur Size", Float) = 0
_Color ("Color", Color) = (1,1,1,1)
_BlurAlphaMultiplier ("Blur Alpha Multiplier", Float) = 0.7
_BlurAlphaChoke ("Blur Alpha Choke", Float) = 1
[Toggle] _InvertBlur ("Invert Blur", Float) = 0
_AlphaThreshold ("Alpha Threshold", Float) = 0.05
_Buffer ("Buffer", Float) = 0
_MainTex ("Sprite Texture", 2D) = "white" { }
_Flip ("Flip", Vector) = (1,1,1,1)
}
SubShader {
 Tags { "CanUseSpriteAtlas" = "true" "IGNOREPROJECTOR" = "true" "PreviewType" = "Plane" "QUEUE" = "Transparent" "RenderType" = "Transparent" }
 Pass {
  Tags { "CanUseSpriteAtlas" = "true" "IGNOREPROJECTOR" = "true" "PreviewType" = "Plane" "QUEUE" = "Transparent" "RenderType" = "Transparent" }
  ZWrite Off
  Cull Off
  GpuProgramID 56646
Program "vp" {
SubProgram "d3d11 " {
"// shader disassembly not supported on DXBC"
}
}
Program "fp" {
SubProgram "d3d11 " {
"// shader disassembly not supported on DXBC"
}
}
}
}
}