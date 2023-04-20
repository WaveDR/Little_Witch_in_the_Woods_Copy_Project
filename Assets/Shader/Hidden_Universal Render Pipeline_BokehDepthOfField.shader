//////////////////////////////////////////
//
// NOTE: This is *not* a valid shader file
//
///////////////////////////////////////////
Shader "Hidden/Universal Render Pipeline/BokehDepthOfField" {
Properties {
}
SubShader {
 LOD 100
 Tags { "RenderPipeline" = "UniversalPipeline" }
 Pass {
  Name "Bokeh Depth Of Field CoC"
  LOD 100
  Tags { "RenderPipeline" = "UniversalPipeline" }
  ZTest Always
  ZWrite Off
  Cull Off
  GpuProgramID 12160
Program "vp" {
SubProgram "d3d11 " {
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_USE_DRAW_PROCEDURAL" }
"// shader disassembly not supported on DXBC"
}
}
Program "fp" {
SubProgram "d3d11 " {
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_USE_DRAW_PROCEDURAL" }
"// shader disassembly not supported on DXBC"
}
}
}
 Pass {
  Name "Bokeh Depth Of Field Prefilter"
  LOD 100
  Tags { "RenderPipeline" = "UniversalPipeline" }
  ZTest Always
  ZWrite Off
  Cull Off
  GpuProgramID 125263
Program "vp" {
SubProgram "d3d11 " {
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_USE_DRAW_PROCEDURAL" }
"// shader disassembly not supported on DXBC"
}
}
Program "fp" {
SubProgram "d3d11 " {
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_USE_DRAW_PROCEDURAL" }
"// shader disassembly not supported on DXBC"
}
}
}
 Pass {
  Name "Bokeh Depth Of Field Blur"
  LOD 100
  Tags { "RenderPipeline" = "UniversalPipeline" }
  ZTest Always
  ZWrite Off
  Cull Off
  GpuProgramID 174043
Program "vp" {
SubProgram "d3d11 " {
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_USE_DRAW_PROCEDURAL" }
"// shader disassembly not supported on DXBC"
}
}
Program "fp" {
SubProgram "d3d11 " {
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_USE_DRAW_PROCEDURAL" }
"// shader disassembly not supported on DXBC"
}
}
}
 Pass {
  Name "Bokeh Depth Of Field Post Blur"
  LOD 100
  Tags { "RenderPipeline" = "UniversalPipeline" }
  ZTest Always
  ZWrite Off
  Cull Off
  GpuProgramID 253830
Program "vp" {
SubProgram "d3d11 " {
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_USE_DRAW_PROCEDURAL" }
"// shader disassembly not supported on DXBC"
}
}
Program "fp" {
SubProgram "d3d11 " {
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_USE_DRAW_PROCEDURAL" }
"// shader disassembly not supported on DXBC"
}
}
}
 Pass {
  Name "Bokeh Depth Of Field Composite"
  LOD 100
  Tags { "RenderPipeline" = "UniversalPipeline" }
  ZTest Always
  ZWrite Off
  Cull Off
  GpuProgramID 303344
Program "vp" {
SubProgram "d3d11 " {
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_USE_DRAW_PROCEDURAL" }
"// shader disassembly not supported on DXBC"
}
}
Program "fp" {
SubProgram "d3d11 " {
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_USE_DRAW_PROCEDURAL" }
"// shader disassembly not supported on DXBC"
}
}
}
}
SubShader {
 LOD 100
 Tags { "RenderPipeline" = "UniversalPipeline" }
 Pass {
  Name "Bokeh Depth Of Field CoC"
  LOD 100
  Tags { "RenderPipeline" = "UniversalPipeline" }
  ZTest Always
  ZWrite Off
  Cull Off
  GpuProgramID 351151
Program "vp" {
SubProgram "d3d11 " {
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_USE_DRAW_PROCEDURAL" }
"// shader disassembly not supported on DXBC"
}
}
Program "fp" {
SubProgram "d3d11 " {
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_USE_DRAW_PROCEDURAL" }
"// shader disassembly not supported on DXBC"
}
}
}
 Pass {
  Name "Bokeh Depth Of Field Prefilter"
  LOD 100
  Tags { "RenderPipeline" = "UniversalPipeline" }
  ZTest Always
  ZWrite Off
  Cull Off
  GpuProgramID 450612
Program "vp" {
SubProgram "d3d11 " {
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_USE_DRAW_PROCEDURAL" }
"// shader disassembly not supported on DXBC"
}
}
Program "fp" {
SubProgram "d3d11 " {
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_USE_DRAW_PROCEDURAL" }
"// shader disassembly not supported on DXBC"
}
}
}
 Pass {
  Name "Bokeh Depth Of Field Blur"
  LOD 100
  Tags { "RenderPipeline" = "UniversalPipeline" }
  ZTest Always
  ZWrite Off
  Cull Off
  GpuProgramID 478647
Program "vp" {
SubProgram "d3d11 " {
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_USE_DRAW_PROCEDURAL" }
"// shader disassembly not supported on DXBC"
}
}
Program "fp" {
SubProgram "d3d11 " {
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_USE_DRAW_PROCEDURAL" }
"// shader disassembly not supported on DXBC"
}
}
}
 Pass {
  Name "Bokeh Depth Of Field Post Blur"
  LOD 100
  Tags { "RenderPipeline" = "UniversalPipeline" }
  ZTest Always
  ZWrite Off
  Cull Off
  GpuProgramID 525342
Program "vp" {
SubProgram "d3d11 " {
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_USE_DRAW_PROCEDURAL" }
"// shader disassembly not supported on DXBC"
}
}
Program "fp" {
SubProgram "d3d11 " {
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_USE_DRAW_PROCEDURAL" }
"// shader disassembly not supported on DXBC"
}
}
}
 Pass {
  Name "Bokeh Depth Of Field Composite"
  LOD 100
  Tags { "RenderPipeline" = "UniversalPipeline" }
  ZTest Always
  ZWrite Off
  Cull Off
  GpuProgramID 625948
Program "vp" {
SubProgram "d3d11 " {
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_USE_DRAW_PROCEDURAL" }
"// shader disassembly not supported on DXBC"
}
}
Program "fp" {
SubProgram "d3d11 " {
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_USE_DRAW_PROCEDURAL" }
"// shader disassembly not supported on DXBC"
}
}
}
}
}