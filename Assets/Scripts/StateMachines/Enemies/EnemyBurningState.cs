using System.Collections;
using System.Collections.Generic;
using UnityEditor.U2D.Animation;
using UnityEngine;

public class EnemyBurningState : EnemyBaseState
{
    private float burningTimerCounter;

    public EnemyBurningState(EnemyStateMachine stateMachine) : base(stateMachine)
    {
    }

    public override void Enter()
    {
        stateMachine.spriteRenderer.color = Color.yellow;
    }
    public override void Tick(float deltaTime)
    {
        if (burningTimerCounter < stateMachine.characterData.burningTimer) 
        {
            burningTimerCounter+= Time.deltaTime;
        }
        else 
        {
            stateMachine.SwitchState(new EnemyMainState(stateMachine));
        }
    }

    public override void Exit()
    {
        Debug.Log("stopped burning");
    }




}
