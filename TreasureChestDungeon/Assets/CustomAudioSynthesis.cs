
using System;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.SocialPlatforms;

[RequireComponent(typeof(AudioSource))]
public class CustomAudioSynthesis : MonoBehaviour
{
    private AudioSource audioSource;
    public float frequency = 440f; // ��ݲ���Ƶ�ʣ�Hz��
    public float amplitude = 0.5f; // ��ݲ������
    private bool isPlaying = false;
    float range;
    private System.Random random = new System.Random();
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
            range = UnityEngine.Random.Range(0f, 100f);
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
    float Map(double value, double fromSource, double toSource, double fromTarget, double toTarget)
    {
        return (float)(fromTarget + (value - fromSource) / (toSource - fromSource) * (toTarget - fromTarget));
    }
    // �� OnAudioFilterRead �����кϳɾ�ݲ���Ч
    void OnAudioFilterRead(float[] data, int channels)
    {
        if (isPlaying)
        {
            for (int i = 0; i < data.Length; i += channels)
            {
                // �����ݲ�����ֵ
                float randomValue = Map(random.NextDouble(), 0, 1, -1, 1);

                // �����ֵӦ�õ���Ƶ����
                data[i] = randomValue;

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
