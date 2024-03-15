using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using NaughtyAttributes;

public class YakkuruControls : MonoBehaviour
{
    [Header ("Fleeing")]
    private bool isFleeing;
    private bool hasFleeingDirection;
    private Vector2 fleeingDirection;
    private bool timerStarted;
    [SerializeField] float runningTimer;
    private float runningCounter;

    private Destroyable destroyable;
    private Rigidbody2D rb2;
    private SpriteRenderer spriteRenderer;

    [Expandable] [SerializeField] ObjectsData yakkuruData;
    [SerializeField] GameObject player;

    private void OnValidate()
    {
        if (runningTimer <= 0) {  runningTimer = 8f; }
    }

    // Start is called before the first frame update
    void Start()
    {
        destroyable = GetComponent<Destroyable>();
        rb2 = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();

        if (player == null) { player = GameObject.Find("Player"); }
    }

    // Update is called once per frame
    void Update()
    {
        if(destroyable.MyCurrentHealth != yakkuruData.maxHealth)
        {
            isFleeing = true;
        }

        if (isFleeing) 
        {
            if (!hasFleeingDirection)
            {
                fleeingDirection = new Vector2(transform.position.x - player.transform.position.x, 
                    transform.position.y - player.transform.position.y).normalized;
                hasFleeingDirection = true;
                timerStarted = true;
            }

            rb2.velocity = fleeingDirection*yakkuruData.runSpeed*Time.deltaTime;
            if (fleeingDirection.x < 0)
            {
                spriteRenderer.flipX = true;
            }

        }

        if (timerStarted)
        {
            if (runningCounter < runningTimer)
            {
                runningCounter += Time.deltaTime;
            }
            else { isFleeing = false;  runningCounter = 0f; }
        }
        
    }
}