using UnityEngine;

public enum LocalDataType
{
    SFX,
    BGM,
    SCREEN_WIDTH,
    SCREEN_HEIGHT,
    IS_FULLSCREEN
}

public static class DataManager
{
    public static OptionLocalData curOptionData;

    public static void LoadOptionData()
    {
        // 사운드
        curOptionData.SFXValue = PlayerPrefs.GetFloat(LocalDataType.SFX.ToString());
        curOptionData.BGMValue = PlayerPrefs.GetFloat(LocalDataType.BGM.ToString());

        // 화면
        curOptionData.ScreenResolutionWidthSize = PlayerPrefs.GetInt(LocalDataType.SCREEN_WIDTH.ToString());
        curOptionData.ScreenResolutionHeightSize = PlayerPrefs.GetInt(LocalDataType.SCREEN_HEIGHT.ToString());
        curOptionData.isFullScreen = System.Convert.ToBoolean(PlayerPrefs.GetInt(LocalDataType.IS_FULLSCREEN.ToString()));
    }

    public static void SaveOptionData()
    {
        PlayerPrefs.SetFloat(LocalDataType.BGM.ToString(), curOptionData.SFXValue);
        PlayerPrefs.SetFloat(LocalDataType.SFX.ToString(), curOptionData.BGMValue);

        PlayerPrefs.SetInt(LocalDataType.SCREEN_WIDTH.ToString(), curOptionData.ScreenResolutionWidthSize);
        PlayerPrefs.SetInt(LocalDataType.SCREEN_HEIGHT.ToString(), curOptionData.ScreenResolutionHeightSize);
        PlayerPrefs.SetInt(LocalDataType.IS_FULLSCREEN.ToString(), System.Convert.ToInt16(curOptionData.isFullScreen));
    }
}

public struct OptionLocalData
{
    public float SFXValue;
    public float BGMValue;

    public int ScreenResolutionWidthSize;
    public int ScreenResolutionHeightSize;

    public bool isFullScreen;
}
