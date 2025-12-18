using System;
using System.Threading.Tasks;
using UnityEngine;

/// <summary>
/// 앱 최초 실행 시 필요한 매니저를 호출한다.
/// </summary>
public class AppBootStrap : MonoBehaviour
{
    public static AppBootStrap Instance;

    [SerializeField] private SoundManager soundManager;
    [SerializeField] private UIManager uIManager;

    private async void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        try
        {
            await InitializedManagers();
        }
        catch(Exception e)
        {
            Debug.LogError(e);
        }
    }

    private async Task InitializedManagers()
    {
        await soundManager.Initialized();
        await uIManager.Initialized();
    }
}
