using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class YDeathCount : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI tmpYDCount;
    [SerializeField] GameObject bossYakkuruSpawner;

    // Start is called before the first frame update
    void Start()
    {
        if(bossYakkuruSpawner == null) { Debug.Log("missing spawner"); }

        if (tmpYDCount == null) { Debug.Log("missing tmp"); }
    }

    // Update is called once per frame
    void Update()
    {
        if (tmpYDCount == null) { return; }
        if (bossYakkuruSpawner == null) { return; }
        tmpYDCount.text = bossYakkuruSpawner.GetComponent<BossYakkuruSpawner>().YakkurusKilled.ToString();
    }
}
