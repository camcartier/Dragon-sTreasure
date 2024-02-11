using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class PlayerData : ScriptableObject
{
    public int Level;

    [Header ("Health&Mana")]
    public float Health;
    public float Mana;

    public float Speed;
}
