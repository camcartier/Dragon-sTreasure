using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerStateMachine : StateMachine
{
    [field: SerializeField] public InputReader InputReader { get; private set; }
    [field: SerializeField] public CharacterController Controller { get; private set; }
    [field: SerializeField] public Animator Animator { get; private set; }
    [field: SerializeField] public float _movementSpeed { get; private set; }

    //no current use
    //[field: SerializeField] public float DashForce { get; private set; }

    //not necessary for this game
    //[field: SerializeField] public float RotationDamping { get; private set; }
    
    //not currently used 
    [field: SerializeField] public ForceReceiver ForceReceiver { get; private set; }

    public Transform MainCameraTransform { get; private set; }

    void Start()
    {
        //why? I don't remember
        MainCameraTransform = Camera.main.transform;

        SwitchState(new PlayerMainState(this));
    }

}
