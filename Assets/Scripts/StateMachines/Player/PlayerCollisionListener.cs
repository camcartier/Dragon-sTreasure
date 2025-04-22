using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisionListener : MonoBehaviour
{

    private PlayerStateMachine stateMachine;
    public Vector2 knockbackDirection { get; private set; }

    private void Awake()
    {
        stateMachine = GetComponent<PlayerStateMachine>();
    }

    void Start()
    {

    }

    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("collided");

        
        if (collision.collider.gameObject.GetComponentInChildren<CanDamage>() != null)
        {
            knockbackDirection = new Vector2(gameObject.transform.position.x - collision.collider.transform.position.x, gameObject.transform.position.y - collision.collider.transform.position.y);
            
            stateMachine.knockbackDirection = knockbackDirection;

            stateMachine.SwitchState(new PlayerHurtState(stateMachine));
        }
        else
        {
            Debug.Log("not found");
        }
        
    }



}
