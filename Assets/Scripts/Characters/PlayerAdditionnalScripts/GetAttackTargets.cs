using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetAttackTargets : MonoBehaviour
{
    private Collider2D playerColliderTrigger;
    public List<GameObject> enemiesInReach = new List<GameObject>();
    public PlayerStateMachine playerStateMachine;
    //private EnemyStateMachine enemyStateMachine;

    public event Action HasBeenHit;
    public bool hasAlreadBeenHit;

    void Update()
    {
        enemiesInReach.RemoveAll(enemy => enemy == null);
        //Debug.Log(enemiesInReach.Count);

        if (playerStateMachine.isAttacking)
        {
            foreach (GameObject gameObject in enemiesInReach)
            {
                if (gameObject == null)
                    continue;

                EnemyStateMachine enemyStateMachine = gameObject.GetComponentInParent<EnemyStateMachine>();
                if (enemyStateMachine != null)
                {


                    HasBeenHit?.Invoke();
                    enemyStateMachine.isHit = true;
                    


                    if (playerStateMachine.isBiting)
                    {
                        enemyStateMachine.pendingDamage = playerStateMachine.PlayerData.biteDamage;
                    }
                    if (playerStateMachine.isHeadbutt)
                    {
                        enemyStateMachine.pendingDamage = playerStateMachine.PlayerData.headbuttDamage;
                    }

                }


                
            }
        } 
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemies"))
        {
            enemiesInReach.Add(collision.gameObject);


            Vector2 direction = (collision.transform.position - transform.position).normalized;
            collision.GetComponentInParent<EnemyStateMachine>().pendingKnockback = direction * playerStateMachine.PlayerData.knockbackAmount;

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemies"))
        {
            enemiesInReach.Remove(collision.gameObject);
        }
    }
}
