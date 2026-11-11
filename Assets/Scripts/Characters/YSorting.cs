using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YSorting : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;

    [SerializeField] private int sortingOrderBase = 1;
    [SerializeField] private float offset = 0f;
    [SerializeField] private int precision = 100;

    void Awake()
    {
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }

    void LateUpdate()
    {
        spriteRenderer.sortingOrder =
            sortingOrderBase - Mathf.RoundToInt(
                (transform.position.y + offset) * precision
            );
    }
}
