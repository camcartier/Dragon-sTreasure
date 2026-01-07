using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStartGameState : PlayerBaseState
{
    private readonly int StartingHash = Animator.StringToHash("WakingUp");
    private const float CrossFadeDuration = 0.1f;

    private float TimerCounter;

    public PlayerStartGameState(PlayerStateMachine stateMachine) : base(stateMachine)
    {
    }


    public override void Enter()
    {
        stateMachine.Animator.Play("WakingUp");
        stateMachine.canDash = true;

        //Debug.Log(stateMachine.Animator.GetCurrentAnimatorStateInfo(0).length);
    }
    public override void Tick(float deltaTime)
    {

        if (TimerCounter < stateMachine.Animator.GetCurrentAnimatorStateInfo(0).length)
        {
            TimerCounter += Time.deltaTime;
        }
        else { stateMachine.SwitchState(new PlayerMainState(stateMachine)); }

    }
    public override void Exit()
    {
        stateMachine.StartingTextPanel.SetActive(true);
    }

}
