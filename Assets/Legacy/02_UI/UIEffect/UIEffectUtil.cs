using UnityEngine;
using Cysharp.Threading.Tasks;
using System.Threading;

public static class UIEffectUtil
{
    public static async UniTask Fade(CanvasGroup canvasgroup, float from, float to, float duration, CancellationToken ct = default)
    {
        canvasgroup.alpha = from;
        float time = 0f;

        while (time < duration)
        {
            ct.ThrowIfCancellationRequested();
            time += Time.deltaTime;
            canvasgroup.alpha = Mathf.Lerp(from, to, time / duration);
            await UniTask.Yield(PlayerLoopTiming.Update, ct);
        }

        canvasgroup.alpha = to;
    }

    public static async UniTask SpectrumDataDisplay(RectTransform[] bars, AudioSource audioSource, CancellationToken ct, float barWidth = 5f, float heightMultiplier = 700f)
    {
        int sampleCount = bars.Length;
        float[] samples = new float[sampleCount];

        while (!ct.IsCancellationRequested)
        {
            audioSource.GetSpectrumData(samples, 0, FFTWindow.Hamming);

            for (int i = 0; i < sampleCount; i++)
            {
                bars[i].sizeDelta = new Vector2(barWidth, samples[i] * heightMultiplier);
            }
            await UniTask.Yield(PlayerLoopTiming.Update, ct);
        }
    }
}
