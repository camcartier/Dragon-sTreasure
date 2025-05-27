using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class NightAndDay : MonoBehaviour
{
    [Header ("general timer")]
    public float DayTimer = 5f;
    public float NightTimer = 5f;
    private float DayTimerCounter;
    private float NightTimerCounter;

    private Camera Camera;
    private Color CameraBaseColor;
    [SerializeField] Light2D CharacterLight;
    [SerializeField] Light2D GlobalLight;

    [Header ("light stats")]
    private float DayIntensityGL;
    private float NightIntensityGL = 0.25f;
    private float NightFalloff = 0.7f;
    private float DayFalloff;
    private float DayIntensityCL;
    private float NightIntensityCL = 0.7f;
    

    void Start()
    {
        Camera = Camera.main;
        CameraBaseColor =  Camera.backgroundColor;

        DayIntensityGL = GlobalLight.intensity;
        DayIntensityCL = CharacterLight.intensity;
        DayFalloff = CharacterLight.falloffIntensity;
    }

    // Update is called once per frame
    void Update()
    {
        DayTimerCounter += Time.deltaTime;

        if (DayTimerCounter > DayTimer)
        {
            GlobalLight.intensity = NightIntensityGL;
            CharacterLight.intensity = NightIntensityCL;
            CharacterLight.falloffIntensity = NightFalloff;

            NightTimerCounter += Time.deltaTime;

            if (NightTimerCounter > NightTimer)
            {
                GlobalLight.intensity = DayIntensityGL;
                CharacterLight.falloffIntensity = DayFalloff;
                CharacterLight.intensity = DayIntensityCL;

                NightTimerCounter = 0f;
                DayTimerCounter = 0f;
            }

        }

        //on va passer a un changement de la light apres ma prochaine game :p
    }
}
