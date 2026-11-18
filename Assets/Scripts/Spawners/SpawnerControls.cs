using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;
using UnityEditor.Build;

public class SpawnerControls : MonoBehaviour
{
    [SerializeField] GameObject SoldierPrefab;
    [SerializeField] GameObject HorsePrefab;
    [SerializeField] GameObject SorcererPrefab;

    [SerializeField] List<GameObject> SpawnPOS;

    [SerializeField] EnemyNumbers EnemyNumbers;
    [SerializeField] GameManager GameManager;
    [SerializeField] KillsData KillsData;


    public int index;
    private int currentSwordNumber;
    private int currentHorseNumber;
    private int currentSorcererNumber;
    private int currentEnemyNumber;
    private int numberOfEnemySpawned;

    private List<EnemyStateMachine> listOfEnemiesSM = new List<EnemyStateMachine>();

    public bool hasReachedMaxNumber;

    public float timeBeforeSwordSpawn;
    private float spawnSwordTimerCounter;

    public float timeBeforeHorseSpawn;
    private float spawnHorseTimerCounter;

    public float timeBeforeSorcererSpawn;
    private float spawnSorcererTimerCounter;

    [SerializeField] TextMeshProUGUI testingTXT;
    public int nbOfSpawnsFromEvent;

    private void OnEnable()
    {
        Destroyable.OnDeath += countDeath;
        Destroyable.OnSpawn += countSpawn;
    }
    private void OnDisable()
    {
        Destroyable.OnSpawn -= countSpawn;
        Destroyable.OnDeath -= countDeath;
    }

    // Start is called before the first frame update
    void Start()
    {
        index = GameManager.currentWaveNumber;
    }

    // Update is called once per frame
    void Update()
    {
        testingTXT.text = nbOfSpawnsFromEvent.ToString();



        listOfEnemiesSM.Clear();

        listOfEnemiesSM.AddRange(FindObjectsOfType<EnemyStateMachine>());
        currentEnemyNumber = listOfEnemiesSM.Count;
        numberOfEnemySpawned = nbOfSpawnsFromEvent;

        if (numberOfEnemySpawned < EnemyNumbers.PtotalEnemyNumber[index])
        {
            if (currentEnemyNumber < EnemyNumbers.PtotalEnemyNumber[index])
            {
                if (!hasReachedMaxNumber)
                {
                    spawnSwordTimerCounter += Time.deltaTime;
                    spawnHorseTimerCounter += Time.deltaTime;
                    spawnSorcererTimerCounter += Time.deltaTime;

                    if (spawnSwordTimerCounter >= timeBeforeSwordSpawn)
                    {
                        SpawnSoldier();
                        spawnSwordTimerCounter = 0;
                    }
                    if (currentHorseNumber < EnemyNumbers.PhorsesMaxNumber[index])
                    {
                        if (spawnHorseTimerCounter >= timeBeforeHorseSpawn)
                        {
                            SpawnHorse();
                            spawnHorseTimerCounter = 0;
                        }
                    }
                    if (currentSorcererNumber < EnemyNumbers.PsorceresMaxNumber[index])
                    {
                        if (spawnSorcererTimerCounter >= timeBeforeSorcererSpawn)
                        {
                            SpawnSorcerer();
                            spawnSorcererTimerCounter = 0;
                        }
                    }
                }
            }
        }
        else { hasReachedMaxNumber = true;   }



        if (KillsData.killCount >= EnemyNumbers.PtotalEnemyNumber[index])
        {
            if (index < EnemyNumbers.PtotalEnemyNumber.Count-1)
            {
                index += 1;
                nbOfSpawnsFromEvent = 0;
            }
         
            Debug.Log(index);
            hasReachedMaxNumber = false;
            KillsData.killCount = 0;
            KillsData.swordsKillCount=0;
            KillsData.horsesKillCount=0;
            KillsData.sorcerersKillCount=0;
        }
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

    void countDeath(int value)
    {
        Debug.Log("enemy died");
        
    }

    void countSpawn(int value)
    {
        nbOfSpawnsFromEvent += value;
    }
}
