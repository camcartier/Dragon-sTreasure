using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkTowardsPlayer : MonoBehaviour
{
    private GameObject player;
    private Rigidbody2D rb2D;
    [SerializeField] ObjectsData objectData;

    public float directionX;
    public float directionY;

    public bool isFollowing;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");  
        rb2D = GetComponent<Rigidbody2D>();

        isFollowing = true;
    }

    // Update is called once per frame
    void Update()
    {

        if (Mathf.Sign(gameObject.transform.position.x - player.transform.position.x) > 0)
        {
            directionX = -1;
        }
        else { directionX = 1; }

        if (Mathf.Sign(gameObject.transform.position.y - player.transform.position.y) > 0)
        {
            directionY = -1;
        }
        else { directionY = 1; }



        if(isFollowing)
        {
            rb2D.velocity = new Vector2(directionX, directionY) * objectData.walkSpeed;

        }
        
            
    }


}
