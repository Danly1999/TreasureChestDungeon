
using System;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.SocialPlatforms;

[RequireComponent(typeof(AudioSource))]
public class CustomAudioSynthesis : MonoBehaviour
{
    private AudioSource audioSource;
    public float frequency = 440f; // 锯齿波的频率（Hz）
    public float amplitude = 0.5f; // 锯齿波的振幅
    private bool isPlaying = false;
    float range;
    private System.Random random = new System.Random();
    void Start()
    {

        audioSource = GetComponent<AudioSource>();
        audioSource.clip = null; // 确保没有音频剪辑
        audioSource.playOnAwake = false;
        audioSource.spatialBlend = 0f; // 2D音效
    }
    void Update()
    {
        // 按下鼠标左键开始播放音效
        if (Input.GetMouseButtonDown(0) && !isPlaying)
        {
            range = UnityEngine.Random.Range(0f, 100f);
            isPlaying = true;
            audioSource.Play();
        }

        // 松开鼠标左键停止音效
        if (Input.GetMouseButtonUp(0) && isPlaying)
        {
            isPlaying = false;
            audioSource.Stop();
        }
    }
    float Map(double value, double fromSource, double toSource, double fromTarget, double toTarget)
    {
        return (float)(fromTarget + (value - fromSource) / (toSource - fromSource) * (toTarget - fromTarget));
    }
    // 在 OnAudioFilterRead 方法中合成锯齿波音效
    void OnAudioFilterRead(float[] data, int channels)
    {
        if (isPlaying)
        {
            for (int i = 0; i < data.Length; i += channels)
            {
                // 计算锯齿波样本值
                float randomValue = Map(random.NextDouble(), 0, 1, -1, 1);

                // 将随机值应用到音频数据
                data[i] = randomValue;

            }
        }
        else
        {
            // 如果未播放音效，则填充静音数据
            for (int i = 0; i < data.Length; i++)
            {
                data[i] = 0f;
            }
        }

    }
}
