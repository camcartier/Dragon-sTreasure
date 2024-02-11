using System.Collections;
using System.Collections.Generic;
using UnityEditor.U2D.Animation;
using UnityEngine;

public class ThiefControls : MonoBehaviour
{
    [SerializeField] Rigidbody2D thiefRb;
    [SerializeField] CharacterData thiefData;

    private GameObject treasure;

    //public float speed;
    //public int health;
    

    // Start is called before the first frame update
    void Start()
    {
        treasure = GameObject.Find("Treasure");
        MoveToTreasure();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void MoveToTreasure()
    {
        Vector2 direction = new Vector2 (treasure.transform.position.x- thiefRb.position.x, treasure.transform.position.y- thiefRb.position.y);
        thiefRb.velocity = new Vector2 (direction.x, direction.y);
    }

    void GetDirection()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Gold"))
        {
            Destroy(collision.gameObject);
        }
    }
}
