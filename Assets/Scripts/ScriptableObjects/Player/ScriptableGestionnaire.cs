using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptableGestionnaire : MonoBehaviour
{
    public PlayerData PlayerData ;

    public PlayerCurrentHealthAndMana PlayerCurrentHealthAndMana;

    /*[Header("Levels?")]
    public PlayerData PlayerDataLVL1;
    public PlayerData PlayerDataLVL2;
    public PlayerData PlayerDataLVL3;
    public PlayerData PlayerDataLVL4;
    public PlayerData PlayerDataLVL5;*/
  

    void Start()
    {
        PlayerData = ScriptableObject.CreateInstance<PlayerData>();

        PlayerCurrentHealthAndMana = ScriptableObject.CreateInstance< PlayerCurrentHealthAndMana>();

        /*PlayerDataLVL1 = new PlayerData();
        PlayerDataLVL2 = new PlayerData();
        PlayerDataLVL3 = new PlayerData();
        PlayerDataLVL4 = new PlayerData();
        PlayerDataLVL5 = new PlayerData();*/


    }



}
