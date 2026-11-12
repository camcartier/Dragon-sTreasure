using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDyingState : PlayerBaseState
{


    private const float CrossFadeDuration = 0.1f;
    private List<int> ListOfDyingHash = new List<int>();

    private float TimerCounter;

    private readonly int NBase_Death = Animator.StringToHash("NBase_Death");

    public PlayerDyingState(PlayerStateMachine stateMachine) : base(stateMachine)
    {
    }

    public override void Enter()
    {

        stateMachine.PlayerCoroutinesScript.StopAllCoroutines();
        stateMachine.flappingSound.Stop();
        stateMachine.MainSpriteRenderer.color = Color.white;    

        foreach (Collider2D coll in stateMachine.Colliders)
        {
            coll.enabled = false;
        }


        stateMachine.isDead = true;

        //stateMachine.Animator.CrossFadeInFixedTime(ListOfDyingHash[stateMachine.currentLevelStored], CrossFadeDuration);

        stateMachine.Animator.Play(NBase_Death);
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

        foreach (Collider2D coll in stateMachine.Colliders)
        {
            coll.enabled = true;
        }


    }
}
