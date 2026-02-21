using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackPlayer : MonoBehaviour
{
    [SerializeField] WalkTowards walkTowards;
    [SerializeField] EnemyIDNumber enemyIDN;

    private GameObject Player;

    List<Action> AttacksList = new List<Action>();

    private bool canAttack;
    private bool isAttacking;




    private float attackTimerCounter;

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("Player");

        AttacksList.Add(SimpleAttack);
        AttacksList.Add(FireBullet);
        AttacksList.Add(SomethingAttack);

        canAttack = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (isAttacking && canAttack)
        {
            AttacksList[enemyIDN.IDNumber]();
            canAttack = false;
            attackTimerCounter += Time.deltaTime;
        }
        if(attackTimerCounter > enemyIDN.IDAttackTimer)
        {
            walkTowards.isFollowing = true;
            canAttack = true;
        }



    }

    private void SimpleAttack()
    {
        gameObject.GetComponentInChildren<SpriteRenderer>().color = Color.blue;
    }

    private void FireBullet()
    {
        gameObject.GetComponentInChildren<SpriteRenderer>().color = Color.yellow;
    }

    private void SomethingAttack()
    {
        gameObject.GetComponentInChildren<SpriteRenderer>().color = Color.green;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.gameObject.CompareTag("Player"))
        {
            //Debug.Log("should attack player");
            walkTowards.isFollowing = false;
            Debug.Log(walkTowards.isFollowing);
            isAttacking = true;
        }
    }
}
