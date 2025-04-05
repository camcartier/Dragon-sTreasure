using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldDugControls : MonoBehaviour
{

    private Animator gDAnimator;
    private float animationTimer;

    [SerializeField] TreasureData CurrentTreasure;

    void Start()
    {
        gDAnimator = gameObject.GetComponentInChildren<Animator>();
        CurrentTreasure.GoldCount += 5;
    }

    // Update is called once per frame
    void Update()
    {

        if (gDAnimator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1)
        {
            Destroy(this.gameObject);
        }

              
        /*if (TimerCounter < gDAnimator.GetCurrentAnimatorStateInfo(0).length)
        {
            TimerCounter += Time.deltaTime;
        }
        else { Destroy(this.gameObject); }
        */
    }
}
