using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;

public class PlayerMainState : PlayerBaseState
{
  
    Vector2 movement = new Vector2();

    private bool isFiring;
    private GameObject BulletStartPoint;


    private readonly int LVL1_IdleHash = Animator.StringToHash("LVL1_Idle");
    //each for each level
    //private readonly int LVL2_IdleHash = Animator.StringToHash("LVL2_Idle");
    //private const float AnimatorDampTime = 0.1f;

    [Header ("Everything about firing Bullets")]
    private readonly int FiringHash = Animator.StringToHash("LVL1_Fire");
    private const float CrossFadeDuration = 0.1f;
    private float TimerCounter;

    private float dashDelayCounter;

    public PlayerMainState(PlayerStateMachine stateMachine) : base(stateMachine) {}

    public override void Enter()
    {
        stateMachine.isStunnable = true;

        stateMachine.InputReader.UseEvent += OnUse;
        stateMachine.InputReader.FireEvent += OnFire;
        stateMachine.InputReader.DashEvent += OnDash;

        BulletStartPoint = stateMachine.gameObject.GetComponentInChildren<BulletStartPoint>().gameObject;


        if (stateMachine.PlayerData.currentLevel < 2)
        {
            stateMachine.Animator.Play(LVL1_IdleHash);
        }


        //stateMachine.Animator.Play(FreeLookBlendTreeHash);
    }
    public override void Tick(float deltaTime)
    {
        

        movement = new Vector2(stateMachine.InputReader.MovementValue.x, stateMachine.InputReader.MovementValue.y);
        //Debug.Log(movement);
        movement.Normalize();

        if (movement != Vector2.zero)
        {
            stateMachine.lastMovementDirection = movement;
        }

        FaceMovementDirecton();

        //weirdass movement at the start of the game
        stateMachine.rb2D.velocity = movement * stateMachine.PlayerData.movementSpeed * Time.deltaTime;

        //seems to be working
        if (TimerCounter < stateMachine.Animator.GetCurrentAnimatorStateInfo(0).length)
        {
            TimerCounter += Time.deltaTime;
        }
        else { stateMachine.Animator.CrossFadeInFixedTime(LVL1_IdleHash, CrossFadeDuration); TimerCounter = 0f;  }


        if (!stateMachine.PlayerData.canDash)
        {
            if (dashDelayCounter < stateMachine.PlayerData.dashDelay)
            {
                dashDelayCounter += Time.deltaTime;
            }
            else { stateMachine.PlayerData.canDash = true; dashDelayCounter = 0f; }
        }


        /*
        movement.x = stateMachine.InputReader.MovementValue.x;
        movement.y = 0f;
        movement.z = stateMachine.InputReader.MovementValue.y;*/

        /*
        if (stateMachine.InputReader.MovementValue == Vector2.zero)
        {
            stateMachine.Animator.SetFloat(FreeLookSpeedHash, 0, AnimatorDampTime, deltaTime);
            return;
        }
        stateMachine.Animator.SetFloat(FreeLookSpeedHash, 1, AnimatorDampTime, deltaTime);
        */

        //old version
        //FaceMovementDirection(movement, deltaTime);
    }
    public override void Exit()
    {

        stateMachine.InputReader.UseEvent -= OnUse;
        stateMachine.InputReader.FireEvent -= OnFire;
        stateMachine.InputReader.DashEvent -= OnDash;

    }


    
    //private Vector3 CalculateMovement()
    //{

        /*
        Vector3 forward = stateMachine.MainCameraTransform.forward;
        Vector3 right = stateMachine.MainCameraTransform.right;

        forward.y = 0; right.y = 0;

        forward.Normalize(); right.Normalize();

        return forward * stateMachine.InputReader.MovementValue.y + right * stateMachine.InputReader.MovementValue.x;

        */
    //}

    /*
    private void OnMove()
    {

    }
    */

    private void OnUse()
    {
        stateMachine.SwitchState(new PlayerUsingState(stateMachine));
    }

    private void OnFire()
    {


        if (stateMachine.PlayerCurrentHealthAndMana.currentMana >= 5)
        {
            stateMachine.Animator.CrossFadeInFixedTime(FiringHash, CrossFadeDuration);

            GameObject.Instantiate(stateMachine.BulletPrefab, new Vector2(BulletStartPoint.transform.position.x, BulletStartPoint.transform.position.y), Quaternion.identity);
            stateMachine.PlayerCurrentHealthAndMana.manaMinimumDelayCounter = 0;
            
                  
            if (stateMachine.PlayerCurrentHealthAndMana.currentMana - 5 < 0)
            {
                stateMachine.PlayerCurrentHealthAndMana.currentMana = 0;
            }
            else {  stateMachine.PlayerCurrentHealthAndMana.currentMana -= 5; }
        }
        else { Debug.Log("not enough mana"); }


    }

    private void OnDash()
    {
        if (stateMachine.PlayerData.canDash)
        {
            stateMachine.SwitchState(new PlayerDashingState(stateMachine));
        }

    }



    private void FaceMovementDirecton()
    {
        if(movement.x ==  0) { return; }

        if (movement.x < 0)
        {
            //Debug.Log("facing left");
            this.stateMachine.gameObject.transform.rotation = new Quaternion (0, 180, 0, 0); 
            //GameObject.Find("PlayerLVL1").GetComponentInChildren<SpriteRenderer>().flipX = true;
        }
        else {
            //Debug.Log("facing right");
            this.stateMachine.gameObject.transform.rotation = new Quaternion(0, 0, 0, 0);
            //GameObject.Find("PlayerLVL1").GetComponentInChildren<SpriteRenderer>().flipX = false;
            }
        }

    //this can not work as the script is not derived from MonoBehavior
    /*private void OnCollisionEnter2D(Collision collision)
    {
        Debug.Log("collided");

        if (collision.collider.gameObject.GetComponent<CanDamage>() !=null)
        {
            stateMachine.SwitchState(new PlayerHurtState(stateMachine));
        }
        else { Debug.Log("not found"); }
    }*/


    /*
    private void FaceMovementDirection(Vector3 movement, float deltaTime)
    {
        stateMachine.transform.rotation = Quaternion.Lerp(
            stateMachine.transform.rotation, 
            Quaternion.LookRotation(movement),
            deltaTime * stateMachine.RotationDamping);
    }


    */
}
