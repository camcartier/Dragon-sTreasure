using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class PlayerData : ScriptableObject
{
    [Header("Level Info")]
    public int LevelMax;
    public int currentLevel;

    [Header("Basic Stats")]
    public float movementSpeed;
    public float stunTime;

    [Header ("Health&Mana")]
    public float MaxHealth;
    public float currentHealth;
    public float MaxMana;
    public float currentMana;   
    [Header ("Health Regen")]
    public float HealthRegenDelay;
    public float HealthRegenSpeed;
    public float HealthRegenAmount;
    [Header ("Mana Regen")]
    public float ManaRegenDelay;
    public float ManaRegenSpeed;
    public float ManaRegenAmount;

    [Header("Firing Info")]
    public float fireDelay;


}
