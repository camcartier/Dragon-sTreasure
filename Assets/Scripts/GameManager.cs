using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //[SerializeField] TreasureData treasureData;

    [Header("Testing")]
    public float TimerCounter;
    public float TimeBeforeIncrement = 3f;

    [Header("Panel")]
    public GameObject DeathPanel;
    public GameObject PausePanel;
    public GameObject HeaderPanel;
    public GameObject AbilitiesPanel;
    public GameObject KillsPanel;

    public bool isPaused;

    [Header ("Scriptables")]
    [SerializeField] PlayerCurrentHealthAndMana currentPlayerHealthAndMana;
    [SerializeField] PlayerData playerData;
    [SerializeField] KillsData killCount;
    [SerializeField] GoldData goldData;

    public GameObject player;

    public int currentWaveNumber;

    private void Awake()
    {
        //currentWaveNumber = 1;

        currentPlayerHealthAndMana.currentHealth = playerData.MaxHealth;
        killCount.killCount = 0;
        killCount.swordsKillCount = 0;
        killCount.horsesKillCount = 0;
        killCount.sorcerersKillCount = 0;
        goldData.goldCount = 0;

        player = GameObject.Find("Player");

        PausePanel.SetActive(false);
        HeaderPanel.SetActive(true);
        AbilitiesPanel.SetActive(true);
        KillsPanel.SetActive(true);
    }

    // Start is called before the first frame update
    void Start()
    {


        if(SceneManager.GetActiveScene().buildIndex > 1)
        {
            if (player.GetComponent<PlayerStateMachine>().isDead)
            {
                player.GetComponent<PlayerStateMachine>().isDead = false;
            }
        }

        UnPauseGame();
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!isPaused)
            {
                PauseGame();
                ActivateDeactivatePauseMenu();
                isPaused = true;
            }
            else { UnPauseGame(); ActivateDeactivatePauseMenu(); isPaused = false; }

        }

        killCount.killCount = killCount.swordsKillCount + killCount.horsesKillCount + killCount.sorcerersKillCount;


    }

    public void SetActiveDeathPanel()
    {
        DeathPanel.SetActive(true);
        HeaderPanel.SetActive(false);
        AbilitiesPanel.SetActive(false);
        KillsPanel.SetActive(false);
    }

    public void ActivateDeactivatePauseMenu()
    {
        if (!PausePanel.activeInHierarchy == true)
        {
            PausePanel.SetActive(true);
        }
        else
        {
            PausePanel.SetActive(false);
        }
    }


    public void PauseGame()
    {
        Time.timeScale = 0f;
    }
    public void UnPauseGame()
    {
        Time.timeScale = 1f;
    }

    public void LoadNextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
