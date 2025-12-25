using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Oculus.Voice.Core.Bindings.Android.PlatformLogger;
using UnityEngine;
using UnityEngine.Audio;

public enum SoundType
{
    MOVE,
    JUMP
}

/// <summary>
/// 구조체 배열 인덱스와 SoundType 인덱스가 맞아 떨어져야 함.
/// </summary>
[RequireComponent(typeof(AudioSource))]
public class SoundManager : Singleton<SoundManager>
{
    private AudioSource audioSource;

    [SerializeField] private SoundSO soundSO;

    protected override void OnSingletonInit()
    {
        Debug.Log("SoundManager Init...");
    }

    public static void PlaySound(SoundType type, AudioSource source = null, float volume = 1f)
    {
        SoundList soundList = Instance.soundSO.sounds[(int)type];
        AudioClip[] clips = soundList.Sounds;
        AudioMixerGroup audioMixerGroup = soundList.mixer;

        if(source)
        {
            source.clip = clips[UnityEngine.Random.Range(0, clips.Length)];
            source.outputAudioMixerGroup = audioMixerGroup;
            source.volume = volume * soundList.volume;
            source.Play();
        }
        else
        {
            Instance.audioSource.outputAudioMixerGroup = audioMixerGroup;
            Instance.audioSource.PlayOneShot(clips[UnityEngine.Random.Range(0, clips.Length)], volume * soundList.volume);
        }
    }
}

[Serializable]
public struct SoundList
{
    [HideInInspector] public string name;
    [Range(0, 1)] public float volume;
    public AudioMixerGroup mixer;
    public AudioClip[] Sounds;
}
