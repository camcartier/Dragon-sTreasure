using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeathState : EnemyBaseState
{
    public EnemyDeathState(EnemyStateMachine stateMachine) : base(stateMachine)
    {
    }

    public override void Enter()
    {
        
        stateMachine.spriteRenderer.color = Color.black;

        Debug.Log(stateMachine.rb2D);
    }

    public override void Tick(float deltaTime)
    {
        stateMachine.rb2D.velocity = Vector2.zero;
    }

    public override void Exit()
    {
        
    }


}
