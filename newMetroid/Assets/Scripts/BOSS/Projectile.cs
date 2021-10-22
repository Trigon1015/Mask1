using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed = 0.2f;
    public Rigidbody2D rb;
    public float time = 1f;
    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.up   * speed;
    }

    private void Update()
    {


        //time -= 5 * Time.deltaTime;
        //if (time <= 0)
        //{
        //    Destroy(gameObject);
        //    Debug.Log("destroycbullet");
        //    time = 1f;
        //}




    }


}
