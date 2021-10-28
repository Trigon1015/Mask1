using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{

    
    void Start()
    {
        
    }

    void Update()
    {
        
        
        
    }
    static public int bullet=0;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            
            if (PlayerController.canAbsorb)
            {
                bullet = 0;
                Debug.Log("Absorb");
                Debug.Log(bullet );
            }
            else
            {
                PlayerController.ShieldDurability -= 20;
                Debug.Log("parry");
                Debug.Log(PlayerController.ShieldDurability);
                
            }
            
        }
        if (collision.gameObject.tag == "Bullet RED")
        {

            if (PlayerController.canAbsorb)
            {
                bullet = 1;
                Debug.Log("Absorb");
                Debug.Log(bullet );
            }
            else
            {
                PlayerController.ShieldDurability -= 20;
                Debug.Log("parry");
                Debug.Log(PlayerController.ShieldDurability);

            }

        }
        if (collision.gameObject.tag == "Bullet BLUE")
        {

            if (PlayerController.canAbsorb)
            {
                bullet = 2;
                Debug.Log("Absorb");
                Debug.Log(bullet );
            }
            else
            {
                PlayerController.ShieldDurability -= 20;
                Debug.Log("parry");
                Debug.Log(PlayerController.ShieldDurability);

            }

        }





    }

}
