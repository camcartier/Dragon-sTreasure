using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceReceiver : MonoBehaviour
{
    //[SerializeField] CharacterController controller;

    private float verticalVelocity;
    private float horizontalVelocity;   

    public Vector2 Movement => new Vector2(verticalVelocity, horizontalVelocity);


    private void Update()
    {

    }

    /*
    public void Jump(float jumpForce)
    {
        verticalVelocity += jumpForce;    
    }

    public void Dash(float dashForce)
    {
        horizontalVelocity += dashForce;
    }
    */

    public void Knockback()
    {

    }
}
