using TMPro;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 로그인 팝업을 관리하는 스크립트 입니다.
/// </summary>
public class LoginPopup : BaseUI
{
    [Header("로그인 화면 버튼들")]
    [SerializeField] private Button loginBtn;
    [SerializeField] private Button findLoginOrPass;

    [Header("로그인 및 비밀번호 인풋필드들")]
    [SerializeField] private TMP_InputField loginField;
    [SerializeField] private TMP_InputField passField;

    public override void Show()
    {
        base.Show();
    }
    
    public override void Hide()
    {
        base.Hide();
    }

    private void OnEnable()
    {
        
    }

    private void OnDisable()
    {
        
    }

    /// <summary>
    /// 로그인 버튼 이벤트 입니다.
    /// </summary>
    public void OnClickLogin()
    {
        // TODO : 로그인 성공 시에만 다음화면으로 넘어가게 구현 필요. 현재는 예약화면으로 바로 넘어갑니다.
        UIManagement.Instance?.GoNextUI<ReservationPopup>(this, transform.parent);
    }

    /// <summary>
    /// 아이디 및 비밀번호 찾기 버튼 이벤트 입니다.
    /// </summary>
    public void OnClickFindIdorPass()
    {
        // TODO : 추후에 구현 필요.
    }
}
