using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;

public class ThiefSpawnerControls : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private Color startColor;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = gameObject.GetComponentInChildren<SpriteRenderer>();
        startColor = spriteRenderer.color;
    }




    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet") || collision.gameObject.CompareTag("Fireball"))
        {
            spriteRenderer.color = Color.red;
            StartCoroutine(TimeSpentRed());
        }
    }

    public IEnumerator TimeSpentRed()
    {
        yield return new WaitForSecondsRealtime(3);
        spriteRenderer.color = startColor;
    }


}
