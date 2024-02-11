using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] TreasureData treasureData;

    [Header("Testing")]
    public float TimerCounter;
    public float TimeBeforeIncrement = 3f;

    // Start is called before the first frame update
    void Start()
    {
        treasureData.GoldCount = 1;
    }

    // Update is called once per frame
    void Update()
    {



    }


    /*
//TESTING
if(TimerCounter < TimeBeforeIncrement) { TimerCounter += Time.deltaTime; }
else { treasureData.GoldCount += 1;  TimerCounter -= 0; }
*/


}
