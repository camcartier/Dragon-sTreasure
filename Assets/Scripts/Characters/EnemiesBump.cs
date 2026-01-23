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
            //rb2d.AddForce(direction * bumpForce);

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

            direction = (collision.transform.position - transform.position).normalized;
            direction *= -1;

            walkTowards.isFollowing = false;
                
        }

        /*
        if (collision.gameObject.CompareTag("Enemies"))
        {
            if (hasBeenBumped == true)
            {
                collision.gameObject.GetComponent<WalkTowards>().isFollowing = false;
            }
            
        }*/
    }


}
