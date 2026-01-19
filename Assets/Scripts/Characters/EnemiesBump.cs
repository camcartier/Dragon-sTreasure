using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesBump : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb2d;

    public float bumpForce;
    public Vector2 direction;

    [SerializeField] WalkTowards walkTowards;
   

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            Debug.Log("bump should happen");
            
            
            if(collision.transform.position.x > gameObject.transform.position.x)
            {
                if (collision.transform.position.y > gameObject.transform.position.y)
                {
                    
                    direction = new Vector2(gameObject.transform.position.x - collision.transform.position.x, gameObject.transform.position.y - collision.transform.position.y);
                }

                else { direction = new Vector2(gameObject.transform.position.x - collision.transform.position.x, collision.transform.position.y - gameObject.transform.position.y); }

            }
            else
            {
                direction = new Vector2(collision.transform.position.x - gameObject.transform.position.x, gameObject.transform.position.y - collision.transform.position.y);
            }

                rb2d.AddForce(direction * bumpForce);
        }
    }



}
