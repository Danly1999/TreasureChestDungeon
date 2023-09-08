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
    private CommandBuffer cameraBuffer ;
    private CullingResults cullingResults;
    FilteringSettings filteringSettings;

    protected override void Render(ScriptableRenderContext context, Camera[] cameras)
    {

        foreach (var camera in cameras)
        {
            // �����ȾĿ��
            //cameraBuffer = new CommandBuffer() { name = "ClearRenderTarget" };
            //cameraBuffer.ClearRenderTarget(true, true, Color.blue);
            //context.ExecuteCommandBuffer(cameraBuffer);
            //cameraBuffer.Clear();


            context.SetupCameraProperties(camera);

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
            // ִ����Ⱦ
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
