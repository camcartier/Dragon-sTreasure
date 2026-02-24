using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class SimpleProjectileControls : MonoBehaviour
{

    private GameObject player;
    private Rigidbody2D rb2d;

    public float projectileLifeTimer;
    private float projectileTimerCounter;

    public float projectileSpeed;
    public int projectileDamage;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        rb2d =  gameObject.GetComponent<Rigidbody2D>();

        rb2d.velocity = new Vector2(player.transform.position.x - gameObject.transform.position.x,
                                    player.transform.position.y - gameObject.transform.position.y) * projectileSpeed;
                                    
    }

    // Update is called once per frame
    void Update()
    {
        if (projectileTimerCounter < projectileLifeTimer)
        {
            projectileTimerCounter += Time.deltaTime;
        }
        else
        {
            Destroy(gameObject);
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {

            Destroy(gameObject);
        }
    }
}
