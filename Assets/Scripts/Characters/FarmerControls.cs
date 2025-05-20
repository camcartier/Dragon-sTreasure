using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;
using System.Runtime.CompilerServices;

public class FarmerControls : MonoBehaviour
{
    [Header("Setup")]
    [Expandable][SerializeField] ObjectsData farmerData;
    [SerializeField] List<Vector2> fleeingPosList;
    [SerializeField] GameObject player;
    [SerializeField] GameObject healthCanvas;
    [SerializeField] GameObject surpriseFX;

    private Destroyable destroyable;
    private Rigidbody2D farmerRb;
    private Animator animator;

    private SpriteRenderer spriteRenderer;

    private readonly int AttackHash = Animator.StringToHash("Peasant_1");
    private const float CrossFadeDuration = 0.1f;

    public bool isFollowing { get; private set;}
    public bool isFleeing { get; private set;}
    public bool canBeStunned { get; private set;}
    public bool isStunned { get; private set; }
    private float stunTimerCounter;

    public bool canTurn;

    //private float turnDelayCounter;

    void Start()
    {
        player = GameObject.Find("Player");

        farmerRb = GetComponent<Rigidbody2D>();
        destroyable = GetComponent<Destroyable>();
        animator = GetComponentInChildren<Animator>();

        spriteRenderer= GetComponentInChildren<SpriteRenderer>();

        canBeStunned= true;
    }


    void Update()
    {
        
        if (destroyable.MyCurrentHealth < farmerData.maxHealth)
        {
            surpriseFX.SetActive(false);    
        }
        

        if (destroyable.IsBurning)
        {
            isFleeing = true;
        }
        else { isFleeing = false; }

        if (isFleeing)
        {
            canBeStunned = false;
            int randomIndex = Random.Range(0, 3);
            Vector2 direction = fleeingPosList[randomIndex];
            farmerRb.velocity = direction * farmerData.runSpeed;
        }
        else { canBeStunned = true; if (!isFollowing) { farmerRb.velocity = Vector2.zero; } }


        if (isStunned)
        {
            canTurn = false;
            farmerRb.velocity = Vector2.zero;
            if (stunTimerCounter < farmerData.stunDuration)
            {
                stunTimerCounter += Time.deltaTime;
            }
            else
            {
                isStunned = false;
                stunTimerCounter = 0;
                canTurn = true;
            }
        }


        if (isFollowing)
        {
            canTurn = true;
            //animator.CrossFadeInFixedTime(AttackHash, CrossFadeDuration);

            Vector3 direction = new Vector3(player.transform.position.x - transform.position.x, player.transform.position.y- transform.position.y);
            farmerRb.velocity = direction.normalized * farmerData.walkSpeed;
        }
        else { farmerRb.velocity = Vector2.zero; canTurn = false; }

        if (canTurn)
        {
            TurnTowardsPlayer();
        }






    }

    private Vector3 PickFleeingDirection()
    {
        int randomIndex = Random.Range(0, 3);
        return new Vector2(fleeingPosList[randomIndex].x, fleeingPosList[randomIndex].y) ;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isFollowing = true;
            surpriseFX.SetActive(true);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (!isFollowing)
            {
                isFollowing = true;
            }
               
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isFollowing = false;
            surpriseFX.SetActive(false);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            if (canBeStunned)
            {
                isStunned = true;
            }


        }
    }



    public void TurnTowardsPlayer()
    {
        if (player.transform.position.x > gameObject.transform.position.x)
        {
            gameObject.transform.localScale = new Vector3(-1, 1, 1);
        }
        else { gameObject.transform.localScale = new Vector3(1, 1, 1); }
    }
}
