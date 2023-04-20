//////////////////////////////////////////
//
// NOTE: This is *not* a valid shader file
//
///////////////////////////////////////////
Shader "Hidden/Light2d-Point-Volumetric" {
Properties {
}
SubShader {
 Tags { "QUEUE" = "Transparent" "RenderPipeline" = "UniversalPipeline" "RenderType" = "Transparent" }
 Pass {
  Tags { "QUEUE" = "Transparent" "RenderPipeline" = "UniversalPipeline" "RenderType" = "Transparent" }
  ZWrite Off
  Cull Off
  GpuProgramID 27942
Program "vp" {
SubProgram "d3d11 " {
Local Keywords { "LIGHT_QUALITY_FAST" "USE_POINT_LIGHT_COOKIES" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Local Keywords { "USE_POINT_LIGHT_COOKIES" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Local Keywords { "LIGHT_QUALITY_FAST" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
"// shader disassembly not supported on DXBC"
}
}
Program "fp" {
SubProgram "d3d11 " {
Local Keywords { "LIGHT_QUALITY_FAST" "USE_POINT_LIGHT_COOKIES" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Local Keywords { "USE_POINT_LIGHT_COOKIES" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Local Keywords { "LIGHT_QUALITY_FAST" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
"// shader disassembly not supported on DXBC"
}
}
}
}
}