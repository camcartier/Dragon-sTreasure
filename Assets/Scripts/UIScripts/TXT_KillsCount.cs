using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TXT_KillsCount : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI killCountTxt;
    [SerializeField] EnemyNumbers enemyNumbers;
    [SerializeField] KillsData killData;
    [SerializeField] SpawnerControls spawnerControls;
    public int killSaveValue;


    void Start()
    {
        killCountTxt.text = (killData.killCount.ToString());

        //goldSaveValue = goldData.goldCount;
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if (goldSaveValue != goldData.goldCount)
        {
            goldSaveValue = goldData.goldCount;
            killCountTxt.text = goldSaveValue.ToString();
        }
        else { return; }*/
        
        //game manager change la valeur
        killCountTxt.text = (killData.killCount.ToString()) + "/" + (enemyNumbers.PtotalEnemyNumber[spawnerControls.index].ToString());

    }
}
