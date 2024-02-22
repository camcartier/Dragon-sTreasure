using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;

[CreateAssetMenu]
public class CharacterData : ScriptableObject
{
    [Header ("Basic Stats")]
    public int maxHealth;
    public int walkSpeed;
    public int goldLoot;

    [Header ("Special Stats")]
    public int goldCarried;
    public int defenseSpe;
    public int runSpeed;

    //that's stupid LOL
    /*
    [Header("Thief")]
    public int thiefMaxHealth;
    public int thiefSpeed;
    public int thiefGoldLoot;
    public int thiefGoldCarried;

    [Header("Farmer")]
    public int farmerMaxHealth;
    public int farmerSpeed;
    public int farmerLoot;

    [Header("Soldier")]
    public int soldierMaxHealth;
    public int soldierSpeed;
    public int soldierLoot;

    [Header ("Yakkuru")]
    public int yakkuruMaxHealth;
    public int yakkuruSpeed;
    public int yakkuruLoot;
    */

}
