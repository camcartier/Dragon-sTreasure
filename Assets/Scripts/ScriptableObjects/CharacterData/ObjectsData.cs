using System.Collections;
using System.Collections.Generic;
using Unity.Rendering.HybridV2;
using UnityEngine;

[CreateAssetMenu]
public class ObjectsData : ScriptableObject
{
    [Header("Basic Stats")]
    public float maxHealth;
    public float regenAmount;
    public float regenSpeed;
    public float regenFirstWait;

    [Header("Loot")]
    public int goldLoot;

    [Header("hurt info")]
    public float hurtTimer;

    [Header("Burning Stats")]
    public float burningTimer;
    public float burningAmount;
    public float burningSpeed;
    public float minHealthBurnsStop;

    [Header("Character Stats")]
    public float walkSpeed;
    public float outOfRangeDetachTime;
    public float damageAmount;
    //public float damageCooldown;
    public float stunDuration;
    public float loadAttackTimer; 
    public float attackTimer;

    //idk if i'll use this...
    //[Header("Turn Stats")]
    //public float timeBeforeTurn;
    //public bool hasTurnedOnce;

    [Header ("Contact with player stats")]
    public bool isHurtFromContact;
    public int contactDamageTaken;

    [Header("Character Special Stats")]
    //public int goldCarried;
    //public int defenseSpe;
    public int runSpeed;
    public float timeBetweenProjectile;

    [Header("Spawn Stats")]
    public int maxSpawnCapacity;
}
