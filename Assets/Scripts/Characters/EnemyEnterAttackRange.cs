using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyEnterAttackRange : MonoBehaviour
{
    //public WalkTowards WalkTowards;
    public EnemyStateMachine enemyStateMachine;
    private PlayerStateMachine playerStateMachine;

    private void Start()
    {
        playerStateMachine = GameObject.Find("Player").GetComponent<PlayerStateMachine>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            enemyStateMachine.isAttacking = true;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            //transition attaque vers attaque
             enemyStateMachine.stillAttacking = true;

            if (enemyStateMachine.isHitting)
            {
                if (!enemyStateMachine.hasHit)
                {
                    playerStateMachine.isHurt = true;
                    enemyStateMachine.hasHit = true;

                    if (playerStateMachine.knockbackDirection == Vector2.zero)
                    {
                        if (collision.transform.position.x > gameObject.transform.position.x)
                        {
                            playerStateMachine.knockbackDirection = new Vector2(collision.transform.position.x - gameObject.transform.position.x,
                                                                                                    0);
                        }
                        else
                        {
                            playerStateMachine.knockbackDirection = new Vector2(gameObject.transform.position.x - collision.transform.position.x,
                                                                                                     0);
                        }

                    }
                }
                
            }
        }

        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            enemyStateMachine.stillAttacking = false;
        }
    }
}
