using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;
using UnityEngine.Rendering;

public class WalkTowards : MonoBehaviour
{
    private GameObject toFollow;
    private Rigidbody2D rb2D;
    [SerializeField] ObjectsData objectData;

    public float directionX;
    public float directionY;

    public bool isFollowing;
    public bool isTurning;
    public bool isStunned;

    [field: SerializeField] public float stunTimer { get; private set; }
    private float stunTimerCounter;

    // Start is called before the first frame update
    void Start()
    {
        if (gameObject.tag != "Thief")
        {
            toFollow = GameObject.Find("Player");
        }
        else { toFollow = GameObject.Find("Treasure"); }
            rb2D = GetComponent<Rigidbody2D>();

        if(stunTimer ==0)
        {
            stunTimer = 1.5f;
        }

        isFollowing = true;
        isTurning = true;
        isStunned = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isStunned)
        {
            
            rb2D.velocity = Vector3.zero;
            rb2D.mass = 100f; 
            stunTimerCounter += Time.deltaTime;
            if (stunTimerCounter>= stunTimer)
            {
                isStunned= false;
                stunTimerCounter= 0f;
                rb2D.mass = 1f;
            }
        }

        if (Mathf.Sign(gameObject.transform.position.x - toFollow.transform.position.x) > 0)
        {
            directionX = -1;
        }
        else { directionX = 1; }

        if (Mathf.Sign(gameObject.transform.position.y - toFollow.transform.position.y) > 0)
        {
            directionY = -1;
        }
        else { directionY = 1; }


        //Walk towards the player
        if(isFollowing && !isStunned)
        {
            float distance = Vector2.Distance(gameObject.transform.position, toFollow.transform.position);
            Vector2 direction = new Vector2(toFollow.transform.position.x - gameObject.transform.position.x, toFollow.transform.position.y - gameObject.transform.position.y);
            //debug
            Debug.DrawRay(transform.position, direction * distance, Color.red);

            if (Physics2D.Raycast(gameObject.transform.position, direction, distance) == true)
            {
                
                Debug.Log("obstacle");

                if (direction.x > 0) { rb2D.velocity = new Vector2(directionX + 1, directionY).normalized * objectData.walkSpeed; }
                else { rb2D.velocity = new Vector2(directionX - 1, directionY).normalized * objectData.walkSpeed; }
                if (direction.y > 0) { rb2D.velocity = new Vector2(directionX, directionY +1).normalized * objectData.walkSpeed; }
                else { rb2D.velocity = new Vector2(directionX, directionY -1).normalized * objectData.walkSpeed; }

                    
            }
            else
            {
                rb2D.velocity = new Vector2(directionX, directionY) * objectData.walkSpeed;
            }
                

        }

        if (Mathf.Abs(toFollow.transform.position.x - gameObject.transform.position.x) <= 0.5f)
        {
            isTurning = false;
        }
        else { isTurning = true; }


        //Turning the prefab
        if (isFollowing && isTurning && !isStunned)
        {
            if (toFollow.transform.position.x > gameObject.transform.position.x)
            {
                gameObject.transform.localScale = new Vector3(-1, 1, 1);
            }
            else
            {
                gameObject.transform.localScale = new Vector3(1, 1, 1);
            }
        }
            
    }


}
