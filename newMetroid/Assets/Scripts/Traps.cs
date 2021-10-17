using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Traps : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
            GameManager.instance.player.Die();
        if (collision.tag == "Enemies")
            collision.GetComponent<Enemies>().Die();
    }
}
