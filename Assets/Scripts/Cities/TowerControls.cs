using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerControls : MonoBehaviour
{
    [SerializeField] GameObject SwordSoldierPrefab;
    [SerializeField] GameObject ShieldSoldierPrefab;

    public GameObject[] SpawnPoints = new GameObject[3];

    public float delayBetweenSpawns;
    private bool hasStartedSpawning;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("tower sees you");
            if(!hasStartedSpawning) 
            {
                InvokeRepeating(nameof(SoldierSpawn), 0, delayBetweenSpawns); hasStartedSpawning = true;
            }
            
        }
    }

    private void SoldierSpawn()
    {
        int randomNumber = Random.Range(0, 3);
        Instantiate(ShieldSoldierPrefab, new Vector2(SpawnPoints[randomNumber].transform.position.x, SpawnPoints[randomNumber].transform.position.y), Quaternion.identity);
    }
    
    private void ArcherAttack()
    {

    }
}
