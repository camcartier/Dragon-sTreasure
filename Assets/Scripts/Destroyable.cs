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
    [SerializeField] IAMAPS burningFx;
    [SerializeField] BulletData bulletData;
    [SerializeField] PlayerData playerData;


    private IAMAPS burningFxInstance;


    public float MyCurrentHealth { get; private set; }
    public float MyCurrentStoredHealth { get; private set; }
    public bool IsBurning { get; private set; }
    private bool burningFxHasSpawned;
    public bool IsRegen { get; private set; }
    public bool IsRepulsed { get; set; }    


    private float currentWaitAfterLastAttack;
    private float currentWaitBeforeNextBurn;
    private float currentWaitBeforeRegen;

    public ObjectsData ObjectData => objectData;

    private bool lastColliderIsBullet;

    //Loot Generation
    public GameObject[] listOfPossibleLoots = new GameObject[6];


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
        //Debug.Log(objectData.maxHealth);

        MyCurrentHealth = objectData.maxHealth;
        MyCurrentStoredHealth = objectData.maxHealth;

        burningFxHasSpawned = false;
    }

    private void Update()
    {
        //Debug.Log("burning is" + IsBurning);
        //Debug.Log("regen is" + IsRegen);
        if (MyCurrentHealth != objectData.maxHealth)
        {   healthPanel.gameObject.SetActive(true); }

        if ( MyCurrentStoredHealth != MyCurrentHealth)
        { 
            UpdateHealthBar(MyCurrentHealth); MyCurrentStoredHealth  = MyCurrentHealth;
        }

        if (MyCurrentHealth >= objectData.maxHealth)
        {
            MyCurrentHealth = objectData.maxHealth;
            IsRegen = false;
            //Debug.Log("regen stopped");

        }



        if (MyCurrentHealth < objectData.maxHealth)
        {
            if (!IsBurning)
            {
                //not sure about that one
                /*currentWaitAfterLastAttack += Time.deltaTime;
                if (currentWaitAfterLastAttack > objectData.regenFirstWait)
                {
                    IsRegen = true; Debug.Log("regen");
                }*/

                //Debug.Log("not full health not burning");
            }
        }

        if (IsRepulsed)
        {
            MyCurrentHealth -= playerData.repulseDamageArray[playerData.currentLevel];
            IsRepulsed = false;
        }

        if (IsRegen)
        {
            if (currentWaitBeforeRegen < objectData.regenSpeed)
            {
                currentWaitBeforeRegen += Time.deltaTime;
            }
            else { RegenHealth(); currentWaitBeforeRegen = 0;  }
        }


        if (MyCurrentHealth <= objectData.maxHealth / 2)
        {
            if (lastColliderIsBullet)
            {
                IsBurning = true; IsRegen = false; 
            }
            if (MyCurrentHealth <= objectData.minHealthBurnsStop)
            {
                IsBurning = false; 
            }

        }

        if (IsBurning)
        {
            gameObject.GetComponentInChildren<SpriteRenderer>().color = Color.red;
            if (!burningFxHasSpawned)
            {
                burningFxInstance = Instantiate(burningFx, new Vector3(transform.position.x, transform.position.y + 16, transform.position.z), Quaternion.identity, gameObject.transform);
                burningFxHasSpawned = true;
            }

            currentWaitBeforeNextBurn += Time.deltaTime;
            if (currentWaitBeforeNextBurn >= objectData.burningSpeed)
            {
                BurningHealth(); currentWaitBeforeNextBurn = 0;
            }

        }
        else 
        {
            gameObject.GetComponentInChildren<SpriteRenderer>().color = Color.white; 
            
            //idk makes error pop but still runs
            //ParticleSystem ps = burningFxInstance.GetComponentInChildren<ParticleSystem>();
            //if (ps != null) ps.Stop();
            
            burningFxHasSpawned = false;
        }



        if (MyCurrentHealth <= 0)
        {
            Instantiate(destructionFx, transform.position, Quaternion.identity);

            if (gameObject.CompareTag("Yakkuru") == true)
            {
                int lootnum = Random.Range(0, 2);
                Instantiate(listOfPossibleLoots[lootnum], transform.position, Quaternion.identity);
            }
            if (gameObject.CompareTag("Farmer") == true)
            {
                Instantiate(listOfPossibleLoots[3], transform.position, Quaternion.identity);
            }


            //destructionFx.GetComponentInChildren<ParticleSystem>().Play();
            Destroy(gameObject);
        }
    }

    private void SetMaxHealth(float health)
    {
        healthSlider.maxValue = health;
    }
    private void UpdateHealthBar(float health)
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
            lastColliderIsBullet = true;

        }

        if (collision.gameObject.CompareTag("Player"))
        {
            lastColliderIsBullet = false;
            if (objectData.isHurtFromContact )
            {
                MyCurrentHealth -= objectData.contactDamageTaken;
            }
        }

    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Fireball"))
        {
            Debug.Log("fireball touched");
            MyCurrentHealth -= bulletData.FireballDamageArray[1];
        }
    }




}
