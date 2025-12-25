using UnityEngine;
using System.Collections.Generic;

/// <summary>
/// 앱 최초 실행 시 필요한 매니저를 호출합니다.
/// </summary>]
[RequireComponent(typeof(AppBootStrap))]
public class AppBootStrap : MonoBehaviour
{
    [SerializeField] private List<GameObject> managerPrefabs;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);

        foreach (var prefab in managerPrefabs)
        {
            if (prefab == null) continue;

            var managerType = prefab.GetComponent<MonoBehaviour>().GetType();

            // 이미 존재하면 생성 안 함
            if (FindObjectOfType(managerType) == null)
            {
                Instantiate(prefab);
            }
        }
        InitTitle();
    }

    public void InitTitle()
    {
        UIManager.Instance?.SpawnAnyPage<TitlePanel>();
    }
}
