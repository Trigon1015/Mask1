using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCenterCheck : MonoBehaviour
{
    public float countDownDuration = 2f;

    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Solid")
            StartCoroutine(CountDown(countDownDuration));
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Solid")
            StopAllCoroutines();
    }

    private IEnumerator CountDown(float duration)
    {
        yield return new WaitForSeconds(duration);
        GameManager.instance.player.Die();
    }
}
