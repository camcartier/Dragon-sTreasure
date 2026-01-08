using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerStateMachine : StateMachine
{
    [field: SerializeField] public InputReader InputReader { get; private set; }
    //[field: SerializeField] public ForceReceiver ForceReceiver { get; private set; }
    //n a pas servi avec ce nom la 

    //Movement
    [field: SerializeField] public Animator Animator { get; private set; }
    [field: SerializeField] public Rigidbody2D rb2D { get; private set; }


    //Stats, Health and Mana
    [field: SerializeField] public PlayerData PlayerData { get; private set; }
    [field: SerializeField] public PlayerCurrentHealthAndMana PlayerCurrentHealthAndMana { get;  set; }

    [field: SerializeField] public PlayerManaManager PlayerManaManager;


    //Firing bullets
    [field: SerializeField] public bool canFire { get; private set; }
    [field: SerializeField] public bool isFiring { get; private set; }
    [field: SerializeField] public GameObject BulletPrefab { get; private set; }
    

    //FXs
    [field: SerializeField] public GameObject diggingFX { get; private set; }


    //stun and knockback
    [field: SerializeField] public bool isStunnable { get;  set; }
    [field: SerializeField] public float stunDuration { get; set; }
    [field: SerializeField] public Vector2 knockbackDirection { get; set; }
    [field: SerializeField] public int knockbackForce { get; private set; }
    
    //celui la devrait etre dans le playerData
    [field: SerializeField] public float knockBackDuration { get; private set; }
    [field: SerializeField] public int knockBackDistance { get; private set; }


    //so we don't get back in hurt state when in contact and dead
    [field: SerializeField] public bool isDead { get; set; }
    
    //pour qu'on se fasse pas marave comme une victime
    [field: SerializeField] public bool isInvulnerable  { get; set; }
    [field: SerializeField] public PlayerCoroutinesScript PlayerCoroutinesScript { get; private set; }


    //Use
    [field: SerializeField] public bool isUsing { get; set; }


    //Dash
    [field: SerializeField] public bool canDash { get; set; }
    [field: SerializeField] public bool isDashing { get; set; }
    [field: SerializeField] public float dashDuration { get; private set; }
    [field: SerializeField] public Vector2 lastMovementDirection { get; set; }

    //Fireball
    [field: SerializeField] public bool canFireball { get; set; }
    [field: SerializeField] public GameObject fireballStartingPoint { get; private set; }
    [field: SerializeField] public GameObject FireballPrefab { get; private set; }

    //Leveling up
    [field: SerializeField] public int currentLevelStored { get; set; }
    [field: SerializeField] public TreasureData TreasureData { get; set; }
    [field: SerializeField] public LevelingUpTimer LevelingUpTimer { get; set; }

    //General
    public GameManager GameManager { get; set; }
    public Transform MainCameraTransform { get; private set; }
    [field: SerializeField] public CameraCoroutines CameraCoroutines { get; private set; }
    [field: SerializeField] public CameraData CameraData { get; set; }

    public CinemachineVirtualCamera CinemachineVirtualCamera { get; set; }

    [field: SerializeField] public GameObject StartingTextPanel { get; private set; }

    void Start()
    {
        GameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

        MainCameraTransform = Camera.main.transform;
        CinemachineVirtualCamera = GameObject.Find("CinemachineVirtualCamera").GetComponent<CinemachineVirtualCamera>();

        SwitchState(new PlayerStartGameState(this));
    }

}
