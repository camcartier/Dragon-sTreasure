using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkTowards : MonoBehaviour
{
    private GameObject toFollow;
    private Rigidbody2D rb2D;
    [SerializeField] ObjectsData objectData;

    public float directionX;
    public float directionY;

    public bool isFollowing;
    public bool isTurning;

    // Start is called before the first frame update
    void Start()
    {
        if (gameObject.tag != "Thief")
        {
            toFollow = GameObject.Find("Player");
        }
        else { toFollow = GameObject.Find("Treasure"); }
            rb2D = GetComponent<Rigidbody2D>();

        isFollowing = true;
        isTurning = true;
        
    }

    // Update is called once per frame
    void Update()
    {

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
        if(isFollowing)
        {
            rb2D.velocity = new Vector2(directionX, directionY) * objectData.walkSpeed;

        }

        if (Mathf.Abs(toFollow.transform.position.x - gameObject.transform.position.x) <= 0.5f)
        {
            isTurning = false;
        }
        else { isTurning = true; }


        //Turning the prefab
        if (isFollowing && isTurning)
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
