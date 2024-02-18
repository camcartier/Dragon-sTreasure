using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMainState : PlayerBaseState
{

     
    Vector2 movement = new Vector2();

    private bool isFiring;
    private GameObject BulletStartPoint;


    //private const float AnimatorDampTime = 0.1f;
    //we attribute an int to this string for faster code
    //private readonly int FreeLookSpeedHash = Animator.StringToHash("FreelookSpeed");
    //private readonly int FreeLookBlendTreeHash = Animator.StringToHash("FreeLookBlendTree");


    private readonly int LVL1_IdleHash = Animator.StringToHash("LVL1_Idle");
    //each for each level
    //private readonly int LVL2_IdleHash = Animator.StringToHash("LVL2_Idle");

    public PlayerMainState(PlayerStateMachine stateMachine) : base(stateMachine) {}

    public override void Enter()
    {

        stateMachine.InputReader.UseEvent += OnUse;
        stateMachine.InputReader.FireEvent += OnFire;

        BulletStartPoint = stateMachine.gameObject.GetComponentInChildren<BulletStartPoint>().gameObject;


        if (stateMachine.PlayerData.CurrentLevel < 2)
        {
            stateMachine.Animator.Play(LVL1_IdleHash);
        }


        //stateMachine.Animator.Play(FreeLookBlendTreeHash);
    }
    public override void Tick(float deltaTime)
    {
        

        movement = new Vector2(stateMachine.InputReader.MovementValue.x, stateMachine.InputReader.MovementValue.y);
        //Debug.Log(movement);

        FaceMovementDirecton();

        /*
        movement.x = stateMachine.InputReader.MovementValue.x;
        movement.y = 0f;
        movement.z = stateMachine.InputReader.MovementValue.y;*/

        //Move(movement * stateMachine._movementSpeed, deltaTime);
        //stateMachine.Controller.Move(movement * Time.deltaTime * stateMachine._movementSpeed);

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
        GameObject.Instantiate(stateMachine.BulletPrefab, BulletStartPoint.transform);
    }


    private void FaceMovementDirecton()
    {
        if(movement.x ==  0) { return; }

        if (movement.x < 0)
        {
            Debug.Log("facing left");
            this.stateMachine.gameObject.transform.rotation = new Quaternion (0, 180, 0, 0); 
            //GameObject.Find("PlayerLVL1").GetComponentInChildren<SpriteRenderer>().flipX = true;
        }
        else {
            Debug.Log("facing right");
            this.stateMachine.gameObject.transform.rotation = new Quaternion(0, 0, 0, 0);
            //GameObject.Find("PlayerLVL1").GetComponentInChildren<SpriteRenderer>().flipX = false;
            }
        }


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
