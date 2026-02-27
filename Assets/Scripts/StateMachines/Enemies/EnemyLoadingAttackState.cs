using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLoadingAttackState : EnemyBaseState
{
    private float loadingTimerCounter;

    public EnemyLoadingAttackState(EnemyStateMachine stateMachine) : base(stateMachine)
    {
    }

    public override void Enter()
    {
        stateMachine.spriteRenderer.color = Color.blue;
    }

    public override void Tick(float deltaTime)
    {
        stateMachine.rb2D.velocity = Vector2.zero;

        if (loadingTimerCounter > stateMachine.characterData.loadAttackTimer)
        {
            stateMachine.SwitchState(new EnemyAttackState(stateMachine));
        }
        else { loadingTimerCounter += Time.deltaTime;  }

    }

    public override void Exit()
    {
        loadingTimerCounter = 0f;

        stateMachine.isAttacking = true;
    }


}
