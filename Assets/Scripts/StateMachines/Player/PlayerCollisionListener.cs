using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisionListener : MonoBehaviour
{

    private PlayerStateMachine stateMachine;
    public Vector2 knockbackDirection { get; private set; }


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

    private void OnCollisionEnter2D(Collision2D collision)
    {

        
        if (collision.collider.gameObject.GetComponentInChildren<CanDamage>() != null)
        {
            if(stateMachine.PlayerCurrentHealthAndMana.currentHealth - collision.collider.gameObject.GetComponentInChildren<CanDamage>().contactDamage < 0)
            {
                stateMachine.PlayerCurrentHealthAndMana.currentHealth = 0;
                //stateMachine.SwitchState(new PlayerDyingState(stateMachine));
                //quand j'avais laissé ça, on entrait dans le dying state et en sortait directement
                //maintenant on passe en dying state seulement apres avoir été rentré dans le hurt state, je ne sais pas si c'est LA solution 
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
        
    }



}
