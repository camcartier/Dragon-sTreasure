using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class StartControls : MonoBehaviour
{
    [SerializeField] GameObject MenuButtonsPanel;

    
    void Start()
    {
        
    }

    
    void Update()
    {
        
    }

    private void LoadGameScene()
    {
        SceneManager.LoadScene("GameScene");
    }
    private void LoadNextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    private void QuitGame()
    {
        Application.Quit();
    }
}
