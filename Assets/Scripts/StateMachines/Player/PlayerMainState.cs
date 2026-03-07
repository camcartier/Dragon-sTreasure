using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.Rendering;

public class PlayerMainState : PlayerBaseState
{
  
    Vector2 movement = new Vector2();

    public bool isFiring;
    private GameObject BulletStartPoint;

    [Header("Idle Animation")]
    private readonly int LVL1_IdleHash = Animator.StringToHash("LVL1_Idle");
    private readonly int LVL2_IdleHash = Animator.StringToHash("LVL2_Idle");
    private readonly int LVL3_IdleHash = Animator.StringToHash("LVL3_Idle");
    private readonly int LVL4_IdleHash = Animator.StringToHash("LVL4_Idle");
    private readonly int LVL5_IdleHash = Animator.StringToHash("LVL5_Idle");
    //each for each level
    private List<int> listOfIdleHash = new List<int>();
    


    [Header ("Everything about firing Bullets")]
    private readonly int LVL1_FiringHash = Animator.StringToHash("LVL1_Fire");
    private readonly int LVL2_FiringHash = Animator.StringToHash("LVL2_Fire");
    private readonly int LVL3_FiringHash = Animator.StringToHash("LVL3_Fire");
    private readonly int LVL4_FiringHash = Animator.StringToHash("LVL4_Fire");
    private readonly int LVL5_FiringHash = Animator.StringToHash("LVL5_Fire");
    private List<int> listOfFiringHash = new List<int>();
    private const float CrossFadeDuration = 0.1f;
    private float TimerCounter;

    private float dashDelayCounter;

    public PlayerMainState(PlayerStateMachine stateMachine) : base(stateMachine) {}

    public override void Enter()
    {
        listOfIdleHash.Add(LVL1_IdleHash);
        listOfIdleHash.Add(LVL2_IdleHash);
        listOfIdleHash.Add(LVL3_IdleHash);
        listOfIdleHash.Add(LVL4_IdleHash);
        listOfIdleHash.Add(LVL5_IdleHash);
        //Same with every level
        listOfFiringHash.Add(LVL1_FiringHash);
        listOfFiringHash.Add(LVL2_FiringHash);
        listOfFiringHash.Add(LVL3_FiringHash);
        listOfFiringHash.Add(LVL4_FiringHash);
        listOfFiringHash.Add(LVL5_FiringHash);
        //Same with every level

        stateMachine.isStunnable = true;

        stateMachine.InputReader.UseEvent += OnUse;
        stateMachine.InputReader.FireEvent += OnFire;
        stateMachine.InputReader.DashEvent += OnDash;
        stateMachine.InputReader.FireballEvent += OnFireball;
        stateMachine.InputReader.RepulseEvent += OnRepulse;

        BulletStartPoint = stateMachine.gameObject.GetComponentInChildren<BulletStartPoint>().gameObject;


        if (stateMachine.PlayerData.currentLevel < 2)
        {
            stateMachine.Animator.Play(LVL1_IdleHash);
        }


        //stateMachine.Animator.Play(FreeLookBlendTreeHash);
    }
    public override void Tick(float deltaTime)
    {
        if (stateMachine.currentLevelStored != stateMachine.TreasureData.CurrentStep)
        {
            stateMachine.SwitchState(new PlayerLevelingUpState(stateMachine));
        }

        if (!stateMachine.isInvulnerable && stateMachine.isHurt) { stateMachine.SwitchState(new PlayerHurtState(stateMachine));  }

        movement = new Vector2(stateMachine.InputReader.MovementValue.x, stateMachine.InputReader.MovementValue.y);
        movement.Normalize();

        if (movement != Vector2.zero)
        {
            stateMachine.lastMovementDirection = movement;
        }


        FaceMovementDirecton();
        stateMachine.rb2D.velocity = movement * stateMachine.PlayerData.movementSpeed;


        //seems to be working
        if (TimerCounter < stateMachine.Animator.GetCurrentAnimatorStateInfo(0).length)
        {
            TimerCounter += Time.deltaTime;
        }
        else { stateMachine.Animator.CrossFadeInFixedTime(listOfIdleHash[stateMachine.currentLevelStored], CrossFadeDuration); TimerCounter = 0f;  }


        if (!stateMachine.PlayerData.canDash)
        {
            if (dashDelayCounter < stateMachine.PlayerData.dashDelay)
            {
                dashDelayCounter += Time.deltaTime;
            }
            else { stateMachine.PlayerData.canDash = true; dashDelayCounter = 0f; }
        }

        if (stateMachine.InputReader.Fire.ReadValue<float>() > 0)
        {
            Debug.Log("fire continuously");

            //isFiring = true;

        }

        //Debug.Log(stateMachine.InputReader.Fire.ReadValue<float>());

    }
    public override void Exit()
    {

        stateMachine.InputReader.UseEvent -= OnUse;
        stateMachine.InputReader.FireEvent -= OnFire;
        stateMachine.InputReader.DashEvent -= OnDash;
        stateMachine.InputReader.RepulseEvent -= OnRepulse;

    }



