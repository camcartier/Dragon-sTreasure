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
        goldCounterTxt.text = "1/1";
        treasureSaveValue = treasureData.GoldCount;
    }

    // Update is called once per frame
    void Update()
    {
        if (treasureSaveValue != treasureData.GoldCount)
        {
            treasureSaveValue = treasureData.GoldCount;
            goldCounterTxt.text = treasureSaveValue + "/" + treasureSaveValue*2 ;
        }
        else { return; }
    }
}
