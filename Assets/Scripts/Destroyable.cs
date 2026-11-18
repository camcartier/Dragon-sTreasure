using NaughtyAttributes;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;


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
    [SerializeField] EnemyStateMachine stateMachineEnemy;
    [SerializeField] EnemyIDNumber enemyIDNumber;
    [SerializeField] KillsData killsCount;
    private GetAttackTargets getAttackTargets;



    private IAMAPS burningFxInstance;


    public float MyCurrentHealth;
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
    public bool hasInstantiatedLoot;

    public static event Action<int> OnDeath;
    public static event Action<int> OnSpawn;

    void Reset()
    {
        healthPanel = gameObject.GetComponentInChildren<IAMAPanel>(true);
        healthSlider = gameObject.GetComponentInChildren<Slider>(true);
        //destructionFx = gameObject.GetComponentInChildren<IAMAPS>(true);
    }

    private void Start()
    {
        OnSpawn?.Invoke(1);

        SetMaxHealth(objectData.maxHealth);

        MyCurrentHealth = objectData.maxHealth;
        MyCurrentStoredHealth = objectData.maxHealth;

        //burningFxHasSpawned = false;
        getAttackTargets = GameObject.Find("Player").GetComponentInChildren<GetAttackTargets>();
    }

    private void Update()
    {
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



        if (MyCurrentHealth - bulletData.BulletDamageArray[playerData.currentLevel] < objectData.maxHealth / 2 
            && !stateMachineEnemy.isBurning 
            && !stateMachineEnemy.hasAlreadyBurnt)
        {
           // stateMachineEnemy.isBurning = true;
        }
        else { //stateMachineEnemy.isBurning = false;
               }




        if (MyCurrentHealth <= 0)
        {
            //Instantiate(destructionFx, transform.position, Quaternion.identity);
            stateMachineEnemy.isDead = true;

            getAttackTargets.enemiesInReach.Remove(this.gameObject);

            if (!hasInstantiatedLoot)
            {
                if (gameObject.CompareTag("Yakkuru") == true)
                {
                    int lootnum = UnityEngine.Random.Range(0, 2);
                    Instantiate(listOfPossibleLoots[lootnum], transform.position, Quaternion.identity);
                    hasInstantiatedLoot = true;
                }
                if (gameObject.CompareTag("Farmer") == true)
                {

                    Instantiate(listOfPossibleLoots[3], transform.position, Quaternion.identity);
                    hasInstantiatedLoot = true;
                }
                if (gameObject.CompareTag("Soldier") == true)
                {
                    int lootnum = UnityEngine.Random.Range(4, 6);
                    Instantiate(listOfPossibleLoots[lootnum], transform.position, Quaternion.identity);
                    hasInstantiatedLoot = true;
                }
            }

            //destructionFx.GetComponentInChildren<ParticleSystem>().Play();

            AnimatorStateInfo stateInfo = stateMachineEnemy.Animator.GetCurrentAnimatorStateInfo(0);

            if (stateInfo.IsName("Death"))
            {
                if (stateInfo.normalizedTime >= 1f)
                {
                    
                        //Instantiate(gameObject.GetComponent<EnemyStateMachine>().Skull, transform.position, new Quaternion(0,0,0,0));
                    if (enemyIDNumber.IDNumber == 1)
                    {
                       killsCount.swordsKillCount ++;   
                    }
                    if( enemyIDNumber.IDNumber == 2)
                    {
                        killsCount.horsesKillCount ++;
                    }
                    if (enemyIDNumber.IDNumber == 3)
                    {
                        killsCount.sorcerersKillCount ++;
                    }

                    OnDeath?.Invoke(1);
                    Destroy(gameObject);
                }
            }

  
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
            MyCurrentHealth -= bulletData.BulletDamageArray[playerData.currentLevel];
               
            if (!stateMachineEnemy.isHurt)
            {
                stateMachineEnemy.isHurt = true;
            }

            Destroy(collision.gameObject);
            lastColliderIsBullet = true;

        }

        //je ne sais pas si je vais l'utiliser
        
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
            MyCurrentHealth -= bulletData.FireballDamageArray[playerData.currentLevel];

            gameObject.GetComponent<EnemyStateMachine>().isHit = true;
        }
    }




}
