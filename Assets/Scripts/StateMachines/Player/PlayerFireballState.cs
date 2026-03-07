using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFireballState : PlayerBaseState
{
    private float fireballEmissionDuration = 1.1f;
    private float fireballTimerCounter = 0f;
    //private GameObject fireballStartingPoint;

    private readonly int LVL1_FireballHash = Animator.StringToHash("LVL1_Fireball");
    private readonly int LVL2_FireballHash = Animator.StringToHash("LVL2_Fireball");
    private readonly int LVL3_FireballHash = Animator.StringToHash("LVL3_Fireball");
    private readonly int LVL4_FireballHash = Animator.StringToHash("LVL4_Fireball");
    private readonly int LVL5_FireballHash = Animator.StringToHash("LVL5_Fireball");
    //each for each level
    private List<int> listOfFireballHash = new List<int>();
    public PlayerFireballState(PlayerStateMachine stateMachine) : base(stateMachine)
    {
    }

    public override void Enter()
    {
        listOfFireballHash.Add(LVL1_FireballHash);
        listOfFireballHash.Add(LVL2_FireballHash);
        listOfFireballHash.Add(LVL3_FireballHash);
        listOfFireballHash.Add(LVL4_FireballHash);
        listOfFireballHash.Add(LVL5_FireballHash);


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
            fireballTimerCounter += Time.deltaTime;
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
