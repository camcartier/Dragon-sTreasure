using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CanKnockback : MonoBehaviour
{
    private GameObject player;

    void Start()
    {
        player = GameObject.Find("Player");
    }

    /*
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerStateMachine>())
        {
            if (!collision.gameObject.GetComponent<PlayerStateMachine>().isStunnable == true)
            {
                return;

            }
            else 
            { 
                collision.gameObject.GetComponent<PlayerStateMachine>().SwitchState(new PlayerHurtState(collision.gameObject.GetComponent<PlayerStateMachine>()));

                if (collision.gameObject.transform.rotation.y > 0)
                {
                    collision.gameObject.GetComponent<PlayerStateMachine>().knockbackDirection = new Vector2(player.transform.position.x - collision.otherRigidbody.gameObject.transform.position.x, player.transform.position.y - collision.otherRigidbody.gameObject.transform.position.y).normalized;
                    
                }
                else
                {
                    collision.gameObject.GetComponent<PlayerStateMachine>().knockbackDirection = new Vector2(collision.otherRigidbody.gameObject.transform.position.x - player.transform.position.x, collision.otherRigidbody.gameObject.transform.position.y - player.transform.position.y).normalized;
                }
                
                    
            }
        }
    }
    */

}
