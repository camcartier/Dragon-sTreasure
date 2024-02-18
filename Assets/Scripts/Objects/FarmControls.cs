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
    [SerializeField] BuildingsData farmData;

    [Header("Individual Farm Stats")]
    //it's inside FarmData
    //public int farmMaxHealth;
    public int farmCurrentHealth;
    public bool isBurning;
    [SerializeField] GameObject HealthPanel;
    [SerializeField] GameObject HealthBarGreen;
    [SerializeField] GameObject HealthBarRed;

    [Header("ObjectsToSpawn")]
    [SerializeField] GameObject Peasant;
    [SerializeField] GameObject FleeingPeasant;

    [Header("Spawner Settings")]
    public bool canSpawn;
    public int maxNumberOfFarmers;
    public int currentNumberOfFarmers;
    public float spawnTimer = 2f;
    public float spawnTimerCounter = 0f;
    //current values used by code above will be replaced with farmData values

    public bool alert;
    public bool panic;

    
    void Start()
    {
        farmCurrentHealth = farmData.maxHealth;

        maxNumberOfFarmers = 5;
        currentNumberOfFarmers = 0;

        canSpawn = true;
        spawnTimer = 2f;
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
            else { spawnTimerCounter = 0f; Instantiate(Peasant, gameObject.transform); currentNumberOfFarmers++; }
             // Debug.Log("i will spawn");
            Debug.Log(currentNumberOfFarmers);
        }


        if (farmCurrentHealth == farmData.maxHealth)
        {
            HealthPanel.SetActive(false);
        }
        else { HealthPanel.SetActive(true); }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            if (activePlayerData.CurrentLevel < 2)
            {
                farmCurrentHealth -= bulletData.LVL1_bulletDamage;
            }
                
        }
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
            Debug.Log("Player is detected");
            if (collision.gameObject.GetComponent<testPlayer>().playerData.CurrentLevel < 3)
            {
                alert = true;

                Debug.Log("FIGHT");
                //if(!canSpawn)
                //{

                //}

                //if (spawnTimer > spawnTimerCounter)
                //{
                //    spawnTimerCounter += Time.deltaTime;
                //}
                //else
                //{
                //   Instantiate(Peasant, gameObject.transform);
                //    spawnTimerCounter = 0;
                //}
            }
            else { Debug.Log("HAAAAAAA"); panic = true; }
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
