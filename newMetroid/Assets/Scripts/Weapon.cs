using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public UnityEngine.Transform firepoint;
    public GameObject bulletPrefabs;
    public GameObject CbulletPrefabs;

    // Update is called once per frame
    void Update()
    {
        
        if(!PlayerController.activate)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                Shoot();
                if (PlayerController.isRunning)
                {
                    PlayerController.isRunShooting = true;
                    PlayerController.isStandShooting = false;
                }
                else
                {
                    PlayerController.isStandShooting = true;
                    PlayerController.isRunShooting = false;
                }


            }
            if ((GameObject.Find("cBullet(Clone)") == null))
            {

                if (Input.GetButtonDown("Fire2"))
                {
                    CShoot();
                }
            }
        }
        
    }

  

    void Shoot()
    {
        //shooting logic
        Instantiate(bulletPrefabs, firepoint.position, firepoint.rotation);

    }

    void CShoot()
    {
        //shooting logic
        Instantiate(CbulletPrefabs, firepoint.position, firepoint.rotation);

    }
}

