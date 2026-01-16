using System.Collections;
using System.Collections.Generic;
using System.Runtime.ExceptionServices;
using UnityEngine;
using UnityEngine.Rendering;

public class TasDor : MonoBehaviour
{
    [Header("Data")]
    [SerializeField] TreasureData treasureData;
    [SerializeField] PlayerData playerData;

    [Header ("Visuals")]

    public GameObject[] StepArrayGameObjects = new GameObject[5];
    public int CurrentSpriteNumber;

    private CircleCollider2D DetectorTrigger;

    private void Awake()
    {
        DetectorTrigger = GameObject.Find("DetectionCircle").GetComponent<CircleCollider2D>();

        CurrentSpriteNumber = playerData.currentLevel;
        StepArrayGameObjects[CurrentSpriteNumber].SetActive(true);

        /*
        for (int i = 1; i < StepArrayGameObjects.Length; i++)
        {
            StepArrayGameObjects[i].SetActive(false);
        }
        */

    }

    // Start is called before the first frame update
    void Start()
    {
        if(!treasureData)
        {
            Debug.Log("no treasure Data");
        }

    }

    // Update is called once per frame
    void Update()
    {

        if (treasureData.CurrentStep != CurrentSpriteNumber)
        {
            StepArrayGameObjects[treasureData.CurrentStep].SetActive(true);
            StepArrayGameObjects[CurrentSpriteNumber].SetActive(false);
            CurrentSpriteNumber += 1;
        }


    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Thief"))
        {
            Debug.Log("uuuuhhhhrrrr");
        }
        
    }
}
