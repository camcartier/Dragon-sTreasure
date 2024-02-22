using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.Events;

public class Loot : MonoBehaviour
{
    [SerializeField] TreasureData treasureData;

    [SerializeField] GoldValue thisGoldValue;


    private void Start()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player")){

            treasureData.GoldCount += thisGoldValue.Value;
            Destroy(this.gameObject);
        }

        if (collision.gameObject.CompareTag("Thief"))
        {
            collision.gameObject.GetComponentInChildren<ThiefControls>().currentGoldCarried += thisGoldValue.Value;
            Destroy(this.gameObject);
        }
    }
}
