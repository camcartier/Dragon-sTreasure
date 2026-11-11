using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GoldCounterTxt : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI goldCounterTxt;

    [SerializeField] TreasureData treasureData;
    public int treasureSaveValue;

    void Start()
    {
        //ne prend pas en compte le depassement d'honoraire
        goldCounterTxt.text = (treasureData.GoldCount + "/" + treasureData.StepArray[treasureData.CurrentStep]);

        treasureSaveValue = treasureData.GoldCount;


    }

    // Update is called once per frame
    void Update()
    {
        if (treasureData.GoldCount >= treasureData.StepArray[treasureData.CurrentStep])
        {
            treasureData.CurrentStep += 1; //treasureData.GoldCount = 0;
        }




        if (treasureSaveValue != treasureData.GoldCount)
        {
            treasureSaveValue = treasureData.GoldCount;
            goldCounterTxt.text = treasureSaveValue + "/" + treasureData.StepArray[treasureData.CurrentStep] ;
        }
        else { return; }
    }
}
