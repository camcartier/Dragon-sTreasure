using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnState : EnemyBaseState
{
    private float waitTimeAtSpawn = 2f;
    private float waitTimeCounter;

    public EnemySpawnState(EnemyStateMachine stateMachine) : base(stateMachine)
    {
    }
    public override void Enter()
    {
        stateMachine.spriteRenderer.color = Color.black;
        Debug.Log("spawn");
    }

    public override void Tick(float deltaTime)
    {
        if (waitTimeCounter < waitTimeAtSpawn) 
        {
            waitTimeCounter += Time.deltaTime;
        }
        else
        {
            stateMachine.SwitchState(new EnemyMainState(stateMachine));
        }

    }

    public override void Exit()
    {
        waitTimeCounter = 0f;
    }

}
