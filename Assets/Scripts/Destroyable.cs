using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyable : MonoBehaviour
{
    //tag script

    public ObjectsData objectData;
    public GameObject healthPanel;
    public GameObject destructionDerby;

    public int currentHealth;
    public int storedHealth;

    private void Start()
    {
        currentHealth = storedHealth = objectData.maxHealth;
        healthPanel.SetActive(false);
    }

    private void Update()
    {
        if (currentHealth == objectData.maxHealth) { return; }
        else { healthPanel.SetActive(true); }

        if (currentHealth == storedHealth){
            return;}


        if (currentHealth <= 0)
        {
            Instantiate(destructionDerby,transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }

}
