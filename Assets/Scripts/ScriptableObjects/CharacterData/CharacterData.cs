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


}
