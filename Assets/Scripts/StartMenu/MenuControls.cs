using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class MenuControls : MonoBehaviour
{
    //[SerializeField] GameObject MenuButtonsPanel;
    [SerializeField] GameObject CreditsPanel;
    [SerializeField] GameObject OptionsPanel;

    [SerializeField] Animator blackScreenAnimator;
    [SerializeField] GameObject blackScreen;
    void Start()
    {
        StartCoroutine(FadeToTransparent());
    }

    private void OnDisable()
    {
        StopAllCoroutines();
    }

    void Update()
    {
        
    }
    public void OpenHideCredits()
    {
        if (CreditsPanel != null)
        {
            if (CreditsPanel.activeInHierarchy == true)
            {
                CreditsPanel.SetActive(false);
            }
            else { CreditsPanel.SetActive(true); }
        }
    }
    public void OpenHideOptions()
    {
        if (OptionsPanel != null)
        {
            if (OptionsPanel.activeInHierarchy == true)
            {
                OptionsPanel.SetActive(false);
            }
            else { OptionsPanel.SetActive(true); }
        }
    }
    public void LoadGameScene()
    {
        SceneManager.LoadScene("GameScene");
    }
    public void LoadNextScene()
    {
        StartCoroutine(FadeToBlack());
        
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    IEnumerator FadeToBlack()
    {
        blackScreen.SetActive(true);
        blackScreenAnimator.Play("fadeIn");
        yield return new WaitForSecondsRealtime(1.25f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    IEnumerator FadeToTransparent()
    {
        blackScreenAnimator.Play("fadeOut");
        yield return new WaitForSecondsRealtime(1.25f);
        blackScreen.SetActive(false);
    }
}
