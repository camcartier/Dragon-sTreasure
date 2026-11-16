using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class MenuControls : MonoBehaviour
{
    //[SerializeField] GameObject MenuButtonsPanel;

    
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
    public void LoadNextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
