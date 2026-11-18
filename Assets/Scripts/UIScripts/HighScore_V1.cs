using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HighScore_V1 : MonoBehaviour
{
    [SerializeField] GoldData goldData;
    [SerializeField] KillsData killData;
    [SerializeField] TextMeshProUGUI killsTXT;
    [SerializeField] TextMeshProUGUI goldsTXT;

    // Start is called before the first frame update
    void Start()
    {
        goldsTXT.text = "Total gold : " + goldData.goldCount;
        killsTXT.text = "Total kills : " + killData.totalKillCount;
    }

    // Update is called once per frame
    void Update()
    {

    }

    
}
