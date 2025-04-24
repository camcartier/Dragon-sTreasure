using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthManager : MonoBehaviour
{
    [SerializeField] PlayerCurrentHealthAndMana playerCurrentHealthAndMana;
    [SerializeField] PlayerData playerData;

    public float HealthRegenTimer;
    public float HealthRegenTimerCounter;

    // Start is called before the first frame update
    void Start()
    {
        playerData.canRegenHealth = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (playerData.canRegenHealth)
        {
            playerCurrentHealthAndMana.currentHealth += 0.1f;
        }


    }
}
