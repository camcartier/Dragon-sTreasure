using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerStateMachine : StateMachine
{
    [field: SerializeField] public InputReader InputReader { get; private set; }
    [field: SerializeField] public ForceReceiver ForceReceiver { get; private set; }


    [field: SerializeField] public Animator Animator { get; private set; }
    [field: SerializeField] public Rigidbody2D rb2D { get; private set; }


    [field: SerializeField] public PlayerData PlayerData { get; private set; }
    [field: SerializeField] public GameObject BulletPrefab { get; private set; }

    [field: SerializeField] public bool canFire { get; private set; }


    public Transform MainCameraTransform { get; private set; }

    void Start()
    {
        //why? I don't remember
        MainCameraTransform = Camera.main.transform;

        SwitchState(new PlayerMainState(this));
    }

}
