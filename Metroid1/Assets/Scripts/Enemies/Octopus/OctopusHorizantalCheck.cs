using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OctopusHorizantalCheck : MonoBehaviour
{
    private Octopus octopus;

    private void Awake()
    {
        octopus = this.GetComponentInParent<Octopus>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag != "Hole")
            octopus.ChangeDirection();
    }
}
