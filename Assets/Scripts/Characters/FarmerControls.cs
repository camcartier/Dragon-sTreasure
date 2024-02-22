using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FarmerControls : MonoBehaviour
{
    [SerializeField] Rigidbody2D farmerRb;
    [SerializeField] CharacterData farmerData;

    private GameObject player;



    void Start()
    {
        player = GameObject.Find("Player");

    }


    void Update()
    {

    }


}
