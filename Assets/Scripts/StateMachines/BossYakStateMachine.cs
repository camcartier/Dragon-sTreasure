using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossYakStateMachine : StateMachine
{
    /*
    [Header("Attack fields")]
    private bool isCloseEnough;
    private bool canAttack;
    [SerializeField] float AttackTimer;
    private float AttackTimerCounter;
    private bool canStomp;
    [SerializeField] float StompTimer;
    private float StompTimerCounter;
    private bool IsEnraged;
    [SerializeField] float RestTimer;
    private float RestTimerCounter;
    private bool isResting;


    [Header("Core")]
    private Rigidbody2D rb2d;
    private SpriteRenderer spriteRenderer;
    */

    [field: SerializeField] public GameObject player { get; set; }

    [field: SerializeField] public Rigidbody2D rb2D { get; set; }
    [field: SerializeField] public Destroyable destroyable { get; set; }
    [field: SerializeField] public SpriteRenderer spriteRenderer { get; set; }


    [field: SerializeField] public ObjectsData bossYakuruData { get; set; }


    [field: SerializeField] public bool isCloseEnough { get; set; }
    [field: SerializeField] public bool canAttack { get; set; }
    [field: SerializeField] public bool canStomp { get; set; }


    [field: SerializeField] public bool isEnraged { get; set; }
    [field: SerializeField] public bool isResting { get; set; }


    void Start()
    {
        SwitchState(new BossYakMainState(this));
    }
}
