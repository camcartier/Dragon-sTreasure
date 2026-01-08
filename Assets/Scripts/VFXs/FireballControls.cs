using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballControls : MonoBehaviour
{
    private Rigidbody2D rb2D;
    private Vector2 firingDirection;
    public float bulletSpeed;

    // Start is called before the first frame update
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();

        if(gameObject.transform.position.x < 0)
        {
            rb2D.velocity = new Vector2(-1 , 0) * bulletSpeed;
        }
        else { rb2D.velocity = new Vector2(1, 0) * bulletSpeed; }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
