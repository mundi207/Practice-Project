using System.Threading.Tasks;
using UnityEngine;


public enum InterviewState
{
    QUESTION,
    ANSWER,
    PAUSE,
    EXIT
}

/// <summary>
/// 면접을 생성하고 면접 상황을 추적, 관리합니다.
/// TODO : Data에 대한 정의가 필요함
/// </summary>
public class InterviewManager : MonoBehaviour
{
    public static InterviewManager Instance;
    public InterviewInfo curInterviewInfo;
    public InterviewState curInterviewState;

    // [SerializeField] private InterviewTimer InterviewTimer;
    // [SerializeField] private InterviewTimer AnswerTimer;
    // [SerializeField] private InterviewTimer GuideTimer;

    public void Initialize()
    {
        if (!Instance)
        {
            Instance = this;
        }
    }

    public void SetInterviewInfo(float interviewtime)
    {
        curInterviewInfo.InterviewTime = interviewtime;
        curInterviewInfo.isPaused = false;
        // curInterviewInfo.isExiting = false;

        // TODO : HUD 띄우는 로직이 필요함
        // TODO : 인터뷰 시작, StartInterView()
    }

    public void SpawnInterview()
    {

    }

    public void StartInterView()
    {
        // 타이머 시작
        // InterviewTimer.StartTimer();
    }

    public void PauseInterView()
    {
        curInterviewState = InterviewState.PAUSE;
        curInterviewInfo.isPaused = true;

        // TODO : 인터뷰 중지 팝업 띄우는 로직이 필요함
        // InterviewTimer.PauseTimer();
    }

    public void ExitInterView()
    {
        curInterviewState = InterviewState.EXIT;

        // TODO : 인터뷰 종료 팝업 띄우는 로직이 필요함
        // InterviewTimer.ResetTimer();
    }

    public void StartQuestion()
    {
        curInterviewState = InterviewState.QUESTION;
    }

    public void StartAnswer()
    {
        curInterviewState = InterviewState.ANSWER;
        // AnswerTimer.SetTimer(curInterviewInfo.AnswerTime, true);
    }
}

public struct InterviewInfo
{
    public float InterviewTime; // 면접 총 시간
    public float AnswerTime; // 답변 시간
    public bool isPaused; // 일시정지 여부
}
