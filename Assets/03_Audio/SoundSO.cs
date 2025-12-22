using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "SoundSO", menuName = "Scriptable Objects/SoundSO")]
public class SoundSO : ScriptableObject
{
    [SerializeField] public SoundList[] sounds;
}
