using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHurtState : EnemyBaseState
{
    private float hurtTimerCounter;

    private readonly int Hurt = Animator.StringToHash("Hurt");

    private float successiveHitsTimerCounter;
    private float successiveHitsTimer = 0.1f;

    private bool willTakeAnotherHit;
    private int Count;
    public EnemyHurtState(EnemyStateMachine stateMachine) : base(stateMachine)
    {
    }

    public override void Enter()
    {
        stateMachine.getAttackTargets.HasBeenHit += OnHit;

        //stateMachine.gameObject.layer = LayerMask.NameToLayer("DestroyableKnockback");
        SetLayerRecursively(stateMachine.gameObject, 14);

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
        successiveHitsTimerCounter += deltaTime;
        if (successiveHitsTimerCounter > successiveHitsTimer) { stateMachine.hasAlreadyBeenHit = false; }

        if (stateMachine.isDead)
        {
            stateMachine.SwitchState(new EnemyDeathState(stateMachine));
            return;
        }

        /*
        if (stateMachine.hurtIsReset)
        {
            hurtTimerCounter = 0f; stateMachine.hurtIsReset = false;
        }
        */



        if (hurtTimerCounter < stateMachine.characterData.hurtTimer)
        {
            hurtTimerCounter += Time.deltaTime;

        }
        else
        {

            if (Count > 1)
            {
                stateMachine.SwitchState(new EnemyHurtState(stateMachine));
                Count = 0;
                return;
            }
            else { stateMachine.SwitchState(new EnemyMainState(stateMachine)); return; }

        }
    }

    public override void Exit()
    {
        stateMachine.getAttackTargets.HasBeenHit -= OnHit;

        //stateMachine.gameObject.layer = LayerMask.NameToLayer("Destroyable");
        SetLayerRecursively(stateMachine.gameObject, 7);


        hurtTimerCounter = 0f;
        stateMachine.isHurt = false;
        stateMachine.isHit = false;

        //Debug.Log("out hurt state");

        //stateMachine.walkTowards.isFollowing = true;
    }

    void SetLayerRecursively(GameObject gameObject, int layer)
    {
        gameObject.layer = layer;
        foreach (Transform child in gameObject.transform)
            SetLayerRecursively(child.gameObject, layer);
    }

    void OnHit()
    {
        Count++;
        Debug.Log("got hit");
        //willTakeAnotherHit = true;
        stateMachine.getAttackTargets.HasBeenHit -= OnHit;
    }

}
