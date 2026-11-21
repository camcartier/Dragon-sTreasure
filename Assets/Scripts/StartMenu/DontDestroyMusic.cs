using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DontDestroyMusic : MonoBehaviour
{
    private AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        DontDestroyOnLoad(gameObject);
    }

    private void Update()
    {
        if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            audioSource.volume = 0.025f;
        }

        if (SceneManager.GetActiveScene().buildIndex == 2)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnDestroy()
    {
        
    }



    private void OnDisable()
    {
        
    }
}
