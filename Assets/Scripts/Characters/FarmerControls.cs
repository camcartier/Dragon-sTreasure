using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FarmerControls : MonoBehaviour
{
    [Header("Setup")]
    [SerializeField] ObjectsData farmerData;
    [SerializeField] List<Transform> fleeingPosList;
    [SerializeField] GameObject player;

    private Destroyable destroyable;
    private Rigidbody2D farmerRb;

    private SpriteRenderer spriteRenderer;

    public bool isFollowing { get; private set;}

    void Start()
    {
        player = GameObject.Find("Player");

        farmerRb = GetComponent<Rigidbody2D>();
        destroyable = GetComponent<Destroyable>();

        spriteRenderer= GetComponentInChildren<SpriteRenderer>();
    }


    void Update()
    {
        if (destroyable.IsBurning)
        {
            spriteRenderer.color = Color.red;
        }

        if (isFollowing)
        {
            Vector3 direction = new Vector3(player.transform.position.x - transform.position.x, player.transform.position.y- transform.position.y);
            farmerRb.velocity = direction.normalized * farmerData.walkSpeed;
        }

    }

    private Vector3 PickFleeingDirection()
    {
        int randomIndex = Random.Range(0, 3);
        return new Vector3(fleeingPosList[randomIndex].transform.position.x, fleeingPosList[randomIndex].transform.position.y, 0) ;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isFollowing = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isFollowing = false;
        }
    }
}
