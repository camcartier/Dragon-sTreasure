using PrimeTween;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageGlowPulse : MonoBehaviour
{
    [SerializeField] private Image glow;
    public float minAlpha = 0.2f;
    public float maxAlpha = 0.9f;
    public float duration = 0.8f;

    public float targetsize;

    private Tween tween;

    void OnEnable()
    {
        glow.color = new Color(glow.color.r, glow.color.g, glow.color.b, minAlpha);
        tween = Tween.Alpha(glow, minAlpha, maxAlpha, duration, Ease.InOutSine,
                            cycles: -1, cycleMode: CycleMode.Yoyo, useUnscaledTime: true);
        Tween.Scale(glow.transform, 1f, targetsize, duration, Ease.InOutSine,
            cycles: -1, cycleMode: CycleMode.Yoyo, useUnscaledTime: true);
    }

    void OnDisable()
    {
        tween.Stop();
    }
}
