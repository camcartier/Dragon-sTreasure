using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemonessControls : MonoBehaviour
{
    private GameManager gameManager;
    private DemonessPanelTag demonessPanelTag;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

        demonessPanelTag = FindObjectOfType<DemonessPanelTag>(true);
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            gameManager.PauseGame();
            demonessPanelTag.gameObject.SetActive(true);
        }
    }
}
