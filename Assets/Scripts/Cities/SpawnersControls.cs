using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnersControls : MonoBehaviour
{

    //public GameObject[] prefabsToSpawn = new GameObject[10];
    //public GameObject[] SpawnPoints = new GameObject[10];

    [SerializeField] GameObject testingPrefab;

    public List<GameObject> ListOfPrefabs = new List<GameObject>();
    public List<GameObject> ListOfSpwanPoints = new List<GameObject>();

    public List<GameObject> ListOfLeftSpawnPoints = new List<GameObject>();
    public List<GameObject> ListOfRightSpawnPoints = new List<GameObject>();


    [Header("Spawn Stats")]
    public float delayBetweenSpawns;
    public bool hasStartedSpawning;
    private float spawnTimerCounter;
    public float spawnMultiplier;


    [Header("numbers")]
    public int numberOfPrefabs;
    //public int numberOfSpawnPoints;
    public int numberOfLeftSpawnPoints;
    public int numberOfRightSpawnPoints;

    private GameObject player;



    void Start()
    {
        numberOfPrefabs = ListOfPrefabs.Count;
        numberOfLeftSpawnPoints = ListOfLeftSpawnPoints.Count;
        numberOfRightSpawnPoints = ListOfRightSpawnPoints.Count;

        spawnTimerCounter = delayBetweenSpawns;
        spawnMultiplier = 1f;


        player = GameObject.Find("Player");

    }

    void Update()
    {
        if (hasStartedSpawning)
        {
            
            if(spawnTimerCounter >= delayBetweenSpawns * spawnMultiplier)
            {
                SpawnEnemies();
                spawnTimerCounter = 0f;
            }
            else
            {
                spawnTimerCounter += Time.deltaTime;
            }



        }

    }

    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("spawner sees you");
            if (!hasStartedSpawning)
            {

                hasStartedSpawning = true;


                //InvokeRepeating(nameof(SpawnEnemies), 0, delayBetweenSpawns); hasStartedSpawning = true;
            }

        }
    }
    
    
    private void SpawnEnemies()
    {
        //congrats it works
        if (Mathf.Sign(gameObject.transform.position.x - player.transform.position.x) > 0)
        {
            int randomNumberForSpawner = Random.Range(0, numberOfLeftSpawnPoints);
            Instantiate(testingPrefab, new Vector2(ListOfLeftSpawnPoints[randomNumberForSpawner].transform.position.x, ListOfLeftSpawnPoints[randomNumberForSpawner].transform.position.y), Quaternion.identity);
        }
        else {
            int randomNumberForSpawner = Random.Range(0, numberOfRightSpawnPoints);
            Instantiate(testingPrefab, new Vector2(ListOfRightSpawnPoints[randomNumberForSpawner].transform.position.x, ListOfRightSpawnPoints[randomNumberForSpawner].transform.position.y), Quaternion.identity);
        }

        /*if (Mathf.Sign(gameObject.transform.position.y - player.transform.position.y) > 0)
        {
            directionY = -1;
        }
        else { directionY = 1; }*/

        //int randomNumberForSpawner = Random.Range(0, numberOfSpawnPoints);
        //Instantiate(testingPrefab, new Vector2(ListOfSpwanPoints[randomNumberForSpawner].transform.position.x, ListOfSpwanPoints[randomNumberForSpawner].transform.position.y), Quaternion.identity);
    }
    
}
