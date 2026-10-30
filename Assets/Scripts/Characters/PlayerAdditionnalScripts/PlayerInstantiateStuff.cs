using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInstantiateStuff : MonoBehaviour
{
    public void InstantiateStuff(GameObject stuff, Transform position)
    {
        Instantiate(stuff,position);
    }
}
