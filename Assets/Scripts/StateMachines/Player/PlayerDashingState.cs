using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDashingState : PlayerBaseState
{
    private float dashDurationCounter;
    public PlayerDashingState(PlayerStateMachine stateMachine) : base(stateMachine)
    {
    }

    public override void Enter()
    {
        Debug.Log("i am dashing");
        stateMachine.gameObject.GetComponentInChildren<Collider2D>().enabled = false;
        stateMachine.gameObject.GetComponentInChildren<SpriteRenderer>().color = Color.blue;

        stateMachine.rb2D.velocity = stateMachine.lastMovementDirection * stateMachine.PlayerData.dashSpeed * Time.deltaTime;

    }
    public override void Tick(float deltaTime)
    {
        if (dashDurationCounter < stateMachine.dashDuration)
        { 
            dashDurationCounter += deltaTime;
        }
        else { stateMachine.SwitchState(new PlayerMainState(stateMachine)); }

    }

    public override void Exit()
    {
        dashDurationCounter = 0f;
        stateMachine.gameObject.GetComponentInChildren<Collider2D>().enabled = true;
        stateMachine.gameObject.GetComponentInChildren<SpriteRenderer>().color = Color.white;
        stateMachine.PlayerData.canDash = false;
        
    }
}
