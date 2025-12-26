using Cysharp.Threading.Tasks;
using System.Collections.Generic;
using System.Text;
using System.Xml.Schema;
using UnityEngine;
using UnityEngine.Networking;

[System.Serializable]
public class TtsReq
{
    public string text;
}
public class ApiClient : MonoBehaviour
{
    /// <summary>
    /// GET 요청 할 때 씁니다.
    /// </summary>
    public static async UniTask<string> Get(string path)
    {
        using var request = UnityWebRequest.Get(ApiConfig.BaseUrl + path);
        request.timeout = ApiConfig.TimeoutSeconds;
        await request.SendWebRequest();
        return request.downloadHandler.text;
    }

    public static async UniTask PostTTS(string path, string text)
    {
        string url = ApiConfig.BaseUrl + path;
        var payload = new TtsReq
        {
            text = text
        };

        string json = JsonUtility.ToJson(payload);
        Debug.Log(json);
        byte[] bodyRaw = Encoding.UTF8.GetBytes(json);

        using var request = new UnityWebRequest(url, "POST");
        request.uploadHandler = new UploadHandlerRaw(bodyRaw);
        request.downloadHandler = new DownloadHandlerBuffer();
        request.SetRequestHeader("Content-Type", "application/json");

        await request.SendWebRequest();

        if (request.result != UnityWebRequest.Result.Success)
            Debug.LogError(request.error);
        else
            Debug.Log(request.downloadHandler.text);
    }

    /// <summary>
    /// POST 요청 할 때 씁니다. (파일을 보내거나 할때...)
    /// </summary>
    public static async UniTask<string> PostSTT(string path, byte[] fileBytes, string fileName, Dictionary<string, string> fields = null)
    {
        string url = ApiConfig.BaseUrl + path;

        List<IMultipartFormSection> formSections = new List<IMultipartFormSection>();

        // POST 요청과 함께 보낼 HTTP 바디부분. 키값을 정의한다.
        // 질문 자체를 보낼 필ㅇ가 없다 -> id 만
        formSections.Add(new MultipartFormFileSection(
            "file", // 현재 파일 형태
            fileBytes, // 바이너리 정보, byte[]
            fileName, // 파일 이름
            "audio/wav" // 보낼 파일 확장자명
        ));

        if (fields != null)
        {
            foreach (var pair in fields)
            {
                formSections.Add(new MultipartFormDataSection(
                    pair.Key,
                    pair.Value,
                    Encoding.UTF8,
                    "text/plain" // 평범한 글자.
                ));
            }
        }

        using UnityWebRequest request = UnityWebRequest.Post(url, formSections);
        request.timeout = ApiConfig.TimeoutSeconds;

        while (!request.SendWebRequest().isDone)
        {
            await UniTask.Yield();
        }

        if (request.result != UnityWebRequest.Result.Success)
        {
            Debug.LogError($"POST Respone Failed");
            throw new System.Exception(request.error);
        }

        // JSON
        Debug.Log(request.downloadHandler.text);

        return request.downloadHandler.text;
    }
}
