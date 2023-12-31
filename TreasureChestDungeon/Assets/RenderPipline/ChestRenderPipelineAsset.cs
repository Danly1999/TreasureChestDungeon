using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using UnityEngine.Experimental.Rendering;
using UnityEngine.UI;
using System.Linq; // 导入LINQ库以进行排序

[CreateAssetMenu(menuName ="RenderPipline/ChestRenderPipelineAsset")]
public class ChestRenderPipelineAsset : RenderPipelineAsset
{
    public Shader blurShader;
    [Range(0.1f,1f)]
    public float blurScale = 0.5f;
    protected override RenderPipeline CreatePipeline()
    {
        if(blurShader == null)
        {
            blurShader = Shader.Find("RenderPipeline/Blur");
        }

        Material mat = new Material(blurShader);
        Shader.SetGlobalFloat("_BlurScale", blurScale);
        return new ChestRenderPipeline(mat);
    }
}

public class ChestRenderPipeline : RenderPipeline
{
    CullingResults cullingResults;
    FilteringSettings filteringSettings;
    RenderTargetHandle renderTargetHandleRight;
    RenderTargetHandle renderTargetHandleLeft;
    Material blurMat;
    public static bool isBlur;
    public ChestRenderPipeline(Material blurMat)
    {
        this.blurMat = blurMat;
    }

    protected override void Render(ScriptableRenderContext context, Camera[] cameras)
    {
        

        foreach (var camera in cameras)
        {
            renderTargetHandleRight.Init("CameraRenderTextureRight");
            renderTargetHandleLeft.Init("CameraRenderTextureLeft");
            context.SetupCameraProperties(camera);
            
            if(isBlur)
            {
                CommandBuffer cmdSetRender = new CommandBuffer(){name = "SetRenderTexture"};
                RenderTextureDescriptor descriptor = new RenderTextureDescriptor(camera.pixelWidth/6,camera.pixelHeight/6,RenderTextureFormat.RGB565,0,0);
                cmdSetRender.GetTemporaryRT(renderTargetHandleRight.id,descriptor,FilterMode.Bilinear);
                cmdSetRender.GetTemporaryRT(renderTargetHandleLeft.id,descriptor,FilterMode.Bilinear);
                cmdSetRender.SetRenderTarget(renderTargetHandleRight.id);
                cmdSetRender.ClearRenderTarget(true, true, Color.clear);
                context.ExecuteCommandBuffer(cmdSetRender);
                cmdSetRender.Clear();
            }else
            {
                CommandBuffer cmdSetRender = new CommandBuffer(){name = "ClearTex"};
                cmdSetRender.ClearRenderTarget(true, true, Color.clear);
                context.ExecuteCommandBuffer(cmdSetRender);
                cmdSetRender.Clear();
            }

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
            SortingSettings sortingSettings = new SortingSettings(camera);
            sortingSettings.criteria = SortingCriteria.SortingLayer;
            var drawSettings = new DrawingSettings(new ShaderTagId("SRPDefaultUnlit"), sortingSettings)
            {
                overrideMaterial = null
            };
            filteringSettings = new FilteringSettings(RenderQueueRange.transparent);
            filteringSettings.sortingLayerRange = new SortingLayerRange(0, 0);
            context.DrawRenderers(cullingResults, ref drawSettings, ref filteringSettings);



            if(isBlur)
            {
                CommandBuffer cmdBlit = new CommandBuffer(){name = "BlitTexture"};
                cmdBlit.SetGlobalTexture("_SourceTex", renderTargetHandleRight.id);
                cmdBlit.Blit(renderTargetHandleRight.id, renderTargetHandleLeft.id , blurMat, 2);
                cmdBlit.SetGlobalTexture("_SourceTex", renderTargetHandleLeft.id);
                cmdBlit.Blit(renderTargetHandleLeft.id , renderTargetHandleRight.id, blurMat, 1);
                cmdBlit.Blit(renderTargetHandleRight.id, BuiltinRenderTextureType.CameraTarget);
                cmdBlit.ReleaseTemporaryRT(renderTargetHandleRight.id);
                cmdBlit.ReleaseTemporaryRT(renderTargetHandleLeft.id);
                context.ExecuteCommandBuffer(cmdBlit);
                cmdBlit.Clear();

            }

            filteringSettings.sortingLayerRange = new SortingLayerRange(1,short.MaxValue);
            context.DrawRenderers(cullingResults, ref drawSettings, ref filteringSettings);
            context.Submit();

        }
    }
}
