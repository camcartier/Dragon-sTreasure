using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class ObjectsData : ScriptableObject
{
    [Header("Basic Stats")]
    public int maxHealth;
    public int regenAmount;
    public float regenSpeed;
    public float regenFirstWait;
    public float regenWaitTime;

    [Header("Loot")]
    public int goldLoot;

    [Header ("Burning Stats")]
    public int burningAmount;
    public float burningSpeed;

    [Header("Character Stats")]
    public int walkSpeed;

    [Header("Character Special Stats")]
    public int goldCarried;
    public int defenseSpe;
    public int runSpeed;

    [Header("Spawn Stats")]
    public int maxSpawnCapacity;
}
