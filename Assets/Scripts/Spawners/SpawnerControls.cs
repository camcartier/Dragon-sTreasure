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

    [SerializeField] EnemyNumbers EnemyNumbers;
    [SerializeField] GameManager GameManager;
    [SerializeField] KillsData KillsData;


    public int index;
    private int currentSwordNumber;
    private int currentHorseNumber;
    private int currentSorcererNumber;
    private int currentEnemyNumber;

    private List<EnemyStateMachine> listOfEnemiesSM = new List<EnemyStateMachine>();

    public bool hasReachedMaxNumber;

    public float timeBeforeSwordSpawn;
    private float spawnSwordTimerCounter;

    public float timeBeforeHorseSpawn;
    private float spawnHorseTimerCounter;

    public float timeBeforeSorcererSpawn;
    private float spawnSorcererTimerCounter;

    private void OnEnable()
    {
        Destroyable.OnDeath += countDeath;
    }
    private void OnDisable()
    {
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
        

        listOfEnemiesSM.Clear();

        listOfEnemiesSM.AddRange(FindObjectsOfType<EnemyStateMachine>());
        currentEnemyNumber = listOfEnemiesSM.Count;


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
        else { hasReachedMaxNumber = true;  }



        if (KillsData.killCount >= EnemyNumbers.PtotalEnemyNumber[index])
        {
            index += 1;
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
}
