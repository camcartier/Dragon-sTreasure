using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class BulletData : ScriptableObject
{
    [Header("Temp Damage")]
    public int LVL1_bulletDamage;
    public int LVL2_bulletDamage;
    public int LVL3_bulletDamage;
    public int LVL4_bulletDamage;
    public int LVL5_bulletDamage;
    public int LVL6_bulletDamage;

    [Header("Temp Speed")]
    public int LVL1_bulletSpeed;
    public int LVL2_bulletSpeed;
    public int LVL3_bulletSpeed;
    public int LVL4_bulletSpeed;
    public int LVL5_bulletSpeed;
    public int LVL6_bulletSpeed;

}
