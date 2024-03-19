using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;

public class BossYakControls : MonoBehaviour
{

    [Header ("Attack fields")]
    private bool isCloseEnough;
    private bool canAttack;
    [SerializeField] float AttackTimer;
    private float AttackTimerCounter;
    private bool canStomp;
    [SerializeField] float StompTimer;
    private float StompTimerCounter;
    private bool IsEnraged;
    [SerializeField] float RestTimer;
    private float RestTimerCounter;
    private bool isResting;
    [SerializeField] float stayInState;
    private float stateTimerCounter;

    [Header("Core")]
    private Rigidbody2D rb2d;
    private SpriteRenderer spriteRenderer;

    [Header ("Data")]
    [SerializeField] GameObject player;
    [Expandable] [SerializeField] ObjectsData bossYakuruData;
    [SerializeField] Destroyable destroyable;

    public Vector3 Direction { get; private set; }

    void Start()
    {
        rb2d= GetComponent<Rigidbody2D>();
        destroyable = GetComponent<Destroyable>();

        spriteRenderer = GetComponentInChildren<SpriteRenderer>();

        if (player == null) { player = GameObject.Find("Player"); }
    }

    void Update()
    {
        if (isResting)
        {
            RestTimerCounter += Time.deltaTime;
            spriteRenderer.color = Color.white;
            if (RestTimerCounter > RestTimer) { isResting = false; RestTimerCounter = 0f; }
        }

        if (destroyable.MyCurrentHealth < bossYakuruData.maxHealth/4)
        {
            IsEnraged= true;
        }

        if (IsEnraged) { spriteRenderer.color= Color.red;
                         AttackTimer = AttackTimer / 2;              
        }


        if (!isCloseEnough)
        {
            Vector3 direction =  TargetVector(player.transform);
            rb2d.velocity = direction.normalized * bossYakuruData.walkSpeed;
            

        }
        else
        {
            if (canStomp && !isResting)
            {
                Stomp();

            }
            
            if (canAttack && !isResting)
            {
                Attack();

            }

        }



        if (!canStomp)
        {
            StompTimerCounter += Time.deltaTime;
            if(StompTimerCounter > StompTimer)
            {
                canStomp= true;
                StompTimerCounter= 0;
            }
        }

        if (!canAttack)
        {
            AttackTimerCounter+= Time.deltaTime;
            if(AttackTimerCounter > AttackTimer)
            {
                canAttack= true;
                AttackTimerCounter= 0;
            }
        }
        

    }



    private Vector3 TargetVector(Transform target)
    {
        if (gameObject.transform.position.x< target.position.x)
        {
            Direction = new Vector3(gameObject.transform.position.x - target.position.x,
                                    gameObject.transform.position.y - target.position.y,
                                    0);
        }
        else
        {
            Direction = new Vector3(target.position.x - gameObject.transform.position.x,
                                    target.position.y - gameObject.transform.position.y,
                                    0);
        }

        return Direction;

    }

    private void Stomp()
    {
        spriteRenderer.color = Color.yellow;
        rb2d.velocity = Vector3.zero;
        //maybe i should do states lol
        //isResting = true;
    }
    private void Attack()
    {
        spriteRenderer.color = Color.blue;
        rb2d.velocity = Vector3.zero;
        //need to stay a bit in attack state to do animation
        //isResting = true;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isCloseEnough= true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isCloseEnough = false;
        }
    }
}
