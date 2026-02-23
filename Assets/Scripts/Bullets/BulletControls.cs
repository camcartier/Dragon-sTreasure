using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BulletControls : MonoBehaviour
{
    [SerializeField] PlayerData playerData;
    [SerializeField] BulletData bulletData;

    //private CharacterData characterData;

    [SerializeField] GameObject boooomBaby;

    private GameObject FiringStart;
    private GameObject FiringEnd;
    private Vector2 direction;

    private Rigidbody2D rb2D;

    private GameObject player;

    [Header("Bullet stats")]
    [SerializeField] float bulletSpeed;
    [SerializeField] float bulletLifeExpectancy;
    public float bulletTimeAlive { get; private set; }

    

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        FiringStart = player.GetComponentInChildren<BulletStartPoint>().gameObject;
        FiringEnd = player.GetComponentInChildren<BulletEndPoint>().gameObject;

        rb2D = GetComponent<Rigidbody2D>();

        
        bulletTimeAlive = 0f;

        rb2D.velocity = new Vector2(FiringEnd.transform.position.x-FiringStart.transform.position.x  , FiringEnd.transform.position.y-FiringStart.transform.position.y )*bulletSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        if(bulletTimeAlive < bulletLifeExpectancy)
        {
            bulletTimeAlive += Time.deltaTime;
        }
        else { Destroy(this.gameObject); }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {


        if (collision.gameObject.GetComponentInParent<Destroyable>())
        {
           
            if (player.transform.rotation.y > 0)
            {
                Instantiate(boooomBaby, new Vector2(collision.otherCollider.gameObject.transform.position.x, collision.otherCollider.gameObject.transform.position.y), Quaternion.Euler(0, 180, 0));
            }
            else
            {
                Instantiate(boooomBaby, new Vector2(collision.otherCollider.gameObject.transform.position.x, collision.otherCollider.gameObject.transform.position.y), Quaternion.identity);
            }
        }

        Destroy (this.gameObject);

    }

}
