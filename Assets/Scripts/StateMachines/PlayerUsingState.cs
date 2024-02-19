using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class PlayerUsingState : PlayerBaseState
{
    private readonly int UseHash = Animator.StringToHash("LVL1_Dig");
    private const float CrossFadeDuration = 0.1f;

    private float TimerCounter;

    public PlayerUsingState(PlayerStateMachine stateMachine) : base(stateMachine) { }

    public override void Enter()
    {
        TimerCounter  = 0f;
        stateMachine.rb2D.velocity = Vector2.zero;

        stateMachine.Animator.CrossFadeInFixedTime(UseHash, CrossFadeDuration);
    }

    public override void Tick(float deltaTime)
    {
        
        if (TimerCounter < stateMachine.Animator.GetCurrentAnimatorStateInfo(0).length)
        {
            Debug.Log("I am digging");
            TimerCounter += Time.deltaTime;
        }
        else { stateMachine.SwitchState(new PlayerMainState(stateMachine));  }
    }

    public override void Exit()
    {
        TimerCounter = 0f;
        Debug.Log("I stopped digging");
    }



}
