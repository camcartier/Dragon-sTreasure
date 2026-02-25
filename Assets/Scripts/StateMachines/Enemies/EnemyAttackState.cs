using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackState : EnemyBaseState
{
    private float attackTimerCounter;

    private float timebeforechangeState = 2f;
    private float timebeforechangeStateCounter;

    //turning the prefab
    private bool isTurning;
    private GameObject toFollow;

    public EnemyAttackState(EnemyStateMachine stateMachine) : base(stateMachine)
    {
    }

    public override void Enter()
    {
        stateMachine.rb2D.velocity = Vector2.zero;


        //turning the prefab
        toFollow = GameObject.Find("Player");

    }
    public override void Tick(float deltaTime)
    {
        if (stateMachine.isHurt)
        {
            stateMachine.SwitchState(new EnemyHurtState(stateMachine));
        }
        
        if (stateMachine.isDead)
        {
            stateMachine.SwitchState(new EnemyDeathState(stateMachine));
        }


        stateMachine.rb2D.velocity = Vector2.zero;

        timebeforechangeStateCounter += Time.deltaTime;


        //ENEMY ID 3
        if (stateMachine.enemyID.IDNumber == 3 && !stateMachine.hasInstantiated)
        {

            //Turning the prefab
            isTurning = true;
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
            stateMachine.instantiateStuff.InstantiateProjectile();
            stateMachine.hasInstantiated = true;
            timebeforechangeStateCounter = 0f;






        }

        if (attackTimerCounter < stateMachine.attackTimer)
        {
            attackTimerCounter += Time.deltaTime;
        }
        else { stateMachine.hasInstantiated = false; attackTimerCounter = 0f;}



        if (!stateMachine.isAtttacking && timebeforechangeStateCounter > timebeforechangeState)
        {
            stateMachine.SwitchState(new EnemyMainState(stateMachine));
        }

    }

    public override void Exit()
    {
        //attackTimerCounter  = 0f;
        stateMachine.hasInstantiated = false;
    }



}
