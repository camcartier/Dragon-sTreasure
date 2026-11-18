using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Analytics;

public class DemonessPanelManager : MonoBehaviour
{
    [SerializeField] string[] sentences = new string[5];
    [SerializeField] TextMeshProUGUI displayedText;
    [SerializeField] GameObject dialogPanel;
    [SerializeField] GameObject yesButton;
    [SerializeField] GameObject noButton;
    [SerializeField] GameObject continueButton;

    [SerializeField] PlayerCurrentHealthAndMana playerCurrentHealth;
    [SerializeField] PlayerData playerData;
    [SerializeField] GameManager gameManager;

    [SerializeField] GoldData goldData;

    private GameObject demonessInScene;

    private int index;
    private bool hasRefused;

    // Start is called before the first frame update
    void Start()
    {
        displayedText.text = sentences[0];
        demonessInScene = GameObject.Find("Demoness(Clone)");
    }

    // Update is called once per frame
    void Update()
    {
        displayedText.text = sentences[index];
    }

    public void SkipOneSentence()
    {
        index += 2;
        yesButton.SetActive(false);
        noButton.SetActive(false);
        continueButton.SetActive(true);
        hasRefused = true;
    }

    public void noOption()
    {
        dialogPanel.SetActive(false);
        gameManager.UnPauseGame();
        Destroy(demonessInScene);
    }

    public void yesOption()
    {
        index = 2;
        playerCurrentHealth.currentHealth = playerData.MaxHealth;
        yesButton.SetActive(false);
        noButton.SetActive(false);
        continueButton.SetActive(true);
    }

    public void NextSentence()
    {
        index += 1;
        if (index == 1 )
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

        




        //end dialog
        if (index == 4)
        {
            dialogPanel.SetActive(false);
            gameManager.UnPauseGame();
            Destroy(demonessInScene);
        }
    }



    public void EndDialog()
    {
        dialogPanel.SetActive(false);

        if (!hasRefused)
        {
            playerCurrentHealth.currentHealth = playerData.MaxHealth;
        }
    }
}
