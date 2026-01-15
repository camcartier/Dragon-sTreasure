using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFireballState : PlayerBaseState
{
    private float fireballEmissionDuration = 90f;
    private float fireballTimerCounter = 0f;
    //private GameObject fireballStartingPoint;
    public PlayerFireballState(PlayerStateMachine stateMachine) : base(stateMachine)
    {
    }

    public override void Enter()
    {
        //Debug.Log("fireball");
        stateMachine.canFireball = false;
        stateMachine.isStunnable = false;

        stateMachine.gameObject.GetComponentInChildren<SpriteRenderer>().color = Color.green;

        stateMachine.rb2D.velocity = Vector3.zero;

        stateMachine.PlayerCoroutinesScript.StartCoroutine(stateMachine.PlayerCoroutinesScript.countingFireballReload());

        GameObject.Instantiate(stateMachine.FireballPrefab, new Vector2(stateMachine.fireballStartingPoint.transform.position.x, stateMachine.fireballStartingPoint.transform.position.y), Quaternion.identity);
        stateMachine.CinemachineVirtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_AmplitudeGain = stateMachine.CameraData.FireballAmplitudeGain;
        stateMachine.CinemachineVirtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_FrequencyGain = stateMachine.CameraData.FireballFrequencyGain;


        //stopping noise progressively
        stateMachine.CameraCoroutines.StartCoroutine(stateMachine.CameraCoroutines.FireballCameraShake());
    }
    public override void Tick(float deltaTime)
    {
        if (fireballTimerCounter < fireballEmissionDuration)
        {
            fireballTimerCounter++;
        }
        else
        {
            stateMachine.SwitchState(new PlayerMainState(stateMachine));
            fireballTimerCounter = 0f;
        }
    }

    public override void Exit()
    {
        stateMachine.gameObject.GetComponentInChildren<SpriteRenderer>().color = Color.white;

        //stateMachine.canFireball = true;

    }
}
