using Unity.Profiling;
using UnityEngine;
using System.Collections.Generic;

/// <summary>
/// BaseURL 및 Path 정보를 저장합니다.
/// </summary>
[CreateAssetMenu(fileName = "ApiConfig", menuName = "Scriptable Objects/ApiConfig")]
public class ApiConfig : ScriptableObject
{
    [Header("API Base URL")]
    [SerializeField] public string BaseURL = "http://localhost";

    [Header("Paths")]
    [SerializeField] public List<PathList> path;
}
[System.Serializable]
public struct PathList
{
    public PathType type;
    public string path;
}

public enum PathType
{
    TEST,
    QUESTION,
    ANSWER,
    NONVERBAL,
    REQ_STT,
    REQ_TTS,
    TypeCount
}

/* 질문 진행 플로우는 다음과 같습니다. (단순화, 해당 항목이 무한반복!)

1. 질문 시작 (질문 호출 API 요청) -> 서버에서는 이미 질문을 한번에 뽑아서 리스트로 가지고 있음. TTS 생성도 마찬가지
2. 질문이 끝나면 -> TTS 요청 -> Response로 wav혹은 mp3 음성파일 받음
3. 면접자 답변 -> STT 요청 및 비언어적 데이터 서버로 보냄

*/