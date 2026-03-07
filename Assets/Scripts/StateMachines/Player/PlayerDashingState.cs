using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerDashingState : PlayerBaseState
{
    private float dashDurationCounter;

    private readonly int LVL1_DashingHash = Animator.StringToHash("LVL1_Dashing");
    private readonly int LVL2_DashingHash = Animator.StringToHash("LVL2_Dashing");
    private readonly int LVL3_DashingHash = Animator.StringToHash("LVL3_Dashing");
    private readonly int LVL4_DashingHash = Animator.StringToHash("LVL4_Dashing");
    private readonly int LVL5_DashingHash = Animator.StringToHash("LVL5_Dashing");
    //each for each level
    private List<int> listOfDashingHash = new List<int>();


    public PlayerDashingState(PlayerStateMachine stateMachine) : base(stateMachine)
    {
    }

    public override void Enter()
    {
        listOfDashingHash.Add(LVL1_DashingHash);
        listOfDashingHash.Add(LVL2_DashingHash);
        listOfDashingHash.Add(LVL3_DashingHash);
        listOfDashingHash.Add(LVL4_DashingHash);
        listOfDashingHash.Add(LVL5_DashingHash);



        stateMachine.gameObject.GetComponentInChildren<Collider2D>().enabled = false;
        stateMachine.gameObject.GetComponentInChildren<SpriteRenderer>().color = Color.blue;

        stateMachine.rb2D.velocity = stateMachine.lastMovementDirection * stateMachine.PlayerData.dashSpeed;

        stateMachine.CinemachineVirtualCamera.GetCinemachineComponent<CinemachineFramingTransposer>().m_XDamping = 0.75f;
        stateMachine.CinemachineVirtualCamera.GetCinemachineComponent<CinemachineFramingTransposer>().m_YDamping = 1f;

        //framingTransposer.m_XDamping = Mathf.Lerp(framingTransposer.m_XDamping, targetXDamping, Time.deltaTime * 5f);

    }
    public override void Tick(float deltaTime)
    {
        if (dashDurationCounter < stateMachine.dashDuration)
        { 
            dashDurationCounter += deltaTime;
        }
        else { stateMachine.SwitchState(new PlayerMainState(stateMachine)); }

    }

    public override void Exit()
    {
        stateMachine.isDashing = false;
        //Debug.Log(stateMachine.isDashing);

        dashDurationCounter = 0f;
        stateMachine.gameObject.GetComponentInChildren<Collider2D>().enabled = true;
        stateMachine.gameObject.GetComponentInChildren<SpriteRenderer>().color = Color.white;
        stateMachine.PlayerData.canDash = false;
        //stateMachine.CinemachineVirtualCamera.GetCinemachineComponent<CinemachineFramingTransposer>().m_XDamping = Mathf.Lerp(2, 0, Time.deltaTime * 5f);

        stateMachine.CameraCoroutines.StartCoroutine(stateMachine.CameraCoroutines.LerpXYDamping());
        
    }



}
