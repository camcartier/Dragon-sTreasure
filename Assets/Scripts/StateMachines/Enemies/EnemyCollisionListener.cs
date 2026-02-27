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
    }

    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
             gameObject.GetComponent<EnemyStateMachine>().isInAttackState = true;
             collisionsList.Add(collision.gameObject);
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
