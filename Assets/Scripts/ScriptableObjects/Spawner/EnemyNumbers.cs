using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class EnemyNumbers : ScriptableObject
{
    [Header("Princess")]
    public List<int> totalEnemyNumber = new List<int>();
    public List<int> swordsMaxNumber = new List<int>();
    public List<int> horsesMaxNumber = new List<int>();
    public List<int> sorceresMaxNumber = new List<int>();


}
