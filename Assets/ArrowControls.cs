using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ArrowControls : MonoBehaviour
{
    [SerializeField] GameObject player;

    private Rigidbody2D rb2d;
    private Vector3 direction;


    [SerializeField] int arrowSpeed;
    [SerializeField] float gravityMultiplier;
    [SerializeField] int arrowCurvature;
    [SerializeField] float arrowLifeTime;
    private float arrowLifeTimerCounter;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = gameObject.GetComponent<Rigidbody2D>();

        if (player == null) { player = GameObject.Find("Player"); }
        direction = new Vector3(player.transform.position.x - transform.position.x, player.transform.position.y - transform.position.y + arrowCurvature, 0).normalized;
        Debug.Log(direction);

        rb2d.AddForce(direction * arrowSpeed, ForceMode2D.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        if (arrowLifeTimerCounter < arrowLifeTime)
        {
            arrowLifeTimerCounter += Time.deltaTime;
        }
        else { Destroy(this.gameObject); }

        rb2d.gravityScale += gravityMultiplier;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(this.gameObject);
    }
}
