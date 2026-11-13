using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class SimpleProjectileControls : MonoBehaviour
{
    [SerializeField] PlayerCurrentHealthAndMana playerCurrentHealthAndMana;
    [SerializeField] GameObject iceSpellExplosion;

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
                                    player.transform.position.y - gameObject.transform.position.y).normalized * projectileSpeed;


        //turning the prefab
        if (gameObject.transform.position.x - player.transform.position.x > 0)
        {

            gameObject.transform.rotation = new Quaternion(0, 180, 0, 0);
        }
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
            Debug.Log(" life over");
            //Destroy(gameObject);
        }


    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("touching player");
            //Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("ice spell hit");
            player.GetComponent<PlayerStateMachine>().isHurt = true;

            if (playerCurrentHealthAndMana.currentHealth >0)
            {
                playerCurrentHealthAndMana.currentHealth -= projectileDamage;
            }

            
            Instantiate(iceSpellExplosion, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }

        if (collision.gameObject.CompareTag("Soldier"))
        {
            collision.gameObject.GetComponentInParent<Destroyable>().MyCurrentHealth -= projectileDamage;
            Instantiate(iceSpellExplosion, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }

    
}
