using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHurtState : EnemyBaseState
{
    private float hurtTimerCounter;

    private readonly int Hurt = Animator.StringToHash("Hurt");

    public EnemyHurtState(EnemyStateMachine stateMachine) : base(stateMachine)
    {
    }

    public override void Enter()
    {
        //Debug.Log("in hurt state");
        
        stateMachine.GetComponentInChildren<SpriteRenderer>().color = Color.red;

        stateMachine.Animator.Play("Hurt");

        stateMachine.attackSound.Stop();

        
        stateMachine.rb2D.velocity = Vector2.zero;


        stateMachine.rb2D.AddForce(stateMachine.pendingRepulse, ForceMode2D.Impulse);
        stateMachine.pendingRepulse = Vector2.zero;    
        stateMachine.rb2D.AddForce(stateMachine.pendingKnockback, ForceMode2D.Impulse);
        stateMachine.pendingKnockback = Vector2.zero;
        stateMachine.destroyableInfo.MyCurrentHealth -= stateMachine.pendingDamage;
        stateMachine.pendingDamage = 0;
    }
    public override void Tick(float deltaTime)
    {
        if (stateMachine.isDead)
        {
            stateMachine.SwitchState(new EnemyDeathState(stateMachine));
            return;
        }


        if (stateMachine.hurtIsReset)
        {
            hurtTimerCounter = 0f; stateMachine.hurtIsReset = false;
        }

        

        if (hurtTimerCounter < stateMachine.characterData.hurtTimer)
        {
            hurtTimerCounter += Time.deltaTime;
            
        }
        else { stateMachine.SwitchState(new EnemyMainState(stateMachine)); }


    }

    public override void Exit()
    {
        hurtTimerCounter = 0f;
        stateMachine.isHurt = false;
        stateMachine.isHit = false;

        //Debug.Log("out hurt state");

        //stateMachine.walkTowards.isFollowing = true;
    }
}
