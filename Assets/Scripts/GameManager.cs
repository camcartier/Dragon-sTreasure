using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] TreasureData treasureData;

    [Header("Testing")]
    public float TimerCounter;
    public float TimeBeforeIncrement = 3f;

    //public PlayerCurrentHealthAndMana currentPlayerData;
    //public PlayerData playerData;

    [SerializeField] PlayerCurrentHealthAndMana currentPlayerHealthAndMana;
    [SerializeField] PlayerData playerData;

    private void Awake()
    {
        treasureData.GoldCount = 1;

        currentPlayerHealthAndMana.currentMana = playerData.MaxMana;
        currentPlayerHealthAndMana.currentHealth = playerData.MaxHealth;

        //currentPlayerData = GameObject.Find("ScriptableObjectsManager").GetComponent<ScriptableGestionnaire>().PlayerCurrentHealthAndMana;
        //playerData = GameObject.Find("ScriptableObjectsManager").GetComponent<ScriptableGestionnaire>().PlayerData;
    }

    // Start is called before the first frame update
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {

        /* hahahaha
        if (playerData.MaxMana < playerData.MaxMana * treasureData.CurrentStep)
        {
            playerData.MaxMana = playerData.MaxMana * treasureData.CurrentStep;
        }
        */


    }


    /*
//TESTING
if(TimerCounter < TimeBeforeIncrement) { TimerCounter += Time.deltaTime; }
else { treasureData.GoldCount += 1;  TimerCounter -= 0; }
*/


}
