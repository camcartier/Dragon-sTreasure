using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using NaughtyAttributes;

public class YakkuruControls : MonoBehaviour
{
    [Header("Idle")]
    private bool isWaiting;
    private float waitingTimer = 4;
    private float waitingTimerCounter;
    private bool waitingTimerStarted;
    private float walkingTimer = 3;
    private float walkingTimerCounter;
    private bool walkingTimerStarted;
    private bool hasDirection;
    private Vector2 walkingDirection;
    private List<Vector2> cardinalDirections;

    [Header ("Fleeing")]
    private bool isFleeing;
    private bool hasFleeingDirection;
    private Vector2 fleeingDirection;
    private bool timerStarted;
    [SerializeField] float runningTimer;
    private float runningCounter;

    [Header ("General")]
    private Destroyable destroyable;
    private Rigidbody2D rb2;
    private Animator animator;
    private SpriteRenderer spriteRenderer;
    private bool gameJustStarted;
    private float startGameWaitingTime = 2f;
    private float startGameWaitingCounter;

    private GameObject bossYakkuruSpawner;


    [Expandable] [SerializeField] ObjectsData yakkuruData;
    [SerializeField] GameObject player;


    private void OnValidate()
    { 
        if (runningTimer <= 0) {  runningTimer = 3f; }

        gameJustStarted= true;
    }

    // Start is called before the first frame update
    void Start()
    {
        destroyable = GetComponent<Destroyable>();
        rb2 = GetComponent<Rigidbody2D>();
        animator = GetComponentInChildren<Animator>();
        bossYakkuruSpawner = GameObject.Find("BossYakkuruSpawner");

        spriteRenderer = GetComponentInChildren<SpriteRenderer>();


        if (player == null) { player = GameObject.Find("Player"); }

        cardinalDirections= new List<Vector2>();
        cardinalDirections.Add(new Vector2(0, 1));
        cardinalDirections.Add(new Vector2(0, -1));
        cardinalDirections.Add(new Vector2(1, 0));
        cardinalDirections.Add(new Vector2(-1, 0));
    }

    // Update is called once per frame
    void Update()
    {
        //on attend 2f sans rien faire au debut du jeu
        if (gameJustStarted)
        {
            if (startGameWaitingCounter< startGameWaitingTime) 
            {
                startGameWaitingCounter += Time.deltaTime;
            }
            else gameJustStarted= false;

                
        }

        //j'ai mis tout le code dedans pour eviter les bugs de demarrage ca semble fonctionner
        if (!gameJustStarted)
        {
            //ca c'est le code de l'idle
            if (isWaiting)
            {
                hasDirection = false;
                waitingTimerStarted = true;
                spriteRenderer.color = Color.white;
                rb2.velocity = Vector2.zero;
            }
            else
            {
                if (!hasDirection)
                {
                    walkingDirection = RandomCardinalDirection();
                    hasDirection = true;
                }
                walkingTimerStarted = true;
                spriteRenderer.color = Color.yellow;
                rb2.velocity = walkingDirection * yakkuruData.walkSpeed * Time.deltaTime;
            }

            //c'est le timer de l'idle
            if (waitingTimerStarted)
            {
                waitingTimerCounter += Time.deltaTime;
                //Debug.Log("I am waiting");
                if (waitingTimerCounter > waitingTimer)
                {
                    isWaiting = false;
                    waitingTimerStarted = false;
                    walkingTimerStarted = true;
                    waitingTimerCounter = 0;
                }
            }

            //c'est la marche de l'idle
            if (walkingTimerStarted)
            {
                walkingTimerCounter += Time.deltaTime;
                //Debug.Log("I am walking");
                if (walkingTimerCounter > walkingTimer)
                {
                    isWaiting = true;
                    walkingTimerStarted = false;
                    waitingTimerStarted = true;
                    walkingTimerCounter = 0;
                }
            }


            //code de la reaction aux degats
            if (isFleeing)
            {
                timerStarted = true;
                //isWalking = false;
                isWaiting = false;
                spriteRenderer.color = Color.white;

                if (!hasFleeingDirection)
                {
                    fleeingDirection = new Vector2(transform.position.x - player.transform.position.x,
                        transform.position.y - player.transform.position.y).normalized;
                    hasFleeingDirection = true;
                    animator.SetBool("isRunning", true);
                }

                rb2.velocity = fleeingDirection * yakkuruData.runSpeed * Time.deltaTime;
                if (fleeingDirection.x < 0)
                {
                    gameObject.transform.localScale = new Vector3(-1, 1, 1);
                    //msieur Roussel il a dit
                    //pas bien
                    //spriteRenderer.flipX = true;
                }
                else { gameObject.transform.localScale = new Vector3(1, 1, 1); }
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
                    isWaiting = true;
                }
            }
        }

    }

    private Vector2 RandomCardinalDirection()
    {
        int randomIndex = Random.Range(0, 3);
        return new Vector2(cardinalDirections[randomIndex].x, cardinalDirections[randomIndex].y);
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            isFleeing = true;
            hasFleeingDirection = false;
        }
    }

    private void OnDestroy()
    {
        //bossYakkuruSpawner.GetComponent<BossYakkuruSpawner>().YakkurusKilled += 1;
    }
}
