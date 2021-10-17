using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Octopus : Enemies
{
    public float interval;
    public float jumpSpeed;

    private Animator ani;
    private bool isJumping;

    private void Start()
    {
        ani = this.GetComponent<Animator>();
        StartCoroutine(JumpCoroutine());

    }

    public IEnumerator JumpCoroutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(interval);
            ani.SetTrigger("Jump");
            Jump();
        }
    }

    public void Jump()
    {
        if(this.transform.localScale.x < 0)
            rb.velocity = new Vector2( speed, jumpSpeed);
        else
            rb.velocity = new Vector2( -speed, jumpSpeed);
    }

    public override void ChangeDir()
    {

    }

    public void ChangeDirection()
    {
        this.transform.localScale = new Vector3(-this.transform.localScale.x, this.transform.localScale.y, this.transform.localScale.z);

        rb.velocity = new Vector2(-rb.velocity.x, rb.velocity.y);
    }

}
