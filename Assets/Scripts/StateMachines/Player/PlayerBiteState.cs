using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBiteState : PlayerBaseState
{
    private float BiteTimer = 0.5f;
    private float BiteTimerCounter;

    private float ImpulseForce = 50f;

    private readonly int NBase_Bite = Animator.StringToHash("NBase_Bite");


    public PlayerBiteState(PlayerStateMachine stateMachine) : base(stateMachine)
    {
    }

    public override void Enter()
    {
        BiteTimerCounter = 0f;
        stateMachine.rb2D.velocity = Vector3.zero;

        if (stateMachine.gameObject.transform.rotation.y < 0)
        {
            stateMachine.rb2D.AddForce(Vector2.left * ImpulseForce, ForceMode2D.Impulse);
        }
        else
        {
            stateMachine.rb2D.AddForce(Vector2.right * ImpulseForce, ForceMode2D.Impulse);
        }
         

        stateMachine.Animator.Play(NBase_Bite);
        


    }

    public override void Exit()
    {
        
    }

    public override void Tick(float deltaTime)
    {
        BiteTimerCounter += Time.deltaTime;

        if (BiteTimerCounter > BiteTimer)
        {
            stateMachine.SwitchState(new PlayerMainState(stateMachine));
        }


    }


}
