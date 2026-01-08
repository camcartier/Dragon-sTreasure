using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballIconScript : MonoBehaviour
{
    [SerializeField] PlayerStateMachine playerStateMachine;
    

    // Update is called once per frame
    void Update()
    {
        if (playerStateMachine.canFireball == true)
        {
            gameObject.GetComponent<CanvasRenderer>().SetAlpha(1f);
        }
        else
        {
            gameObject.GetComponent<CanvasRenderer>().SetAlpha(0.1f);
        }
    }
}
