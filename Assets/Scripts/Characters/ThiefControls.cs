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


    void Start()
    {
        treasure = GameObject.Find("Treasure");

    }


    void Update()
    {

        if (!isFleeing || hasStolen)
        {
            isMovingToTreasure = true;
        }
    }

    void MoveToTreasure()
    {
        Vector2 direction = new Vector2 (treasure.transform.position.x- thiefRb.position.x, treasure.transform.position.y- thiefRb.position.y);
        thiefRb.velocity = new Vector2 (direction.x, direction.y).normalized * thiefData.walkSpeed * Time.deltaTime;
    }

    void GetDirection()
    {

    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isFleeing = true;
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
