using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class PlayerRepulseState : PlayerBaseState
{
    private float repulseTimer = 0.8f;
    private float repulseTimerCounter;

    public LayerMask affectedLayers = LayerMask.GetMask("Destroyable"); // All layers by default


    private readonly int LVL1_RepulseHash = Animator.StringToHash("LVL1_Repulse");
    private readonly int LVL2_RepulseHash = Animator.StringToHash("LVL2_Repulse");
    private readonly int LVL3_RepulseHash = Animator.StringToHash("LVL3_Repulse");
    private readonly int LVL4_RepulseHash = Animator.StringToHash("LVL4_Repulse");
    private readonly int LVL5_RepulseHash = Animator.StringToHash("LVL5_Repulse");
    //each for each level
    private List<int> listOfRepulseHash = new List<int>();

    public PlayerRepulseState(PlayerStateMachine stateMachine) : base(stateMachine)
    {
    }

    public override void Enter()
    {
        listOfRepulseHash.Add(LVL1_RepulseHash);
        listOfRepulseHash.Add(LVL2_RepulseHash);
        listOfRepulseHash.Add(LVL3_RepulseHash);
        listOfRepulseHash.Add(LVL4_RepulseHash);
        listOfRepulseHash.Add(LVL5_RepulseHash);


        stateMachine.canRepulse = false;

        stateMachine.rb2D.velocity = Vector3.zero;
        stateMachine.gameObject.GetComponentInChildren<SpriteRenderer>().color = Color.green;


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
        stateMachine.canRepulse = true;

        repulseTimerCounter = 0f;
        stateMachine.gameObject.GetComponentInChildren<SpriteRenderer>().color = Color.white;

        //Debug.Log("exit repulse state");
    }

    public void ApplyExplosionForce()
    {
        Vector3 explosionPosition = stateMachine.gameObject.transform.position;
        Collider2D[] colliders = Physics2D.OverlapCircleAll(explosionPosition, stateMachine.PlayerData.repulseRadius, affectedLayers);

        /*
        if(colliders.Length > 0 )
        {
            Debug.Log(colliders[0].name);
        }*/
        
         foreach (Collider2D collider in colliders)
        {
            Rigidbody2D rb2d = collider.gameObject.GetComponentInParent<Rigidbody2D>();
            GetsRepulsed getsRepulsed = collider.gameObject.GetComponentInParent<GetsRepulsed>();
            Vector2 repulseDirection = new Vector2(collider.transform.position.x - stateMachine.transform.position.x, collider.transform.position.y - stateMachine.transform.position.y);

            if(getsRepulsed != null)
            {
                if (collider.GetComponentInParent<WalkTowards>() != null)
                {
                    collider.GetComponentInParent<WalkTowards>().isStunned = true;
                }

                //collider.GetComponentInParent<WalkTowards>().isStunned= true;
                //rb2d.AddForce(repulseDirection.normalized * stateMachine.repulseForce, ForceMode2D.Impulse );
                rb2d.AddForce(repulseDirection.normalized * stateMachine.PlayerData.repulseAmountArray[stateMachine.PlayerData.currentLevel]);

                if(collider.GetComponentInParent<Destroyable>() != null)
                {
                    collider.GetComponentInParent<Destroyable>().IsRepulsed = true;
                }
            }
            //else { Debug.Log("no repulsed"); }
        }
    }
}
