using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.Experimental.RestService;
using UnityEngine;

public class FarmControls : MonoBehaviour
{
    [Header("ScriptableObjects")]
    [SerializeField] BulletData bulletData;
    [SerializeField] PlayerData activePlayerData;
    [SerializeField] ObjectsData farmData;

    [Header("ObjectsToSpawn")]
    [SerializeField] GameObject Peasant;
    [SerializeField] GameObject FleeingPeasant;

    /*
[Header("Individual Farm Stats")]
//it's inside FarmData
//public int farmMaxHealth;
//public int farmCurrentHealth;
//public bool isBurning;
//[SerializeField] GameObject HealthPanel;
//[SerializeField] GameObject HealthBarGreen;
//[SerializeField] GameObject HealthBarRed;
*/

    [Header("Spawner Settings")]
    private int currentNumberOfFarmers;
    private int maxNumberOfFarmers;
    [SerializeField] Transform spawnPostransform;

    public bool canSpawn { get; private set; }
    public bool alert { get; private set; }
    public bool panic { get; private set; }

    [Header ("Spawner Timer")]
    private float spawnTimer = 2f;
    private float spawnTimerCounter;

    void Start()
    {
        
        maxNumberOfFarmers = 5;
        currentNumberOfFarmers = 0;

        canSpawn = true;
        spawnTimer = 2f;

        if (spawnPostransform == null) { spawnPostransform = transform; }   
    }

    
    void Update()
    {
        if (currentNumberOfFarmers >= maxNumberOfFarmers)
        {
            canSpawn = false;
        }

        if (!canSpawn) { return; }
        
        if (alert)
        {
            if (spawnTimerCounter < spawnTimer)
            {
                spawnTimerCounter += Time.deltaTime;
            }
            else { spawnTimerCounter = 0f; Instantiate(Peasant, PickRandomSpot(), Quaternion.identity); currentNumberOfFarmers++; }
             // Debug.Log("i will spawn");
            //Debug.Log(currentNumberOfFarmers);
        }

        

    }


    private Vector3 PickRandomSpot()
    {
        return new Vector3(spawnPostransform.position.x + Random.Range(-15, 15), spawnPostransform.position.y + Random.Range(-15, 15), 0);
    }

    private Vector3 PickRandomFleeingSpot()
    {
        return new Vector3(spawnPostransform.position.x + Random.Range(-25, 25), spawnPostransform.position.y + Random.Range(-25, 25), 0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Farmer"))
        {
            currentNumberOfFarmers++;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            //Debug.Log("Player is detected");
            alert = true;
            
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            alert = false;
        }
        if (collision.gameObject.CompareTag("Farmer"))
        {
            currentNumberOfFarmers--;
        }

    }
}
