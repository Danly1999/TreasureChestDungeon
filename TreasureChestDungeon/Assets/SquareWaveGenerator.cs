using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SquareWaveGenerator : MonoBehaviour
{
    private AudioSource audioSource;
    public float frequency = 440f; // 方形波频率（默认为A4音符）
    private float sampleRate = 44100; // 音频采样率
    private float phase = 0f; // 波形相位

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = null; // 确保没有音频剪辑

        // 设置音频源属性
        audioSource.playOnAwake = false;
        audioSource.spatialBlend = 0f; // 2D音效

        // 设置音频采样率
        AudioConfiguration config = AudioSettings.GetConfiguration();
        sampleRate = config.sampleRate;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            PlaySquareWave();
        }
    }

    void PlaySquareWave()
    {
        int numSamples = audioSource.clip == null ? 1024 : audioSource.clip.samples; // 使用或创建一个新的音频剪辑
        float[] samples = new float[numSamples];

        // 生成方形波信号
        for (int i = 0; i < numSamples; i++)
        {
            float t = phase / sampleRate;
            float squareWave = Mathf.Sign(Mathf.Sin(2f * Mathf.PI * frequency * t));
            samples[i] = squareWave;
            phase += 1f;
        }

        // 创建新的音频剪辑并设置音频数据
        AudioClip squareWaveClip = AudioClip.Create("SquareWave", numSamples, 1, (int)sampleRate, false);
        squareWaveClip.SetData(samples, 0);

        // 播放方形波音频
        audioSource.clip = squareWaveClip;
        audioSource.Play();

        // 重置相位
        phase = 0f;
    }
}
