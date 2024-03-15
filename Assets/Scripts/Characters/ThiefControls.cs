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

    public int currentGoldCarried;
    public bool isMovingToTreasure;
    public bool hasStolen;
    public bool isFleeing;

    private bool hasDirection;
    private Vector2 dirToTreasure;
    private Vector2 dirAway;
    private Vector2 dirFromPlayer;

    private SpriteRenderer spriteRenderer;

    void Start()
    {
        treasure = GameObject.Find("Treasure");
        isMovingToTreasure = true;

        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }


    void Update()
    {


        if (!hasDirection)
        {
            dirToTreasure = GetDirection(treasure.transform.position.x, treasure.transform.position.y);
        }

        //Vector3 direction = GetDirection(treasure.transform.position.x, treasure.transform.position.y);

        if (!isFleeing || hasStolen)
        {
            isMovingToTreasure = true;
        }
        else { isMovingToTreasure= false; }

        if (isMovingToTreasure)
        {
            thiefRb.velocity = dirToTreasure.normalized * thiefData.walkSpeed * Time.deltaTime;
        }
    }

    void MoveToTreasure()
    {
        Vector2 direction = new Vector2 (treasure.transform.position.x- thiefRb.position.x, treasure.transform.position.y- thiefRb.position.y);
        thiefRb.velocity = new Vector2 (direction.x, direction.y).normalized * thiefData.walkSpeed * Time.deltaTime;
    }

    Vector3 GetDirection(float posX, float posY)
    {
        if (gameObject.transform.position.x- posX > gameObject.transform.position.x)
        {
            return new Vector3(gameObject.transform.position.x - posX, gameObject.transform.position.y - posY, 0);
        }
        else return new Vector3(posX-gameObject.transform.position.x, posY-gameObject.transform.position.y, 0);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") || collision.CompareTag("Bullet"))
        {
            isFleeing = true;
        }

        if (collision.CompareTag("Treasure"))
        {
            spriteRenderer.color = Color.grey;
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isFleeing = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Treasure"))
        {
            hasStolen= true;
            if (treasureData.GoldCount < 50)
            {
                currentGoldCarried += treasureData.GoldCount;
            }
            else { currentGoldCarried += 50; }
            
        }
    }


}
