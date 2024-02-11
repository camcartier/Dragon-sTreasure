using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class TasDor : MonoBehaviour
{
    [Header("Data")]
    [SerializeField] TreasureData treasureData;

    [Header ("Visuals")]
    [SerializeField] GameObject Tas1;
    [SerializeField] GameObject Tas2;
    [SerializeField] GameObject Tas3;
    [SerializeField] GameObject Tas4;
    [SerializeField] GameObject Tas5;

    private CircleCollider2D DetectorTrigger;

    private void Awake()
    {
        DetectorTrigger = GameObject.Find("DetectionCircle").GetComponent<CircleCollider2D>();
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
        if (treasureData.GoldCount > 10)
        {
            Tas2.SetActive (true);
            Tas1.SetActive(false);
            DetectorTrigger.radius = 4f;
        }
        if (treasureData.GoldCount > 50)
        {
            Tas3.SetActive (true);
            Tas2.SetActive(false);
            DetectorTrigger.radius = 8f;
        }
        if (treasureData.GoldCount > 100)
        {
            Tas4.SetActive (true);
            Tas3.SetActive(false);
            DetectorTrigger.radius = 16f;
        }
        if (treasureData.GoldCount > 500)
        {
            Tas5.SetActive (true);
            Tas4.SetActive(false);
            DetectorTrigger.radius = 32f;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Thief"))
        {

        }
        
    }
}
