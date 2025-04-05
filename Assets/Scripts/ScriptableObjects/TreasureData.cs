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
    public int FirstStep;
    public int SecondStep;
    public int ThirstStep;
    public int FourthStep;
    public int FifthStep;
    public int SixthStep;
}