    private void OnUse()
    {
        //Debug.Log("i pressed E");
        stateMachine.SwitchState(new PlayerUsingState(stateMachine));

    }

    private void OnFire()
    {
        if( stateMachine.hasInfiniteMana == true)
        {
            isFiring = true;
            stateMachine.PlayerData.canRegenMana = false;
            stateMachine.PlayerCurrentHealthAndMana.currentMana = stateMachine.PlayerData.MaxMana;


            stateMachine.PlayerCoroutinesScript.StartCoroutine(stateMachine.PlayerCoroutinesScript.UnlimitedManaDuration());


            stateMachine.Animator.CrossFadeInFixedTime(listOfFiringHash[stateMachine.currentLevelStored], CrossFadeDuration);
            GameObject.Instantiate(stateMachine.BulletPrefab, new Vector2(BulletStartPoint.transform.position.x, BulletStartPoint.transform.position.y), Quaternion.identity);
        }
        else
        {
            if (stateMachine.PlayerCurrentHealthAndMana.currentMana >= 5)
            {
                isFiring = true;

                //stateMachine.PlayerManaManager.ManaDepletionTimerCounter = 0f;
                stateMachine.PlayerData.canRegenMana = false;


                stateMachine.Animator.CrossFadeInFixedTime(listOfFiringHash[stateMachine.currentLevelStored], CrossFadeDuration);

                GameObject.Instantiate(stateMachine.BulletPrefab, new Vector2(BulletStartPoint.transform.position.x, BulletStartPoint.transform.position.y), Quaternion.identity);
                stateMachine.PlayerCurrentHealthAndMana.manaMinimumDelayCounter = 0;


                if (stateMachine.PlayerCurrentHealthAndMana.currentMana - 5 < 0)
                {
                    stateMachine.PlayerCurrentHealthAndMana.currentMana = 0;
                }
                else { stateMachine.PlayerCurrentHealthAndMana.currentMana -= 5; }
            }
            else { Debug.Log("not enough mana"); }

        }


    }

    private void OnDash()
    {
        if (stateMachine.canDash)
        {
            stateMachine.SwitchState(new PlayerEnterDashState(stateMachine));
        }

    }

    private void OnFireball()
    {
        if(stateMachine.canFireball)
        {
            stateMachine.SwitchState(new PlayerFireballState(stateMachine));
        }    
    }

    private void OnRepulse()
    {
        if (stateMachine.canRepulse)
        {
            stateMachine.SwitchState(new PlayerRepulseState(stateMachine));
        }

    }


    private void FaceMovementDirecton()
    {
        if(movement.x ==  0) { return; }

        if (movement.x < 0)
        {
            
            this.stateMachine.gameObject.transform.rotation = new Quaternion (0, 180, 0, 0); 
            //GameObject.Find("PlayerLVL1").GetComponentInChildren<SpriteRenderer>().flipX = true;
        }
        else {
            
            this.stateMachine.gameObject.transform.rotation = new Quaternion(0, 0, 0, 0);
            //GameObject.Find("PlayerLVL1").GetComponentInChildren<SpriteRenderer>().flipX = false;
            }
        }





}
