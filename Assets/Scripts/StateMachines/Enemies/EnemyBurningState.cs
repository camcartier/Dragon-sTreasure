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
        Debug.Log("burning");
    }
    public override void Tick(float deltaTime)
    {
        stateMachine.rb2D.velocity = Vector2.zero ;

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

        stateMachine.hasAlreadyBurnt = true;
        Debug.Log("stopped burning");
    }




}
