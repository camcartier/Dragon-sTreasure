using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class BuildingsData : ScriptableObject
{
    [Header("Health Stats")]
    public int maxHealth;
    public int regenAmount;
    public float regenSpeed;
    public float regenWaitTime;
    public int burningAmount;
    public float burningSpeed;

    [Header("Spawn Stats")]
    public int maxSpawnCapacity;
    //public float spawnRate;

}
