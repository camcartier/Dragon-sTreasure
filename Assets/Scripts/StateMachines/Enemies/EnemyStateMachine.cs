using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStateMachine : StateMachine
{
    [field: SerializeField] public Animator Animator { get; private set; }
    [field: SerializeField] public Rigidbody2D rb2D { get; private set; }
    [field: SerializeField] public EnemyIDNumber enemyID { get; private set; }
    //[field: SerializeField] public SpriteRenderer spriteRenderer { get; set; }
    [field: SerializeField] public ObjectsData characterData { get; private set; }
    [field: SerializeField] public Destroyable destroyableInfo { get; private set; }


    [field: SerializeField] public bool canAttack { get;  set; }
    [field: SerializeField] public bool isAtttacking { get; set; }
    [field: SerializeField] public float attackTimer { get; set; }
    [field: SerializeField] public InstantiateStuff instantiateStuff { get; set; }
    [field: SerializeField] public bool hasInstantiated { get; set; }
    [field: SerializeField] public Collider2D hitCollider { get; set; }

    [field: SerializeField] public bool canBeBumped { get; private set; }


    [field: SerializeField] public bool isFollowing { get; set; }
    [field: SerializeField] public bool isHurt { get; set; }

    [field: SerializeField] public bool hurtIsReset { get; set; }


    [field: SerializeField] public bool isBurning { get; set; }

    [field: SerializeField] public bool hasAlreadyBurnt{ get; set; }
    [field: SerializeField] public bool isStuned { get; set; }
    [field: SerializeField] public bool isDead { get; set; }



    [field: SerializeField] public SpriteRenderer spriteRenderer { get; set; }

    void Start()
    {
        SwitchState(new EnemySpawnState(this));

        spriteRenderer.gameObject.GetComponentInChildren<SpriteRenderer>();
    }


}
