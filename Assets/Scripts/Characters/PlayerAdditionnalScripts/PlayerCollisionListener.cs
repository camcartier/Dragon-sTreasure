using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisionListener : MonoBehaviour
{

    private PlayerStateMachine stateMachine;
    public Vector2 knockbackDirection { get; private set; }

    //private float thiefWaitTime = 10f;
    private float thiefWaitCounter;

    //[SerializeField] PlayerCurrentHealthAndMana playerCurrentHealth;

    private void Awake()
    {
        stateMachine = GetComponent<PlayerStateMachine>();
    }

    void Start()
    {
    }
    void Update()
    {
    }


    //chat gpt says add var
    private void OnCollisionEnter2D(Collision2D collision)
    {

        //Debug.Log("Collision avec : " + collision.collider.gameObject.name);


        var damageScript = collision.collider.GetComponent<CanDamage>()
                  ?? collision.collider.GetComponentInParent<CanDamage>()
                  ?? collision.collider.GetComponentInChildren<CanDamage>();


        if (collision.gameObject.CompareTag("Thief"))
        {
            stateMachine.rb2D.velocity = Vector2.zero;


        }

        if (!stateMachine.isDead )
        {

            if (damageScript != null)
            {

                if (!stateMachine.isInvulnerable) 
                {
                    if (stateMachine.PlayerCurrentHealthAndMana.currentHealth - damageScript.contactDamage < 0)
                    {
                        stateMachine.PlayerCurrentHealthAndMana.currentHealth = 0;
                        //stateMachine.SwitchState(new PlayerDyingState(stateMachine));
                        //quand j'avais laiss� �a, on entrait dans le dying state et en sortait directement
                        //maintenant on passe en dying state seulement apres avoir �t� rentr� dans le hurt state, je ne sais pas si c'est LA solution 
                        //mais c'est UNE solution
                    }
                    else { stateMachine.PlayerCurrentHealthAndMana.currentHealth -= damageScript.contactDamage; }


                    knockbackDirection = new Vector2(gameObject.transform.position.x - collision.collider.transform.position.x, gameObject.transform.position.y - collision.collider.transform.position.y);
                    stateMachine.knockbackDirection = knockbackDirection;


                    stateMachine.SwitchState(new PlayerHurtState(stateMachine));

                }





            }
            else
            {
                Debug.Log("not found");
            }
        }


    }

    /* my own
    private void OnCollisionEnter2D(Collision2D collision)
    {


        if (collision.collider.gameObject.GetComponentInChildren<CanDamage>() != null)
        {
            if(stateMachine.PlayerCurrentHealthAndMana.currentHealth - collision.collider.gameObject.GetComponentInChildren<CanDamage>().contactDamage < 0)
            {
                stateMachine.PlayerCurrentHealthAndMana.currentHealth = 0;
                //stateMachine.SwitchState(new PlayerDyingState(stateMachine));
                //quand j'avais laiss� �a, on entrait dans le dying state et en sortait directement
                //maintenant on passe en dying state seulement apres avoir �t� rentr� dans le hurt state, je ne sais pas si c'est LA solution 
                //mais c'est UNE solution
            }
            else { stateMachine.PlayerCurrentHealthAndMana.currentHealth -= collision.collider.gameObject.GetComponentInChildren<CanDamage>().contactDamage; }


            knockbackDirection = new Vector2(gameObject.transform.position.x - collision.collider.transform.position.x, gameObject.transform.position.y - collision.collider.transform.position.y);
            stateMachine.knockbackDirection = knockbackDirection;


            stateMachine.SwitchState(new PlayerHurtState(stateMachine));

        }
        else
        {
            Debug.Log("not found");
        }
        
    }*/





}
