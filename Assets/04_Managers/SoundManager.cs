using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;
    [SerializeField] private AudioResistory audioScriptable;

    public Dictionary<BGMType, AudioSourceObj> BGMList = new Dictionary<BGMType, AudioSourceObj>();
    public Dictionary<SFXType, AudioSourceObj> SFXList = new Dictionary<SFXType, AudioSourceObj>();

    private Transform bgmContainer;
    private Transform sfxContainer;

    public async Task Initialized()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }   
        else
        {
            Destroy(gameObject);
            return;
        }
        SpawnContainer();
        LoadAudioCilp();
    }

    private void SpawnContainer()
    {
        bgmContainer = new GameObject {name = "BgmContainer" }.transform;
        sfxContainer = new GameObject {name = "SfxContainer" }.transform;
    }

    /// <summary>
    /// AudioResistory가 참조하는 오디오 클립들을 불러옵니다.
    /// </summary>
    private void LoadAudioCilp()
    {
        for(int i = 0; i < audioScriptable.bgmClipList.Count; i++)
        {
            AudioSourceObj sourceObj = Instantiate(audioScriptable.poolObjPrefab).GetComponent<AudioSourceObj>();

            sourceObj.transform.SetParent(bgmContainer);
            sourceObj.Clip = audioScriptable.bgmClipList[i];
        }
        for(int i = 0; i < audioScriptable.sfxClipList.Count; i++)
        {
            AudioSourceObj sourceObj = Instantiate(audioScriptable.poolObjPrefab).GetComponent<AudioSourceObj>();

            sourceObj.transform.SetParent(sfxContainer);
            sourceObj.Clip = audioScriptable.sfxClipList[i];
        }
    }

    /// <summary>
    /// BGM을 재생합니다.
    /// </summary>
    public void PlayBGM(BGMType bgmType)
    {
        
    }

    /// <summary>
    /// SFX를 재생합니다.
    /// </summary>
    public void PlaySFX(SFXType sfxType)
    {
        
    }
}
