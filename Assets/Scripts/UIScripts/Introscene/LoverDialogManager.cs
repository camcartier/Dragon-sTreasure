using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class LoverDialogManager : DialogBase
{
    [SerializeField] DialogScriptable dialogScriptable;
    [SerializeField] TextMeshProUGUI textToDisplay;
    [SerializeField] Image portraitToDisplay;
    [SerializeField] TextMeshProUGUI titleToDisplay;

    [SerializeField] GameObject blackPanel;
    [SerializeField] Animator blackPanelAnimator;
    [SerializeField] GameManager gameManager;
    [SerializeField] GameObject dialogPanel;

    public int index;

    // Start is called before the first frame update
    void Start()
    {
        portraitToDisplay.sprite = dialogScriptable.portraits[0];
        titleToDisplay.text = dialogScriptable.titles[0];
        NextSentence(dialogScriptable.sentences, index, textToDisplay, dialogScriptable.typeSpeed);
    }

    // Update is called once per frame
    void Update()
    {
        portraitToDisplay.sprite = dialogScriptable.portraits[index];
        titleToDisplay.text = dialogScriptable.titles[index];
    }

    public void DisplayNextSentence()
    {
        if (index == dialogScriptable.sentences.Length-1)
        {
            
            BlackScreeen(dialogPanel);
            return;
        }
        index += 1;
        NextSentence(dialogScriptable.sentences, index, textToDisplay, dialogScriptable.typeSpeed);
        
    }
}
