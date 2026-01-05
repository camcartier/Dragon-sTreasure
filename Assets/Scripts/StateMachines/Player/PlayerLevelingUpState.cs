using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerLevelingUpState : PlayerBaseState
{

    public PlayerLevelingUpState(PlayerStateMachine stateMachine) : base(stateMachine)
    {
    }

    public override void Enter()
    {
        stateMachine.gameObject.GetComponentInChildren<SpriteRenderer>().color = Color.yellow;
        stateMachine.GameManager.PauseGame();

        stateMachine.LevelingUpTimer.StartCoroutine(stateMachine.LevelingUpTimer.countingLevelUp());
        //stateMachine.CameraCoroutines.StartCoroutine(stateMachine.CameraCoroutines.LerpDezoomCamera());

        
        
    }
    public override void Tick(float deltaTime)
    {

    }
    public override void Exit()
    {
        stateMachine.currentLevelStored += 1;
        stateMachine.gameObject.GetComponentInChildren<SpriteRenderer>().color = Color.white;
        stateMachine.GameManager.UnPauseGame();

        //a remplacer par des valeurs choisies au préalable et faire un lerp
        stateMachine.CinemachineVirtualCamera.m_Lens.OrthographicSize = stateMachine.CinemachineVirtualCamera.m_Lens.OrthographicSize * 1.5f;
    }




}
