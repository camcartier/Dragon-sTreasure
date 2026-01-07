using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEnterDashState : PlayerBaseState
{
    public PlayerEnterDashState(PlayerStateMachine stateMachine) : base(stateMachine)
    {
    }

    private float ChargeDurationCounter;
    private float ChargeDuration = 0.1f;

    public override void Enter()
    {
        stateMachine.gameObject.GetComponentInChildren<Collider2D>().enabled = false;
        stateMachine.gameObject.GetComponentInChildren<SpriteRenderer>().color = Color.blue;

        stateMachine.rb2D.velocity = Vector2.zero;
            //stateMachine.lastMovementDirection * stateMachine.PlayerData.dashSpeed;


    }
    public override void Tick(float deltaTime)
    {
        if (ChargeDurationCounter < ChargeDuration)
        {
            ChargeDurationCounter += deltaTime;
        }
        else { stateMachine.SwitchState(new PlayerDashingState(stateMachine)); }

    }

    public override void Exit()
    {
        ChargeDurationCounter = 0f;


    }
}





