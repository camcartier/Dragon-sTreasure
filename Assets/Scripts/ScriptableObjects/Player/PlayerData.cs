using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class PlayerData : ScriptableObject
{
    [Header("Level Info")]
    public int LevelMax;
    public int currentLevel;

    [Header(" Stats")]
    public float movementSpeed;
    public float stunTime;

    [Header("Dash attributes")]
    public float dashSpeed;
    public float dashDelay;
    public bool canDash;

    [Header ("Health&Mana")]
    public float MaxHealth;
    public float MaxMana;

    [Header("Health Regen")]
    public bool canRegenHealth;
    public float HealthRegenDelay;
    public float HealthRegenAmount;

    [Header("Mana Regen")]
    public bool canRegenMana;
    public float ManaRegenMinimumDelay;

    [Header("Firing Info")]
    public float fireDelay;


}
