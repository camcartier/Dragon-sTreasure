using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class HeartsManager : MonoBehaviour
{
    public GameObject[] hearts = new GameObject[10];
    public GameObject[] emptyHearts = new GameObject[5];
    [SerializeField] PlayerCurrentHealthAndMana playerCurrentHealth;
    [SerializeField] PlayerData playerData;

    void Start()
    {
        for (int i = 0; i < playerData.MaxHealth / 2; i++)
        {
            emptyHearts[i].SetActive(true);
        }

        UpdateHearts();
    }

    void Update()
    {
        UpdateHearts();
    }

    void UpdateHearts()
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            // Le cœur est actif seulement si son index est inférieur à la vie actuelle
            hearts[i].SetActive(i < playerCurrentHealth.currentHealth);
        }
    }

    /*
    void Start()
    {


        for (int i = 0; i < playerData.MaxHealth / 2; i++)
        {
            emptyHearts[i].SetActive(true);
            
        }

        
        for (int i = 0; i < playerCurrentHealth.currentHealth; i++)
        {
            hearts[i].SetActive(true);
        }




    }

    void Update()
    {
        for (int i = hearts.Length-1; i >= playerCurrentHealth.currentHealth; i--)
        {
            if (i < 0 || i >= hearts.Length)
            {
                Debug.LogError("OUT OF BOUNDS ! Index : " + i +
                               " | Hearts Length : " + hearts.Length);
                break;
            }

            hearts[i].SetActive(false);
        }
    }

    */
}
