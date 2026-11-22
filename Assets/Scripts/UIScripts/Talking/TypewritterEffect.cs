using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TypewritterEffect : MonoBehaviour
{
    public float typeSpeed;
    public IEnumerator DisplayLetters(string[] arrayOfText, int currentTXTIndex, TextMeshProUGUI displayTXT)
    {



        foreach (char letter in arrayOfText[currentTXTIndex].ToCharArray())
        {
            displayTXT.text += letter;
            yield return new WaitForSeconds(typeSpeed);
        }


    }
}
