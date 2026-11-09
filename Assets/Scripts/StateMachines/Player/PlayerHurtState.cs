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


    private readonly int LVL1_HurtHash = Animator.StringToHash("LVL1_Hurt");
    private readonly int LVL2_HurtHash = Animator.StringToHash("LVL2_Hurt");
    private readonly int LVL3_HurtHash = Animator.StringToHash("LVL3_Hurt");
    private readonly int LVL4_HurtHash = Animator.StringToHash("LVL4_Hurt");
    private readonly int LVL5_HurtHash = Animator.StringToHash("LVL5_Hurt");
    //each for each level
    private List<int> listOfHurtHash = new List<int>();

    private readonly int NBase_Hurt = Animator.StringToHash("NBase_Hurt");

    //also knockback state
    public PlayerHurtState(PlayerStateMachine stateMachine) : base(stateMachine)
    {
    }

    public override void Enter()
    {
        stateMachine.flappingSound.Stop();
        stateMachine.Animator.Play(NBase_Hurt);

        Debug.Log("enter hurt state");

        stateMachine.isStunnable = false;
        stateMachine.isInvulnerable = true;
        stateMachine.PlayerCoroutinesScript.StartCoroutine(stateMachine.PlayerCoroutinesScript.countingInvulnerability());
        stateMachine.PlayerCoroutinesScript.StartCoroutine(stateMachine.PlayerCoroutinesScript.invulnerableBlinkingRed());

        stateMachine.rb2D.velocity = Vector3.zero;
        

        stateMachine.rb2D.AddForce(new Vector2(stateMachine.knockbackDirection.x, stateMachine.knockbackDirection.y).normalized*stateMachine.knockbackForce, ForceMode2D.Force) ;



        stateMachine.isHurt = false;

        stateMachine.MainSpriteRenderer.color = Color.red;

    }
    public override void Tick(float deltaTime)
    {


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
        //stateMachine.MainSpriteRendererArray[stateMachine.currentLevelStored].color = Color.white;

        knockbackDurationCounter = 0f;
        stunDurationCounter = 0f;
        stateMachine.knockbackDirection = Vector2.zero;

        

        stateMachine.MainSpriteRenderer.color = Color.white;
    }
     




}
