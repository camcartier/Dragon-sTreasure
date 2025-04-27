using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Playables;

public class OrientationManager : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] ObjectsData characterData;
    [SerializeField] GameObject healthCanvas;
    private float turnDelayCounter;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (characterData.canTurn)
        {

            if (Mathf.Abs(player.transform.position.x) - Mathf.Abs(gameObject.transform.position.x) > 0)
            {
                if (turnDelayCounter < characterData.timeBeforeTurn)
                {
                    turnDelayCounter += Time.deltaTime;
                }
                else { gameObject.transform.localScale = new Vector3(-1, 1, 1); turnDelayCounter = 0f; healthCanvas.transform.localScale = new Vector3(-1, 1, 1); }
            }

            if (Mathf.Abs(player.transform.position.x) - Mathf.Abs(gameObject.transform.position.x) < 0)
            {
                if (turnDelayCounter < characterData.timeBeforeTurn)
                {
                    turnDelayCounter += Time.deltaTime;
                }
                else { gameObject.transform.localScale = new Vector3(1, 1, 1); turnDelayCounter = 0f; healthCanvas.transform.localScale = new Vector3(1, 1, 1); }
            }


            /*
            if (player.transform.position.x > gameObject.transform.position.x)
            {
                if (turnDelayCounter < characterData.timeBeforeTurn)
                {
                    turnDelayCounter += Time.deltaTime;
                }
                else { gameObject.transform.localScale = new Vector3(-1, 1, 1); turnDelayCounter = 0f; healthCanvas.transform.localScale = new Vector3(-1, 1, 1); }
            }
            
            if (player.transform.position.x < gameObject.transform.position.x)
            {
                if (turnDelayCounter < characterData.timeBeforeTurn)
                {
                    turnDelayCounter += Time.deltaTime;
                }
                else { gameObject.transform.localScale = new Vector3(1, 1, 1); turnDelayCounter = 0f; healthCanvas.transform.localScale = new Vector3(1, 1, 1); }
            }
            */
        }


    }
}
