using UnityEngine;
using UnityEngine.UI;

public class TitlePanel : BaseUI
{
    [SerializeField] private Image UnivLogoImage;
    [SerializeField] private Transform LoginObj;
    [SerializeField] private Transform ReservationObj;

    public void OnEnable()
    {
        UnivLogoImage.gameObject.SetActive(true);
        LoginObj.gameObject.SetActive(true);
        ReservationObj.gameObject.SetActive(false);
    }

    public void OnDisable()
    {
        
    }
}
