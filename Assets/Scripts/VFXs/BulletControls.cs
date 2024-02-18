using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BulletControls : MonoBehaviour
{
    [SerializeField] PlayerData playerData;
    [SerializeField] BulletData bulletData;

    private GameObject FiringStart;
    private GameObject FiringEnd;
    private Vector2 direction;

    private Rigidbody2D rb2D;

    [Header("Bullet stats")]
    public float bulletLifeExpectancy;
    public float bulletTimeAlive;
    public float bulletSpeed;
    //public int bulletDamage = 1;

    // Start is called before the first frame update
    void Start()
    {
        FiringStart = GameObject.Find("Player").GetComponentInChildren<BulletStartPoint>().gameObject;
        FiringEnd = GameObject.Find("Player").GetComponentInChildren<BulletEndPoint>().gameObject;

        rb2D = GetComponent<Rigidbody2D>();

        
        bulletTimeAlive = 0f;

        rb2D.velocity = new Vector2(FiringEnd.transform.position.x-FiringStart.transform.position.x  , FiringEnd.transform.position.y-FiringStart.transform.position.y )*bulletSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        

        if(bulletTimeAlive < bulletLifeExpectancy)
        {
            Debug.Log("ayoooooo");
            bulletTimeAlive += Time.deltaTime;
        }
        else { Destroy(this.gameObject); }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {


        if (collision.gameObject.GetComponentInParent<FarmControls>() )
        {
            collision.gameObject.GetComponentInParent<FarmControls>().farmCurrentHealth -= bulletData.LVL1_bulletDamage;
            
            //Debug.Log(collision.gameObject.GetComponentInParent<FarmControls>().farmCurrentHealth);
        }


    }

}
