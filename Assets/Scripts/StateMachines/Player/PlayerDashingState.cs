using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditorInternal;
using UnityEngine;

public class PlayerDashingState : PlayerBaseState
{
    private float dashDurationCounter;

    private readonly int NBase_Dash = Animator.StringToHash("NBase_Dash");


    public PlayerDashingState(PlayerStateMachine stateMachine) : base(stateMachine)
    {
    }

    public override void Enter()
    {
        stateMachine.canDash = false;

        //ajouté pour l'UI
        //
        //stateMachine.dashCooldownCounter = stateMachine.PlayerData.dashDelay;

        stateMachine.PlayerCoroutinesScript.StartCoroutine(stateMachine.PlayerCoroutinesScript.countingDashReload());

        //animation
        stateMachine.Animator.Play(NBase_Dash);
        //stateMachine.flappingSound.Stop();
        //stateMachine.dashingSound.Play();



        stateMachine.gameObject.GetComponentInChildren<Collider2D>().enabled = false;
        //stateMachine.gameObject.GetComponentInChildren<SpriteRenderer>().color = Color.blue;

        stateMachine.rb2D.velocity = stateMachine.lastMovementDirection * stateMachine.PlayerData.dashSpeed;

        stateMachine.CinemachineVirtualCamera.GetCinemachineComponent<CinemachineFramingTransposer>().m_XDamping = 0.75f;
        stateMachine.CinemachineVirtualCamera.GetCinemachineComponent<CinemachineFramingTransposer>().m_YDamping = 1f;

        //framingTransposer.m_XDamping = Mathf.Lerp(framingTransposer.m_XDamping, targetXDamping, Time.deltaTime * 5f);

    }
    public override void Tick(float deltaTime)
    {
        if (dashDurationCounter < stateMachine.PlayerData.dashDuration)
        { 
            dashDurationCounter += deltaTime;
        }
        else { stateMachine.SwitchState(new PlayerMainState(stateMachine)); }

    }

    public override void Exit()
    {
        //stateMachine.isDashing = false;
        //Debug.Log(stateMachine.isDashing);

        dashDurationCounter = 0f;
        stateMachine.gameObject.GetComponentInChildren<Collider2D>().enabled = true;
        
        stateMachine.PlayerData.canDash = false;
        //stateMachine.CinemachineVirtualCamera.GetCinemachineComponent<CinemachineFramingTransposer>().m_XDamping = Mathf.Lerp(2, 0, Time.deltaTime * 5f);

        stateMachine.CameraCoroutines.StartCoroutine(stateMachine.CameraCoroutines.LerpXYDamping());


        stateMachine.dashCooldownCounter = 0f;
    }



}
