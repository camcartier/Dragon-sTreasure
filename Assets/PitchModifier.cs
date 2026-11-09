using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PitchModifier : MonoBehaviour
{
    private AudioSource audioSource;
    public float pitchValue;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        audioSource.pitch = pitchValue;
    }


}
