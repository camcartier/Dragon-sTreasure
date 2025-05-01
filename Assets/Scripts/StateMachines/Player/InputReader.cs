using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputReader : MonoBehaviour, Controls.IMainActions
{
    private Controls controls;

    public event Action  UseEvent, FireEvent, DashEvent; 
    //MoveEvent,

    public Vector2 MovementValue { get; private set; }

    void Start()
    {
        controls = new Controls(); controls.Main.SetCallbacks(this);

        controls.Main.Enable();
    }

    void OnDestroy()
    {
        controls.Main.Disable();
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

    public void OnFire(InputAction.CallbackContext context)
    {
        if (!context.performed) { return; }

        FireEvent?.Invoke();

    }

    public void OnDash(InputAction.CallbackContext context)
    {
        if (!context.performed) { return; }

        DashEvent?.Invoke();
    }

}
