using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public UnityEngine.Transform firepoint;
    public UnityEngine.Transform crouchfirepoint;
    public GameObject bulletPrefabs;
    public GameObject bulletPrefabs1;
    public GameObject bulletPrefabs2;
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
                if(PlayerController.isCrouching)
                {
                    PlayerController.isCrouchShooting = true;
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
        
        if(!PlayerController.isCrouching)
        {
            if (Shield.bullet ==0 )
            {
                Instantiate(bulletPrefabs, firepoint.position, firepoint.rotation);
            }
            if (Shield.bullet == 1)
            {
                Instantiate(bulletPrefabs1, firepoint.position, firepoint.rotation);
            }
            if (Shield.bullet == 2)
            {
                Instantiate(bulletPrefabs2, firepoint.position, firepoint.rotation);
            }

        }
        else
        {
            if (Shield.bullet == 0)
            {
                Instantiate(bulletPrefabs, crouchfirepoint.position, firepoint.rotation);
            }
            if (Shield.bullet == 1)
            {
                Instantiate(bulletPrefabs1, crouchfirepoint.position, firepoint.rotation);
            }
            if (Shield.bullet == 2)
            {
                Instantiate(bulletPrefabs2, crouchfirepoint.position, firepoint.rotation);
            }
            
        }
        

    }

    void CShoot()
    {
        //shooting logic
        if (!PlayerController.isCrouching)
        {
            Instantiate(CbulletPrefabs, firepoint.position, firepoint.rotation);
        }
        else
        {
            Instantiate(CbulletPrefabs, crouchfirepoint.position, firepoint.rotation);
        }
        

    }
}

