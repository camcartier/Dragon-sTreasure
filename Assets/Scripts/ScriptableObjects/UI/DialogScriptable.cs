using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.UI;

[CreateAssetMenu]
public class DialogScriptable : ScriptableObject
{
     public Sprite[] portraits = new Sprite[10];
     public string[] titles = new string[10];
     public string[] sentences = new string[10];

    public float typeSpeed;

    [SerializeField] AudioSource speakingSound;
}
