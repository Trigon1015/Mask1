using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeWorldCheck : MonoBehaviour
    
{
    public float CheckCircle;
    public static bool changeworld=true ;
    public LayerMask whatIs;
    public static  bool ischanged;

  

    // Start is called before the first frame update
    void Start()
    {
        
    }
   
    // Update is called once per frame
    void Update()
    {
        if (PlayerController.player.y >-4)
        { 
            transform.position = PlayerController.player + new Vector2(0, -16);
        }
        else
        {
            transform.position = PlayerController.player + new Vector2(0, 16);

        }
        Check();
        


    }




     void Check()
    {
        ischanged = Physics2D.OverlapCircle(transform .position, CheckCircle, whatIs);
        //Debug.Log(ischanged);
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform .position, CheckCircle);
    }
}
