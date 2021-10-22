using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirePoint : MonoBehaviour
{
    public UnityEngine.Transform BossFirepoint;
    public UnityEngine.Transform BossFirepoint1;
    public UnityEngine.Transform BossFirepoint2;
    public GameObject bulletPrefabs;
    private float attackSpeed = 3;

    public Quaternion Fire2;
    private Quaternion Fire3;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        attackSpeed -= Time.deltaTime;
        
        if (attackSpeed <= 0)
        {
            attack();
            attackSpeed = 3;
        }
    }
    private void attack()
    {
        
        Instantiate(bulletPrefabs, BossFirepoint.position, BossFirepoint.rotation);
     
        Instantiate(bulletPrefabs, BossFirepoint1.position, BossFirepoint1.rotation);
        Instantiate(bulletPrefabs, BossFirepoint2.position, BossFirepoint2.rotation);
    }
}
