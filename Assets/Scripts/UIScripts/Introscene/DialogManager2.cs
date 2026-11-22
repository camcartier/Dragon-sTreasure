using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;
using UnityEngine.Timeline;
using UnityEngine.Playables;
public class DialogManager2 : MonoBehaviour
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
    [SerializeField] GameObject blackPanel;
    [SerializeField] Animator animator;

    [SerializeField] GameObject yesButton;
    [SerializeField] GameObject noButton;
    [SerializeField] GameObject continueButton;

    [SerializeField] PlayableDirector timeline2;

    //same for everyone
    [SerializeField] AudioSource speakingSound;
    [SerializeField] TypewritterEffect typewritterEffect;

    private int index;
    private Coroutine currentCoroutine;
    void Start()
    {
        portraitToDisplay.sprite = portraits[0];
        titleToDisplay.text = titles[0];
        //dialogToDisplay.text = sentences[0];
        //gameManager.PauseGame();


        dialogToDisplay.text = string.Empty;
        //typewritterEffect.StartCoroutine(typewritterEffect.DisplayLetters(sentences, index, dialogToDisplay));
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

        if (index == 2)
        {
            yesButton.SetActive(true);
            noButton.SetActive(true);
            continueButton.SetActive(false);
        }
        else
        {
            yesButton.SetActive(false);
            noButton.SetActive(false);
            continueButton.SetActive(true);
        }

        if (index < 10)
        {

            index += 1;
            //typewritterEffect.StartCoroutine(typewritterEffect.DisplayLetters(sentences, index, dialogToDisplay));
            StartSentence();
        }
        else if (index == 10)
        {
            //speakingSound.Stop();
            //gameManager.UnPauseGame();
            StartCoroutine(NextSceneWithBlackScreeen());
        }

    }

    public void AnsweredNo()
    {
        gameManager.UnPauseGame();
        dialogPanel.SetActive(false);
        timeline2.Play();
    }

    private IEnumerator NextSceneWithBlackScreeen()
    {
        blackPanel.SetActive(true);
        animator.Play("fadeIn");
        yield return new WaitForSecondsRealtime(1.25f);
        gameManager.LoadNextScene();
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
