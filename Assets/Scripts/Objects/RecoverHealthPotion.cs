using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecoverHealthPotion : MonoBehaviour
{
    [SerializeField] PlayerCurrentHealthAndMana playerCurrentHealthAndMana;
    [SerializeField] float healthRecovered;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerCurrentHealthAndMana.currentHealth += healthRecovered;
            Destroy(this.gameObject);
        }
    }
}
