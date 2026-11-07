using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyEnterAttackRange : MonoBehaviour
{
    //public WalkTowards WalkTowards;
    public EnemyStateMachine enemyStateMachine;


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
             enemyStateMachine.stillAttacking = true;
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
