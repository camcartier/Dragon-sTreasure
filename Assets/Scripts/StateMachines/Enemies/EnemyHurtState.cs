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
        Debug.Log("in hurt state");
        
        stateMachine.GetComponentInChildren<SpriteRenderer>().color = Color.red;

        stateMachine.Animator.Play("Hurt");

        stateMachine.attackSound.Stop();

        
        //Debug.Log(stateMachine.knockbackDirection);
        stateMachine.rb2D.velocity = Vector2.zero;
        //Debug.Log("Velocity après reset : " + stateMachine.rb2D.velocity);


        //stateMachine.rb2D.AddForce(new Vector2(stateMachine.knockbackDirection.x, stateMachine.knockbackDirection.y).normalized * stateMachine.knockbackForce, ForceMode2D.Impulse);
        
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

        //Debug.Log(stateMachine.rb2D.velocity);

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

        Debug.Log("out hurt state");

        //stateMachine.walkTowards.isFollowing = true;
    }
}
