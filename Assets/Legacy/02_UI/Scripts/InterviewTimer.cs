using TMPro;
using UnityEngine;

public class InterviewTimer : MonoBehaviour
{
    private float curTime;
    private float setTime;

    private bool isPause = false;
    private bool isConstraint;

    [SerializeField] private TMP_Text _textField;

    // �ܺο��� ȣ��
    public void SetTimer(float time, bool isconstraint = false)
    {
        setTime = time;
        isConstraint = isconstraint;

        isPause = false;
    }

    public void StartTimer()
    {
        isPause = false;
    }

    public void PauseTimer()
    {
        isPause = true;
    }

    public void ResetTimer()
    {
        curTime = setTime;
    }

    private void Update()
    {
        if (curTime == 0 || isPause)
            return;
        if (isConstraint)
            curTime -= Time.deltaTime;
        else
            curTime += Time.deltaTime;

        int minute = Mathf.FloorToInt(setTime / 60);
        int second = Mathf.FloorToInt(setTime % 60);

        _textField.text = $"{minute}:{second}";
    }
}
