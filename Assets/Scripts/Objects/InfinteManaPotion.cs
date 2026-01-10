using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class InfinteManaPotion : MonoBehaviour
{
    private GameObject Player;

    private void Start()
    {
        Player = GameObject.Find("Player");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("mana");
            Player.GetComponent<PlayerStateMachine>().hasInfiniteMana = true;

            Destroy(this.gameObject);
        }
    }


}
