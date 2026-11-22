using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;
using UnityEngine.Timeline;
using UnityEngine.Playables;
public class DialogManager3 : MonoBehaviour
{
    [SerializeField] Sprite[] portraits = new Sprite[5];
    [SerializeField] string[] titles = new string[5];
    [SerializeField] string[] sentences = new string[5];
    
    [SerializeField] Image portraitToDisplay;
    [SerializeField] TextMeshProUGUI titleToDisplay;
    [SerializeField] TextMeshProUGUI dialogToDisplay;

    [SerializeField] GameObject dialogPanel;
    //[SerializeField] PlayableDirector timeline;
    [SerializeField] GameManager gameManager;

    //same for everyone
    [SerializeField] AudioSource speakingSound;
    [SerializeField] TypewritterEffect typewritterEffect;

    private int index;
    private Coroutine currentCoroutine;
    void Start()
    {
        dialogToDisplay.text = string.Empty;

        portraitToDisplay.sprite = portraits[0];
        titleToDisplay.text = titles[0];
        //dialogToDisplay.text = sentences[0];
        //gameManager.PauseGame();
        StartSentence();
    }


    void Update()
    {
        //Debug.Log(index);
        portraitToDisplay.sprite = portraits[index];
        titleToDisplay.text = titles[index];
        //dialogToDisplay.text = sentences[index];
    }

    public void NextSentence()
    {
        //speakingSound.Stop();
        //speakingSound.Play();

        StopCoroutine(typewritterEffect.DisplayLetters(sentences, index, dialogToDisplay));
        dialogToDisplay.text = string.Empty;

        if (index < 3)
        {
            index += 1;
            StartSentence();
        }
        else if (index == 3)
        {

            dialogPanel.SetActive(false);
            //speakingSound.Stop();
        }

    }



    void StartSentence()
    {
        if (currentCoroutine != null)
        {
            typewritterEffect.StopCoroutine(currentCoroutine);
        }

        dialogToDisplay.text = string.Empty;
        currentCoroutine = typewritterEffect.StartCoroutine(typewritterEffect.DisplayLetters(sentences, index, dialogToDisplay));
    }
}
