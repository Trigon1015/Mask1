using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesCenterCheck : MonoBehaviour
{
    private Enemies enemy;

    private void Awake()
    {
        enemy = this.GetComponentInParent<Enemies>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Solid")
            enemy.Die();
    }
}
