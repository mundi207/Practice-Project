using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "UISO", menuName = "Scriptable Objects/UISO")]
public class UISO : ScriptableObject
{
    [SerializeField] public List<UIList> uiList;
}

/*
 구조
 1. 모든 패널과 팝업들은 프리팹으로 저장되고 유니티 런타임 시 동적으로 생성됩니다. 
    씬에 대한 종속성을 최대한 제거하기 위함입니다.
 2. 모든 패널과 팝업들은 본 스크립터블 오브젝트에 저장, UIManager에서 참조합니다.
 3. 모든 패널과 팝업들은 BaseUI를 상속 받습니다.

 * 모든 UI 팝업 및 패널 생성은 UIManager를 통해서만 이루어져야 합니다.
 * 모든 UI 팝업 및 패널들은 프리팹으로 저장되며, UI/Prefab 폴더에 존재합니다.
 * 새로은 UI를 추가 할 때는 꼭 어떤 씬에 들어가는지 씬 이름을 그대로 적어주세요!
 */