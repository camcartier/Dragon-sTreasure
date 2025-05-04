using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManaManager : MonoBehaviour
{
    [SerializeField] PlayerCurrentHealthAndMana playerCurrentHealthAndMana;
    [SerializeField] PlayerData playerData;
    [SerializeField] TreasureData treasureData;
    public float ManaDepletionTimer;
    public float ManaDepletionTimerCounter;

    //public float ManaMinimumDelayCounter;


    void Start()
    {
        playerData.canRegenMana = false;
    }

    // Update is called once per frame
    void Update()
    {


        if (playerData.canRegenMana)
        {
            playerCurrentHealthAndMana.currentMana += 0.1f;
        }

        if (playerCurrentHealthAndMana.currentMana >= playerData.MaxMana)
        {
            playerData.canRegenMana = false;
            playerCurrentHealthAndMana.currentMana = playerData.MaxMana;
        }

        if (playerCurrentHealthAndMana.currentMana<= 0)
        {
            ManaDepletionTimerCounter += 1;
            if (ManaDepletionTimerCounter > ManaDepletionTimer)
            {
                playerData.canRegenMana = true;
                ManaDepletionTimerCounter = 0f;
            }
        }

        if (playerCurrentHealthAndMana.manaMinimumDelayCounter <= playerData.ManaRegenMinimumDelay)
        {
            playerCurrentHealthAndMana.manaMinimumDelayCounter += 1;
        }
        if(playerCurrentHealthAndMana.manaMinimumDelayCounter >= playerData.ManaRegenMinimumDelay)
        {
            playerData.canRegenMana = true;
            playerCurrentHealthAndMana.manaMinimumDelayCounter = 0;

        }




    }
}
