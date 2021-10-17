using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemies : MonoBehaviour
{
    public float speed;

    protected Rigidbody2D rb;
    protected Animator ani;

    private void Awake()
    {
        rb = this.GetComponent<Rigidbody2D>();
        ani = this.GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Player")
            GameManager.instance.player.Die();
        else if(collision.collider.tag != "Hole")
            ChangeDir();
        //Debug.Log("collision");
    }

    public virtual void ChangeDir()
    {

        this.transform.localScale = new Vector3(-this.transform.localScale.x, this.transform.localScale.y, this.transform.localScale.z);


        rb.velocity *= -1f;
    }

    public void Die()
    {
        rb.Sleep();
        ani.SetTrigger("Die");
    }

    public void Destroy()
    {
        Destroy(gameObject);
    }
}
