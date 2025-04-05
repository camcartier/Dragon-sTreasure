using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GoldUI : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI goldCounterTxt;
    [SerializeField] TreasureData treasureData;
    public int TreasureCounter;

    // Start is called before the first frame update
    void Start()
    {
        TreasureCounter = treasureData.GoldCount;
    }

    // Update is called once per frame
    void Update()
    {
        if (TreasureCounter == treasureData.GoldCount)
        {
            return;
        }
        else { TreasureCounter = treasureData.GoldCount; goldCounterTxt.text = TreasureCounter + ("/") + treasureData.CurrentStep;  }
    }
}
