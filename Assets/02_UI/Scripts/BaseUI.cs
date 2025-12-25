using UnityEngine;

public class BaseUI : MonoBehaviour
{
    /// <summary>
    /// 해당 팝업을 띄웁니다.
    /// </summary>
    public virtual void Show() => gameObject.SetActive(true);

    /// <summary>
    /// 해당 팝업을 숨깁니다.
    /// </summary>
    public virtual void Hide() => gameObject.SetActive(false);
}
