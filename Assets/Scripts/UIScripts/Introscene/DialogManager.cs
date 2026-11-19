using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;
using UnityEngine.Timeline;
using UnityEngine.Playables;
public class DialogManager : MonoBehaviour
{
    [SerializeField] Sprite[] portraits = new Sprite[5];
    [SerializeField] string[] titles = new string[5];
    [SerializeField] string[] sentences = new string[5];
    
    [SerializeField] Image portraitToDisplay;
    [SerializeField] TextMeshProUGUI titleToDisplay;
    [SerializeField] TextMeshProUGUI dialogToDisplay;

    [SerializeField] GameObject dialogPanel;
    [SerializeField] PlayableDirector timeline;
    [SerializeField] GameManager gameManager;

    private int index;

    void Start()
    {
        portraitToDisplay.sprite = portraits[0];
        titleToDisplay.text = titles[0];
        dialogToDisplay.text = sentences[0];
        gameManager.PauseGame();
    }


    void Update()
    {
        //Debug.Log(index);
        portraitToDisplay.sprite = portraits[index];
        titleToDisplay.text = titles[index];
        dialogToDisplay.text = sentences[index];
    }

    public void NextSentence()
    {
  

        if (index < 3)
        {
            index += 1;
        }
        else
        {
            dialogPanel.SetActive(false);
            gameManager.UnPauseGame();
            timeline.Play();
        }
    }
}
