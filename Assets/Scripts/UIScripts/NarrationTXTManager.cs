using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NarrationTXTManager : MonoBehaviour
{
    public string[] arrayOfText = new string[6];
    [SerializeField] TextMeshProUGUI textToRead;
    private int currentTXTIndex;

    public GameObject[] arrayOfBGImages = new GameObject[6];

    // Start is called before the first frame update
    void Start()
    {
        currentTXTIndex = 0;
    }

    // Update is called once per frame
    void Update()
    {
        textToRead.text = arrayOfText[currentTXTIndex];
    }

    public void IncrementIndex()
    {
        currentTXTIndex += 1;
    }
}
