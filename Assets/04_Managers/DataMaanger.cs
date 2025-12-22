using UnityEngine;

public enum DataType
{
    
}

public class DataMaanger : MonoBehaviour
{
    public static DataMaanger Instance;

    private void Awake()
    {
        if(!Instance)
        {
            Instance = this;
        }
    }
}

public struct DataList
{
    
}

