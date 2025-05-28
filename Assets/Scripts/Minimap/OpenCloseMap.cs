using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class OpenCloseMap : MonoBehaviour
{

    [SerializeField] GameObject openedMap;
    [SerializeField] GameObject closedMap;

    private void Start()
    {
        if (openedMap == enabled)
        {
            openedMap.SetActive(false);
        }
        if (closedMap != enabled) { closedMap.SetActive(true); }

    }

    public void openMap()
    {
        closedMap.SetActive(false);
        openedMap.SetActive(true);
    }
    public void closeMap()
    {
        closedMap.SetActive(true);
        openedMap.SetActive(false);
    }
}
