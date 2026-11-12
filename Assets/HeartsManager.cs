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

    // Start is called before the first frame update
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

    // Update is called once per frame
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
}
