using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateStuff : MonoBehaviour
{
    [SerializeField] GameObject simpleProjectile;

    [SerializeField] GameObject projectileStartPoint;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void InstantiateProjectile()
    {
        Instantiate(simpleProjectile, new Vector3(projectileStartPoint.transform.position.x,
                                                  projectileStartPoint.transform.position.y,
                                                  projectileStartPoint.transform.position.z), Quaternion.identity);
    }
}
