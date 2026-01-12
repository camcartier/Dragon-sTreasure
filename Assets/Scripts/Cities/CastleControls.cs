using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CastleControls : MonoBehaviour
{
    [SerializeField] GameObject ShieldSoldier;
    [SerializeField] GameObject SwordSoldier;

    [SerializeField] GameObject SpawnPoint;

    private GameObject player;
    [SerializeField] PlayerData playerData;

    private bool isSpawing;
    public float timeBeforeNextSpawn;

    void Start()
    {
        player = GameObject.Find("Player");
    }

    
    void Update()
    {
        if(playerData.currentLevel > 3)
        {
            InvokeRepeating(nameof(SpawnSoldier), 0, timeBeforeNextSpawn);
        }
    }

    private void SpawnSoldier()
    {
        Debug.Log("+1soldier");
        Instantiate(SwordSoldier, new Vector2(SpawnPoint.transform.position.x, SpawnPoint.transform.position.y), Quaternion.identity);
    }
}
