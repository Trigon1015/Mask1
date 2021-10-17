using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullets : MonoBehaviour
{
    public float speed;
    private Rigidbody2D rb;

    private void Awake()
    {
        rb = this.GetComponent<Rigidbody2D>();

    }

    public void Shoot(bool isRight)
    {
        if (isRight)
            rb.velocity = Vector2.right * speed;
        else
            rb.velocity = Vector2.left * speed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        switch (collision.collider.tag)
        {
            case "Player":
                {
                    GameManager.instance.player.Die();
                    Destroy(gameObject);
                    break;
                }
            case "Enemies":
                {
                    collision.collider.GetComponent<Enemies>().Die();
                    Destroy(gameObject);
                    break;
                }
            case "Hole":
                {
                    Debug.Log("Hit Hole");
                    break;
                }
            default:
                {
                    Destroy(gameObject);
                    break;
                }

        }
            
    }
}
