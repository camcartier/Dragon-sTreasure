using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDyingState : PlayerBaseState
{

    private readonly int DyingHash = Animator.StringToHash("LVL1_Die");
    private const float CrossFadeDuration = 0.1f;

    private float TimerCounter;

    public PlayerDyingState(PlayerStateMachine stateMachine) : base(stateMachine)
    {
    }

    public override void Enter()
    {
        stateMachine.isDead = true;

        stateMachine.Animator.CrossFadeInFixedTime(DyingHash, CrossFadeDuration);

    }
    public override void Tick(float deltaTime)
    {
        if (!stateMachine.isDead)
        {
            stateMachine.SwitchState(new PlayerMainState(stateMachine));
        }

        if (TimerCounter < stateMachine.Animator.GetCurrentAnimatorStateInfo(0).length)
        {
            TimerCounter += Time.deltaTime;
        }
        else { stateMachine.GameManager.GetComponent<GameManager>().SetActiveDeathPanel() ; stateMachine.GameManager.GetComponent<GameManager>().PauseGame(); }

    }

    public override void Exit()
    {
        Debug.Log("why is it happening");
    }
}
