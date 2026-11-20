using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;
using UnityEngine.UI;

public class TweenHoverButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Vector3 hoverScale = new Vector3(1.1f, 1.1f, 1f);

    private Vector3 originalScale;
  

    void Awake()
    {

        originalScale = transform.localScale;

    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        transform.localScale = hoverScale;

    }

    public void OnPointerExit(PointerEventData eventData)
    {
        transform.localScale = originalScale;

    }
}
