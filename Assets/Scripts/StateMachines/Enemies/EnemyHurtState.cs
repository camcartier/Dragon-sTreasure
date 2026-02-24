using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHurtState : EnemyBaseState
{
    private float hurtTimerCounter;

    public EnemyHurtState(EnemyStateMachine stateMachine) : base(stateMachine)
    {
    }

    public override void Enter()
    {
        //stateMachine.rb2D.velocity = Vector2.zero;
        stateMachine.spriteRenderer.color = Color.red;
        //Debug.Log("hurt");

        
    }
    public override void Tick(float deltaTime)
    {
        if (stateMachine.isDead)
        {
            stateMachine.SwitchState(new EnemyDeathState(stateMachine));
        }

        if (stateMachine.isBurning)
        {
            stateMachine.SwitchState(new EnemyBurningState(stateMachine));
        }


        if (stateMachine.hurtIsReset)
        {
            hurtTimerCounter = 0f; stateMachine.hurtIsReset = false;
        }

        stateMachine.rb2D.velocity = Vector2.zero;

        if (hurtTimerCounter < stateMachine.characterData.hurtTimer)
        {
            hurtTimerCounter += Time.deltaTime;
            
        }
        else { stateMachine.SwitchState(new EnemyMainState(stateMachine)); }


    }

    public override void Exit()
    {
        hurtTimerCounter = 0f;
        stateMachine.isHurt = false;
    }
}
