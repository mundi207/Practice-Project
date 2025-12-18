using UnityEngine;
using UnityEngine.Audio;

/// <summary>
/// 오디오 풀링의 대상 오브젝트가 자신의 클립 및 사운드 타입을 가지게.
/// </summary>
public class AudioSourceObj : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioMixerGroup audioGroup;

    public AudioClip Clip;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }
}
