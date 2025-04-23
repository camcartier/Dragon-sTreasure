using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIMana : MonoBehaviour
{

    [SerializeField] Slider manaSlider;
    [SerializeField] PlayerCurrentHealthAndMana PlayerCurrentHealthAndMana;
    [SerializeField] PlayerData playerData;

    void Start()
    {
        manaSlider.maxValue = playerData.MaxMana;
        manaSlider.value = playerData.MaxMana;
    }

    // Update is called once per frame
    void Update()
    {
        manaSlider.value = PlayerCurrentHealthAndMana.currentMana;
        

    }

}