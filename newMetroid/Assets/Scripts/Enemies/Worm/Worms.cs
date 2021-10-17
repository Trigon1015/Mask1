using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Worms : Enemies
{
    private void Start()
    {
        rb.velocity = Vector2.left * speed;
    }

    

}
