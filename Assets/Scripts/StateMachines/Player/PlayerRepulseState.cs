using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class PlayerRepulseState : PlayerBaseState
{
    private float repulseTimer = 0.5f;
    private float repulseTimerCounter;

    public LayerMask affectedLayers = LayerMask.GetMask("Destroyable"); // All layers by default



    //each for each level
    private List<int> listOfRepulseHash = new List<int>();

    public PlayerRepulseState(PlayerStateMachine stateMachine) : base(stateMachine)
    {
    }

    public override void Enter()
    {




        stateMachine.canRepulse = false;

        stateMachine.rb2D.velocity = Vector3.zero;
        stateMachine.MainSpriteRenderer.color = Color.green;


        Debug.Log("enter repulse state");

        ApplyExplosionForce();
    }
    public override void Tick(float deltaTime)
    {
        

        repulseTimerCounter += Time.deltaTime;
        //Debug.Log(repulseTimerCounter);

        if (repulseTimerCounter > repulseTimer)
        {
            stateMachine.SwitchState(new PlayerMainState(stateMachine));
        }
    }

    public override void Exit()
    {
        //stateMachine.canRepulse = true;

        repulseTimerCounter = 0f;
        stateMachine.MainSpriteRenderer.color = Color.white;

        //Debug.Log("exit repulse state");
    }

    public void ApplyExplosionForce()
    {
        Vector3 explosionPosition = stateMachine.gameObject.transform.position;
        Collider2D[] colliders = Physics2D.OverlapCircleAll(explosionPosition, stateMachine.PlayerData.repulseRadius, affectedLayers);

        
        //c'est une collection qui ne contient jamais de doublon
        //La méthode Add() renvoie un bool : true si l’élément a été ajouté, false s’il était déjà là
        HashSet<Rigidbody2D> alreadyPushed = new HashSet<Rigidbody2D>();


        foreach (Collider2D collider in colliders)
        {
            Rigidbody2D rb2d = collider.gameObject.GetComponentInParent<Rigidbody2D>();
            GetsRepulsed getsRepulsed = collider.gameObject.GetComponentInParent<GetsRepulsed>();
            

            if(getsRepulsed != null)
            {

                if (alreadyPushed.Add(rb2d))
                {
                    EnemyStateMachine enemy = collider.GetComponentInParent<EnemyStateMachine>();

                    //mis ici pour etre sur qu'il y a un rb2d 
                    Vector2 repulseDirection = new Vector2(enemy.transform.position.x - stateMachine.rb2D.transform.position.x, 
                                                            enemy.transform.position.y - stateMachine.rb2D.transform.position.y);

                    collider.GetComponentInParent<EnemyStateMachine>().isHit = true;

                    enemy.pendingKnockback = repulseDirection.normalized * stateMachine.PlayerData.repulseAmount;
                    enemy.pendingDamage = stateMachine.PlayerData.repulseDamage;

                    //a mettre dans hurt state
                    //rb2d.AddForce(repulseDirection.normalized * stateMachine.PlayerData.repulseAmount,  ForceMode2D.Impulse);

                    /*
                    if(collider.GetComponentInParent<Destroyable>() != null)
                    {
                        collider.GetComponentInParent<Destroyable>().IsRepulsed = true;
                    }
                    */
                }


            }
            
        }
    }
}
