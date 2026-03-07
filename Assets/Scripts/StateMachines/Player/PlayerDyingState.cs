using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDyingState : PlayerBaseState
{

    private readonly int LVL1_DyingHash = Animator.StringToHash("LVL1_Die");
    private readonly int LVL2_DyingHash = Animator.StringToHash("LVL2_Die");
    private readonly int LVL3_DyingHash = Animator.StringToHash("LVL3_Die");
    private readonly int LVL4_DyingHash = Animator.StringToHash("LVL4_Die");
    private readonly int LVL5_DyingHash = Animator.StringToHash("LVL5_Die");
    private const float CrossFadeDuration = 0.1f;
    private List<int> ListOfDyingHash = new List<int>();

    private float TimerCounter;

    public PlayerDyingState(PlayerStateMachine stateMachine) : base(stateMachine)
    {
    }

    public override void Enter()
    {
        ListOfDyingHash.Add(LVL1_DyingHash);
        ListOfDyingHash.Add(LVL2_DyingHash);
        ListOfDyingHash.Add(LVL3_DyingHash);
        ListOfDyingHash.Add(LVL4_DyingHash);
        ListOfDyingHash.Add(LVL5_DyingHash);



        stateMachine.isDead = true;

        stateMachine.Animator.CrossFadeInFixedTime(ListOfDyingHash[stateMachine.currentLevelStored], CrossFadeDuration);

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
