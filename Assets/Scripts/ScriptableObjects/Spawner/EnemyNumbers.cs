using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class EnemyNumbers : ScriptableObject
{
    [Header("Princess")]
    public List<int> PtotalEnemyNumber = new List<int>();
    public List<int> PswordsMaxNumber = new List<int>();
    public List<int> PhorsesMaxNumber = new List<int>();
    public List<int> PsorceresMaxNumber = new List<int>();


}
