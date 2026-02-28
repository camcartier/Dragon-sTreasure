using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHurtState : PlayerBaseState
{

    private float knockbackDurationCounter;
    private float invulnerabilityDurationCounter;
    private float stunDurationCounter;
    private Vector2 normalizedDirection;

    private PlayerCollisionListener collisionListener;

    //also knockback state
    public PlayerHurtState(PlayerStateMachine stateMachine) : base(stateMachine)
    {
    }

    public override void Enter()
    {
        stateMachine.MainSpriteRendererArray[stateMachine.currentLevelStored].color = Color.red;

        Debug.Log("enter hurt state");

        stateMachine.isStunnable = false;
        stateMachine.isInvulnerable = true;
        stateMachine.PlayerCoroutinesScript.StartCoroutine(stateMachine.PlayerCoroutinesScript.countingInvulnerability());

stateMachine.rb2D.velocity = Vector3.zero;
        

        stateMachine.rb2D.AddForce(new Vector2(stateMachine.knockbackDirection.x, stateMachine.knockbackDirection.y).normalized*stateMachine.knockbackForce, ForceMode2D.Force) ;
        //direction comes from Player Collision Listener
        //and EnemyCollisionListener?



        //noise on impact
        /*
          if (stateMachine.PlayerCurrentHealthAndMana.currentHealth < stateMachine.PlayerData.MaxHealth / 2) 
        {
            stateMachine.CinemachineVirtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_AmplitudeGain = stateMachine.CameraData.AmplitudeGain;
            stateMachine.CinemachineVirtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_FrequencyGain = stateMachine.CameraData.FrequencyGain;


            //stopping noise progressively
            stateMachine.CameraCoroutines.StartCoroutine(stateMachine.CameraCoroutines.LerpCameraNoise());
        }
        */

    }
    public override void Tick(float deltaTime)
    {
        if (knockbackDurationCounter < stateMachine.knockBackDuration)
        {
            knockbackDurationCounter += Time.deltaTime;
        }
        else
        {
            //stateMachine.rb2D.velocity = Vector3.zero;
        }

        if (stunDurationCounter < stateMachine.PlayerData.stunDuration)
        {
            stunDurationCounter += Time.deltaTime;
        }
        else if (stateMachine.PlayerCurrentHealthAndMana.currentHealth > 0)
        {
            stateMachine.SwitchState(new PlayerMainState(stateMachine));

        }
        else { stateMachine.SwitchState(new PlayerDyingState(stateMachine)); }
    }

    public override void Exit()
    {
        stateMachine.MainSpriteRendererArray[stateMachine.currentLevelStored].color = Color.white;

        knockbackDurationCounter = 0f;

        stateMachine.isHurt = false;
    }
     




}
