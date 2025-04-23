using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDyingState : PlayerBaseState
{


    public PlayerDyingState(PlayerStateMachine stateMachine) : base(stateMachine)
    {
    }

    public override void Enter()
    {
        Debug.Log("Am dead");


    }
    public override void Tick(float deltaTime)
    {
        //stateMachine.InputReader.enabled = false;
    }

    public override void Exit()
    {
        Debug.Log("why is it happening");
    }
}
