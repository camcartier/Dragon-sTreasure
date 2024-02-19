using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loot : MonoBehaviour
{
    [SerializeField] TreasureData treasureData;

    [SerializeField] GoldValue thisGoldValue; 


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player")){

            treasureData.GoldCount += thisGoldValue.Value;
            Destroy(this.gameObject);
        }
    }
}
