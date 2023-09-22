using OfficeOpenXml.FormulaParsing.Excel.Functions.DateTime;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class CustomAudioSynthesis : MonoBehaviour
{
    private AudioSource audioSource;
    public float frequency = 440f; // ��ݲ���Ƶ�ʣ�Hz��
    public float amplitude = 0.5f; // ��ݲ������
    private bool isPlaying = false;

    void Start()
    {

        audioSource = GetComponent<AudioSource>();
        audioSource.clip = null; // ȷ��û����Ƶ����
        audioSource.playOnAwake = false;
        audioSource.spatialBlend = 0f; // 2D��Ч
    }
    void Update()
    {
        // ������������ʼ������Ч
        if (Input.GetMouseButtonDown(0) && !isPlaying)
        {
            isPlaying = true;
            audioSource.Play();
        }

        // �ɿ�������ֹͣ��Ч
        if (Input.GetMouseButtonUp(0) && isPlaying)
        {
            isPlaying = false;
            audioSource.Stop();
        }
    }

    // �� OnAudioFilterRead �����кϳɾ�ݲ���Ч
    void OnAudioFilterRead(float[] data, int channels)
    {
        if (isPlaying)
        {
            for (int i = 0; i < data.Length; i += channels)
            {
                // �����ݲ�����ֵ
                float t = (float)i / data.Length; // ��׼��ʱ�� [0, 1]
                float sample = amplitude * (2f * (t - Mathf.Floor(t + 0.5f)));

                // ����Ƶ����д�����
                for (int channel = 0; channel < channels; channel++)
                {
                    data[i + channel] = sample;
                }
            }
        }
        else
        {
            // ���δ������Ч������侲������
            for (int i = 0; i < data.Length; i++)
            {
                data[i] = 0f;
            }
        }

    }
}
