using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetAttackTargets : MonoBehaviour
{
    private Collider2D playerColliderTrigger;
    public List<GameObject> enemiesInReach = new List<GameObject>();
    public PlayerStateMachine playerStateMachine;


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
                    enemyStateMachine.isHit = true;
                }


                
            }
        } 
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemies"))
        {
            enemiesInReach.Add(collision.gameObject);
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
