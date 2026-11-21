using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinT1 : MonoBehaviour
{
    [SerializeField] GameObject winPanel;
    [SerializeField] GameObject princessPrefab;

    private GameObject player;

    public bool hasWon;
    public bool hasInstantiated;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (hasWon)
        {
            if (!hasInstantiated)
            {
                Instantiate(princessPrefab, new Vector3(player.transform.position.x + 50f, player.transform.position.y, player.transform.position.z),
                                                    Quaternion.identity);
                hasInstantiated = true;
            }
            
            winPanel.SetActive(true);
            hasWon = false;
        }
    }
}
