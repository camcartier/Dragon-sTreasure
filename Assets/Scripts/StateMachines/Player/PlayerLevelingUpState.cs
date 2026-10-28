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
        stateMachine.PlayerVisualsAndCollidersGO.GetComponentInChildren<SpriteRenderer>().color = Color.yellow;
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
        stateMachine.PlayerVisualsAndCollidersGO.GetComponentInChildren<SpriteRenderer>().color = Color.white;
        stateMachine.GameManager.UnPauseGame();

        /*
        stateMachine.LvlsObjects[stateMachine.currentLevelStored].SetActive(true);
        stateMachine.LvlsObjects[stateMachine.currentLevelStored -1].SetActive(false);
        */

        /*
        //scaling player but are we doing this? i don't think so anymore
        stateMachine.PlayerVisualsAndCollidersGO.transform.localScale = new Vector3(stateMachine.PlayerVisualsAndCollidersGO.transform.localScale.x * 1.5f,
                                                                                      stateMachine.PlayerVisualsAndCollidersGO.transform.localScale.y * 1.5f,
                                                                                      stateMachine.PlayerVisualsAndCollidersGO.transform.localScale.z * 1.5f);
        */




        //a remplacer par des valeurs choisies au préalable et faire un lerp
        //stateMachine.CinemachineVirtualCamera.m_Lens.OrthographicSize = stateMachine.CinemachineVirtualCamera.m_Lens.OrthographicSize * 1.5f;

        stateMachine.Animator = stateMachine.GetComponentInChildren<Animator>();
    }




}
