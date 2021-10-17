using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cBullet : MonoBehaviour
{
   
    public float cspeed = 0.2f;
    public Rigidbody2D rb;
    public float time = 1f;
    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.right * cspeed;
    }

    private void Update()
    {
        
        
        time -= 5*Time.deltaTime;
        if (time <= 0)
        {
            Destroy(gameObject);
            Debug.Log("destroycbullet");
            time = 1f;
        }
        

    
        
    }


}
