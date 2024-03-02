using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;


public class Destroyable : MonoBehaviour
{
    //tag script

    [Header("truc")]
    [SerializeField] ObjectsData objectData;
    [SerializeField] IAMAPanel healthPanel;
    [SerializeField] Slider healthSlider;
    [SerializeField] IAMAPS destructionFx;
    [SerializeField] BulletData bulletData;

    private int currentHealth;
    public int storedHealth;

    public int MyCurrentHealth { get; private set; }
    public ObjectsData ObjectData => objectData; 


    private void OnValidate()
    {
        if (currentHealth <= 0) currentHealth = 100;
    }


    private void Start()
    {
        MyCurrentHealth = 12;
        currentHealth = storedHealth = objectData.maxHealth;
        
        healthPanel= gameObject.GetComponentInChildren<IAMAPanel>(true);
        destructionFx= gameObject.GetComponentInChildren<IAMAPS>();
        healthSlider= gameObject.GetComponentInChildren<Slider>(true);

        SetMaxHealth(objectData.maxHealth);
    }

    private void Update()
    {
        if (currentHealth == objectData.maxHealth) { return; }
        else { healthPanel.gameObject.SetActive(true); }

        if (currentHealth == storedHealth){
            return;}
        else { UpdateHealthBar();  }

        if (currentHealth <= 0)
        {
            Instantiate(destructionFx, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }

    private void SetMaxHealth(int health)
    {
        healthSlider.value = health;
    }
    private void UpdateHealthBar()
    {
        healthSlider.value = currentHealth;
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            currentHealth -= bulletData.LVL1_bulletDamage;
        }
    }
}
