using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeWorld : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //InvokeRepeating("check", 2.0f, 2f);

    }
   
     int i =1;//각것각것
     
    // Update is called once per frame
    void Update()
    {
        //Debug.Log(ChangeWorldCheck.changeworld);
       
        if (Input.GetKeyDown(KeyCode.L ) )
        {
            if (ChangeWorldCheck.ischanged == false)
            {
                //Debug.Log("Pressed");
                i++;
                //Debug.Log(i);
                if (i % 2 == 0)
                {
                    transform.position += new Vector3(0, -16, 0);
                }
                else
                {
                    transform.position += new Vector3(0, 16, 0);
                }
            }
        }

    }
    
}
