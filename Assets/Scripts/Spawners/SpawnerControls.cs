using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
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

    public float timeBeforeSwordSpawn;
    private float spawnSwordTimerCounter;

    public float timeBeforeHorseSpawn;
    private float spawnHorseTimerCounter;

    public float timeBeforeSorcererSpawn;
    private float spawnSorcererTimerCounter;

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
            spawnSwordTimerCounter += Time.deltaTime;
            spawnHorseTimerCounter += Time.deltaTime;
            spawnSorcererTimerCounter += Time.deltaTime;

            if (spawnSwordTimerCounter >= timeBeforeSwordSpawn)
            {
                SpawnSoldier();
                spawnSwordTimerCounter = 0;
            }

            if(currentHorseNumber < EnemyNumbers.horsesMaxNumber[index])
            {
                if(spawnHorseTimerCounter >= timeBeforeHorseSpawn)
                {
                    SpawnHorse();
                    spawnHorseTimerCounter = 0;
                }
            }

            if (currentSorcererNumber < EnemyNumbers.sorceresMaxNumber[index])
            {
                if (spawnSorcererTimerCounter >= timeBeforeSorcererSpawn)
                {
                    SpawnSorcerer();
                    spawnSorcererTimerCounter = 0;
                }
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

    void SpawnHorse()
    {
        int index = Random.Range(0, 2);
        Instantiate (HorsePrefab, new Vector2(SpawnPOS[index].transform.position.x,
                                                 SpawnPOS[index].transform.position.y + Random.Range(-300, 300)), Quaternion.identity);
    }

    void SpawnSorcerer()
    {
        int index = Random.Range(0, 2);
        Instantiate(SorcererPrefab, new Vector2(SpawnPOS[index].transform.position.x,
                                                 SpawnPOS[index].transform.position.y + Random.Range(-300, 300)), Quaternion.identity);
    }
}
