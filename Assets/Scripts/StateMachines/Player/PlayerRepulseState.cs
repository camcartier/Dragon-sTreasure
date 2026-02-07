using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRepulseState : PlayerBaseState
{
    private float repulseTimer = 1.5f;
    private float repulseTimerCounter;

    public PlayerRepulseState(PlayerStateMachine stateMachine) : base(stateMachine)
    {
    }

    public override void Enter()
    { 
        stateMachine.canRepulse = false;
        
        stateMachine.rb2D.velocity = Vector3.zero;
        stateMachine.gameObject.GetComponentInChildren<SpriteRenderer>().color = Color.green;

        Debug.Log("enter repulse state");
    }
    public override void Tick(float deltaTime)
    {
        repulseTimerCounter += Time.deltaTime;
        Debug.Log(repulseTimerCounter);

        if (repulseTimerCounter > repulseTimer)
        {
            stateMachine.SwitchState(new PlayerMainState(stateMachine));
        }
    }
    
    public override void Exit()
    {
        stateMachine.canRepulse = false;

        repulseTimerCounter = 0f;
        stateMachine.gameObject.GetComponentInChildren<SpriteRenderer>().color = Color.white;
    }



}
