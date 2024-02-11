using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.Experimental.RestService;
using UnityEngine;

public class FarmControls : MonoBehaviour
{
    //[Header("ScriptableObjects")]
    //[SerializeField] PlayerData ActivePlayerData;

    [Header("ObjectsToSpawn")]
    [SerializeField] GameObject Peasant;
    [SerializeField] GameObject FleeingPeasant;

    [Header("Spawner Settings")]
    public bool canSpawn;
    public int maxNumberOfFarmers;
    public int currentNumberOfFarmers;
    public float spawnTimer = 2f;
    public float spawnTimerCounter = 0f;

    public bool alert;
    public bool panic;

    // Start is called before the first frame update
    void Start()
    {
        maxNumberOfFarmers = 5;
        currentNumberOfFarmers = 0;

        canSpawn = true;
        spawnTimer = 2f;
    }

    // Update is called once per frame
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
            if (collision.gameObject.GetComponent<testPlayer>().playerData.Level < 3)
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
