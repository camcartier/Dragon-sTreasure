using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class PlayerData : ScriptableObject
{
    [Header("Level Info")]
    public int LevelMax;
    public int currentLevel;

    [Header("Movement")]
    public float movementSpeed;
    public float[] movementSpeedArray = new float[6];

    [Header("hurt state")]
    public float stunDuration;
    public float invulnerabilityDuration;
    //public float knockbackDuration;

    [Header("Dash attributes")]
    public float dashSpeed;
    public float[] dashSpeedArray = new float[6];
    public float dashDelay;
    public float[] dashDelayArray = new float[6];
    public bool canDash;

    [Header ("Health&Mana")]
    public float MaxHealth;
    public float MaxMana;
    public float[] maxHealthArray = new float[6];
    public float[] maxManaArray = new float[6];
    public float invulnerabilityTimer;

    [Header("Health Regen")]
    public bool canRegenHealth;
    public float HealthRegenDelay;
    public float HealthRegenAmount;

    [Header("Mana Regen")]
    public bool canRegenMana;
    public float ManaRegenMinimumDelay;

    [Header("Firing Info")]
    public float fireDelay;

    [Header("Repulse Info")]
    public float repulseForce;
    public float repulseRadius;


}
