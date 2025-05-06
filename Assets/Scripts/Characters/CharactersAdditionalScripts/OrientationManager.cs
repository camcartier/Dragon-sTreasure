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

    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {


        /*
        if (player.transform.position.x > gameObject.transform.position.x)
        {
            gameObject.transform.localScale = new Vector3(-1, 1, 1);
        }
        else { gameObject.transform.localScale = new Vector3(1, 1, 1); }
        */



    }

    public void TurnTowardsPlayer()
    {
        if (player.transform.position.x > gameObject.transform.position.x)
        {
            gameObject.transform.localScale = new Vector3(-1, 1, 1);
        }
        else { gameObject.transform.localScale = new Vector3(1, 1, 1); }
    }

}
