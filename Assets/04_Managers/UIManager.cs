using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;

public enum UIType
{
    Popup,
    Page,
    typeCount
}

/// <summary>
/// 프로젝트 내의 모든 UI 요소를 생성 및 관리합니다.
/// </summary>
[RequireComponent(typeof(UIManager))] 
public class UIManager : Singleton<UIManager>
{
    private List<UIList> AllUiList = new List<UIList>();
    private List<BaseUI> UiListCache = new List<BaseUI>();

    [SerializeField] private UISO UiData;
    [SerializeField] private Canvas UIRoot;

    protected override void OnSingletonInit()
    {
        Debug.Log("UIManager 초기화");
        foreach(var uilist in UiData.uiList)
        {
            AllUiList.Add(uilist);
        }
    }

    // TODO : VR이 바라보는 방향에 따라 생성지점을 바꾸도록 확장 필요 
    /// <summary>
    /// 원하는 팝업창을 생성합니다.
    /// </summary>
    public void SpawnAnyPopup<T>(Transform parent = null) where T : BaseUI
    {
        UIList curUI = AllUiList.Find(x => x.uiInstance is T);
        T go = Instantiate(curUI.uiInstance) as T;

        if(!parent)
            go.gameObject.transform.SetParent(UIRoot.transform);
        else
            go.gameObject.transform.SetParent(parent, false);
        if(go)
            UiListCache.Add(go.GetComponent<BaseUI>());
        else
            Debug.LogError("해당 UI 요소가 없습니다.");
    }

    // TODO : VR이 바라보는 방향에 따라 생성지점을 바꾸도록 확장 필요 
    /// <summary>
    /// 원하는 페이지를 생성합니다.
    /// </summary>
    public void SpawnAnyPage<T>(Transform parent = null) where T : BaseUI
    {
        UIList curUI = AllUiList.Find(x => x.uiInstance.GetComponent<BaseUI>() is T);

        Debug.Log(curUI);
        Debug.Log(curUI.spawnScene);
        Debug.Log(curUI.uiInstance);

        T go = Instantiate(curUI.uiInstance).GetComponent<T>();

        if(!parent)
            go.gameObject.transform.SetParent(UIRoot.transform, false);
        else
            go.gameObject.transform.SetParent(parent, false);
        if(go)
            UiListCache.Add(go.GetComponent<BaseUI>());
        else
            Debug.LogError("해당 UI 요소가 없습니다.");
    }

    /// <summary>
    /// 지정한 UI를 제거합니다.
    /// </summary>
    public void DestroyAnyUI<T>(BaseUI targetUI) where T : BaseUI
    {
        if(UiListCache.Count < 1)
        {
            Debug.LogError("현재 생성된 UI가 없습니다!");
            return;
        }

        Destroy(targetUI.gameObject);
        UiListCache.RemoveAll(x => x.GetComponent<T>() == targetUI);
    }
    
    /// <summary>
    /// 모든 UI를 제거합니다. 
    /// </summary>
    public void AllDestroyUI()
    {
        if(UiListCache.Count < 1)
        {
            Debug.LogError("현재 생성된 UI가 없습니다!");
            return;
        }
        else
        {
            foreach(var ui in UiListCache)
            {
                Destroy(ui.gameObject);
            }
            UiListCache.Clear();
        }
    }
}

[System.Serializable]
public struct UIList
{
    public UIType type;
    public GameObject uiInstance;
    public string spawnScene;
}