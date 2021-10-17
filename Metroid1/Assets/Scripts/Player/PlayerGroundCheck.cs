using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGroundCheck : MonoBehaviour
{
    private Player player;

    private void Awake()
    {
        player = this.GetComponentInParent<Player>();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag != "Holes")
        {
            player.isOnGround = true;
            player.ani.SetBool("IsJumping", false);
        }
           
        //Debug.Log("isOnGround: " + player.isOnGround);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag != "Holes")
        {
            player.isOnGround = false;
            player.ani.SetBool("IsJumping", true);
        }

        //Debug.Log("isOnGround: " + player.isOnGround);
    }
}
