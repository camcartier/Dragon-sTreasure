using PrimeTween;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageGlowPulse : MonoBehaviour
{
    [SerializeField] private Image image;
    [Header("glow")]
    public float minAlpha = 0.2f;
    public float maxAlpha = 0.9f;
    public bool doesGlow;

    [Header("pulse")]
    public float targetsize;
    public bool doesPulse;

    [Header("durations")]
    public float glowDuration = 0.8f;
    public float pulseDuration = 0.8f;


    private Tween tween;

    void OnEnable()
    {
        image.color = new Color(image.color.r, image.color.g, image.color.b, minAlpha);
        if (doesGlow)
        {
            tween = Tween.Alpha(image, minAlpha, maxAlpha, glowDuration, Ease.InOutSine,
                            cycles: -1, cycleMode: CycleMode.Yoyo, useUnscaledTime: true);
        }
        if (doesPulse)
        {
            Tween.Scale(image.transform, 1f, targetsize, pulseDuration, Ease.InOutSine,
            cycles: -1, cycleMode: CycleMode.Yoyo, useUnscaledTime: true);
        }
        
    }

    void OnDisable()
    {
        tween.Stop();
    }
}
