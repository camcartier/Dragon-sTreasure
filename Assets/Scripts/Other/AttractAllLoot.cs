using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class AttractAllLoot : MonoBehaviour
{
    private GameObject player;
    public float attractionSpeed;

    private bool isAttracted;

    private void OnEnable()
    {
        SpawnerControls.AWaveSpawned += AttractLoot;
    }
    private void OnDisable()
    {
        SpawnerControls.AWaveSpawned -= AttractLoot;
    }

    private void Start()
    {
        player = GameObject.Find("Player");
    }

    private void Update()
    {
        if (isAttracted)
        {
            GameObject[] loot = GameObject.FindGameObjectsWithTag("Loot");

            attractionSpeed += 0.5f;

            foreach (GameObject gold in loot)
            {
                gold.transform.position = Vector3.MoveTowards(gold.transform.position,
                                                                player.transform.position,
                                                                attractionSpeed * Time.deltaTime);
            }

            if (loot.Length == 0)
            {
                isAttracted = false;
                attractionSpeed = 25f;
            }
        }
    }

    private void AttractLoot()
    {
        //Debug.Log("attract");
        isAttracted = true;
    }
}
