using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using static Cinemachine.CinemachineFreeLook;

public class PlayerHeadbuttState : PlayerBaseState
{
    private float HeadbuttTimer = 0.5f;
    private float HeadbuttTimerCounter = 0f;
    private float ImpulseForce = 50f;

    private float HeadbuttDistance = 1f;
    private float HeadbuttDuration = 0.1f;
    private float HeadbuttMoveTimer;
    private float HeadbuttDirection;
    private Vector2 HeadbuttStartPosition;

    private bool hasInstatiated;
    private bool privateIsBiting;

    private readonly int NBase_Headbutt = Animator.StringToHash("NBase_Headbutt");

    public PlayerHeadbuttState(PlayerStateMachine stateMachine) : base(stateMachine)
    {
    }

    public override void Enter()
    {
        //Debug.Log("am heabutting");

        privateIsBiting = false;
        HeadbuttTimerCounter = 0f;
        stateMachine.InputReader.BiteEvent += OnBite;

        stateMachine.rb2D.velocity = Vector3.zero;


        stateMachine.isAttacking = true;
        stateMachine.isHeadbutt = true;    

        stateMachine.Animator.Play(NBase_Headbutt);
    }

    public override void Exit()
    {
        stateMachine.InputReader.BiteEvent -= OnBite;

        HeadbuttTimerCounter = 0f;

        privateIsBiting = false;
        stateMachine.isAttacking = false;
        stateMachine.isHeadbutt = false;
        stateMachine.isDashing = false;
    }

    public override void Tick(float deltaTime)
    {
        HeadbuttTimerCounter += Time.deltaTime;

        if (stateMachine.isHurt)
        {
            stateMachine.SwitchState(new PlayerHurtState(stateMachine));
            return;
        }

        if (Mouse.current.rightButton.wasPressedThisFrame) { stateMachine.isDashing = true; }
        if (stateMachine.isDashing)
        {
            stateMachine.SwitchState(new PlayerDashingState(stateMachine));
            return;
        }


        if (HeadbuttTimerCounter >= HeadbuttTimer)
        {
            stateMachine.SwitchState(new PlayerMainState(stateMachine));
            /*
            if (privateIsBiting) { stateMachine.SwitchState(new PlayerBiteState(stateMachine)); }

            else { stateMachine.SwitchState(new PlayerMainState(stateMachine)); }
            */
        }





        HeadbuttMoveTimer += Time.deltaTime;
        float t = Mathf.Clamp01(HeadbuttMoveTimer / HeadbuttDuration);

        if (t >= 1f)
        {
            if (!hasInstatiated)
            {
                stateMachine.InstantiateStuff.InstantiateStuff(stateMachine.HeadbuttFXPrefab, stateMachine.HeadbuttFXPOS.transform);
                hasInstatiated = true;
            }
        }

        float curveValue = stateMachine.HeadbuttCurve.Evaluate(t);
        float distance = HeadbuttDistance * curveValue;
        HeadbuttStartPosition = new Vector2(stateMachine.rb2D.transform.position.x, stateMachine.rb2D.transform.position.y);

        //float direction = Mathf.Sign(stateMachine.transform.localScale.x);
        if (stateMachine.gameObject.transform.rotation.y < 0)
        {
            stateMachine.rb2D.MovePosition(HeadbuttStartPosition + Vector2.left * distance);
            //stateMachine.rb2D.AddForce(Vector2.left  * ImpulseForce, ForceMode2D.Impulse);
        }
        else
        {
            stateMachine.rb2D.MovePosition(HeadbuttStartPosition + Vector2.right * distance);
            //stateMachine.rb2D.AddForce(Vector2.right  * ImpulseForce, ForceMode2D.Impulse);
        }
    }

    private void OnBite()
    {
        privateIsBiting = true;
    }



}
