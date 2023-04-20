//////////////////////////////////////////
//
// NOTE: This is *not* a valid shader file
//
///////////////////////////////////////////
Shader "QFSW/Blur" {
Properties {
_Color ("Main Color", Color) = (1,1,1,1)
_OverlayColor ("Overlay Color", Color) = (1,1,1,1)
_MainTex ("Tint Color (RGB)", 2D) = "white" { }
_Radius ("Radius", Range(0, 20)) = 1
}
SubShader {
 Tags { "IGNOREPROJECTOR" = "true" "QUEUE" = "Transparent" "RenderType" = "Opaque" }
 GrabPass {
}
 Pass {
  Tags { "IGNOREPROJECTOR" = "true" "LIGHTMODE" = "ALWAYS" "QUEUE" = "Transparent" "RenderType" = "Opaque" }
  GpuProgramID 134
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
 GrabPass {
}
 Pass {
  Tags { "IGNOREPROJECTOR" = "true" "LIGHTMODE" = "ALWAYS" "QUEUE" = "Transparent" "RenderType" = "Opaque" }
  GpuProgramID 81258
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
 GrabPass {
}
 Pass {
  Tags { "IGNOREPROJECTOR" = "true" "LIGHTMODE" = "ALWAYS" "QUEUE" = "Transparent" "RenderType" = "Opaque" }
  GpuProgramID 160933
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