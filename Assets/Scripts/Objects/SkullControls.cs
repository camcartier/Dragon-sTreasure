using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SkullControls : MonoBehaviour
{
    //private Rigidbody2D rbSkull;
    private PlayerStateMachine PlayerStateMachine;
    private TextMeshPro UsingText;

    [SerializeField] GameObject GoldDug;
    private bool hasInstantiated;

    //[SerializeField] TreasureData TotalGoldCount;

    // Start is called before the first frame update
    void Start()
    {
        PlayerStateMachine = GameObject.Find("Player").GetComponent<PlayerStateMachine>();
        UsingText = gameObject.GetComponentInChildren<TextMeshPro>();
        UsingText.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if (UsingText.gameObject.activeInHierarchy == true)
        {
            Debug.Log("yoooo");
        }
        else { Debug.Log("ayyyy"); }
        */

        if (hasInstantiated)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            UsingText.gameObject.SetActive(true);
            Debug.Log("Player is in range");


            //if (collision.gameObject.GetComponentInChildren<PlayerStateMachine>() == null) { Debug.Log("notfound"); }

        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (PlayerStateMachine.isUsing && !hasInstantiated)
        {
            Debug.Log("GGGGG");
            Instantiate(GoldDug, transform.position, Quaternion.identity);
            hasInstantiated = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            UsingText.gameObject.SetActive(false);
        }
    }

    /*
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (PlayerStateMachine.isUsing)
        {
            Debug.Log("GGGGG");
            Instantiate(GoldDug);
        }
    }
    */

}
