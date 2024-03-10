using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FarmerControls : MonoBehaviour
{
    [Header ("Setup")]
    [SerializeField] ObjectsData farmerData;

    private GameObject player;
    private Destroyable destroyable;
    private Rigidbody2D farmerRb;

    private SpriteRenderer spriteRenderer;


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
    }


}
