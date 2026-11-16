using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class KillsData : ScriptableObject
{
    [Header ("Total")]
    public int killCount;

    [Header ("Specific")]
    public int swordsKillCount;
    public int horsesKillCount;
    public int sorcerersKillCount;
}
