using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.Events;

public class Loot : MonoBehaviour
{
    //[SerializeField] TreasureData treasureData;
    [SerializeField] GoldData goldCount;
    [SerializeField] LootValues thisLootValue;

    [SerializeField] PlayerCurrentHealthAndMana PlayerHealthAndMana;
    [SerializeField] GameObject GoldPSPrefab;

    private void Start()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player")){

            goldCount.goldCount += thisLootValue.GoldValue;
            PlayerHealthAndMana.currentHealth += thisLootValue.HealthValue;
            Instantiate(GoldPSPrefab, collision.gameObject.GetComponent<PlayerStateMachine>().goldFXPOS.transform.position, new Quaternion(0,0,0,0), collision.gameObject.GetComponent<PlayerStateMachine>().goldFXPOS.transform);
            Destroy(this.gameObject);
        }


    }
}
