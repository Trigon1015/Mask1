using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class  UpgradeDoubleJump: MonoBehaviour
{
    public ParticleSystem upgradeEffects;
    public Transform playerPosition;
    

    private void OnTriggerEnter2D (Collider2D collider)
    {
        if(collider.tag == "Player")
        {
            Debug.Log("upgrade");
            PlayerController.availableJumps = 2;
            Instantiate(upgradeEffects, playerPosition);
            Destroy(gameObject);
        }
    }
}
