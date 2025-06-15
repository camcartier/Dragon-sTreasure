using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] TreasureData treasureData;

    [Header("Testing")]
    public float TimerCounter;
    public float TimeBeforeIncrement = 3f;

    [Header("Panel")]
    public GameObject DeathPanel;

    [SerializeField] PlayerCurrentHealthAndMana currentPlayerHealthAndMana;
    [SerializeField] PlayerData playerData;
    public GameObject player;

    private void Awake()
    {
        treasureData.GoldCount = 1;

        currentPlayerHealthAndMana.currentMana = playerData.MaxMana;
        currentPlayerHealthAndMana.currentHealth = playerData.MaxHealth;
        
        player = GameObject.Find("Player");

        //currentPlayerData = GameObject.Find("ScriptableObjectsManager").GetComponent<ScriptableGestionnaire>().PlayerCurrentHealthAndMana;
        //playerData = GameObject.Find("ScriptableObjectsManager").GetComponent<ScriptableGestionnaire>().PlayerData;
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



    }

    public void SetActiveDeathPanel()
    {
        DeathPanel.SetActive(true);
    }

    public void SetActivePauseMenu()
    {
        //not yet implemented
    }
    public void RestartCurrent()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
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
}
