using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using UnityEngine.Experimental.Rendering;

[CreateAssetMenu(menuName ="RenderPipline/CustomRenderPipelineAsset")]
public class CustomRenderPipelineAsset : RenderPipelineAsset
{
    protected override RenderPipeline CreatePipeline()
    {
        return new CustomRenderPipeline();
    }
}

public class CustomRenderPipeline : RenderPipeline
{
    private CommandBuffer cameraBuffer = new CommandBuffer();
    private CullingResults cullingResults;
    FilteringSettings filteringSettings;

    protected override void Render(ScriptableRenderContext context, Camera[] cameras)
    {

        foreach (var camera in cameras)
        {
            // 清空渲染目标
            context.SetupCameraProperties(camera);
            cameraBuffer.ClearRenderTarget(true, true, Color.clear);

            if (!camera.TryGetCullingParameters(out var cullingParameters))
            {
                return;
            }
            cullingResults = context.Cull(ref cullingParameters);

            // 执行渲染
            var drawSettings = new DrawingSettings(new ShaderTagId("SRPDefaultUnlit"), new SortingSettings(camera))
            {
                overrideMaterial = null
            };
            filteringSettings = new FilteringSettings(RenderQueueRange.transparent);
            context.DrawRenderers(cullingResults, ref drawSettings, ref filteringSettings);
            context.Submit();
        }
    }
}
