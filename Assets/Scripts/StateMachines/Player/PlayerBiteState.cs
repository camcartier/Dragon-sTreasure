using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerBiteState : PlayerBaseState
{
    private float BiteTimer = 0.5f;
    private float BiteTimerCounter;
    private float ImpulseForce = 50f;

    private float BiteDistance = .3f;
    private float BiteDuration = 0.15f;
    private float BiteMoveTimer;
    private float BiteDirection;
    private Vector2 BiteStartPosition;


    private readonly int NBase_Bite = Animator.StringToHash("NBase_Bite");

    private bool isCombo;
    private float timeBeforeComboCounter;
    private float timeForComboEnabled = 0.1f;

    public PlayerBiteState(PlayerStateMachine stateMachine) : base(stateMachine)
    {
    }

    public override void Enter()
    {
        BiteTimerCounter = 0f;
        stateMachine.rb2D.velocity = Vector3.zero;
        stateMachine.isAttacking = true;
        stateMachine.isBiting = true;
         

        stateMachine.Animator.Play(NBase_Bite);
        //current sound takes too much space
        stateMachine.biteSound.Play();
        stateMachine.flappingSound.Stop();


    }

    public override void Exit()
    {
        stateMachine.isAttacking = false;
        isCombo = false;
        stateMachine.isDashing = false;
        stateMachine.isBiting = false;
    }

    public override void Tick(float deltaTime)
    {
        BiteTimerCounter += Time.deltaTime;

        if (stateMachine.isHurt)
        {
            stateMachine.SwitchState(new PlayerHurtState(stateMachine));
            return;
        }

        if (Mouse.current.rightButton.wasPressedThisFrame) { stateMachine.isDashing = true;}
        if (stateMachine.isDashing) 
        {
            stateMachine.SwitchState(new PlayerDashingState(stateMachine));
            return;
        }

        timeBeforeComboCounter += Time.deltaTime;
        if (timeBeforeComboCounter > timeForComboEnabled)
        {
            if (Mouse.current.leftButton.wasPressedThisFrame)
            {
                isCombo = true;
            }
        }



        if (BiteTimerCounter > BiteTimer)
        {
            if (isCombo) { stateMachine.SwitchState(new PlayerHeadbuttState(stateMachine)); }
            else { 
            stateMachine.SwitchState(new PlayerMainState(stateMachine));
            }
        }

        BiteMoveTimer += Time.deltaTime;
        float t = Mathf.Clamp01(BiteMoveTimer / BiteDuration);

        float curveValue = stateMachine.BiteCurve.Evaluate(t);
        float distance = BiteDistance * curveValue;
        BiteStartPosition = new Vector2(stateMachine.rb2D.transform.position.x, stateMachine.rb2D.transform.position.y);




        if (stateMachine.gameObject.transform.rotation.y < 0)
        {
            stateMachine.rb2D.MovePosition(BiteStartPosition + Vector2.left * distance);
            //stateMachine.rb2D.AddForce(Vector2.left * ImpulseForce, ForceMode2D.Impulse);
        }
        else
        {
            stateMachine.rb2D.MovePosition(BiteStartPosition + Vector2.right * distance);
            //stateMachine.rb2D.AddForce(Vector2.right * ImpulseForce, ForceMode2D.Impulse);
        }
    }


}
