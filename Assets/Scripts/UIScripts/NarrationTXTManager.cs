using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class NarrationTXTManager : MonoBehaviour
{
    public string[] arrayOfText = new string[6];
    [SerializeField] TextMeshProUGUI textToRead;
    private int currentTXTIndex;
    [SerializeField] GameObject startImage;
    [SerializeField] AudioSource paperAudio;

    public GameObject[] arrayOfBGImages = new GameObject[6];

    //[SerializeField] EndButton

    // Start is called before the first frame update
    void Start()
    {
        currentTXTIndex = 0;

        if (startImage.activeInHierarchy == false)
        {
            startImage.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        textToRead.text = arrayOfText[currentTXTIndex];

        if (currentTXTIndex > 0)
        {
            if (arrayOfBGImages[currentTXTIndex].activeInHierarchy == false)
            {
                arrayOfBGImages[currentTXTIndex].SetActive(true);
            }
        }

    }

    public void IncrementIndex()
    {
        if (currentTXTIndex < arrayOfBGImages.Length -1)
        {
            currentTXTIndex += 1; 
        }
        else 
        { 
            currentTXTIndex = arrayOfBGImages.Length - 1;
            LoadGameScene();
            //dans une fonction comme ça on pourra personnaliser plus tard
        }

        paperAudio.Play();
    }


    private void LoadGameScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
