using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputReader : MonoBehaviour
    //, Controls.IMainActions
{
    //private Controls controls;

    public event Action MoveEvent, UseEvent, AttackEvent;

    public Vector2 MovementValue { get; private set; }

    void Start()
    {
        //controls = new Controls();
        //controls.Main.SetCallbacks(this);

        //controls.Main.Enable();
    }

    void OnDestroy()
    {
        //controls.Main.Disable();
    }

    /*
    public void OnJump(InputAction.CallbackContext context)
    {
        if(!context.performed) { return; }

        JumpEvent?.Invoke();
    }
    public void OnAttack(InputAction.CallbackContext context)
    {
        if(!context.performed) { return; }

        AttackEvent?.Invoke(); 
    }
    public void OnDash(InputAction.CallbackContext context)
    {
        if (!context.performed) { return; }

        DashEvent?.Invoke();
    }
    public void OnMove(InputAction.CallbackContext context)
    {
        MovementValue = context.ReadValue<Vector2>();
    }
    public void OnUse(InputAction.CallbackContext context)
    {
        if (!context.performed) { return; }

        UseEvent?.Invoke();
    }

    public void OnLook(InputAction.CallbackContext context)
    {
        //code is being handled by cinemachine
    }
    public void OnTarget(InputAction.CallbackContext context)
    {
        if (!context.performed) { return; }

        TargetEvent?.Invoke();  
    }
    public void OnCancel(InputAction.CallbackContext context)
    {
        if (context.performed) { CancelEvent?.Invoke(); }
    }
    */
}
