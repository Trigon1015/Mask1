using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eCrab : MonoBehaviour
{
    public UnityEngine.Transform efirepoint;
    public GameObject bulletPrefabs;
    private float attackSpeed = 3;

    

    void Update()
    {
        attackSpeed -= Time.deltaTime;
        if(attackSpeed<=0)
        {
            attack();
            attackSpeed = 3;
        }
        
    }

    private void attack()
    {
        Instantiate(bulletPrefabs, efirepoint.position, efirepoint.rotation);
    }

    
}
