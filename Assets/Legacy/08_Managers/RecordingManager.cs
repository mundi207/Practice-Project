using UnityEngine;
using System.Collections.Generic;

/// <summary>
/// 녹음 기능을 제공하는 매니저임돠.
/// </summary>
[RequireComponent(typeof(AudioSource))]
public class RecordingManager : MonoBehaviour
{
    public static RecordingManager Instance;
    private AudioClip recordedClip;
    private AudioSource _audioSource;

    private List<string> curMicroDevices;

    private void Awake()
    {
        if (!Instance)
        {
            Instance = this;
        }
    }

    /// <summary>
    /// 현재 연결된 녹음 장치를 확인합니다.
    /// </summary>
    public void CheckMicrophone()
    {
        foreach (var device in Microphone.devices)
        {
            curMicroDevices.Add(device);
            Debug.Log($"장비 이름 : {device}");
        }
    }

    /// <summary>
    /// 녹음을 시작합니다.
    /// </summary>
    public static void StartRecording()
    {
        // 현재 감지된 마이크가 없으면 녹음을 하지 않습니다.
        if (Instance.curMicroDevices.Count <= 0)
        {
            return;
        }
        Instance.recordedClip = Microphone.Start(Microphone.devices[1].ToString(), false, 3, 44100);
        Instance._audioSource = Instance.GetComponent<AudioSource>();
    }

    /// <summary>
    /// 녹음을 멈춥니다.
    /// </summary>
    public static void StopRecording()
    {
        if (!Microphone.IsRecording(Microphone.devices[1]))
        {
            return;
        }

        Microphone.End(Microphone.devices[1]);

        Debug.Log("녹음 종료");
        Debug.Log($"샘플 수: {Instance.recordedClip.samples}");
    }

    public static void PlayRecordClip()
    {
        Instance._audioSource.Play();
    }
}
