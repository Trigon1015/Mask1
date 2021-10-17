using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D rb;

    [HideInInspector]
    public Animator ani;

    [HideInInspector]
    public  bool isOnGround;
    [HideInInspector]
    public bool isInOutsiderWorld = true;

    public float movingSpeed;
    public float jumpSpeed;
    public float fallRate = 2.5f;
    public float lowJumpRate = 2f;

    private void Awake()
    {
        rb = this.GetComponent<Rigidbody2D>();
        ani = this.GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.D))
            rb.velocity = new Vector2(movingSpeed, rb.velocity.y);

        if (Input.GetKey(KeyCode.A))
            rb.velocity = new Vector2(-movingSpeed, rb.velocity.y);

        if (Input.GetKeyDown(KeyCode.A))
            this.transform.localScale = new Vector3(-Mathf.Abs(this.transform.localScale.x), this.transform.localScale.y, this.transform.localScale.z);

        if( Input.GetKeyDown(KeyCode.D))
            this.transform.localScale = new Vector3(Mathf.Abs(this.transform.localScale.x), this.transform.localScale.y, this.transform.localScale.z);

        if (Input.GetKeyDown(KeyCode.W))
            Jump();
            
        if (rb.velocity.y < 0)
            rb.velocity += Vector2.up * Physics2D.gravity.y * (fallRate - 1f) * Time.deltaTime;
        else if (rb.velocity.y > 0 && !Input.GetKey(KeyCode.W))
            rb.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpRate - 1f) * Time.deltaTime;

    }

    private void Jump()
    {
        if (isOnGround)
        {
            rb.velocity += Vector2.up * jumpSpeed;
            
        }
    }


    public void Die()
    {
        Debug.Log("Player Die");
        AudioManager.instance.Play("Hurt");
        rb.simulated = false;
        rb.Sleep();
        ani.SetBool("Jump", true);
        GameManager.instance.GameOver();
    }

}
