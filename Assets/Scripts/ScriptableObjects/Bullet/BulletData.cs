using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class BulletData : ScriptableObject
{

    [Header("regular bullet damage array")]
    public int[] BulletDamageArray = new int[6];

    [Header ("fireball damage array")]
    public int[] FireballDamageArray = new int[6];


}
