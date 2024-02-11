using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMainState : PlayerBaseState
{
     
    Vector3 movement = new Vector3();
    private const float AnimatorDampTime = 0.1f;


    //we attribute an int to this string for faster code
    private readonly int FreeLookSpeedHash = Animator.StringToHash("FreelookSpeed");
    private readonly int FreeLookBlendTreeHash = Animator.StringToHash("FreeLookBlendTree");


    public PlayerMainState(PlayerStateMachine stateMachine) : base(stateMachine) {}

    public override void Enter()
    {
        /*
        stateMachine.InputReader.MoveEvent += OnMove;
        stateMachine.InputReader.FireEvent += OnFire;
        stateMachine.InputReader.UseEvent += OnUse;

        */

        stateMachine.Animator.Play(FreeLookBlendTreeHash);
    }
    public override void Tick(float deltaTime)
    {
        movement = CalculateMovement();
        /*
        movement.x = stateMachine.InputReader.MovementValue.x;
        movement.y = 0f;
        movement.z = stateMachine.InputReader.MovementValue.y;*/

        Move(movement * stateMachine._movementSpeed, deltaTime);

        //stateMachine.Controller.Move(movement * Time.deltaTime * stateMachine._movementSpeed);

        if (stateMachine.InputReader.MovementValue == Vector2.zero)
        {
            stateMachine.Animator.SetFloat(FreeLookSpeedHash, 0, AnimatorDampTime, deltaTime);
            return;
        }
        stateMachine.Animator.SetFloat(FreeLookSpeedHash, 1, AnimatorDampTime, deltaTime);

        //FaceMovementDirection(movement, deltaTime);
    }
    public override void Exit()
    {
        /*
        stateMachine.InputReader.MoveEvent -= OnMove;
        stateMachine.InputReader.FireEvent -= OnFire;
        stateMachine.InputReader.UseEvent -= OnUse;
        //Debug.Log("exit");
        */
    }

    private Vector3 CalculateMovement()
    {
        Vector3 forward = stateMachine.MainCameraTransform.forward;
        Vector3 right = stateMachine.MainCameraTransform.right;

        forward.y = 0; right.y = 0;

        forward.Normalize(); right.Normalize();

        return forward * stateMachine.InputReader.MovementValue.y + right * stateMachine.InputReader.MovementValue.x;
    }

    /*
    private void FaceMovementDirection(Vector3 movement, float deltaTime)
    {
        stateMachine.transform.rotation = Quaternion.Lerp(
            stateMachine.transform.rotation, 
            Quaternion.LookRotation(movement),
            deltaTime * stateMachine.RotationDamping);
    }

    private void OnJump()
    {
        stateMachine.SwitchState(new PlayerJumpingState(stateMachine));
    }

    private void OnTarget()
    {
        if (!stateMachine.Targeter.SelectTarget()) { return; }
        stateMachine.SwitchState(new PlayerTargetingState(stateMachine));
    }
    private void OnCancel()
    {
        stateMachine.SwitchState(new PlayerFreeLookState(stateMachine));
    }

    private void OnDash()
    {
        stateMachine.SwitchState(new PlayerDashingState(stateMachine));
    }
    */
}
