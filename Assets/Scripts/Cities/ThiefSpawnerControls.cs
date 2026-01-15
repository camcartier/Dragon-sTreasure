using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;
using UnityEngine.Rendering;

public class ThiefSpawnerControls : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private Color startColor;

    private SpawnersControls spawnerControls;
    public float amount;

    [SerializeField] PlayerData playerData;

    //private bool hasStartedInvoke;

    //[SerializeField] GameObject ThiefPrefab;
    //[SerializeField] GameObject SpawnPoint;
    //public float timeBeforeNextSpawn;

    void Start()
    {
        spawnerControls = GetComponent<SpawnersControls>();
        spriteRenderer = gameObject.GetComponentInChildren<SpriteRenderer>();
        startColor = spriteRenderer.color;
    }

    void Update()
    {
        if (playerData.currentLevel > 0)
        {
            spawnerControls.hasStartedSpawning = true;
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet") || collision.gameObject.CompareTag("Fireball"))
        {
            spriteRenderer.color = Color.red;
            StartCoroutine(TimeSpentRed());


            spawnerControls.delayBetweenSpawns += amount;
        }
    }

    //old code
    /*
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if(timeBeforeNextSpawn != 0)
            {
                if (!hasStartedInvoke)
                {
                    InvokeRepeating(nameof(SpawnThief), 0, timeBeforeNextSpawn);
                    hasStartedInvoke = true;
                }
                
            }
            else { Debug.Log("missing value"); }
        }
    }*/

    public IEnumerator TimeSpentRed()
    {
        yield return new WaitForSecondsRealtime(3);
        spriteRenderer.color = startColor;
    }

    /*
    private void SpawnThief()
    {
        Debug.Log("+1thief");
        Instantiate(ThiefPrefab, new Vector2(SpawnPoint.transform.position.x, SpawnPoint.transform.position.y), Quaternion.identity);
    }*/
}
