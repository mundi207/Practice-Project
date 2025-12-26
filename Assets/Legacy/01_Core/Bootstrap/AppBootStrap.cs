using UnityEngine;
using System.Collections.Generic;
using Oculus.Interaction;

public enum ManagerType
{
    UIManager
}

/// <summary>
/// 본 프로젝트에 존재하는 모든 매니저를 로드합니다.
/// </summary>
public class AppBootStrap : MonoBehaviour
{
    [SerializeField] private List<ManagerEntry> managerList;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        InitializeManagers();
    }

    private void Start()
    {
        InitTitle();
    }

    private void InitializeManagers()
    {
        foreach (var entry in managerList)
        {
            if (entry.managerPrefab == null) continue;
            DontDestroyOnLoad(entry.managerPrefab);
        }
    }

    private void InitTitle()
    {
        var ui = FindFirstObjectByType<UIManagement>();
        if (ui != null)
        {
            ui.SpawnAnyPage<TitlePanel>();
            Debug.Log(ui);
        }
        else
        {
            Debug.LogWarning("UIManagement 없음");
        }
    }
}


[System.Serializable]
public class ManagerEntry
{
    public ManagerType type;
    public GameObject managerPrefab;
}
