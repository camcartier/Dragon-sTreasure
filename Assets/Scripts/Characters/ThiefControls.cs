using System.Collections;
using System.Collections.Generic;
using UnityEditor.U2D.Animation;
using UnityEngine;
using UnityEngine.Rendering;

public class ThiefControls : MonoBehaviour
{
    [SerializeField] Rigidbody2D thiefRb;
    [SerializeField] ObjectsData thiefData;
    [SerializeField] PlayerData playerData;
    [SerializeField] TreasureData treasureData;

    private GameObject treasure;
    private GameObject Player;
    private GameObject MinusPanel;

    [Header ("General stats")]
    public int currentGoldCarried;
    public bool isMovingToTreasure;
    public bool isMovingAwayFromTreasure;
    public bool hasStolen;
    public bool isFleeing;

    private float fleeingDuration = 5f;
    private float fleeingTimerCounter;

    [Header ("Disappear after stealing")]
    public float disappearDuration = 1f;
    private float disappearTimerCounter;  

    private bool hasDirection;
    private bool hasFleeingDirection;
    private Vector2 dirToTreasure;
    private Vector2 dirAway;
    private Vector2 dirFromPlayer;
    private Vector2 playerPosAtCollision;

    private SpriteRenderer spriteRenderer;

    void Start()
    {
        treasure = GameObject.Find("Treasure");
        Player = GameObject.Find("Player");
        MinusPanel = GameObject.Find("MinusPanel");

        isMovingToTreasure = true;
        //MinusPanel.SetActive(false);

        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }


    void Update()
    {


        if (hasStolen)
        {
            isMovingToTreasure = false;
            hasDirection = false;
            MinusPanel.SetActive(true);
            //thiefRb.velocity = GetDirectionToTreasure(treasure.transform.position.x*-1, treasure.transform.position.y*-1).normalized * thiefData.walkSpeed;
            
            
            disappearTimerCounter += Time.deltaTime;

            if (disappearTimerCounter > disappearDuration * (treasureData.CurrentStep +1))
            {
                Destroy(gameObject);
            }
        }

        if (isMovingAwayFromTreasure)
        {
            thiefRb.velocity = dirAway.normalized * thiefData.walkSpeed;
        }

        /*
        if (disappearTimerCounter > disappearDuration)
        {
            Destroy(this.gameObject);
        }*/



        if (!hasDirection && !hasStolen)
        {
            dirToTreasure = GetDirectionToTreasure(treasure.transform.position.x, treasure.transform.position.y);
            hasDirection = true;
        }

        if (!hasDirection && hasStolen)
        {
            dirAway = -dirToTreasure;
            hasDirection = true;
            isMovingAwayFromTreasure = true;
        }

       

        if (!isFleeing && !hasStolen)
        {
            isMovingToTreasure = true;
        }
        else { isMovingToTreasure= false; }

        if (isMovingToTreasure)
        {
            thiefRb.velocity = dirToTreasure.normalized * thiefData.walkSpeed;
        }

        if (isFleeing && !hasStolen)
        {
            isMovingToTreasure = false;
            hasDirection = false;
            MoveAwayFromPlayer();
            fleeingTimerCounter += Time.deltaTime;
                
        }
        if(fleeingTimerCounter > fleeingDuration && !hasStolen)
        {
            isFleeing= false;
            isMovingToTreasure = true;
            fleeingTimerCounter= 0;
        }

    }

    void MoveToTreasure()
    {
        Vector2 direction = new Vector2 (treasure.transform.position.x- thiefRb.position.x, treasure.transform.position.y- thiefRb.position.y);
        thiefRb.velocity = new Vector2 (direction.x, direction.y).normalized * thiefData.walkSpeed;
    }

    Vector3 GetDirectionToTreasure(float posX, float posY)
    {
        if (gameObject.transform.position.x- posX > gameObject.transform.position.x)
        {
            return new Vector3(gameObject.transform.position.x - posX, gameObject.transform.position.y - posY, 0);
        }
        else return new Vector3(posX-gameObject.transform.position.x, posY-gameObject.transform.position.y, 0);
    }

    
    void MoveAwayFromPlayer()
    {
        Vector2 direction;
        if (Player.transform.position.x > thiefRb.position.x)
        {
            direction.x =  thiefRb.position.x - Player.transform.position.x;
        }
        else {
            direction.x =  thiefRb.position.x + Player.transform.position.x;
        }
        if (Player.transform.position.y > thiefRb.position.y)
        {
            direction.y = thiefRb.position.y -Player.transform.position.y ;
        }
        else {
            direction.y = thiefRb.position.y +Player.transform.position.y ;
        }
        
        thiefRb.velocity = direction.normalized * thiefData.runSpeed;
        
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {


        if (collision.CompareTag("Treasure"))
        {
            hasStolen = true;
            isFleeing = false;
            spriteRenderer.color = Color.blue;
            Debug.Log("has stolen");
            if (treasureData.GoldCount < 50)
            {
                currentGoldCarried += treasureData.GoldCount;
                treasureData.GoldCount = 0;
            }
            else { currentGoldCarried += 50; treasureData.GoldCount -= 50; }

        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        /*
        if (collision.CompareTag("Player"))
        {
            Debug.Log("not touching anymore");

            //isFleeing = false;
            //playerPosAtCollision= Vector2.zero;
        }
        */


    }

    private void OnCollisionEnter2D(Collision2D collision)
    {


        if (collision.gameObject.CompareTag("Player"))
        {
            isFleeing = true;
            //Debug.Log(collision.transform.position);
        }

        if (collision.gameObject.CompareTag("Bullet"))
        {
            isFleeing = true;
        }
    }


}
