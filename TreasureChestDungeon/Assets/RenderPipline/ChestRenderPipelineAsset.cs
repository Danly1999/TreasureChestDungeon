using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using UnityEngine.Experimental.Rendering;

[CreateAssetMenu(menuName ="RenderPipline/ChestRenderPipelineAsset")]
public class ChestRenderPipelineAsset : RenderPipelineAsset
{
    protected override RenderPipeline CreatePipeline()
    {
        return new ChestRenderPipeline();
    }
}

public class ChestRenderPipeline : RenderPipeline
{
    CullingResults cullingResults;
    FilteringSettings filteringSettings;
    RenderTargetHandle renderTargetHandleRight;
    RenderTargetHandle renderTargetHandleLeft;

    protected override void Render(ScriptableRenderContext context, Camera[] cameras)
    {

        foreach (var camera in cameras)
        {
            renderTargetHandleRight.Init("CameraRenderTextureRight");
            renderTargetHandleLeft.Init("CameraRenderTextureLeft");
            context.SetupCameraProperties(camera);
            
            CommandBuffer cmdSetRender = new CommandBuffer(){name = "SetRenderTexture"};
            
            RenderTextureDescriptor descriptor = new RenderTextureDescriptor(camera.pixelWidth/6,camera.pixelHeight/6,RenderTextureFormat.ARGB32,24,0);
            cmdSetRender.GetTemporaryRT(renderTargetHandleRight.id,descriptor,FilterMode.Bilinear);
            cmdSetRender.GetTemporaryRT(renderTargetHandleLeft.id,descriptor,FilterMode.Bilinear);
            cmdSetRender.SetRenderTarget(renderTargetHandleRight.id);
            cmdSetRender.ClearRenderTarget(true, true, Color.clear);
            context.ExecuteCommandBuffer(cmdSetRender);
            cmdSetRender.Clear();


            if (!camera.TryGetCullingParameters(out var cullingParameters))
            {
                return;
            }
            
#if UNITY_EDITOR
            if (camera.cameraType == CameraType.SceneView)
            {
                ScriptableRenderContext.EmitWorldGeometryForSceneView(camera);
            }
#endif
            cullingResults = context.Cull(ref cullingParameters);

            var drawSettings = new DrawingSettings(new ShaderTagId("SRPDefaultUnlit"), new SortingSettings(camera))
            {
                overrideMaterial = null
            };
            filteringSettings = new FilteringSettings(RenderQueueRange.transparent);
            filteringSettings.sortingLayerRange = new SortingLayerRange(0,0);
            context.DrawRenderers(cullingResults, ref drawSettings, ref filteringSettings);
            CommandBuffer cmdBlit = new CommandBuffer(){name = "BlitTexture"};
            Shader shader = Shader.Find("RenderPipeline/Bloom");
            Material mat = new Material(shader);
            cmdBlit.SetGlobalTexture("_SourceTex", renderTargetHandleRight.id);
            cmdBlit.Blit(renderTargetHandleRight.id, renderTargetHandleLeft.id , mat, 2);
            cmdBlit.SetGlobalTexture("_SourceTex", renderTargetHandleLeft.id);
            cmdBlit.Blit(renderTargetHandleLeft.id , renderTargetHandleRight.id, mat, 1);
            cmdBlit.Blit(renderTargetHandleRight.id, BuiltinRenderTextureType.CameraTarget);
            cmdBlit.ReleaseTemporaryRT(renderTargetHandleRight.id);
            cmdBlit.ReleaseTemporaryRT(renderTargetHandleLeft.id);
            context.ExecuteCommandBuffer(cmdBlit);
            cmdBlit.Clear();
            filteringSettings.sortingLayerRange = new SortingLayerRange(1,1);
            context.DrawRenderers(cullingResults, ref drawSettings, ref filteringSettings);
            context.Submit();

        }
    }
}
