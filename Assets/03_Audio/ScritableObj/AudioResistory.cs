using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "AudioResistory", menuName = "Scriptable Objects/AudioResistory")]
public class AudioResistory : ScriptableObject
{
    [Header("BGM")]
    public List<AudioClip> bgmClipList;

    [Header("SFX")]
    public List<AudioClip> sfxClipList;

    [Header("Prefab")]
    public GameObject poolObjPrefab;
}
