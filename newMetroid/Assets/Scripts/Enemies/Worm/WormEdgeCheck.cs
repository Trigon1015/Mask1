using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WormEdgeCheck : MonoBehaviour
{
    private Worms worm;

    private void Start()
    {
        worm = this.GetComponentInParent<Worms>();
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.tag != "Hole")
            worm.ChangeDir();
    }

}
