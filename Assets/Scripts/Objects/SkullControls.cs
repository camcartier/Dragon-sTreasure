using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SkullControls : MonoBehaviour
{
    //private Rigidbody2D rbSkull;
    private PlayerStateMachine PlayerStateMachine;
    private TextMeshPro UsingText;

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
        if (UsingText.gameObject.activeInHierarchy == true)
        {
            Debug.Log("yoooo");
        }
        else { Debug.Log("ayyyy"); }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            UsingText.gameObject.SetActive(true);
            Debug.Log("Player is in range");

            if (PlayerStateMachine.isUsing) { Debug.Log("Player is using"); }
        }
    }

}
