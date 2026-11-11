using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TXT_GoldCount : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI goldCountTxt;

    [SerializeField] GoldData goldData;
    public int goldSaveValue;
    
    void Start()
    {
        goldCountTxt.text = (goldData.goldCount.ToString());

        goldSaveValue = goldData.goldCount;
    }

    // Update is called once per frame
    void Update()
    {
        if (goldSaveValue != goldData.goldCount)
        {
            goldSaveValue = goldData.goldCount;
            goldCountTxt.text = goldSaveValue.ToString();
        }
        else { return; }
    }
}
