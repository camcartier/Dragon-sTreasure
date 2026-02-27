using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testingStuff : MonoBehaviour
{
    [SerializeField] SpriteRenderer spriteRenderer;
    private GameObject Player;

    private void Start()
    {
        Player = GameObject.Find("Player");
        
    }

    private void Update()
    {
        /*
        if (Player.GetComponent<PlayerStateMachine>().isInvulnerable)
        {
            spriteRenderer.color = Color.yellow;
        }
        else
        {
            spriteRenderer.color = Color.white;
        }
        */
    }
}
