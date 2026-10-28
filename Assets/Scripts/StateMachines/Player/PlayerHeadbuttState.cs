using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Cinemachine.CinemachineFreeLook;

public class PlayerHeadbuttState : PlayerBaseState
{
    private float HeadbuttTimer = 0.5f;
    private float HeadbuttTimerCounter = 0f;

    private float ImpulseForce = 50f;

    private bool isBiting;

    private readonly int NBase_Headbutt = Animator.StringToHash("NBase_Headbutt");

    public PlayerHeadbuttState(PlayerStateMachine stateMachine) : base(stateMachine)
    {
    }

    public override void Enter()
    {
        //Debug.Log("am heabutting");

        isBiting = false;
        HeadbuttTimerCounter = 0f;
        stateMachine.InputReader.BiteEvent += OnBite;


        stateMachine.rb2D.velocity = Vector3.zero;

        //float direction = Mathf.Sign(stateMachine.transform.localScale.x);
        if (stateMachine.gameObject.transform.rotation.y < 0)
        {
            stateMachine.rb2D.AddForce(Vector2.left  * ImpulseForce, ForceMode2D.Impulse);
        }
        else
        {
            stateMachine.rb2D.AddForce(Vector2.right  * ImpulseForce, ForceMode2D.Impulse);
        }
            

        stateMachine.Animator.Play(NBase_Headbutt);
    }

    public override void Exit()
    {
        stateMachine.InputReader.BiteEvent -= OnBite;

        HeadbuttTimerCounter = 0f;
        
        isBiting = false;
    }

    public override void Tick(float deltaTime)
    {
        HeadbuttTimerCounter += Time.deltaTime;

        if (HeadbuttTimerCounter >= HeadbuttTimer)
        {
            if (isBiting) { stateMachine.SwitchState(new PlayerBiteState(stateMachine)); }

            else { stateMachine.SwitchState(new PlayerMainState(stateMachine)); }
        }
       
    }

    private void OnBite()
    {   
        isBiting = true;
    }



}
