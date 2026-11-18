using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemonessSpawnControls : MonoBehaviour
{
    [SerializeField] GameObject demonessPrefab;
    [Header("SpawnPOS")]
    [SerializeField] GameObject[] spawnPos = new GameObject[4];

    [SerializeField] PlayerCurrentHealthAndMana playerCurrentHealth;

    private bool hasSpawned;

    void Start()
    {
        
    }

    void Update()
    {
        if (playerCurrentHealth != null) 
        {
            if (playerCurrentHealth.currentHealth < 5)
            {
                if (!hasSpawned) 
                {
                    int index = Random.Range(0, 4);
                    Instantiate(demonessPrefab, spawnPos[index].transform.position, Quaternion.identity);
                    hasSpawned = true;
                }

            }
        }
    }
}
