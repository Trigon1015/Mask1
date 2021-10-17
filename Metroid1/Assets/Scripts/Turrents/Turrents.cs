using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turrents : MonoBehaviour
{
    public GameObject[] bullets;
    public bool isFiring = true;
    public float intervalTime;

    private bool fireDirReversed;

    private void Start()
    {
        StartCoroutine(FireCoroutine());
    }

    private IEnumerator FireCoroutine()
    {
        while (isFiring)
        {
            yield return new WaitForSeconds(intervalTime);
            Fire();
        }
    }

    public void Fire()
    {
        GameObject prefab = Instantiate(bullets[Random.Range(0, bullets.Length)], this.transform.parent);

        if (this.transform.localScale.x < 0)
        {
            prefab.transform.localScale = new Vector3(-prefab.transform.localScale.x, prefab.transform.localScale.y, prefab.transform.localScale.z);
            prefab.transform.localPosition = this.transform.localPosition + new Vector3(-1f, 0.52f, 0);
            prefab.GetComponent<Bullets>().Shoot(false);

        }
        else
        {
            prefab.transform.localPosition = this.transform.localPosition + new Vector3(1f, 0.52f, 0);
            prefab.GetComponent<Bullets>().Shoot(true);
        }
            

    }


}
