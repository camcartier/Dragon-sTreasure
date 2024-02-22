using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyInTime : MonoBehaviour
{
    public float AliveMaxTime;
    private float AliveTimerCounter;

    // Update is called once per frame
    void Update()
    {
        if (AliveTimerCounter < AliveMaxTime) { AliveTimerCounter++; } else { Destroy(this.gameObject); }
    }
}
