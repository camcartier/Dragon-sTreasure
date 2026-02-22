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


        stateMachine.rb2D.velocity = Vector2.zero;

        if (hurtTimerCounter < stateMachine.characterData.hurtTimer && stateMachine.destroyableInfo.MyCurrentHealth > 0)
        {
            hurtTimerCounter += Time.deltaTime;
            
        }
        else { stateMachine.SwitchState(new EnemyMainState(stateMachine)); }

        /*
        else if (hurtTimerCounter < stateMachine.characterData.hurtTimer && stateMachine.destroyableInfo.MyCurrentHealth <= 0)
        {
            stateMachine.SwitchState(new EnemyDeathState(stateMachine));
        }*/
    }

    public override void Exit()
    {
        hurtTimerCounter = 0f;
        stateMachine.isHurt = false;
    }
}
