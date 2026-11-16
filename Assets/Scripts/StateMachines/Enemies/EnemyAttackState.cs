using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackState : EnemyBaseState
{
    private float attackTimer;
    private float attackTimerCounter;
    private float ID2AttackTimerCounter;
    private float ID3AttackTimerCounter;

    private float timebeforechangeState = 2f;
    private float timebeforechangeStateCounter;

    
   

    //turning the prefab
    private bool isTurning;
    private GameObject toFollow;


    private bool hasInstantiatedHitPS;

    private readonly int Attack = Animator.StringToHash("Attack");

    public EnemyAttackState(EnemyStateMachine stateMachine) : base(stateMachine)
    {
    }

    public override void Enter()
    {
        stateMachine.rb2D.velocity = Vector2.zero;

        stateMachine.rb2D.constraints |= RigidbodyConstraints2D.FreezePositionX;

        //stateMachine.GetComponentInChildren<SpriteRenderer>().color = Color.grey;

        //turning the prefab
        toFollow = GameObject.Find("Player");


        stateMachine.Animator.Play("Attack",0 ,0f);
        stateMachine.shadowAnimator.Play("Shadow_move_toAttack");
        stateMachine.attackSound.Play();
    }
    public override void Tick(float deltaTime)
    {
        if (stateMachine.isHit){stateMachine.SwitchState(new EnemyHurtState(stateMachine)); return; }
        if (stateMachine.isDead) { stateMachine.SwitchState(new  EnemyDeathState(stateMachine)); return; }
   

        stateMachine.rb2D.velocity = Vector2.zero;

        timebeforechangeStateCounter += deltaTime;


        if (timebeforechangeStateCounter >= timebeforechangeState / 5)
        {
            stateMachine.isHitting = true;
            

            if (!hasInstantiatedHitPS)
            {
                stateMachine.instantiateStuff.InstantiateFX(stateMachine.attackPSHit, stateMachine.attackPSAirposition);
                hasInstantiatedHitPS = true;
            }
            
        }

        //ENEMY ID 2 sword
        if (stateMachine.enemyID.IDNumber == 2|| stateMachine.enemyID.IDNumber == 1)
        {


            if(stateMachine.characterData.attackTimer < ID2AttackTimerCounter)
            {
                if (stateMachine.stillAttacking)
                {
                    stateMachine.SwitchState(new EnemyAttackState(stateMachine));
                    return;
                }
                else
                {
                    stateMachine.SwitchState(new EnemyMainState(stateMachine));
                    return;
                }
                   
            }
            else { ID2AttackTimerCounter += deltaTime; }
            
    
        }


        //ENEMY ID 3 archer
        if (stateMachine.enemyID.IDNumber == 3 )
        {


            if (!stateMachine.hasInstantiated)
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
            }

            if (stateMachine.characterData.attackTimer < ID3AttackTimerCounter)
            {
                if (stateMachine.stillAttacking)
                {
                    stateMachine.SwitchState(new EnemyAttackState(stateMachine));
                    return;
                }
                else
                {
                    stateMachine.SwitchState(new EnemyMainState(stateMachine));
                    return;
                }

            }
            else { ID3AttackTimerCounter += deltaTime; }

            


        }





    }

    public override void Exit()
    {
        //startAttack = false;
        stateMachine.spriteRenderer.color = Color.white;


        //attackTimerCounter  = 0f;
        stateMachine.hasInstantiated = false;

        stateMachine.isAttacking = false;
        stateMachine.isHitting = false;
        stateMachine.hasHit = false;
        stateMachine.isInAttackState = false;

        timebeforechangeStateCounter = 0f;
        ID2AttackTimerCounter = 0f;
        ID3AttackTimerCounter = 0f;

        stateMachine.rb2D.constraints &= ~RigidbodyConstraints2D.FreezePositionX;

        stateMachine.shadowAnimator.Play("Shadow_POS");
        //stateMachine.rb2D.constraints &= ~RigidbodyConstraints2D.FreezePositionX;
    }



}
