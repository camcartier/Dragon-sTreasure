using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class PlayerData : ScriptableObject
{
    [Header("Level Info")]
    public int LevelMax;
    public int CurrentLevel;

    [Header ("Health&Mana")]
    public float Health;
    public float Mana;

    public float Speed;
}
