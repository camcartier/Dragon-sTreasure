using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testingTrigger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ( collision.CompareTag("Fireball"))
        {
            Debug.Log("triggered");
        }
       
    }
}
