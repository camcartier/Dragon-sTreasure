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


    private readonly int NBase_Idle = Animator.StringToHash("NBase_Idle");


    private float dashDelayCounter;

    public PlayerMainState(PlayerStateMachine stateMachine) : base(stateMachine) {}

    public override void Enter()
    {

        

        stateMachine.isStunnable = true;

        stateMachine.InputReader.HeadbuttEvent += OnHeadbutt;
        stateMachine.InputReader.BiteEvent += OnBite;
        stateMachine.InputReader.DashEvent += OnDash;
        stateMachine.InputReader.FireballEvent += OnFireball;
        stateMachine.InputReader.RepulseEvent += OnRepulse;

        BulletStartPoint = stateMachine.gameObject.GetComponentInChildren<BulletStartPoint>().gameObject;

        /*
        if (stateMachine.PlayerData.currentLevel < 2)
        {
            stateMachine.Animator.Play(LVL1_IdleHash);
        }
        else
        {
            stateMachine.Animator.Play(LVL1_IdleHash);
        }
        */


        //new animation
        stateMachine.Animator.Play(NBase_Idle);


        //stateMachine.Animator.Play(FreeLookBlendTreeHash);
    }
    public override void Tick(float deltaTime)
    {
        //on ne fait plus de leveling
        /*
        if (stateMachine.currentLevelStored != stateMachine.TreasureData.CurrentStep)
        {
            stateMachine.SwitchState(new PlayerLevelingUpState(stateMachine));
        }
        */

        if (!stateMachine.isInvulnerable && stateMachine.isHurt) { stateMachine.SwitchState(new PlayerHurtState(stateMachine));  }

        movement = new Vector2(stateMachine.InputReader.MovementValue.x, stateMachine.InputReader.MovementValue.y);
        movement.Normalize();

        if (movement != Vector2.zero)
        {
            stateMachine.lastMovementDirection = movement;
        }


        FaceMovementDirecton();
        stateMachine.rb2D.velocity = movement * stateMachine.PlayerData.movementSpeed;
        Debug.Log(dashDelayCounter);

        if (!stateMachine.canDash)
        {
            if (stateMachine.dashCooldownCounter < stateMachine.PlayerData.dashDelay)
            {
                stateMachine.dashCooldownCounter += Time.deltaTime;
            }
            else { stateMachine.canDash = true;  }
        }

        if (!stateMachine.canFireball)
        {
            if (stateMachine.fireballCooldownCounter < stateMachine.PlayerData.fireballDelay)
            {
                stateMachine.fireballCooldownCounter += Time.deltaTime;
            }
            else { stateMachine.canFireball = true; }
        }


        /*
        if (stateMachine.InputReader.Fire.ReadValue<float>() > 0)
        {
            Debug.Log("fire continuously");

            //isFiring = true;

        }
        */

        //Debug.Log(stateMachine.InputReader.Fire.ReadValue<float>());

        /*
        if (stateMachine.canDash)
        {
            stateMachine.MainSpriteRenderer.color = Color.green;
        }
        else
        {
            stateMachine.MainSpriteRenderer.color = Color.white;
        }
        */

    }
    public override void Exit()
    {

        stateMachine.InputReader.HeadbuttEvent -= OnHeadbutt;
        stateMachine.InputReader.BiteEvent -= OnBite;
        stateMachine.InputReader.DashEvent -= OnDash;
        stateMachine.InputReader.RepulseEvent -= OnRepulse;

    }



    private void OnHeadbutt()
    {
        
        stateMachine.SwitchState(new PlayerHeadbuttState(stateMachine));

    }

    private void OnBite()
    {
        stateMachine.SwitchState(new PlayerBiteState(stateMachine));
    }

    /*
    private void OnFire()
    {
        if( stateMachine.hasInfiniteMana == true)
        {
            isFiring = true;
            stateMachine.PlayerData.canRegenMana = false;
            stateMachine.PlayerCurrentHealthAndMana.currentMana = stateMachine.PlayerData.MaxMana;


            stateMachine.PlayerCoroutinesScript.StartCoroutine(stateMachine.PlayerCoroutinesScript.UnlimitedManaDuration());


            //stateMachine.Animator.CrossFadeInFixedTime(listOfFiringHash[stateMachine.currentLevelStored], CrossFadeDuration);
            GameObject.Instantiate(stateMachine.BulletPrefab, new Vector2(BulletStartPoint.transform.position.x, BulletStartPoint.transform.position.y), Quaternion.identity);
        }
        else
        {
            if (stateMachine.PlayerCurrentHealthAndMana.currentMana >= 5)
            {
                isFiring = true;

                //stateMachine.PlayerManaManager.ManaDepletionTimerCounter = 0f;
                stateMachine.PlayerData.canRegenMana = false;


                //stateMachine.Animator.CrossFadeInFixedTime(listOfFiringHash[stateMachine.currentLevelStored], CrossFadeDuration);

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
    */

    private void OnDash()
    {
        if (stateMachine.canDash)
        {
            stateMachine.SwitchState(new PlayerDashingState(stateMachine));
            stateMachine.dashCooldownCounter = 0f;
            
        }

    }

    private void OnFireball()
    {
        if(stateMachine.canFireball)
        {
            stateMachine.SwitchState(new PlayerFireballState(stateMachine));
            stateMachine.fireballCooldownCounter = 0f;
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
            
            this.stateMachine.gameObject.transform.rotation = new Quaternion (0, -180, 0, 0); 
            //GameObject.Find("PlayerLVL1").GetComponentInChildren<SpriteRenderer>().flipX = true;
        }
        else {
            
            this.stateMachine.gameObject.transform.rotation = new Quaternion(0, 0, 0, 0);
            //GameObject.Find("PlayerLVL1").GetComponentInChildren<SpriteRenderer>().flipX = false;
            }
        }





}
