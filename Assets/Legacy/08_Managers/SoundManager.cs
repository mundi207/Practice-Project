using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using Cysharp.Threading.Tasks;

[RequireComponent(typeof(AudioSource))]
public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;
    private AudioSource audioSource;

    [SerializeField] private SoundData _soundData;
    private List<SoundList> _soundCache = new List<SoundList>();

    public void Initialize()
    {
        if (!Instance)
        {
            Instance = this;
            audioSource = GetComponent<AudioSource>();
        }
    }

    public static void SoundPlay(AudioType type, AudioSource source = null, float volume = 1f)
    {
        SoundList so = Instance._soundData.soundDatas[(int)type];
        Instance._soundCache.Add(so);

        AudioMixerGroup mixer = so.mixer;
        AudioClip rendomclip = so.Sounds[UnityEngine.Random.Range(0, so.Sounds.Length)];

        if (source)
        {
            source.volume = volume * so.volume;
            source.clip = rendomclip;
            source.outputAudioMixerGroup = mixer;
            source.Play();
        }
        else
        {
            Instance.audioSource.volume = volume * so.volume;
            Instance.audioSource.clip = rendomclip;
            Instance.audioSource.outputAudioMixerGroup = mixer;
            Instance.audioSource.Play();
        }
    }

    public static void SoundPause(AudioType type, AudioSource source = null)
    {
        SoundList so = Instance._soundData.soundDatas[(int)type];

        if (source)
        {

        }
        else
        {

        }
    }

    public static void SetVolume(AudioType type, AudioSource source = null, float volume = 1f)
    {
        SoundList so = Instance._soundData.soundDatas[(int)type];

        if (source)
        {

        }
        else
        {

        }
    }

    public static void GetSoundIsEnd(AudioType type, AudioSource source)
    {
        if (source && source.clip != null)
        {
            float audioClipLength = source.clip.length;
            Debug.Log($"오디오 클립 길이: {audioClipLength}초");
        }
        else
        {
            Debug.LogError("클립이 존재하지 않습니다.");
        }
    }

    public static void MuteSound()
    {

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
