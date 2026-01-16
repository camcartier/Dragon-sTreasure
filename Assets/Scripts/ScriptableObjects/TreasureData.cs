using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class TreasureData : ScriptableObject
{
    [Header("It's a magnificent treasure")]
    public int GoldCount;

    [Header("current step")]
    public int CurrentStep;

    [Header("valeurs a atteindre")]
    public int[] StepArray = new int[6];

    /*
    public bool LVL1;
    public bool LVL2;
    public bool LVL3;
    public bool LVL4;
    public bool LVL5;
    */
}
