using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SpawnerControls : MonoBehaviour
{
    [SerializeField] GameObject SoldierPrefab;
    [SerializeField] GameObject HorsePrefab;
    [SerializeField] GameObject SorcererPrefab;

    [SerializeField] List<GameObject> SpawnPOS;


    public EnemyNumbers EnemyNumbers;
    public GameManager GameManager;

    private int index;
    private int currentSwordNumber;
    private int currentHorseNumber;
    private int currentSorcererNumber;
    private int currentEnemyNumber;

    private List<EnemyStateMachine> listOfEnemiesSM = new List<EnemyStateMachine>();

    public float timeBeforeSpawn;
    private float spawnTimerCounter;

    // Start is called before the first frame update
    void Start()
    {
        index = GameManager.currentSelectedLoverIndex;
    }

    // Update is called once per frame
    void Update()
    {
        listOfEnemiesSM.Clear();

        listOfEnemiesSM.AddRange(FindObjectsOfType<EnemyStateMachine>());
        currentEnemyNumber = listOfEnemiesSM.Count;

        if (currentEnemyNumber < EnemyNumbers.totalEnemyNumber[index])
        {
            spawnTimerCounter += Time.deltaTime;

            if (spawnTimerCounter >= timeBeforeSpawn)
            {
                SpawnSoldier();
                spawnTimerCounter = 0;
            }
        }

        /* plantage
    while (currentEnemyNumber < EnemyNumbers.totalEnemyNumber[index])
    {
        spawnTimerCounter += Time.deltaTime;

        if (spawnTimerCounter > timeBeforeSpawn) 
        {
            SpawnSoldier();
            currentEnemyNumber++;
            spawnTimerCounter = 0;
        }
    }
        */
    }

    void SpawnSoldier()
    {
        int index = Random.Range(0, 2);

        Instantiate(SoldierPrefab, new Vector2 (SpawnPOS[index].transform.position.x,
                                                 SpawnPOS[index].transform.position.y + Random.Range(-300,300)), Quaternion.identity);
        Instantiate(SoldierPrefab, new Vector2 (SpawnPOS[2].transform.position.x + Random.Range(-300, 300),
                                               SpawnPOS[2].transform.position.y), Quaternion.identity);
    }
}
