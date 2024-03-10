using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using NaughtyAttributes;

public class AttackPlayer : MonoBehaviour
{
    [SerializeField] GameObject player;
    [Expandable][SerializeField] ObjectsData objectData;

    private Rigidbody2D rb2D;

    public bool IsAttacking { get; private set; }
    public bool TimerStarted { get; private set; }
    public float DetachTimer {  get; private set; }

    private void Reset()
    {

        
    }
    private void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();

        //i dun get what happens here (type mismatch but wut???
        //player = GameObject.Find("Player");
    }

    private void Update()
    {
        

        if (TimerStarted)
        {
            DetachTimer += Time.deltaTime;
            if (DetachTimer > objectData.outOfRangeDetachTime)
            {
                IsAttacking = false;
                DetachTimer = 0;
                TimerStarted = false;
            }
        }

        if (IsAttacking)
        {
            Vector2 direction = GetDirection(player.transform.position.x, player.transform.position.y);
            rb2D.velocity = direction.normalized * objectData.walkSpeed * Time.deltaTime;
        }

    }

    Vector3 GetDirection(float posX, float posY)
    {
        if (gameObject.transform.position.x - posX < gameObject.transform.position.x)
        {
            return new Vector3(gameObject.transform.position.x - posX, gameObject.transform.position.y - posY, 0);
        }
        else return new Vector3(posX - gameObject.transform.position.x, posY - gameObject.transform.position.y, 0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            IsAttacking = true;
            DetachTimer = 0f;
        }
    }

    

    private void OnTriggerExit2D(Collider2D collision)
    {
        TimerStarted = true;
    }
}
