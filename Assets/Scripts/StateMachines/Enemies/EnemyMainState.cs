using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMainState : EnemyBaseState
{
    private GameObject toFollow;

    private float directionX;
    private float directionY;

    private bool isTurning;

    public EnemyMainState(EnemyStateMachine stateMachine) : base(stateMachine)
    {
    }

    public override void Enter()
    {
        stateMachine.spriteRenderer.color = Color.white;
        Debug.Log("main");

        toFollow = GameObject.Find("Player");
    }
    public override void Tick(float deltaTime)
    {
        if (stateMachine.isHurt)
        {
            stateMachine.SwitchState(new EnemyHurtState(stateMachine));
        }


        if (Mathf.Sign(stateMachine.gameObject.transform.position.x - toFollow.transform.position.x) > 0) { directionX = -1; }
        else { directionX = 1; }
        if (Mathf.Sign(stateMachine.gameObject.transform.position.y - toFollow.transform.position.y) > 0) { directionY = -1; }
        else { directionY = 1; }


        stateMachine.rb2D.velocity = new Vector2(directionX, directionY) * stateMachine.characterData.walkSpeed;


        if (Mathf.Abs(toFollow.transform.position.x - stateMachine.gameObject.transform.position.x) <= 0.5f)
        {
            isTurning = false;
        }
        else { isTurning = true; }


        //Turning the prefab
        if (isTurning)
        {
            if (toFollow.transform.position.x > stateMachine.transform.position.x)
            {
                stateMachine.gameObject.transform.localScale = new Vector3(-1, 1, 1);
            }
            else
            {
                stateMachine.gameObject.transform.localScale = new Vector3(1, 1, 1);
            }
        }
    }

    public override void Exit()
    {
        
    }




}
