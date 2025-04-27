using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FarmerControls : MonoBehaviour
{
    [Header("Setup")]
    [SerializeField] ObjectsData farmerData;
    [SerializeField] List<Transform> fleeingPosList;
    [SerializeField] GameObject player;
    [SerializeField] GameObject healthCanvas;

    private Destroyable destroyable;
    private Rigidbody2D farmerRb;

    private SpriteRenderer spriteRenderer;

    public bool isFollowing { get; private set;}
    public bool canBeStunned { get; private set;}
    public bool isStunned { get; private set; }
    private float stunTimerCounter;

    private float turnDelayCounter;

    void Start()
    {
        player = GameObject.Find("Player");

        farmerRb = GetComponent<Rigidbody2D>();
        destroyable = GetComponent<Destroyable>();

        spriteRenderer= GetComponentInChildren<SpriteRenderer>();

        canBeStunned= true;
    }


    void Update()
    {
        if (destroyable.IsBurning)
        {
            spriteRenderer.color = Color.red;
            isFollowing= false;
            canBeStunned= false;
        }

        if (isFollowing)
        {
            Vector3 direction = new Vector3(player.transform.position.x - transform.position.x, player.transform.position.y- transform.position.y);
            farmerRb.velocity = direction.normalized * farmerData.walkSpeed;
        }

        if (canBeStunned)
        {
            if (isStunned)
            {
                farmerRb.velocity = Vector2.zero;
                if (stunTimerCounter < farmerData.stunDuration)
                {
                    stunTimerCounter += Time.deltaTime;
                }
                else
                {
                    isStunned = false;
                    stunTimerCounter = 0;
                }
            }
        }

        if (player.transform.position.x > gameObject.transform.position.x) 
        {
            if (turnDelayCounter < farmerData.timeBeforeTurn)
            {
                turnDelayCounter += Time.deltaTime;
            }
            else { gameObject.transform.localScale = new Vector3(-1, 1, 1); turnDelayCounter = 0f; healthCanvas.transform.localScale = new Vector3(-1, 1, 1); }
        }
        if (player.transform.position.x < gameObject.transform.position.x)
        {
            if (turnDelayCounter < farmerData.timeBeforeTurn)
            {
                turnDelayCounter += Time.deltaTime;
            }
            else { gameObject.transform.localScale = new Vector3(1, 1, 1); turnDelayCounter = 0f; healthCanvas.transform.localScale = new Vector3(1, 1, 1); }
        }





    }

    private Vector3 PickFleeingDirection()
    {
        int randomIndex = Random.Range(0, 3);
        return new Vector3(fleeingPosList[randomIndex].transform.position.x, fleeingPosList[randomIndex].transform.position.y, 0) ;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isFollowing = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isFollowing = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            isStunned= true;
        }
    }
}
