using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHurtState : PlayerBaseState
{

    private float knockbackDurationCounter;
    private float stunDurationCounter;
    private Vector2 normalizedDirection;

    private PlayerCollisionListener collisionListener;

    //also knockback state
    public PlayerHurtState(PlayerStateMachine stateMachine) : base(stateMachine)
    {
    }

    public override void Enter()
    {
        stateMachine.isStunnable = false;

        stateMachine.gameObject.GetComponentInChildren<SpriteRenderer>().color = Color.red;

        stateMachine.rb2D.velocity = Vector3.zero;
        
        stateMachine.rb2D.AddForce(new Vector2(stateMachine.knockbackDirection.x, stateMachine.knockbackDirection.y).normalized*stateMachine.knockbackForce) ;
        //direction comes from Player Collision Listener
    }
    public override void Tick(float deltaTime)
    {
        if (knockbackDurationCounter < stateMachine.knockBackDuration)
        {
            knockbackDurationCounter++;
        }
        else
        {
            stateMachine.rb2D.velocity = Vector3.zero;
        }

        if (stunDurationCounter < stateMachine.stunDuration)
        {
            stunDurationCounter++;
        }
        else if (stateMachine.PlayerCurrentHealthAndMana.currentHealth > 0)
        {
            stateMachine.SwitchState(new PlayerMainState(stateMachine));

        }
        else { stateMachine.SwitchState(new PlayerDyingState(stateMachine)); }
    }

    public override void Exit()
    {
        stateMachine.gameObject.GetComponentInChildren<SpriteRenderer>().color = Color.white;

        knockbackDurationCounter = 0f;
    }





}
