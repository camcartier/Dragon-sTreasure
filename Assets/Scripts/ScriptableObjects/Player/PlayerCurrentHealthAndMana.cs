using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu]
public class PlayerCurrentHealthAndMana : ScriptableObject
{
    [Header("Health and Mana")]
    public float currentHealth;
    public float currentMana;
    public float manaMinimumDelayCounter;

    //idk si servira ou pas
    [Header("Stamina")]
    public float stamina;
}
