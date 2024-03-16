using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossYakkuruSpawner : MonoBehaviour
{
    private YakkuruControls[] ActiveYakkuruArray;
    private int storedYakkurusNumber;
    [SerializeField] GameObject yakkuruBoss;
    [SerializeField] GameObject player;
    public int YakkurusKilled { get; set; }
    public bool HasSpawned { get; private set; }

    // Start is called before the first frame update
    void Start()
    {
        ActiveYakkuruArray = FindObjectsOfType<YakkuruControls>();
        storedYakkurusNumber = ActiveYakkuruArray.Length;
    }

    // Update is called once per frame
    void Update()
    {
        if (YakkurusKilled > storedYakkurusNumber / 2)
        {
            if(!HasSpawned)
            Instantiate(
                yakkuruBoss, 
                new Vector3 (player.transform.position.x -100, player.transform.position.y, 0), 
                Quaternion.identity);
            HasSpawned = true;
        }
    }
}
