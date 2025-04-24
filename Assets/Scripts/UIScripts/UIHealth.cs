using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIHealth : MonoBehaviour
{

    [SerializeField] Slider healthSlider;
    [SerializeField] PlayerCurrentHealthAndMana PlayerCurrentHealthAndMana;
    [SerializeField] PlayerData playerData;

    void Start()
    {
        healthSlider.maxValue = playerData.MaxHealth;
        healthSlider.value = playerData.MaxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        healthSlider.value = PlayerCurrentHealthAndMana.currentHealth;
        

    }

}