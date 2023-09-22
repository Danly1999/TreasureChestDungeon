using OfficeOpenXml.FormulaParsing.Excel.Functions.DateTime;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class CustomAudioSynthesis : MonoBehaviour
{
    private AudioSource audioSource;
    public float frequency = 440f; // 锯齿波的频率（Hz）
    public float amplitude = 0.5f; // 锯齿波的振幅
    private bool isPlaying = false;

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

    // 在 OnAudioFilterRead 方法中合成锯齿波音效
    void OnAudioFilterRead(float[] data, int channels)
    {
        if (isPlaying)
        {
            for (int i = 0; i < data.Length; i += channels)
            {
                // 计算锯齿波样本值
                float t = (float)i / data.Length; // 标准化时间 [0, 1]
                float sample = amplitude * (2f * (t - Mathf.Floor(t + 0.5f)));

                // 将音频数据写入输出
                for (int channel = 0; channel < channels; channel++)
                {
                    data[i + channel] = sample;
                }
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
