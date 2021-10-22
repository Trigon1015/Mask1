using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public float speed = 20f;
    public Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.right * speed; 
    }

    private void OnTriggerEnter2D(Collider2D info)
    {
        if(info.gameObject.tag == "Environment")
        {
            Destroy(gameObject);
        }

        if(info.gameObject.tag == "Player")
        {
            PlayerManager.PlayerHP--;
            //Debug.Log("HP"+PlayerManager.PlayerHP);



            Destroy(gameObject);

        }

        if (info.gameObject.tag == "Shield")
        {
      
            Destroy(gameObject);

        }

    }
}
