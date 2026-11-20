using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using PrimeTween;
public class ImageColorAnimation : MonoBehaviour
{
    [SerializeField] private Image image;
    public Color color1;
    public Color color2;
    public float duration;

    private Tween tween;

    private void OnEnable()
    {
        image.color = color1;
        tween = Tween.Color(image, color1, color2, duration, Ease.InOutSine,
                            cycles: -1, cycleMode: CycleMode.Yoyo);
    }


    private void OnDisable()
    {
        tween.Stop();
    }



}
