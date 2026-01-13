using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballControls : MonoBehaviour
{
    private Rigidbody2D rb2D;
    private GameObject fireballStartingPos;
    private GameObject fireballFinishedPos;
    private GameObject player;

    [SerializeField] GameObject EndOfFireballFX;

    [Header("BulletSettings")]
    public float fireballSpeed;
    public float fireballDamage;
    public float fireballLifeExpectancy;
    //public float fireballLifeExpectancy { get; private set; }
    public float fireballTimeAlive { get; private set; }
    


    void Start()
    {
        player = GameObject.Find("Player");
        fireballStartingPos = player.GetComponentInChildren<FireballStartPoint>().gameObject;
        fireballFinishedPos = player.GetComponentInChildren<FireballEndPoint>().gameObject;
        rb2D = GetComponent<Rigidbody2D>();

        fireballTimeAlive = 0f;
        //fireballLifeExpectancy = 1.5f;

        rb2D.velocity = new Vector2(Mathf.Sign(fireballFinishedPos.transform.position.x - fireballStartingPos.transform.position.x), 0) * fireballSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        if (fireballTimeAlive < fireballLifeExpectancy)
        {
            fireballTimeAlive += Time.deltaTime;
        }
        else {
            Instantiate(EndOfFireballFX, new Vector2(gameObject.transform.position.x, gameObject.transform.position.y), Quaternion.identity);
            Destroy(this.gameObject); }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponentInParent<Destroyable>())
        {
            Debug.Log("HEADSHOT");
        }
    }
}
