using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogBase : MonoBehaviour
{
    private Coroutine currentCoroutine;

    public static event Action SceneIsOver;

    public IEnumerator DisplayLetters(string[] arrayOfText, int currentTXTIndex, TextMeshProUGUI displayTXT, float typeSpeed)
    {
        foreach (char letter in arrayOfText[currentTXTIndex].ToCharArray())
        {
            displayTXT.text += letter;
            yield return new WaitForSeconds(typeSpeed);
        }
    }
    public void NextSentence(string[] arrayOfText, int currentTXTIndex, TextMeshProUGUI dialogToDisplay, float typeSpeed)
    {   if (currentCoroutine != null)
        {
            StopCoroutine(currentCoroutine);
        }

        //StopCoroutine(DisplayLetters(arrayOfText, currentTXTIndex, dialogToDisplay, typeSpeed));
        dialogToDisplay.text = string.Empty;
        currentCoroutine = StartCoroutine(DisplayLetters(arrayOfText, currentTXTIndex, dialogToDisplay, typeSpeed));

    }

    public void BlackScreeen(GameObject dialogPanel)
    {
        SceneIsOver?.Invoke();
        

        dialogPanel.SetActive(false);
        //yield return new WaitForSecondsRealtime(1.25f);
        //gameManager.LoadNextScene();
    }

}
