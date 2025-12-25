using UnityEngine;
using UnityEngine.UI;

public class TitlePanel : BaseUI
{
    [SerializeField] private Image UnivLogoImage;
    [SerializeField] private Transform LoginObj;
    [SerializeField] private Transform ReservationObj;

    public void OnEnable()
    {
        OnActiveLoginObj();
    }

    public void OnDisable()
    {
        
    }

    public void OnActiveLoginObj()
    {
        LoginObj.gameObject.SetActive(true);
        ReservationObj.gameObject.SetActive(false);
    }  

    public void OnActiveReservationObj()
    {
        LoginObj.gameObject.SetActive(false);
        ReservationObj.gameObject.SetActive(true);
    }
}
