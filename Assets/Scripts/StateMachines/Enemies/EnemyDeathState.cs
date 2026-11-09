using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeathState : EnemyBaseState
{
    private readonly int Death = Animator.StringToHash("Death");

    public EnemyDeathState(EnemyStateMachine stateMachine) : base(stateMachine)
    {
    }

    public override void Enter()
    {
        
        stateMachine.spriteRenderer.color = Color.white;

        //Debug.Log(stateMachine.rb2D);

        stateMachine.Animator.Play("Death");
    }

    public override void Tick(float deltaTime)
    {
        stateMachine.rb2D.velocity = Vector2.zero;
    }

    public override void Exit()
    {
        
    }


}
