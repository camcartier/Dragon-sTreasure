using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesBump : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb2d;

    public float bumpForce;
    public Vector2 direction;

    [SerializeField] WalkTowards walkTowards;

    public float timeForBump;
    public float storedTimeForBump;
    private float timerCouterBump;

    public bool hasBeenBumped;

    private void Update()
    {
        if (walkTowards.isFollowing == false)
        {
            rb2d.velocity = Vector2.zero;
            rb2d.AddForce(direction * bumpForce, ForceMode2D.Impulse );


        }

        if (timerCouterBump < timeForBump)
        {
            timerCouterBump += Time.deltaTime;
        }
        else
        {
            walkTowards.isFollowing = true;
            hasBeenBumped = false;
            timerCouterBump = 0f;
        }

    }



    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            Debug.Log("bump should happen");

            hasBeenBumped = true;
            if (collision.transform.position.x > gameObject.transform.position.x)
            {
                if (collision.transform.position.y > gameObject.transform.position.y)
                {
                    
                    direction = new Vector2(gameObject.transform.position.x - collision.transform.position.x, gameObject.transform.position.y - collision.transform.position.y).normalized;
                }

                else { direction = new Vector2(gameObject.transform.position.x - collision.transform.position.x, collision.transform.position.y - gameObject.transform.position.y).normalized; }

            }
            else
            {
                direction = new Vector2(collision.transform.position.x - gameObject.transform.position.x, gameObject.transform.position.y - collision.transform.position.y).normalized;
            }

            walkTowards.isFollowing = false;
                //rb2d.AddForce(direction * bumpForce, ForceMode2D.Impulse);
        }

        if (collision.gameObject.CompareTag("Enemies"))
        {
            if (hasBeenBumped == true)
            {
                collision.gameObject.GetComponent<WalkTowards>().isFollowing = false;
            }
            
        }
    }


}
