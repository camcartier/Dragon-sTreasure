using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyCollisionListener : MonoBehaviour
{
    private List<GameObject> collisionsList = new List<GameObject>();
    private GameObject Player;

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if(gameObject.GetComponentInParent<EnemyStateMachine>().isAttacking && collisionsList.Count > 0 && !Player.GetComponent<PlayerStateMachine>().isInvulnerable)
        {
            Player.GetComponent<PlayerStateMachine>().isHurt = true;

            //need to implement isInvulnerable
        }

        /*
        if (Player.GetComponent<PlayerStateMachine>().knockbackDirection != Vector2.zero)
        {
            Debug.Log("not 0");
        }*/
    }

    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
             gameObject.GetComponent<EnemyStateMachine>().isInAttackState = true;
             collisionsList.Add(collision.gameObject);

            if (Player.GetComponent<PlayerStateMachine>().knockbackDirection == Vector2.zero)
            {
                if (collision.transform.position.x > gameObject.transform.position.x)
                {
                    Player.GetComponent<PlayerStateMachine>().knockbackDirection = new Vector2(collision.transform.position.x - gameObject.transform.position.x,
                                                                                            0);
                }
                else
                {
                    Player.GetComponent<PlayerStateMachine>().knockbackDirection = new Vector2( gameObject.transform.position.x - collision.transform.position.x,
                                                                                             0);
                }
                
            }
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            gameObject.GetComponent<EnemyStateMachine>().isInAttackState = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            gameObject.GetComponent<EnemyStateMachine>().isInAttackState = false;
            collisionsList.Remove(collision.gameObject);
        }
    }
}
