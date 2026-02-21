using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStateMachine : StateMachine
{
    [field: SerializeField] public Animator Animator { get; private set; }
    [field: SerializeField] public Rigidbody2D rb2D { get; private set; }

    [field: SerializeField] public bool canAttack { get; private set; }
    [field: SerializeField] public bool canBeBumped { get; private set; }

    [field: SerializeField] public bool isFollowing { get; private set; }
    [field: SerializeField] public bool isHurt { get; private set; }
    [field: SerializeField] public bool isStuned { get; private set; }
    [field: SerializeField] public bool isDead { get; private set; }


    void Start()
    {
        SwitchState(new EnemySpawnState(this));
    }


}
