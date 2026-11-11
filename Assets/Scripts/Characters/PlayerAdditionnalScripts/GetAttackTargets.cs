using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetAttackTargets : MonoBehaviour
{
    private Collider2D playerColliderTrigger;
    public List<GameObject> enemiesInReach = new List<GameObject>();
    public PlayerStateMachine playerStateMachine;
    //private EnemyStateMachine enemyStateMachine;



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

            if (collision.GetComponentInParent<EnemyStateMachine>().knockbackDirection == Vector2.zero)
            {
                if (collision.transform.position.x > gameObject.transform.position.x)
                {
                    collision.GetComponentInParent<EnemyStateMachine>().knockbackDirection = Vector2.right;
                }
                else if (collision.transform.position.x < gameObject.transform.position.x)
                {
                    collision.GetComponentInParent<EnemyStateMachine>().knockbackDirection = Vector2.left;
                }

            }
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
