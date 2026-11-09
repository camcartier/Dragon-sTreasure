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
    //each for each level
    private List<int> listOfFireballHash = new List<int>();

    private readonly int NBase_Fireball = Animator.StringToHash("NBase_Fireball");
    //private readonly int NBase_Fireball = Animator.StringToHash("NBase_Bite");

    public PlayerFireballState(PlayerStateMachine stateMachine) : base(stateMachine)
    {
    }

    public override void Enter()
    {
        stateMachine.fireballCooldownCounter = stateMachine.PlayerData.fireballDelay;

        //animation
        stateMachine.Animator.Play(NBase_Fireball);
        stateMachine.flappingSound.Stop();
        //stateMachine.fireballSound.Play();

        //Debug.Log("fireball");
        stateMachine.canFireball = false;
        stateMachine.isStunnable = false;

        stateMachine.gameObject.GetComponentInChildren<SpriteRenderer>().color = Color.green;

        stateMachine.rb2D.velocity = Vector3.zero;

        //stateMachine.PlayerCoroutinesScript.StartCoroutine(stateMachine.PlayerCoroutinesScript.countingFireballReload());

        GameObject.Instantiate(stateMachine.FireballPrefab, new Vector2(stateMachine.fireballStartingPoint.transform.position.x, stateMachine.fireballStartingPoint.transform.position.y), Quaternion.identity);
        
        
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

        //stateMachine.fireballSound.Stop();
        //stateMachine.canFireball = true;

    }
}
