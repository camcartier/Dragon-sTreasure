using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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


    public PlayerBiteState(PlayerStateMachine stateMachine) : base(stateMachine)
    {
    }

    public override void Enter()
    {
        BiteTimerCounter = 0f;
        stateMachine.rb2D.velocity = Vector3.zero;
        stateMachine.isAttacking = true;

         

        stateMachine.Animator.Play(NBase_Bite);
        stateMachine.flappingSound.Stop();


    }

    public override void Exit()
    {
        stateMachine.isAttacking = false;
    }

    public override void Tick(float deltaTime)
    {
        BiteTimerCounter += Time.deltaTime;

        if (BiteTimerCounter > BiteTimer)
        {
            stateMachine.SwitchState(new PlayerMainState(stateMachine));
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
