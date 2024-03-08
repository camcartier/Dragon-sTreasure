using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;
using NaughtyAttributes;


public class Destroyable : MonoBehaviour
{
    //tag script

    [Header("Setup")]
    [Expandable] [SerializeField] ObjectsData objectData;
    [SerializeField] IAMAPanel healthPanel;
    [SerializeField] Slider healthSlider;
    [SerializeField] IAMAPS destructionFx;
    [SerializeField] BulletData bulletData;


    public int MyCurrentHealth { get; private set; }
    public int MyCurrentStoredHealth { get; private set; }
    public bool IsBurning { get; private set; }
    public bool IsRegen { get; private set; }


    private float currentWaitAfterLastAttack;
    private float currentWaitBeforeNextBurn;
    private float currentWaitBeforeRegen;

    public ObjectsData ObjectData => objectData; 

    /*
    private void OnValidate()
    {
        //if (MyCurrentHealth <= 0) MyCurrentHealth = 100;   
    }
    */

     void Reset()
    {
        healthPanel = gameObject.GetComponentInChildren<IAMAPanel>(true);
        healthSlider = gameObject.GetComponentInChildren<Slider>(true);
        //destructionFx = gameObject.GetComponentInChildren<IAMAPS>(true);
    }

    private void Start()
    {
        SetMaxHealth(objectData.maxHealth);
        Debug.Log(objectData.maxHealth);

        MyCurrentHealth = objectData.maxHealth;
        MyCurrentStoredHealth = objectData.maxHealth;

    }

    private void Update()
    {
        if (MyCurrentHealth != objectData.maxHealth)
        {   healthPanel.gameObject.SetActive(true); }

        if ( MyCurrentStoredHealth != MyCurrentHealth)
        { UpdateHealthBar(MyCurrentHealth); MyCurrentStoredHealth  = MyCurrentHealth;
            Debug.Log(MyCurrentHealth);
        }

        /*
        if ( MyCurrentHealth <= objectData.maxHealth & currentWaitAfterLastAttack > objectData.regenFirstWait)
        {    }
        else { currentWaitAfterLastAttack += Time.deltaTime; }*/

        if(MyCurrentHealth < objectData.maxHealth)
        {
            currentWaitAfterLastAttack += Time.deltaTime;
            if (currentWaitAfterLastAttack > objectData.regenFirstWait )
            {
                IsRegen = true;
            }

        }

        if (IsRegen)
        {
            if (currentWaitBeforeRegen < objectData.regenSpeed)
            {
                currentWaitBeforeRegen += Time.deltaTime;
            }
            else { RegenHealth(); currentWaitBeforeRegen = 0; }
        }


        if (MyCurrentHealth <= objectData.maxHealth / 2)
        {
            IsBurning = true;
        }

        if (IsBurning) {
            currentWaitBeforeNextBurn += Time.deltaTime;
            if (currentWaitBeforeNextBurn >= objectData.burningSpeed)
            {
                BurningHealth(); currentWaitBeforeNextBurn = 0; 
            }
        }


        if (MyCurrentHealth <= 0)
        {
            Instantiate(destructionFx, transform.position, Quaternion.identity);
            destructionFx.GetComponentInChildren<ParticleSystem>().Play();
            Destroy(gameObject);
        }
    }

    private void SetMaxHealth(int health)
    {
        healthSlider.maxValue = health;
    }
    private void UpdateHealthBar(int health)
    {
        healthSlider.value = health;
        //Debug.Log(healthSlider.value);
    }

    private void RegenHealth() { 
            MyCurrentHealth += objectData.regenAmount; }

    private void BurningHealth() { MyCurrentHealth -= objectData.burningAmount; }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            MyCurrentHealth -= bulletData.LVL1_bulletDamage;
            Destroy(collision.gameObject);
        }
    }
}
