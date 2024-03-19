using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHurtState : PlayerBaseState
{

    private float knockbackDurationCounter;
    private Vector2 normalizedDirection;

    //also knockback state
    public PlayerHurtState(PlayerStateMachine stateMachine) : base(stateMachine)
    {
    }

    public override void Enter()
    {
        stateMachine.isStunnable = false;

        Debug.Log("I am hurt");
        stateMachine.gameObject.GetComponentInChildren<SpriteRenderer>().color = Color.red;

        //stateMachine.rb2D.velocity = Vector3.zero;
        //normalizedDirection = new Vector2(stateMachine.knockbackDirection.x, stateMachine.knockbackDirection.y);
        stateMachine.rb2D.AddForce(new Vector2(stateMachine.knockbackDirection.x, stateMachine.knockbackDirection.y)*stateMachine.knockbackForce) ;
        
    }
    public override void Tick(float deltaTime)
    {
        if (knockbackDurationCounter < stateMachine.knockBackDuration)
        {
            knockbackDurationCounter++;
        }
        else
        {
            stateMachine.SwitchState(new PlayerMainState(stateMachine));
        }
    }

    public override void Exit()
    {
        stateMachine.gameObject.GetComponentInChildren<SpriteRenderer>().color = Color.white;

        knockbackDurationCounter = 0f;
    }





}
