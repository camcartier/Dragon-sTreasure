using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateStuff : MonoBehaviour
{
    [SerializeField] GameObject simpleProjectile;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void InstantiateProjectile()
    {
        Instantiate(simpleProjectile, new Vector3(gameObject.transform.position.x,
                                                  gameObject.transform.position.y,
                                                  gameObject.transform.position.z), Quaternion.identity);
    }
}
