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
    private Animator animator;

    [Expandable] [SerializeField] ObjectsData yakkuruData;
    [SerializeField] GameObject player;

    private void OnValidate()
    {
        if (runningTimer <= 0) {  runningTimer = 3f; }
    }

    // Start is called before the first frame update
    void Start()
    {
        destroyable = GetComponent<Destroyable>();
        rb2 = GetComponent<Rigidbody2D>();
        animator = GetComponentInChildren<Animator>();  

        //spriteRenderer = GetComponentInChildren<SpriteRenderer>();

        if (player == null) { player = GameObject.Find("Player"); }
    }

    // Update is called once per frame
    void Update()
    {

        if (isFleeing) 
        {
            timerStarted = true;

            if (!hasFleeingDirection)
            {
                fleeingDirection = new Vector2(transform.position.x - player.transform.position.x, 
                    transform.position.y - player.transform.position.y).normalized;
                hasFleeingDirection = true;
                animator.SetBool("isRunning", true);
            }

            rb2.velocity = fleeingDirection*yakkuruData.runSpeed*Time.deltaTime;
            if (fleeingDirection.x < 0)
            {
                gameObject.transform.localScale = new Vector3(-1, 1, 1); 
                //msieur Roussel il a dit
                //pas bien
                //spriteRenderer.flipX = true;
            }else { gameObject.transform.localScale = new Vector3(1, 1, 1); }
        }

        if (timerStarted)
        {
            runningCounter += Time.deltaTime;
            if (runningCounter >= runningTimer)
            {
                isFleeing = false;
                timerStarted = false;
                runningCounter = 0;
                rb2.velocity = Vector2.zero;
                animator.SetBool("isRunning", false);
            }
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            isFleeing = true;
            hasFleeingDirection = false;
        }
    }
}
